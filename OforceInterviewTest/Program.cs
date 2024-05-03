// See https://aka.ms/new-console-template for more information
using OforceInterviewTest;
using OforceInterviewTest.Models;
using OforceInterviewTest.Utilities;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Http.Headers;

//2 mins to research the question
//5 mins to implement solution

//Returns a List<DataSet>
//Guid - Id
//decimal - Commission
//decimal - Deduction
var dataList = CsvFileReader.Read();

Console.WriteLine("******************************************************************************************");

#region Question 1 - Output total count from dataList
//Requirements
//1. Print out count of total from dataList

//Output
//Total number of records in dataList
#endregion

Console.WriteLine("******************************************************************************************");

#region Question 2 - Display count for how many Unique Ids have more than 5 records in dataList
//Requirements
//1. Get a count on dataList for how many unique Ids have more than 5 records in dataList

//Output
//Total number of records in dataList where unique Id has more than 5 records
#endregion

Console.WriteLine("******************************************************************************************");

#region Question 3 - Group Data over the Id, get Gross commissions, Gross deductions, and net Total
//Requirements
//1. Use the GroupedData class to group into
//2. Measure the time it takes from the start of grouping to the end.
//3. Perform a grouping on column Id so that only 1 record per Id exist and Sum the grouped data of commissions and deductions
//4. Create net total (gross commissions - gross deductions)

//Output:
//3A. Total time to group the dataList
//3B. Total number of records in new list
//3C. Output the first record from GroupData List - You can just comma delimite them.
#endregion

Console.WriteLine("******************************************************************************************");

#region Question 4 - Perform same requirments from question 3, but using parallelism
//Requirements
//1. Perform same actions from question 2, but now us Parallelism to do your group
//2. Print out time it took for this

//Output:
//4A. Total time grouping took
//4B. Total number of records in new list
//4C. Output the first record from GroupData List - You can just comma delimite them.
#endregion

Console.WriteLine("******************************************************************************************");

#region Question 5 - Accuracy Check

//Requirements:
//1. Take your GroupedData list and output the results for Id: f2ce7dac-176e-4359-9b41-e2d2c602a48f
//2. Take your GroupedData list and output the results for Id: 14df0c2c-4860-400f-ba2a-45304cab4f78
//3. Take your GroupedData list and output the results for Id: 9749ed12-66a8-4657-9563-951484a3499b
//4. Take your GroupedData list and output the results for Id: 0e0c3604-1eea-4b29-a1f8-6e84609be40c

#endregion

Console.WriteLine("******************************************************************************************");

#region Bonus Question - Show how much faster or slower the parallel version was
//Requirements compare how much slower, or faster the parallel version was

//Output:
//1. show how much time the sync process took
//2. show how much time the parallel process took
//3. show how much faster or slow the parallel process was in percent. round 2 decimal places
//3 continued - Specify with text if it was 'More' or 'Less' efficient and don't represent the diff as a negative
#endregion

Console.WriteLine("******************************************************************************************");
