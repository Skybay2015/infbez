using System;
using System.Security.Cryptography;
using System.Text;

namespace laba3z1
{
    class Program
    {
        static void Main(string[] args)
        {
            static byte[] ComputeHashMd5(byte[] dataForHash)
            {
                using (var md5 = MD5.Create())
                {
                    return md5.ComputeHash(dataForHash);
                }
            }

            const string Message = "hello world";
            const string Message2 = "hello world";
            const string Messsage3 = "Hello world";

            var md5M = ComputeHashMd5(Encoding.Unicode.GetBytes(Message));
            var md5M2 = ComputeHashMd5(Encoding.Unicode.GetBytes(Message2));
            var md5M3 = ComputeHashMd5(Encoding.Unicode.GetBytes(Messsage3));
            Guid guid1 = new Guid(md5M);
            Guid guid2 = new Guid(md5M2);
            Guid guid3 = new Guid(md5M3);

            Console.WriteLine("MD5:");
            Console.WriteLine(Message);
            Console.WriteLine(Convert.ToBase64String(md5M));
            Console.WriteLine(guid1);
            Console.WriteLine(Message2);
            Console.WriteLine(Convert.ToBase64String(md5M2));
            Console.WriteLine(guid2);
            Console.WriteLine(Messsage3);
            Console.WriteLine(Convert.ToBase64String(md5M3));
            Console.WriteLine(guid3);
            Console.WriteLine("-------");

            static byte[] ComputeHashSha1(byte[] toBeHashed)
            {
                using (var sha1 = SHA1.Create())
                {
                    return sha1.ComputeHash(toBeHashed);
                }
            }

            var sha1M = ComputeHashSha1(Encoding.Unicode.GetBytes(Message));
            var sha1M1 = ComputeHashSha1(Encoding.Unicode.GetBytes(Message2));
            var sha1M2 = ComputeHashSha1(Encoding.Unicode.GetBytes(Messsage3));

            Console.WriteLine("SHA1:");
            Console.WriteLine(Message);
            Console.WriteLine(Convert.ToBase64String(sha1M));
            Console.WriteLine(Message2);
            Console.WriteLine(Convert.ToBase64String(sha1M1));
            Console.WriteLine(Messsage3);
            Console.WriteLine(Convert.ToBase64String(sha1M2));
            Console.WriteLine("--------");

            static byte[] ComputeHashSha256(byte[] toBeHashed)
            {
                using (var sha256 = SHA256.Create())
                {
                    return sha256.ComputeHash(toBeHashed);
                }
            }
            var sha256M = ComputeHashSha256(Encoding.Unicode.GetBytes(Message));
            var sha256M1 = ComputeHashSha256(Encoding.Unicode.GetBytes(Message2));
            var sha256M2 = ComputeHashSha256(Encoding.Unicode.GetBytes(Messsage3));

            Console.WriteLine("SHA256:");
            Console.WriteLine(Message);
            Console.WriteLine(Convert.ToBase64String(sha256M));
            Console.WriteLine(Message2);
            Console.WriteLine(Convert.ToBase64String(sha256M1));
            Console.WriteLine(Messsage3);
            Console.WriteLine(Convert.ToBase64String(sha256M2));
            Console.WriteLine("--------");

            static byte[] ComputeHashSha384(byte[] toBeHashed)
            {
                using (var sha384 = SHA384.Create())
                {
                    return sha384.ComputeHash(toBeHashed);
                }
            }

            var sha384M = ComputeHashSha384(Encoding.Unicode.GetBytes(Message));
            var sha384M1 = ComputeHashSha384(Encoding.Unicode.GetBytes(Message2));
            var sha384M2 = ComputeHashSha384(Encoding.Unicode.GetBytes(Messsage3));

            Console.WriteLine("SHA384:");
            Console.WriteLine(Message);
            Console.WriteLine(Convert.ToBase64String(sha384M));
            Console.WriteLine(Message2);
            Console.WriteLine(Convert.ToBase64String(sha384M1));
            Console.WriteLine(Messsage3);
            Console.WriteLine(Convert.ToBase64String(sha384M2));
            Console.WriteLine("----------");

            static byte[] ComputeHashSha512(byte[] toBeHashed)
            {
                using (var sha512 = SHA512.Create())
                {
                    return sha512.ComputeHash(toBeHashed);
                }
            }

            var sha512M = ComputeHashSha512(Encoding.Unicode.GetBytes(Message));
            var sha512M1 = ComputeHashSha512(Encoding.Unicode.GetBytes(Message2));
            var sha512M2 = ComputeHashSha512(Encoding.Unicode.GetBytes(Messsage3));

            Console.WriteLine("SHA512:");
            Console.WriteLine(Message);
            Console.WriteLine(Convert.ToBase64String(sha512M));
            Console.WriteLine(Message2);
            Console.WriteLine(Convert.ToBase64String(sha512M1));
            Console.WriteLine(Messsage3);
            Console.WriteLine(Convert.ToBase64String(sha512M2));
            Console.WriteLine("--------");
        }
    }
}
