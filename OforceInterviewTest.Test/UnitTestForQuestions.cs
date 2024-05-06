using NuGet.Frameworks;

namespace OforceInterviewTest.Test
{
    public class UnitTestForQuestions
    {
        [Fact]
        public void Question_One_Test()
        {
            Assert.True(TestQuestions.QuestionOne() == 1_000_000); 
        }

        [Fact]
        public void Question_Two_Test()
        {
            Assert.True(TestQuestions.QuestionTwo() == 65705);
        }
        [Fact]
        public void Question_Three_A_Test()
        {
            Assert.True(TestQuestions.QuestionThreeA() != null);
        }

        [Fact]
        public void Question_Three_B_Test()
        {
            Assert.True(TestQuestions.QuestionThreeB() == 200_756);
        }

        [Fact]
        public void Question_Three_C_Test()
        {
            var record = TestQuestions.QuestionThreeC();
            Assert.True(record != null && record.Id == new Guid("3228fe14-dc3d-4fe5-83d7-f66e35919329"));
        }

        [Fact]
        public void Question_Four_Test()
        {
            var recordA = TestQuestions.QuestionFour("f2ce7dac-176e-4359-9b41-e2d2c602a48f");
            var recordB = TestQuestions.QuestionFour("14df0c2c-4860-400f-ba2a-45304cab4f78");
            var recordC = TestQuestions.QuestionFour("9749ed12-66a8-4657-9563-951484a3499b");
            var recordD = TestQuestions.QuestionFour("0e0c3604-1eea-4b29-a1f8-6e84609be40c");

            if (recordA == null || recordB == null || recordC == null || recordD == null)
                Assert.False(true, "One of the records was null.");

            if(recordA?.NetTotal != 5300.91M)
                Assert.False(true, $"Record A net total is not correct. Expected 5300.91, but got {recordA.NetTotal}");
            if (recordB?.NetTotal != 10590.04M)
                Assert.False(true, $"Record B net total is not correct. Expected 10590.04, but got {recordB.NetTotal}");
            if (recordC?.NetTotal != 7959.38M)
                Assert.False(true, $"Record C net total is not correct. Expected 7959.38, but got {recordC.NetTotal}");
            if (recordD?.NetTotal != 13072.90M)
                Assert.False(true, $"Record D net total is not correct. Expected 13072.90, but got {recordD.NetTotal}");

            Assert.True(true, null);
        }
    }
}