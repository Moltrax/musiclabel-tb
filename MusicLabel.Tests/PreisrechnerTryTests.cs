using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class PreisrechnerTryTests
{
    [Fact]
    public void TryBerechneTicketpreis_ValideWerte_ReturntTrueUndPreis()
    {
        // Arrange
        decimal grundpreis = 25m;
        int anzahl = 4;
        decimal rabattInProzent = 10m;

        decimal gesamtPreis;

        // Act
        bool istValide = Preisrechner.TryBerechneTicketpreis(grundpreis, anzahl, rabattInProzent, out gesamtPreis);

        // Assert
        Assert.True(istValide);
        Assert.Equal(90, gesamtPreis);
    }
    [Fact]
    public void TryBerechneTicketpreis_AnzahlIstNull_ReturntFalseUndPreisNull()
    {
        // Arrange
        decimal grundpreis = 25m;
        int anzahl = 0;
        decimal rabattInProzent = 0m;

        decimal gesamtPreis;

        // Act
        bool istValide = Preisrechner.TryBerechneTicketpreis(grundpreis, anzahl, rabattInProzent, out gesamtPreis);

        // Assert
        Assert.False(istValide);
        Assert.Equal(0, gesamtPreis);
    }
    [Fact]
    public void TryBerechneTicketpreis_UeberHundertProzentRabatt_ReturntFalseUndPreisNull()
    {
        // Arrange
        decimal grundpreis = 25m;
        int anzahl = 2;
        decimal rabattInProzent = 101m;


        // Act
        bool istValide = Preisrechner.TryBerechneTicketpreis(grundpreis, anzahl, rabattInProzent, out _);

        // Assert
        Assert.False(istValide);
    }
}
