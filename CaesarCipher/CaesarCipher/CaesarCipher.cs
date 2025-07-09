using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public class CaesarCipher : Cipher
    {
        public CaesarCipher(string text, string key) : base(text, key)
        {
        }

        public override string Encryption()
        {
            int keyToInt = int.Parse(_key);
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
                    int encryptedIndex = (index + keyToInt) % Alphabet.Length;

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

        public override string Decryption()
        {
            int keyToInt = int.Parse(_key);
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

                    int calculation = index - keyToInt;
                    if (calculation < 0)
                    {
                        calculation += Alphabet.Length;

                    }
                    char decryptedLetter = Alphabet[calculation % Alphabet.Length];

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
