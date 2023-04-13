using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserSendMessageView
    {
        MessageService messageService;
        public UserSendMessageView(MessageService messageService)
        {
            this.messageService = messageService;
        }
        public void Show(User user)
        {
            MessageSendingData messageSendingData = new(user.Id);

            Console.WriteLine("Введите email адресата:");
            messageSendingData.RicepientEmail = Console.ReadLine();
            Console.WriteLine("Введите текст сообщения:");
            messageSendingData.Content = Console.ReadLine();
            messageService.SendMessage(messageSendingData);
        }
    }
}