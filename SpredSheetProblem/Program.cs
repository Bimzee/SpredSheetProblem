using System;

namespace SpredSheetProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number");
            var n = Convert.ToInt32(Console.ReadLine());
            //for (int i = 1; i < 702; i++)
            //{
            //    n = i;

                var n1 = n > 702 ? n % 702 : n;
                if (n1 == 0)
                {
                    n -= 1;
                    n1 = (n > 702 ? n % 702 : n) + 1;
                }

                var t = getSpreadsheetNotation(n1);
                var letters = ColumnIndexToColumnLetter(n1);

                var lineNum = n / 702;
                var num = (lineNum > 0 ? lineNum : 0) + 1;
                Console.WriteLine("-----------");

                Console.WriteLine(num + letters);
                Console.WriteLine("\t" + num + t);
                Console.WriteLine("-----------");
            //}

        }
        public static string getSpreadsheetNotation(long n)
        {
            //Rows 1 - 10^9
            //Columns : A - ZZ (702)

            string result = "";
            if (n <= 26)
            {
                n = n == 0 ? 26 : n;
                int val = ((int)'A') - 1;

                result = ((char)(val + n)).ToString();
                return Convert.ToString(result);
            }
            else
            {
                n = n > 702 ? n / 702 : n;
                var div = n / 26 > 26 ? (n - 1) / 26 : n / 26;
                var mod = n % 26;
                result = getSpreadsheetNotation(div) + getSpreadsheetNotation(mod);

                return result;
            }
        }


        static string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }
    }
}
