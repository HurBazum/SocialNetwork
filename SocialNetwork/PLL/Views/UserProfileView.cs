using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserProfileView
    {
        public void Show(User user)
        {
            Console.WriteLine(user.ToString());
        }
    }
}