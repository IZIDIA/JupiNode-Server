namespace JupiNode.Core.Models;

/// <summary>
/// Доменная модель заметки
/// </summary>
public class Note
{
    /// <summary>
    /// Максимальная длина заголовка
    /// </summary>
    public const int MaxTitleLength = 250;

    /// <summary>
    /// Конструктор с параметрами
    /// </summary>
    /// <param name="id"> Идентификатор </param>
    /// <param name="createdAt"> Дата создания </param>
    /// <param name="title"> Заголовок </param>
    /// <param name="content"> Содержимое </param>
    private Note(Guid id, DateTime createdAt, string title, string content)
    {
        Id = id;
        CreatedAt = createdAt;
        Title = title;
        Content = content;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Содержимое в текстовом формате
    /// </summary>
    public string Content { get; }

    // TODO: Связь с пользователем
    // public int UserId { get; }

    /// <summary>
    /// Безопасно создать запись
    /// </summary>
    /// <param name="id"> Идентификатор </param>
    /// <param name="createdAt"> Дата создания </param>
    /// <param name="title"> Заголовок </param>
    /// <param name="content"> Содержимое </param>
    /// <returns> Запись или null, список ошибок </returns>
    public static (Note? Note, IList<string> Error) Create(Guid id, DateTime createdAt, string title, string content)
    {
        var error = new List<string>();
        if (title.Length > MaxTitleLength)
        {
            error.Add($"Заголовок превышает максимально допустимое количество символов {MaxTitleLength}.");
        }

        // TODO: Валидация (ValidationAttribute)

        if (error.Count == 0)
        {
            return (null, error);
        }

        var note = new Note(id, createdAt, title, content);
        return (note, error);
    }
}