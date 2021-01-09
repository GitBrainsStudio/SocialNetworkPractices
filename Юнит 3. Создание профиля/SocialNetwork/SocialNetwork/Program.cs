using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while(true)
            {
                Console.WriteLine("Войти в профиль (нажмите 1)");
                Console.WriteLine("Зарегистрироваться (нажмите 2)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var authenticationData = new UserAuthenticationData();

                            Console.WriteLine("Введите почтовый адрес:");
                            authenticationData.Email = Console.ReadLine();

                            Console.WriteLine("Введите пароль:");
                            authenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(authenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Вы успешно вошли в социальную сеть! Добро пожаловать {0}", user.FirstName);
                                Console.ForegroundColor = ConsoleColor.White;


                                while (true)
                                {
                                    Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                                    Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                                    Console.WriteLine("Добавить в друзья (нажмите 3)");
                                    Console.WriteLine("Написать сообщение (нажмите 4)");
                                    Console.WriteLine("Выйти из профиля (нажмите 5)");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Информация о моем профиле");
                                                Console.WriteLine("Мой идентификатор: {0}", user.Id);
                                                Console.WriteLine("Меня зовут: {0}", user.FirstName);
                                                Console.WriteLine("Моя фамилия: {0}", user.LastName);
                                                Console.WriteLine("Мой пароль: {0}", user.Password);
                                                Console.WriteLine("Мой почтовый адрес: {0}", user.Email);
                                                Console.WriteLine("Ссылка на моё фото: {0}", user.Photo);
                                                Console.WriteLine("Мой любимый фильм: {0}", user.FavoriteMovie);
                                                Console.WriteLine("Моя любимая книга: {0}", user.FavoriteBook);
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.Write("Меня зовут:");
                                                user.FirstName = Console.ReadLine();

                                                Console.Write("Моя фамилия:");
                                                user.LastName = Console.ReadLine();

                                                Console.Write("Ссылка на моё фото:");
                                                user.Photo = Console.ReadLine();

                                                Console.Write("Мой любимый фильм:");
                                                user.FavoriteMovie = Console.ReadLine();

                                                Console.Write("Моя любимая книга:");
                                                user.FavoriteBook = Console.ReadLine();

                                                userService.Update(user);

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ваш профиль успешно обновлён!");
                                                Console.ForegroundColor = ConsoleColor.White;

                                                break;
                                            }
                                    }
                                }
                                
                            }

                            catch (WrongPasswordException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пароль не корректный!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            catch (UserNotFoundException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пользователь не найден!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        }

                    case "2":
                        {
                            var userRegistrationData = new UserRegistrationData();

                            Console.WriteLine("Для создания нового профиля введите ваше имя:");
                            userRegistrationData.FirstName = Console.ReadLine();

                            Console.Write("Ваша фамилия:");
                            userRegistrationData.LastName = Console.ReadLine();

                            Console.Write("Пароль:");
                            userRegistrationData.Password = Console.ReadLine();

                            Console.Write("Почтовый адрес:");
                            userRegistrationData.Email = Console.ReadLine();

                            try
                            {
                                userService.Register(userRegistrationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            catch (ArgumentNullException)
                            {
                                Console.WriteLine("Введите корректное значение.");
                            }

                            catch (Exception)
                            {
                                Console.WriteLine("Произошла ошибка при регистрации.");
                            }

                            break;
                        }
                }
            }

        }
    }
}
