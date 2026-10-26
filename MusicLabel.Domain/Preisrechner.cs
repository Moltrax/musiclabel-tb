namespace MusicLabel.Domain;

public static class Preisrechner
{
    public static decimal BerechneTicketpreis(decimal grundpreis, int anzahl)
    {
        return grundpreis * anzahl;
    }

    public static decimal BerechneTicketpreis(decimal grundpreis, int anzahl, decimal rabattInProzent)
    {
        return BerechneTicketpreis(grundpreis, anzahl) * (1 - (rabattInProzent / 100));
    }
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

    public static decimal BerechneAlbumpreis(int anzahlTitel, decimal preisProTitel)
    {
        return BerechneTicketpreis(preisProTitel, anzahlTitel);
    }

    public static decimal BerechneAlbumpreis(int anzahlTitel, decimal preisProTitel, decimal rabattInProzent = 0m)
    {
        return BerechneTicketpreis(preisProTitel, anzahlTitel, rabattInProzent);
    }

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