// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

namespace Azure.AI.AgentServer.Hosting;

/// <summary>
/// Registry that collects user-agent identity segments from protocol packages.
/// Each protocol registers its identity string (e.g., <c>azure-ai-agentserver-responses/1.0.0 (dotnet/10.0)</c>)
/// during route mapping, and the <c>ServerUserAgentMiddleware</c> reads all segments to compose the
/// final <c>x-platform-server</c> response header.
/// </summary>
public sealed class ServerUserAgentRegistry
{
    private readonly List<string> _segments = new();

    /// <summary>
    /// Registers a protocol identity segment. Duplicate values are ignored.
    /// </summary>
    /// <param name="identity">The identity string to register (e.g., <c>azure-ai-agentserver-responses/1.0.0 (dotnet/10.0)</c>).</param>
    public void Register(string identity)
    {
        ArgumentException.ThrowIfNullOrEmpty(identity);
        if (!_segments.Contains(identity))
        {
            _segments.Add(identity);
        }
    }

    /// <summary>
    /// Returns all registered identity segments in registration order.
    /// </summary>
    public IReadOnlyList<string> GetSegments() => _segments;

    /// <summary>
    /// Builds a standard identity string from an SDK name and assembly version.
    /// Format: <c>{sdkName}/{version} (dotnet/{major}.{minor})</c>.
    /// </summary>
    /// <param name="sdkName">The SDK identifier (e.g., <c>azure-ai-agentserver-responses</c>).</param>
    /// <param name="assembly">The assembly to read the version from.</param>
    /// <returns>A formatted identity string.</returns>
    public static string BuildIdentityString(string sdkName, Assembly assembly)
    {
        var version = assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
            .InformationalVersion ?? "0.0.0";

        var plusIdx = version.IndexOf('+');
        if (plusIdx >= 0)
        {
            version = version[..plusIdx];
        }

        var runtime = Environment.Version;
        return $"{sdkName}/{version} (dotnet/{runtime.Major}.{runtime.Minor})";
    }
}
