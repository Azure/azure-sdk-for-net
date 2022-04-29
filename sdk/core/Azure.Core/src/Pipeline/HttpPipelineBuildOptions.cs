// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Specifies configuration of options for building the <see cref="HttpPipeline"/>
    /// </summary>
    public class HttpPipelineBuildOptions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="HttpPipelineBuildOptions"/>.
        /// </summary>
        /// <param name="options">The customer provided client options object.</param>
        /// <param name="perCallPolicies">Client provided per-call policies.</param>
        /// <param name="perRetryPolicies">Client provided per-retry policies.</param>
        /// <param name="responseClassifier">The client provided response classifier.</param>
        /// <param name="requestFailedDetailsParser"></param>
        public HttpPipelineBuildOptions(ClientOptions options, HttpPipelinePolicy[] perCallPolicies, HttpPipelinePolicy[] perRetryPolicies, ResponseClassifier? responseClassifier, RequestFailedDetailsParser? requestFailedDetailsParser = null)
        {
            ClientOptions = options;
            PerCallPolicies = perCallPolicies;
            PerRetryPolicies = perRetryPolicies;
            ResponseClassifier = responseClassifier;
            RequestFailedDetailsParser = requestFailedDetailsParser ?? new DefaultRequestFailedDetailsParser();
        }

        /// <summary>
        /// The customer provided client options object.
        /// </summary>
        public ClientOptions ClientOptions { get; set; }

        /// <summary>
        /// Client provided per-call policies.
        /// </summary>
        public HttpPipelinePolicy[] PerCallPolicies { get; set; }

        /// <summary>
        /// Client provided per-retry policies.
        /// </summary>
        public HttpPipelinePolicy[] PerRetryPolicies { get; set; }

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
