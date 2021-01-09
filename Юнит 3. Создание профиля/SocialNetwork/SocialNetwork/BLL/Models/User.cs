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
            string favoriteBook)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Email = email;
            this.Photo = photo;
            this.FavoriteMovie = favoriteMovie;
            this.FavoriteBook = favoriteBook;
        }
    }
}
