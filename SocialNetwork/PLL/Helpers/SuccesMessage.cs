namespace SocialNetwork.PLL.Helpers
{
    public static class SuccesMessage
    {
        public static void Show(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}