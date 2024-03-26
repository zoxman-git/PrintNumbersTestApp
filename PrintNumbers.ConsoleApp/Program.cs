using ClassLibraryPrintNumbers.BusinessLogic;

var upperBound = 15;

var numbersToPrint = PrintNumbersService.GetNumbersToPrint(upperBound, 3, 5, "Zach", "Oxman");

foreach (var number in numbersToPrint)
{
    Console.WriteLine(number);
}
