// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Extensions.OpenAI;

public abstract partial class MemoryOutputItem
{
    /// <summary> The last update time of the memory item. </summary>
    [CodeGenMember("UpdatedOn")]
    public DateTimeOffset UpdatedAt { get; set; }
}
