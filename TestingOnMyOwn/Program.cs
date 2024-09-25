using Microsoft.Data.SqlClient;

namespace TestingOnMyOwn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Server=MST\\SQLEXPRESS;Database=DogTraining;Trusted_Connection=True;TrustServerCertificate=True;";

            string query = "SELECT DISTINCT club FROM User_Info";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Club: {reader["Club"]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
