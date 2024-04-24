namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestRunWithoutParameters()
        {
            // Test application does not throw error when passed no parameter sample data.
            FrequencyAnalysis.Program.Main(Array.Empty<string>());
        }

        [TestMethod]
        public void IterateDataTestCaseTrue()
        {
            // Test for "The three did feed the deer The quick brown fox jumped over the lazy dog"
            // With case sensitivity true.
            var expectedAccepted = 58;
            var expectedIgnored = 15;
            var data = FrequencyAnalysis.Program.GetData("C:\\TextFrequencyAnalysis\\UnitTests\\TestData\\SampleDataSet.txt");
            var (_, ignoredCharacters, acceptedCharacters, _) = FrequencyAnalysis.Program.IterateData(data, true);

            Assert.AreEqual(acceptedCharacters, expectedAccepted);
            Assert.AreEqual(ignoredCharacters, expectedIgnored);
        }

        [TestMethod]
        public void IterateDataTestCaseFalse()
        {
            // Test for "The three did feed the deer The quick brown fox jumped over the lazy dog"
            // With case sensitivity false.
            var expectedAccepted = 58;
            var expectedIgnored = 15;
            var data = FrequencyAnalysis.Program.GetData("C:\\TextFrequencyAnalysis\\UnitTests\\TestData\\SampleDataSet.txt");
            var (_, ignoredCharacters, acceptedCharacters, _) = FrequencyAnalysis.Program.IterateData(data, false);

            Assert.AreEqual(acceptedCharacters, expectedAccepted);
            Assert.AreEqual(ignoredCharacters, expectedIgnored);
        }

        [TestMethod]
        public void IterateDataTestLargeData()
        {
            // Test with large dataset.
            // With case sensitivity true.
            var expectedAccepted = 58188066;
            var expectedIgnored = 12087255;
            var data = FrequencyAnalysis.Program.GetData("C:\\TextFrequencyAnalysis\\UnitTests\\TestData\\LargeDataSet.txt");
            var (_, ignoredCharacters, acceptedCharacters, _) = FrequencyAnalysis.Program.IterateData(data, true);

            Assert.AreEqual(acceptedCharacters, expectedAccepted);
            Assert.AreEqual(ignoredCharacters, expectedIgnored);
        }

        [TestMethod]
        public void IllegalCharacterData()
        {
            // Test with illegal character dataset.
            // With case sensitivity true.
            var expectedAccepted = 59;
            var expectedIgnored = 75;
            var data = FrequencyAnalysis.Program.GetData("C:\\TextFrequencyAnalysis\\UnitTests\\TestData\\IllegalCharacterDataSet.txt");
            var (_, ignoredCharacters, acceptedCharacters, _) = FrequencyAnalysis.Program.IterateData(data, true);

            Assert.AreEqual(acceptedCharacters, expectedAccepted);
            Assert.AreEqual(ignoredCharacters, expectedIgnored);
        }
    }
}