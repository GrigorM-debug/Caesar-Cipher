using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    public abstract class Cipher
    {
        protected readonly string _text;
        protected readonly string _key;

        protected Cipher(string text, string key)
        {
            _text = text;
            _key = key;
        }

        public string Alphabet { get; set; }

        public abstract string Encryption();

        public abstract string Decryption();
    }
}
