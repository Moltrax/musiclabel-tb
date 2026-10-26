namespace MusicLabel.Domain;

public class Interpret
{
    public int Id { get; set; }
    public string Kuenstlername { get; set; }
    public string Genre { get; set; }   
    public decimal Tagesgage { get; set; }

    public Interpret(string kuenstlername, string genre, decimal tagesgage)
    {
        Kuenstlername = kuenstlername;
        Genre = genre;
        Tagesgage = tagesgage;
    }

    public decimal BerechneGage(int tage)
    {
        return Tagesgage * tage;
    }
}