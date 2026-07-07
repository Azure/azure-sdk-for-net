// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Extensions.OpenAI;

[CodeGenType("AgentReference")]
[CodeGenSuppress(nameof(AgentReference), typeof(string))]
public partial class AgentReference
{
    /// <summary> The version identifier of the agent. </summary>
    [CodeGenMember("Version")]
    public string Version { get; }

    /// <summary> Initializes a new instance of <see cref="AgentReference"/>. </summary>
    /// <param name="name"> The name of the agent. </param>
    /// <param name="version"> The optional version identifier of the agent. </param>
    public AgentReference(string name, string version = null)
    {
        Name = name;
        Version = version;
        _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
    }

    /// <summary> Converts a string assistant or agent identifier into an <see cref="AgentReference"/>. </summary>
    /// <param name="agentName"> The assistant or agent identifier. </param>
    /// <returns> The agent reference created from the supplied identifier. </returns>
    public static implicit operator AgentReference(string agentName) => new(agentName);
}
