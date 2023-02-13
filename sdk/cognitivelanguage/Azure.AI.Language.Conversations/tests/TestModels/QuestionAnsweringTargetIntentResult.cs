// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> It is a wrap up a Question Answering KB response. </summary>
    public partial class QuestionAnsweringTargetIntentResult : TargetIntentResult
    {
        /// <summary> Initializes a new instance of QuestionAnsweringTargetIntentResult. </summary>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal QuestionAnsweringTargetIntentResult(double confidence) : base(confidence)
        {
            TargetProjectKind = TargetProjectKind.QuestionAnswering;
        }

        /// <summary> Initializes a new instance of QuestionAnsweringTargetIntentResult. </summary>
        /// <param name="targetProjectKind"> This discriminator property specifies the type of the target project that returns the response. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        /// <param name="result"> The generated answer by a Question Answering KB. </param>
        internal QuestionAnsweringTargetIntentResult(TargetProjectKind targetProjectKind, string apiVersion, double confidence, AnswersResult result) : base(targetProjectKind, apiVersion, confidence)
        {
            Result = result;
            TargetProjectKind = targetProjectKind;
        }

        /// <summary> The generated answer by a Question Answering KB. </summary>
        public AnswersResult Result { get; }
    }
}
