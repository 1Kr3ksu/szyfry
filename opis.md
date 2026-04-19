# Projekt z Kryptografii i Szyfrowania



## Struktura Projektu

### 1. Transkrypcja na Alfabet Morse'a (Katalog: `MorseCode`)
Aplikacja konsolowa w języku C# (`Program.cs`). 
Jej zadaniem jest pobranie od użytkownika ciągu znaków (opartego o wielkie litery alfabetu łacińskiego) i przetłumaczenie go na odpowiadające mu sygnały w alfabecie Morse'a. Program automatycznie ignoruje wielkość liter przy wprowadzaniu.

### 2. Szyfry: Vigenère'a oraz Przestawieniowy (Katalog: `CiphersApp`)
Aplikacja konsolowa w języku C# (`Program.cs`).
Program posiada proste menu tekstowe, które pozwala użytkownikowi wybrać jeden z dwóch algorytmów szyfrujących:
* **Szyfr Vigenère'a**: Polialfabetyczny szyfr podstawieniowy wykorzystujący klucz tekstowy do odpowiedniego przesunięcia liter alfabetu.
* **Szyfr Przestawieniowy (Kolumnowy)**: Szyfr transpozycyjny, w którym jawny tekst wpisywany jest do macierzy, a następnie odczytywany kolumnami zgodnie z kolejnością alfabetyczną liter podanego klucza. Brakujące miejsca (puste komórki macierzy) uzupełniane są literą 'X'.

### 3. Witryna Internetowa do Szyfrowania (Katalog: `WebApp`) - Zadanie Domowe
Kompletna aplikacja webowa uruchamiana bezpośrednio w przeglądarce, stworzona z wykorzystaniem technologii HTML, CSS i JavaScript.
Witryna została zaprojektowana zgodnie z nowoczesnymi trendami UI/UX, posiadając przejrzysty układ i estetyczną oprawę wizualną.

Aplikacja pozwala na interaktywne szyfrowanie tekstu przy pomocy trzech klasycznych algorytmów:
* **Szyfr Cezara** (wymaga podania liczbowego przesunięcia)
* **Szyfr Vigenère'a** (wymaga podania słowa kluczowego)
* **Szyfr Przestawieniowy Kolumnowy** (wymaga podania słowa kluczowego)

**Instrukcja uruchomienia witryny:**
Aby przetestować szyfrowanie na stronie internetowej, wystarczy otworzyć plik `index.html` znajdujący się w katalogu `WebApp` za pomocą dowolnej przeglądarki internetowej (np. Chrome, Edge, Firefox). Działanie algorytmów (JavaScript) odbywa się w pełni po stronie klienta, bez konieczności uruchamiania serwera.
