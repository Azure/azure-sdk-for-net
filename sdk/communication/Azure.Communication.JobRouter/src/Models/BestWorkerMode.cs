// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are distributed to the worker with the strongest abilities available. </summary>
    [CodeGenModel("BestWorkerMode")]
    public partial class BestWorkerMode : DistributionMode, IUtf8JsonSerializable
    {
        #region Default scoring rule

        /// <summary> Initializes a new instance of BestWorkerModePolicy with default scoring rule.
        /// Default scoring formula that uses the number of job labels that the worker labels match, as well as the number of label selectors the worker labels match and/or exceed
        /// using a logistic function (https://en.wikipedia.org/wiki/Logistic_function).
        /// </summary>
        public BestWorkerMode() : this(null)
        {
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of BestWorkerModePolicy with user-specified scoring rule.
        /// </summary>
        /// <param name="scoringRule"> Defines a scoring rule to use, when calculating a score to determine the best worker. </param>
        /// <param name="scoringParameterSelectors"> (Optional) List of <see cref="ScoringRuleParameterSelector"/> that will be sent as part of the payload to scoring rule.</param>
        /// <param name="allowScoringBatchOfWorkers"> (Optional) If true, will try to obtain scores for a batch of workers. By default, set to false. </param>
        /// <param name="batchSize"> (Optional) Set batch size when 'allowScoringBatchOfWorkers' is set to true to control batch size of workers. Defaults to 20 if not set. </param>
        /// <param name="descendingOrder"> (Optional) If false, will sort scores by ascending order. By default, set to true. </param>
        public BestWorkerMode(RouterRule scoringRule,
            IList<ScoringRuleParameterSelector> scoringParameterSelectors = default,
            bool allowScoringBatchOfWorkers = false,
            int? batchSize = default,
            bool descendingOrder = true)
            : this(null)
        {
            if (batchSize is <= 0)
            {
                throw new ArgumentException("Value of batchSize has to be an integer greater than zero");
            }

            ScoringRule = scoringRule;
            ScoringRuleOptions = new ScoringRuleOptions
            {
                BatchSize = batchSize,
                AllowScoringBatchOfWorkers = allowScoringBatchOfWorkers,
                DescendingOrder = descendingOrder
            };

            if (scoringParameterSelectors is not null)
            {
                foreach (var scoringParameterSelector in scoringParameterSelectors)
                {
                    ScoringRuleOptions.ScoringParameters.Add(scoringParameterSelector);
                }
            }
        }

        internal BestWorkerMode(string kind)
        {
            Kind = kind ?? "best-worker";
        }

        /// <summary>
        /// Encapsulates all options that can be passed as parameters for scoring rule with BestWorkerMode.
        /// </summary>
        public ScoringRuleOptions ScoringRuleOptions { get; internal set; }

        /// <summary>
        /// Defines a scoring rule to use, when calculating a score to determine the best worker.
        /// </summary>
        public RouterRule ScoringRule { get; internal set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ScoringRule))
            {
                writer.WritePropertyName("scoringRule"u8);
                writer.WriteObjectValue(ScoringRule);
            }
            if (Optional.IsDefined(ScoringRuleOptions))
            {
                writer.WritePropertyName("scoringRuleOptions"u8);
                writer.WriteObjectValue(ScoringRuleOptions);
            }
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(MinConcurrentOffers))
            {
                writer.WritePropertyName("minConcurrentOffers"u8);
                writer.WriteNumberValue(MinConcurrentOffers);
            }
            if (Optional.IsDefined(MaxConcurrentOffers))
            {
                writer.WritePropertyName("maxConcurrentOffers"u8);
                writer.WriteNumberValue(MaxConcurrentOffers);
            }
            if (Optional.IsDefined(BypassSelectors))
            {
                writer.WritePropertyName("bypassSelectors"u8);
                writer.WriteBooleanValue(BypassSelectors.Value);
            }
            writer.WriteEndObject();
        }
    }
}
