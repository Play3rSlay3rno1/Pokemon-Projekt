
//5. Inventar & Wirtschaft (Tasche mit 3 Fächern)
//Items (Pokébälle, Tränke)

public class Tasche
{
    public int PokeballAnzahl { get; set; }
    public int TrankAnzahl { get; set; }
    public Tasche() { }
    public Tasche(int pokeballAnzahl = 5, int trankAnzahl = 5)
    {
        PokeballAnzahl = pokeballAnzahl;
        TrankAnzahl = trankAnzahl;
    }

    public void BenutzeTrank(Pokemon ziel)
    {
        if (TrankAnzahl > 0)
        {
            int heilung = 30;
            ziel.KP += heilung;
            if (ziel.KP > ziel.MaxKP) ziel.KP = ziel.MaxKP;

            TrankAnzahl--;
            Console.WriteLine($"{ziel.Name} wurde um {heilung} KP geheilt. Verbleibende Tränke: {TrankAnzahl}");
        }
        else
        {
            Console.WriteLine("Du hast keine Tränke mehr!");
        }
    }

    public bool BenutzePokeball()
    {
        if (PokeballAnzahl > 0)
        {
            PokeballAnzahl--;
            Console.WriteLine($"Du wirfst einen Pokéball! Verbleibende Pokébälle: {PokeballAnzahl}");
            return true;
        }
        else
        {
            Console.WriteLine("Du hast keine Pokébälle mehr!");
            return false;
        }
    }

    public void ZeigeInventar()
    {
        Console.WriteLine($"Inventar: {TrankAnzahl} Tränke, {PokeballAnzahl} Pokébälle");
    }
}
