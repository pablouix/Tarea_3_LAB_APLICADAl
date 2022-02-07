

using System;
using Microsoft.EntityFrameworkCore;
using Tarea_3.Entidades;

public class Contexto:DbContext
{
    public DbSet<Estudiantes>? Estudiantes {get; set; }
    public DbSet<Carreras>? Carreras {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = DATA\Estudiantes.db");
    }

}