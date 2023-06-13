// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.EventGrid.Config;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    internal class InstrumentedCollectorFactory : EventGridAsyncCollectorFactory
    {
        private readonly RecordedTestBase _recording;

        public InstrumentedCollectorFactory(RecordedTestBase recording, IConfiguration configuration, AzureComponentFactory componentFactory) : base(configuration, componentFactory)
        {
            _recording = recording;
        }
        internal override IAsyncCollector<object> CreateCollector(EventGridAttribute attribute)
        {
            return new EventGridAsyncCollector(_recording.InstrumentClient(CreateClient(attribute, _recording.InstrumentClientOptions(new EventGridPublisherClientOptions()))));
        }
    }
}