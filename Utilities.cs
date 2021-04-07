using System;
using System.Collections.Generic;
using System.Xml;
namespace WPF
{
    public static class Utilities
    {
        public static XmlNodeList parseXML(string filePath)
        {
            // TODO: READ ONLY INPUT (We read both input and output so the list contains duplicates)
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
