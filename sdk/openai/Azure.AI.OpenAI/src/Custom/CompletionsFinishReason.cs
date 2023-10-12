// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.OpenAI
{
    /// <summary> Representation of the manner in which a completions response concluded. </summary>
    public readonly partial struct CompletionsFinishReason
    {
        /// <summary> Initializes a new instance of <see cref="CompletionsFinishReason"/>. </summary>
        public CompletionsFinishReason(string value)
        {
            _value = value;
        }
    }
}
