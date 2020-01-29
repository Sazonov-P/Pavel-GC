using Converter.Models;
using System;
using System.Linq;
using System.Text;

namespace ASSIGNMENT_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input your full name: ");
            string user_input = Console.ReadLine();

            // Binary Convert
            Console.WriteLine("The binary code of your input information is: " + Binary_Converter.StringToBinary2(user_input));
            string binary_name = Binary_Converter.StringToBinary2(user_input);
            Console.WriteLine("Binary to ASCII is: " + user_input);

            // Hexadecimal Convert
            Console.WriteLine("The Hexadecimal code of your input information is: " + Hexadecimal_Converter.StringToHex2(user_input));
            Console.WriteLine("Hexadecimal to ASCII is: " + user_input);

            // Base64 Convert
            Console.WriteLine("The base64 code of your input information is: " + Base64Encode(user_input));
            Console.WriteLine("Base64 to ASCII is: " + user_input);

            //DeepEncryptWithCipher
            int[] mycipher = new[] { 5, 1, 0, 9, 0, 9, 4, 2, 1, 7, 1, 7, 0, 9, 4, 4, 0, 0, 0, 0 }; //21!
            Console.WriteLine("The DeepEncryptWithCipher of your name: " + Encrypter.DeepEncryptWithCipher(user_input, mycipher, 20));
            var DEWC_text = Encrypter.DeepEncryptWithCipher(user_input, mycipher, 20);
            Console.WriteLine("The DeepDecryptWithCipher of your name: " + Encrypter.DeepDecryptWithCipher(DEWC_text, mycipher, 20));


            //string unicodeString = "This string contains the unicode character Pi (\u03a0)";
            //int[] cipher = new[] { 1, 1, 2, 3, 5, 8, 13 }; //Fibonacci Sequence
            //string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            //int encryptionDepth = 10;

            //Encrypter encrypter = new Encrypter(unicodeString, cipher, encryptionDepth);

            ////Single Level Encrytion
            //string nameEncryptWithCipher = Encrypter.EncryptWithCipher(unicodeString, cipher);
            //Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            //string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            //Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            ////Deep Encrytion
            //string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(unicodeString, cipher, encryptionDepth);
            //Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            //string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            //Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            ////Base64 Encoded
            //Console.WriteLine($"Base64 encoded {unicodeString} {encrypter.Base64}");

            //string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            //Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");
        }
        public static string Base64Encode(string string_base64)
        {
            var text_tobase64 = System.Text.Encoding.UTF8.GetBytes(string_base64);
            return System.Convert.ToBase64String(text_tobase64);
        }
    }

    class Binary_Converter
    {
        /// <summary>
        /// A more mathmatical approach to ASCII to Binary conversion
        /// https://forums.asp.net/t/1713174.aspx?How+to+convert+ASCII+value+to+binary+value+using+c+net
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns></returns>
        public static string StringToBinary2(string data)
        {
            string converted = string.Empty;
            // convert string to byte
            byte[] byteArray = Encoding.ASCII.GetBytes(data);


            for (int i = 0; i < byteArray.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    converted += (byteArray[i] & 0x80) > 0 ? "1" : "0";
                    byteArray[i] <<= 1;
                }
            }

            return converted;
        }
    }
    class Hexadecimal_Converter
    {
        /// <summary>
        /// An approach to ASCII to Hexadecimal conversion using ToString("X2")
        /// </summary>
        /// <param name="data">String to convert</param>
        /// <returns></returns>
        public static string StringToHex2(string data)
        {
            StringBuilder sb = new StringBuilder();

            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            foreach (byte bytepart in bytearray)
            {
                sb.Append(bytepart.ToString("X2"));
            }

            return sb.ToString().ToUpper();
        }
    }
}
