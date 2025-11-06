namespace Azure.AI.AgentServer.Core.Common.Id;

/// <summary>
/// Provides functionality for generating unique identifiers.
/// </summary>
public interface IIdGenerator
{
    /// <summary>
    /// Generates a new unique identifier with an optional category prefix.
    /// </summary>
    /// <param name="category">The category prefix for the ID.</param>
    /// <returns>A newly generated unique identifier.</returns>
    string Generate(string? category = null);
}

/// <summary>
/// Provides extension methods for <see cref="IIdGenerator"/>.
/// </summary>
public static class IdGeneratorExtensions
{
    /// <summary>
    /// Generates a function call ID.
    /// </summary>
    /// <param name="idGenerator">The ID generator.</param>
    /// <returns>A newly generated function call ID.</returns>
    public static string GenerateFunctionCallId(this IIdGenerator idGenerator) => idGenerator.Generate("func");

    /// <summary>
    /// Generates a function output ID.
    /// </summary>
    /// <param name="idGenerator">The ID generator.</param>
    /// <returns>A newly generated function output ID.</returns>
    public static string GenerateFunctionOutputId(this IIdGenerator idGenerator) => idGenerator.Generate("funcout");

    /// <summary>
    /// Generates a message ID.
    /// </summary>
    /// <param name="idGenerator">The ID generator.</param>
    /// <returns>A newly generated message ID.</returns>
    public static string GenerateMessageId(this IIdGenerator idGenerator) => idGenerator.Generate("msg");
}
