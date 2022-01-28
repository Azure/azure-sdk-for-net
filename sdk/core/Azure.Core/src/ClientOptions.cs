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
        internal bool IsCustomTransportSet { get; private set; }

        /// <summary>
        /// Gets the default set of <see cref="ClientOptions"/>. Changes to the <see cref="Default"/> options would be reflected
        /// in new instances of <see cref="ClientOptions"/> type created after changes to <see cref="Default"/> were made.
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
        protected ClientOptions(): this(Default)
        {
        }

        internal ClientOptions(ClientOptions? clientOptions)
        {
            if (clientOptions != null)
            {
                Retry = new RetryOptions(clientOptions.Retry);

                Diagnostics = new DiagnosticsOptions(clientOptions.Diagnostics);

                _transport = clientOptions.Transport;
                if (clientOptions.Policies != null)
                {
                    Policies = new(clientOptions.Policies);
                }
            }
            else
            {
                // Intentionally leaving this null. The only consumer of this branch is
                // DefaultAzureCredential that would re-assign the value
                _transport = null!;
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
            set
            {
                _transport = value ?? throw new ArgumentNullException(nameof(value));
                IsCustomTransportSet = true;
            }
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
            if (position != HttpPipelinePosition.PerCall &&
                position != HttpPipelinePosition.PerRetry &&
                position != HttpPipelinePosition.BeforeTransport)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }

            Policies ??= new();
            Policies.Add((position, policy));
        }

        internal List<(HttpPipelinePosition Position, HttpPipelinePolicy Policy)>? Policies { get; private set; }

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
