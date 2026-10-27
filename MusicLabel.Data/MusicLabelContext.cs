using System;
using Microsoft.EntityFrameworkCore;
using MusicLabel.Domain;

namespace MusicLabel.Data;

public class MusicLabelContext : DbContext
{
    public MusicLabelContext(DbContextOptions<MusicLabelContext> options) : base(options)
    {
        
    }

    public DbSet<Interpret> Interpreten => Set<Interpret>();
    public DbSet<Band> Bands => Set<Band>();
    public DbSet<Musiker> Musiker => Set<Musiker>();
}
