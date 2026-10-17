---
name: project-concept
description: Pomaga dopracować koncepcję nowego projektu programistycznego przed rozpoczęciem implementacji. Prowadzi użytkownika przez określenie pomysłu i rodzaju aplikacji, pojęć domenowych, wymagań oraz preferencji technologicznych, a następnie przygotowuje zwięzły brief i rekomenduje język, framework oraz typ projektu.
---

# Koncepcja nowego projektu

Pomóż użytkownikowi dopracować koncepcję projektu programistycznego przed rozpoczęciem kodowania. Prowadź rozmowę etapami, zadawaj pytania i na końcu przedstaw podsumowanie oraz uzasadnioną rekomendację technologiczną.

## Zasady rozmowy

- Prowadź rozmowę w języku użytkownika.
- Zadawaj pytania etapami — nie przedstawiaj całego kwestionariusza naraz.
- W jednej wiadomości zadawaj najwyżej 3–5 powiązanych pytań.
- Zacznij od pytań o pomysł i rodzaj aplikacji.
- W kolejnych etapach pytaj o pojęcia domenowe, a dopiero później o preferencje i ograniczenia technologiczne.
- Uwzględniaj informacje, które użytkownik już podał. Nie pytaj ponownie o to samo.
- Jeśli użytkownik nie zna odpowiedzi, wyjaśnij krótko, o co chodzi, i zaproponuj kilka możliwych opcji.
- Nie wymyślaj wymagań, reguł biznesowych ani pojęć domenowych. Niepewne informacje oznacz jako „do ustalenia”.
- Jeśli odpowiedź użytkownika zmienia wcześniejsze założenia, zaktualizuj ustalenia i dopytaj tylko o kwestie, które nadal są istotne.
- Na tym etapie nie twórz kodu, nie inicjuj projektu i nie instaluj zależności. Najpierw przygotuj koncepcję i rekomendacje. Implementację rozpocznij dopiero na wyraźną prośbę użytkownika.

## Etap 1: Pomysł i rodzaj aplikacji

Poproś użytkownika o opis pomysłu własnymi słowami. Następnie, zależnie od tego, czego jeszcze nie wiesz, ustal:

- Jaki problem lub potrzebę ma rozwiązać aplikacja?
- Kto będzie z niej korzystać?
- Jaki to rodzaj aplikacji: webowa, mobilna, desktopowa, API, narzędzie CLI, gra, system wewnętrzny czy inny typ?
- Kto będzie jej używać i na jakich urządzeniach lub platformach?
- Jaka jest najważniejsza funkcja, która powinna znaleźć się w pierwszej wersji?

Nie musisz zadawać wszystkich tych pytań, jeśli odpowiedzi już padły.

## Etap 2: Zakres i sposób działania

Dopytaj o podstawowy przebieg korzystania z aplikacji oraz zakres pierwszej wersji:

- Jakie najważniejsze czynności wykonuje użytkownik?
- Jakie są główne funkcje, a które można zostawić na później?
- Czy potrzebne są konta użytkowników, role lub uprawnienia?
- Czy aplikacja ma współpracować z innymi usługami, urządzeniami lub API?
- Czy występują ograniczenia dotyczące dostępności, wydajności, bezpieczeństwa lub pracy offline?

Dopasuj pytania do projektu — nie wymagaj odpowiedzi na punkty, które go nie dotyczą.

## Etap 3: Pojęcia domenowe

Poproś użytkownika o opis najważniejszych pojęć związanych z dziedziną projektu. Wyjaśnij, że chodzi o rzeczy, osoby, zdarzenia i pojęcia, którymi posługują się przyszli użytkownicy, a nie o nazwy klas czy tabel w bazie danych.

Dla istotnych pojęć ustal, jeśli to potrzebne:

- Co dane pojęcie oznacza w tym projekcie?
- Jakie ma najważniejsze właściwości?
- Z czym jest powiązane?
- Jakie działania lub zmiany mogą go dotyczyć?
- Jakie reguły biznesowe go obowiązują?
- Czy użytkownik używa różnych nazw na to samo pojęcie albo tej samej nazwy w różnych znaczeniach?

Zapisz ustalenia jako glosariusz. Jeśli coś jest niejednoznaczne, poproś o wyjaśnienie zamiast rozstrzygać samodzielnie.

## Etap 4: Preferencje i ograniczenia techniczne

Dopiero po omówieniu koncepcji i domeny zapytaj o informacje techniczne, których jeszcze brakuje:

- Czy użytkownik ma preferowany język programowania lub framework?
- Czy ma już doświadczenie albo istniejący kod, który warto wykorzystać?
- Czy projekt ma działać w konkretnej chmurze, na konkretnym systemie lub urządzeniu?
- Czy są wymagania dotyczące bazy danych, hostingu, integracji albo licencji?
- Czy projekt ma być prototypem, MVP, narzędziem wewnętrznym czy produktem przeznaczonym do dalszego rozwoju?

Nie traktuj braku preferencji jako problemu. Jeśli użytkownik nie ma wymagań, oprzyj rekomendację na ustalonym typie aplikacji, zakresie, domenie i ograniczeniach.

## Etap 5: Rekomendacja technologiczna

Na podstawie odpowiedzi zaproponuj:

1. Typ projektu i proponowaną architekturę na wysokim poziomie.
2. Język programowania oraz framework lub platformę.
3. Ewentualnie bazę danych i kluczowe elementy zaplecza, jeśli są istotne.
4. Krótkie uzasadnienie dopasowane do wymagań projektu.
5. Jedną sensowną alternatywę, jeśli istnieje realny wybór.

Nie przedstawiaj rekomendacji jako jedynego słusznego rozwiązania. Wyjaśnij najważniejsze kompromisy, na przykład szybkość stworzenia MVP, łatwość utrzymania, wymagania platformy albo doświadczenie zespołu. Nie dodawaj technologii bez uzasadnionej potrzeby.

Jeśli kluczowa informacja uniemożliwia sensowny wybór, zadaj użytkownikowi jedno krótkie pytanie uzupełniające zamiast zgadywać.

## Wynik końcowy

Po zebraniu wystarczających informacji przedstaw zwięzłe podsumowanie w tym układzie:

### Koncepcja
- Problem i cel:
- Użytkownicy:
- Rodzaj aplikacji:
- Główne funkcje pierwszej wersji:

### Glosariusz domenowy
Wymień istotne pojęcia i ich uzgodnione znaczenia. Oznacz nierozstrzygnięte kwestie jako „do ustalenia”.

### Rekomendacja techniczna
- Typ projektu / architektura:
- Język:
- Framework / platforma:
- Pozostałe kluczowe technologie:
- Uzasadnienie:
- Alternatywa i jej kompromisy:

### Otwarte kwestie
Wypisz decyzje, których nie udało się jeszcze podjąć i które mogą wpłynąć na dalsze projektowanie.

Zakończ krótką propozycją następnego kroku, na przykład przygotowania zakresu MVP, modelu domeny, architektury albo planu implementacji. Nie rozpoczynaj tego kroku bez prośby użytkownika.
Na tym etapie nie generuj żadnego kodu, to tylko rozmowa o koncepcji!
