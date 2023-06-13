// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.Tests;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    public class OutputBindingEndToEndTests : EventGridLiveTestBase
    {
        public static TestRecording CurrentRecording { get; private set; }

        private string ClientSecret => Mode == RecordedTestMode.Playback ? "fakesecret" : TestEnvironment.ClientSecret;

        public OutputBindingEndToEndTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void Setup()
        {
            CurrentRecording = Recording;
        }

        [RecordedTest]
        public async Task OutputSingleEvent()
        {
            var config = new Dictionary<string, string>()
            {
                { "eventGridUri", TestEnvironment.TopicHost },
                { "eventGridKey", TestEnvironment.TopicKey }
            };
            var host = TestHelpers.NewHost<OutputFunctions>(configuration: config, recording: this);
            await host.GetJobHost().CallAsync(nameof(OutputFunctions.SingleEvent));
        }

        [RecordedTest]
        public async Task OutputBatchEvents()
        {
            var config = new Dictionary<string, string>()
            {
                { "eventGridUri", TestEnvironment.TopicHost },
                { "eventGridKey", TestEnvironment.TopicKey }
            };
            var host = TestHelpers.NewHost<OutputFunctions>(configuration: config, recording: this);
            await host.GetJobHost().CallAsync(nameof(OutputFunctions.BatchEvents));
        }

        [RecordedTest]
        public async Task OutputSingleEvent_Connection()
        {
            var config = new Dictionary<string, string>()
            {
                { "eventgridConnection:topicEndpointUri", TestEnvironment.TopicHost },
                { "eventgridConnection:tenantId", TestEnvironment.TenantId },
                { "eventgridConnection:clientId", TestEnvironment.ClientId },
                { "eventgridConnection:clientSecret", ClientSecret },
            };
            var host = TestHelpers.NewHost<OutputFunctions_Connection>(configuration: config, recording: this);
            await host.GetJobHost().CallAsync(nameof(OutputFunctions_Connection.SingleEvent_Connection));
        }

        [RecordedTest]
        public async Task OutputSingleCloudEvent()
        {
            var config = new Dictionary<string, string>()
            {
                { "eventGridUri", TestEnvironment.CloudEventTopicHost },
                { "eventGridKey", TestEnvironment.CloudEventTopicKey }
            };
            var host = TestHelpers.NewHost<OutputFunctions_CloudEvent>(configuration: config, recording: this);
            await host.GetJobHost().CallAsync(nameof(OutputFunctions_CloudEvent.SingleCloudEvent));
        }

        [RecordedTest]
        public async Task OutputBatchCloudEvents()
        {
            var config = new Dictionary<string, string>()
            {
                { "eventGridUri", TestEnvironment.CloudEventTopicHost },
                { "eventGridKey", TestEnvironment.CloudEventTopicKey }
            };
            var host = TestHelpers.NewHost<OutputFunctions_CloudEvent>(configuration: config, recording: this);
            await host.GetJobHost().CallAsync(nameof(OutputFunctions_CloudEvent.BatchCloudEvents));
        }

        [RecordedTest]
        public async Task OutputSingleCloudEvent_Connection()
        {
            var config = new Dictionary<string, string>()
            {
                { "eventgridConnection:topicEndpointUri", TestEnvironment.CloudEventTopicHost },
                { "eventgridConnection:tenantId", TestEnvironment.TenantId },
                { "eventgridConnection:clientId", TestEnvironment.ClientId },
                { "eventgridConnection:clientSecret", ClientSecret },
            };
            var host = TestHelpers.NewHost<OutputFunctions_CloudEvent_Connection>(configuration: config, recording: this);
            await host.GetJobHost().CallAsync(nameof(OutputFunctions_CloudEvent_Connection.SingleCloudEvent_Connection));
        }

        public class OutputFunctions
        {
            public static void SingleEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out EventGridEvent single)
            {
                single = new EventGridEvent("source", "type", "1", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    EventTime = CurrentRecording.Now
                };
            }
            public static async Task BatchEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] IAsyncCollector<EventGridEvent> events)
            {
                await events.AddAsync(new EventGridEvent("source1", "type", "1", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    EventTime = CurrentRecording.Now
                });
                await events.AddAsync(new EventGridEvent("source2", "type", "1", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    EventTime = CurrentRecording.Now
                });
            }
        }

        public class OutputFunctions_Connection
        {
            public static void SingleEvent_Connection([EventGrid(Connection = "eventgridConnection")] out EventGridEvent single)
            {
                single = new EventGridEvent("source", "type", "1", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    EventTime = CurrentRecording.Now
                };
            }
        }

        public class OutputFunctions_CloudEvent
        {
            public void SingleCloudEvent([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] out CloudEvent single)
            {
                single = new CloudEvent("source", "type", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    Time = CurrentRecording.Now
                };
            }

            public static async Task BatchCloudEvents([EventGrid(TopicEndpointUri = "eventgridUri", TopicKeySetting = "eventgridKey")] IAsyncCollector<CloudEvent> events)
            {
                await events.AddAsync(new CloudEvent("source1", "type", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    Time = CurrentRecording.Now
                });
                await events.AddAsync(new CloudEvent("source2", "type", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    Time = CurrentRecording.Now
                });
            }
        }

        public class OutputFunctions_CloudEvent_Connection
        {
            public static void SingleCloudEvent_Connection([EventGrid(Connection = "eventgridConnection")] out CloudEvent single)
            {
                single = new CloudEvent("source", "type", "data")
                {
                    Id = CurrentRecording.Random.NewGuid().ToString(),
                    Time = CurrentRecording.Now
                };
            }
        }
    }
}