using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService userService;

        public RegistrationView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            Console.Clear();

            Console.WriteLine("Для регистрации пользователя введите");
            Console.Write("Имя: ");
            string firstname = Console.ReadLine();
            Console.Write("Фамилия: ");
            string lastname = Console.ReadLine();
            Console.Write("Пароль: ");
            string password = Console.ReadLine();
            Console.Write("Почтовый адрес: ");
            string email = Console.ReadLine();

            UserRegistrationData userRegistrationData = new()
            {
                FirstName = firstname,
                LastName = lastname,
                Password = password,
                Email = email
            };

            try
            {
                userService.Register(userRegistrationData);

                SuccesMessage.Show("Регистрация прошла успешно!");
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }
            catch (Exception e)
            {
                AlertMessage.Show($"Произошла ошибка при регистрации!\n{e.Message}");
            }
        }
    }
}