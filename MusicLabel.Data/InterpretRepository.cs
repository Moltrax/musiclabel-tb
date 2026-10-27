using System;
using Microsoft.EntityFrameworkCore;
using MusicLabel.Domain;

namespace MusicLabel.Data;

public class InterpretRepository : IInterpretRepository
{
    private readonly MusicLabelContext _context;

    public InterpretRepository(MusicLabelContext context)
    {
        _context = context;
    }

    public bool ExistiertName(string kuenstlername)
    {
        return _context.Interpreten.Any(i => i.Kuenstlername == kuenstlername);
    }

    public void Hinzufügen(Interpret interpret)
    {
        if (ExistiertName(interpret.Kuenstlername))
        {
            throw new InvalidOperationException("Der Name des Interpreten muss einzigartig sein");
        }
        
        _context.Interpreten.Add(interpret);
        _context.SaveChanges();
    }

    public List<Interpret> HoleAlle()
    {
        return _context.Interpreten.OrderBy(i => i.Kuenstlername).ToList();
    }

    public Interpret? HoleNachId(int id)
    {
        return _context.Interpreten.Find(id);
    }
}
