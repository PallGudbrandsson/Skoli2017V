using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace json_sql
{
    class Program {
        //lina = reader.readLine() != null
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("data.txt");
            StreamWriter writer = new StreamWriter("data.sql");

            List<string> cats = new List<string>();
            List<string> data = new List<string>();

            string line = null;
            string[] input;

            //Console.WriteLine("1");
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                //Console.WriteLine("2");
                if (line.Contains('}') == false && line.Contains('{') == false && line.Contains(']') == false)
                {
                   // Console.WriteLine("3");
                    try
                    {
                        input = line.Split(':');
                        Console.WriteLine("4");
                        for (int i = 0; i < input.Length; i++)
                        {
                            input[i] = input[i].Trim();
                            input[i] = input[i].Trim('"');
                        }
                        if (line.Contains('{') == false && line.Contains('}') == false)
                        {
                            cats.Add(input[0]);
                            data.Add(input[1]);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }//end while
                if (line.Contains('}') == true && line.Contains(']') == true)
                {
                    try
                    {
                        Console.WriteLine(cats[0]);
                        Console.WriteLine("5");
                        line = "INSERT INTO data3(" + cats[0];
                        for (int i = 1; i < cats.Count; i++)
                        {
                            line += ',' + cats[i];
                        }
                        line += ")VALUES(";

                        for (int i = 0; i < data.Count; i++)
                        {
                            try
                            {
                                double a = Convert.ToDouble(data[i]);
                                line += data[i];
                            }
                            catch (Exception)
                            {
                                line += "'" + data[i] + "'";
                            }
                            if (i != data.Count)
                            {
                                line += ',';
                            }
                        }
                        line += ");";
                        writer.WriteLine(line);
                        Console.WriteLine(line);
                        cats.Clear();
                        data.Clear();
                    }
                    catch (Exception)
                    {

                    }
                }
            }//end while
            writer.Close();
            reader.Close();
        }
    }
}