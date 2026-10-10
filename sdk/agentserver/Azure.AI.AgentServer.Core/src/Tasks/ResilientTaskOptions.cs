// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks;

/// <summary>
/// Controls whether the resilient-task runtime is active for an application host.
/// </summary>
public class ResilientTaskOptions
{
    /// <summary>
    /// Gets or sets whether the host initializes durable task storage, runs startup recovery, and
    /// starts the periodic recovery loop. The default is <see langword="false"/>.
    /// </summary>
    public bool Enabled { get; set; }
}
