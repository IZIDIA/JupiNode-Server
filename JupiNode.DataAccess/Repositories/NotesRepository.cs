using JupiNode.Core.Abstractions;
using JupiNode.Core.Models;
using JupiNode.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace JupiNode.DataAccess.Repositories;

/// <summary>
/// Репозиторий для работы с заметками
/// </summary>
public class NotesRepository : INotesRepository
{
    /// <summary>
    /// Контекст
    /// </summary>
    private readonly JupiNodeDbContext _context;

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="context"> Контекст </param>
    public NotesRepository(JupiNodeDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<List<Note>> Get()
    {
        var notesEntities = await _context.Notes.AsNoTracking().ToListAsync();

        // TODO: Mapping (Изучить лучшие подходы для реализации)
        var notes = new List<Note>();
        foreach (var item in notesEntities)
        {
            var mapNote = Note.Create(item.Id, item.CreatedAt, item.Title, item.Content);
            if (mapNote.Note is null)
            {
                continue;
            }

            notes.Add(mapNote.Note);
        }

        return notes;
    }

    /// <inheritdoc/>
    public async Task<Guid> Create(Note note)
    {
        var noteEntity = new NoteEntity()
        {
            Id = note.Id,
            CreatedAt = note.CreatedAt,
            Title = note.Title,
            Content = note.Content,
        };

        await _context.Notes.AddAsync(noteEntity);
        await _context.SaveChangesAsync();

        return noteEntity.Id;
    }

    /// <inheritdoc/>
    public async Task<Guid> Update(Guid id, DateTime createdAt, string title, string content)
    {
        await _context.Notes
            .Where(item => item.Id == id)
            .ExecuteUpdateAsync(
                entity => entity
                    .SetProperty(note => note.CreatedAt, createdAt)
                    .SetProperty(note => note.Title, title)
                    .SetProperty(note => note.Content, content));
        return id;
    }

    /// <inheritdoc/>
    public async Task<Guid> Delete(Guid id)
    {
        // TODO: Перепроверить удаление одного и того же Id
        await _context.Notes
            .Where(item => item.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}