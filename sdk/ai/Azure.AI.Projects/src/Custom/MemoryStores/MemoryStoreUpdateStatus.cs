// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Memory;

/// <summary> Status of a memory store update operation. </summary>
[CodeGenType("MemoryStoreUpdateStatus")]
public enum MemoryStoreUpdateStatus
{
    /// <summary> Queued. </summary>
    Queued,
    /// <summary> InProgress. </summary>
    InProgress,
    /// <summary> Completed. </summary>
    Completed,
    /// <summary> Failed. </summary>
    Failed,
    /// <summary> Superseded. </summary>
    Superseded
}
