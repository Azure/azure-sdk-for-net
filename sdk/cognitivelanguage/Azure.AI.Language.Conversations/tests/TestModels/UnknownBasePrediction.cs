// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.AI.Language.Conversations
{
    /// <summary> The UnknownBasePrediction. </summary>
    internal partial class UnknownBasePrediction : BasePrediction
    {
        /// <summary> Initializes a new instance of UnknownBasePrediction. </summary>
        /// <param name="projectKind"> The type of the project. </param>
        /// <param name="topIntent"> The intent with the highest score. </param>
        internal UnknownBasePrediction(ProjectKind projectKind, string topIntent) : base(projectKind, topIntent)
        {
            ProjectKind = projectKind;
        }
    }
}
