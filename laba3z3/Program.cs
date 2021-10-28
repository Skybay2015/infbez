using System;
using System.Security.Cryptography;
using System.Text;

namespace laba3z3
{
    class Program
    {
        static void Main(string[] args)
        {
                static byte[] ComputeHmacsha1(byte[] toBeHashed, byte[] key)
                {
                    using (var hmac = new HMACSHA1(key))
                    {
                        return hmac.ComputeHash(toBeHashed);
                    }
                }
                const string M1 = "abcd";
                const string M2 = "1234";
                string k = "key";
                string origHash = Convert.ToBase64String(ComputeHmacsha1(Encoding.Unicode.GetBytes(M1), Encoding.Unicode.GetBytes(k)));
                Console.WriteLine(origHash);
                void check(string message, string key, string origHash)
                {
                    var hash = ComputeHmacsha1(Encoding.Unicode.GetBytes(message), Encoding.Unicode.GetBytes(key));
                    if (origHash == Convert.ToBase64String(hash))
                    {
                        Console.WriteLine("Ok");
                    }
                    else
                    {
                        Console.WriteLine("Fake");
                    }
                }
                check(M1, k, origHash);
                check(M2, k, origHash);
            }
    }
}
