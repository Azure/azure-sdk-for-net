// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> A wrap up of Conversation project response. </summary>
    public partial class ConversationTargetIntentResult : TargetIntentResult
    {
        /// <summary> Initializes a new instance of ConversationTargetIntentResult. </summary>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal ConversationTargetIntentResult(double confidence) : base(confidence)
        {
            TargetProjectKind = TargetProjectKind.Conversation;
        }

        /// <summary> Initializes a new instance of ConversationTargetIntentResult. </summary>
        /// <param name="targetProjectKind"> This discriminator property specifies the type of the target project that returns the response. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        /// <param name="result"> The actual response from a Conversation project. </param>
        internal ConversationTargetIntentResult(TargetProjectKind targetProjectKind, string apiVersion, double confidence, ConversationResult result) : base(targetProjectKind, apiVersion, confidence)
        {
            Result = result;
            TargetProjectKind = targetProjectKind;
        }

        /// <summary> The actual response from a Conversation project. </summary>
        public ConversationResult Result { get; }
    }
}
