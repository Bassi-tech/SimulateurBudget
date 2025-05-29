# SimulateurBudget

Simulateur de budget personnel en WPF (.NET 7 / C#)

## Fonctionnalités
- Ajout / modification / suppression de transactions
- Persistance JSON
- Interface MVVM (DatePicker, ComboBox éditable, DataGrid)
- Export Excel via ClosedXML avec auto‐fit
- …

## Installation
```bash
git clone https://github.com/tonPseudo/BudgetSimulator.git
cd BudgetSimulator
dotnet publish -c Release -r win-x64 --self-contained true -o ./publish

## Installation
Double-cliquez sur publish/BudgetSimulator.exe

Tech Stack
C# · WPF · MVVM · JSON · ClosedXML