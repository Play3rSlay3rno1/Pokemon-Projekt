
public class ErsteStadt
{
    public Spieler spieler;


    public void BetreteStadt()
    {
        Console.Clear();
        Console.WriteLine("Willkommen in Azuria City!");
        Console.WriteLine("Hier gibt es ein Pokémon-Center, einen Pokémon-Markt und die erste Arena.");
        Console.ReadKey();

        bool inStadt = true;
        while (inStadt)
        {
            Console.Clear();
            Console.WriteLine("Was möchtest du tun?");
            Console.WriteLine("1 = Pokémon-Center besuchen");
            Console.WriteLine("2 = Pokémon-Markt besuchen");
            Console.WriteLine("3 = Arena herausfordern");
            Console.WriteLine("4 = Stadt verlassen");

            string eingabe = Console.ReadLine() ?? "";

            switch (eingabe)
            {
                case "1":
                    BesuchePokemonCenter();
                    break;
                case "2":
                    BesuchePokemonMarkt();
                    break;
                case "3":
                    BetreteArena();
                    break;
                case "4":
                    inStadt = false;
                    Console.WriteLine("Du verlässt die Stadt.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public ErsteStadt(Spieler spieler)
    {
        this.spieler = spieler;
    }
    public void BetreteArena()
    {
        ArenaAzuria arena = new ArenaAzuria(spieler);
        arena.BetreteArena();
    }


    private void BesuchePokemonCenter()
    {
        Console.Clear();
        Console.WriteLine("Schwester Joy: Willkommen im Pokémon-Center!");
        foreach (var p in spieler.Team)
        {
            p.KP = p.MaxKP;
        }
        Console.WriteLine("Deine Pokémon wurden vollständig geheilt!");
        Console.ReadKey();
    }

    private void BesuchePokemonMarkt()
    {
        Console.Clear();
        Console.WriteLine("Willkommen im Pokémon-Markt!");
        Console.WriteLine("1 = Trank kaufen (1 Stück)");
        Console.WriteLine("2 = Pokéball kaufen (1 Stück)");
        Console.WriteLine("3 = Zurück");

        string eingabe = Console.ReadLine() ?? "";

        switch (eingabe)
        {
            case "1":
                spieler.Tasche.TrankAnzahl++;
                Console.WriteLine("Du hast einen Trank gekauft.");
                break;
            case "2":
                spieler.Tasche.PokeballAnzahl++;
                Console.WriteLine("Du hast einen Pokéball gekauft.");
                break;
            default:
                Console.WriteLine("Du verlässt den Markt.");
                break;
        }
        Console.ReadKey();
    }
}

