// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    public abstract class ProducerTest<TOptions> : PerfTest<TOptions> where TOptions : ProducerOptions
    {
        protected EventHubProducerClient EventHubProducerClient { get; }

        private readonly byte[] _eventBody;
        private readonly String _propertyValue;

        public ProducerTest(TOptions options) : base(options)
        {
            _eventBody = RandomByteArray.Create((int)options.Size);
            _propertyValue = new string('a', options.PropertySize);

            EventHubProducerClient = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                EventHubsTestEnvironment.Instance.EventHubNameOverride);
        }

        protected IEnumerable<EventData> CreateEvents()
        {
            for (var i = 0; i < Options.MessagesPerBatch; i++)
            {
                var eventData = new EventData(_eventBody);
                for (var j = 0; j < Options.PropertyCount; j++)
                {
                    eventData.Properties.Add(Guid.NewGuid().ToString(), _propertyValue);
                }
                yield return eventData;
            }
        }

        public override void Run(CancellationToken cancellationToken)
        {
            throw new NotImplementedException("ProducerTest only supports async");
        }
    }
}
