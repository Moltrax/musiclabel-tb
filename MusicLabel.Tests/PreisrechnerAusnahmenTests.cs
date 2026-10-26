using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class PreisrechnerAusnahmenTests
{
    [Fact]
    public void BerechneTicketpreis_NullAnzahl_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal preis = 25m;
        int anzahl = 0;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Preisrechner.BerechneTicketpreis(preis, anzahl));    

    }

    [Fact]
    public void BerechneTicketpreis_NegativerPreis_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal preis = -1m;
        int anzahl = 2;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Preisrechner.BerechneTicketpreis(preis, anzahl));
    }

    [Fact]
    public void BerechneTicketpreis_ZuVielRabatt_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal preis = 25m;
        int anzahl = 2;
        decimal rabatt = 120m;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Preisrechner.BerechneTicketpreis(preis, anzahl, rabatt));    
    }

    [Fact]
    public void BerechneAlbumbPreis_NullAnzahlTitel_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal preis = 25m;
        int anzahl = 0;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Preisrechner.BerechneAlbumpreis(anzahl, preis));    
    }

    [Fact]
    public void BerechneAlbumbPreis_NegativerRabatt_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        decimal preis = 25m;
        int anzahl = 2;
        decimal rabatt = -5m;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => Preisrechner.BerechneAlbumpreis(anzahl, preis, rabatt));    
    }

   

    
}
