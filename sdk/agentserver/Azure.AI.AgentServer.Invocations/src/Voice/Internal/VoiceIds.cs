// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Invocations.Voice.Internal;

/// <summary>
/// Allocates collision-resistant protocol identifiers in one namespace.
/// </summary>
internal static class VoiceIds
{
    /// <summary>Returns a new random identifier in the form <c>{prefix}_{hex}</c>.</summary>
    public static string New(string prefix) => $"{prefix}_{Guid.NewGuid():N}";
}
