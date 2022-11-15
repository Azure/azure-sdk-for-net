// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// This is the base class of an intent prediction
    /// Please note <see cref="TargetIntentResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ConversationTargetIntentResult"/>, <see cref="LuisTargetIntentResult"/>, <see cref="NoneLinkedTargetIntentResult"/> and <see cref="QuestionAnsweringTargetIntentResult"/>.
    /// </summary>
    public partial class TargetIntentResult
    {
        /// <summary> Initializes a new instance of TargetIntentResult. </summary>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal TargetIntentResult(double confidence)
        {
            Confidence = confidence;
        }

        /// <summary> Initializes a new instance of TargetIntentResult. </summary>
        /// <param name="targetProjectKind"> This discriminator property specifies the type of the target project that returns the response. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidence"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal TargetIntentResult(TargetProjectKind targetProjectKind, string apiVersion, double confidence)
        {
            TargetProjectKind = targetProjectKind;
            ApiVersion = apiVersion;
            Confidence = confidence;
        }

        /// <summary> This discriminator property specifies the type of the target project that returns the response. </summary>
        internal TargetProjectKind TargetProjectKind { get; set; }
        /// <summary> The API version used to call a target service. </summary>
        public string ApiVersion { get; }
        /// <summary> The prediction score and it ranges from 0.0 to 1.0. </summary>
        public double Confidence { get; }
    }
}
