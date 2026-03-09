// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects;

[CodeGenType("PageOrder")]
public readonly partial struct MemoryStoreListOrder
{
    [CodeGenMember("Asc")]
    public static MemoryStoreListOrder Ascending { get; } = new MemoryStoreListOrder(AscValue);

    [CodeGenMember("Desc")]
    public static MemoryStoreListOrder Descending { get; } = new MemoryStoreListOrder(DescValue);
}
