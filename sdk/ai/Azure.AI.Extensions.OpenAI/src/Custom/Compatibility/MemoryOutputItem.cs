// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

#pragma warning disable AAIP001

namespace Azure.AI.Extensions.OpenAI;

public partial class MemoryOutputItem
{
    /// <summary> Gets or sets the time the memory was last updated. </summary>
    [CodeGenMember("UpdatedAt")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary> Gets or sets the time the memory was last updated. </summary>
    public DateTimeOffset UpdatedOn
    {
        get => UpdatedAt;
        set => UpdatedAt = value;
    }
}
