// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.A2A.Internal;

internal sealed record A2ATaskScope(string? Tenant, string? UserId)
{
    private static readonly AsyncLocal<A2ATaskScope?> Scope = new();
    public static A2ATaskScope? Current { get => Scope.Value; set => Scope.Value = value; }
}
