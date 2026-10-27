using System;

namespace MusicLabel.Domain;

public class InterpretService
{
    private readonly IInterpretRepository _repository;

    public InterpretService(IInterpretRepository interpretRepository)
    {
        _repository = interpretRepository;
    }

    public List<Interpret> HoleAlle()
    {
        return _repository.HoleAlle();
    }

    public Interpret Hole(int id)
    {
        var interpret = _repository.HoleNachId(id);

        if (interpret is null)
        {
            throw new InterpretNichtGefundenExceptionException($"Interpret nicht gefunden mit id {id}");
        }
        return interpret;
    }
    public Interpret Anlegen(string kuenstlername, string genre, decimal tagesgage)
    {
        if (_repository.ExistiertName(kuenstlername))
        {
            throw new InvalidOperationException($"Interpret mit Name {kuenstlername} existiert schon");
        }

        Interpret neuerInterpret = new Interpret(kuenstlername, genre, tagesgage);
        _repository.Hinzufügen(neuerInterpret);
        return neuerInterpret;
    }

    public decimal BerechneGage(int id, int tage)
    {
        Interpret interpret;
        try
        {
            interpret = Hole(id);
            return interpret.BerechneGage(tage);
        }
        catch
        {
            throw;
        }
    }
}
