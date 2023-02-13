// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// This is the base class of prediction
    /// Please note <see cref="BasePrediction"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="OrchestrationPrediction"/> and <see cref="ConversationPrediction"/>.
    /// </summary>
    public partial class BasePrediction
    {
        /// <summary> Initializes a new instance of BasePrediction. </summary>
        internal BasePrediction()
        {
        }

        /// <summary> Initializes a new instance of BasePrediction. </summary>
        /// <param name="projectKind"> The type of the project. </param>
        /// <param name="topIntent"> The intent with the highest score. </param>
        internal BasePrediction(ProjectKind projectKind, string topIntent)
        {
            ProjectKind = projectKind;
            TopIntent = topIntent;
        }

        /// <summary> The type of the project. </summary>
        internal ProjectKind ProjectKind { get; set; }
        /// <summary> The intent with the highest score. </summary>
        public string TopIntent { get; }
    }
}
