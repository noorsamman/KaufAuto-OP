# KaufAuto OP – Autoverwaltung

Fahrzeugverwaltung für ein Autohaus in **C# / .NET Framework 4.8** – mit Konsolen-Version und grafischer Oberfläche (**Windows Forms**) mit dunklem Design.

## Funktionen

- Fahrzeuge (PKW, SUV, Transporter) **hinzufügen, bearbeiten, löschen**
- **Suche und Filter** nach Marke/Modell, Kraftstoff und Status
- **Vorschläge für Marke und Modell** passend zum Fahrzeugtyp (z. B. PKW → BMW → 3er)
- **Auto verkaufen** mit Käufer, Verkaufspreis, Rabatt und Datum
- **Finanzierungsrechner** (Anzahlung, Laufzeit, Zinssatz → Monatsrate)
- **Dashboard** mit Bestand, Bestandswert, Verkäufen und Umsatz
- Speichern und Laden als **JSON**, Nachfrage bei ungespeicherten Änderungen

## Aufbau

| Projekt | Inhalt |
|---|---|
| `KaufAuto` | Logik und Konsolen-Version: Modelle (`Auto`, `PKW`, `SUV`, `Transporter`), `AutoManager`, `SpeicherService`, `FinanzierungsService`, `FahrzeugKatalog` |
| `KaufAuto.GUI` | Windows-Forms-Oberfläche: Hauptfenster, Dialoge, eigene Controls (`ModernButton`, `KennzahlKarte`), zentrale Farben in `Design.cs` |

Verwendete Konzepte: Vererbung und Polymorphie (abstrakte Klasse `Auto`), Interfaces (`IAutoService`, `ISpeicherService`), Trennung von Logik und Oberfläche, LINQ, JSON-Serialisierung (Newtonsoft.Json).

## Starten

1. `KaufAuto OP.sln` in Visual Studio öffnen
2. Rechtsklick auf **KaufAuto.GUI** → *Als Startprojekt festlegen* (oder **KaufAuto** für die Konsole)
3. **F5** drücken – NuGet-Pakete werden automatisch wiederhergestellt

## Autor

Noureddin AlSamman – [github.com/noorsamman](https://github.com/noorsamman)
