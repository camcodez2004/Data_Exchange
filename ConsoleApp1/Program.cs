using System;
using System.IO;
// takes input as path to file wanted to read, and prints it to the console. 
class Program
{
    static void Main()
    {
        try
        {
            // ask user for file path
            Console.WriteLine("Enter path to file to read:");
            string filePath = Console.ReadLine();
            
            // check if the file exists
            if (File.Exists(filePath))
            {
                // Read the content of the file
                string fileContent = File.ReadAllText(filePath);
                
                // print content to the console
                Console.WriteLine("The content of the file is:");
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        }
        catch (Exception e)
        {
            // If an exception occurred, print the details.
            Console.WriteLine("An error occurred while reading the file:");
            Console.WriteLine(e.Message);
        }
    }
}