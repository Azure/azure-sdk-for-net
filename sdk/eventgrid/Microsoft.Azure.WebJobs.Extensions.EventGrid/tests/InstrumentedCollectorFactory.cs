// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
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

        public InstrumentedCollectorFactory(RecordedTestBase recording, IConfiguration configuration,
            AzureComponentFactory componentFactory) :
            base(configuration, new RecordedTestModeAwareComponentFactory(componentFactory, recording))
        {
            _recording = recording;
        }

        internal override IAsyncCollector<object> CreateCollector(EventGridAttribute attribute)
        {
            return new EventGridAsyncCollector(_recording.InstrumentClient(CreateClient(attribute,
                _recording.InstrumentClientOptions(new EventGridPublisherClientOptions()))));
        }

        private class RecordedTestModeAwareComponentFactory : AzureComponentFactory
        {
            private readonly AzureComponentFactory _innerFactory;
            private readonly RecordedTestBase _recording;

            public RecordedTestModeAwareComponentFactory(AzureComponentFactory innerFactory, RecordedTestBase recording)
            {
                _innerFactory = innerFactory;
                _recording = recording;
            }

            public override TokenCredential CreateTokenCredential(IConfiguration configuration)
            {
                if (_recording.Mode == RecordedTestMode.Playback)
                {
                    return new MockCredential();
                }

                return _innerFactory.CreateTokenCredential(configuration);
            }

            public override object CreateClientOptions(Type optionsType, object serviceVersion, IConfiguration configuration)
            {
                return _innerFactory.CreateClientOptions(optionsType, serviceVersion, configuration);
            }

            public override object CreateClient(Type clientType, IConfiguration configuration, TokenCredential credential,
                object clientOptions)
            {
                return _innerFactory.CreateClient(clientType, configuration, credential, clientOptions);
            }
        }
    }
}