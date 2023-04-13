using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Посмотреть информацию о своём профиле(нажмите 1)");
                Console.WriteLine("Редактировать мой профиль(нажмите 2)");
                Console.WriteLine("Посмотреть информацию о чужом профиле(нажмите 3)");
                Console.WriteLine("Посмотреть список друзей(нажмите 4)");
                Console.WriteLine("Добавить в друзья(нажмите 5)");
                Console.WriteLine("Удалить из друзей(нажмите 6)");
                Console.WriteLine("Написать сообщение(нажмите 7)");
                Console.WriteLine("Выйти из профиля(нажмите 8)");


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        Console.CursorLeft = 0;
                        Program.profileView.Show(user);
                        break;

                    case ConsoleKey.D2:
                        Console.CursorLeft = 0;
                        Program.dataUpdateView.Show(user);
                        break;

                    case ConsoleKey.D3:
                        Console.CursorLeft = 0;
                        Program.lookinUserById.Show();
                        break;

                    case ConsoleKey.D4:
                        Console.CursorLeft = 0;
                        Program.friendList.Show(user);
                        break;

                    case ConsoleKey.D5:
                        Console.CursorLeft = 0;
                        Program.friendView.Show(user);
                        break;

                    case ConsoleKey.D6:
                        Console.CursorLeft = 0;
                        Program.deleteFriend.Show(user);
                        break;

                    case ConsoleKey.D7:
                        Console.CursorLeft = 0;
                        Program.messageView.Show(user);
                        break;

                    case ConsoleKey.D8:
                        Console.Clear();
                        return;
                }
            }
        }
    }
}