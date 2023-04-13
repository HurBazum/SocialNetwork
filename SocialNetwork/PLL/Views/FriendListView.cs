using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class FriendListView
    {
        FriendService friendService;

        public FriendListView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            friendService.LookFriendList(user);
            Console.WriteLine();
        }
    }
}