using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class log_pas
    {
        public static acc LogIn()
        {
            acc account = new acc();
            string login = Console.ReadLine();
            string password = ReadPassword(9, 2);
            foreach (var element in JsonDS.Deserialize<List<acc>>())
            {
                if (element.Password == password && element.Login == login)
                {
                    account = element;
                    break;
                }
            }
            return account;

        }

        public static string ReadPassword(int left, int top)
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            Console.SetCursorPosition(8, 2);
            while (info.Key != ConsoleKey.Enter)
            {
                
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}
