/*
 * #nullable disable  
 * #nullable enable
 * adding thistext in top of the page will disable/enable nullable reference type in this file. 
 */

using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Person();
            example.FirstName = "matt";  // setting value is fine
            example.FirstName = null; // attribute is nullable so this is ok
            example.LastName = null; // this will give a warning, because property is non-nullable
            Console.WriteLine($"Last name is: {example.LastName}.");

            /*
             * In case you want to set warnings into errors 
             * write in .csproj file: 
             *   <PropertyGroup>
             *      <LangVersion>8.0</LangVersion>
             *      <NullableContextOptions>enable</NullableContextOptions>
             *   </PropertyGroup>
             * 
             */
        }
    }



    class Person
    {

        // property can contain null - no warnings
        public string? FirstName { get; set; } 
        public List<string>? NullableNames { get; set; }



        // gives a warning of uninitialized non-nullable property - warning
        public string LastName { get; set; }
        public List<string> NonNullableNames { get; set; }



        // Non-nullable property is initialized - no warning
        public string MiddleName { get; set; } = string.Empty; 



        //Non-nullable property is initialized with null - warning
        public string NameInitWithNull { get; set; } = null;

    }



    
}
