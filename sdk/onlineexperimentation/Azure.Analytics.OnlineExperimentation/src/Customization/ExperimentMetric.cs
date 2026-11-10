// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class ExperimentMetric
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="ExperimentMetric"/>. </summary>
        /// <param name="lifecycle"> Determines whether it is included in experiment analysis. </param>
        /// <param name="displayName"> A user-friendly display name for the experiment metric shown in reports and dashboards. </param>
        /// <param name="description"> A detailed description of the experiment metric. </param>
        /// <param name="categories"> Categories associated with the experiment metric. Used for organizing and filtering metrics. </param>
        /// <param name="desiredDirection"> The desired direction for changes in the metric value. </param>
        /// <param name="definition"> The metric definition specifying how the metric value is calculated from event data. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="displayName"/>, <paramref name="description"/>, <paramref name="categories"/> or <paramref name="definition"/> is null. </exception>
        public ExperimentMetric(LifecycleStage lifecycle, string displayName, string description, IEnumerable<string> categories, DesiredDirection desiredDirection, ExperimentMetricDefinition definition) : this()
        {
            Argument.AssertNotNull(displayName, nameof(displayName));
            Argument.AssertNotNull(description, nameof(description));
            Argument.AssertNotNull(categories, nameof(categories));
            Argument.AssertNotNull(definition, nameof(definition));

            Lifecycle = lifecycle;
            DisplayName = displayName;
            Description = description;
            foreach (string category in categories)
            {
                Categories.Add(category);
            }
            DesiredDirection = desiredDirection;
            Definition = definition;
        }
    }
}
