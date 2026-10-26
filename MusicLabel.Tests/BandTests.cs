using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class BandTests
{
    [Fact]
    public void BandCtor_KeinName_ThrowsArgumentException()
    {
        // Arrange
        string name = " ";
        int gruendungsJahr = 2019;

        // Act + Assert
        Assert.Throws<ArgumentException>(() => new Band(name, gruendungsJahr));
    }

    [Fact]
    public void FuegeMitgliedHinzu_nullMitglied_ThrowsArgumentNullException()
    {
         // Arrange
        string name = "Kevin";
        int gruendungsJahr = 2019;
        Band band = new Band(name, gruendungsJahr);
        
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => band.FuegeMitgliedHinzu(null!));
    }
}
