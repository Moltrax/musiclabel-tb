namespace MusicLabel.Domain;

class Interpret
{
    public int Id { get; set; }
    public string Kuenstlername { get; set; }
    public string Genre { get; set; }   
    public decimal Tagesgage { get; set; }

    public Interpret(string kuenstlername, decimal tagesgage)
    {
        Kuenstlername = kuenstlername;
        Tagesgage = tagesgage;
    }

    public decimal BerechneGage(int tage)
    {
        return Tagesgage * tage;
    }
}