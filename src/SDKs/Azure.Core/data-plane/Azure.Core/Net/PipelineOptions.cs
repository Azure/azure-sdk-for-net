// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Http.Pipeline;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Core.Http
{
    public class PipelineOptions
    {
        static readonly PipelinePolicy s_default = new Default();

        PipelineTransport _transport;

        public ArrayPool<byte> Pool { get; set; } = ArrayPool<byte>.Shared;

        public PipelineTransport Transport {
            get => _transport;
            set {
                if (value == null) throw new ArgumentNullException(nameof(value));
                _transport = value;
            }
        }

        public PipelinePolicy TelemetryPolicy { get; set; } = s_default;

        public PipelinePolicy LoggingPolicy { get; set; } = s_default;

        public PipelinePolicy RetryPolicy { get; set; } = s_default;

        public PipelinePolicy[] PerCallPolicies = Array.Empty<PipelinePolicy>();

        public PipelinePolicy[] PerRetryPolicies = Array.Empty<PipelinePolicy>();

        public string ApplicationId { get; set; }

        public int PolicyCount {
            get {
                int numberOfPolicies = 3 + PerCallPolicies.Length + PerRetryPolicies.Length;
                if (LoggingPolicy == null) numberOfPolicies--;
                if (TelemetryPolicy == null) numberOfPolicies--;
                if (RetryPolicy == null) numberOfPolicies--;
                return numberOfPolicies;
            }
        }

        internal static bool IsDefault(PipelinePolicy policy)
         => policy == s_default;
        
        // TODO (pri 3): I am not happy with the design that needs a semtinel policy. 
        sealed class Default : PipelinePolicy
        {
            public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<PipelinePolicy> pipeline)
            {
                Debug.Fail("default policy should be removed");
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }
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

