// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> This represents the prediction result of an Orchestration project. </summary>
    public partial class OrchestrationPrediction : BasePrediction
    {
        /// <summary> Initializes a new instance of OrchestrationPrediction. </summary>
        /// <param name="intents">
        /// A dictionary that contains all intents. A key is an intent name and a value is its confidence score and target type. The top intent&apos;s value also contains the actual response from the target project.
        /// Please note <see cref="TargetIntentResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ConversationTargetIntentResult"/>, <see cref="LuisTargetIntentResult"/>, <see cref="NoneLinkedTargetIntentResult"/> and <see cref="QuestionAnsweringTargetIntentResult"/>.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="intents"/> is null. </exception>
        internal OrchestrationPrediction(IReadOnlyDictionary<string, TargetIntentResult> intents)
        {
            Argument.AssertNotNull(intents, nameof(intents));

            Intents = intents;
            ProjectKind = ProjectKind.Orchestration;
        }

        /// <summary> Initializes a new instance of OrchestrationPrediction. </summary>
        /// <param name="projectKind"> The type of the project. </param>
        /// <param name="topIntent"> The intent with the highest score. </param>
        /// <param name="intents">
        /// A dictionary that contains all intents. A key is an intent name and a value is its confidence score and target type. The top intent&apos;s value also contains the actual response from the target project.
        /// Please note <see cref="TargetIntentResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ConversationTargetIntentResult"/>, <see cref="LuisTargetIntentResult"/>, <see cref="NoneLinkedTargetIntentResult"/> and <see cref="QuestionAnsweringTargetIntentResult"/>.
        /// </param>
        internal OrchestrationPrediction(ProjectKind projectKind, string topIntent, IReadOnlyDictionary<string, TargetIntentResult> intents) : base(projectKind, topIntent)
        {
            Intents = intents;
            ProjectKind = projectKind;
        }

        /// <summary>
        /// A dictionary that contains all intents. A key is an intent name and a value is its confidence score and target type. The top intent&apos;s value also contains the actual response from the target project.
        /// Please note <see cref="TargetIntentResult"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ConversationTargetIntentResult"/>, <see cref="LuisTargetIntentResult"/>, <see cref="NoneLinkedTargetIntentResult"/> and <see cref="QuestionAnsweringTargetIntentResult"/>.
        /// </summary>
        public IReadOnlyDictionary<string, TargetIntentResult> Intents { get; }
    }
}
