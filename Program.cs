using System;
using System.Globalization; 

class Program
{
    static void Main(string[] args)
    {
    
        string productName = GetStringFromUser("Ange produktnamn: ");
        double productPrice = GetPositiveDoubleFromUser("Ange pris per styck: ");
        int productQuantity = GetPositiveIntFromUser("Ange antal: ");
        
        Console.WriteLine("\n--- Beräknar totalpris ---");

        
        double totalDefaultTax = CalculateTotal(productName, productPrice, productQuantity);
        
    
        Console.WriteLine($"Du köpte {productQuantity} st {productName}, totalpris (inkl. 25% moms): {totalDefaultTax.ToString("F2", CultureInfo.InvariantCulture)} kr");

   
        double totalCustomTax = CalculateTotal(productName, productPrice, productQuantity, 0.12);
        Console.WriteLine($"Du köpte {productQuantity} st {productName}, totalpris (inkl. 12% moms): {totalCustomTax.ToString("F2", CultureInfo.InvariantCulture)} kr");
    }

    
    static double CalculateTotal(string product, double price, int quantity, double tax = 0.25)
    {
        double total = (price * quantity) * (1 + tax);
        return total;
    }

    

    static string GetStringFromUser(string prompt)
    {
        string input;
        while (true)
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("Fel: Inmatningen får inte vara tom.");
        }
    }

    static double GetPositiveDoubleFromUser(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            
            if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out number) && number > 0)
            {
                return number;
            }
            Console.WriteLine("Fel: Ange ett positivt tal (använd punkt som decimaltecken).");
        }
    }

    static int GetPositiveIntFromUser(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number) && number > 0)
            {
                return number;
            }
            Console.WriteLine("Fel: Ange ett positivt heltal.");
        }
    }
}