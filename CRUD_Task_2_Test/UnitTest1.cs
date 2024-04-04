using System.Data;
using MySql.Data.MySqlClient;

[TestClass]
public class CRUD_Task_2_Tests
{
    private readonly string connectionString = CRUD_Task_2.connectionString;

    [TestMethod]
    public void TestTableCreation()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string cmdText = "SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'store'";
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());

            Assert.IsTrue(table.Rows.Count == 5, "Number of columns does not match expected.");
            AssertColumnExistsWithDataType(table, "id", "INT");
            AssertColumnExistsWithDataType(table, "name", "VARCHAR");
            AssertColumnExistsWithDataType(table, "category", "VARCHAR");
            AssertColumnExistsWithDataType(table, "price", "FLOAT");
            AssertColumnExistsWithDataType(table, "stock_quantity", "INT");
        }
    }

    [TestMethod]
    public void TestDataInsertion()
    {
        object[,] groceryItemsData = CRUD_Task_2.groceryItemsData;
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string cmdText = "SELECT name, category, price, stock_quantity FROM store";
            MySqlCommand cmd = new MySqlCommand(cmdText, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                int rowCount = 0;
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    string category = reader.GetString(1);
                    float price = reader.GetFloat(2);
                    int stockQuantity = reader.GetInt32(3);

                    bool foundMatch = false;
                    for (int i = 0; i < groceryItemsData.GetLength(0); i++)
                    {
                        if ((string)groceryItemsData[i, 0] == name &&
                            (string)groceryItemsData[i, 1] == category &&
                            (float)groceryItemsData[i, 2] == price &&
                            (int)groceryItemsData[i, 3] == stockQuantity)
                        {
                            foundMatch = true;
                            break;
                        }
                    }
                    Assert.IsTrue(foundMatch, $"Data mismatch for item '{name}'.");
                    rowCount++;
                }

                Assert.AreEqual(10, rowCount, "Number of rows in 'store' table does not match expected.");
            }
        }
    }

    private void AssertColumnExistsWithDataType(DataTable table, string columnName, string expectedDataType)
    {
        DataRow[] rows = table.Select($"COLUMN_NAME = '{columnName}' AND DATA_TYPE = '{expectedDataType}'");
        Assert.IsTrue(rows.Length == 1, $"Column '{columnName}' with data type '{expectedDataType}' not found.");
    }
}
