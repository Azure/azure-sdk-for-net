// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;

namespace Azure.Storage.Test
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
            NumberOfReadFailuresToSimulate = numberOfReadFailuresToSimulate;
            Simulate404 = simulate404;
            SecondaryUri = secondaryUri;
            HostsSetInRequests = new List<string>();
            TrackedRequestMethods = trackedRequestMethods ?? new List<RequestMethod>(new RequestMethod[] { RequestMethod.Get, RequestMethod.Head });
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!SimulateFailure(message))
            {
                ProcessNext(message, pipeline);
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!SimulateFailure(message))
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
        }

        private bool SimulateFailure(HttpMessage message)
        {
            if (TrackedRequestMethods.Contains(message.Request.Method))
            {
                CurrentInvocationNumber++;
                HostsSetInRequests.Add(message.Request.Uri.Host);
                if (CurrentInvocationNumber <= NumberOfReadFailuresToSimulate)
                {
                    message.Response = new MockResponse(Simulate404 && message.Request.Uri.Host == SecondaryUri.Host ? 404 : 429);
                    return true;
                }
            }
            return false;
        }
    }
}
