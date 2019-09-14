// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Testing;

namespace Azure.Storage.Common.Test
{
    public class TestExceptionPolicy : HttpPipelinePolicy
    {
        public List<string> HostsSetInRequests { get; private set; }

        private int CurrentInvocationNumber { get; set; }

        private int NumberOfReadFailuresToSimulate { get; set; }

        private Uri SecondaryUri { get; set; }

        private bool Simulate404 { get; set; }

        private List<RequestMethod> TrackedRequestMethods { get; set; }

        public TestExceptionPolicy(int numberOfReadFailuresToSimulate, Uri secondaryUri, bool simulate404 = false, List<RequestMethod> trackedRequestMethods = null)
        {
            this.NumberOfReadFailuresToSimulate = numberOfReadFailuresToSimulate;
            this.Simulate404 = simulate404;
            this.SecondaryUri = secondaryUri;
            this.HostsSetInRequests = new List<string>();
            this.TrackedRequestMethods = trackedRequestMethods ?? new List<RequestMethod>(new RequestMethod[] { RequestMethod.Get, RequestMethod.Head });
        }

        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!this.SimulateFailure(message))
            {
                ProcessNext(message, pipeline);
            }
        }

        public override async ValueTask ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!this.SimulateFailure(message))
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
        }

        private bool SimulateFailure(HttpPipelineMessage message)
        {
            if (this.TrackedRequestMethods.Contains(message.Request.Method))
            {
                this.CurrentInvocationNumber++;
                this.HostsSetInRequests.Add(message.Request.UriBuilder.Host);
                if (this.CurrentInvocationNumber <= this.NumberOfReadFailuresToSimulate)
                {
                    message.Response = new MockResponse(this.Simulate404 && message.Request.UriBuilder.Host == this.SecondaryUri.Host ? 404 : 429);
                    return true;
                }
            }
            return false;
        }
    }
}
