using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class LookinForUserByIdView
    {
        UserService userService;

        public LookinForUserByIdView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show()
        {
            Console.WriteLine("Введите id пользователя: ");
            var lookingForId = int.Parse(Console.ReadLine()!);
            Console.WriteLine(userService.DisplayProfileById(lookingForId));
            Console.WriteLine();
        }
    }
}