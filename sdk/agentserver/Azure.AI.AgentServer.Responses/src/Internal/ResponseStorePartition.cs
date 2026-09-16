// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Cryptography;
using System.Text;
using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Responses.Internal;

internal readonly record struct ResponseStorePartition(string? UserIdKey)
{
    public static ResponseStorePartition FromContext(PlatformContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        return new(context.UserIdKey);
    }

    // Anonymous is a separate namespace, never a reserved user ID.
    public string DirectoryName => UserIdKey is null ? "anonymous" : "user-" + Hash(UserIdKey);

    public static string Hash(string value) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value))).ToLowerInvariant();
}
