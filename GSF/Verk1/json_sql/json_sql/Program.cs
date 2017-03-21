using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

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
            char[] pff = "'".ToCharArray();
            int count = 0;

            //Console.WriteLine("1");
            while ((line = reader.ReadLine()) != null)
            {
                //Console.WriteLine("2");
                if (line.Contains('}') == false || line.Contains('{') == false || line.Contains(']') == false)
                {
                   // Console.WriteLine("3");
                    try
                    {
                        input = line.Split(':');
                        for (int i = 0; i < input.Length; i++)//this loop is to clean the line of chars that don't belong #make strings great again
                        {
                            string item = null;//var for holding the input[i] while working with it

                            for (int a = 0; a < input[i].Length; a++)
                            {
                                if (input[i][a] == pff[0] || input[i][a] == '"' || input[i][a] == ',')
                                {

                                }
                                else
                                {
                                    item += input[i][a];
                                }
                            }
                            input[i] = item.Trim();
                        }
                        if (line.Contains('{') == false && line.Contains('}') == false)
                        {
                            cats.Add(input[0]);
                            data.Add(input[1]);
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }//end while
                if (line.Contains('}') == true || line.Contains(']') == true)
                {
                    try
                    {
                        Console.WriteLine(cats[0] + ' ' + count);
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
                                line += pff[0] + data[i] + pff[0];
                            }
                            if (i != data.Count)
                            {
                                line += ',';
                            }
                        }
                        line += ");";
                        writer.WriteLine(line);
                        cats.Clear();
                        data.Clear();
                        count++;
                    }
                    catch (Exception)
                    {

                    }
                }
            }//end while
            Console.WriteLine(count); Console.ReadLine();
            Thread.Sleep(1000);
            writer.Close();
            reader.Close();
        }
    }
}