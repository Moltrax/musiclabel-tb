namespace MusicLabel.Domain;

/// <summary>
/// Repräsentiert einen Künstler oder Musiker mit Name, Genre und Tagesgage.
/// </summary>
public class Interpret
{
    /// <summary>
    /// Gets or sets the identifier of the interpret.
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Gets or sets the artist name.
    /// </summary>
    public string Kuenstlername { get; set; }

    /// <summary>
    /// Gets or sets the musical genre.
    /// </summary>
    public string Genre { get; set; }

    /// <summary>
    /// Gets or sets the daily fee for the interpret.
    /// </summary>
    public decimal Tagesgage { get; set; }

    /// <summary>
    /// Initializes a new interpret with a valid artist name and non-negative daily fee.
    /// </summary>
    /// <param name="kuenstlername">Der Künstlername.</param>
    /// <param name="genre">Das Musikgenre.</param>
    /// <param name="tagesgage">Die Tagesgage des Interpreten.</param>
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

    /// <summary>
    /// Berechnet die Gesamtgage für eine bestimmte Anzahl von Tagen.
    /// </summary>
    /// <param name="tage">Anzahl der Tage.</param>
    /// <returns>Die berechnete Gesamtgage.</returns>
    public decimal BerechneGage(int tage)
    {
        if(tage <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        return Tagesgage * tage;
    }
}