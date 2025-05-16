public class Attacke
{
    public string Name { get; set; }
    public string Typ { get; set; }
    public int Schaden { get; set; }

    public Attacke() { }

    public Attacke(string name, string typ, int schaden)
    {
        Name = name;
        Typ = typ;
        Schaden = schaden;
    }
}
