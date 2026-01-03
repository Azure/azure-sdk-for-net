// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents a connected tool configuration definition.
/// </summary>
public sealed record FoundryConnectedTool : FoundryTool
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FoundryConnectedTool"/> class.
    /// </summary>
    /// <param name="protocol">The tool protocol.</param>
    /// <param name="projectConnectionId">The project connection ID for the tool.</param>
    /// <param name="additionalProperties">Optional additional properties for the tool configuration.</param>
    public FoundryConnectedTool(
        FoundryToolProtocol protocol,
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        : base(additionalProperties)
    {
        Protocol = protocol;
        ProjectConnectionId = projectConnectionId ?? throw new ArgumentNullException(nameof(projectConnectionId));
    }

    /// <summary>
    /// Creates an MCP connected tool definition.
    /// </summary>
    public static FoundryConnectedTool Mcp(
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(FoundryToolProtocol.MCP, projectConnectionId, additionalProperties);

    /// <summary>
    /// Creates an A2A connected tool definition.
    /// </summary>
    public static FoundryConnectedTool A2a(
        string projectConnectionId,
        IReadOnlyDictionary<string, object?>? additionalProperties = null)
        => new(FoundryToolProtocol.A2A, projectConnectionId, additionalProperties);

    /// <summary>
    /// Gets the source of the tool.
    /// </summary>
    public override FoundryToolSource Source => FoundryToolSource.CONNECTED;

    /// <summary>
    /// Gets or initializes the tool protocol.
    /// </summary>
    public FoundryToolProtocol Protocol { get; init; }

    /// <summary>
    /// Gets or initializes the project connection ID for the tool.
    /// </summary>
    public string ProjectConnectionId { get; init; }

    /// <summary>
    /// Gets the type string for API payloads (e.g., "mcp", "a2a").
    /// </summary>
    public string Type => Protocol switch
    {
        FoundryToolProtocol.MCP => "mcp",
        FoundryToolProtocol.A2A => "a2a",
        _ => throw new ArgumentOutOfRangeException(nameof(Protocol))
    };
}
