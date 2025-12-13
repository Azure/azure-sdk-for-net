// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Exceptions;

/// <summary>
/// Exception thrown when MCP tool approval is required before invocation.
/// </summary>
public class MCPToolApprovalRequiredException : Exception
{
    /// <summary>
    /// Gets the approval arguments containing information about the approval request.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? ApprovalArguments { get; }

    /// <summary>
    /// Gets the payload containing additional error information.
    /// </summary>
    public IReadOnlyDictionary<string, object?>? Payload { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MCPToolApprovalRequiredException"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="approvalArguments">The approval arguments.</param>
    /// <param name="payload">Additional error payload.</param>
    public MCPToolApprovalRequiredException(
        string message,
        IReadOnlyDictionary<string, object?>? approvalArguments = null,
        IReadOnlyDictionary<string, object?>? payload = null)
        : base(message)
    {
        ApprovalArguments = approvalArguments;
        Payload = payload;
    }
}
