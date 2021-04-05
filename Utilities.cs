using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WPF
{
    public static class Utilities
    {
        public static XmlNodeList parseXML(string filePath)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(filePath);
            XmlNodeList names = xml.GetElementsByTagName("name");
            return names;
        }

        public static List<String> getFeatureNamesList(string filePath)
        {
            XmlNodeList parsedXML = parseXML(filePath);

            // get list of names
            List<String> listOfFeaturesNames = new List<String>();
            foreach (XmlNode node in parsedXML)
            {
                listOfFeaturesNames.Add(node.FirstChild.Value);
            }
            return listOfFeaturesNames;
        }
    }
}
