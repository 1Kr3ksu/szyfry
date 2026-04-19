using System;
using System.Collections.Generic;

namespace MorseCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> morseAlphabet = new Dictionary<char, string>()
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
                {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
                {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
                {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
                {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
                {'Z', "--.."}, {' ', "/"}
            };

            Console.WriteLine("Wprowadź tekst do przetłumaczenia na alfabet Morse'a (tylko litery łacińskie):");
            string input = Console.ReadLine()?.ToUpper() ?? "";
            
            Console.WriteLine("\nWynik w alfabecie Morse'a:");
            foreach (char c in input)
            {
                if (morseAlphabet.ContainsKey(c))
                {
                    Console.Write(morseAlphabet[c] + " ");
                }
                else
                {
                    // Nieznane znaki ignorujemy lub oznaczamy znakiem zapytania
                    Console.Write("? ");
                }
            }
            Console.WriteLine();
        }
    }
}
