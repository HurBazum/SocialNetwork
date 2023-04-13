using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserDataUpdateView
    {
        UserService userService;
        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show(User user)
        {
            Console.CursorLeft = 0;

            Console.Write("Меня зовут: ");
            user.FirstName = Console.ReadLine();
            Console.Write("Моя фамилия: ");
            user.LastName = Console.ReadLine();
            Console.Write("Ссылка на моё фото: ");
            user.Photo = Console.ReadLine();
            Console.Write("Мой любимый фильм: ");
            user.FavoriteMovie = Console.ReadLine();
            Console.Write("Моя любимая книга: ");
            user.FavoriteBook = Console.ReadLine();

            userService.Update(user);

            SuccesMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}