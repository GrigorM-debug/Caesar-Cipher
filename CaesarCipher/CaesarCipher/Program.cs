using CaesarCipher;
using TextCopy;

Console.InputEncoding = System.Text.Encoding.Unicode;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(@"  ___ __ _  ___  ___  __ _ _ __        _       _               
 / __/ _` |/ _ \/ __|/ _` | '__|     (_)     | |              
| (_| (_| |  __/\__ \ (_| | |     ___ _ _ __ | |__   ___ _ __ 
 \___\__,_|\___||___/\__,_|_|    / __| | '_ \| '_ \ / _ \ '__|
                                 | (__| | |_) | | | |  __/ |   
                                  \___|_| .__/|_| |_|\___|_|   
                                        | |                    
                                        |_|      ");

Console.WriteLine(@".-------------------.---------------.----------.----------.---------------.
|E N C R Y P T|===|M E S S A G E S|===|L I K E|===|R O M A N|===|E M P E R O R|™
'-------------------'---------------'----------'----------'---------------'");

Console.WriteLine();

Console.ForegroundColor = ConsoleColor.White;

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

Console.Write("Enter your secret key (0-26): ");
int key = int.Parse(Console.ReadLine());

while (key < 0 || key > 26)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Secret key number must be between 0 and 26 !");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Enter your secret key (0-26): ");
    key = int.Parse(Console.ReadLine());
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

CaesarCipher.CaesarCipher caesarCipher = new CaesarCipher.CaesarCipher(key.ToString(), secret);

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

string result = string.Empty;

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


Console.WriteLine("Operation successful! Here is your result -> ");
Console.ForegroundColor  = ConsoleColor.Green;
Console.WriteLine($"> {result}");
ClipboardService.SetText(result);
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("The result is copied in your clipboard.");