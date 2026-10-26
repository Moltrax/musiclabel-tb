using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class PreisrechnerAlbumTests
{
    [Theory]
    [InlineData(10, 1.5, 0, 15)]
    [InlineData(10, 1.5, 20, 12)]
    [InlineData(10, 1.5, 50, 7.5)]
    public void BerechneAlbumpreis_VerschiedeneParameter_RechnetKorrekt(int anzahlTitel, decimal preisProTitel, int rabattInProzent, decimal erwartet)
    {
        // Act
        decimal gesamtPreis = Preisrechner.BerechneAlbumpreis(anzahlTitel, preisProTitel, rabattInProzent);

        // Assert
        Assert.Equal(erwartet, gesamtPreis);
    }
}
