using System;
using System.IO;
using System.Linq;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] decData = File.ReadAllBytes("text.txt").ToArray();
            byte[] encriptedData = new byte[decData.Length];
            byte key = 113;
            Console.WriteLine("____info____");
            for (int i = 0; i < decData.Length; i++)
            {
                Console.Write((char)decData[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < decData.Length; i++)
            {
                encriptedData[i] = (byte)(decData[i] ^ key);
            }
            Console.WriteLine("__scripted_info___");
            for (int i = 0; i < decData.Length; i++)
            {
                Console.Write((char)encriptedData[i]);
            }
            Console.WriteLine();


            File.WriteAllBytes("text.dat", encriptedData);
            Console.WriteLine("__decoded_info___");


            byte[] NewData = new byte[decData.Length];
            for (int i = 0; i < decData.Length; i++)
            {
                NewData[i] = (byte)(encriptedData[i] ^ key);
                Console.Write((char)NewData[i]);
            }
            Console.WriteLine();
        }
    }
}
