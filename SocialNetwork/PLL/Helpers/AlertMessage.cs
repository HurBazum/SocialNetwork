namespace SocialNetwork.PLL.Helpers
{
    public static class AlertMessage
    {
        public static void Show(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}