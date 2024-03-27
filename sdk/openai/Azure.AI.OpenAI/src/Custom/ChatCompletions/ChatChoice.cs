// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public partial class ChatChoice
{
    // CUSTOM CODE NOTE:
    //   This demotes the visibility of the internal "delta" field of a choice, which is otherwise exposed for
    //   streaming use.

    internal ChatResponseMessage InternalStreamingDeltaMessage { get; }
}
