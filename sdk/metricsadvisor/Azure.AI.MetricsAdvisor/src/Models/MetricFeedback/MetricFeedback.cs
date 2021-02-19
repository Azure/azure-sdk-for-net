// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> <see cref="MetricFeedback"/>s are used to describe feedback on unsatisfactory anomaly detection results.
    /// When feedback is created for a given metric, it is applied to future anomaly detection processing of the same series.
    /// The processed points will not be re-calculated. </summary>
    public abstract partial class MetricFeedback : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of the <see cref="MetricFeedback"/> class. </summary>
        /// <param name="metricId"> The metric unique Id. </param>
        /// <param name="dimensionFilter"> The <see cref="FeedbackDimensionFilter" /> to apply to the feedback. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dimensionFilter"/> is null. </exception>
        internal MetricFeedback(string metricId, FeedbackDimensionFilter dimensionFilter)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNull(dimensionFilter, nameof(dimensionFilter));

            MetricId = metricId;
            DimensionFilter = dimensionFilter;
        }

        /// <summary> The <see cref="FeedbackType"/> of this feedback.</summary>
        [CodeGenMember("FeedbackType")]
        public FeedbackType Type { get; internal set; }

        /// <summary> feedback unique id. </summary>
        [CodeGenMember("FeedbackId")]
        public string Id { get; }

        /// <summary> feedback created time. </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary> user who gives this feedback. </summary>
        public string UserPrincipal { get; }

        /// <summary> metric unique id. </summary>
        public string MetricId { get; }

        /// <summary> The dimension filter. </summary>
        public FeedbackDimensionFilter DimensionFilter { get; internal set; }

        internal static MetricFeedback DeserializeMetricFeedback(JsonElement element)
        {
            if (element.TryGetProperty("feedbackType", out JsonElement discriminator))
            {
                var discriminatorString = discriminator.GetString();

                switch (discriminatorString)
                {
                    case "Anomaly":
                        return MetricAnomalyFeedback.DeserializeMetricAnomalyFeedback(element);
                    case "ChangePoint":
                        return MetricChangePointFeedback.DeserializeMetricChangePointFeedback(element);
                    case "Comment":
                        return MetricCommentFeedback.DeserializeMetricCommentFeedback(element);
                    case "Period":
                        return MetricPeriodFeedback.DeserializeMetricPeriodFeedback(element);
                    default:
                        throw new ArgumentException($"Unknown feedback type returned by the service: {discriminatorString}");
                }
            }
            else
            {
                throw new ArgumentException("The feedback type was not returned by the service");
            }
        }
    }
}
