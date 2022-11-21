using Microsoft.VisualBasic;
using System;

public class Base
{
    static void Main()
    {
        Task1.ShowMassiveElement();

        Person person1 = new Person() { Name = "Vasya" };
        Person person2 = new Person() { Name = "Petya"};
        Person person3 = new Person() { Name = "Oleg" };
    }
}

public class Task1
{ 
    public static void ShowMassiveElement()
    {
        string? checkedValue = "abc";
        try
        {
            int[] massive = { 8, 7, 1, 4, 2 };

            Console.WriteLine("Input index of element in massive:");
            string? inputedValue = Console.ReadLine();
            checkedValue = inputedValue.Equals(string.Empty) ? null : inputedValue;
            int inputtedNumber = Int32.Parse(checkedValue);             // InvalidCastException and NullReferenceException is possible

            int massiveElement = massive[inputtedNumber];               // IndexOutOfRangeException is possible 
            Console.WriteLine($"Massive element that has index {inputedValue} has value {massiveElement}");
        }
        catch (InvalidCastException)                                    // is thrown for invalid casting 
        {
            Console.WriteLine("InvalidCastException occured");        
        }
        catch (IndexOutOfRangeException)                                // is thrown when invalid index is used to access a member of array
        {
            Console.WriteLine("IndexOutOfRangeException occured");
        }
        catch (NullReferenceException) when (checkedValue == null)      // is thrown when 'checkedValue' is null
        {
            Console.WriteLine("NullReferenceException occured");
        }
        catch                                                           // for all the other possible exceptions
        {
            Console.WriteLine("Some exception occured");
        }
        finally
        {
            Console.WriteLine("Finally block");
        }
    }
}

public class Person
{
    private string name;

    public string Name
    {
        set
        {
            if ((value == "Vasya") || (value == "Petya"))
                throw new ForbiddenNameException(value);         // throw ForbiddenNameException if name 'Vasya' or 'Petya' was entered
            else
            {
                name = value;
                Console.WriteLine($"Name is {value}");                        // output name if not 'Vasya' or 'Petya' was entered
            }
        }
    }
}

public class ForbiddenNameException : Exception
{
    private string name;

    public ForbiddenNameException(string name) : base($"Vhod zapreschen vsem po imeni {name}")  // output 'Vhod zapreschen vsem po imeni {}' if name 'Vasya' or 'Petya' was entered
    {
        this.name = name;                 // saving exeption parameter 'name'
    }

}



