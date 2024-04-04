# Description
In the last task we created a table which stores products of a grocery store. They contact you again to fix the previous table making sure that the `id` of each item in the products table is unique. They also want you to insert the following data into the table:

```
        object[,] groceryItemsData = new object[,]
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
```

Your task is to:
1. Create a new table called `store` and this time make the `id` column a primary key and set it to automatically increment.
2. Insert the data given in the `groceryItemsData` array into the new table.

### Hints
> Hint 1: We use the `PRIMARY KEY` keyword for making a column a primary key;

> Hint 2: The `AUTO_INCREMENT` is used for making a column automatically take up incremented values;

> Hint 3: Use the `INSERT INTO` statement for inserting data into the table;
