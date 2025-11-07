// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

[CodeGenType("MemoryStoreObject")]
public partial class MemoryStore
{
    /// <summary> The object type, which is always 'agent.version'. </summary>
    [CodeGenMember("Object")]
    internal string Object { get; } = "agent.version";
}
