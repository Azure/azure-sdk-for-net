// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Memory;

[Experimental("AAIP001")]
[CodeGenType("PageOrder")]
public readonly partial struct MemoryStoreListOrder
{
    [CodeGenMember("Asc")]
    public static MemoryStoreListOrder Ascending { get; } = new MemoryStoreListOrder(AscValue);

    [CodeGenMember("Desc")]
    public static MemoryStoreListOrder Descending { get; } = new MemoryStoreListOrder(DescValue);
}
