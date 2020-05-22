using System;

namespace SpredSheetProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.WriteLine(Letter(703));

            var n = 27;
            //var n1 = n;
            for (int i = 1; i < 70200; i++)
            {
                n = i;

                var n1 = n > 702 ? n % 702 : n;

                var t = getSpreadsheetNotation(n1);
                //var letters = getSpreadsheetNotation(n1);
                var letters = ColumnIndexToColumnLetter(n1);

                var lineNum = n / 702;
                var num = (lineNum > 0 ? lineNum : 0) + 1;
                Console.WriteLine("-----------");

                Console.WriteLine(num + letters);
                Console.WriteLine("\t"+ num+t);
                Console.WriteLine("-----------");
            }

        }
        public static string Letter(int intCol)
        {

            int intFirstLetter = ((intCol) / 702) + 1;
            int intSecondLetter = ((intCol % 702) / 26) + 64;
            int intThirdLetter = (intCol % 26) + 64;

            char FirstLetter = (intFirstLetter > 64) ? (char)intFirstLetter : ' ';
            char SecondLetter = (intSecondLetter > 64) ? (char)intSecondLetter : ' ';
            char ThirdLetter = (char)intThirdLetter;

            return string.Concat(FirstLetter, SecondLetter, ThirdLetter).Trim();
        }
        public static string getSpreadsheetNotation(long n)
        {

            //Rows 1 - 10^9
            //Columns : A - ZZ (702)
            //n = n > 702 ? n % 702 : n;
            //var lineNum = n / 702.0;
            //var num = (lineNum > 1 ? lineNum : 0) + 1;

            string result = "";
            if (n <= 26)
            {
                n = n == 0 ? 26 : n;
                int val = ((int)'A') - 1;

                result = ((char)(val + n)).ToString();
                return Convert.ToString( result);
            }
            else
            {
                n = n > 702 ? n / 702 : n;
                //n = n / 26 > 26 ? (n - 1) : n;
                var div = n / 26 > 26 ? (n - 1) / 26 : n / 26;
                var mod = n % 26;
                result =  getSpreadsheetNotation(div) + getSpreadsheetNotation(mod);

                return result;

                /*
                if(n%26 ==0){
                    return getSpreadsheetNotation((n/26)-1 + (long)getSpreadsheetNotation(26));
                }
                return getSpreadsheetNotation(n/26) + (long)getSpreadsheetNotation(n%26);
                */

                /*int val = ((int)'A') - 1;
                var q = n;
                long x = 0;
                char temp;
                while (q > 0)
                {
                    x = (q % 26) + val;
                    q = (int)(q / 26);
                    temp = (char)x;
                    result = temp + result;
                    //Convert.ToString(x +val);//+result.ToString();

                }
                return (q + 1).ToString() + result;

                /*var loopCnt = n%26;
                var colCnt = n/702

                for(int i=0;i<loopCnt;i++){
                    val++
                    if(n/702<1){
                        var num = n%26;
                        return ""
                    }
                }*/

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
