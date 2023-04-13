using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class UserAddToFriendView
    {
        FriendService friendService;
        public UserAddToFriendView(FriendService friendService)
        {
            this.friendService = friendService;
        }
        public void Show(User user)
        {
            FriendSearchingData friendData = new(user.Id);
            try
            {
                Console.Write("Введите email друга:");
                friendData.FriendEmail = Console.ReadLine();


                friendService.AddFriend(friendData);
            }
            catch(Exception e)
            {
                AlertMessage.Show(e.Message);
            }
        }
    }
}