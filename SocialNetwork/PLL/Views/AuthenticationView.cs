using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;

        public AuthenticationView(UserService service)
        {
            userService = service;
        }

        public void Show()
        {
            Console.Clear();

            UserAuthenticationData authData = new();

            Console.Write("Введите email: ");
            authData.Email = Console.ReadLine();
            Console.Write("Введите пароль: ");
            authData.Password = Console.ReadLine();

            try
            {
                User user = userService.Authenticate(authData);

                SuccesMessage.Show($"Вы успешно вошли в социальную сеть!\n Добро пожаловать, {user.FirstName}!");

                Program.userMenu.Show(user);
            }
            catch (WrongPasswordException)
            {
                AlertMessage.Show("Введён неверный пароль!");
            }
            catch (UserNotFoundException) 
            {
                AlertMessage.Show("Пользователь с таким email не существует!");
            }
            catch(Exception ex)
            {
                AlertMessage.Show(ex.Message);
            }
        }
    }
}