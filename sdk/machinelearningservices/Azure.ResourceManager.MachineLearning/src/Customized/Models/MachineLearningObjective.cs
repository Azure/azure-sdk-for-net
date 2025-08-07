// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Optimization objective. </summary>
    public partial class MachineLearningObjective
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningObjective"/>. </summary>
        /// <param name="goal"> [Required] Defines supported metric goals for hyperparameter tuning. </param>
        /// <param name="primaryMetric"> [Required] Name of the metric to optimize. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="primaryMetric"/> is null. </exception>
        public MachineLearningObjective(MachineLearningGoal goal, string primaryMetric)
        {
            Argument.AssertNotNull(primaryMetric, nameof(primaryMetric));

            PrimaryMetric = primaryMetric;
            Goal = goal;
        }
    }
}
