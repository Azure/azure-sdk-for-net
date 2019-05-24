// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core.Pipeline.Policies;

namespace Azure.Core.Pipeline
{
    public class HttpClientOptions
    {
        private HttpPipelineTransport _transport = HttpClientTransport.Shared;

        public HttpClientOptions()
        {
            TelemetryPolicy = new TelemetryPolicy(GetType().Assembly);
            LoggingPolicy = LoggingPolicy.Shared;
        }

        public HttpPipelineTransport Transport {
            get => _transport;
            set => _transport = value ?? throw new ArgumentNullException(nameof(value));
        }

        public TelemetryPolicy TelemetryPolicy { get; set; }

        public LoggingPolicy LoggingPolicy { get; set; }

        public ResponseClassifier ResponseClassifier { get; set; } = new ResponseClassifier();

        public IList<HttpPipelinePolicy> PerCallPolicies { get; } = new List<HttpPipelinePolicy>();

        public IList<HttpPipelinePolicy> PerRetryPolicies { get; } = new List<HttpPipelinePolicy>();

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

