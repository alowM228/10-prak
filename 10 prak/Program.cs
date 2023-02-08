using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal enum AccountAttribute
    {
        ID,
        Loign,
        Password,
        Post
    }
    internal enum HotKey
    {
        Выбрать = ConsoleKey.Enter,
        Стереть = ConsoleKey.Backspace,
        Вверх = ConsoleKey.UpArrow,
        Вниз = ConsoleKey.DownArrow,
        Назад = ConsoleKey.Escape,
        Создать = ConsoleKey.F1,
        Удалить = ConsoleKey.Delete,
        Поиск = ConsoleKey.F2
    }
    internal enum Roly
    {
        Администратор,
        Кассир,
        Склад,
        Менеджер,
        Бухгалтер
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonDS.SearchToJsonFiles();
            while (true)
            {
                Console.CursorVisible = true;
                Console.WriteLine("Приветствуем вас в нашем магазине - 'Скажи нет комиссии!' ");
                Console.WriteLine("Логин: ");
                Console.WriteLine("Пароль: ");
                Console.SetCursorPosition(8, 1);
                acc account = log_pas.LogIn();
                if (account.Password != null)
                {
                    admin ad = new admin(JsonDS.Deserialize<List<acc>>() , account);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ошибка: такого аккаунта не существует");
                    Console.WriteLine("Нажите Escape, чтобы выйти, или любую другую клавишу, чтобы поворить попытку.");
                    if(Console.ReadKey().Key == (ConsoleKey)HotKey.Назад)
                    {
                        break;
                    }
                }
                Console.Clear();
            }
        }
    }
}