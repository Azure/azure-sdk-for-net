// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public readonly partial struct CompletionsFinishReason
{
    // CUSTOM CODE NOTE:
    //   This allows us to properly represent a nullable enum-like type, where we don't want to assert on null
    //   string inputs.

    /// <summary> Initializes a new instance of <see cref="CompletionsFinishReason"/>. </summary>
    public CompletionsFinishReason(string value)
    {
        _value = value;
    }
}
