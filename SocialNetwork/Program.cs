using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new();
        public static FriendService friendService = new();
        public static MessageService messageService = new();
        public static MainView mainView = new();
        public static AuthenticationView authenticationView = new(userService);
        public static RegistrationView registrationView = new(userService);
        public static UserMenuView userMenu = new();
        public static UserProfileView profileView = new();
        public static UserDataUpdateView dataUpdateView = new(userService);
        public static UserAddToFriendView friendView = new(friendService);
        public static UserSendMessageView messageView = new(messageService);
        public static LookinForUserByIdView lookinUserById = new(userService);
        public static FriendListView friendList = new(friendService);
        public static DeleteFriendView deleteFriend = new(friendService);
        
        static void Main(string[] args)
        {
            while (true)
            {
                mainView.Show();
            }
        }
    }
}