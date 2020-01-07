// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;

namespace Azure.Storage.Test
{
    public class TestExceptionPolicy : HttpPipelinePolicy
    {
        public List<string> HostsSetInRequests { get; private set; }

        public List<DateTime> DatesSetInRequests { get; private set; }

        private int CurrentInvocationNumber { get; set; }

        private int NumberOfFailuresToSimulate { get; set; }

        private Uri SecondaryUri { get; set; }

        private bool Simulate404 { get; set; }

        private List<RequestMethod> TrackedRequestMethods { get; set; }

        private readonly int _delayBetweenAttempts;

        public TestExceptionPolicy(
            int numberOfFailuresToSimulate,
            Uri secondaryUri,
            bool simulate404 = false,
            List<RequestMethod> trackedRequestMethods = null,
            int delayBetweenAttempts = default)
        {
            NumberOfFailuresToSimulate = numberOfFailuresToSimulate;
            Simulate404 = simulate404;
            SecondaryUri = secondaryUri;
            HostsSetInRequests = new List<string>();
            DatesSetInRequests = new List<DateTime>();
            TrackedRequestMethods = trackedRequestMethods ?? new List<RequestMethod>(new RequestMethod[] { RequestMethod.Get, RequestMethod.Head });
            _delayBetweenAttempts = delayBetweenAttempts;
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!SimulateFailureAsync(message, false).EnsureCompleted())
            {
                ProcessNext(message, pipeline);
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            if (!await SimulateFailureAsync(message, true))
            {
                await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
            }
        }

        private async Task<bool> SimulateFailureAsync(HttpMessage message, bool async)
        {
            if (TrackedRequestMethods.Contains(message.Request.Method))
            {
                if (_delayBetweenAttempts > 0)
                {
                    if (async)
                    {
                        await Task.Delay(_delayBetweenAttempts);
                    }
                    else
                    {
                        Thread.Sleep(_delayBetweenAttempts);
                    }
                }
                CurrentInvocationNumber++;
                HostsSetInRequests.Add(message.Request.Uri.Host);
                if (message.Request.Headers.TryGetValue("x-ms-date", out string date))
                {
                    DatesSetInRequests.Add(Convert.ToDateTime(date));
                }
                if (CurrentInvocationNumber <= NumberOfFailuresToSimulate)
                {
                    message.Response = new MockResponse(Simulate404 && message.Request.Uri.Host == SecondaryUri.Host ? 404 : 429);
                    return true;
                }
            }
            return false;
        }
    }
}
