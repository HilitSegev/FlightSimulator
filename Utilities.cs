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

        public static List<Double> getColumn(List<String> rowsList, int idx)
        {
            List<Double> column = new List<Double>();
            foreach (String row in rowsList)
            {
                column.Add(Double.Parse(row.Split(",")[idx]));
            }
            return column;
        }

        public static int bestCorrelation(List<String> rowsList, int index)
        {
            Double maxCorr = -1;
            int maxCorrIdx = 0;
            Double currentCorr;
            int numOfRows = rowsList.Count;
            int numOfColumns = rowsList[0].Split(",").Length;

            for (int i = 0; i < numOfColumns; i++)
            {
                currentCorr = Correlation.Pearson(getColumn(rowsList, index), getColumn(rowsList, i));
                if (currentCorr > maxCorr && i != index)
                {
                    maxCorr = currentCorr;
                    maxCorrIdx = i;
                }
            }
            return maxCorrIdx;
        }
    }


}
