// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

namespace Azure.AI.Projects;

/// <summary> Connection options for a Foundry GPT Live voice agent. </summary>
[Experimental("AAIP001")]
public class ProjectsLiveSessionClientOptions
{
    /// <summary> Whether to save the conversation in Foundry. If unset, uses the agent's storage setting. </summary>
    public bool? Store { get; set; }

    /// <summary> The agent version to use instead of the endpoint's configured version. </summary>
    public string AgentVersion { get; set; }

    /// <summary> JSON values for the agent's structured input templates. </summary>
    public IDictionary<string, BinaryData> StructuredInputs { get; } = new Dictionary<string, BinaryData>();

    /// <summary> Additional connection query parameters, without a leading question mark. </summary>
    public string QueryString { get; set; }

    /// <summary> Additional connection headers. The client supplies authentication and Voice Agents preview headers. </summary>
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();
}
