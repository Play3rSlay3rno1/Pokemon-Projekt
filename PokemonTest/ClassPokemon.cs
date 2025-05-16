
//2. Pokémon-System
//Pokémon-Klasse mit Typ, Level, KP, Attacken (Name, Attaken, Level, Kraftpunkte)
public class Pokemon
{
    public string Name { get; set; }
    public string Typ { get; set; }
    public int Level { get; set; }
    public int KP { get; set; }
    public int MaxKP { get; set; }
    public int AngriffsWert { get; set; }
    public int VerteidigungsWert { get; set; }
    public List<Attacke> Attacken { get; set; }
    public int Erfahrung { get; set; }

    public Pokemon() { }

    public Pokemon(string name, string typ, int level, int kp, int angriff, int verteidigung, List<Attacke> attacken)
    {
        Name = name;
        Typ = typ;
        Level = level;
        MaxKP = kp;
        KP = kp;
        AngriffsWert = angriff;
        VerteidigungsWert = verteidigung;
        Attacken = attacken;
        Erfahrung = 0;
    }

    public void GreifeAn(Pokemon ziel, Attacke attacke)
    {
        int schaden = attacke.Schaden + AngriffsWert - ziel.VerteidigungsWert;
        if (schaden < 0) schaden = 0;

        ziel.KP -= schaden;
        if (ziel.KP < 0) ziel.KP = 0;

        Console.WriteLine($"{Name} greift {ziel.Name} mit {attacke.Name} an und verursacht {schaden} Schaden!");
        Console.WriteLine($"{ziel.Name} hat noch {ziel.KP} KP.");
    }

    public void ErhalteErfahrung(int ep)
    {
        Erfahrung += ep;
        int epFürLevelUp = Level * 10;

        while (Erfahrung >= epFürLevelUp)
        {
            Erfahrung -= epFürLevelUp;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        MaxKP += 5;
        AngriffsWert += 2;
        VerteidigungsWert += 2;
        KP = MaxKP;

        Console.WriteLine($"{Name} erreicht Level {Level}!");
        Console.WriteLine($"KP: {MaxKP}, Angriff: {AngriffsWert}, Verteidigung: {VerteidigungsWert}");
    }

    public bool IstBesiegt()
    {
        return KP <= 0;
    }
}
