namespace SocialNetwork.BLL.Models
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        public User(
            int id,
            string firstName,
            string lastName,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
        }

        public override string ToString()
        {
            return $"""
                        информация о профиле id#{Id}:
                    Имя: {FirstName}
                    Фамилия: {LastName}
                    Мой пароль: {Password}
                    Мой почтовый адрес: {Email}
                    Ссылка на фото: {Photo}
                    Любимый фильм: {FavoriteMovie}
                    Любимая книга: {FavoriteBook}
                """;
        }
    }
}