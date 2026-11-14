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

    /// <summary>
    /// Additional connection query parameters, without a leading question mark. Foundry features may
    /// be supplied as <c>foundry_features</c> instead of a <c>Foundry-Features</c> header.
    /// The client ensures that the selected feature channel includes <c>VoiceAgents=V1Preview</c>.
    /// </summary>
    public string QueryString { get; set; }

    /// <summary>
    /// Additional connection headers. The client supplies authentication and ensures that
    /// <c>VoiceAgents=V1Preview</c> is included in <c>Foundry-Features</c> unless features are supplied in the query.
    /// </summary>
    public IDictionary<string, string> Headers { get; } = new Dictionary<string, string>();
}
