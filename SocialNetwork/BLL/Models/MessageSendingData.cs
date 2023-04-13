using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Models
{
    public class MessageSendingData
    {
        public int SenderId { get; }
        public string Content { get; set; }
        public string RicepientEmail { get; set; }

        public MessageSendingData(int sender_id)
        {
            SenderId = sender_id;
        }
    }
}