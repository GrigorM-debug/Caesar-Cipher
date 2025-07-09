using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException();
        }

        public override string Decryption()
        {
            throw new NotImplementedException();
        }

    }
}
