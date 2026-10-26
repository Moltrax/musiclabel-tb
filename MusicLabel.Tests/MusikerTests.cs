using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class MusikerTests
{
    [Fact]
    public void MusikerCtor_KeinName_ThrowsArgumentException()
    {
        // Arrange
        string vorname = " ";
        string nachname = "Berg";
        string instrument = "Gitarre";

        // Act + Assert
        Assert.Throws<ArgumentException>(() => new Musiker(vorname, nachname, instrument));
    }
}
