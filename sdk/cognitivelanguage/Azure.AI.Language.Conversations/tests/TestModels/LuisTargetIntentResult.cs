// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> It is a wrap up of LUIS Generally Available response. </summary>
    public partial class LuisTargetIntentResult : TargetIntentResult
    {
        /// <summary> Initializes a new instance of LuisTargetIntentResult. </summary>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal LuisTargetIntentResult(double confidence) : base(confidence)
        {
            TargetProjectKind = TargetProjectKind.Luis;
        }

        /// <summary> Initializes a new instance of LuisTargetIntentResult. </summary>
        /// <param name="targetProjectKind"> This discriminator property specifies the type of the target project that returns the response. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        /// <param name="result"> The actual response from a LUIS Generally Available application. </param>
        internal LuisTargetIntentResult(TargetProjectKind targetProjectKind, string apiVersion, double confidence, object result) : base(targetProjectKind, apiVersion, confidence)
        {
            Result = result;
            TargetProjectKind = targetProjectKind;
        }

        /// <summary> The actual response from a LUIS Generally Available application. </summary>
        public object Result { get; }
    }
}
