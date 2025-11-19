using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson7
{
    public class Calls
    {
        private XDocument doc;
        private string FILENAME;

        public Calls(string FILENAME)
        {
            this.FILENAME = FILENAME;
            doc = XDocument.Load(FILENAME);
        }

        //get all times of the calls  who called miriam from phone 1:
        public List<string> func1() { 
        var x1 = doc.Root?.Elements()?.Where(e => e.Attribute("num")?.Value == "1")?
                                    .ToList().First()?.Element("calls")?.Elements("call")
                                    .Where(e => e.Attribute("destination")?.Value == "miriam")
                                    .OrderBy(e => Convert.ToInt16(e.Attribute("length")?.Value))?
                                    .Select(e => e.Attribute("length")?.Value).ToList();
            return x1;
    }

        //get all numbers of phone that spoke to shira
        public List<string> func2()
        {
            return doc.Root?.Descendants("call")
                              .Where(e => e.Attribute("destination")?.Value == "shira")
                              .Select(e => e.Ancestors("phone")?.ToList()[0]?.Attribute("num")?.Value)
                              .Distinct()
                              .ToList()?? new List<string>();

        }

        //get all phones that had calls over 10 min
        public List<string> func3()
        {
            var x3 = doc.Root?.Descendants("call")
                              .Where(e => Convert.ToInt64(e.Attribute("length")?.Value) > 10)
                              .Select(e => e.Ancestors("phone")?.ToList()[0]?.Attribute("num")?.Value)
                              .Distinct()
                              .ToList();
            return x3;
        }

        //add a phone call
        public void AddCall(string phoneNum, string time, string length, string destination)
        {
            XElement newCall = new XElement("call",
                new XAttribute("start", time),
                new XAttribute("length", length),
                new XAttribute("destination", destination));

            XElement phone = doc.Root?.Elements("phone")
                .FirstOrDefault(e => e.Attribute("num")?.Value == phoneNum);

            phone?.Element("calls")?.Add(newCall);
            doc.Save(FILENAME);
        }

        //delete phonecall by destination and length
        public void DeleteCall(string phoneNum, string destination)
        {
            var call = doc.Root?.Elements("phone")
                .Where(e => e.Attribute("num")?.Value == phoneNum)
                .FirstOrDefault()?
                .Element("calls")?
                .Elements("call")
                .FirstOrDefault(e => e.Attribute("destination")?.Value == destination);

            if (call != null)
            {
                call.Remove();
                doc.Save(FILENAME);
            }
        }
    }
}
