using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class DeleteFriendView
    {
        FriendService friendService;

        public DeleteFriendView(FriendService friendService)
        {
            this.friendService = friendService;
        }

        public void Show(User user)
        {
            friendService.DeleteFriend(user);
        }
    }
}