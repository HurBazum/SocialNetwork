using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.PLL.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriend(FriendSearchingData friendSearchingData)
        {
            var foundFriend = userRepository.FindByEmail(friendSearchingData.FriendEmail);

            if(foundFriend is null)
            {
                throw new UserNotFoundException();
            }

            friendSearchingData.FriendId = foundFriend.id;

            FriendEntity friend = new()
            { 
                friend_id = friendSearchingData.FriendId,
                user_id = friendSearchingData.UserId,
            };

            if(friendRepository.Create(friend) == 0)
            {
                throw new Exception();
            }
            else
            {
                SuccesMessage.Show($"Пользователь {foundFriend.email} успешно добавлен в друзья!");
            }
        }

        public void LookFriendList(User user)
        {
            var friends = friendRepository.FindAllByUserId(user.Id);

            if(friends.Count() > 0)
            {
                SuccesMessage.Show("Список друзей:");
                foreach(var friend in friends)
                {
                    Console.WriteLine(userRepository.FindById(friend.friend_id).email);
                }
            }
            else
            {
                AlertMessage.Show("У Вас пока нет друзей. Попробуйте найти их по email!");
            }
        }

        public void DeleteFriend(User user)
        {

            Console.Write("Введите email друга, которого хотите удалить: ");
            string deleteEmail = Console.ReadLine();

            try
            {
                if (!new EmailAddressAttribute().IsValid(deleteEmail))
                {
                    throw new ArgumentNullException();
                }

                var friends = friendRepository.FindAllByUserId(user.Id);

                var friend = userRepository.FindByEmail(deleteEmail);

                if(friends.Count() > 0) 
                {

                }
                if (friend is null)
                {
                    throw new UserNotFoundException();
                }

                if(friends.Count() > 0)
                {
                      
                    var idFriend = from f in friends
                                   where f.friend_id == friend.id
                                   select f.id;
                    // чтобы избежать вывода ошибки: sequence contains no elements
                    if (idFriend.Count() == 0)
                    {
                        throw new NotYourFriendException();
                    }
                    if (friendRepository.Delete(idFriend.First()) == 0)
                    {
                        throw new NotYourFriendException();
                    }
                    else
                    {
                        SuccesMessage.Show($"{friend.email} был успешно удалён из друзей!");
                    }
                }
                else
                {
                    throw new Exception("У Вас нет друзей. Возможно, Вы всех уже удалили!");
                }
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show($"Присутствует опечатка в {deleteEmail}!");
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show($"{deleteEmail} не зарегистрирован в системе!");
            }
            catch(NotYourFriendException)
            {
                AlertMessage.Show($"{deleteEmail} не является Вашим другом!");
            }
            catch (Exception e)
            {
                AlertMessage.Show(e.Message);
            }
        }
    }
}