using OforceInterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OforceInterviewTest.Utilities
{
    public class CsvFileReader
    {
        public static List<DataSet> Read()
        {
            List<DataSet> dataSetList = ReadCsv(Globals.TestFilePath);
            return dataSetList;
        }

        private static List<DataSet> ReadCsv(string filePath)
        {
            List<DataSet> dataSetList = new List<DataSet>();

            // Read the CSV file line by line
            using (var reader = new StreamReader(filePath))
            {
                // Skip the header line
                reader.ReadLine();

                // Read each data row
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // Parse the values into a DataSet object
                    var data = new DataSet
                    {
                        Id = Guid.Parse(values[0]),
                        Commission = decimal.Parse(values[1]),
                        Deduction = decimal.Parse(values[2])
                    };

                    dataSetList.Add(data);
                }
            }

            return dataSetList;
        }

    }
}
