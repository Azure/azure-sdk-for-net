// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure
{
    /// <summary>
    /// Options which can be used to control the behavior of a request sent by a client.
    /// </summary>
    public class RequestContext
    {
        private readonly List<HttpPipelinePolicy> _perRetryPolicies = new();
        private readonly List<HttpPipelinePolicy> _perCallPolicies = new();
        private readonly List<HttpPipelinePolicy> _beforeTrasportPolicies = new();

        internal int PolicyCount => _perRetryPolicies.Count + _perCallPolicies.Count + _beforeTrasportPolicies.Count;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class.
        /// </summary>
        public RequestContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestContext"/> class using the given <see cref="ErrorOptions"/>.
        /// </summary>
        /// <param name="options"></param>
        public static implicit operator RequestContext(ErrorOptions options) => new RequestContext { ErrorOptions = options };

        /// <summary>
        /// The token to check for cancellation.
        /// </summary>
        public CancellationToken CancellationToken { get; set; } = CancellationToken.None;

        /// <summary>
        /// Controls under what conditions the operation raises an exception if the underlying response indicates a failure.
        /// </summary>
        public ErrorOptions ErrorOptions { get; set; } = ErrorOptions.Default;

        /// <summary>
        /// </summary>
        /// <param name="policy"></param>
        /// <param name="position"></param>
        public void AddPolicy(HttpPipelinePolicy policy, HttpPipelinePosition position)
        {
            switch (position)
            {
                case HttpPipelinePosition.PerCall:
                    _perCallPolicies.Add(policy);
                    HasPolicies = true;
                    break;
                case HttpPipelinePosition.PerRetry:
                    _perRetryPolicies.Add(policy);
                    HasPolicies = true;
                    break;
                case HttpPipelinePosition.BeforeTransport:
                    _beforeTrasportPolicies.Add(policy);
                    HasPolicies = true;
                    break;
                default:
                    break;
            }
        }

        internal int AppendPolicies(HttpPipelinePolicy[] target, HttpPipelinePosition position, int start)
        {
            var source = position switch
            {
                HttpPipelinePosition.PerCall => _perCallPolicies,
                HttpPipelinePosition.PerRetry => _perRetryPolicies,
                HttpPipelinePosition.BeforeTransport => _beforeTrasportPolicies,
                _ => throw new NotSupportedException("Unexpected 'position' value.")
            };

            int i = 0;
            foreach (var policy in source)
            {
                target[start + i++] = policy;
            }

            return i;
        }
    }
}
