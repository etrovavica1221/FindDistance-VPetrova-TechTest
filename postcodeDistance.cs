using System;
using System.Text.RegularExpressions;
using System.IO;

namespace postcodesDistance
{
  class Program
  {
    static void Main(string[] args)
    {
		// it checks that a user typed a valid postcode

		Regex postCodeValidation = new Regex(@"^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]))))\s?[0-9][A-Za-z]{2})$");

		// prompt a user to type postcodes and save them in variables

		Console.WriteLine("Enter first postcode:");
		string firstPostcode = Console.ReadLine();

		if (postCodeValidation.Match(firstPostcode).Success)
		{
			Console.WriteLine("Enter second postcode:");
			string secondPostcode = Console.ReadLine();		

			if (postCodeValidation.Match(secondPostcode).Success) 
			{
				Console.WriteLine("The distance is:");

				// make a call to api with required postcodes

				mapsApiHelper apiHelper = new mapsApiHelper();
				var model = apiHelper.CallApi(firstPostcode, secondPostcode);
				string distance = model.Rows[0].Elements[0].Distance.Text;
				Console.WriteLine(distance);

				// writing result to historyLog.txt 

				File.AppendAllText
				("historyLog.txt",
				$"{DateTime.Now.ToString("dd MMM yyyy HH:mm:ss")}{System.Environment.NewLine}Distance from {firstPostcode.ToUpper()} to {secondPostcode.ToUpper()}{System.Environment.NewLine}{distance}{System.Environment.NewLine}{System.Environment.NewLine}");
			} 
			else 
			{
				Console.WriteLine("Please enter valid postcode!");
			}

		}
		else
		{
			Console.WriteLine("Please enter valid postcode!");
		}
		
	}
  }
}
