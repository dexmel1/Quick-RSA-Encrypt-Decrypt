// See https://aka.ms/new-console-template for more information


using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;


while (true)
{
    Console.WriteLine("Encrypt: 1\nDecrypt: 2");
    int userChoice = int.Parse(Console.ReadLine());
    if (userChoice == 1)
    {
        Console.WriteLine("Enter your message:");
        string userInput = Console.ReadLine().ToUpper();
        Convert(userInput);
    }
    else if (userChoice == 2)
    {
        Console.WriteLine("Enter your encrypted message:");
        string userCrypto = Console.ReadLine();
        List<string> holder = new List<string>(userCrypto.Split(' '));
        List<long> userEncrypt = new List<long>();
        foreach (string holderItem in holder)
        {
            userEncrypt.Add(long.Parse(holderItem));
        }
        Decrypt(userEncrypt);

    } 
}




 static void Convert (string s)
    {
        string nums = "";
        string  hold = "";
        List<long> longs = new List<long>();
        Dictionary<string, long> AlphaNumero = new Dictionary<string, long>()
        {
            {"A", 01 },
            {"B", 02 },
            {"C", 03 },
            {"D", 04 },
            {"E", 05 },
            {"F", 06 },
            {"G", 07 },
            {"H", 08 },
            {"I", 09 },
            {"J", 10 },
            {"K", 11 },
            {"L", 12 },
            {"M", 13 },
            {"N", 14 },
            {"O", 15 },
            {"P", 16 },
            {"Q", 17 },
            {"R", 18 },
            {"S", 19 },
            {"T", 20 },
            {"U", 21 },
            {"V", 22 },
            {"W", 23 },
            {"X", 24 },
            {"Y", 25 },
            {"Z", 26 },
            {".", 31 },
            {" ", 32 },
        };

        foreach (char c in s)
        {
            hold =  AlphaNumero[c.ToString()].ToString();
            nums+=(hold + " ");
        longs.Add(AlphaNumero[c.ToString()]);
        }

    Console.WriteLine(nums);

    Encrypt(longs);

    }

 static void Encrypt(List<long> plainlong)
{
    List<long> encryplong = new List<long>();
    string nums = "";

    foreach (long i in plainlong)
    {
        if(i == 32)
        {
            encryplong.Add(i);
            nums += (i + " ");
        }
        else
        {
            long j = (long)Math.Pow(i, 3);
            long k = j % 33;
            encryplong.Add(k);
            nums += (k + " "); 
        }
    }
    Console.WriteLine("Encrypted: ");
    Console.WriteLine(nums);

    Decrypt(encryplong);
}

static void Decrypt(List<long> encryptlong)
{
    List<long> decryptlong = new List<long>();
    string nums = "";
    string letters = "";
    Dictionary<long, string> AlphaNumero = new Dictionary<long, string>()
        {
        {1, "A"},
        {2, "B"},
        {3, "C"},
        {4, "D"},
        {5, "E"},
        {6, "F"},
        {7, "G"},
        {8, "H"},
        {9, "I"},
        {10, "J"},
        {11, "K"},
        {12, "L"},
        {13, "M"},
        {14, "N"},
        {15, "O"},
        {16, "P"},
        {17, "Q"},
        {18, "R"},
        {19, "S"},
        {20, "T"},
        {21, "U"},
        {22, "V"},
        {23, "W"},
        {24, "X"},
        {25, "Y"},
        {26, "Z"},
        {31, "."},
        {32, " "}
        };

    foreach (long i in encryptlong)
    {
        if(i == 32)
        {
            decryptlong.Add(i);
            nums += (i + " ");
        }
       else
        {
            long j = (long)Math.Pow(i, 7);
            long k = j % 33;
            decryptlong.Add(k);
            nums += (k + " "); 
        }
    }
    Console.WriteLine("decrypted Numbers: ");
    Console.WriteLine(nums );

    foreach (long i in decryptlong)
    {
        letters += AlphaNumero[i].ToString();
    }

    Console.WriteLine(letters);
}



