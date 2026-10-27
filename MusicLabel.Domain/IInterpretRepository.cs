using System;

namespace MusicLabel.Domain;

public interface IInterpretRepository
{
    List<Interpret> HoleAlle();
    Interpret? HoleNachId(int id);
    bool ExistiertName(string kuenstlername);
    void Hinzufügen(Interpret interpret);
}