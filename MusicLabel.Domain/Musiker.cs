namespace MusicLabel.Domain;

/// <summary>
/// Repräsentiert einen Musiker mit Namen, Instrument und optionaler Bandzuordnung.
/// </summary>
public class Musiker
{
    /// <summary>
    /// Gets or sets the unique identifier of the musician.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the musician's first name.
    /// </summary>
    public string Vorname { get; set; }

    /// <summary>
    /// Gets or sets the musician's last name.
    /// </summary>
    public string Nachname { get; set; }

    /// <summary>
    /// Gets or sets the instrument the musician plays.
    /// </summary>
    public string Instrument { get; set; }

    /// <summary>
    /// Gets or sets the foreign key of the associated band.
    /// </summary>
    public int? BandId { get; set; }

    /// <summary>
    /// Gets or sets the associated band, if any.
    /// </summary>
    public Band? Band { get; set; }

    /// <summary>
    /// Initializes a new musician instance with first name, last name and instrument.
    /// </summary>
    /// <param name="vorname">Der Vorname.</param>
    /// <param name="nachname">Der Nachname.</param>
    /// <param name="instrument">Das Instrument.</param>
    public Musiker(string vorname, string nachname, string instrument)
    {
        if (string.IsNullOrWhiteSpace(vorname))
        {
            throw new ArgumentException();
        }
        if (string.IsNullOrWhiteSpace(nachname))
        {
            throw new ArgumentException();
        }
        if (string.IsNullOrWhiteSpace(instrument))
        {
            throw new ArgumentException();
        }

        Vorname = vorname;
        Nachname = nachname;
        Instrument = instrument;
    }

    /// <summary>
    /// Gibt den vollständigen Namen des Musikers als "Vorname Nachname" zurück.
    /// </summary>
    /// <returns>Der vollständige Name.</returns>
    public string GibVollenNamen()
    {
        return $"{Vorname} {Nachname}";
    }
}