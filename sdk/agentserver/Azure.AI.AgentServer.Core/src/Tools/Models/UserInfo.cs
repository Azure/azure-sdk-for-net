// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tools.Models;

/// <summary>
/// Represents user context information for tool invocations.
/// </summary>
/// <param name="ObjectId">The user's object ID.</param>
/// <param name="TenantId">The user's tenant ID.</param>
public record UserInfo(string ObjectId, string TenantId)
{
    /// <summary>
    /// Gets the user properties as a read-only dictionary.
    /// </summary>
    public IReadOnlyDictionary<string, string> Properties { get; } = new Dictionary<string, string>
    {
        ["objectId"] = ObjectId,
        ["tenantId"] = TenantId
    };
}
