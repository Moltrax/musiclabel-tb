namespace MusicLabel.Domain;

public class Interpret
{
    public int Id { get; set; }
    public string Kuenstlername { get; set; }
    public string Genre { get; set; }   
    public decimal Tagesgage { get; set; }

    public Interpret(string kuenstlername, string genre, decimal tagesgage)
    {
        if (string.IsNullOrWhiteSpace(kuenstlername))
        {
            throw new ArgumentException();
        }
        if (tagesgage < 0m)
        {
            throw new ArgumentOutOfRangeException();
        }
        Kuenstlername = kuenstlername;
        Genre = genre;
        Tagesgage = tagesgage;
    }

    public decimal BerechneGage(int tage)
    {
        if(tage <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        return Tagesgage * tage;
    }
}