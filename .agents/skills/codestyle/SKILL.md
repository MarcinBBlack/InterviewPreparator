---
name: codestyle-csharp
description: określa styl kodowania w języku C#
---
#Nazewnictwo zmiennych
Pola prywatne klasy lub struktury nazywaj metodą camelCase poprzedzoną znakiem _ , pola publiczne również camelCase, ale bez znaku _ . Publiczne właściwości styl PascalCase.

#Wcięcia
Uzywaj 4 znaków spacji na wcięcia, unikaj tabulatur.

#Nawiasy klamrowe
Tworząc metody, nawias klamrowy otwierający rób w nowej linii. 

#Komentarze
Używaj komentarzy jednolinijkowych. W przypadku metod używaj komentarzy xmlowych z opisem metody, jej parametrów wejściowych i tego co zwraca.

#Zmienne lokalne
Jeżeli to możliwe, używaj var dla zmiennych lokalnych. Konkretne typy tylko w przypadku kiedy konieczne jest przypisaniu wartości null.

#Kolejność
Najpierw definiuj const oraz zmienne private readonly, później zmienne protected, potem zmienne public, później właściwości. Analogiczna kolejność dotyczy metod. Konstruktory umieść za właściwościami publicznymi. Użyj regionów do grupowania wszystkich tych bytów.

#private readonly
W przypadku pól prywatnych, które nie będą modyfikowane, używaj private readonly. Stosuj to np. do wstrzykiwania przez konstruktor interfejsów klas serwisowych bądź repozytoriów.

#Instrukcje
Pisz nie więcej niż jedną instrukcję w jednej linii. Jeżeli dana instrukcja jest długa, możesz przenieść jej część do następnych linii. Jeżeli metoda posiada wiele paraemtrów, każdy wpisuj w osobnej linii.

#Pliki
Twórz pliki tylko zdefiniowane w prompcie. Nie twórz samemu bez zgody bytów. Jeżeli uznasz, że są potrzebne, pytaj użytkownika o pozwolenie na ich utworzenie.

#Typy
Używaj aliasów z wielkiej litery, np. Int32, Int64, Boolean, String, Decimal itd.