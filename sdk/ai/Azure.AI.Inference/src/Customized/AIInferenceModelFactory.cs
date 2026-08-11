// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Inference
{
    public static partial class AIInferenceModelFactory
    {
        // CUSTOM: ChatCompletions.Choices was made internal in favor of flattened properties, so the
        // generator omits this factory method; it is restored here for mocking support.
        /// <summary> Initializes a new instance of <see cref="Inference.ChatCompletions"/>. </summary>
        /// <param name="id"> A unique identifier associated with this chat completions response. </param>
        /// <param name="created"> The first timestamp associated with generation activity for this completions response. </param>
        /// <param name="model"> The model used for the chat completion. </param>
        /// <param name="choices"> The collection of completions choices associated with this completions response. </param>
        /// <param name="usage"> Usage information for tokens processed and generated as part of this completions operation. </param>
        /// <returns> A new <see cref="Inference.ChatCompletions"/> instance for mocking. </returns>
        public static ChatCompletions ChatCompletions(string id = null, DateTimeOffset created = default, string model = null, IEnumerable<ChatChoice> choices = null, CompletionsUsage usage = null)
        {
            choices ??= new List<ChatChoice>();

            return new ChatCompletions(id, created, model, choices.ToList(), usage, serializedAdditionalRawData: null);
        }
    }
}
