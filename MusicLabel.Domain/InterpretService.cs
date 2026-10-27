using System;

namespace MusicLabel.Domain;

/// <summary>
/// Bietet Geschäftsfunktionen für das Verwalten und Berechnen von Interpreten.
/// </summary>
public class InterpretService
{
    private readonly IInterpretRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="InterpretService"/> class.
    /// </summary>
    /// <param name="interpretRepository">Das Repository für Interpretendaten.</param>
    public InterpretService(IInterpretRepository interpretRepository)
    {
        _repository = interpretRepository;
    }

    /// <summary>
    /// Gibt alle vorhandenen Interpreten zurück.
    /// </summary>
    /// <returns>Liste aller Interpreten.</returns>
    public List<Interpret> HoleAlle()
    {
        return _repository.HoleAlle();
    }

    /// <summary>
    /// Holt einen Interpret anhand seiner ID.
    /// </summary>
    /// <param name="id">Die ID des Interpreten.</param>
    /// <returns>Den gefundenen Interpret.</returns>
    /// <exception cref="InterpretNichtGefundenExceptionException">Wird ausgelöst, wenn kein Interpret gefunden wurde.</exception>
    public Interpret Hole(int id)
    {
        var interpret = _repository.HoleNachId(id);

        if (interpret is null)
        {
            throw new InterpretNichtGefundenExceptionException($"Interpret nicht gefunden mit id {id}");
        }
        return interpret;
    }

    /// <summary>
    /// Legt einen neuen Interpret an, sofern der Name noch nicht existiert.
    /// </summary>
    /// <param name="kuenstlername">Der Name des Interpreten.</param>
    /// <param name="genre">Das Genre des Interpreten.</param>
    /// <param name="tagesgage">Die Tagesgage des Interpreten.</param>
    /// <returns>Der angelegte Interpret.</returns>
    /// <exception cref="InvalidOperationException">Wird ausgelöst, wenn der Name bereits existiert.</exception>
    public Interpret Anlegen(string kuenstlername, string genre, decimal tagesgage)
    {
        if (_repository.ExistiertName(kuenstlername))
        {
            throw new InvalidOperationException($"Interpret mit Name {kuenstlername} existiert schon");
        }

        Interpret neuerInterpret = new Interpret(kuenstlername, genre, tagesgage);
        _repository.Hinzufügen(neuerInterpret);
        return neuerInterpret;
    }

    /// <summary>
    /// Berechnet die Gage eines Interpreten für eine bestimmte Anzahl von Tagen.
    /// </summary>
    /// <param name="id">Die ID des Interpreten.</param>
    /// <param name="tage">Die Anzahl der Tage.</param>
    /// <returns>Die berechnete Gage.</returns>
    public decimal BerechneGage(int id, int tage)
    {
        Interpret interpret;
        try
        {
            interpret = Hole(id);
            return interpret.BerechneGage(tage);
        }
        catch
        {
            throw;
        }
    }
}
