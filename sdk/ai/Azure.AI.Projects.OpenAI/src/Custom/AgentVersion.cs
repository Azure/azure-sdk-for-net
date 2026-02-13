// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("AgentVersionObject")]
public partial class AgentVersion
{
    /// <summary> The object type, which is always 'agent.version'. </summary>
    [CodeGenMember("Object")]
    internal string Object { get; } = "agent.version";
}
