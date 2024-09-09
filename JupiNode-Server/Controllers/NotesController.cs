using JupiNode_Server.Contracts;
using JupiNode.Core.Abstractions;
using JupiNode.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace JupiNode_Server.Controllers;

/// <summary>
/// Контроллер для заметок
/// </summary>
[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly INotesService _notesService;

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="notesService"> Сервис заметок </param>
    public NotesController(INotesService notesService)
    {
        _notesService = notesService;
    }

    /// <summary>
    /// Получить список заметок
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<List<NotesResponse>>> GetNotes()
    {
        var notes = await _notesService.GetAllNotes();

        // TODO: Мапинг
        var response = notes.Select(item => new NotesResponse(item.Id, item.CreatedAt, item.Title, item.Content));
        return Ok(response);
    }

    /// <summary>
    /// Создать заметку
    /// </summary>
    /// <param name="request"> Запрос для создания </param>
    /// <returns> ID в случае успешного создания </returns>
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateNote([FromBody] NotesRequest request)
    {
        var (note, error) = Note.Create(Guid.NewGuid(), request.CreatedAt, request.Title, request.Content);
        if (note is null)
        {
            return BadRequest(error);
        }

        var noteId = await _notesService.CreateNote(note);
        return Ok(noteId);
    }

    /// <summary>
    /// Обновить заметку
    /// </summary>
    /// <param name="id"> Идентификатор </param>
    /// <param name="request"> Запрос для обновления </param>
    /// <returns> ID в случае успешного обновления </returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateNote(Guid id, [FromBody] NotesRequest request)
    {
        var noteId = await _notesService.UpdateNote(id, request.CreatedAt, request.Title, request.Content);
        return Ok(noteId);
    }

    /// <summary>
    /// Удалить заметку
    /// </summary>
    /// <param name="id"> Идентификатор </param>
    /// <returns> ID в случае успешного удаления </returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteNote(Guid id)
    {
        return Ok(await _notesService.DeleteNote(id));
    }
}