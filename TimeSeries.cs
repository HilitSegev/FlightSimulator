using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WPF
{
    class TimeSeries
    {
        private List<List<Double>> ts;
        public TimeSeries(string csvPath)
        {
            this.ts = new List<List<Double>>();

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
    }
}
