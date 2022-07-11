// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
using System.Text.RegularExpressions;

namespace BMICalc // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private const float INCHESTOCENTIMETERS = 2.54f;
        private const float POUNDSTOKILOGRAMS = 0.454f;

        static void Main(string[] args)
        {
            try
            {
                // Parse command line args
                if (args.Length != 2)
                {
                    
                }
                string allArgs = args[0].ToLower() + args[1].ToLower();
                Regex regx = new(@"([\d]+)([\D]+)([\d]+)([\D]+)", RegexOptions.IgnoreCase);
                MatchCollection matches = regx.Matches(allArgs);

                if (matches.Count() != 1)
                {
                    Usage();
                    throw new FormatException("Incorrect input format detected!");
                }
                var matchGroup = matches[0].Groups;

                // Calculate
                Person person = regexToPerson(matchGroup);

                // Output
                Console.WriteLine("*");
                Console.WriteLine("*");
                Console.WriteLine(person.stringify());
                Console.WriteLine("*");
                Console.WriteLine("*");


            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /**
         * Preliminary step to handle Imperial and Metric Weights and Heights independently of each other.
         * This is achieved by converting them to metric internally up front, so that there is one simple numerical representation of an attribute in our program.
         * 
         * Note: matches[0] unused, will always be the original match.
         * 
         * Comment for Caleb: This code is pretty disgusting with the amount of repetition, ToString invocations.
         * If I were to do this again, I might look to using regex to extract the pairs (attributeUnitofMeasure, Value) and place them into something easier to handle like a dict["kg"]
         * It's jank but works with my regex method of parsing input, and I'm prioritising spending minimal extra time on this.
         * 
         */
        
        static Person regexToPerson(GroupCollection matches)
        {
            float mass = 0;
            float height = 0;

            if (matches[2].ToString().Equals("kg")  || matches[2].ToString().Equals("lbs"))
            {
                if (matches[2].Equals("lbs"))
                {
                    mass = float.Parse(matches[1].ToString()) * POUNDSTOKILOGRAMS;
                }
                mass = float.Parse(matches[1].ToString());
            }
            else if (matches[4].ToString().Equals("kg") || matches[4].ToString().Equals("lbs"))
            {
                if (matches[4].ToString().Equals("lbs"))
                {
                    mass = float.Parse(matches[3].ToString()) * POUNDSTOKILOGRAMS;
                }
                mass = float.Parse(matches[3].ToString());
            }

            if (matches[2].ToString().Equals("cm") || matches[2].ToString().Equals("in"))
            {
                if (matches[2].ToString().Equals("in"))
                {
                    height = float.Parse(matches[1].ToString()) * INCHESTOCENTIMETERS;
                }
                height = float.Parse(matches[1].ToString());
            }
            else if (matches[4].ToString().Equals("cm") || matches[4].ToString().Equals("in"))
            {
                if (matches[4].ToString().Equals("in"))
                {
                    height = float.Parse(matches[3].ToString()) * INCHESTOCENTIMETERS;
                }
                height = float.Parse(matches[3].ToString());
            }

            return new Person(mass, height);
        }

        private static void Usage()
        {
            Console.WriteLine("Usage: <height> <weight>");
            Console.WriteLine("Example: 180cm 75kg");
            Console.WriteLine("Permitted Units: Metric: kg and cm, Imperial: lbs and in");
        }
    }
}