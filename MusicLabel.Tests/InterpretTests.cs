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
}
