// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid.Models;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridLiveTestBase : RecordedTestBase<EventGridTestEnvironment>
    {
        public EventGridLiveTestBase(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
            Sanitizer = new EventGridRecordedTestSanitizer();
        }

        [Test]
        public async Task PublishEvent()
        {
            var client = GetClient();
            await client.PublishEventsAsync(
                TestEnvironment.TopicHost,
                new EventGridEvent[] { new EventGridEvent("id", "subject", "data", "type", Recording.Now, "1.0") });
        }

        protected ServiceClient GetClient() =>
            new ServiceClient(
                TestEnvironment.TopicHost,
                new AzureKeyCredential(TestEnvironment.TopicKey),
                Recording.InstrumentClientOptions(new EventGridClientOptions()));
    }
}
