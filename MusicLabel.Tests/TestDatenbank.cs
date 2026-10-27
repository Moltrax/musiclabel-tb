using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MusicLabel.Data;

namespace MusicLabel.Tests;

public class TestDatenbank : IDisposable 
{ 
    private readonly SqliteConnection _verbindung = new SqliteConnection("Data Source=:memory:"); 

    public TestDatenbank() 
    {
        _verbindung.Open(); 
        using MusicLabelContext context = ErzeugeContext(); 
        context.Database.EnsureCreated(); 
    }

    public MusicLabelContext ErzeugeContext() 
    {
        DbContextOptions<MusicLabelContext> options = new DbContextOptionsBuilder<MusicLabelContext>() 
            .UseSqlite(_verbindung) 
            .Options; 

        return new MusicLabelContext(options); 
    } 

    public void Dispose() 
    { 
        _verbindung.Dispose(); 
    } 
} 