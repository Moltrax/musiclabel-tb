namespace MusicLabel.Domain;

public class Musiker
{
    public int Id { get; set; }
    public string Vorname { get; set; } 
    public string Nachname { get; set; }
    public string Instrument { get; set; }
    public int? BandId { get; set; }
    public Band? Band { get; set; }

    public Musiker(string vorname, string nachname, string instrument)
    {
        Vorname = vorname;
        Nachname = nachname;
        Instrument = instrument;
    }

    public string GibVollenNamen()
    {
        return $"{Vorname} {Nachname}";
    }
}