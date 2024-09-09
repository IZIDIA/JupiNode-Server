using JupiNode.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JupiNode.DataAccess;

public class JupiNodeDbContext : DbContext
{
    public JupiNodeDbContext(DbContextOptions<JupiNodeDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Коллекция заметок
    /// </summary>
    public DbSet<NoteEntity> Notes { get; set; }
}