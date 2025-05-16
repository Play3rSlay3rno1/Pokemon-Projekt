




//Fangsystem mit Fangchance (Pokémon fangen Chance berechnen nach KP)

//Trainerkämpfe (Zwei Trainerkämpfe auf dem Weg in die erste Stadt mit jeweils 1 Pokemon)

//Arenakampf erste Arena (Zwei Trainer mit 2 Pokemon und Arenaleiter mit 3 Pokemon)
//4. Welt & Navigation
//Orte: Startstadt, Route, Arena-Stadt (Anfangsstadt, Route 1, Zweite Stadt Arena)
//Poke-Center & Markt (Auswahlkriterien für die zweite Stadt)
//Nebenmissionen (z.B. Items sammeln, Pokémon fangen)

//Pokedollar als Währung (Startguthaben und Geld verdienen durch Kämpfe)

//Teamverwaltung (Zwei Pokemon fangen vor der Arena und ein Team aus 3 besitzen)
//Laufweg und Laufrichtung (Gras betreten, Trainer treffen, Items finden)



using System;

namespace PokemonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pokemon ROM by PeacePaddy";
            Spieler spieler;

            Console.WriteLine("Willkommen in der Pokémon-Welt!");
            Console.WriteLine("1 = Neues Spiel starten");
            Console.WriteLine("2 = Spielstand laden");
            string auswahl = Console.ReadLine() ?? "";

            if (auswahl == "2")
            {
                spieler = SpeicherSystem.Laden();
                if (spieler == null)
                {
                    Console.WriteLine("⚠️ Kein Spielstand gefunden. Neues Spiel wird gestartet.");
                    Console.ReadKey();
                    spieler = StarteNeuesSpiel();
                }
            }
            else
            {
                spieler = StarteNeuesSpiel();
            }

            // Route 1 starten
            Route1 route1 = new Route1(spieler);
            route1.StarteRoute();

            Console.WriteLine("Route 1 abgeschlossen – du erreichst die Stadt!");
            Console.ReadKey();

            // Stadt betreten
            ErsteStadt stadt = new ErsteStadt(spieler);
            stadt.BetreteStadt();

            // Spiel speichern
            SpeicherSystem.Speichern(spieler);
            Console.WriteLine("Spielstand gespeichert. Danke fürs Spielen!");
            Console.ReadKey();
        }

        static Spieler StarteNeuesSpiel()
        {
            Console.Clear();
            Console.WriteLine("Bist du ein Junge oder ein Mädchen?");
            string geschlecht = Console.ReadLine() ?? "";
            Console.Clear();

            Console.WriteLine("Wie heißt du?");
            string spielerName = Console.ReadLine() ?? "";
            Console.Clear();

            Console.WriteLine("Dies ist mein Neffe, er wird dein Rivale sein, wie hieß er noch gleich?");
            string rivalenName = Console.ReadLine() ?? "";
            Console.Clear();

            Console.WriteLine($"Du bist ein {geschlecht} und heißt {spielerName}.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Dein Rivale heißt {rivalenName}.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"\nHallo {spielerName}! Dein Abenteuer beginnt jetzt!");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Du wachst auf und siehst deinen Rivalen {rivalenName} in deinem Zimmer.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"{rivalenName}: \"Hey {spielerName}, komm schon! Heute bekommen wir unser erstes Pokémon!\"");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Du verlässt dein Zimmer und gehst nach unten.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Deine Mutter sagt: \"Guten Morgen {spielerName}! Du bist spät dran!\"");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Deine Mutter gibt dir eine Tasche mit 5 Tränken.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Du gehst nach draußen und begleitest deinen Rivalen {rivalenName} zum Pokémon-Professor.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Professor Eich: \"Hallo {spielerName}! Ich bin Professor Eich!\"");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Der Professor erklärt dir die Pokémon-Welt und gibt dir die Wahl zwischen 3 Pokémon.");

            var starterListe = new List<Pokemon>
            {
                new Pokemon("Bisasam", "Pflanze", 5, 45, 10, 8, new List<Attacke>
                {
                    new Attacke("Tackle", "Normal", 10),
                    new Attacke("Rankenhieb", "Pflanze", 12)
                }),
                new Pokemon("Schiggy", "Wasser", 5, 44, 9, 10, new List<Attacke>
                {
                    new Attacke("Tackle", "Normal", 10),
                    new Attacke("Aquaknarre", "Wasser", 12)
                }),
                new Pokemon("Glumanda", "Feuer", 5, 39, 12, 6, new List<Attacke>
                {
                    new Attacke("Kratzer", "Normal", 10),
                    new Attacke("Glut", "Feuer", 14)
                })
            };

            int auswahl = 0;
            while (auswahl < 1 || auswahl > 3)
            {
                Console.WriteLine("Welches Pokémon möchtest du wählen?");
                Console.WriteLine("1 = Bisasam, 2 = Schiggy, 3 = Glumanda");
                string eingabe = Console.ReadLine() ?? "";
                Console.Clear();
                bool istZahl = int.TryParse(eingabe, out auswahl);
                if (!istZahl || auswahl < 1 || auswahl > 3)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl zwischen 1 und 3 ein.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Pokemon spielerStarter = starterListe[auswahl - 1];
            Spieler spieler = new Spieler(spielerName, spielerStarter);
            
            List<Pokemon> rivalenOptionen = starterListe.FindAll(p => p != spielerStarter);
            Pokemon rivalenStarter = rivalenOptionen[new Random().Next(rivalenOptionen.Count)];

            Console.Clear();
            Console.WriteLine($"\nDu hast {spielerStarter.Name} gewählt!");
            Console.WriteLine($"{rivalenName} hat {rivalenStarter.Name} gewählt!");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"{rivalenName} fordert dich zu einem Kampf heraus!");
            Console.ReadKey();
            Console.Clear();

            KampfSystem kampf = new KampfSystem(spieler.Team[0], rivalenStarter, spieler.Name, rivalenName, spieler.Tasche);
            kampf.StarteKampf();

            SpeicherSystem.Speichern(spieler);

            Console.WriteLine("Nach dem Kampf tritt der Professor an dich heran und sagt:");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"\nHerzlichen Glückwunsch {spieler.Name} zu deinem ersten Kampf!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Der Professor gibt dir 5 Pokébälle.");
            spieler.Tasche.PokeballAnzahl += 5;
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Du verlässt das Labor und gehst nach Norden zu Route 1.");
            Console.ReadKey();
            Console.Clear();

            return spieler;
        }
    }
}


















































































