namespace JupiNode.DataAccess.Entities;

/// <summary>
/// Сущность-заметка для БД
/// </summary>
public class NoteEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Содержимое в текстовом формате
    /// </summary>
    public string Content { get; set; }
}