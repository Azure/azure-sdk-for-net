// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks.Engine;

internal static class MemorySnapshotSettings
{
    internal const string EnvironmentVariable = "FOUNDRY_MEMORY_SNAPSHOT_ENABLED";

    public static bool ReadEnabled()
    {
        string? raw = Environment.GetEnvironmentVariable(EnvironmentVariable);
        if (raw is null)
        {
            return false;
        }

        return Parse(raw);
    }

    internal static bool Parse(string raw)
    {
        string value = raw.Trim();
        if (string.Equals(value, bool.TrueString, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        if (string.Equals(value, bool.FalseString, StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        throw new InvalidOperationException(
            $"{EnvironmentVariable} must be 'true' or 'false' when set.");
    }
}
