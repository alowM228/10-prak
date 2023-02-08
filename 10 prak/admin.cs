using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class admin : acc
    {
        private bool DopMenuEnable;
        private int StartPositionCursor;
        private int EndPositionCursor;
        private int PositionCursor;
        private bool SearchIsEnable;
        public admin(List<acc> arr, acc account)
        {
            DrewAllInterface(arr, account);
        }

        private void DrewAllInterface(List<acc> list, acc account)
        {
            while (true)
            {
                Console.Clear();
                if (DopMenuEnable)
                {
                    list = Update(list, list[PositionCursor-1]);
                    DopMenuEnable = false;
                }
                if(!DopMenuEnable)
                {
                    Console.Clear();
                    BodyInterface(list, account);
                    StartPositionCursor = 1;
                    EndPositionCursor = list.Count;
                }
                ConsoleKeyInfo key = ArrowMenu(StartPositionCursor, EndPositionCursor);
                if (key.Key == (ConsoleKey)HotKey.Назад)
                {
                    if (!DopMenuEnable)
                    {
                        break;
                    }
                } else if (key.Key == (ConsoleKey)HotKey.Удалить)
                {
                    if (list.Count != 1 && !SearchIsEnable)
                    {
                        list = Delete(list);
                    }
                } else if (key.Key == (ConsoleKey)HotKey.Выбрать)
                {
                    if (!DopMenuEnable && !SearchIsEnable)
                    {
                        DopMenuEnable = true;
                    }
                } else if (key.Key == (ConsoleKey)HotKey.Создать)
                {
                    list = Create(list);
                }else if(key.Key == (ConsoleKey)HotKey.Поиск)
                {
                    if (!SearchIsEnable)
                    {
                        SearchIsEnable = true;
                        SearchAccount(list, account);
                        SearchIsEnable = false;
                    }
                }
            }
        }

        private void HeadInterface(acc account)
        {
            Console.WriteLine("Добро пожаловать: " + account.Login + " Ваша роль: " + DrewPostWorker(account.Post));
        }

        private void BodyInterface(List<acc> list, acc acount)
        {
            HeadInterface(acount);
            foreach (var element in list)
            {
                Console.WriteLine("  ID " + element.ID + " Логин: " + element.Login + " Пароль: " + element.Password + " Роль " + DrewPostWorker(element.Post));
            }
            Console.WriteLine("SearchIsEnable: " + SearchIsEnable);
        }

        private string DrewPostWorker(string post)
        {
            if (Convert.ToInt32(post) == (int)Roly.Администратор)
            {
                return Convert.ToString(Roly.Администратор);
            }
            else if (Convert.ToInt32(post) == (int)Roly.Кассир)
            {
                return Convert.ToString(Roly.Кассир);
            }
            else if (Convert.ToInt32(post) == (int)Roly.Склад)
            {
                return Convert.ToString(Roly.Склад);
            }
            else if (Convert.ToInt32(post) == (int)Roly.Менеджер)
            {
                return Convert.ToString(Roly.Менеджер);
            }
            else if (Convert.ToInt32(post) == (int)Roly.Бухгалтер)
            {
                return Convert.ToString(Roly.Бухгалтер);
            }
            else
            {
                return Convert.ToString("null");
            }
        }

        private void SearchAccount(List<acc> list,acc account)
        {
            List<acc> newList = new List<acc>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("  ID: ");
                Console.WriteLine("  Login: ");
                Console.WriteLine("  Password: ");
                Console.WriteLine("  Post: ");
                ConsoleKeyInfo key = ArrowMenu(0,3);
                if(key.Key == (ConsoleKey)HotKey.Назад)
                {
                    break;
                }
                else if(key.Key == (ConsoleKey)HotKey.Выбрать)
                {
                    Console.CursorVisible = true;
                    if (Console.CursorTop - 1 == (int)AccountAttribute.ID)
                    {
                        var ID = ReadInt(6, 0, 7);
                        foreach (var element in list)
                        {
                            if (element.ID == ID)
                            {
                                newList.Add(element);
                            }
                        }
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Loign)
                    {
                        Console.SetCursorPosition(10, 1);
                        string Login = Console.ReadLine();
                        foreach (var element in list)
                        {
                            if (element.Login == Login)
                            {
                                newList.Add(element);
                            }
                        }
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Password)
                    {
                        Console.SetCursorPosition(13, 2);
                        string Password = Console.ReadLine();
                        foreach (var element in list)
                        {
                            if (element.Password == Password)
                            {
                                newList.Add(element);
                            }
                        }
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Post)
                    {
                        var Post = ReadInt(6, 0, 7).ToString();
                        foreach (var element in list)
                        {
                            if (element.Post == Post)
                            {
                                newList.Add(element);
                            }
                        }
                    }
                    break;
                }
            }
            if(newList.Count != 0)
            {
                DrewAllInterface(newList,account);
            }
        }

        public override List<acc> Create(List<acc> list)
        {
            acc account = new acc
            {
                ID = list.Count,
                Login = "null",
                Password = "null",
                Post = "null"
            };
            while (true)
            {
                Console.Clear();
                Read(account);
                ConsoleKeyInfo key = ArrowMenu(0, 3);
                if (key.Key == (ConsoleKey)HotKey.Назад)
                {
                    Console.CursorVisible = false;
                    break;
                }
                else if (key.Key == (ConsoleKey)HotKey.Выбрать)
                {
                    Console.CursorVisible = true;
                    if (Console.CursorTop - 1 == (int)AccountAttribute.ID)
                    {
                        bool error;
                        do
                        {
                            error = false;
                            var ID = ReadInt(6, 0, 7);
                            account.ID = ID == null ? account.ID : Convert.ToInt32(ID);
                            foreach (var element in list)
                            {
                                if (element.ID == account.ID && element != account)
                                {
                                    error = true;
                                    break;
                                }
                            }
                        } while (error);
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Loign)
                    {
                        bool error;
                        do
                        {
                            error = false;
                            Console.SetCursorPosition(10, 1);
                            account.Login = Console.ReadLine();
                            foreach (var element in list)
                            {
                                if (element.Login == account.Login && element != account)
                                {
                                    error = true;
                                    break;
                                }
                            }
                        } while (error);
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Password)
                    {
                        Console.SetCursorPosition(13, 2);
                        account.Password = Console.ReadLine();
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Post)
                    {
                        while (true)
                        {
                            account.Post = ReadInt(9, 3, 10).ToString();
                            if (DrewPostWorker(account.Post) != "null")
                            {
                                break;
                            }
                        }
                    }
                }
            }
            if(account.Post != "null" &&(!string.IsNullOrEmpty(account.Login) && account.Login != "null") && (!string.IsNullOrEmpty(account.Password) && account.Password != "null"))
            {
                list.Add(account);
                JsonDS.Serelialize("Account.json", list);
            }
            return list;
        }
        public override List<acc> Delete(List<acc> list)
        {
            list.RemoveAt(PositionCursor - 1);
            JsonDS.Serelialize("Account.json", list);
            return list;
        }
        public override List<acc> Update(List<acc> list, acc account)
        {
            while (true)
            {
                Console.Clear();
                Read(account);
                ConsoleKeyInfo key = ArrowMenu(0, 3);
                if (key.Key == (ConsoleKey)HotKey.Назад)
                {
                    Console.CursorVisible = false;
                    break;
                }
                else if (key.Key == (ConsoleKey)HotKey.Выбрать)
                {
                    Console.CursorVisible = true;
                    if (Console.CursorTop - 1 == (int)AccountAttribute.ID)
                    {
                        bool error;
                        do
                        {
                            error = false;
                            var ID = ReadInt(6, 0, 7);
                            account.ID = ID == null ? account.ID : Convert.ToInt32(ID);
                            foreach (var element in list)
                            {
                                if (element.ID == account.ID && element != account)
                                {
                                    error = true;
                                    break;
                                }
                            }
                        } while (error);
                    } else if (Console.CursorTop - 1 == (int)AccountAttribute.Loign)
                    {
                        bool error;
                        do
                        {
                            error = false;
                            Console.SetCursorPosition(10, 1);
                            account.Login = Console.ReadLine();
                            foreach (var element in list)
                            {
                                if (element.Login == account.Login && element != account)
                                {
                                    error = true;
                                    break;
                                }
                            }
                        } while (error);
                    }
                    else if (Console.CursorTop - 1 == (int)AccountAttribute.Password)
                    {
                        Console.SetCursorPosition(13, 2);
                        account.Password = Console.ReadLine();
                    } else if (Console.CursorTop - 1 == (int)AccountAttribute.Post)
                    {
                        while (true)
                        {
                            account.Post = ReadInt(9, 3, 10).ToString();
                            if (DrewPostWorker(account.Post) != "null")
                            {
                                break;
                            }
                        }
                    }
                }
            }
            JsonDS.Serelialize("Account.json",list);
            return list;
        }
        public override void Read(acc account)
        {
            Console.WriteLine("  ID: " + account.ID);
            Console.WriteLine("  Login: " + account.Login);
            Console.WriteLine("  Password: " + account.Password);
            Console.WriteLine("  Post: " + account.Post);
        }
        private ConsoleKeyInfo ArrowMenu(int startPositionCursot, int EndPositionCursor)
        {
            Console.CursorVisible = false;
            PositionCursor = startPositionCursot;
            int LastPositionCursor;
            ConsoleKeyInfo key;
            while (true)
            {
                Console.SetCursorPosition(0, PositionCursor);
                Console.WriteLine("->");
                key = Console.ReadKey();
                if (key.Key == (ConsoleKey)HotKey.Вверх)
                {
                    LastPositionCursor = PositionCursor--;
                    PositionCursor = PositionCursor < startPositionCursot ? EndPositionCursor : PositionCursor;
                    ClearLastPositionArrow(LastPositionCursor);
                }
                else if (key.Key == (ConsoleKey)HotKey.Вниз)
                {
                    LastPositionCursor = PositionCursor++;
                    PositionCursor = PositionCursor > EndPositionCursor ? startPositionCursot : PositionCursor;
                    ClearLastPositionArrow(LastPositionCursor);
                }
                else
                {
                    break;
                }
            }
            return key;
        }
        private void ClearLastPositionArrow(int LastPosition)
        {
            Console.SetCursorPosition(0, LastPosition);
            Console.WriteLine("  ");
        }
        private int? ReadInt(int left, int top, int lenstring)
        {
            List<char> a = new List<char>();
            string b = "";
            while (true)
            {
                Console.SetCursorPosition(left, top);
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == (ConsoleKey)HotKey.Выбрать)
                {
                    break;
                }
                else if (key.Key == (ConsoleKey)HotKey.Стереть)
                {
                    if (a.Count > 0)
                    {
                        a.RemoveAt(left - lenstring);
                        Console.SetCursorPosition(left - 1, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(left + 1, top);
                        left--;
                    }
                }
                else
                {
                    if (char.IsNumber(key.KeyChar))
                    {
                        Console.SetCursorPosition(left, top);
                        Console.Write(key.KeyChar);
                        a.Add(key.KeyChar);
                        left++;
                    }
                    else
                    {
                        Console.SetCursorPosition(left, top);
                        Console.Write(" ");
                    }
                }
            }
            foreach (var element in a)
            {
                b += element;
            }
            return string.IsNullOrEmpty(b)?null:Convert.ToInt32(b);
        }
    }
}
