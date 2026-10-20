// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Azure.AI.Projects;

/// <summary> Options for connecting to a Foundry Voice Agent using the native Live protocol. </summary>
[Experimental("AAIP001")]
public class ProjectsLiveSessionClientOptions
{
    /// <summary> Whether to persist this session's conversation in Foundry. Omission uses the agent's setting. </summary>
    public bool? Store { get; set; }

    /// <summary> An optional agent version to select instead of the configured endpoint version. </summary>
    public string AgentVersion { get; set; }

    /// <summary> Per-session JSON values for templates declared by the agent. </summary>
    public IDictionary<string, BinaryData> StructuredInputs { get; } = new Dictionary<string, BinaryData>();

    /// <summary> Additional query parameters for the WebSocket handshake, without a leading question mark. </summary>
    public string QueryString { get; set; }

    /// <summary> Additional handshake headers. Authentication and the Voice Agents preview header are supplied by the client. </summary>
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();
}
