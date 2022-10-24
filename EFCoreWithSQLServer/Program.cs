// See https://aka.ms/new-console-template for more information


//Function that queries all categories

using EFCoreWithSQLServer;
using EFCoreWithSQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;


static void GetCategories()
{
    using(MyDatabaseContext db = new())
    {
        Console.WriteLine("Categories and number of products they have :");
        IQueryable<Category>? categories = db.Categories?.Include(category => category.Products);
        if(categories == null)
        {
            Console.WriteLine("The table is empty");
            return;
        }

        foreach(Category category in categories)
        {
            Console.WriteLine($"{category.CategoryName} has [ {category.Products?.Count} ] producs");
        }
    }
}
static void GetProducts()
{
    using (MyDatabaseContext db = new())
    {
        IQueryable<Product>? products = db.Products;
        if(products == null)
        {
            Console.WriteLine("No product found");
            return;
        }
        foreach(Product product in products)
        {
            Console.WriteLine("Available Products are :");
            Console.WriteLine($"{product.ProductId}. {product.ProductName}");
        }
    }
}
static bool InsertProduct(int categoryId, string productName)
{
    using(MyDatabaseContext db = new())
    {
        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            //Cost = price
        };
        db.Products.Add(p);

        // save tracked change to database
        int affected = db.SaveChanges();
        return(affected == 1);
    }
}

