using System;


/// <summary>
/// Small demostration on how to work with indexers
/// </summary>
namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            // example of indexer with a simple class
            EmployeeRegister<Employee> newHires = new EmployeeRegister<Employee>();
            newHires.Add(new Employee { name = "Susan Sarah" });
            newHires.Add(new Employee { name = "Justin James" });
            for (int i = 0; i < newHires.items.Length; i++) 
            {
                Console.WriteLine(newHires[i].ToString());  // possible to access employees with the usagae if indexes 
            }
            Console.WriteLine(newHires["Susan"]);  // possible to access with reference values 

            //same example will work with any type, in this case with int
            EmployeeRegister<int> numbers = new EmployeeRegister<int>();
            numbers.Add(3);
            numbers.Add(10);

            for (int i = 0; i < numbers.items.Length; i++)
            {
                Console.WriteLine(numbers[i].ToString());  // possible to access employees with the usagae if indexes 
            }
            Console.WriteLine(numbers["3"]);  // possible to access with reference values 
        }
    }


    public class EmployeeRegister<T>
    {
        public T[] items = new T[1];
        public int nextValue = 0;
        public T this[int i] => items[i];  // indexer by int value
        public T this[string i] => FindByStringValue(i);  // indexer with a reference type

        private T FindByStringValue(string i)
        {
            foreach (var item in items)
            {
                if (item.ToString().Contains(i)) return item;
            }
            return default(T);
        }

        public void Add(T value)
        {
            try
            {
                items[nextValue] = value;
                nextValue++; 
            }
            catch (IndexOutOfRangeException e)  // e is unused but it is okay in this demo
            {
                var tempArray = new T[items.Length * 2];
                Array.Copy(items, 0, tempArray, 0, items.Length);
                items = tempArray;
                Add(value); 
            }
        }
    }

    public class Employee
    {
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
