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
    /// Converts the user information to a dictionary.
    /// </summary>
    /// <returns>A dictionary containing the user information.</returns>
    public IDictionary<string, object?> ToDictionary()
    {
        return new Dictionary<string, object?>
        {
            ["objectId"] = ObjectId,
            ["tenantId"] = TenantId
        };
    }
}
