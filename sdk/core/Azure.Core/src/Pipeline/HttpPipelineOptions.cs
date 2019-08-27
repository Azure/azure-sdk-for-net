// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Core.Pipeline
{
    public abstract class ClientOptions
    {
        private HttpPipelineTransport _transport = HttpClientTransport.Shared;

        protected ClientOptions()
        {
            Retry = new RetryOptions();
            Diagnostics = new DiagnosticsOptions();
            ResponseClassifier = new ResponseClassifier();
        }

        public HttpPipelineTransport Transport {
            get => _transport;
            set => _transport = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DiagnosticsOptions Diagnostics { get; }

        public RetryOptions Retry { get; }

        public ResponseClassifier ResponseClassifier { get; set; }

        public void AddPolicy(HttpPipelinePosition position, HttpPipelinePolicy policy)
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
