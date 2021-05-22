using System;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;
using System.Text.RegularExpressions;

namespace postcodesDistance
{
  class Program
  {
    static void Main(string[] args)
    {

	Regex postCodeValidation = new Regex(@"^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]))))\s?[0-9][A-Za-z]{2})$");

	Console.WriteLine("Enter first postcode:");
	string firstPostcode = Console.ReadLine();

	if (postCodeValidation.Match(firstPostcode).Success)
	    {
			Console.WriteLine("Enter second postcode:");
			string secondPostcode = Console.ReadLine();		

			if (postCodeValidation.Match(secondPostcode).Success) 
			{
				Console.WriteLine("Results:");
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
