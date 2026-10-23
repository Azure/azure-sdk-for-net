// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Shared OpenTelemetry constants for the agent server hosting infrastructure.
/// </summary>
internal static class AgentHostTelemetry
{
    /// <summary>
    /// The attribute identifying Foundry spans and log records.
    /// </summary>
    public const string FoundryAttributeName = "microsoft.foundry";

    /// <summary>
    /// The string value of the Foundry telemetry marker.
    /// </summary>
    public const string FoundryAttributeValue = "True";

    /// <summary>
    /// The activity source name for the Responses protocol.
    /// </summary>
    public const string ResponsesSourceName = "Azure.AI.AgentServer.Responses";

    /// <summary>
    /// The activity source name for the Invocations protocol.
    /// </summary>
    public const string InvocationsSourceName = "Azure.AI.AgentServer.Invocations";

    /// <summary>
    /// The meter name for the Responses protocol.
    /// </summary>
    public const string ResponsesMeterName = "Azure.AI.AgentServer.Responses";

    /// <summary>
    /// The meter name for the Invocations protocol.
    /// </summary>
    public const string InvocationsMeterName = "Azure.AI.AgentServer.Invocations";
}
