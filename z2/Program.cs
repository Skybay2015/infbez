using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace z2
{
    public class PBKDF2
    {
        public static byte[] GenerateSalt()
        {
            using (var randomNumberGenerator =
            new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public static byte[] HashPassword(byte[] toBeHashed,
        byte[] salt, int numberOfRounds)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(
            toBeHashed, salt, numberOfRounds))
            {
                return rfc2898.GetBytes(20);
            }
        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            const string passwordToHash = "VeryComplexPassword";
            HashPassword(passwordToHash, 240000);
            HashPassword(passwordToHash, 290000);
            HashPassword(passwordToHash, 340000);
            HashPassword(passwordToHash, 390000);
            HashPassword(passwordToHash, 440000);
            HashPassword(passwordToHash, 490000);
            HashPassword(passwordToHash, 540000);
            HashPassword(passwordToHash, 590000);
            HashPassword(passwordToHash, 640000);
            HashPassword(passwordToHash, 690000);
            Console.ReadLine();
        }
        private static void HashPassword(string passwordToHash,
        int numberOfRounds)
        {
            var sw = new Stopwatch();
            sw.Start();
            var hashedPassword = PBKDF2.HashPassword(
            Encoding.UTF8.GetBytes(passwordToHash),
            PBKDF2.GenerateSalt(),
            numberOfRounds);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("Password to hash : " + passwordToHash);
            Console.WriteLine("Hashed Password : " +
               Convert.ToBase64String(hashedPassword));
            Console.WriteLine("Iterations <" + numberOfRounds + ">Elapsed Time: " +
           sw.ElapsedMilliseconds + "ms");
        }
    }
}

