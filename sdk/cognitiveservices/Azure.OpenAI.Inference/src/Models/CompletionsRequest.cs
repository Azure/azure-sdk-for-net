// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.OpenAI.Inference.Models
{
    public partial class CompletionsRequest
    {
        public CompletionsRequest(IList<string> prompt)
        {
            Prompt = prompt;
            Logit_bias = null;
            Stop = null;
        }
    }
}
