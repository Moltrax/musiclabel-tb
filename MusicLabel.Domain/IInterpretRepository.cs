using System;

namespace MusicLabel.Domain;

/// <summary>
/// Definiert die Datenzugriffsfunktionen für Interpret-Entitäten.
/// </summary>
public interface IInterpretRepository
{
    /// <summary>
    /// Gibt alle vorhandenen Interpreten zurück.
    /// </summary>
    /// <returns>Liste aller Interpreten.</returns>
    List<Interpret> HoleAlle();

    /// <summary>
    /// Sucht einen Interpreten anhand seiner eindeutigen ID.
    /// </summary>
    /// <param name="id">Die ID des Interpreten.</param>
    /// <returns>Den gefundenen Interpreten oder null, wenn keiner existiert.</returns>
    Interpret? HoleNachId(int id);

    /// <summary>
    /// Prüft, ob bereits ein Interpret mit dem angegebenen Namen existiert.
    /// </summary>
    /// <param name="kuenstlername">Der zu prüfende Künstlername.</param>
    /// <returns>True, wenn der Name bereits verwendet wird; ansonsten false.</returns>
    bool ExistiertName(string kuenstlername);

    /// <summary>
    /// Speichert einen neuen Interpretendatensatz.
    /// </summary>
    /// <param name="interpret">Der anzulegende Interpret.</param>
    void Hinzufügen(Interpret interpret);
}