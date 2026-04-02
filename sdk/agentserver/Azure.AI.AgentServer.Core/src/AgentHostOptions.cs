// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Configuration options for the agent server host.
/// </summary>
public class AgentHostOptions
{
    /// <summary>
    /// Graceful shutdown timeout. Default: 30 seconds.
    /// During shutdown, in-flight requests are allowed to complete within this period.
    /// </summary>
    public TimeSpan ShutdownTimeout { get; set; } = TimeSpan.FromSeconds(30);

    /// <summary>
    /// Additional server identity string appended to the <c>x-platform-server</c> response header.
    /// </summary>
    public string? AdditionalServerIdentity { get; set; }

    /// <summary>
    /// Validates the options and throws <see cref="InvalidOperationException"/> if invalid.
    /// </summary>
    internal void Validate()
    {
        if (ShutdownTimeout <= TimeSpan.Zero)
        {
            throw new InvalidOperationException(
                $"ShutdownTimeout must be a positive duration, but was {ShutdownTimeout}.");
        }
    }
}
