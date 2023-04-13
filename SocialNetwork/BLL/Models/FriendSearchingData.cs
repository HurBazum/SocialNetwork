namespace SocialNetwork.BLL.Models
{
    public class FriendSearchingData
    {
        public int FriendId { get; set; }
        public int UserId { get; }
        public string FriendEmail { get; set; }

        public FriendSearchingData(int user_id)
        {
            UserId = user_id;
        }
    }
}