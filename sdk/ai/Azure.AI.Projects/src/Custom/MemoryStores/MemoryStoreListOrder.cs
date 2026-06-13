// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Memory;

[CodeGenType("PageOrder")]
public readonly partial struct MemoryStoreListOrder
{
    /// <summary> Sort results in ascending order by the <c>created_at</c> timestamp. </summary>
    [CodeGenMember("Asc")]
    public static MemoryStoreListOrder Ascending { get; } = new MemoryStoreListOrder(AscValue);

    /// <summary> Sort results in descending order by the <c>created_at</c> timestamp. </summary>
    [CodeGenMember("Desc")]
    public static MemoryStoreListOrder Descending { get; } = new MemoryStoreListOrder(DescValue);
}
