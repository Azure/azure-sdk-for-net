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

    public AgentReference(string name, string version = null)
    {
        Name = name;
        Version = version;
        _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
    }

    public static implicit operator AgentReference(string agentName) => new(agentName);
}
