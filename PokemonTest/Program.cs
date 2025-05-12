
//Anforderungen und Ideen für das Spiel

//2. Pokémon-System
//Pokémon-Klasse mit Typ, Level, KP, Attacken (Name, Attaken, Level, Kraftpunkte)
//Typenstärken/-schwächen (Typenberechnung bei Kämpfen)
//Fangsystem mit Fangchance (Pokémon fangen Chance berechnen nach KP)
//3. Kampf-System
//Trainerkämpfe (Zwei Trainerkämpfe auf dem Weg in die erste Stadt mit jeweils 1 Pokemon)
//Rivalenkämpfe (Erster Kampf nach Starterauswahl, zweiter Kampf vor der Arena)
//Arenakampf erste Arena (Zwei Trainer mit 2 Pokemon und Arenaleiter mit 3 Pokemon)
//4. Welt & Navigation
//Orte: Startstadt, Route, Arena-Stadt (Anfangsstadt, Route 1, Zweite Stadt Arena)
//Poke-Center & Markt (Auswahlkriterien für die zweite Stadt)
//Nebenmissionen (z.B. Items sammeln, Pokémon fangen)
//5. Inventar & Wirtschaft (Tasche mit 3 Fächern)
//Pokedollar als Währung (Startguthaben und Geld verdienen durch Kämpfe)
//Items (Pokébälle, Tränke
//Teamverwaltung (Zwei Pokemon fangen vor der Arena und ein Team aus 3 besitzen)
//Laufweg und Laufrichtung (Gras betreten, Trainer treffen, Items finden)
//Informationsbeschaffung

using System;
using System.Collections.Generic;

namespace PokemonTest
{
    class Program
    {
        //Einstieg & Charaktererstellung (Begrüßung und Abfrage ob Junge oder Mädchen)
        //Spielername (Spierlname eingabe)
        //Rivalenname (Rivalenname eingabe)
        static void Main(string[] args)
        {
            Console.Title = "Pokemon ROM by PeacePaddy";
            Console.WriteLine("Willkommen in der Pokemon-Welt!");

            
            Console.WriteLine("Bist du ein Junge oder ein Mädchen?");
            string geschlecht = Console.ReadLine() ?? "";

            Console.WriteLine("Wie heißt du?");
            string spielerName = Console.ReadLine() ?? "";

            Console.WriteLine("Dies ist mein Neffe, wie hieß er noch gleich?");
            string rivalenName = Console.ReadLine() ?? "";

            Console.WriteLine("Du bist ein " + geschlecht + " und heißt " + spielerName + ".");
            Console.WriteLine("Dein Rivale heißt " + rivalenName + ".");
            Console.WriteLine("Du bist ein Trainer und möchtest Pokemon fangen.");
            Console.WriteLine($"\nHallo {spielerName}! Dein Abenteuer beginnt jetzt!");

            
            Console.WriteLine("Du wachst auf und siehst deinen Rivalen " + rivalenName + " in deinem Zimmer.");
            Console.WriteLine(rivalenName + ": \"Hey " + spielerName + ", komm schon heute bekommen wir unser erstes Pokemon!\"");
            Console.WriteLine("Du verlässt dein Zimmer und gehst nach unten.");
            Console.WriteLine("Deine Mutter sagt: \"Guten Morgen " + spielerName + "! Du bist spät dran!\"");
            Console.WriteLine("Du gehst nach draußen und begleitest deinen Rivalen " + rivalenName + " zum Pokemon-Professor.");
            Console.WriteLine("Der Professor sagt: \"Hallo " + spielerName + "! Ich bin Professor Eich!\"");
            Console.WriteLine("Der Professor erklärt dir die Pokemon-Welt und gibt dir die Wahl zwischen 3 Pokemon.");

            
            //Auswahl des Starter-Pokémon (Auswahl zwischen 3 Pokémon)
            List<Pokemon> starterListe = new List<Pokemon>
            {
                new Pokemon("Bisasam", "Pflanze", 5, 45),
                new Pokemon("Schiggy", "Wasser", 5, 44),
                new Pokemon("Glumanda", "Feuer", 5, 39)
            };

            
            int auswahl = 0;
            while (auswahl < 1 || auswahl > 3)
            {
                Console.WriteLine("Welches Pokemon möchtest du wählen?");
                Console.WriteLine("1 = Bisasam, 2 = Schiggy, 3 = Glumanda");
                string eingabe = Console.ReadLine()??"";

                bool istZahl = int.TryParse(eingabe, out auswahl);
                if (!istZahl || auswahl < 1 || auswahl > 3)
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte gib eine Zahl zwischen 1 und 3 ein.");
                }
            }

          
            Pokemon spielerStarter = starterListe[auswahl - 1];

            List<Pokemon> rivalenOptionen = new List<Pokemon>();
            foreach (Pokemon p in starterListe)
            {
                if (p != spielerStarter)
                {
                    rivalenOptionen.Add(p);
                }
            }
            //Zufälliger Auswahl derübrigen Pokemon für den Rivalen (Copilot-Unterstützung)
            Random zufall = new Random();
            int zufallsIndex = zufall.Next(rivalenOptionen.Count);
            Pokemon rivalenStarter = rivalenOptionen[zufallsIndex];


            Console.WriteLine($"\nDu hast {spielerStarter.Name} gewählt!");
            Console.WriteLine($"{rivalenName} hat {rivalenStarter.Name} gewählt!");
        }
    }
 }          





















































