// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary> Jobs are distributed to the worker with the strongest abilities available. </summary>
    public partial class BestWorkerMode
    {
        #region Default scoring rule

        /// <summary> Initializes a new instance of BestWorkerModePolicy with default scoring rule.
        /// Default scoring formula that uses the number of job labels that the worker labels match, as well as the number of label selectors the worker labels match and/or exceed
        /// using a logistic function (https://en.wikipedia.org/wiki/Logistic_function).
        /// </summary>
        public BestWorkerMode()
        {
            Kind = DistributionModeKind.BestWorker;
        }

        #endregion

        /// <summary>
        /// A rule of one of the following types:
        ///
        /// StaticRule:  A rule
        /// providing static rules that always return the same result, regardless of
        /// input.
        /// DirectMapRule:  A rule that return the same labels as the input
        /// labels.
        /// ExpressionRule: A rule providing inline expression
        /// rules.
        /// FunctionRule: A rule providing a binding to an HTTP Triggered Azure
        /// Function.
        /// WebhookRule: A rule providing a binding to a webserver following
        /// OAuth2.0 authentication protocol.
        /// Please note <see cref="RouterRule"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="DirectMapRouterRule"/>, <see cref="ExpressionRouterRule"/>, <see cref="FunctionRouterRule"/>, <see cref="StaticRouterRule"/> and <see cref="WebhookRouterRule"/>.
        /// </summary>
        public RouterRule ScoringRule { get; set; }

        /// <summary>
        /// Encapsulates all options that can be passed as parameters for scoring rule with
        /// BestWorkerMode
        /// </summary>
        public ScoringRuleOptions ScoringRuleOptions { get; set; }
    }
}
