using JupiNode.Core.Models;
using JupiNode.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JupiNode.DataAccess.Configurations;

public class NotesConfiguration : IEntityTypeConfiguration<NoteEntity>
{
    public void Configure(EntityTypeBuilder<NoteEntity> builder)
    {
        builder.Property(item => item.Title).IsRequired().HasMaxLength(Note.MaxTitleLength);

        // TODO: Конфигурация (Изучить для чего в основном используется)
    }
}