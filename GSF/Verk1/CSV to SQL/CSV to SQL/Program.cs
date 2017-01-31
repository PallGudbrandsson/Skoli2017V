using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV_to_SQL
{
    class Program
    {
        static string eat(string tName, string[] col, string[] data)
        {
            //the , has to be added before the data so 1 item has to be added before
            //going into the forloop
            string final = string.Format("INSERT INTO {0} (", tName) + col[0];//that item is added here, and another below

            for (int i = 1; i < col.Length; i++)
            {
                final += ", " + col[i];
            }
            final += ") VALUES ('" + data[0]+"'";//the item is again added here for the same reason
            double test = 0;
            for (int i = 1; i < data.Length; i++)
            {
                try
                {
                    test = Convert.ToDouble(data[i]);
                    final += ", " + data[i];
                }
                catch (Exception)
                {
                    final += ", '" + data[i] + "'";
                }
                
            }
            final += ");";
            return final;
        }
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("data.txt");
            StreamWriter writer = new StreamWriter("data.sql");
            string line = null;
            string tName = null;

            string[] colums;
            string[] data;

            line = reader.ReadLine();
            colums = line.Split(',');

            Console.WriteLine("enter the table name");
            tName = Console.ReadLine();

            

            while (true)
            {
                try
                {
                    line = reader.ReadLine();
                    data = line.Split(',');
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = data[i].Trim();
                    }
                    writer.WriteLine(eat(tName, colums, data));
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
