using System;
using System.IO;

namespace EncryptionDecryption_XOR
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string from, to;
            byte[] key;

            Console.WriteLine("File you want to decrypt or encrypt: ");
            from = Console.ReadLine();

            Console.WriteLine("Output to where: ");
            to = Console.ReadLine();

            Console.WriteLine("Key: ");
            key = System.Text.Encoding.ASCII.GetBytes(Console.ReadLine());

            Encrypt(from, to, key);
        }

        static void Encrypt(string from, string to, byte[] key)
        {
            byte[] file = File.ReadAllBytes(from);
            for (var i = 0; i < file.Length; i++)
                file[i] ^= key[i % key.Length];

            File.WriteAllBytes(to, file);
        }

    }
}
