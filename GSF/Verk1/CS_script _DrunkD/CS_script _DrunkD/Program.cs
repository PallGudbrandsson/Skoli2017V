using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CS_script__DrunkD
{
    class Program
    {
        static void Main(string[] args)
        {
            //hvar eru konur liklegastar til ad deyja i  bilslisi
            //en menn
            //en liklegast
            //hvad er hattulegasta rikid
            StreamReader reader = new StreamReader("data.txt");
            StreamWriter writer = new StreamWriter("data.sql");
            string lineIdentifier = null;
            string query = null, line, state = null, lastID = null, info = null;
            string[] input;

            line = reader.ReadLine();
            do
            {
                
                input = line.Split('<', '>');
                try
                {
                    lineIdentifier = input[1];
                }
                catch (Exception ex)
                {
                    lineIdentifier = ex.ToString();
                }
                switch (lineIdentifier)
                    {
                        case "state_not_geocoded":
                            {
                                state = input[2];
                            }
                            break;
                        case "all_ages":
                        case "all_ages_2014":
                        case "ages_0_20":
                        case "ages_0_20_2014":
                        case "ages_21_34":
                        case "ages_21_34_2014":
                        case "ages_35":
                        case "ages_35_2014":
                        case "male":
                        case "male_2014":
                        case "female":
                        case "female_2014":
                            {
                                query = "INSERT INTO data(state, cat, num) VALUES ('" + state + "', '" + lineIdentifier + "', " + input[2] + ");";
                                Console.WriteLine(query);
                                writer.Write(query);
                                query = null;
                            }
                            break;
                        default:
                            break;
                    }
                    lastID = lineIdentifier;
                line = reader.ReadLine();
            } while (line != "</response>");
            Console.ReadLine();
        }
    }
}
