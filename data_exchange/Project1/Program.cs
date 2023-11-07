using System;
using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;  

class Program
{
    static void Main()
    {
        // Set up the connection string. Replace with your database details.
        string connectionString = "Server=localhost; Database=overwatchdb; Uid=root; Pwd=CamZoe2004$$;";
        // SQL query to select all data from the 'player_stats' table.
        string query = "SELECT * FROM player_stats";
        
        // Establish a new MySQL connection.
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            // Create a new MySQL command object with the query and connection.
            MySqlCommand command = new MySqlCommand(query, connection);
            // Open the connection to the database.
            connection.Open();

            // Execute the command and store the results in a MySqlDataReader.
            MySqlDataReader reader = command.ExecuteReader();

            // Define the path to the output CSV file.
            string filePath = "/Users/cameronhess/Documents/Personal Projects/Onboard/Data_Project/data_exchange/Overwatch_test_data.csv";
            
            // Create a StreamWriter to write to the file, overwrite if it already exists.
            using (StreamWriter file = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Write the header row with column names.
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    file.Write(reader.GetName(i) + (i < reader.FieldCount - 1 ? "," : ""));
                }
                file.WriteLine();

                // Write the data rows.
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        // Get the value from the reader and convert it to a string.
                        string value = reader[i].ToString();
                        // If the value contains a comma, enclose it in quotes.
                        if (value.Contains(","))
                            value = "\"" + value + "\"";

                        // Write the value to the file.
                        file.Write(value + (i < reader.FieldCount - 1 ? "," : ""));
                    }
                    // Write a new line at the end of each row.
                    file.WriteLine();
                }
            }
        }

        // Notify the user that the data export is complete.
        Console.WriteLine("Data exported successfully!");
    }
}
