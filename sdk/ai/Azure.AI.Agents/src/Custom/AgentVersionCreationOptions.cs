// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents;

[CodeGenType("CreateAgentVersionRequest1")]
[CodeGenSuppress(nameof(AgentVersionCreationOptions), typeof(AgentDefinition))]
public partial class AgentVersionCreationOptions
{
    /// <summary> The agent definition. This can be a workflow, hosted agent, or a simple agent definition. </summary>
    [CodeGenMember("Definition")]
    internal AgentDefinition Definition { get; set; }

    /// <summary> A human-readable description of the agent. </summary>
    [CodeGenMember("Description")]
    public string Description { get; set; }

    public AgentVersionCreationOptions()
    {
        Metadata = new ChangeTrackingDictionary<string, string>();
    }

    internal AgentVersionCreationOptions GetClone()
    {
        AgentVersionCreationOptions copiedOptions = (AgentVersionCreationOptions)this.MemberwiseClone();

        if (_additionalBinaryDataProperties is not null)
        {
            copiedOptions._additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (KeyValuePair<string, BinaryData> sourcePair in _additionalBinaryDataProperties)
            {
                copiedOptions._additionalBinaryDataProperties[sourcePair.Key] = sourcePair.Value;
            }
        }

        return copiedOptions;
    }

    /// <summary> Keeps track of any properties unknown to the library. </summary>
    private protected IDictionary<string, BinaryData> _additionalBinaryDataProperties;
}
