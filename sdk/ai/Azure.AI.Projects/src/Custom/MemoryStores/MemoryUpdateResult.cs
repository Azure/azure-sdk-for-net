// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects.Memory;

[CodeGenType("MemoryStoreUpdateResponse")]
public partial class MemoryUpdateResult
{
    /// <summary> Details of the memory-store update result. </summary>
    [CodeGenMember("Result")]
    public MemoryUpdateResultDetails Details { get; }

    [CodeGenMember("Error")]
    internal FoundryOpenAIError InternalError { get; }

    /// <summary> A human-readable description of the failure, or <c>null</c> when the update succeeded. </summary>
    public string ErrorDetails => InternalError?.ToExceptionMessage(0);
}
