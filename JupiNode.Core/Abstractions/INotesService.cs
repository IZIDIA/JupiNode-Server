using JupiNode.Core.Models;

namespace JupiNode.Core.Abstractions;

public interface INotesService
{
    Task<List<Note>> GetAllNotes();

    Task<Guid> CreateNote(Note note);

    Task<Guid> UpdateNote(Guid id, DateTime createdAt, string title, string content);

    Task<Guid> DeleteNote(Guid id);
}