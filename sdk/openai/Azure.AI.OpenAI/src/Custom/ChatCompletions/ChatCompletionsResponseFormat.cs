// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.OpenAI;

public abstract partial class ChatCompletionsResponseFormat
{
    /// <inheritdoc cref="ChatCompletionsTextResponseFormat" />
    public static readonly ChatCompletionsResponseFormat Text = new ChatCompletionsTextResponseFormat();

    /// <inheritdoc cref="ChatCompletionsJsonResponseFormat" />
    public static readonly ChatCompletionsResponseFormat JsonObject = new ChatCompletionsJsonResponseFormat();
}
