// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// The shared marker used to classify an <see cref="Exception"/> as a platform
/// (infrastructure) failure rather than a developer-handler or caller-input failure.
/// </summary>
/// <remarks>
/// Infrastructure code (for example outbound token acquisition) tags an exception via
/// <see cref="Tag"/> before it propagates; <see cref="ActivityErrorSourceFilter"/> reads the
/// marker via <see cref="IsTagged"/> to set the <c>x-platform-error-source</c> response header to
/// <c>platform</c>. This is a shared convention across the agent-server protocol packages — the
/// key string must not change.
/// </remarks>
internal static class PlatformErrorMarker
{
    /// <summary>The <see cref="System.Exception.Data"/> key that marks a platform error.</summary>
    public const string DataKey = "Azure.AI.AgentServer.PlatformError";

    /// <summary>Marks <paramref name="exception"/> as a platform (infrastructure) failure.</summary>
    /// <param name="exception">The exception to tag.</param>
    public static void Tag(Exception exception)
    {
        if (exception is not null)
        {
            exception.Data[DataKey] = true;
        }
    }

    /// <summary>Returns whether <paramref name="exception"/> is tagged as a platform failure.</summary>
    /// <param name="exception">The exception to inspect.</param>
    /// <returns><c>true</c> when the platform marker is present; otherwise <c>false</c>.</returns>
    public static bool IsTagged(Exception exception) => exception?.Data.Contains(DataKey) == true;
}
