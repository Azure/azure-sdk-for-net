// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Http.Pipeline;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Azure.Base.Http
{
    public partial struct HttpPipeline
    {
        public class Options
        {
            static readonly HttpPipelinePolicy s_default = new Default();

            HttpPipelineTransport _transport;

            public ArrayPool<byte> Pool { get; set; } = ArrayPool<byte>.Shared;

            public HttpPipelineTransport Transport {
                get => _transport;
                set {
                    if (value == null) throw new ArgumentNullException(nameof(value));
                    _transport = value;
                }
            }

            public HttpPipelinePolicy TelemetryPolicy { get; set; } = s_default;

            public HttpPipelinePolicy LoggingPolicy { get; set; } = s_default;

            public HttpPipelinePolicy RetryPolicy { get; set; } = s_default;

            public HttpPipelinePolicy[] PerCallPolicies = Array.Empty<HttpPipelinePolicy>();

            public HttpPipelinePolicy[] PerRetryPolicies = Array.Empty<HttpPipelinePolicy>();

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

            internal static bool IsDefault(HttpPipelinePolicy policy)
             => policy == s_default;

            // TODO (pri 3): I am not happy with the design that needs a sentinel policy. 
            sealed class Default : HttpPipelinePolicy
            {
                public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
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
}

