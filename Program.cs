using System;
using System.Linq;
using System.Collections.Generic;


public class Product
{
  /*
  Properties
  */
  public string Title { get; set; }
  public double Price { get; set; }

  // Constructor method
  public Product(string title, double price)
  {
    this.Title = title;
    this.Price = price;
  }
}

public class Program
{
  public static void Main()
  {
    /*
               We can use curly braces to create instances of objects
               and immediately inject them into the List.
           */
    List<Product> shoppingCart = new List<Product>(){
            new Product("Bike", 109.99),
            new Product("Mittens", 6.49),
            new Product("Lollipop", 0.50),
            new Product("Pocket Watch", 584.00)
        };

    /*
              IEnumerable is an interface, which we'll get to later,
              that we're using here to create a collection of Products
              that we can iterate over.
          */
    IEnumerable<Product> inexpensive = from product in shoppingCart
                                       where product.Price < 100.00
                                       orderby product.Price descending
                                       select product;
    Console.WriteLine("**************************************");

    foreach (Product p in inexpensive)
    {
      Console.WriteLine($"{p.Title} ${p.Price:f2}");
    }

    /*
        You can also use `var` when creating LINQ collections. The
        following variable will still be typed as List<Product> by
        the compiler, but you don't need to type that all out.
    */
    var expensive = from product in shoppingCart
                    where product.Price >= 100.00
                    orderby product.Price descending
                    select product;
    Console.WriteLine("**************************************");


    /*
        Start with a collection that is of type IEnumerable, which
        List is and initialize it with some values. This is the
        class sizes for a selection of NSS cohorts.
    */
    List<int> cohortStudentCount = new List<int>()
        {
            25, 12, 28, 22, 11, 25, 27, 24, 19
        };

    Console.WriteLine($"Largest cohort was {cohortStudentCount.Max()}");
    Console.WriteLine($"Smallest cohort was {cohortStudentCount.Min()}");
    Console.WriteLine($"Total students is {cohortStudentCount.Sum()}");
    /*
        Now we need to determine which cohorts fell within the range
        of acceptable size - between 20 and 26 students. Also, sort
        the new enumerable collection in ascending order.
    */
    IEnumerable<int> idealSizes = from count in cohortStudentCount
                                  where count < 27 && count > 19
                                  orderby count ascending
                                  select count;

    Console.WriteLine($"Average ideal size is {idealSizes.Average()}");

    // The @ symbol lets you create multi-line strings in C#
    Console.WriteLine($@"There were {idealSizes.Count()} ideally sized cohorts
    There have been {cohortStudentCount.Count()} total cohorts");

    // Display each number that was the acceptable size
    foreach (int c in idealSizes)
    {
      Console.WriteLine($" FROM idealSizes IEnumerable {c}");
    }
  }
}