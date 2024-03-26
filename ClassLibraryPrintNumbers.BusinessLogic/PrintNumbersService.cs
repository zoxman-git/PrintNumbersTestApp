namespace ClassLibraryPrintNumbers.BusinessLogic
{
    public class PrintNumbersService
    {
        public static IEnumerable<string> GetNumbersToPrint(int upperBound, int firstMod, int secondMod, string firstModText, string secondModText)
        {
            if (upperBound <= 0)
                throw new ArgumentException($"Please provide a positive {nameof(upperBound)} value");

            if (firstMod <= 0)
                throw new ArgumentException($"Please provide a positive {nameof(firstMod)} value");

            if (secondMod <= 0)
                throw new ArgumentException($"Please provide a positive {nameof(secondMod)} value");

            if (firstMod == secondMod)
                throw new ArgumentException($"Please provide different values for {nameof(firstMod)} and {nameof(secondMod)}");

            if (string.IsNullOrWhiteSpace(firstModText))
                throw new ArgumentException($"Please provide a non-empty {nameof(firstModText)} value");

            if (string.IsNullOrWhiteSpace(secondModText))
                throw new ArgumentException($"Please provide a non-empty {nameof(secondModText)} value");

            string outputValue;
            int numberTemp;

            for (var i = 0; i < upperBound; i++)
            {
                numberTemp = i + 1;

                if (numberTemp % firstMod == 0 && numberTemp % secondMod == 0)
                {
                    outputValue = $"{firstModText} {secondModText}";
                }
                else if (numberTemp % firstMod == 0)
                {
                    outputValue = firstModText;
                }
                else if (numberTemp % secondMod == 0)
                {
                    outputValue = secondModText;
                }
                else
                {
                    outputValue = numberTemp.ToString();
                }

                yield return outputValue;
            }
        }
    }
}
