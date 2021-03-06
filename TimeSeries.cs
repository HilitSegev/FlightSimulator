using MathNet.Numerics.Statistics;
using OxyPlot;
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
                currentCorr = Math.Abs(Correlation.Pearson(this.getColumn(index), this.getColumn(i)));
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

        public List<DataPoint> getDataPointSeries(int i, int j)
        {
            List<DataPoint> result = new List<DataPoint>();
            List<Double> col1 = this.getColumn(i);
            List<Double> col2 = this.getColumn(j);

            for (int k = 0; k < this.getNumOfRows(); k++)
            {
                result.Add(new DataPoint(col1[k], col2[k]));
            }

            return result;
        }

        public List<DataPoint> getRegressionLine(int i, int j)
        {
            List<Double> x = this.getColumn(i);
            List<Double> y = this.getColumn(j);

            // calculate elements for regression line formula
            Double sumXX = 0;
            Double sumXY = 0;
            Double sumX = 0;
            Double sumY = 0;

            for (int k = 0; k < x.Count; k++)
            {
                sumX += x[k];
                sumY += y[k];
                sumXX += x[k] * x[k];
                sumXY += x[k] * y[k];
            }

            // get regression line: y = a*x + b
            Double a = Utilities.cov(x, y) / (Utilities.var(x) + 1 / 1e13); //TODO: better solution +1/1e9 to avoid dividing by 0
            Double b = Utilities.avg(y) - a * Utilities.avg(x);
            List<DataPoint> result = new List<DataPoint>();
             // we want to take the points up to the edges
            Double yMin = y.Minimum();
            Double yMax = y.Maximum();
            
            // x is full of 0s
            if ((Utilities.avg(x) == 0) && (Utilities.var(x) == 0))
            {
                a = 1e14;
                result.Add(new DataPoint(0, yMin));
                result.Add(new DataPoint(0, yMax));
                return result;
            }
           
           
            for (int k = 0; k < x.Count; k++)
            {
                result.Add(new DataPoint(x[k], Math.Max(Math.Min((a * x[k] + b), yMax), yMin)));
            }

            return result;
        }


    }
}
