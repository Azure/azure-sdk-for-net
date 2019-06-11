// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public abstract class ClientOptions
    {
        private HttpPipelineTransport _transport = HttpClientTransport.Shared;

        protected ClientOptions()
        {
            (string name, string version)= GetComponentNameAndVersion();

            TelemetryPolicy = new TelemetryPolicy(name, version);
            LoggingPolicy = LoggingPolicy.Shared;
            RetryPolicy = new RetryPolicy();
        }

        public HttpPipelineTransport Transport {
            get => _transport;
            set => _transport = value ?? throw new ArgumentNullException(nameof(value));
        }

        public TelemetryPolicy TelemetryPolicy { get; set; }

        public LoggingPolicy LoggingPolicy { get; set; }

        public RetryPolicy RetryPolicy { get; set; }

        public ResponseClassifier ResponseClassifier { get; set; } = new ResponseClassifier();

        public void AddPolicy(HttpPipelinePolicyPosition position, HttpPipelinePolicy policy)
        {
            switch (position)
            {
                case HttpPipelinePolicyPosition.PerCall:
                    PerCallPolicies.Add(policy);
                    break;
                case HttpPipelinePolicyPosition.PerRetry:
                    PerRetryPolicies.Add(policy);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(position), position, null);
            }
        }

        internal IList<HttpPipelinePolicy> PerCallPolicies { get; } = new List<HttpPipelinePolicy>();

        internal IList<HttpPipelinePolicy> PerRetryPolicies { get; } = new List<HttpPipelinePolicy>();

        private (string ComponentName, string ComponentVersion) GetComponentNameAndVersion()
        {
            Assembly clientAssembly = GetType().Assembly;
            AzureSdkClientLibraryAttribute componentAttribute = clientAssembly.GetCustomAttribute<AzureSdkClientLibraryAttribute>();
            if (componentAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AzureSdkClientLibraryAttribute)} is required to be set on client SDK assembly '{clientAssembly.FullName}'.");
            }

            return (componentAttribute.ComponentName, clientAssembly.GetName().Version.ToString());
        }

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}

