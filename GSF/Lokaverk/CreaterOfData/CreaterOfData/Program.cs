using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CreaterOfData
{
    class Generation {
        Random rand = new Random();

        public string ID(int length, List<string> taken)
        { // ID open
            string placeholder = null;
            char[] items = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                     'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                     '1','2','3','4','5','6','7','8','9','0','-','_','<','>','!','@','$','#','&','(',')','[',']','{','}','+','=','?'};

            while (true)
            { // while open
                for (int i = 0; i < length; i++)
                {
                    placeholder += items[rand.Next(0, 80)];
                }
                if (taken.Contains(placeholder)) // if the selected string is already used will almost never happen
                {
                    placeholder = null;
                }
                else
                {
                    taken.Add(placeholder);
                    return placeholder;
                }
            } // while close
        } // ID close

        public string kaup(string afgID, int varaID)
        { // kaup open
            return string.Format("'AfgID':'{0},\n'VaraID':'{1},\n'magn':{2},\n'afslattur':0;",afgID,varaID,(rand.Next(1,6)));
        } // kaup close

        public string afgreidsla(string ID, int kassi, int verslun, int staffID)
        { // afgreidsla open





            return null;
        } // afgreidsla close

    } // Generation close
    class Program
    {
        static void Main(string[] args)
        {
            // there will be 200 products ID 0-199
            Generation gen = new Generation();
            StreamWriter rethinkDB = new StreamWriter("insert.txt");
            StreamWriter SQL = new StreamWriter("insert.sql");
            Random rand = new Random();
            List<string> taken = new List<string>();
            int vara = 0;
            // Generate an ID for the purchase
            // Add on the neccesari syntax to insert into the rethink db for products
            // Add all the purchased prcoducts. Expect a text file, format to be determined
            while (true) // there are still products
            {
                rethinkDB.WriteLine(gen.kaup(gen.ID(8, taken),vara));
            }
            // Close the insert for the products
            // Open the insert for inserting the purchase information.
            // Add the info for inserting the purchase
            // Close the insert for the purchase
            // Start the next purchase
        }
    }
}
