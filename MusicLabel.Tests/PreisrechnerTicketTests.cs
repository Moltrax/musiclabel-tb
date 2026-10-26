using System;
using MusicLabel.Domain;


namespace MusicLabel.Tests;

public class PreisrechnerTicketTests
{
    [Fact]
    public void BerechneTicketpreis_PreisUndAnzahlKorrektGegeben_RechnetKorrekt()
    {
        // Arrange
        decimal preisProTitel = 25m;
        int anzahlTitel = 4;

        // Act
        decimal gesamtPreis = Preisrechner.BerechneTicketpreis(preisProTitel, anzahlTitel);

        // Assert
        Assert.Equal(100, gesamtPreis);
    }

    [Fact]
    public void BerechneTicketpreis_PreisUndAnzahlMitRabattKorrektGegeben_RechnetKorrekt()
    {
        // Arrange
        decimal preisProTitel = 25m;
        int anzahlTitel = 4;
        int rabattInProzent = 10;

        // Act
        decimal gesamtPreis = Preisrechner.BerechneTicketpreis(preisProTitel, anzahlTitel, rabattInProzent);

        // Assert
        Assert.Equal(90, gesamtPreis);
    }

    [Fact]
    public void BerechneTicketpreis_PreisUndAnzahlOhneFanclubKorrektGegeben_RechnetKorrekt()
    {
        // Arrange
        decimal preisProTitel = 20m;
        int anzahlTitel = 2;
        bool istFanclubMitglied = false;

        // Act
        decimal gesamtPreis = Preisrechner.BerechneTicketpreis(preisProTitel, anzahlTitel, istFanclubMitglied);

        // Assert
        Assert.Equal(40, gesamtPreis);
    }

    [Fact]
    public void BerechneTicketpreis_PreisUndAnzahlMitFanclubKorrektGegeben_RechnetKorrekt()
    {
        // Arrange
        decimal preisProTitel = 20m;
        int anzahlTitel = 2;
        bool istFanclubMitglied = true;

        // Act
        decimal gesamtPreis = Preisrechner.BerechneTicketpreis(preisProTitel, anzahlTitel, istFanclubMitglied);

        // Assert
        Assert.Equal(34, gesamtPreis);
    }
}
