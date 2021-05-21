// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core.TestFramework;
using Azure.Messaging.EventGrid;
using Azure.Messaging.EventGrid.Tests;
using CloudNative.CloudEvents;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents.Tests.Samples
{
    public class CloudNativeSamples : SamplesBase<EventGridTestEnvironment>
    {
        [Test]
        public async Task SendCloudNativeEvents()
        {
            #region Snippet:CloudNativePublish
            EventGridPublisherClient client = new EventGridPublisherClient(
                    new Uri(TestEnvironment.CloudEventTopicHost),
                    new AzureKeyCredential(TestEnvironment.CloudEventTopicKey));

            var cloudEvent =
                new CloudEvent(
                    type: "record",
                    source: new Uri("http://www.contoso.com"))
                    {
                        Data = "data"
                    };

            await client.SendCloudEventAsync(cloudEvent);
            #endregion
        }
    }
}
