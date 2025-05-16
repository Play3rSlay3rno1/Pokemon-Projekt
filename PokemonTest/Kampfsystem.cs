
//3. Kampf-System
public class KampfSystem
{
    public Pokemon spieler;
    public Pokemon gegner;
    public string spielerName;
    public string gegnerName;
    public Tasche tasche;



    public KampfSystem(Pokemon spieler, Pokemon gegner, string spielerName, string gegnerName, Tasche tasche)
    {
        this.spieler = spieler;
        this.gegner = gegner;
        this.spielerName = spielerName;
        this.gegnerName = gegnerName;
        this.tasche = tasche;
    }

    public void StarteKampf()
    {
        Console.WriteLine("\nEin Kampf beginnt!");
        Console.ReadKey();
        Console.Clear();

        bool spielerDran = true;
        Random rnd = new Random();

        while (spieler.KP > 0 && gegner.KP > 0)
        {
            if (spielerDran)
            {
                
                if (spieler.KP < spieler.MaxKP / 2 && tasche.TrankAnzahl > 5)
                {
                    Console.WriteLine($"{spielerName} verwendet einen Trank!");
                    tasche.BenutzeTrank(spieler);
                    Console.ReadKey();
                }

                
                Attacke attacke = spieler.Attacken[rnd.Next(spieler.Attacken.Count)];
                FuehreAngriffAus(spieler, gegner, attacke);
            }
            else
            {
                
                Attacke attacke = gegner.Attacken[rnd.Next(gegner.Attacken.Count)];
                FuehreAngriffAus(gegner, spieler, attacke);
            }

            spielerDran = !spielerDran;
        }

        Console.Clear();
        if (spieler.KP > 0)
        {
            Console.WriteLine($"Herzlichen Glückwunsch, {spielerName}! Du hast den Kampf gewonnen!");

            int ep = gegner.Level * 10;
            Console.WriteLine($"{spieler.Name} erhält {ep} EP!");
            spieler.ErhalteErfahrung(ep);
        }
        else
        {
            Console.WriteLine($"{gegnerName} hat den Kampf gewonnen. Dein Pokémon wird vollständig geheilt!");
            spieler.KP = spieler.MaxKP;
        }

    }
    //Typenstärken/-schwächen (Typenberechnung bei Kämpfen)
    private void FuehreAngriffAus(Pokemon angreifer, Pokemon verteidiger, Attacke attacke)
    {
        double effektivitaet = BerechneTypEffektivitaet(attacke.Typ, verteidiger.Typ);
        int schaden = (int)((attacke.Schaden + angreifer.AngriffsWert - verteidiger.VerteidigungsWert) * effektivitaet);
        if (schaden < 0) schaden = 0;

        verteidiger.KP -= schaden;
        if (verteidiger.KP < 0) verteidiger.KP = 0;

        Console.WriteLine($"{angreifer.Name} setzt {attacke.Name} ein!");
        if (effektivitaet > 1.0)
            Console.WriteLine("Es ist sehr effektiv!");
        else if (effektivitaet < 1.0)
            Console.WriteLine("Es ist nicht sehr effektiv...");
        Console.WriteLine($"{verteidiger.Name} erleidet {schaden} Schaden. Verbleibende KP: {verteidiger.KP}");
        Console.WriteLine();
        Console.ReadKey();
    }

    private double BerechneTypEffektivitaet(string attackeTyp, string verteidigerTyp)
    {
        if (attackeTyp == "Feuer" && verteidigerTyp == "Pflanze") return 2.0;
        if (attackeTyp == "Feuer" && verteidigerTyp == "Wasser") return 0.5;
        if (attackeTyp == "Wasser" && verteidigerTyp == "Feuer") return 2.0;
        if (attackeTyp == "Wasser" && verteidigerTyp == "Pflanze") return 0.5;
        if (attackeTyp == "Pflanze" && verteidigerTyp == "Wasser") return 2.0;
        if (attackeTyp == "Pflanze" && verteidigerTyp == "Feuer") return 0.5;
        if (attackeTyp == "Normal" && verteidigerTyp == "Gestein") return 0.5;
        if (attackeTyp == "Feuer" && verteidigerTyp == "Gestein") return 0.5;
        if (attackeTyp == "Gestein" && verteidigerTyp == "Feuer") return 2.0;
        if (attackeTyp == "Wasser" && verteidigerTyp == "Gestein") return 2.0;
        if (attackeTyp == "Pflanze" && verteidigerTyp == "Gestein") return 2.0;


        return 1.0;
    }
}



