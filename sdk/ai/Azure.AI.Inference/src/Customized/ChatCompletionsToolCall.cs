// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Inference
{
    public partial class ChatCompletionsToolCall
    {
        // CUSTOM CODE NOTE:
        //   This code allows the concrete tool call type to directly pass through use of its underlying function
        //   rather than having a separate layer of indirection.

        /// <inheritdoc cref="FunctionCall.Name"/>
        public string Name
        {
            get => Function.Name;
            set => Function.Name = value;
        }

        /// <inheritdoc cref="FunctionCall.Arguments"/>
        public string Arguments
        {
            get => Function.Arguments;
            set => Function.Arguments = value;
        }
    }
}
