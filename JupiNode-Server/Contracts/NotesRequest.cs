namespace JupiNode_Server.Contracts;

public record NotesRequest(
    DateTime CreatedAt,
    string Title,
    string Content);