using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPF
{
    public class TimeSeries
    {
        private List<List<Double>> ts;
        public List<int> highestCorrelationInds;
        public TimeSeries(string csvPath)
        {
            this.ts = new List<List<Double>>();
            this.highestCorrelationInds = new List<int>();
            // populate line
            StreamReader sr = new StreamReader(csvPath);

            // keep reading from file and send to server
            string line = sr.ReadLine();

            while (line != null)
            {
                List<Double> row = new List<Double>();
                foreach (string elem in line.Split(","))
                {
                    row.Add(Double.Parse(elem));
                }
                ts.Add(row);

                // read new line
                line = sr.ReadLine();
            }
        }

        public List<Double> getRow(int i)
        {
            return ts[i];
        }

        public String printRow(int i)
        {
            List<Double> row = this.getRow(i);
            String stringRow = "";
            for (int j = 0; j < this.getNumOfColumns(); j++)
            {
                stringRow += row[j].ToString();
                if (j < this.getNumOfColumns() - 1)
                {
                    stringRow += ",";
                }
                else
                {
                    stringRow += "\n";
                }

            }
            return stringRow;
        }

        public int getNumOfRows()
        {
            return ts.Count;
        }

        public int getNumOfColumns()
        {
            return ts[0].Count;
        }

        public List<Double> getColumn(int i)
        {
            List<Double> col = new List<Double>();
            for (int j = 0; j < this.getNumOfRows(); j++)
            {
                col.Add(this.getRow(j)[i]);
            }
            return col;
        }

        public int BestCorrelation(int index)
        {
            Double maxCorr = -1;
            int maxCorrIdx = 0;
            Double currentCorr;

            for (int i = 0; i < this.getNumOfColumns(); i++)
            {
                currentCorr = Correlation.Pearson(this.getColumn(index), this.getColumn(i));
                if (currentCorr > maxCorr && i != index)
                {
                    maxCorr = currentCorr;
                    maxCorrIdx = i;
                }
            }
            return maxCorrIdx;
        }

        public void setHighestCorrelations()
        {
            for (int i = 0; i < this.getNumOfColumns(); i++)
            {
                highestCorrelationInds.Add(this.BestCorrelation(i));
            }
        }
    }
}
