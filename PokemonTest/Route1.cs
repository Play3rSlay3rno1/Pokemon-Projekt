
//Route 1 mit Trainerkämpfen und Wilden Pokemonbegegnungen

public class Route1
{
    public Spieler spieler;
    public Random zufall = new Random();

    public Route1(Spieler spieler)
    {
        this.spieler = spieler;
    }

    public void StarteRoute()
    {
        Console.WriteLine("Du betrittst Route 1. Der Weg teilt sich mehrfach...");
        Console.ReadKey();
        Console.Clear();

        int trainerKaempfe = 0;
        int pokemonBegegnungen = 0;
        int abzweigung = 1;
        int maxVersuche = 10;
        int versuche = 0;

        while ((trainerKaempfe < 2 || pokemonBegegnungen < 2) && versuche < maxVersuche)
        {
            versuche++;

            Console.WriteLine($"Abzweigung {abzweigung}: Möchtest du nach links oder rechts gehen?");
            string richtung = "";

            while (richtung != "links" && richtung != "rechts")
            {
                Console.Write("Gib 'links' oder 'rechts' ein: ");
                richtung = Console.ReadLine()?.ToLower() ?? "";
            }

            Console.Clear();
            Console.WriteLine($"Du gehst nach {richtung}...");
            Console.ReadKey();
            Console.Clear();

            bool istTrainerkampf = zufall.Next(2) == 0;

            if (istTrainerkampf && trainerKaempfe < 2)
            {
                StarteTrainerkampf(richtung);
                trainerKaempfe++;
            }
            else if (!istTrainerkampf && pokemonBegegnungen < 2)
            {
                StarteWildPokemonBegegnung(richtung);
                pokemonBegegnungen++;
            }
            else
            {
                if (trainerKaempfe < 2)
                {
                    StarteTrainerkampf(richtung);
                    trainerKaempfe++;
                }
                else if (pokemonBegegnungen < 2)
                {
                    StarteWildPokemonBegegnung(richtung);
                    pokemonBegegnungen++;
                }
            }

            abzweigung++;
        }

        if (trainerKaempfe >= 2 && pokemonBegegnungen >= 2)
        {
            Console.WriteLine("Du hast Route 1 erfolgreich durchquert!");
        }
        else
        {
            Console.WriteLine("Du konntest Route 1 nicht vollständig abschließen. Bitte versuche es erneut.");
        }

        Console.ReadKey();
        Console.Clear();
    }

    private void StarteTrainerkampf(string richtung)
    {
        var trainerListe = new List<(string Name, Pokemon Pokemon)>
        {
            ("Trainer Tim", new Pokemon("Rattfratz", "Normal", 4, 30, 8, 6, new List<Attacke> { new Attacke("Tackle", "Normal", 10) })),
            ("Trainerin Lisa", new Pokemon("Mauzi", "Normal", 5, 32, 9, 7, new List<Attacke> { new Attacke("Kratzer", "Normal", 11) })),
            ("Trainer Ben", new Pokemon("Zubat", "Gift/Flug", 4, 28, 7, 8, new List<Attacke> { new Attacke("Biss", "Unlicht", 10) })),
            ("Trainerin Mia", new Pokemon("Pummeluff", "Normal", 5, 35, 6, 5, new List<Attacke> { new Attacke("Pfund", "Normal", 9) }))
        };

        var trainer = trainerListe[zufall.Next(trainerListe.Count)];

        Console.WriteLine($"Ein {trainer.Name} erscheint auf dem {richtung}-Pfad mit einem {trainer.Pokemon.Name}!");
        Console.ReadKey();
        Console.Clear();

        KampfSystem kampf = new KampfSystem(spieler.Team[0], trainer.Pokemon, spieler.Name, trainer.Name, spieler.Tasche);
        kampf.StarteKampf();
    }

    private void StarteWildPokemonBegegnung(string richtung)
    {
        var moeglicheWildePokemon = new List<Pokemon>
        {
            new Pokemon("Taubsi", "Normal", 3, 28, 7, 5, new List<Attacke> { new Attacke("Schnabel", "Normal", 9) }),
            new Pokemon("Rattfratz", "Normal", 3, 26, 8, 6, new List<Attacke> { new Attacke("Tackle", "Normal", 10) }),
            new Pokemon("Hornliu", "Käfer", 3, 25, 6, 4, new List<Attacke> { new Attacke("Fadenschuss", "Käfer", 5) }),
            new Pokemon("Raupy", "Käfer", 3, 24, 5, 5, new List<Attacke> { new Attacke("Tackle", "Normal", 8) })
        };

        Pokemon wildesPokemon = moeglicheWildePokemon[zufall.Next(moeglicheWildePokemon.Count)];

        Console.WriteLine($"Im hohen Gras auf dem {richtung}-Pfad erscheint ein wildes {wildesPokemon.Name}!");
        Console.ReadKey();

        KampfSystem kampf = new KampfSystem(spieler.Team[0], wildesPokemon, spieler.Name, "Wildes Pokémon", spieler.Tasche);
        kampf.StarteKampf();

        int ep = wildesPokemon.Level * 5;
        Console.WriteLine($"{spieler.Team[0].Name} erhält {ep} EP!");
        spieler.Team[0].ErhalteErfahrung(ep);

        Console.WriteLine($"Möchtest du versuchen, {wildesPokemon.Name} zu fangen? (ja/nein)");
        string antwort = Console.ReadLine()?.ToLower() ?? "";

        if (antwort == "ja")
        {
            int versuche = 0;
            bool gefangen = false;

            while (versuche < 3 && !gefangen && spieler.Tasche.PokeballAnzahl > 0)
            {
                versuche++;
                Console.WriteLine($"Fangversuch {versuche}...");

                if (spieler.Tasche.BenutzePokeball())
                {
                    int fangChance = wildesPokemon.IstBesiegt() ? 80 : 20 + (int)((1 - (double)wildesPokemon.KP / wildesPokemon.MaxKP) * 60);
                    gefangen = zufall.Next(100) < fangChance;

                    if (gefangen)
                    {
                        Console.WriteLine($"Du hast {wildesPokemon.Name} erfolgreich gefangen!");
                        spieler.FuegePokemonHinzu(wildesPokemon);

                        int fangEp = wildesPokemon.Level * 3;
                        Console.WriteLine($"{spieler.Team[0].Name} erhält {fangEp} EP für das Fangen von {wildesPokemon.Name}!");
                        spieler.Team[0].ErhalteErfahrung(fangEp);

                        SpeicherSystem.Speichern(spieler);

                    }
                    else
                    {
                        Console.WriteLine($"{wildesPokemon.Name} konnte nicht gefangen werden.");
                    }
                }
            }

            if (!gefangen)
            {
                Console.WriteLine($"{wildesPokemon.Name} ist entkommen.");
            }
        }
        else
        {
            Console.WriteLine($"Du hast dich entschieden, {wildesPokemon.Name} nicht zu fangen.");
        }

        Console.ReadKey();
        Console.Clear();
    }
}
