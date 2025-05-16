public class ArenaAzuria
{
    public Spieler spieler;

    public ArenaAzuria(Spieler spieler)
    {
        this.spieler = spieler;
    }

    public void BetreteArena()
    {
        Console.Clear();
        Console.WriteLine("Du betrittst die Arena von Azuria City!");
        Console.WriteLine("Ein Trainer stellt sich dir in den Weg!");
        Console.ReadKey();

        if (!StarteTrainerkampf())
        {
            Console.WriteLine("Du wurdest vom Trainer besiegt. Kehre später zurück.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Du hast den Trainer besiegt und gehst weiter zum Arenaleiter!");
        Console.ReadKey();
        Console.Clear();

        StarteArenaleiterkampf();
    }

    private bool StarteTrainerkampf()
    {
        Pokemon trainerPokemon = new Pokemon("Kleinstein", "Gestein", 6, 40, 10, 10, new List<Attacke>
        {
            new Attacke("Tackle", "Normal", 10),
            new Attacke("Steinwurf", "Gestein", 12)
        });

        KampfSystem trainerKampf = new KampfSystem(spieler.Team[0], trainerPokemon, spieler.Name, "Trainer Max", spieler.Tasche);
        trainerKampf.StarteKampf();

        return !spieler.Team[0].IstBesiegt();
    }

    private void StarteArenaleiterkampf()
    {
        Pokemon arenaPokemon = new Pokemon("Onix", "Gestein", 8, 60, 14, 12, new List<Attacke>
        {
            new Attacke("Steinwurf", "Gestein", 15),
            new Attacke("Tackle", "Normal", 10)
        });

        KampfSystem arenaKampf = new KampfSystem(spieler.Team[0], arenaPokemon, spieler.Name, "Arenaleiter Rocko", spieler.Tasche);
        arenaKampf.StarteKampf();

        if (!arenaPokemon.IstBesiegt())
        {
            Console.WriteLine("Du hast die Arena leider verloren. Versuche es später erneut.");
        }
        else
        {
            Console.WriteLine("Glückwunsch! Du hast den ersten Arenaorden erhalten!");

            SpeicherSystem.Speichern(spieler);

        }

        Console.ReadKey();
    }
}
