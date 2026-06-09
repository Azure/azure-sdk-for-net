// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore shipped constructors/properties that latest TypeSpec generation normalized but cannot remove from the GA API surface.
    public partial class MachineLearningObjective
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        public MachineLearningObjective(MachineLearningGoal goal, string primaryMetric)
            : this(primaryMetric, goal)
        {
        }
    }
}
