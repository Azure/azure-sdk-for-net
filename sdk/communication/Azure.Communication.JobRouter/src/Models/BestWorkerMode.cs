// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are distributed to the worker with the strongest abilities available. </summary>
    [CodeGenSuppress("BestWorkerMode", typeof(int), typeof(int))]
    public partial class BestWorkerMode : DistributionMode
    {
        //internal override string Kind => "best-worker";

        #region Default scoring rule

        /// <summary> Initializes a new instance of BestWorkerModePolicy with default scoring rule.
        ///
        /// Default scoring formula that uses the number of job labels that the worker labels match, as well as the number of label selectors the worker labels match and/or exceed
        /// using a logistic function (https://en.wikipedia.org/wiki/Logistic_function).
        /// </summary>
        /// <param name="minConcurrentOffers"> Governs the minimum desired number of active concurrent offers a job can have. By default, set to 1. </param>
        /// <param name="maxConcurrentOffers"> Governs the maximum number of active concurrent offers a job can have. By default, set to 1. </param>
        /// <param name="bypassSelectors"> (Optional) If set to true, then router will match workers to jobs even if they do not match label selectors. Default, set to false.
        /// Warning: You may get workers that are not qualified for the job they are matched with if you set this variable to true. This flag is intended more for temporary usage.
        /// </param>
        /// <param name="sortDescending"> (Optional) If false, will sort scores by ascending order. By default, set to true. </param>
        public BestWorkerMode(
            int minConcurrentOffers = 1,
            int maxConcurrentOffers = 1,
            bool bypassSelectors = false,
            bool sortDescending = true)
            : this(null, minConcurrentOffers, maxConcurrentOffers, bypassSelectors, null, new ScoringRuleOptions()
            {
                DescendingOrder = sortDescending
            })
        {
        }

        #endregion

        #region User specified scoring rule

        #region with paramerter selectors

        /// <summary> Initializes a new instance of BestWorkerModePolicy with user-specified scoring rule.
        ///
        /// Default scoring formula that uses the number of job labels that the worker labels match, as well as the number of label selectors the worker labels match and/or exceed
        /// using a logistic function (https://en.wikipedia.org/wiki/Logistic_function).
        /// </summary>
        /// <param name="scoringRule"> Defines a scoring rule to use, when calculating a score to determine the best worker. </param>
        /// <param name="scoringParameterSelectors"> (Optional) List of <see cref="ScoringRuleParameterSelector"/> that will be sent as part of the payload to scoring rule.</param>
        /// <param name="bypassSelectors"> (Optional) If set to true, then router will match workers to jobs even if they do not match label selectors. Default, set to false.
        ///     Warning: You may get workers that are not qualified for the job they are matched with if you set this variable to true. This flag is intended more for temporary usage.
        /// </param>
        /// <param name="allowScoringBatchOfWorkers"> (Optional) If true, will try to obtain scores for a batch of workers. By default, set to false. </param>
        /// <param name="batchSize"> (Optional) Set batch size when 'allowScoringBatchOfWorkers' is set to true to control batch size of workers to </param>
        /// <param name="sortDescending"> (Optional) If false, will sort scores by ascending order. By default, set to true. </param>
        /// <param name="minConcurrentOffers"> Governs the minimum desired number of active concurrent offers a job can have. By default, set to 1. </param>
        /// <param name="maxConcurrentOffers"> Governs the maximum number of active concurrent offers a job can have. By default, set to 1. </param>
        public BestWorkerMode(RouterRule scoringRule,
            IList<ScoringRuleParameterSelector> scoringParameterSelectors = default,
            bool bypassSelectors = false,
            bool allowScoringBatchOfWorkers = false,
            int? batchSize = default,
            bool sortDescending = true,
            int minConcurrentOffers = 1,
            int maxConcurrentOffers = 1)
            : this(null, minConcurrentOffers, maxConcurrentOffers, bypassSelectors, scoringRule, new ScoringRuleOptions()
            {
                BatchSize = batchSize,
                ScoringParameters = scoringParameterSelectors,
                DescendingOrder = sortDescending,
                AllowScoringBatchOfWorkers = allowScoringBatchOfWorkers
            })
        {
            if (batchSize.HasValue && batchSize.Value <= 0)
            {
                throw new ArgumentException("Value of batchSize has to be an integer greater than zero");
            }
        }

        #endregion with paramerter selectors

        #endregion User specified scoring rule
    }
}
