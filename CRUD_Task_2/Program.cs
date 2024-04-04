using System;
using MySql.Data.MySqlClient;

public class CRUD_Task_2
{
    // Modify the connection string here
    public static string connectionString = "server=___;port=___;user=___;password=___;database=___;";

    public static object[,] groceryItemsData = new object[,]
    {
        { "Bananas", "Fruits", 0.99f, 150 },
        { "Apples", "Fruits", 1.49f, 100 },
        { "Carrots", "Vegetables", 0.79f, 200 },
        { "Potatoes", "Vegetables", 1.29f, 180 },
        { "Milk", "Dairy", 2.49f, 80 },
        { "Eggs", "Dairy", 1.99f, 120 },
        { "Bread", "Bakery", 1.99f, 90 },
        { "Chicken", "Meat", 4.99f, 50 },
        { "Rice", "Grains", 3.99f, 120 },
        { "Pasta", "Grains", 1.49f, 150 }
    };

    static void Main(string[] args)
    {
        // Write code below this line
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string cmdText = "CREATE TABLE store (id INT, name VARCHAR(100), category VARCHAR(100), price FLOAT, stock_quantity INT);";
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            cmd.ExecuteNonQuery();

            // Code for inserting data into the table ...
        }
        // Write code above this line
    }
}
