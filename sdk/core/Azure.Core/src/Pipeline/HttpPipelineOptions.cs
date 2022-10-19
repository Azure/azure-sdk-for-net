// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Specifies configuration of options for building the <see cref="HttpPipeline"/>
    /// </summary>
    public class HttpPipelineOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HttpPipelineOptions"/>.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        public HttpPipelineOptions(ClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            ClientOptions = options;
            PerCallPolicies = new List<HttpPipelinePolicy>();
            PerRetryPolicies = new List<HttpPipelinePolicy>();
            RequestFailedDetailsParser = new DefaultRequestFailedDetailsParser();
            RetryConditions = new List<RetryCondition>();
        }

        /// <summary>
        /// The customer provided client options object.
        /// </summary>
        public ClientOptions ClientOptions { get; }

        /// <summary>
        /// Client provided per-call policies.
        /// </summary>
        public IList<HttpPipelinePolicy> PerCallPolicies { get; }

        /// <summary>
        /// Client provided per-retry policies.
        /// </summary>
        public IList<HttpPipelinePolicy> PerRetryPolicies { get; }

        /// <summary>
        /// Replacement for the default retry policy.
        /// </summary>
        public HttpPipelinePolicy? RetryPolicy { get; set; }

        /// <summary>
        /// Conditions to add to the default retry policy to help it decide whether to retry a request.
        /// </summary>
        public IList<RetryCondition> RetryConditions { get;}

        /// <summary>
        /// The client provided response classifier.
        /// </summary>
        public ResponseClassifier? ResponseClassifier { get; set; }

        /// <summary>
        /// Responsible for parsing the error content related to a failed request from the service.
        /// </summary>
        public RequestFailedDetailsParser RequestFailedDetailsParser { get; set; }
    }
}
