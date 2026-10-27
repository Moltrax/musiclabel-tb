using System;

namespace MusicLabel.Domain;

/// <summary>
/// Repräsentiert eine Musikband mit Namen, Gründungsjahr und Mitgliedern.
/// </summary>
public class Band
{
    private List<Musiker> mitglieder;

    /// <summary>
    /// Gets or sets the unique identifier of the band.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the display name of the band.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the year the band was founded.
    /// </summary>
    public int Gruendungsjahr { get; set; }

    /// <summary>
    /// Gets the list of band members.
    /// </summary>
    public List<Musiker> Mitglieder
    {
        get
        {
            return mitglieder;
        }
    }

    /// <summary>
    /// Initializes a new band instance with a valid name and founding year.
    /// </summary>
    /// <param name="name">Name der Band.</param>
    /// <param name="gruendungsjahr">Gründungsjahr der Band.</param>
    public Band(string name, int gruendungsjahr)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException();
        }
        Name = name;
        Gruendungsjahr = gruendungsjahr;
    }

    /// <summary>
    /// Fügt der Band ein neues Mitglied hinzu.
    /// </summary>
    /// <param name="musiker">Der hinzuzufügende Musiker.</param>
    public void FuegeMitgliedHinzu(Musiker musiker)
    {
        if (musiker == null)
        {
            throw new ArgumentNullException();
        }
        mitglieder.Add(musiker);
    }
}
