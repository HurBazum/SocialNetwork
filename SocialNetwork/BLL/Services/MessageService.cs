using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository messageRepository;
        IUserRepository userRepository;

        public MessageService()
        {
            messageRepository = new MessageRepository();
            userRepository = new UserRepository();
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            if(string.IsNullOrEmpty(messageSendingData.Content))
            {
                throw new ArgumentNullException();
            }
            if(messageSendingData.Content.Length > 5000) 
            {
                throw new ArgumentOutOfRangeException();
            }

            var findUserEntity = userRepository.FindByEmail(messageSendingData.RicepientEmail);

            if(findUserEntity is null)
            {
                throw new UserNotFoundException();
            }

            MessageEntity messageEntity = new()
            { 
                content = messageSendingData.Content,
                sender_id = messageSendingData.SenderId,
                recipient_id = findUserEntity.id
            };

            if (messageRepository.Create(messageEntity) == 0)
            {
                throw new Exception();
            }
            else
            {
                SuccesMessage.Show("Сообщение успешно отправлено!");
            }
        }
    }
}