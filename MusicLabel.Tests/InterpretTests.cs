using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class InterpretTests
{
    [Fact]
    public void InterpretCtor_KorrekteWerte_SetztEigenschaften()
    {
        // Arrange
        string name = "Eisvogel";
        string genre = "Pop";
        decimal tagesGage = 1200m;

        // Act
        Interpret interpret = new Interpret(name, genre, tagesGage);


        // Assert
        Assert.Equal(name, interpret.Kuenstlername);
        Assert.Equal(genre, interpret.Genre);
        Assert.Equal(tagesGage, interpret.Tagesgage);
    }

    [Fact]
    public void BerechneGage_KorrekteWerte_KorrektBerechnet()
    {
        // Arrange
        string name = "Eisvogel";
        string genre = "Pop";
        decimal tagesGage = 1200m;
        Interpret interpret = new Interpret(name, genre, tagesGage);

        // Act
        decimal gesamtGage = interpret.BerechneGage(3);

        // Assert
        Assert.Equal(3600, gesamtGage);
    }


    // ############ Ausnahmen Tests #############


    [Fact]
    public void InterpretCtor_KeinName_ThrowsArgumentException()
    {
         // Arrange
        string name = " ";
        string genre = "Pop";
        decimal tagesGage = 1200m;

        // Act + Assert
        Assert.Throws<ArgumentException>(
            () => new Interpret(name, genre, tagesGage));    
    }

    [Fact]
    public void InterpretCtor_NegativeGage_ThrowsArgumentOutOfRangeException()
    {
         // Arrange
        string name = "Eisvogel";
        string genre = "Pop";
        decimal tagesGage = -1m;

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new Interpret(name, genre, tagesGage));    
    }

    [Fact]
    public void BerechneGage_NullTage_ThrowsArgumentOutOfRangeException()
    {
         // Arrange
        string name = "Eisvogel";
        string genre = "Pop";
        decimal tagesGage = 1200m;
        int anzahlTage = 0;
        Interpret interpret = new Interpret(name, genre, tagesGage);

        // Act + Assert
        Assert.Throws<ArgumentOutOfRangeException>(
            () => interpret.BerechneGage(anzahlTage));    
    }

}
