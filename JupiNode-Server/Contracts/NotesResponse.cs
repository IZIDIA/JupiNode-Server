namespace JupiNode_Server.Contracts;

public record NotesResponse(
    Guid Id,
    DateTime CreatedAt,
    string Title,
    string Content);