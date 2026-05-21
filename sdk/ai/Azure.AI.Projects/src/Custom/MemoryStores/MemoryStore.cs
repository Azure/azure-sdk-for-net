// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Memory;

[Experimental("AAIP001")]
[CodeGenType("MemoryStoreObject")]
public partial class MemoryStore
{
    /// <summary> The object type, which is always 'agent.version'. </summary>
    [CodeGenMember("Object")]
    internal string Object { get; } = "memory_store";
}
