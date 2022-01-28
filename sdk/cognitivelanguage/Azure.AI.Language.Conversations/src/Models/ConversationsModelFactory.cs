// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class ConversationsModelFactory
    {
        /// <summary> Initializes a new instance of LuisTargetIntentResult. </summary>
        /// <param name="targetKind"> This discriminator property specifies the type of the target project that returns the response. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidenceScore"> The prediction score and it ranges from 0.0 to 1.0. </param>
        /// <param name="result"> The actual response from a LUIS Generally Available application. </param>
        /// <returns> A new <see cref="LuisTargetIntentResult"/> instance for mocking. </returns>
        public static LuisTargetIntentResult LuisTargetIntentResult(TargetKind targetKind = default, string apiVersion = null, double confidenceScore = default, object result = null)
        {
            return new LuisTargetIntentResult(targetKind, apiVersion, confidenceScore, result);
        }
    }
}
