using System;
using MusicLabel.Data;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class InterpretRepositoryTests
{
    [Fact]
    public void Hinzufuegen_EinKontextHinzufuegenAndererKontextHole_ReturntErstelleEntitaet()
    {
        // Arrange
        string kuenstlername = "Eisvogel";
        string genre = "Pop";
        decimal tagesgage = 1200m;
        Interpret erstellterInterpret = new Interpret(kuenstlername, genre, tagesgage);

        TestDatenbank db = new TestDatenbank();
        InterpretRepository repo1 = new InterpretRepository(db.ErzeugeContext());
        
        InterpretRepository repo2 = new InterpretRepository(db.ErzeugeContext());

        // Act
        repo1.Hinzufügen(erstellterInterpret);
        
        var geholterInterpret = repo2.HoleNachId(1);

        // Assert
        Assert.Equivalent(erstellterInterpret, geholterInterpret);
    }

    [Fact]
    public void ExistiertName_EinmalBekanntEinmalUnbekannt_ReturntEinmalTrueUndEinmalFalse()
    {
        // Arrange
        string kuenstlername = "Eisvogel";
        string genre = "Pop";
        decimal tagesgage = 1200m;
        Interpret erstellterInterpret = new Interpret(kuenstlername, genre, tagesgage);

        TestDatenbank db = new TestDatenbank();
        InterpretRepository repo = new InterpretRepository(db.ErzeugeContext());
        
        // Act
        repo.Hinzufügen(erstellterInterpret);
        
        bool wahrErwartet = repo.ExistiertName(kuenstlername);
        bool falschErwartet = repo.ExistiertName("Unbekannt");

        // Assert
        Assert.True(wahrErwartet);
        Assert.False(falschErwartet);
    }

    [Fact]
    public void HoleAlle_ZweiEntitaeten_ReturntListeSortiertNachName()
    {
        // Arrange
        string genre = "Pop";
        decimal tagesgage = 1200m;
        
        string kuenstlername1 = "Nordstern";
        string kuenstlername2 = "Eisvogel";
        Interpret interpret1 = new Interpret(kuenstlername1, genre, tagesgage);
        Interpret interpret2 = new Interpret(kuenstlername2, genre, tagesgage);

        TestDatenbank db = new TestDatenbank();
        InterpretRepository repo = new InterpretRepository(db.ErzeugeContext());
        
        repo.Hinzufügen(interpret1);
        repo.Hinzufügen(interpret2);
        
        // Act
        var sortierteListeInterpreten = repo.HoleAlle();


        // Assert
        Assert.Equal(interpret2, sortierteListeInterpreten[0]);
        Assert.Equal(interpret1, sortierteListeInterpreten[1]);
    }
}
