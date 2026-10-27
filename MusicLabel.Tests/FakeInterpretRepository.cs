using System;
using MusicLabel.Domain;

namespace MusicLabel.Tests;

public class FakeInterpretRepository : IInterpretRepository
{
    private List<Interpret> interpreten = [];
    public bool ExistiertName(string kuenstlername)
    {
        return interpreten.Exists(a => a.Kuenstlername == kuenstlername);
    }

    public void Hinzufügen(Interpret interpret)
    {
        if (interpret is null)
        {
            throw new ArgumentNullException();
        }
        if (interpret.Id != null)
        {
            throw new InvalidOperationException("Id des Interpreten darf nicht bereits gesetzt sein.");
        }
        interpret.Id = nächsteFreieId();

        interpreten.Add(interpret);
    }

    public List<Interpret> HoleAlle()
    {
        return interpreten;
    }

    public Interpret? HoleNachId(int id)
    {
        return interpreten.FirstOrDefault(i => i.Id == id);
    }

    private int nächsteFreieId()
    {
        int maxId = 0;
        foreach (var interpret in interpreten)
        {
            if(maxId <= interpret.Id)
            {
                maxId = (int)interpret.Id;
            }
        }

        return maxId + 1;
    }
}
