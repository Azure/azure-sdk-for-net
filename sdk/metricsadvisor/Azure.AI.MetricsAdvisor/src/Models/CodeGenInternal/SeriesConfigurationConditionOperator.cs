// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    internal readonly partial struct SeriesConfigurationConditionOperator
    {
        /// <summary>
        /// Converts this instance into an equivalent <see cref="DetectionConditionsOperator"/>.
        /// </summary>
        /// <returns>The equivalent <see cref="DetectionConditionsOperator"/>.</returns>
        /// <remarks>
        /// Currently, the swagger defines three types that are literally the same thing: SeriesConfiguration.conditionOperator,
        /// DimensionGroupConfiguration.conditionOperator and WholeMetricConfiguration.conditionOperator. We're exposing them as
        /// a single type: <see cref="DetectionConditionsOperator"/>. The service client still requires a
        /// <see cref="SeriesConfigurationConditionOperator"/> in its methods, though, so this method makes conversion easier.
        /// </remarks>
        internal DetectionConditionsOperator ConvertToDetectionConditionsOperator() => _value switch
        {
            ANDValue => DetectionConditionsOperator.And,
            ORValue => DetectionConditionsOperator.Or,
            null => new DetectionConditionsOperator(),
            _ => new DetectionConditionsOperator(_value)
        };
    }
}
