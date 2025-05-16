public class Spieler
{
    public string Name { get; set; }
    public List<Pokemon> Team { get; set; }
    public Tasche Tasche { get; set; }
    public Spieler() { }


    public Spieler(string name, Pokemon starter)
    {
        Name = name;
        Team = new List<Pokemon> { starter };
        Tasche = new Tasche();
    }


    public bool FuegePokemonHinzu(Pokemon neuesPokemon)
    {
        if (Team.Count >= 6)
        {
            Console.WriteLine("Dein Team ist voll! Du kannst kein weiteres Pokémon aufnehmen.");
            return false;
        }

        Team.Add(neuesPokemon);
        Console.WriteLine($"{neuesPokemon.Name} wurde deinem Team hinzugefügt!");
        return true;
    }

    public void ZeigeTeam()
    {
        Console.WriteLine($"Team von {Name}:");
        for (int i = 0; i < Team.Count; i++)
        {
            var p = Team[i];
            Console.WriteLine($"{i + 1}. {p.Name} (Level {p.Level}, KP: {p.KP}/{p.MaxKP})");
        }
    }
}
