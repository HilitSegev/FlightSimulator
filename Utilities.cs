using System;
using MathNet.Numerics.Statistics;
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
            XmlNodeList names = xml.SelectNodes("/PropertyList/generic/input/chunk/name");//.GetElementsByTagName("name");
            //XmlNodeList names = xml.GetElementsByTagName("name");
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

        public static Double avg(List<Double> x)
        {
            double sum = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sum += x[i];
            }

            return sum / x.Count;
        }

        public static Double var(List<Double> x)
        {
            Double sumPow = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sumPow += Math.Pow(x[i], 2.0);
            }
            Double result = (sumPow / x.Count) - Math.Pow(avg(x), 2.0);
            return result;
        }

        // returns the covariance of X and Y
        public static Double cov(List<Double> x, List<Double> y)
        {
            List<Double> xy = new List<Double>();
            for (int i = 0; i < x.Count; i++)
            {
                xy.Add(x[i] * y[i]);
            }
            Double cov = avg(xy) - (avg(x) * avg(y));
            return cov;
        }
    }


}
