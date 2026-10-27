namespace MusicLabel.Domain;

/// <summary>
/// Stellt Funktionen zur Berechnung von Ticket- und Albumpreisen bereit.
/// </summary>
public static class Preisrechner
{
    /// <summary>
    /// Berechnet den Gesamtpreis für eine Anzahl von Tickets zu einem Grundpreis.
    /// </summary>
    /// <param name="grundpreis">Preis pro Ticket.</param>
    /// <param name="anzahl">Anzahl der Tickets.</param>
    /// <returns>Gesamtpreis.</returns>
    public static decimal BerechneTicketpreis(decimal grundpreis, int anzahl)
    {
        if(anzahl <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if(grundpreis < 0m)
        {
            throw new ArgumentOutOfRangeException();
        }
        return grundpreis * anzahl;
    }

    /// <summary>
    /// Berechnet den Gesamtpreis für Tickets mit einem Rabatt in Prozent.
    /// </summary>
    /// <param name="grundpreis">Preis pro Ticket.</param>
    /// <param name="anzahl">Anzahl der Tickets.</param>
    /// <param name="rabattInProzent">Rabatt in Prozent.</param>
    /// <returns>Preis nach Rabatt.</returns>
    public static decimal BerechneTicketpreis(decimal grundpreis, int anzahl, decimal rabattInProzent)
    {
        if(rabattInProzent > 100m)
        {
            throw new ArgumentOutOfRangeException();
        }
        return BerechneTicketpreis(grundpreis, anzahl) * (1 - (rabattInProzent / 100));
    }

    /// <summary>
    /// Berechnet den Gesamtpreis für Tickets mit Fanclub-Rabatt.
    /// </summary>
    /// <param name="grundpreis">Preis pro Ticket.</param>
    /// <param name="anzahl">Anzahl der Tickets.</param>
    /// <param name="istFanclubMitglied">Gibt an, ob das Mitglied des Fanclubs ist.</param>
    /// <returns>Preis inklusive Fanclub-Rabatt.</returns>
    public static decimal BerechneTicketpreis(decimal grundpreis, int anzahl, bool istFanclubMitglied)
    {
        if (istFanclubMitglied)
        {
            return BerechneTicketpreis(grundpreis, anzahl, 15);
        }
        else
        {
            return BerechneTicketpreis(grundpreis, anzahl);
        }
    }

    /// <summary>
    /// Berechnet den Gesamtpreis für mehrere Albumtitel mit festem Preis pro Titel.
    /// </summary>
    /// <param name="anzahlTitel">Anzahl der Titel.</param>
    /// <param name="preisProTitel">Preis pro Titel.</param>
    /// <returns>Gesamtpreis des Albums.</returns>
    public static decimal BerechneAlbumpreis(int anzahlTitel, decimal preisProTitel)
    {
        if(anzahlTitel <= 0m)
        {
            throw new ArgumentOutOfRangeException();
        }
        return BerechneTicketpreis(preisProTitel, anzahlTitel);
    }

    /// <summary>
    /// Berechnet den Gesamtpreis für ein Album mit optionalem Rabatt.
    /// </summary>
    /// <param name="anzahlTitel">Anzahl der Titel.</param>
    /// <param name="preisProTitel">Preis pro Titel.</param>
    /// <param name="rabattInProzent">Rabatt in Prozent.</param>
    /// <returns>Preis nach Rabatt.</returns>
    public static decimal BerechneAlbumpreis(int anzahlTitel, decimal preisProTitel, decimal rabattInProzent = 0m)
    {
        if(rabattInProzent < 0m)
        {
            throw new ArgumentOutOfRangeException();
        }
        return BerechneTicketpreis(preisProTitel, anzahlTitel, rabattInProzent);
    }

    /// <summary>
    /// Versucht, den Ticketpreis mit Rabatt zu berechnen und gibt das Ergebnis per out-Parameter zurück.
    /// </summary>
    /// <param name="grundpreis">Preis pro Ticket.</param>
    /// <param name="anzahl">Anzahl der Tickets.</param>
    /// <param name="rabattInProzent">Rabatt in Prozent.</param>
    /// <param name="preis">Der berechnete Preis bei erfolgreicher Berechnung.</param>
    /// <returns>True, wenn die Berechnung erfolgreich war; sonst false.</returns>
    public static bool TryBerechneTicketpreis(decimal grundpreis, int anzahl, decimal rabattInProzent, out decimal preis)
    {
        if (anzahl <= 0 || rabattInProzent < 0 || rabattInProzent > 100)
        {
            preis = 0;
            return false;
        }

        preis = BerechneTicketpreis(grundpreis, anzahl, rabattInProzent);
        return true;
    }
}