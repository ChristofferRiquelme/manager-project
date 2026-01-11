# CManager

CManager är ett kundhanteringssystem byggt i C# som körs som en konsolapplikation.
Applikationen gör det möjligt att skapa, visa och ta bort kunder. Kunddata lagras lokalt i en JSON-fil.

---

## Funktionalitet

- Skapa ny kund med:
  - Förnamn
  - Efternamn
  - E-postadress
  - Telefonnummer
  - Adress (gatuadress, postnummer, ort)
- Visa alla kunder (namn och e-post)
- Visa specifik kund baserat på e-post
- Ta bort kund baserat på e-post
- Lagring av kunddata i JSON-format

---

## Projektstruktur

Applikationen är uppbyggd enligt en lagerbaserad arkitektur (N-tier):

- **CManager.Presentation.ConsoleApp** – Konsolapplikation (meny och användarinteraktion)
- **CManager.Application** – Affärslogik och interfaces
- **CManager.Domain** – Domänmodeller (Customer, Address)
- **CManager.Infrastructure** – Filbaserad lagring (JSON)
- **CManager.Tests** – Enhetstester

---

## Arkitektur & principer

- Separation of Concerns
- Dependency Inversion Principle (SOLID)
- Repository- och Service-mönster
- Interface-baserad design

---

## Enhetstester

Projektet innehåller ett enhetstest för `CustomerService` där repository mockas med Moq.
Testerna körs med xUnit.

---

## Kom igång

### Krav
- .NET SDK 8.0 eller senare
- macOS / Linux / Windows
- VS Code + terminal

### Köra applikationen

Från solution-mappen:

```bash
dotnet build
dotnet run --project CManager.Presentation.ConsoleApp