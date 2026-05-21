// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.Projects.Memory;

[Experimental("AAIP001")]
[CodeGenType("MemoryStoreUpdateResponse")]
public partial class MemoryUpdateResult
{
    [CodeGenMember("Result")]
    public MemoryUpdateResultDetails Details { get; }

    [CodeGenMember("Error")]
    internal FoundryOpenAIError InternalError { get; }

    public string ErrorDetails => InternalError?.ToExceptionMessage(0);
}
