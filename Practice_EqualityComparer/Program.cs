using System;
using System.Numerics;

class Program
{
    public static void Main()
    {
        Customer customer1 = new Customer("Narmin", "Aliyeva");
        Customer customer2 = new Customer("Narmin", "Aliyeva");

        Console.WriteLine(customer1 == customer2); // False
        Console.WriteLine(customer1.Equals(customer2)); // False

        #region EqualityComparer istifade olunmadiqda :

        ////Dictionary 
        //var dictionary = new Dictionary<Customer, string>();
        //dictionary[customer1] = "Narmin";
        //Console.WriteLine(dictionary.ContainsKey(customer2)); // False

        ////Hashset
        //var customerHashSet = new HashSet<Customer>();
        //customerHashSet.Add(customer1);
        //customerHashSet.Add(customer2);

        //Console.WriteLine(customerHashSet.Count()); // 2 

        #endregion

        #region EqualityCompare istifade olunduqda : 


        var dictionary = new Dictionary<Customer, string>(new CustomerComparer());
        dictionary[customer1] = "Narmin";
        Console.WriteLine(dictionary.ContainsKey(customer2)); // True


        var customerHashSet = new HashSet<Customer>(new CustomerComparer());
        customerHashSet.Add(customer1);
        customerHashSet.Add(customer2);

        Console.WriteLine(customerHashSet.Count()); // 2 

        #endregion

    }
}

public class Customer
{
    public string FirstName;
    public string LastName;
    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
public class CustomerComparer : EqualityComparer<Customer>
{
    public override bool Equals(Customer x, Customer y)
        => x.LastName == y.LastName && x.FirstName == y.FirstName;
    public override int GetHashCode(Customer obj)
        => (obj.LastName + obj.FirstName).GetHashCode();
}

