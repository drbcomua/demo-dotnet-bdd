using Allure.Xunit.Attributes;
using RestSharp;
using Xunit;
using Xunit.Abstractions;

namespace APITestProject
{
    [AllureSuite("Dice Roller Test")]
    public class DiceRollerTest
    {
        const int diceSides = 6;
        private readonly ITestOutputHelper outputHelper;

        public DiceRollerTest(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        //[AllureXunit(DisplayName = "Should Have Enough Enthropy With 100 Samples Test")]
        //public void ShouldHaveEnoughEnthropyWith100SamplesTest()
        //{
        //    int numOfROlls = 100;
        //    double maxDevaiation  = 0.05;
        //    int[] rolls = GetRolls(numOfROlls);
        //    for (int i = 0; i < diceSides; ++i)
        //    {
        //        outputHelper.WriteLine($"[{i + 1}]: {rolls[i]}/{numOfROlls}");
        //        Assert.True(Deviation(rolls[i], diceSides, numOfROlls) < maxDevaiation,
        //            $"Side [{i + 1}] appeared {rolls[i]} times of {numOfROlls} so deviation {Deviation(rolls[i], diceSides, numOfROlls)} is greater than {maxDevaiation}");
        //    }
        //}

        [AllureXunitTheory]
        [MemberData(nameof(Data))]
        public void EnoughEnthropyTest(int numOfROlls, double maxDevaiation)
        {
            int[] rolls = GetRolls(numOfROlls);
            for (int i = 0; i < diceSides; ++i)
            {
                outputHelper.WriteLine($"[{i + 1}]: {rolls[i]}/{numOfROlls}");
                Assert.True(Deviation(rolls[i], diceSides, numOfROlls) < maxDevaiation,
                    $"Side [{i + 1}] appeared {rolls[i]} times of {numOfROlls} so deviation {Deviation(rolls[i], diceSides, numOfROlls)} is greater than {maxDevaiation}");
            }
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1000, 0.05 },
                new object[] { 500, 0.05 },
                new object[] { 100, 0.05 },
            };

        private int[] GetRolls(int rolls)
        {
            var result = new int[diceSides];

            var client = new RestClient($"http://localhost:8080/{rolls}/{diceSides}/");
            var request = new RestRequest();

            var response = client.Get<ResultObj>(request);

            response.listeDes.ForEach(i => ++result[i.resultat - 1]);

            return result;
        }

        private double Deviation(int rolls, int sides, int totalRolls)
        {
            return Math.Abs(rolls / (double)totalRolls - 1 / (double)sides);
        }
    }
}