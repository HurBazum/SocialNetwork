namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Добро пожаловать в социальную сеть!");
            Console.WriteLine("Авторизоваться (нажмите 1)");
            Console.WriteLine("Зарегистрироваться (нажмите 2)");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Program.authenticationView.Show();
                    break;
                case ConsoleKey.D2:
                    Program.registrationView.Show();
                    break;
            }
        }
    }
}