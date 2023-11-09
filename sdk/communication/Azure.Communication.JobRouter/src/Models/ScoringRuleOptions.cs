// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ScoringRuleOptions : IUtf8JsonSerializable
    {
        /// <summary>
        /// (Optional) List of extra parameters from the job that will be sent as part of the payload to scoring rule.
        /// If not set, the job&apos;s labels (sent in the payload as `job`) and the job&apos;s worker selectors (sent in the payload as `selectors`)
        /// are added to the payload of the scoring rule by default.
        /// Note: Worker labels are always sent with scoring payload.
        /// </summary>
        public IList<ScoringRuleParameterSelector> ScoringParameters { get; } = new List<ScoringRuleParameterSelector>();

        /// <summary>
        /// (Optional) Set batch size when AllowScoringBatchOfWorkers is set to true.
        /// Defaults to 20 if not configured.
        /// </summary>
        public int? BatchSize { get; set; }

        /// <summary>
        /// (Optional)
        /// If set to true, will score workers in batches, and the parameter
        /// name of the worker labels will be sent as `workers`.
        /// By default, set to false
        /// and the parameter name for the worker labels will be sent as `worker`.
        /// Note: If enabled, use BatchSize to set batch size.
        /// </summary>
        public bool? IsBatchScoringEnabled { get; set; }

        /// <summary>
        /// (Optional)
        /// If false, will sort scores by ascending order. By default, set to
        /// true.
        /// </summary>
        public bool? DescendingOrder { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(BatchSize))
            {
                writer.WritePropertyName("batchSize"u8);
                writer.WriteNumberValue(BatchSize.Value);
            }
            if (Optional.IsCollectionDefined(ScoringParameters))
            {
                writer.WritePropertyName("scoringParameters"u8);
                writer.WriteStartArray();
                foreach (var item in ScoringParameters)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(IsBatchScoringEnabled))
            {
                writer.WritePropertyName("isBatchScoringEnabled"u8);
                writer.WriteBooleanValue(IsBatchScoringEnabled.Value);
            }
            if (Optional.IsDefined(DescendingOrder))
            {
                writer.WritePropertyName("descendingOrder"u8);
                writer.WriteBooleanValue(DescendingOrder.Value);
            }
            writer.WriteEndObject();
        }
    }
}
