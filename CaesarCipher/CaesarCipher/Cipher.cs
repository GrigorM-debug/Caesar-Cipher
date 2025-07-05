using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class Cipher(string text, int key)
    {
        private readonly string _text = text;
        private readonly int _key = key;

        public string Alphabet { get; set; }

        public string Encryption()
        {
            string encryptedMessage = String.Empty;

            foreach (var letterCharacter in _text)
            {
                if (!char.IsLetter(letterCharacter))
                {
                    encryptedMessage += letterCharacter;
                }

                char letterCharacterToUpperCase = char.ToUpper(letterCharacter);
                if (Alphabet.Contains(letterCharacterToUpperCase))
                {
                    //Current letter index in the alphabet
                    int index = Alphabet.IndexOf(letterCharacterToUpperCase);
                    
                    //The encrypted letter index
                    int encryptedIndex = (index + _key) % Alphabet.Length;

                    char encryptedLetter = Alphabet[encryptedIndex];

                    if (char.IsLower(letterCharacter))
                    {
                        encryptedMessage += char.ToLower(encryptedLetter);
                    }
                    else
                    {
                        encryptedMessage += encryptedLetter;
                    }
                }
            }

            return encryptedMessage;
        }

        public string Decryption()
        {
            string decryptedMessage = string.Empty;

            foreach (var letterCharacter in _text)
            {
                if (!char.IsLetter(letterCharacter))
                {
                    decryptedMessage += letterCharacter;
                }

                char letterCharacterToUpperCase = char.ToUpper(letterCharacter);
                if (Alphabet.Contains(letterCharacterToUpperCase))
                {
                    ////Current index in the alphabet
                    int index = Alphabet.IndexOf(letterCharacterToUpperCase);

                  
                    var calculation = index - _key;
                    if (calculation < 0)
                    {
                        calculation += 26;

                    }
                    char decryptedLetter = Alphabet[calculation % 26];

                    if (char.IsLower(letterCharacter))
                    {
                        decryptedMessage += char.ToLower(decryptedLetter);
                    }
                    else
                    {
                        decryptedMessage += decryptedLetter;
                    }
                }
            }

            return decryptedMessage;
        }
    }
}
