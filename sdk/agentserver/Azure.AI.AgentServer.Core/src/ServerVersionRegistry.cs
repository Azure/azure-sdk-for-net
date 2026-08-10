// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

namespace Azure.AI.AgentServer.Core;

/// <summary>
/// Registry that collects version identity segments from protocol packages.
/// Each protocol registers its identity string (e.g., <c>azure-ai-agentserver-responses/1.0.0 (dotnet/10.0)</c>)
/// during route mapping, and the <see cref="Internal.ServerVersionMiddleware"/> reads all segments to compose the
/// final <c>x-platform-server</c> response header.
/// </summary>
public sealed class ServerVersionRegistry
{
    private readonly object _lock = new();
    private readonly List<string> _segments = new();

    /// <summary>
    /// Registers a protocol identity segment. Duplicate values are ignored.
    /// This method is thread-safe.
    /// </summary>
    /// <param name="identity">The identity string to register (e.g., <c>azure-ai-agentserver-responses/1.0.0 (dotnet/10.0)</c>).</param>
    public void Register(string identity)
    {
        ArgumentException.ThrowIfNullOrEmpty(identity);
        lock (_lock)
        {
            if (!_segments.Contains(identity))
            {
                _segments.Add(identity);
            }
        }
    }

    /// <summary>
    /// Returns all registered identity segments in registration order.
    /// </summary>
    public IReadOnlyList<string> GetSegments()
    {
        lock (_lock)
        {
            return _segments.ToArray();
        }
    }

    /// <summary>
    /// Builds a standard identity string from an SDK name and assembly version.
    /// Format: <c>{sdkName}/{version} (dotnet/{major}.{minor})</c>.
    /// </summary>
    /// <param name="sdkName">The SDK identifier (e.g., <c>azure-ai-agentserver-responses</c>).</param>
    /// <param name="assembly">The assembly to read the version from.</param>
    /// <returns>A formatted identity string.</returns>
    public static string BuildIdentityString(string sdkName, Assembly assembly)
    {
#if NET
        ArgumentException.ThrowIfNullOrEmpty(sdkName);
        ArgumentNullException.ThrowIfNull(assembly);
#else
        if (string.IsNullOrEmpty(sdkName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sdkName));
        if (assembly is null) throw new ArgumentNullException(nameof(assembly));
#endif
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
