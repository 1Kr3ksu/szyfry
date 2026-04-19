using System;
using System.Text;
using System.Linq;

namespace CiphersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz algorytm szyfrowania:");
            Console.WriteLine("1. Szyfr Vigenère'a");
            Console.WriteLine("2. Szyfr Przestawieniowy (Kolumnowy)");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.WriteLine("Wprowadź tekst do zaszyfrowania (wielkie litery, bez polskich znaków):");
                string text = Console.ReadLine()?.ToUpper() ?? "";
                
                Console.WriteLine("Wprowadź klucz (słowo, wielkie litery):");
                string key = Console.ReadLine()?.ToUpper() ?? "";
                
                string encrypted = VigenereEncrypt(text, key);
                Console.WriteLine($"\nZaszyfrowany tekst: {encrypted}");
            }
            else if (choice == "2")
            {
                Console.WriteLine("Wprowadź tekst do zaszyfrowania:");
                string text = Console.ReadLine()?.Replace(" ", "").ToUpper() ?? "";
                
                Console.WriteLine("Wprowadź klucz (słowo, bez powtarzających się liter):");
                string key = Console.ReadLine()?.ToUpper() ?? "";
                
                string encrypted = ColumnarTranspositionEncrypt(text, key);
                Console.WriteLine($"\nZaszyfrowany tekst: {encrypted}");
            }
            else
            {
                Console.WriteLine("Nieznany wybór.");
            }
        }

        static string VigenereEncrypt(string text, string key)
        {
            if (string.IsNullOrEmpty(key)) return text;
            
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;
            
            foreach (char c in text)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    char keyChar = key[keyIndex % key.Length];
                    int shift = keyChar - 'A';
                    
                    char encryptedChar = (char)(((c - 'A' + shift) % 26) + 'A');
                    result.Append(encryptedChar);
                    
                    keyIndex++;
                }
                else
                {
                    result.Append(c);
                }
            }
            
            return result.ToString();
        }

        static string ColumnarTranspositionEncrypt(string text, string key)
        {
            if (string.IsNullOrEmpty(key) || text.Length == 0) return text;
            
            int columns = key.Length;
            int rows = (int)Math.Ceiling((double)text.Length / columns);
            
            char[,] grid = new char[rows, columns];
            int textIndex = 0;
            
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (textIndex < text.Length)
                    {
                        grid[r, c] = text[textIndex++];
                    }
                    else
                    {
                        grid[r, c] = 'X'; // Wypełnienie brakujących miejsc literą X
                    }
                }
            }
            
            var sortedKey = key.Select((c, i) => new { Char = c, Index = i })
                               .OrderBy(x => x.Char)
                               .ToList();
                               
            StringBuilder result = new StringBuilder();
            
            foreach (var keyColumn in sortedKey)
            {
                for (int r = 0; r < rows; r++)
                {
                    result.Append(grid[r, keyColumn.Index]);
                }
            }
            
            return result.ToString();
        }
    }
}
