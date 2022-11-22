// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownTargetIntentResult. </summary>
    internal partial class UnknownTargetIntentResult : TargetIntentResult
    {
        /// <summary> Initializes a new instance of UnknownTargetIntentResult. </summary>
        /// <param name="targetProjectKind"> This discriminator property specifies the type of the target project that returns the response. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal UnknownTargetIntentResult(TargetProjectKind targetProjectKind, string apiVersion, double confidence) : base(targetProjectKind, apiVersion, confidence)
        {
            TargetProjectKind = targetProjectKind;
        }
    }
}
