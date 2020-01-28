// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    public class FailureSimulationTransport : HttpPipelineTransport
    {
        private readonly HttpPipelineTransport _innerTransport;
        private readonly SimulateFailureAttribute _simulateFailure;
        private readonly Dictionary<string, int> _failedMessages;

        public FailureSimulationTransport(HttpPipelineTransport innerTransport)
        {
            _innerTransport = innerTransport;
            _simulateFailure = SimulateFailureAttribute.Current;
            _failedMessages = new Dictionary<string, int>();
        }

        public override void Process(HttpMessage message)
        {
            if (CanFail(message))
            {
                _simulateFailure.Fail(message);
                if (_simulateFailure.DelayInMs > 0)
                {
                    message.CancellationToken.WaitHandle.WaitOne(_simulateFailure.DelayInMs);
                }
            }
            else
            {
                _innerTransport.Process(message);
            }
        }

        public override async ValueTask ProcessAsync(HttpMessage message)
        {
            if (CanFail(message))
            {
                _simulateFailure.Fail(message);
                if (_simulateFailure.DelayInMs > 0)
                {
                    await Task.Delay(_simulateFailure.DelayInMs, message.CancellationToken);
                }
            }
            else
            {
                await _innerTransport.ProcessAsync(message);
            }
        }

        public override Request CreateRequest() => _innerTransport.CreateRequest();

        private bool CanFail(HttpMessage message)
        {
            if (_simulateFailure == null)
            {
                return false;
            }

            if (!_simulateFailure.CanFail(message))
            {
                return false;
            }

            var startCount = _simulateFailure.FailuresCount;
            var id = message.Request.ClientRequestId;

            lock (_failedMessages)
            {
                if (_failedMessages.TryGetValue(message.Request.ClientRequestId, out var count))
                {
                    if (count > 0)
                    {
                        count--;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    count = startCount - 1;
                }

                _failedMessages[id] = count;
            }

            return true;
        }
    }
}
