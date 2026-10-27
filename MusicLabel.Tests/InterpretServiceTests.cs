using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class InterpretServiceTests
{
    [Fact]
    public void Anlegen_KorrekteWerte_ReturntEntityMitId1UndRepoHatEinEntity()
    {
        // Arrange
        string kuenstlername = "Eisvogel";
        string genre = "Pop";
        decimal tagesgage = 1200m;

        IInterpretRepository repository = new FakeInterpretRepository();
        InterpretService service = new InterpretService(repository);
        
        // Act
        var interpret = service.Anlegen(kuenstlername, genre, tagesgage);
        var alleInterpreten = service.HoleAlle();

        // Assert
        Assert.Equal(1, interpret.Id);
        Assert.Single(alleInterpreten);
    }
    
    [Fact]
    public void Anlegen_DoppelterName_ThrowsInvalidOperationException()
    {
        // Arrange
        string kuenstlername = "Eisvogel";
        string genre = "Pop";
        decimal tagesgage = 1200m;

        IInterpretRepository repository = new FakeInterpretRepository();
        InterpretService service = new InterpretService(repository);
        
        // Act
        var interpret = service.Anlegen(kuenstlername, genre, tagesgage);

        // Assert
        Assert.Throws<InvalidOperationException>(
            () => service.Anlegen(kuenstlername, genre+"2", tagesgage));
    }

    [Fact]
    public void Hole_FalscheId_ThrowsInterpretNichtGefundenException()
    {
        // Arrange
        int id = 42;
        IInterpretRepository repository = new FakeInterpretRepository();
        InterpretService service = new InterpretService(repository);
        
        // Act + Assert
        Assert.Throws<InterpretNichtGefundenExceptionException>(
            () => service.Hole(id));
    }

    [Fact]
    public void BerechneGage_1200TagesGageBei3Tagen_Returnt3600GesamtGage()
    {
        // Arrange
        string kuenstlername = "Eisvogel";
        string genre = "Pop";
        decimal tagesgage = 1200m;

        int tage = 3;

        IInterpretRepository repository = new FakeInterpretRepository();
        InterpretService service = new InterpretService(repository);
        var interpret = service.Anlegen(kuenstlername, genre, tagesgage);
        
        // Act
        decimal gesamtGage = service.BerechneGage((int)interpret.Id!, tage);

        // Assert
        Assert.Equal(3600, gesamtGage);
    }

    [Fact]
    public void HoleAlle_ZweiAngelegteInterpreten_ReturntZweiEinträge()
    {
        // Arrange
        string kuenstlername1 = "Eisvogel";
        string genre1 = "Pop";
        decimal tagesgage1 = 1200m;

        string kuenstlername2 = "Feuervogel";
        string genre2 = "Metal";
        decimal tagesgage2 = 4.25m;

        IInterpretRepository repository = new FakeInterpretRepository();
        InterpretService service = new InterpretService(repository);
        service.Anlegen(kuenstlername1, genre1, tagesgage1);
        service.Anlegen(kuenstlername2, genre2, tagesgage2);
        
        // Act
        var alleInterpreten = service.HoleAlle();

        // Assert
        Assert.Equal(2, alleInterpreten.Count);
    }
}
