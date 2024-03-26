namespace ClassLibraryPrintNumbers.BusinessLogic.Tests
{
    [TestClass]
    public class PrintNumbersServiceTests
    {
        [TestMethod]
        public void When_ValidInputs_Return_ValidResult()
        {
            var result = PrintNumbersService.GetNumbersToPrint(15, 3, 5, "John", "Smith").ToList();

            Assert.AreEqual(15, result.Count);
            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("John", result[2]);
            Assert.AreEqual("Smith", result[4]);
            Assert.AreEqual("John Smith", result[14]);
        }

        [TestMethod]
        public void When_InvalidUpperBound_ThrowException()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(-1, 3, 5, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("upperBound"));

            result = result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(0, 3, 5, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("upperBound"));
        }

        [TestMethod]
        public void When_InvalidFirstMod_ThrowException()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, -1, 5, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("firstMod"));

            result = result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, 0, 5, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("firstMod"));
        }

        [TestMethod]
        public void When_InvalidSecondMod_ThrowException()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, 3, -1, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("secondMod"));

            result = result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, 3, 0, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("secondMod"));
        }

        [TestMethod]
        public void When_InvalidFirstAndSecondMod_ThrowException()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, 3, 3, "John", "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("firstMod"));
            Assert.IsTrue(result.Message.Contains("secondMod"));
        }

        [TestMethod]
        public void When_InvalidFirstModText_ThrowException()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, 3, 15, null, "Smith").ToList());
            Assert.IsTrue(result.Message.Contains("firstModText"));
        }

        [TestMethod]
        public void When_InvalidSecondModText_ThrowException()
        {
            var result = Assert.ThrowsException<ArgumentException>(() => PrintNumbersService.GetNumbersToPrint(15, 3, 15, "John", null).ToList());
            Assert.IsTrue(result.Message.Contains("secondModText"));
        }

        [TestMethod]
        [TestCategory("LongRunning")]
        public void When_ValidInputMaxValue_Return_ValidResult()
        {
            var upperBound = int.MaxValue;
            var result = PrintNumbersService.GetNumbersToPrint(upperBound, 3, 5, "John", "Smith");
            var counter = 0;
            string firstItem = string.Empty;
            string thirdItem = string.Empty;
            string fifthItem = string.Empty;
            string fifteenthItem = string.Empty;

            foreach (var item in result)
            {
                counter++;

                if (counter == 1)
                {
                    firstItem = item;
                }
                else if (counter == 3)
                {
                    thirdItem = item;
                }
                else if (counter == 5)
                {
                    fifthItem = item;
                }
                else if (counter == 15)
                {
                    fifteenthItem = item;
                }
            }

            Assert.AreEqual(upperBound, counter);
            Assert.AreEqual("1", firstItem);
            Assert.AreEqual("John", thirdItem);
            Assert.AreEqual("Smith", fifthItem);
            Assert.AreEqual("John Smith", fifteenthItem);
        }
    }
}