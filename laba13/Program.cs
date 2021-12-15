using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using NLog;
using Microsoft.Extensions.Logging;


namespace laba13
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
        private static Logger log = NLog.LogManager.GetCurrentClassLogger();
        private static Dictionary<string, User> _users = new Dictionary<string, User>();

        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator =
            new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[16];
                log.Trace("creating RNGCryptoServiceProvider");
                randomNumberGenerator.GetBytes(randomNumber);
                log.Trace("RandomNumber");
                log.Debug("RandomNumber");
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
            log.Trace("Checking Name");
            log.Debug("Checking Name");
            if (_users.ContainsKey(userName))
            {
                Console.WriteLine("user exist");
                return null;
            }
            else
            {
                User newUser = new User();
                byte[] salt = GenerateSalt();
                log.Debug("salt");
                byte[] hashedPassword = HashPasswordSHA256(Encoding.Default.GetBytes(password), salt, 10);
                log.Debug("hash");
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
            Logger log = NLog.LogManager.GetCurrentClassLogger();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter your login: ");
                var login = Console.ReadLine();
                log.Debug("login");
                Console.WriteLine("Enter your password: ");
                var pw = Console.ReadLine();
                log.Debug("password");
                Console.WriteLine("Enter your roles: ");
                string rolesReadLine = Console.ReadLine();
                log.Debug("variable for roles");
                string[] roles = rolesReadLine.Split(" ");
                log.Debug("variable for roles");
                Protector.Register(login, pw, roles);
                Console.WriteLine();
            }
        }
    }
}
