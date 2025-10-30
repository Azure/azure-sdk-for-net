// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents;

[CodeGenType("MemoryStoreUpdateResponse")]
public partial class MemoryUpdateResult
{
    [CodeGenMember("Result")]
    public MemoryUpdateResultDetails Details { get; }
}
