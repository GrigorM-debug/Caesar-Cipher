using CaesarCipher;
using TextCopy;

Console.InputEncoding = System.Text.Encoding.Unicode;

Console.Write("English (0) or Bulgarian (1)?: ");
int alphabetToggle = int.Parse(Console.ReadLine());

while (alphabetToggle < 0 || alphabetToggle > 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Your choose can be only 0 or 1 !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("English (0) or Bulgarian (1)?: ");
    alphabetToggle = int.Parse(Console.ReadLine());
}

//Ask the user for which cipher he wants
Console.Write("Choose cipher - Caesar Cipher (0) or Vigenère Cipher (1)?: ");
int cipherToggle = int.Parse(Console.ReadLine());
while (cipherToggle < 0 || cipherToggle > 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Your choose can be only 0 or 1 !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Choose cipher - Caesar Cipher(0) or Vigenère Cipher(1)?:");
    cipherToggle = int.Parse(Console.ReadLine());
}

Console.Write("Enter your secret message: ");
string secret = Console.ReadLine();

while(string.IsNullOrEmpty(secret) || string.IsNullOrWhiteSpace(secret))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Secret message can't be null or empty !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Enter your secret message: ");
    secret = Console.ReadLine();
}

Console.Write("Enter your secret key: ");
string key = Console.ReadLine();

switch (cipherToggle)
{
    //Caesar Cipher
    case 0:
        while (int.Parse(key) < 0 || int.Parse(key) > 26)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Secret key number must be between 0 and 26 !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your secret key: ");
            key = Console.ReadLine();
        }
        break;
    //Vigenère Cipher
    case 1:
        while (string.IsNullOrWhiteSpace(key.ToString()) || string.IsNullOrEmpty(key.ToString()))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Key can't be null or empty !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your secret key: ");
            key = Console.ReadLine();
        }

        while (key.ToString() == secret)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your key and secret message can't be the same!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your secret key: ");
            secret = Console.ReadLine();
        }
        break;
}

Console.Write("> Encryption (0) or Decryption (1)?: ");
int toggle = int.Parse(Console.ReadLine());

while (toggle < 0 || toggle > 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Your choose can be only 0 or 1 !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("> Encryption (0) or Decryption (1)?: ");
    toggle = int.Parse(Console.ReadLine());
}

string englishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string bulgarianAlphabet = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЮЯ";

string result = string.Empty;
switch (cipherToggle)
{
    //Caesar cipher
    case 0:
        CaesarCipher.CaesarCipher caesarCipher = new CaesarCipher.CaesarCipher(secret, key.ToString());

        switch (alphabetToggle)
        {
            //English
            case 0:
                caesarCipher.Alphabet = englishAlphabet;
                break;
            //Bulgarian
            case 1:
                caesarCipher.Alphabet = bulgarianAlphabet;
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                break;
        }

        result = string.Empty;

        switch (toggle)
        {
            //Encryption
            case 0:
                result = caesarCipher.Encryption();
                break;
            //Decryption
            case 1:
                result = caesarCipher.Decryption();
                break;
        }
        break;
    case 1:
        VigenèreCipher vigenèreCipher = new VigenèreCipher(secret, key.ToString());

        switch (alphabetToggle)
        {
            //English
            case 0:
                vigenèreCipher.Alphabet = englishAlphabet;
                break;
            //Bulgarian
            case 1:
                vigenèreCipher.Alphabet = bulgarianAlphabet;
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                break;
        }

        result = string.Empty;

        switch (toggle)
        {
            //Encryption
            case 0:
                result = vigenèreCipher.Encryption();
                break;
            //Decryption
            case 1:
                result = vigenèreCipher.Decryption();
                break;
        }
        break;
}


Console.WriteLine("Operation successful! Here is your result -> ");
Console.ForegroundColor  = ConsoleColor.Green;
Console.WriteLine($"> {result}");
ClipboardService.SetText(result);
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("The result is copied in your clipboard.");