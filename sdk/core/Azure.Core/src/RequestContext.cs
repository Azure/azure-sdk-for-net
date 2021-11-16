// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        internal Memory<HttpPipelinePolicy>? Policies { get; private set; }
        private const int PolicySections = 3;
        private const int SectionSize = 4;

        internal static int PerCallOffset => 0 * SectionSize;
        internal static int PerRetryOffset => 1 * SectionSize;
        internal static int BeforeTransportOffset => 2 * SectionSize;

        internal int PerCallPolicies { get; private set; }
        internal int PerRetryPolicies { get; private set; }
        internal int BeforeTransportPolicies { get; private set; }

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
            Policies ??= new Memory<HttpPipelinePolicy>(new HttpPipelinePolicy[PolicySections * SectionSize]);

            switch (position)
            {
                case HttpPipelinePosition.PerCall:
                    CheckPolicyCounter(PerCallPolicies);
                    Policies.Value.Span[PerCallPolicies++] = policy;
                    break;

                case HttpPipelinePosition.PerRetry:
                    CheckPolicyCounter(PerRetryPolicies);
                    Policies.Value.Span[SectionSize + PerRetryPolicies++] = policy;
                    break;

                case HttpPipelinePosition.BeforeTransport:
                    CheckPolicyCounter(BeforeTransportPolicies);
                    Policies.Value.Span[2 * SectionSize + BeforeTransportPolicies++] = policy;
                    break;

                default:
                    break;
            }
        }

        private static void CheckPolicyCounter(int length)
        {
            if (length >= SectionSize)
            {
                throw new InvalidOperationException($"Cannot add more than {SectionSize} policies at a pipeline position.");
            }
        }
    }
}
