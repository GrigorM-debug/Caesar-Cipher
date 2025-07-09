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
            string keyModified = KeyManagement(_key, _text).ToUpper();

            for (int i = 0; i < _text.Length; i++)
            {
                if (!char.IsLetter(_text[i]))
                {
                    encryptedMessage += _text[i];
                }

                char characterToUpperCase = char.ToUpper(_text[i]);
                if(Alphabet.Contains(characterToUpperCase))
                {
                    int charIndex = Alphabet.IndexOf(characterToUpperCase);

                    if (charIndex < 0)
                    {
                        charIndex += Alphabet.Length;
                    }

                    char keyCharacter = keyModified[i % keyModified.Length];
                    int keyIndex = Alphabet.IndexOf(keyCharacter);

                    char encryptedCharacter = Alphabet[(charIndex + keyIndex) % Alphabet.Length];

                    if (char.IsLower(_text[i]))
                    {
                       encryptedMessage += char.ToLower(encryptedCharacter);
                    }
                    encryptedMessage += char.ToUpper(encryptedCharacter);
                }
            }

            return encryptedMessage;
        }

        public override string Decryption()
        {
            string encryptedMessage = string.Empty;
            string keyModified = KeyManagement(_key, _text).ToUpper();

            for (int i = 0; i < _text.Length; i++)
            {
                if (!char.IsLetter(_text[i]))
                {
                    encryptedMessage += _text[i];
                }

                char characterToUpper = char.ToUpper(_text[i]);
                if (Alphabet.Contains(characterToUpper)) 
                {
                    int charIndex = Alphabet.IndexOf(characterToUpper);
                    char keyCharacter = keyModified[i % keyModified.Length];
                    int keyIndex = Alphabet.IndexOf(keyCharacter);

                    int encryptedCharacterIndex = (charIndex - keyIndex) % Alphabet.Length;
                    if (encryptedCharacterIndex < 0)
                    {
                        encryptedCharacterIndex += Alphabet.Length;
                    }

                    char encryptedCharacter = Alphabet[encryptedCharacterIndex];

                    if (char.IsLower(_text[i]))
                    {
                        encryptedMessage += char.ToLower(encryptedCharacter);
                    }
                    encryptedMessage += char.ToUpper(encryptedCharacter);
                }
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
