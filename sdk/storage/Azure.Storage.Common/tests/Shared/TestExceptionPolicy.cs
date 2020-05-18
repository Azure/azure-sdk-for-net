// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Storage.Test
{
    public class TestExceptionPolicy : HttpPipelinePolicy
    {
        public List<string> HostsSetInRequests { get; private set; }

        public List<DateTime> DatesSetInRequests { get; private set; }

        private int _currentInvocationNumber;

        private readonly int _numberOfFailuresToSimulate;

        private readonly Uri _secondaryUri;

        private readonly bool _simulate404;

        private readonly List<RequestMethod> _trackedRequestMethods;

        private readonly int _delayBetweenAttempts;

        public TestExceptionPolicy(
            int numberOfFailuresToSimulate,
            Uri secondaryUri = default,
            bool simulate404 = false,
            List<RequestMethod> trackedRequestMethods = null,
            int delayBetweenAttempts = default)
        {
            _numberOfFailuresToSimulate = numberOfFailuresToSimulate;
            _simulate404 = simulate404;
            _secondaryUri = secondaryUri;
            HostsSetInRequests = new List<string>();
            DatesSetInRequests = new List<DateTime>();
            _trackedRequestMethods = trackedRequestMethods ?? new List<RequestMethod>(new RequestMethod[] { RequestMethod.Get, RequestMethod.Head });
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
            if (_trackedRequestMethods.Contains(message.Request.Method))
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
                _currentInvocationNumber++;
                HostsSetInRequests.Add(message.Request.Uri.Host);
                if (message.Request.Headers.TryGetValue("x-ms-date", out string date))
                {
                    DatesSetInRequests.Add(Convert.ToDateTime(date));
                }
                if (_currentInvocationNumber <= _numberOfFailuresToSimulate)
                {
                    message.Response = new MockResponse(
                        _simulate404 && message.Request.Uri.Host == _secondaryUri?.Host ? 404 : 429);
                    return true;
                }
            }
            return false;
        }
    }
}
