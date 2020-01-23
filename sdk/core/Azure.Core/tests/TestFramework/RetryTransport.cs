// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class RetryTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _innerTransport;
        private readonly SimulateRequestRetryAttribute _simulateRequestRetry;
        private readonly HashSet<string> _retriedMessages;

        public RetryTransport(HttpPipelineTransport innerTransport)
        {
            _innerTransport = innerTransport;
            _simulateRequestRetry = SimulateRequestRetryAttribute.Current ?? new SimulateRequestRetryAttribute();
            _retriedMessages = new HashSet<string>();
        }

        public override void Process(HttpMessage message)
        {
            if (!Retry(message))
            {
                _innerTransport.Process(message);
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            if (!Retry(message))
            {
                await _innerTransport.ProcessAsync(message);
            }
        }

        public override Request CreateRequest() => _innerTransport.CreateRequest();

        private bool Retry(HttpMessage message)
        {
            if (!_simulateRequestRetry.CanRetry(message))
            {
                return false;
            }

            lock (_retriedMessages)
            {
                if (_retriedMessages.Contains(message.Request.ClientRequestId))
                {
                    return false;
                }

                _retriedMessages.Add(message.Request.ClientRequestId);
            }

            _simulateRequestRetry.Retry(message);
            return true;
        }
    }
}
