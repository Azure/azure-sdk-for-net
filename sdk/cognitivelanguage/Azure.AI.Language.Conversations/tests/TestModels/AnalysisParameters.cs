// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary>
    /// This is the parameter set of either the Orchestration project itself or one of the target services.
    /// Please note <see cref="AnalysisParameters"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ConversationParameters"/>, <see cref="LuisParameters"/> and <see cref="QuestionAnsweringParameters"/>.
    /// </summary>
    public partial class AnalysisParameters
    {
        /// <summary> Initializes a new instance of AnalysisParameters. </summary>
        public AnalysisParameters()
        {
        }

        /// <summary> The type of a target service. </summary>
        internal TargetProjectKind TargetProjectKind { get; set; }
        /// <summary> The API version to use when call a specific target service. </summary>
        public string ApiVersion { get; set; }
    }
}
