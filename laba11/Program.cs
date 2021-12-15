using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace laba11
{
    class User
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string[] Roles { get; set; }
    }

    class Protector
    {
        private static Dictionary<string, User> _users = new Dictionary<string, User>();

        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator =
            new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[16];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] HashPasswordSHA256(byte[] toBeHashed, byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds, HashAlgorithmName.SHA256))
            {
                return rfc2898.GetBytes(64);
            }
        }



        public static User Register(string userName, string password, string[] roles = null)
        {
            if (_users.ContainsKey(userName))
            {
                Console.WriteLine("user exist");
                return null;
            }
            else
            {
                User newUser = new User();
                byte[] salt = GenerateSalt();
                byte[] hashedPassword = HashPasswordSHA256(Encoding.Default.GetBytes(password), salt, 10);
                newUser.Login = userName;
                newUser.Salt = Convert.ToBase64String(salt);
                newUser.PasswordHash = Convert.ToBase64String(hashedPassword);
                newUser.Roles = roles;
                _users.Add(userName, newUser);
                Console.WriteLine("complete");
                return null;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            for (int i =0; i<3;i++)
            {
                Console.WriteLine("Enter your login: ");
                var login = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                var pass = Console.ReadLine();
                Console.WriteLine("Enter your roles: ");
                string rolesReadLine = Console.ReadLine();
                string[] roles = rolesReadLine.Split(" ");
                Protector.Register(login, pass, roles);
                Console.WriteLine();
            }
        }
    }
}
