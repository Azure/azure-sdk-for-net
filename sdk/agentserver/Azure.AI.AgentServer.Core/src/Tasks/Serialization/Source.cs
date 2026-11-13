// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Azure.AI.AgentServer.Core.Tasks.Serialization;

/// <summary>
/// The <c>source</c> portion of a task record. <see cref="Name"/> is the
/// canonical identity anchor used to route a recovered task back to its
/// registered handler.
/// </summary>
internal sealed class Source
{
    /// <summary>The source type discriminator; always <c>agentserver.task</c>.</summary>
    public string Type { get; set; } = TaskWireKeys.SourceTypeValue;

    /// <summary>The registered task name — the recovery routing key.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>The composed server version string, <c>&lt;sdk&gt;/&lt;ver&gt; (&lt;runtime&gt;/&lt;ver&gt;)</c>.</summary>
    public string ServerVersion { get; set; } = string.Empty;

    /// <summary>
    /// Immutable creation provenance stamped from <c>FOUNDRY_HOSTING_ENVIRONMENT</c>
    /// (always written; empty string when unset/local). Absent (<see langword="null"/>)
    /// only when reconstructed from a record that predates the field.
    /// </summary>
    public string? HostingEnvironment { get; set; }

    /// <summary>
    /// Unknown/forward-compat <c>source</c> fields preserved verbatim so a round-trip
    /// through .NET never drops extension keys written by another implementation (§28a.3).
    /// </summary>
    private readonly Dictionary<string, JsonNode?> _extensions = new(System.StringComparer.Ordinal);

    /// <summary>Reconstructs a <see cref="Source"/> from its JSON object form, or <see langword="null"/>.</summary>
    /// <param name="node">The JSON node holding the source, or <see langword="null"/>.</param>
    /// <returns>The parsed source, or <see langword="null"/> when absent.</returns>
    public static Source? FromJson(JsonNode? node)
    {
        if (node is not JsonObject obj)
        {
            return null;
        }

        var source = new Source
        {
            Type = (string?)obj[TaskWireKeys.SourceType] ?? TaskWireKeys.SourceTypeValue,
            Name = (string?)obj[TaskWireKeys.SourceName] ?? string.Empty,
            ServerVersion = (string?)obj[TaskWireKeys.SourceServerVersion] ?? string.Empty,
            HostingEnvironment = (string?)obj[TaskWireKeys.SourceHostingEnvironment],
        };

        foreach (KeyValuePair<string, JsonNode?> pair in obj)
        {
            if (pair.Key is TaskWireKeys.SourceType or TaskWireKeys.SourceName
                or TaskWireKeys.SourceServerVersion or TaskWireKeys.SourceHostingEnvironment)
            {
                continue;
            }

            source._extensions[pair.Key] = pair.Value?.DeepClone();
        }

        return source;
    }

    /// <summary>Projects this source to its JSON object form.</summary>
    /// <returns>A <see cref="JsonObject"/> with the source fields.</returns>
    public JsonObject ToJson()
    {
        var obj = new JsonObject
        {
            [TaskWireKeys.SourceType] = Type,
            [TaskWireKeys.SourceName] = Name,
            [TaskWireKeys.SourceServerVersion] = ServerVersion,
        };

        if (HostingEnvironment is not null)
        {
            obj[TaskWireKeys.SourceHostingEnvironment] = HostingEnvironment;
        }

        foreach (KeyValuePair<string, JsonNode?> pair in _extensions)
        {
            obj[pair.Key] = pair.Value?.DeepClone();
        }

        return obj;
    }
}
