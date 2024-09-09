using JupiNode.Core.Abstractions;
using JupiNode.Core.Models;

namespace JupiNode.Application.Services;

public class NotesService : INotesService
{
    private readonly INotesRepository _repository;

    public NotesService(INotesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Note>> GetAllNotes()
    {
        return await _repository.Get();
    }

    public async Task<Guid> CreateNote(Note note)
    {
        return await _repository.Create(note);
    }

    public async Task<Guid> UpdateNote(Guid id, DateTime createdAt, string title, string content)
    {
        return await _repository.Update(id, createdAt, title, content);
    }

    public async Task<Guid> DeleteNote(Guid id)
    {
        return await _repository.Delete(id);
    }
}