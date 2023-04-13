using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        public IUserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }
        public void Register(UserRegistrationData userRegistrationData)
        {
            if(string.IsNullOrEmpty(userRegistrationData.FirstName))
            {
                throw new ArgumentNullException();
            }
            if(string.IsNullOrEmpty(userRegistrationData.LastName))
            {
                throw new ArgumentNullException(); 
            }
            if(string.IsNullOrEmpty(userRegistrationData.Password))
            {
                throw new ArgumentNullException();
            }
            if(string.IsNullOrEmpty(userRegistrationData.Email))
            {
                throw new ArgumentNullException();
            }
            if(userRegistrationData.Password.Length < 8)
            {
                throw new ArgumentNullException();
            }
            if(!new EmailAddressAttribute().IsValid(userRegistrationData.Email)) 
            {
                throw new ArgumentNullException();
            }
            if(userRepository.FindByEmail(userRegistrationData.Email) != null)
            {
                throw new ArgumentNullException();
            }

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if(userRepository.Create(userEntity) == 0)
            {
                throw new Exception();
            }
        }
        private User ConstructUserModel(UserEntity userEntity)
        {
            return new User(
                userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book
                );
        }

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);

            if(findUserEntity == null) 
            {
                throw new UserNotFoundException();
            }
            if (findUserEntity.password != userAuthenticationData.Password) 
            {
                throw new WrongPasswordException();
            }

            return ConstructUserModel(findUserEntity);
        }

        public void Update(User user)
        {
            var updatetableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (userRepository.Update(updatetableUserEntity) == 0)
            {
                throw new UserNotFoundException();
            }
        }

        /// <summary>
        /// Просмотр чужого профиля по id
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DisplayProfileById(int id)
        {
            try
            {
                var foundUser = ConstructUserModel(userRepository.FindById(id));

                return $"""
                            информация о профиле id#{foundUser.Id}:
                        Имя: {foundUser.FirstName}
                        Фамилия: {foundUser.LastName}
                        Почтовый адрес: {foundUser.Email}
                        Ссылка на фото: {foundUser.Photo}
                        Любимый фильм: {foundUser.FavoriteMovie}
                        Любимая книга: {foundUser.FavoriteBook}
                    """;
            }
            catch (UserNotFoundException)
            {
                return "Пользователь с таким id не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}