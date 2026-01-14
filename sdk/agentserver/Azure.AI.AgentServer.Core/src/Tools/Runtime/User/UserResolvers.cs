// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Core.Tools.Runtime.User;

/// <summary>
/// Utility methods for resolving user information from HTTP context.
/// </summary>
public static class UserResolvers
{
    /// <summary>
    /// Resolves user information from HTTP headers.
    /// </summary>
    /// <param name="headers">The HTTP request headers.</param>
    /// <param name="objectIdHeader">The header name for the user's object ID. Defaults to "x-aml-oid".</param>
    /// <param name="tenantIdHeader">The header name for the user's tenant ID. Defaults to "x-aml-tid".</param>
    /// <returns>
    /// A <see cref="UserInfo"/> if both object ID and tenant ID headers are present and non-empty;
    /// otherwise, null.
    /// </returns>
    public static UserInfo? ResolveFromHeaders(
        IHeaderDictionary headers,
        string objectIdHeader = "x-aml-oid",
        string tenantIdHeader = "x-aml-tid")
    {
        if (!headers.TryGetValue(objectIdHeader, out var objectId) ||
            !headers.TryGetValue(tenantIdHeader, out var tenantId) ||
            string.IsNullOrEmpty(objectId) ||
            string.IsNullOrEmpty(tenantId))
        {
            return null;
        }

        return new UserInfo(objectId.ToString(), tenantId.ToString());
    }
}
