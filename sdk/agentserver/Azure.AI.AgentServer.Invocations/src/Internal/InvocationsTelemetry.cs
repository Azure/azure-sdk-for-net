// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.AI.AgentServer.Invocations.Internal;

/// <summary>Shared tracing scope registered by the default AgentServer host.</summary>
internal static class InvocationsTelemetry
{
    public const string SourceName = "Azure.AI.AgentServer.Invocations";

    public static readonly ActivitySource ActivitySource = new(SourceName);
}
