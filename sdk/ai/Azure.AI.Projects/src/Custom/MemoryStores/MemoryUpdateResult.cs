// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Projects;

[CodeGenType("MemoryStoreUpdateResponse")]
public partial class MemoryUpdateResult
{
    [CodeGenMember("Result")]
    public MemoryUpdateResultDetails Details { get; }

    [CodeGenMember("Error")]
    internal FoundryOpenAIError InternalError { get; }

    public string ErrorDetails => InternalError?.ToExceptionMessage(0);
}
