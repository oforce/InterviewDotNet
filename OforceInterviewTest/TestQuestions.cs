using OforceInterviewTest.Models;
using OforceInterviewTest.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OforceInterviewTest
{
    public class TestQuestions
    {
        public static List<DataSet> dataList = new List<DataSet>(); 
        public static int QuestionOne()
        {
            #region Setup - Ignore
            if (!dataList.Any())
            {
                dataList = CsvFileReader.Read();
            }
            #endregion
            //return total count from dataList
            throw new NotImplementedException();
        }

        public static int QuestionTwo()
        {
            #region Setup - Ignore
            if (!dataList.Any())
            {
                dataList = CsvFileReader.Read();
            }
            #endregion
            //return count for how many Unique Ids have more than 5 records in dataList
            throw new NotImplementedException();
        }
        public static GroupedData? QuestionThreeA()
        {
            #region Setup - Ignore
            if (!dataList.Any())
            {
                dataList = CsvFileReader.Read();
            }
            #endregion
            //Use the GroupedData Class
            //1. Group Data over the Id, get Gross commissions, Gross deductions, and net Total
            //2. Perform a grouping on column Id so that only 1 record per Id exist and Sum the grouped data of commissions and deductions
            //3. Create net total (gross commissions - gross deductions) Round two decimal places
            //return specific record 0702b621-e076-4d96-a219-3a7e4208c4f7
            throw new NotImplementedException();
        }
        public static int QuestionThreeB()
        {
            #region Setup - Ignore
            if (!dataList.Any())
            {
                dataList = CsvFileReader.Read();
            }
            #endregion
            //1. Group Data over the Id, get Gross commissions, Gross deductions, and net Total
            //2. Perform a grouping on column Id so that only 1 record per Id exist and Sum the grouped data of commissions and deductions
            //3. Create net total (gross commissions - gross deductions) Round two decimal places
            //Return Total number of records in new list
            throw new NotImplementedException();
        }
        public static GroupedData? QuestionThreeC()
        {
            #region Setup - Ignore
            if (!dataList.Any())
            {
                dataList = CsvFileReader.Read();
            }
            #endregion
            //Use the GroupedData Class
            //1. Group Data over the Id, get Gross commissions, Gross deductions, and net Total. You may use LINQ, For loops, ForEach, etc.
            //2. Perform a grouping on column Id so that only 1 record per Id exist and Sum the grouped data of commissions and deductions
            //3. Create net total (gross commissions - gross deductions) Round two decimal places
            //Return first record in list
            throw new NotImplementedException();
        }

        public static GroupedData? QuestionFour(string guid)
        {
            #region Setup - Ignore
            if (!dataList.Any())
            {
                dataList = CsvFileReader.Read();
            }
            #endregion
            //1. Perform same actions from question 2, but now us Parallelism to do your group
            //2. You must accept a string guid, and then from your new list return a GroupData record
            //3. Remember to Create net total (gross commissions - gross deductions) and Round two decimal places
            throw new NotImplementedException();
        }
    }
}
