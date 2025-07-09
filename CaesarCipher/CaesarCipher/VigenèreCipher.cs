using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class VigenèreCipher : Cipher
    {
        public VigenèreCipher(string text, string key) : base(text, key)
        {
        }


        public override string Encryption()
        {
            string encryptedMessage = string.Empty;

            string modifiedKey = KeyManagement(_key, _text);

            for (int i = 0; i < _text.Length; i++)
            {
                int x = (_text[i] + modifiedKey[i]) % Alphabet.Length;

                x += 'A';
                char ch = (char)(x);

                encryptedMessage += ch;
            }

            return encryptedMessage;
        }

        public override string Decryption()
        {
            string encryptedMessage = string.Empty;
            string modifiedKey = KeyManagement(_key, _text);

            for (int i = 0; i < _text.Length; i++)
            {
                int x = (_text[i] - modifiedKey[i]) % Alphabet.Length;

                x += 'A';
                char ch = (char)(x);

                encryptedMessage += ch;
            }

            return encryptedMessage;
        }

        //Repeating the key work until in match the secret text length
        private string KeyManagement(string key, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (key.Length == text.Length)
                {
                    break;
                }

                key += key[i];
            }

            return key;
        }
    }
}
