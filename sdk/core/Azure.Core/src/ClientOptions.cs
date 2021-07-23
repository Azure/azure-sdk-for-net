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
        private HttpPipelineTransport _transport;

        /// <summary>
        ///
        /// </summary>
        public static ClientOptions Default { get; private set; } = new DefaultClientOptions();

        // For testing
        internal static void ResetDefaultOptions()
        {
            Default = new DefaultClientOptions();
        }

        /// <summary>
        /// Creates a new instance of <see cref="ClientOptions"/>.
        /// </summary>
        protected ClientOptions(): this(true)
        {
        }

        internal ClientOptions(bool useDefaults)
        {
            if (useDefaults)
            {
                Retry = new RetryOptions
                {
                    MaxRetries = Default.Retry.MaxRetries,
                    Delay = Default.Retry.Delay,
                    MaxDelay = Default.Retry.MaxDelay,
                    Mode = Default.Retry.Mode,
                    NetworkTimeout = Default.Retry.NetworkTimeout
                };

                Diagnostics = new DiagnosticsOptions()
                {
                    ApplicationId = Default.Diagnostics.ApplicationId,
                    IsLoggingEnabled = Default.Diagnostics.IsLoggingEnabled,
                    IsTelemetryEnabled = Default.Diagnostics.IsTelemetryEnabled,
                    LoggedHeaderNames = new List<string>(Default.Diagnostics.LoggedHeaderNames),
                    LoggedQueryParameters = new List<string>(Default.Diagnostics.LoggedQueryParameters),
                    LoggedContentSizeLimit = Default.Diagnostics.LoggedContentSizeLimit,
                    IsDistributedTracingEnabled = Default.Diagnostics.IsDistributedTracingEnabled,
                    IsLoggingContentEnabled = Default.Diagnostics.IsLoggingContentEnabled
                };

                _transport = Default.Transport;
                PerCallPolicies = new List<HttpPipelinePolicy>(Default.PerCallPolicies);
                PerRetryPolicies = new List<HttpPipelinePolicy>(Default.PerRetryPolicies);
            }
            else
            {
                // Intentionally laving this null. The only consumer of this branch is
                // DefaultAzureCredential that would re-assign the value
                _transport = null!;
                PerCallPolicies = new List<HttpPipelinePolicy>();
                PerRetryPolicies = new List<HttpPipelinePolicy>();
                Diagnostics = new DiagnosticsOptions();
                Retry = new RetryOptions();
            }
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

        internal IList<HttpPipelinePolicy> PerCallPolicies { get; }

        internal IList<HttpPipelinePolicy> PerRetryPolicies { get; }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj) => base.Equals(obj);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string? ToString() => base.ToString();
    }
}
