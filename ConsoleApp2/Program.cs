// takes contents of file and writes into another file. 
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // gets file you want to copy from
            Console.WriteLine("Enter path to file to copy from:");
            string sourceFilePath = Console.ReadLine();

            // gets path to new destination
            Console.WriteLine("Enter path to destination to copy to:");
            string destinationFilePath = Console.ReadLine();

            // check if the source file exists
            if (File.Exists(sourceFilePath))
            {
                // read content of the source file
                string fileContent = File.ReadAllText(sourceFilePath);
                
                // write the content to the destination file
                File.WriteAllText(destinationFilePath, fileContent);
                
                Console.WriteLine($"The content has been successfully copied to {destinationFilePath}");
            }
            else
            {
                Console.WriteLine("The source file does not exist.");
            }
        }
        catch (Exception e)
        {
            // If an exception occurred, print the details.
            Console.WriteLine("An error occurred:");
            Console.WriteLine(e.Message);
        }
    }
}