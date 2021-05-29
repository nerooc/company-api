<br/>


<img src="https://github.com/nerooc/company-api/blob/main/docs/cmAPI-logo.png" height="60" width="240" />

<br/>

### Company Management API (w oparciu o HierarchyID)
# Przetwarzanie danych hierarchicznych



- [1. Założenia projektu](#1-założenia-projektu)
- [2. Krótki wstęp teoretyczny](#2-krótki-wstęp-teoretyczny)
- [3. Zakres funkcjonalności](#3-zakres-funkcjonalności)
- [4. Opis implementacji](#4-opis-implementacji)
- [5. Przykładowe dane](#5-przykładowe-dane)
- [6. Prezentacja testów jednostkowych](#6-prezentacja-testów-jednostkowych)
- [7. Podsumowanie](#7-podsumowanie)
- [8. Literatura](#8-literatura)
- [9. Kod źródłowy](#9-kod-źródłowy)

## 1. Założenia projektu

Celem **CMAPI** (Company Management API) jest umożliwienie obsługi struktury firmy będącej strukturą **hierarchiczną**. Elementami w hierarchii będą pracownicy wraz z ich danymi personalnymi. Głównym założeniem projektu jest wykorzystanie typu **HierarchyID** do przechowywania wspomnianych danych hierarchicznych.

### Stos technologiczny:

- C#
- Microsoft SQL Server
- Typ HierarchyID
- Visual Studio Testing Tools

CMAPI jest biblioteką udostępniającą zestaw dwóch klas głównych (Employee i Company), z których jedna jest placeholderem do przechowywania danych o pracowniku, a druga daje dostęp do grupy metod działających na tych danych.

## 2. Krótki wstęp teoretyczny

Do stworzenia API wykorzystałem typ **HierarchyID** - używamy go, aby przedstawić pozycję w hierarchii. Kolumna typu hierarchyid nie reprezentuje automatycznie drzewa. Do aplikacji należy generowanie i przypisywanie wartości hierarchyid w taki sposób, aby pożądana relacja między wierszami była odzwierciedlona w wartościach.

## 3. Zakres funkcjonalności

Poprzez zestaw metod API pozwala użytkownikowi na dodawanie/usuwanie **pracowników** oraz tworzenie wybranych raportów.

Oprócz samego **API**, w projekcie uwzględniłem również testy jednostkowe, skrypty służące do utworzenia przykładowej bazy oraz aplikację konsolowa, służącą do przedstawienia przykładu działania stworzonego **API**.

## 3.1 Tabela Employee

Przechowuje dane na temat pracowników

![alt text](https://github.com/nerooc/company-api/blob/main/docs/employee_table.png)

## 3.2 Metody klasy Company

Udostępniają manipulację danymi pracowników

### Dodawanie pracownika - AddEmployee()

**Parametry**

- id \<<int\>>
- level \<<string\>>
- firstName \<<string\>>
- lastName \<<string\>>
- position \<<string\>>
- salary \<<int\>>

**Typ zwracany**

- \<<void\>>

### Usuwanie pracownika po id - RemoveEmployeeById()

**Parametry**

- id \<<int\>>

**Typ zwracany**

- \<<void\>>

### Usuwanie pracownika po imieniu - RemoveEmployeeByFirstName()

**Parametry**

- firstName \<<string\>>

**Typ zwracany**

- \<<void\>>

### Usuwanie pracownika po nazwisku - RemoveEmployeeByLastName()

**Parametry**

- lastName \<<string\>>

**Typ zwracany**

- \<<void\>>

### Usuwanie pracownika po hierarchii - RemoveEmployeeByLevel()

**Parametry**

- level \<<string\>>

**Typ zwracany**

- \<<void\>>

### Usuwanie wszystkich pracowników - RemoveAllEmployees()

**Parametry**

- \<<void\>>

**Typ zwracany**

- \<<void\>>

### Zwróć pracownika po id - GetEmployeeById()

**Parametry**

- id \<<int\>>

**Typ zwracany**

- \<<Employee\>>

### Zwróć pracownika ze specyficznym HierarchyID - GetEmployeeByLevel()

**Parametry**

- level \<<string\>>

**Typ zwracany**

- \<<Employee\>>

### Zwróć pracownika po imieniu - GetEmployeeByFirstName()

**Parametry**

- firstName \<<string\>>

**Typ zwracany**

- \<<Employee\>>

### Zwróć pracownika po nazwisku - GetEmployeeByLastName()

**Parametry**

- lastName \<<string\>>

**Typ zwracany**

- \<<Employee\>>

### Zwróć pracownika ze specyficznym HierarchyID wraz z jego podwładnymi - GetEmployeeWithSubordinates()

**Parametry**

- level \<<string\>>

**Typ zwracany**

- \<<List<Employee\>>>

### Zwróć wszystkich pracowników - GetAllEmployees()

**Parametry**

- \<<void\>>

**Typ zwracany**

- \<<List<Employee\>>>

### Zwróć najwyższe wynagrodzenie - GetMaxSalary()

**Parametry**

- \<<void\>>

**Typ zwracany**

- salary \<<int\>>

### Zwróć średnie wynagrodzenie - GetAverageSalary()

**Parametry**

- \<<void\>>

**Typ zwracany**

- salary \<<int\>>

## 4. Opis implementacji

**CMAPI** udostępnia procedury wykonujące operacje na rekordach tabeli pracowników (Employee) w bazie danych. Do zaimplementowania wykorzystałem klasy w języku **C#**, które wykonują **zapytania SQL** do bazy danych, które uruchamiają żądane **procedury**. W procedurach wykonywane są instrukcje SQL, które korzystają m. in. z typu **hierarchyid**.

Wszystkie funkcje są dostępne z poziomu interaktywnej konsolowej aplikacji **(demo)**, przyjmującej input od użytkownika, który decyduje co chce zrobić. Jest to przykład implementacji API w działającej aplikacji - funkcje można wdrożyć również do istniejącego wcześniej systemu.

![console_app](https://github.com/nerooc/company-api/blob/main/docs/console_app1.png)

## 5. Przykładowe dane

W ramach aplikacji demonstrującej działanie **CMAPI**, możemy do bazy dodać gotowe przykładowe dane - są to testowe dane firmy, która korzysta z **hierarchicznej** struktury danych. **Zbieżność imion i nazwisk jest przypadkowa.**

![example_data](https://github.com/nerooc/company-api/blob/main/docs/test_data_tree.png)

## 6. Prezentacja testów jednostkowych

Do testowania **CMAPI** wykorzystałem narzędzia do testowania udostępnione przez **Visual Studio**. W projekcie testowym, na przykładowych danych przetestowane zostały wszystkie metody wykorzystane w API, poniżej przedstawiam wyniki przeprowadzonych testów.

![unit_tests](https://github.com/nerooc/company-api/blob/main/docs/api_testing_results.png)

## 7. Podsumowanie

Typ **hierarchyid** zdaje się być bardzo dobrą opcją do przetwarzania danych hierarchicznych - jest szybki i łatwy w użyciu. Oprócz tego, udostępnia również wiele pomocnicznych funkcji (takich jak IsDescendantOf), które są bardzo przydatne, a musiałyby być dodatkowo zaimplementowane w przypadku własnoręcznego rozwiązania problemów tego typu.

Z drugiej strony, wsparcie C# dla hierarchyid nie jest pełne - przykładem może być konieczność ciągłego parsowania typu danych z **SqlHierarchyId** do **string,** by mogły one zostać przetworzone przez bazę danych. Słyszałem również że wydajność **hierarchyid** w bazach większego kalibru potrafi być nieakceptowalna - jednak w przypadku małych baz, może nadać się idealnie.

## 8. Literatura

Do stworzenia projektu wykorzystałem głównie **oficjalną dokumentację Microsoftu**, oraz pomniejsze strony służące jako poradniki do obsługi typu **hierarchyid**:

- https://codingsight.com/how-to-use-sql-server-hierarchyid-through-easy-examples/
- https://docs.microsoft.com/en-us/sql/t-sql/data-types/hierarchyid-data-type-method-reference?view=sql-server-ver15
- https://docs.microsoft.com/en-us/dotnet/csharp/
- https://docs.microsoft.com/en-us/sql/relational-databases/tables/tutorial-using-the-hierarchyid-data-type?view=sql-server-ver15
- https://www.sqlshack.com/use-hierarchyid-sql-server/

## 9. Kod źródłowy

Kod źródłowy wszystkich skryptów T-SQL wykorzystanych w projekcie znajduje się w folderze o nazwie “**dbsetup**”. Znajdują się tam skrypty dotyczące **tworzenia bazy, tabeli Employee, dodawania i usuwania potrzebnych procedur** oraz pomniejszych skryptów służących do testowania aktualnego stanu bazy danych.
