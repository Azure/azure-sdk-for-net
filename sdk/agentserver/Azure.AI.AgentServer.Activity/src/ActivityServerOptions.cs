// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Configuration options for the Activity protocol server.
/// </summary>
public class ActivityServerOptions
{
    /// <summary>
    /// Selects the outbound-auth model.
    ///
    /// <list type="bullet">
    ///   <item><c>false</c> (default) — <b>Simple agent</b> model: the agent
    ///     <em>instance</em> identity mints the Bot Connector token directly via
    ///     Managed Identity (<c>FOUNDRY_AGENT_INSTANCE_CLIENT_ID</c>) scoped to
    ///     <c>https://api.botframework.com/.default</c>. This is the standard
    ///     single-tenant Teams bot pattern.</item>
    ///   <item><c>true</c> — <b>Digital worker</b> model: the <em>blueprint</em>
    ///     identity (<c>FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID</c>) performs a 3-step
    ///     federated-identity (FMI) token exchange to obtain an agentic user
    ///     token.</item>
    /// </list>
    /// </summary>
    public bool DigitalWorker { get; set; } = false;
}
