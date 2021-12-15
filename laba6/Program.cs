﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;




namespace laba6
{
    class desChipher
    {
        public byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var CryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                    CryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    CryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var CryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
                    CryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    CryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }
    class tripleDesChipher
    {
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var CryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), CryptoStreamMode.Write);
                    CryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    CryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var des = new TripleDESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = key;
                des.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var CryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), CryptoStreamMode.Write);
                    CryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    CryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }
    class aesChipher
    {
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var CryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    CryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    CryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = iv;
                using (var memoryStream = new MemoryStream())
                {
                    var CryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    CryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    CryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            const string original = "qwerty";
            var des = new desChipher();
            var tripleDes = new tripleDesChipher();
            var aes = new aesChipher();        
            var Key1 = des.GenerateRandomNumber(8);
            var Iv1 = des.GenerateRandomNumber(8);
            var desEncrypted = des.Encrypt(Encoding.UTF8.GetBytes(original), Key1, Iv1);
            var desDecrypted = des.Decrypt(desEncrypted, Key1, Iv1);
            var desDecryptedMessage = Encoding.UTF8.GetString(desDecrypted);
            Console.WriteLine("DES Encryption");
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(desEncrypted));
            Console.WriteLine("Decrypted Text = " + desDecryptedMessage);
            Console.WriteLine();
            var Key2 = des.GenerateRandomNumber(24);
            var Iv2 = des.GenerateRandomNumber(8);
            var tripleDesEncrypted = tripleDes.Encrypt(Encoding.UTF8.GetBytes(original), Key2, Iv2);
            var tripleDesDecrypted = tripleDes.Decrypt(tripleDesEncrypted, Key2, Iv2);
            var tripleDesDecryptedMessage = Encoding.UTF8.GetString(tripleDesDecrypted);
            Console.WriteLine("TripleDES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(tripleDesEncrypted));
            Console.WriteLine("Decrypted Text = " + tripleDesDecryptedMessage);
            Console.WriteLine();      
            var Key3 = des.GenerateRandomNumber(32);
            var Iv3 = des.GenerateRandomNumber(16);
            var aesEncrypted = aes.Encrypt(Encoding.UTF8.GetBytes(original), Key3, Iv3);
            var aesDecrypted = aes.Decrypt(aesEncrypted, Key3, Iv3);
            var aesDecryptedMessage = Encoding.UTF8.GetString(aesDecrypted);
            Console.WriteLine("AES Encryption");
            Console.WriteLine();
            Console.WriteLine("Original Text = " + original);
            Console.WriteLine("Encrypted Text = " + Convert.ToBase64String(aesEncrypted));
            Console.WriteLine("Decrypted Text = " + aesDecryptedMessage);
        }
    }
}