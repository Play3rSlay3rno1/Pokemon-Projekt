using System;
using System.IO;
using System.Text.Json;

public static class SpeicherSystem
{
    public static readonly string StandardPfad = "spielstand.json";

    public static void Speichern(Spieler spieler, string pfad = null)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(spieler, options);
            File.WriteAllText(pfad ?? StandardPfad, json);
            Console.WriteLine("Spielstand wurde erfolgreich gespeichert.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
        }
    }

    public static Spieler Laden(string pfad = null)
    {
        try
        {
            string dateipfad = pfad ?? StandardPfad;

            if (!File.Exists(dateipfad))
            {
                Console.WriteLine("Kein Spielstand gefunden.");
                return null;
            }

            string json = File.ReadAllText(dateipfad);
            Spieler spieler = JsonSerializer.Deserialize<Spieler>(json);
            Console.WriteLine("Spielstand erfolgreich geladen.");
            return spieler;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Fehler beim Laden: {ex.Message}");
            return null;
        }
    }
}
