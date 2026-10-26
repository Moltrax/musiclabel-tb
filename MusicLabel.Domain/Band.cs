using System;

namespace MusicLabel.Domain;

public class Band
{
    private List<Musiker> mitglieder;

    public int Id { get; set; }
    public string Name { get; set; }
    public int Gruendungsjahr { get; set; }
    public List<Musiker> Mitglieder
    {
        get
        {
            return mitglieder;
        }
    }

    public Band(string name, int gruendungsjahr)
    {
        Name = name;
        Gruendungsjahr = gruendungsjahr;
    }

    public void FuegeMitgliedHinzu(Musiker musiker)
    {
        mitglieder.Add(musiker);
    }
}
