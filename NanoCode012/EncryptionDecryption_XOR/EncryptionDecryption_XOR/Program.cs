using System;
using System.IO;

namespace EncryptionDecryption_XOR
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region path
            var text_path = @"/Users/kevinvong/Desktop/Visual Studio/Learning/NanoCode012/EncryptionDecryption_XOR/EncryptionDecryption_XOR/Text/TextFile.txt";
            var key_path = @"/Users/kevinvong/Desktop/Visual Studio/Learning/NanoCode012/EncryptionDecryption_XOR/EncryptionDecryption_XOR/Text/KeyFile.txt";
            var encrypt_path = @"/Users/kevinvong/Desktop/Visual Studio/Learning/NanoCode012/EncryptionDecryption_XOR/EncryptionDecryption_XOR/Text/EncryptedFile.txt";
            var decrypt_path = @"/Users/kevinvong/Desktop/Visual Studio/Learning/NanoCode012/EncryptionDecryption_XOR/EncryptionDecryption_XOR/Text/DecryptedFile.txt";
            #endregion

            //Choose mode
            var mode = ValidateInputMode();//true is encrypt. false is decrypt

            if (mode)
            {
                Encryption(text_path, key_path, encrypt_path);
            }
            else
            {
                Decryption(key_path, encrypt_path, decrypt_path);
            }
        }

        static void Decryption(string key_path, string encrypt_path, string decrypt_path)
        {
            //I commented out some features because they don't work properly.
            Console.WriteLine("Please enter text you want to decrypt : ");
            var text = Console.ReadLine();

            Console.WriteLine("Please enter secret key : ");
            var key = Console.ReadLine();

            File.WriteAllText(encrypt_path, text);
            File.WriteAllText(key_path, key);

            var encryptedByte = File.ReadAllBytes(encrypt_path);
            var keyByte = File.ReadAllBytes(key_path);

            Decrypt(decrypt_path, encryptedByte, keyByte);
            Console.WriteLine("The decrypted key is " + File.ReadAllText(decrypt_path));
        }

        static void Encryption(string text_path, string key_path, string encrypt_path)
        {
            Console.WriteLine("Please enter text you want to encrypt : ");
            var text = Console.ReadLine();

            Console.WriteLine("Please enter secret key : ");
            var key = Console.ReadLine();

            File.WriteAllText(text_path, text);
            File.WriteAllText(key_path, key);

            var textByte = File.ReadAllBytes(text_path);
            var keyByte = File.ReadAllBytes(key_path);

            Encrypt(encrypt_path, textByte, keyByte);
            Console.WriteLine("The encrypted key is " + File.ReadAllText(encrypt_path));
        }

        static bool ValidateInputMode()
        {
            bool mode;
            while (true)
            {
                Console.WriteLine("Please enter 1 for encryption, 0 for decryption : ");
                var tempMode = Console.ReadLine();
                if (tempMode == "1")
                {
                    mode = true;
                    break;
                }
                else if (tempMode == "0")
                {
                    mode = false;
                    break;
                }
                else
                {
                    Console.WriteLine("An error occurred. Only input 1 OR 0!");
                    continue;
                }
            }
            return mode;
        }

        static void Encrypt(string encrypt_path, byte[] textByte, byte[] keyByte)
        {
            var index = 0;
            var intervals = textByte.Length / keyByte.Length;
            var encryption = new byte[textByte.Length];
            for (var i = 0; i <= intervals; i++)
            {
                for (var j = 0; j < keyByte.Length; j++)
                {
                    if (index >= textByte.Length) break;
                    encryption[index] = (byte)(textByte[index] ^ keyByte[j]);
                    index++;
                }
            }
            File.WriteAllBytes(encrypt_path, encryption);
        }

		static void Decrypt(string decrypt_path, byte[] encryptByte, byte[] keyByte)
		{
			var index = 0;
			var intervals = encryptByte.Length / keyByte.Length;
			var decryption = new byte[encryptByte.Length];
			for (var i = 0; i <= intervals; i++)//runs 6 times, maybe 5
			{
				for (var j = 0; j < keyByte.Length; j++)
				{
					if (index >= encryptByte.Length) break;
					decryption[index] = (byte)(encryptByte[index] ^ keyByte[j]);
					index++;
				}
			}
			File.WriteAllBytes(decrypt_path, decryption);
		}
    
    }
}
