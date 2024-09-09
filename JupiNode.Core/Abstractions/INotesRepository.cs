﻿using JupiNode.Core.Models;

namespace JupiNode.Core.Abstractions;

/// <summary>
/// Интерфейс для репозитория заметок
/// </summary>
public interface INotesRepository
{
    /// <summary>
    /// Получить список всех заметок
    /// </summary>
    /// <returns> Список заметок </returns>
    Task<List<Note>> Get();

    /// <summary>
    /// Создать заметку в БД
    /// </summary>
    /// <param name="note"> Объект-заметка </param>
    /// <returns> Идентификатор созданной заметки </returns>
    Task<Guid> Create(Note note);

    /// <summary>
    /// Обновить объект
    /// </summary>
    /// <param name="id"></param>
    /// <param name="createdAt"></param>
    /// <param name="title"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    Task<Guid> Update(Guid id, DateTime createdAt, string title, string content);

    /// <summary>
    /// Удалить
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Guid> Delete(Guid id);
}