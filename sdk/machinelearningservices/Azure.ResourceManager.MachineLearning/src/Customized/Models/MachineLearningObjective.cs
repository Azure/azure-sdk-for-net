// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningObjective
    {
        // The current generated constructor order follows TypeSpec, but GA exposed the Swagger-era primaryMetric-first overload.
        // TypeSpec decorators do not control constructor overload ordering, so keep the old overload and delegate to the generated shape.
        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        public MachineLearningObjective(MachineLearningGoal goal, string primaryMetric)
            : this(goal, primaryMetric, additionalBinaryDataProperties: null)
        {
        }

        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        public MachineLearningObjective(string primaryMetric, MachineLearningGoal goal)
            : this(goal, primaryMetric)
        {
        }
    }
}
