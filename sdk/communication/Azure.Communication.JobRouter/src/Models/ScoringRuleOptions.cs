// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    [CodeGenModel("ScoringRuleOptions")]
    public partial class ScoringRuleOptions : IUtf8JsonSerializable
    {
        /// <summary>
        /// (Optional) List of extra parameters from the job that will be sent as part of the payload to scoring rule.
        /// If not set, the job&apos;s labels (sent in the payload as `job`) and the job&apos;s worker selectors (sent in the payload as `selectors`)
        /// are added to the payload of the scoring rule by default.
        /// Note: Worker labels are always sent with scoring payload.
        /// </summary>
        public IList<ScoringRuleParameterSelector> ScoringParameters { get; } = new List<ScoringRuleParameterSelector>();

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
            if (Optional.IsDefined(AllowScoringBatchOfWorkers))
            {
                writer.WritePropertyName("allowScoringBatchOfWorkers"u8);
                writer.WriteBooleanValue(AllowScoringBatchOfWorkers.Value);
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
