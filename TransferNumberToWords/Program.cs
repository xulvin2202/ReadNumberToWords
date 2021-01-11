using System;

namespace TransferNumberToWords
{
    public class Program
    {
        public static string[] dv = { "", "muoi", "tram", "nghin", "trieu", "ti" };
        public static string[] cs = { "khong", "mot", "hai", "ba", "bon", "nam", "sau", "bay", "tam", "chin", "muoi" };
        public static string[] special_unit = { "lam", "le", "muoi", "mot" };
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your number: ");
            var number = Console.ReadLine();
            string read = string.Empty;

            int i, j, k, n, lenght, found, ddv, rd;
            lenght = number.Length;
            number += "ss";
            read = "";
            found = 0;
            ddv = 0;
            rd = 0;
            i = 0;
            number = number.Replace(" ","");

            if (number.Length < 1 )
            {
                read = $"Khong co gia tri duoc nhap vao ";
            }
            else
            {
                while (i < lenght)
                {
                    ///so chu so o hang dang duyet
                    n = (lenght - i + 2) % 3 + 1;
                    /// check number 0
                    found = 0; for (j = 0; j < n; j++)
                    {
                        if (number[i + j] != '0')
                        {
                            found = 1;
                            break;
                        }
                    }

                    //Duyet n chu so
                    if (found == 1)
                    {
                        rd = 1;
                        for (j = 0; j < n; j++)
                        {
                            ddv = 1;
                            switch (number[i + j])
                            {
                                case '0':
                                    if (n - j == 3) read += cs[0] + " ";
                                    if (n - j == 2)
                                    {
                                        if (number[i + j + 1] != '0') read += special_unit[1] + " ";
                                        ddv = 0;
                                    }
                                    break;
                                case '1':
                                    if (n - j == 3) read += cs[1] + " ";
                                    if (n - j == 2)
                                    {
                                        read += cs[10] + " ";
                                        ddv = 0;
                                    }
                                    if (n - j == 1)
                                    {
                                        if (i + j == 0) k = 0;
                                        else k = i + j - 1;

                                        if (number[k] != '1' && number[k] != '0')
                                            read += special_unit[3] + " ";
                                        else
                                            read += cs[1] + " ";
                                    }
                                    break;
                                case '5':
                                    if (i + j == lenght - 1)
                                    {
                                        read += n - j == 1 ? cs[5] + " " : "lam ";
                                    }
                                    else
                                        read += cs[5] + " ";
                                    break;
                                default:
                                    read += cs[(int)number[i + j] - 48] + " ";
                                    break;
                            }

                            //read don vi nho
                            if (ddv == 1)
                            {
                                read += dv[n - j - 1] + " ";
                            }
                        }
                    }


                    //read don vi lon
                    if (lenght - i - n > 0)
                    {
                        if ((lenght - i - n) % 9 == 0)
                        {
                            if (rd == 1)
                                for (k = 0; k < (lenght - i - n) / 9; k++)
                                    read += dv[5] + " ";
                            rd = 0;
                        }
                        else
                            if (found != 0) read += dv[((lenght - i - n + 1) % 9) / 3 + 2] + " ";
                    }

                    i += n;
                }

                if (lenght == 1)
                    if (number[0] == '0' || number[0] == '5') read = cs[(int)number[0] - 48];
                if (read.Substring(read.Length - 1, 1) == ",") read = read.Substring(0, read.Length - 1);
                read = ReplaceWord(read);
            }
            Console.WriteLine("Your word is: " + read);
            Console.ReadKey();
        }
        public static string ReplaceWord(string word)
        {
            word = word.Trim();
            word = $"{word.Substring(0, 1).ToUpper() + word.Substring(1)} dong";
            word = word.Replace("  ", " ");
            word = word.Replace("ti dong", "ti dong chan");
            word = word.Replace("trieu dong", "trieu dong chan");
            word = word.Replace("tram nghin dong", "tram nghin dong chan");
            word = word.Replace("muoi nghin dong", "muoi nghin dong chan");
            word = word.Replace("mười nghin dong", "mười nghin dong chan");
            return word;
        }
    }
}
