// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Inference {
    public partial class ChatCompletionsToolDefinition
    {
        // CUSTOM CODE NOTE:
        //   This code allows the concrete tool type to directly pass through use of its underlying function
        //   definition rather than having a separate layer of indirection.

        /// <inheritdoc cref="FunctionDefinition.Name"/>
        public string Name
        {
            get => Function.Name;
            set => Function.Name = value;
        }

        /// <inheritdoc cref="FunctionDefinition.Description"/>
        public string Description
        {
            get => Function.Description;
            set => Function.Description = value;
        }

        /// <inheritdoc cref="FunctionDefinition.Parameters"/>
        public BinaryData Parameters
        {
            get => Function.Parameters;
            set => Function.Parameters = value;
        }
    }
}
