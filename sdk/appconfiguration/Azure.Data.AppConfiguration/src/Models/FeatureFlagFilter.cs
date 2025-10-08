// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Data.AppConfiguration
{
    /// <summary>
    /// A Feature filter represents a filter definition that should be evaluated by the consumer to determine if the feature is enabled.
    /// </summary>
    public partial class FeatureFlagFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagFilter"/>.
        /// </summary>
        /// <param name="name">The name of the feature filter. For example: PercentageFilter, TimeWindowFilter, TargetingFilter.</param>
        public FeatureFlagFilter(string name) : this(name, new Dictionary<string, object>())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureFlagFilter"/>.
        /// </summary>
        /// <param name="name">The name of the feature filter. For example: PercentageFilter, TimeWindowFilter, TargetingFilter.</param>
        /// <param name="parameters">Parameters of the feature filter.</param>
        public FeatureFlagFilter(string name, IDictionary<string, object> parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the name of the feature filter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the parameters of the feature filter.
        /// </summary>
        public IDictionary<string, object> Parameters { get; }
    }
}
