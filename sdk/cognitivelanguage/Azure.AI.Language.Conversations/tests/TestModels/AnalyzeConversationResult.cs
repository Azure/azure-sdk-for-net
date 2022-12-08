// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents a conversation analysis response. </summary>
    public partial class AnalyzeConversationResult
    {
        /// <summary> Initializes a new instance of AnalyzeConversationResult. </summary>
        /// <param name="query"> The conversation utterance given by the caller. </param>
        /// <param name="prediction">
        /// The prediction result of a conversation project.
        /// Please note <see cref="BasePrediction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="OrchestrationPrediction"/> and <see cref="ConversationPrediction"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="query"/> or <paramref name="prediction"/> is null. </exception>
        internal AnalyzeConversationResult(string query, BasePrediction prediction)
        {
            Argument.AssertNotNull(query, nameof(query));
            Argument.AssertNotNull(prediction, nameof(prediction));

            Query = query;
            Prediction = prediction;
        }

        /// <summary> Initializes a new instance of AnalyzeConversationResult. </summary>
        /// <param name="query"> The conversation utterance given by the caller. </param>
        /// <param name="detectedLanguage"> The system detected language for the query in BCP 47 language representation.. </param>
        /// <param name="prediction">
        /// The prediction result of a conversation project.
        /// Please note <see cref="BasePrediction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="OrchestrationPrediction"/> and <see cref="ConversationPrediction"/>.
        /// </param>
        internal AnalyzeConversationResult(string query, string detectedLanguage, BasePrediction prediction)
        {
            Query = query;
            DetectedLanguage = detectedLanguage;
            Prediction = prediction;
        }

        /// <summary> The conversation utterance given by the caller. </summary>
        public string Query { get; }
        /// <summary> The system detected language for the query in BCP 47 language representation.. </summary>
        public string DetectedLanguage { get; }
        /// <summary>
        /// The prediction result of a conversation project.
        /// Please note <see cref="BasePrediction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="OrchestrationPrediction"/> and <see cref="ConversationPrediction"/>.
        /// </summary>
        public BasePrediction Prediction { get; }
    }
}
