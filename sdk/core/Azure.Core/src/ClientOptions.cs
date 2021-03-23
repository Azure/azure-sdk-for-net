// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Base type for all client option types, exposes various common client options like <see cref="Diagnostics"/>, <see cref="Retry"/>, <see cref="Transport"/>.
    /// </summary>
    public abstract class ClientOptions
    {
        private HttpPipelineTransport _transport = GetDefaultTransport();

        /// <summary>
        /// Creates a new instance of <see cref="ClientOptions"/>.
        /// </summary>
        protected ClientOptions()
        {
            Retry = new RetryOptions();
            Diagnostics = new DiagnosticsOptions();
        }

        /// <summary>
        /// The <see cref="HttpPipelineTransport"/> to be used for this client. Defaults to an instance of <see cref="HttpClientTransport"/>.
        /// </summary>
        public HttpPipelineTransport Transport
        {
            get => _transport;
            set => _transport = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the client diagnostic options.
        /// </summary>
        public DiagnosticsOptions Diagnostics { get; }

        /// <summary>
        /// Gets the client retry options.
        /// </summary>
        public RetryOptions Retry { get; }

        /// <summary>
        /// Adds an <see cref="HttpPipeline"/> policy into the client pipeline. The position of policy in the pipeline is controlled by <paramref name="position"/> parameter.
        /// If you want the policy to execute once per client request use <see cref="HttpPipelinePosition.PerCall"/> otherwise use <see cref="HttpPipelinePosition.PerRetry"/>
        /// to run the policy for every retry. Note that the same instance of <paramref name="policy"/> would be added to all pipelines of client constructed using this <see cref="ClientOptions"/> object.
        /// </summary>
        /// <param name="policy">The <see cref="HttpPipelinePolicy"/> instance to be added to the pipeline.</param>
        /// <param name="position">The position of policy in the pipeline.</param>
        public void AddPolicy(HttpPipelinePolicy policy, HttpPipelinePosition position)
        {
            switch (position)
            {
                case HttpPipelinePosition.PerCall:
                    PerCallPolicies.Add(policy);
                    break;
                case HttpPipelinePosition.PerRetry:
                    PerRetryPolicies.Add(policy);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }

        internal IList<HttpPipelinePolicy> PerCallPolicies { get; } = new List<HttpPipelinePolicy>();

        internal IList<HttpPipelinePolicy> PerRetryPolicies { get; } = new List<HttpPipelinePolicy>();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string? ToString() => base.ToString();

        private static HttpPipelineTransport GetDefaultTransport()
        {
#if NETFRAMEWORK
            bool GetSwitchValue(string switchName, string envVariable)
            {
                if (!AppContext.TryGetSwitch(switchName, out bool ret))
                {
                    string? switchValue = Environment.GetEnvironmentVariable(envVariable);
                    if (switchValue != null)
                    {
                        ret = string.Equals("true", switchValue, StringComparison.InvariantCultureIgnoreCase) ||
                              switchValue.Equals("1", StringComparison.InvariantCultureIgnoreCase);
                    }
                }

                return ret;
            }

            if (!GetSwitchValue("Azure.Core.Pipeline.DisableHttpWebRequestTransport", "AZURE_CORE_DISABLE_HTTPWEBREQUESTTRANSPORT"))
            {
                return HttpWebRequestTransport.Shared;
            }
#endif
            return HttpClientTransport.Shared;
        }
    }
}
