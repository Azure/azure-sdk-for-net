// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.EventGrid.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.EventGrid.Tests.ScenarioTests
{
    public class ConsumptionTests
    {
        readonly EventGridSubscriber eventGridSubscriber;

        public ConsumptionTests()
        {
            eventGridSubscriber = new EventGridSubscriber();
        }

        // AppConfiguration events
        [Fact]
        public void ConsumeAppConfigurationKeyValueDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.AppConfiguration.KeyValueDeleted\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"key\":\"key1\",\"label\":\"label1\",\"etag\":\"etag1\"}}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is AppConfigurationKeyValueDeletedEventData);
            AppConfigurationKeyValueDeletedEventData eventData = (AppConfigurationKeyValueDeletedEventData)events[0].Data;
            Assert.Equal("key1", eventData.Key);
        }

        [Fact]
        public void ConsumeAppConfigurationKeyValueModifiedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.AppConfiguration.KeyValueModified\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"key\":\"key1\",\"label\":\"label1\",\"etag\":\"etag1\"}}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is AppConfigurationKeyValueModifiedEventData);
            AppConfigurationKeyValueModifiedEventData eventData = (AppConfigurationKeyValueModifiedEventData)events[0].Data;
            Assert.Equal("key1", eventData.Key);
        }

        [Fact]
        public void ConsumeStorageBlobDeletedEventWithExtraProperty()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageBlobDeletedEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[0].Data;
            Assert.Equal("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }

        [Fact]
        public void ConsumeCustomEvents()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();

            // Testing update
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(ContosoItemSentEventData));
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData));

            var events = eventGridSubscriber2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.Single(events);
            Assert.True(events[0].Data is ContosoItemReceivedEventData);
            ContosoItemReceivedEventData eventData = (ContosoItemReceivedEventData)events[0].Data;
            Assert.Equal("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData.ItemSku);
        }

        [Fact]
        public void ConsumeCustomEventWithArrayData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": [{    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553\"  }],  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData[]));

            var events = eventGridSubscriber2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.Single(events);
            Assert.True(events[0].Data is ContosoItemReceivedEventData[]);
            ContosoItemReceivedEventData[] eventData = (ContosoItemReceivedEventData[])events[0].Data;
            Assert.Equal("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData[0].ItemSku);
        }

        [Fact]
        public void ConsumeCustomEventWithBooleanData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": true,  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(bool));

            var events = eventGridSubscriber2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.Single(events);
            Assert.True(events[0].Data is bool);
            bool eventData = (bool)events[0].Data;
            Assert.True(eventData);
        }

        [Fact]
        public void ConsumeCustomEventWithStringData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": \"stringdata\",  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(string));

            var events = eventGridSubscriber2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.Single(events);
            Assert.True(events[0].Data is string);
            string eventData = (string)events[0].Data;
            Assert.Equal("stringdata", eventData);
        }

        [Fact]
        public void ConsumeCustomEventWithPolymorphicData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"shippingInfo\":{\"shippingType\":\"Drone\", \"droneId\":\"Drone1\",\"shipmentId\":\"1\"}} ,  \"eventType\": \"Contoso.Items.ItemSent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}, {  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"shippingInfo\":{\"shippingType\":\"Rocket\", \"rocketNumber\":1,\"shipmentId\":\"1\"}} ,  \"eventType\": \"Contoso.Items.ItemSent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemSent", typeof(ContosoItemSentEventData));

            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new PolymorphicDeserializeJsonConverter<ShippingInfo>("shippingType"));

            var events = eventGridSubscriber2.DeserializeEventGridEvents(requestContent, jsonSerializer);

            Assert.NotNull(events);
            Assert.Equal(2, events.Length);
            Assert.True(events[0].Data is ContosoItemSentEventData);
            Assert.True(events[1].Data is ContosoItemSentEventData);
            ContosoItemSentEventData eventData0 = (ContosoItemSentEventData)events[0].Data;
            Assert.True(eventData0.ShippingInfo is DroneShippingInfo);

            ContosoItemSentEventData eventData1 = (ContosoItemSentEventData)events[1].Data;
            Assert.True(eventData1.ShippingInfo is RocketShippingInfo);
        }

        [Fact]
        public void TestCustomEventMappings()
        {
            EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemSent", typeof(ContosoItemSentEventData));
            eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData));

            IReadOnlyList<KeyValuePair<string, Type>> list = eventGridSubscriber2.ListAllCustomEventMappings().ToList();
            Assert.Equal(2, list.Count);

            Assert.True(eventGridSubscriber2.TryGetCustomEventMapping("Contoso.Items.ItemSent", out Type retrievedType));
            Assert.Equal(typeof(ContosoItemSentEventData), retrievedType);

            Assert.True(eventGridSubscriber2.TryRemoveCustomEventMapping("Contoso.Items.ItemReceived", out retrievedType));
            Assert.Equal(typeof(ContosoItemReceivedEventData), retrievedType);
        }

        [Fact]
        public void ConsumeMultipleEventsInSameBatch()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"eventType\": \"Microsoft.Storage.BlobCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\",  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, {   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, {   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, {  \"topic\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"eventType\": \"Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener\",  \"eventTime\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.Equal(4, events.Length);
            Assert.True(events[0].Data is StorageBlobCreatedEventData);
            Assert.True(events[1].Data is StorageBlobDeletedEventData);
            Assert.True(events[2].Data is StorageBlobDeletedEventData);
            Assert.True(events[3].Data is ServiceBusDeadletterMessagesAvailableWithNoListenersEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[2].Data;
            Assert.Equal("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }

        // Verify stream support
        [Fact]
        public void ConsumeContainerRegistryImagePushedEventFromStream()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ImagePushed\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}},  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            using (var stream = GetStreamFromString(requestContent))
            {
                var events = this.eventGridSubscriber.DeserializeEventGridEvents(stream);

                Assert.NotNull(events);
                Assert.True(events[0].Data is ContainerRegistryImagePushedEventData);
                ContainerRegistryImagePushedEventData eventData = (ContainerRegistryImagePushedEventData)events[0].Data;
                Assert.Equal("127.0.0.1", eventData.Request.Addr);
            }
        }

        [Fact]
        public void ConsumeCustomEventWithPolymorphicDataFromStream()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"shippingInfo\":{\"shippingType\":\"Drone\", \"droneId\":\"Drone1\",\"shipmentId\":\"1\"}} ,  \"eventType\": \"Contoso.Items.ItemSent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}, {  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"shippingInfo\":{\"shippingType\":\"Rocket\", \"rocketNumber\":1,\"shipmentId\":\"1\"}} ,  \"eventType\": \"Contoso.Items.ItemSent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            using (var stream = GetStreamFromString(requestContent))
            {
                EventGridSubscriber eventGridSubscriber2 = new EventGridSubscriber();
                eventGridSubscriber2.AddOrUpdateCustomEventMapping("Contoso.Items.ItemSent", typeof(ContosoItemSentEventData));

                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Converters.Add(new PolymorphicDeserializeJsonConverter<ShippingInfo>("shippingType"));

                var events = eventGridSubscriber2.DeserializeEventGridEvents(stream, jsonSerializer);

                Assert.NotNull(events);
                Assert.Equal(2, events.Length);
                Assert.True(events[0].Data is ContosoItemSentEventData);
                Assert.True(events[1].Data is ContosoItemSentEventData);
                ContosoItemSentEventData eventData0 = (ContosoItemSentEventData)events[0].Data;
                Assert.True(eventData0.ShippingInfo is DroneShippingInfo);

                ContosoItemSentEventData eventData1 = (ContosoItemSentEventData)events[1].Data;
                Assert.True(eventData1.ShippingInfo is RocketShippingInfo);
            }
        }

        // ContainerRegistry events
        [Fact]
        public void ConsumeContainerRegistryImagePushedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ImagePushed\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}},  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";



            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ContainerRegistryImagePushedEventData);
            ContainerRegistryImagePushedEventData eventData = (ContainerRegistryImagePushedEventData)events[0].Data;
            Assert.Equal("127.0.0.1", eventData.Request.Addr);
        }

        [Fact]
        public void ConsumeContainerRegistryImageDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ImageDeleted\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}},  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ContainerRegistryImageDeletedEventData);
            ContainerRegistryImageDeletedEventData eventData = (ContainerRegistryImageDeletedEventData)events[0].Data;
            Assert.Equal("testactor", eventData.Actor.Name);
        }

        [Fact]
        public void ConsumeContainerRegistryChartDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ChartDeleted\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"id\",\"timestamp\":null,\"action\":\"action1\",\"target\":{\"mediaType\":\"mediatype1\",\"size\":null,\"digest\":\"digest1\",\"repository\":null,\"tag\":null,\"name\":\"name1\",\"version\":null}}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ContainerRegistryChartDeletedEventData);
            ContainerRegistryChartDeletedEventData eventData = (ContainerRegistryChartDeletedEventData)events[0].Data;
            Assert.Equal("mediatype1", eventData.Target.MediaType);
        }

        [Fact]
        public void ConsumeContainerRegistryChartPushedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ChartPushed\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"id\",\"timestamp\":null,\"action\":\"action1\",\"target\":{\"mediaType\":\"mediatype1\",\"size\":null,\"digest\":\"digest1\",\"repository\":null,\"tag\":null,\"name\":\"name1\",\"version\":null}}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ContainerRegistryChartPushedEventData);
            ContainerRegistryChartPushedEventData eventData = (ContainerRegistryChartPushedEventData)events[0].Data;
            Assert.Equal("mediatype1", eventData.Target.MediaType);
        }

        // IoTHub Device events
        [Fact]
        public void ConsumeIoTHubDeviceCreatedEvent()
        {
            string requestContent = "[{ \"id\": \"2da5e9b4-4e38-04c1-cc58-9da0b37230c0\", \"topic\": \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\", \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\", \"eventType\": \"Microsoft.Devices.DeviceCreated\", \"eventTime\": \"2018-07-03T23:20:07.6532054Z\",    \"data\": {      \"twin\": {        \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",        \"etag\": \"AAAAAAAAAAE=\",        \"deviceEtag\": null,        \"status\": \"enabled\",        \"statusUpdateTime\": \"0001-01-01T00:00:00\",        \"connectionState\": \"Disconnected\",        \"lastActivityTime\": \"0001-01-01T00:00:00\",        \"cloudToDeviceMessageCount\": 0,        \"authenticationType\": \"sas\",        \"x509Thumbprint\": {          \"primaryThumbprint\": null,          \"secondaryThumbprint\": null        },        \"version\": 2,        \"properties\": {          \"desired\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          },          \"reported\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          }        }      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is IotHubDeviceCreatedEventData);
            IotHubDeviceCreatedEventData eventData = (IotHubDeviceCreatedEventData)events[0].Data;
            Assert.Equal("enabled", eventData.Twin.Status);
        }

        [Fact]
        public void ConsumeIoTHubDeviceDeletedEvent()
        {
            string requestContent = "[  {    \"id\": \"aaaf95c6-ed99-b307-e321-81d8e4f731a6\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceDeleted\",    \"eventTime\": \"2018-07-03T23:21:33.2753956Z\",    \"data\": {      \"twin\": {        \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",        \"etag\": \"AAAAAAAAAAI=\",        \"deviceEtag\": null,        \"status\": \"enabled\",        \"statusUpdateTime\": \"0001-01-01T00:00:00\",        \"connectionState\": \"Disconnected\",        \"lastActivityTime\": \"0001-01-01T00:00:00\",        \"cloudToDeviceMessageCount\": 0,        \"authenticationType\": \"sas\",        \"x509Thumbprint\": {          \"primaryThumbprint\": null,          \"secondaryThumbprint\": null        },        \"version\": 3,        \"tags\": {          \"testKey\": \"testValue\"        },        \"properties\": {          \"desired\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          },          \"reported\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          }        }      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is IotHubDeviceDeletedEventData);
            IotHubDeviceDeletedEventData eventData = (IotHubDeviceDeletedEventData)events[0].Data;
            Assert.Equal("AAAAAAAAAAI=", eventData.Twin.Etag);
        }

        [Fact]
        public void ConsumeIoTHubDeviceConnectedEvent()
        {
            string requestContent = "[  {    \"id\": \"fbfd8ee1-cf78-74c6-dbcf-e1c58638ccbd\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceConnected\",    \"eventTime\": \"2018-07-03T23:20:11.6921933+00:00\",    \"data\": {      \"deviceConnectionStateEventInfo\": {        \"sequenceNumber\":          \"000000000000000001D4132452F67CE200000002000000000000000000000001\"      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",      \"moduleId\": \"\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is IotHubDeviceConnectedEventData);
            IotHubDeviceConnectedEventData eventData = (IotHubDeviceConnectedEventData)events[0].Data;
            Assert.Equal("EGTESTHUB1", eventData.HubName);
        }

        [Fact]
        public void ConsumeIoTHubDeviceDisconnectedEvent()
        {
            string requestContent = "[  {    \"id\": \"877f0b10-a086-98ec-27b8-6ae2dfbf5f67\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceDisconnected\",    \"eventTime\": \"2018-07-03T23:20:52.646434+00:00\",    \"data\": {      \"deviceConnectionStateEventInfo\": {        \"sequenceNumber\":          \"000000000000000001D4132452F67CE200000002000000000000000000000002\"      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",      \"moduleId\": \"\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is IotHubDeviceDisconnectedEventData);
            IotHubDeviceDisconnectedEventData eventData = (IotHubDeviceDisconnectedEventData)events[0].Data;
            Assert.Equal("000000000000000001D4132452F67CE200000002000000000000000000000002", eventData.DeviceConnectionStateEventInfo.SequenceNumber);
        }

        [Fact]
        public void ConsumeIoTHubDeviceTelemetryEvent()
        {
            string requestContent = "[{  \"id\": \"877f0b10-a086-98ec-27b8-6ae2dfbf5f67\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceTelemetry\",    \"eventTime\": \"2018-07-03T23:20:52.646434+00:00\",    \"data\": { \"body\": { \"Weather\": { \"Temperature\": 900  }, \"Location\": \"USA\"  },  \"properties\": {  \"Status\": \"Active\"  },  \"systemProperties\": { \"iothub-content-type\": \"application/json\", \"iothub-content-encoding\": \"utf-8\"   } } }   ]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is IotHubDeviceTelemetryEventData);
            IotHubDeviceTelemetryEventData eventData = (IotHubDeviceTelemetryEventData)events[0].Data;
            Assert.Equal("Active", eventData.Properties["Status"]);
        }

        // EventGrid events
        [Fact]
        public void ConsumeEventGridSubscriptionValidationEvent()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is SubscriptionValidationEventData);
            SubscriptionValidationEventData eventData = (SubscriptionValidationEventData)events[0].Data;
            Assert.Equal("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData.ValidationCode);
        }

        [Fact]
        public void ConsumeEventGridSubscriptionDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"eventSubscriptionId\": \"/subscriptions/id/resourceGroups/rg/providers/Microsoft.EventGrid/topics/topic1/providers/Microsoft.EventGrid/eventSubscriptions/eventsubscription1\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionDeletedEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is SubscriptionDeletedEventData);
            SubscriptionDeletedEventData eventData = (SubscriptionDeletedEventData)events[0].Data;
            Assert.Equal("/subscriptions/id/resourceGroups/rg/providers/Microsoft.EventGrid/topics/topic1/providers/Microsoft.EventGrid/eventSubscriptions/eventsubscription1", eventData.EventSubscriptionId);
        }

        // Event Hub Events
        [Fact]
        public void ConsumeEventHubCaptureFileCreatedEvent()
        {
            string requestContent = "[    {        \"topic\": \"/subscriptions/guid/resourcegroups/rgDataMigrationSample/providers/Microsoft.EventHub/namespaces/tfdatamigratens\",        \"subject\": \"eventhubs/hubdatamigration\",        \"eventType\": \"microsoft.EventHUB.CaptureFileCreated\",        \"eventTime\": \"2017-08-31T19:12:46.0498024Z\",        \"id\": \"14e87d03-6fbf-4bb2-9a21-92bd1281f247\",        \"data\": {            \"fileUrl\": \"https://tf0831datamigrate.blob.core.windows.net/windturbinecapture/tfdatamigratens/hubdatamigration/1/2017/08/31/19/11/45.avro\",            \"fileType\": \"AzureBlockBlob\",            \"partitionId\": \"1\",            \"sizeInBytes\": 249168,            \"eventCount\": 1500,            \"firstSequenceNumber\": 2400,            \"lastSequenceNumber\": 3899,            \"firstEnqueueTime\": \"2017-08-31T19:12:14.674Z\",            \"lastEnqueueTime\": \"2017-08-31T19:12:44.309Z\"        },        \"dataVersion\": \"\",        \"metadataVersion\": \"1\"    }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is EventHubCaptureFileCreatedEventData);
            EventHubCaptureFileCreatedEventData eventData = (EventHubCaptureFileCreatedEventData)events[0].Data;
            Assert.Equal("AzureBlockBlob", eventData.FileType);
        }

        // MachineLearningServices events
        [Fact]
        public void ConsumeMachineLearningServicesModelRegisteredEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.ModelRegistered\",\"subject\":\"models/sklearn_regression_model:3\",\"eventTime\":\"2019-10-17T22:23:57.5350054+00:00\",\"id\":\"3b73ee51-bbf4-480d-9112-cfc23b41bfdb\",\"data\":{\"modelName\":\"sklearn_regression_model\",\"modelVersion\":\"3\",\"modelTags\":{\"area\":\"diabetes\",\"type\":\"regression\"},\"modelProperties\":{\"area\":\"test\"}},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MachineLearningServicesModelRegisteredEventData);
            MachineLearningServicesModelRegisteredEventData eventData = (MachineLearningServicesModelRegisteredEventData)events[0].Data;
            Assert.Equal("sklearn_regression_model", eventData.ModelName);
            Assert.Equal("3", eventData.ModelVersion);

            Assert.True(eventData.ModelTags is JObject);
            var tags = (JObject)eventData.ModelTags;
            Assert.Equal("regression", tags["type"]);

            Assert.True(eventData.ModelProperties is JObject);
            var properties = (JObject)eventData.ModelProperties;
            Assert.Equal("test", properties["area"]);
        }

        [Fact]
        public void ConsumeMachineLearningServicesModelDeployedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.ModelDeployed\",\"subject\":\"endpoints/aciservice1\",\"eventTime\":\"2019-10-23T18:20:08.8824474+00:00\",\"id\":\"40d0b167-be44-477b-9d23-a2befba7cde0\",\"data\":{\"serviceName\":\"aciservice1\",\"serviceComputeType\":\"ACI\",\"serviceTags\":{\"mytag\":\"test tag\"},\"serviceProperties\":{\"myprop\":\"test property\"},\"modelIds\":\"my_first_model:1,my_second_model:1\"},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MachineLearningServicesModelDeployedEventData);
            MachineLearningServicesModelDeployedEventData eventData = (MachineLearningServicesModelDeployedEventData)events[0].Data;
            Assert.Equal("aciservice1", eventData.ServiceName);
            Assert.Equal(2, eventData.ModelIds.Split(',').Length);
        }

        [Fact]
        public void ConsumeMachineLearningServicesRunCompletedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.RunCompleted\",\"subject\":\"experiments/0fa9dfaa-cba3-4fa7-b590-23e48548f5c1/runs/AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"eventTime\":\"2019-10-18T19:29:55.8856038+00:00\",\"id\":\"044ac44d-462c-4043-99eb-d9e01dc760ab\",\"data\":{\"experimentId\":\"0fa9dfaa-cba3-4fa7-b590-23e48548f5c1\",\"experimentName\":\"automl-local-regression\",\"runId\":\"AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"runType\":\"automl\",\"RunTags\":{\"experiment_status\":\"ModelSelection\",\"experiment_status_descr\":\"Beginning model selection.\"},\"runProperties\":{\"num_iterations\":\"10\",\"target\":\"local\"}},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MachineLearningServicesRunCompletedEventData);
            MachineLearningServicesRunCompletedEventData eventData = (MachineLearningServicesRunCompletedEventData)events[0].Data;
            Assert.Equal("AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc", eventData.RunId);
            Assert.Equal("automl-local-regression", eventData.ExperimentName);
        }

        [Fact]
        public void ConsumeMachineLearningServicesRunStatusChangedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.RunStatusChanged\",\"subject\":\"experiments/0fa9dfaa-cba3-4fa7-b590-23e48548f5c1/runs/AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"eventTime\":\"2020-03-09T23:53:04.4579724Z\",\"id\":\"aa8cd7df-fe28-5d5d-9b40-3342dbc2a887\",\"data\":{\"runStatus\": \"Running\",\"experimentId\":\"0fa9dfaa-cba3-4fa7-b590-23e48548f5c1\",\"experimentName\":\"automl-local-regression\",\"runId\":\"AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"runType\":\"automl\",\"runTags\":{\"experiment_status\":\"ModelSelection\",\"experiment_status_descr\":\"Beginning model selection.\"},\"runProperties\":{\"num_iterations\":\"10\",\"target\":\"local\"}},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MachineLearningServicesRunStatusChangedEventData);
            MachineLearningServicesRunStatusChangedEventData eventData = (MachineLearningServicesRunStatusChangedEventData)events[0].Data;
            Assert.Equal("AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc", eventData.RunId);
            Assert.Equal("automl-local-regression", eventData.ExperimentName);
            Assert.Equal("Running", eventData.RunStatus);
            Assert.Equal("automl", eventData.RunType);
        }

        [Fact]
        public void ConsumeMachineLearningServicesDatasetDriftDetectedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/60582a10-b9fd-49f1-a546-c4194134bba8/resourceGroups/copetersRG/providers/Microsoft.MachineLearningServices/workspaces/driftDemoWS\",\"eventType\":\"Microsoft.MachineLearningServices.DatasetDriftDetected\",\"subject\":\"datadrift/01d29aa4-e6a4-470a-9ef3-66660d21f8ef/run/01d29aa4-e6a4-470a-9ef3-66660d21f8ef_1571590300380\",\"eventTime\":\"2019-10-20T17:08:08.467191+00:00\",\"id\":\"2684de79-b145-4dcf-ad2e-6a1db798585f\",\"data\":{\"dataDriftId\":\"01d29aa4-e6a4-470a-9ef3-66660d21f8ef\",\"dataDriftName\":\"copetersDriftMonitor3\",\"runId\":\"01d29aa4-e6a4-470a-9ef3-66660d21f8ef_1571590300380\",\"baseDatasetId\":\"3c56d136-0f64-4657-a0e8-5162089a88a3\",\"targetDatasetId\":\"d7e74d2e-c972-4266-b5fb-6c9c182d2a74\",\"driftCoefficient\":0.8350349068479208,\"startTime\":\"2019-07-04T00:00:00+00:00\",\"endTime\":\"2019-07-05T00:00:00+00:00\"},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MachineLearningServicesDatasetDriftDetectedEventData);
            MachineLearningServicesDatasetDriftDetectedEventData eventData = (MachineLearningServicesDatasetDriftDetectedEventData)events[0].Data;
            Assert.Equal("copetersDriftMonitor3", eventData.DataDriftName);
        }

        // Maps events
        [Fact]
        public void ConsumeMapsGeofenceEnteredEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.Maps.GeofenceEntered\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":null,\"isEventPublished\":true}}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MapsGeofenceEnteredEventData);
            MapsGeofenceEnteredEventData eventData = (MapsGeofenceEnteredEventData)events[0].Data;
            Assert.Equal(1.0, eventData.Geometries[0].Distance);
        }

        [Fact]
        public void ConsumeMapsGeofenceExitedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.Maps.GeofenceExited\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":null,\"isEventPublished\":true}}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MapsGeofenceExitedEventData);
            MapsGeofenceExitedEventData eventData = (MapsGeofenceExitedEventData)events[0].Data;
            Assert.Equal(1.0, eventData.Geometries[0].Distance);
        }

        [Fact]
        public void ConsumeMapsGeofenceResultEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.Maps.GeofenceResult\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":null,\"isEventPublished\":true}}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MapsGeofenceResultEventData);
            MapsGeofenceResultEventData eventData = (MapsGeofenceResultEventData)events[0].Data;
            Assert.Equal(1.0, eventData.Geometries[0].Distance);
        }

        // Media Services events
        [Fact]
        public void ConsumeMediaMediaJobStateChangeEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobStateChange\",  \"eventTime\": \"2018-10-12T15:14:20.2412317\",  \"id\": \"341520d0-dac0-4930-97dd-3085538c624f\",  \"data\": {    \"previousState\": \"Scheduled\",    \"state\": \"Processing\",    \"correlationData\": {}  },  \"dataVersion\": \"2.0\",  \"metadataVersion\": \"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobStateChangeEventData);
            MediaJobStateChangeEventData eventData = (MediaJobStateChangeEventData)events[0].Data;
            Assert.Equal(MediaJobState.Scheduled, eventData.PreviousState);
            Assert.Equal(MediaJobState.Processing, eventData.State);
        }

        [Fact]
        public void ConsumeMediaJobOutputStateChangeEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputStateChange\",  \"eventTime\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"8d0305c0-28c0-4cc9-b613-776e4dd31e9a\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": null,      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputStateChangeEventData);
            MediaJobOutputStateChangeEventData eventData = (MediaJobOutputStateChangeEventData)events[0].Data;
            Assert.Equal(MediaJobState.Scheduled, eventData.PreviousState);
            Assert.Equal(MediaJobState.Processing, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)eventData.Output;
            Assert.Equal("output-2ac2fe75-6557-4de5-ab25-5713b74a6901", outputAsset.AssetName);
        }

        [Fact]
        public void ConsumeMediaJobScheduledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobScheduled\",  \"eventTime\": \"2018-10-12T15:14:11.3028183\",  \"id\": \"9b17dbf0-355d-4fb0-9a73-e76b150858c8\",  \"data\": {    \"previousState\": \"Queued\",    \"state\": \"Scheduled\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobScheduledEventData);
            MediaJobScheduledEventData eventData = (MediaJobScheduledEventData)events[0].Data;
            Assert.Equal(MediaJobState.Queued, eventData.PreviousState);
            Assert.Equal(MediaJobState.Scheduled, eventData.State);
        }

        [Fact]
        public void ConsumeMediaJobProcessingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobProcessing\",  \"eventTime\": \"2018-10-12T15:14:20.2412317\",  \"id\": \"72162c44-c7f4-437a-9592-48b83cec2d18\",  \"data\": {    \"previousState\": \"Scheduled\",    \"state\": \"Processing\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobProcessingEventData);
            MediaJobProcessingEventData eventData = (MediaJobProcessingEventData)events[0].Data;
            Assert.Equal(MediaJobState.Scheduled, eventData.PreviousState);
            Assert.Equal(MediaJobState.Processing, eventData.State);
        }

        [Fact]
        public void ConsumeMediaJobCancelingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobCanceling\",  \"eventTime\": \"2018-10-12T15:41:50.5513295\",  \"id\": \"1f9a488b-abe3-4fca-80b8-aae59bf7f123\",  \"data\": {    \"previousState\": \"Processing\",    \"state\": \"Canceling\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobCancelingEventData);
            MediaJobCancelingEventData eventData = (MediaJobCancelingEventData)events[0].Data;
            Assert.Equal(MediaJobState.Processing, eventData.PreviousState);
            Assert.Equal(MediaJobState.Canceling, eventData.State);
        }

        [Fact]
        public void ConsumeMediaJobFinishedEvent()
        {
            string requestContent = "[{ \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-298338bb-f8d1-4d0f-9fde-544e0ac4d983\",  \"eventType\": \"Microsoft.Media.JobFinished\",  \"eventTime\": \"2018-10-01T20:58:26.7886175\",  \"id\": \"83f8464d-be94-48e5-b67b-46c6199fe28e\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-298338bb-f8d1-4d0f-9fde-544e0ac4d983\",        \"error\": null,        \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 100,        \"state\": \"Finished\"      }    ],    \"previousState\": \"Processing\",    \"state\": \"Finished\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\" }]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobFinishedEventData);
            MediaJobFinishedEventData eventData = (MediaJobFinishedEventData)events[0].Data;
            Assert.Equal(MediaJobState.Processing, eventData.PreviousState);
            Assert.Equal(MediaJobState.Finished, eventData.State);
            Assert.Equal(1, eventData.Outputs.Count);
            Assert.True(eventData.Outputs[0] is MediaJobOutputAsset);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)eventData.Outputs[0];

            Assert.Equal(MediaJobState.Finished, outputAsset.State);
            Assert.Null(outputAsset.Error);
            Assert.Equal(100, outputAsset.Progress);            
            Assert.Equal("output-298338bb-f8d1-4d0f-9fde-544e0ac4d983", outputAsset.AssetName);
        }

        [Fact]
        public void ConsumeMediaJobCanceledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobCanceled\",  \"eventTime\": \"2018-10-12T15:42:05.6519929\",  \"id\": \"3fef7871-f916-4980-8a45-e79a2675808b\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",        \"error\": null,        \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 83,        \"state\": \"Canceled\"      }    ],    \"previousState\": \"Canceling\",    \"state\": \"Canceled\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobCanceledEventData);
            MediaJobCanceledEventData eventData = (MediaJobCanceledEventData)events[0].Data;
            Assert.Equal(MediaJobState.Canceling, eventData.PreviousState);
            Assert.Equal(MediaJobState.Canceled, eventData.State);
            Assert.Equal(1, eventData.Outputs.Count);
            Assert.True(eventData.Outputs[0] is MediaJobOutputAsset);

            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)eventData.Outputs[0];

            Assert.Equal(MediaJobState.Canceled, outputAsset.State);
            Assert.Null(outputAsset.Error);
            Assert.NotEqual(100, outputAsset.Progress);
            Assert.Equal("output-7a8215f9-0f8d-48a6-82ed-1ead772bc221", outputAsset.AssetName);
        }

        [Fact]
        public void ConsumeMediaJobErroredEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobErrored\",  \"eventTime\": \"2018-10-12T15:29:20.9954767\",  \"id\": \"2749e9cf-4095-4723-9bc5-df8e15289135\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",        \"error\": {          \"category\": \"Service\",          \"code\": \"ServiceError\",          \"details\": [            {              \"code\": \"Internal\",              \"message\": \"Internal error in initializing the task for processing\"            }          ],          \"message\": \"Fatal service error, please contact support.\",          \"retry\": \"DoNotRetry\"        },        \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 83,        \"state\": \"Error\"      }    ],    \"previousState\": \"Processing\",    \"state\": \"Error\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobErroredEventData);
            MediaJobErroredEventData eventData = (MediaJobErroredEventData)events[0].Data;
            Assert.Equal(MediaJobState.Processing, eventData.PreviousState);
            Assert.Equal(MediaJobState.Error, eventData.State);
            Assert.Equal(1, eventData.Outputs.Count);
            Assert.True(eventData.Outputs[0] is MediaJobOutputAsset);

            Assert.Equal(MediaJobState.Error, eventData.Outputs[0].State);
            Assert.NotNull(eventData.Outputs[0].Error);
            Assert.Equal(MediaJobErrorCategory.Service, eventData.Outputs[0].Error.Category);
            Assert.Equal(MediaJobErrorCode.ServiceError, eventData.Outputs[0].Error.Code);
        }

        [Fact]
        public void ConsumeMediaJobOutputCanceledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobOutputCanceled\",  \"eventTime\": \"2018-10-12T15:42:04.949555\",  \"id\": \"9297cda2-4a50-4622-a679-c3785d27d512\",  \"data\": {    \"previousState\": \"Canceling\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",      \"error\": null,      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Canceled\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputCanceledEventData);
            MediaJobOutputCanceledEventData eventData = (MediaJobOutputCanceledEventData)events[0].Data;
            Assert.Equal(MediaJobState.Canceling, eventData.PreviousState);
            Assert.Equal(MediaJobState.Canceled, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
        }

        [Fact]
        public void ConsumeMediaJobOutputCancelingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobOutputCanceling\",  \"eventTime\": \"2018-10-12T15:42:04.949555\",  \"id\": \"9297cda2-4a50-4622-a679-c3785d27d512\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",      \"error\": null,      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Canceling\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputCancelingEventData);
            MediaJobOutputCancelingEventData eventData = (MediaJobOutputCancelingEventData)events[0].Data;
            Assert.Equal(MediaJobState.Processing, eventData.PreviousState);
            Assert.Equal(MediaJobState.Canceling, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
        }

        [Fact]
        public void ConsumeMediaJobOutputErroredEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputErrored\",  \"eventTime\": \"2018-10-12T15:29:20.2621252\",  \"id\": \"bc9e6342-f081-49c2-a579-92f506a622c2\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Error\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputErroredEventData);
            MediaJobOutputErroredEventData eventData = (MediaJobOutputErroredEventData)events[0].Data;
            Assert.Equal(MediaJobState.Processing, eventData.PreviousState);
            Assert.Equal(MediaJobState.Error, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
            Assert.NotNull(eventData.Output.Error);
            Assert.Equal(MediaJobErrorCategory.Service, eventData.Output.Error.Category);
            Assert.Equal(MediaJobErrorCode.ServiceError, eventData.Output.Error.Code);
        }

        [Fact]
        public void ConsumeMediaJobOutputFinishedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputFinished\",  \"eventTime\": \"2018-10-12T15:29:20.2621252\",  \"id\": \"bc9e6342-f081-49c2-a579-92f506a622c2\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",            \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 100,      \"state\": \"Finished\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputFinishedEventData);
            MediaJobOutputFinishedEventData eventData = (MediaJobOutputFinishedEventData)events[0].Data;
            Assert.Equal(MediaJobState.Processing, eventData.PreviousState);
            Assert.Equal(MediaJobState.Finished, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
            Assert.Equal(100, eventData.Output.Progress);

            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)eventData.Output;
            Assert.Equal("output-2ac2fe75-6557-4de5-ab25-5713b74a6901", outputAsset.AssetName);
        }

        [Fact]
        public void ConsumeMediaJobOutputProcessingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputProcessing\",  \"eventTime\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"d48eeb0b-2bfa-4265-a2f8-624654c3781c\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": null,      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputProcessingEventData);
            MediaJobOutputProcessingEventData eventData = (MediaJobOutputProcessingEventData)events[0].Data;
            Assert.Equal(MediaJobState.Scheduled, eventData.PreviousState);
            Assert.Equal(MediaJobState.Processing, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
        }

        [Fact]
        public void ConsumeMediaJobOutputScheduledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputScheduled\",  \"eventTime\": \"2018-10-12T15:14:11.2244618\",  \"id\": \"635ca6ea-5306-4590-b2e1-22f172759336\",  \"data\": {    \"previousState\": \"Queued\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": null,      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Scheduled\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputScheduledEventData);
            MediaJobOutputScheduledEventData eventData = (MediaJobOutputScheduledEventData)events[0].Data;
            Assert.Equal(MediaJobState.Queued, eventData.PreviousState);
            Assert.Equal(MediaJobState.Scheduled, eventData.Output.State);
            Assert.True(eventData.Output is MediaJobOutputAsset);
        }

        [Fact]
        public void ConsumeMediaJobOutputProgressEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6981\",  \"eventType\": \"Microsoft.Media.JobOutputProgress\",  \"eventTime\": \"2018-10-12T15:14:11.2244618\",  \"id\": \"635ca6ea-5306-4590-b2e1-22f172759336\",  \"data\": {    \"jobCorrelationData\": {    \"Field1\": \"test1\",    \"Field2\": \"test2\" },    \"label\": \"TestLabel\",    \"progress\": 50 },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobOutputProgressEventData);
            MediaJobOutputProgressEventData eventData = (MediaJobOutputProgressEventData)events[0].Data;
            Assert.Equal("TestLabel", eventData.Label);
            Assert.Equal(50, eventData.Progress);
            Assert.True(eventData.JobCorrelationData.ContainsKey("Field1"));
            Assert.Equal("test1", eventData.JobCorrelationData["Field1"]);
            Assert.True(eventData.JobCorrelationData.ContainsKey("Field2"));
            Assert.Equal("test2", eventData.JobCorrelationData["Field2"]);
        }

        [Fact]
        public void ConsumeMediaLiveEventEncoderConnectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventEncoderConnected\",  \"eventTime\": \"2018-10-12T15:52:04.2013501\",  \"id\": \"3d1f5b26-c466-47e7-927b-900985e0c5d5\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventEncoderConnectedEventData);
            MediaLiveEventEncoderConnectedEventData eventData = (MediaLiveEventEncoderConnectedEventData)events[0].Data;
            Assert.Equal("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59", eventData.IngestUrl);
            Assert.Equal("Mystream1", eventData.StreamId);
            Assert.Equal("<ip address>", eventData.EncoderIp);
            Assert.Equal("3557", eventData.EncoderPort);
        }
 

        [Fact]
        public void ConsumeMediaLiveEventConnectionRejectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventConnectionRejected\",  \"eventTime\": \"2018-10-12T15:52:04.2013501\",  \"id\": \"3d1f5b26-c466-47e7-927b-900985e0c5d5\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"resultCode\": \"MPE_INGEST_CODEC_NOT_SUPPORTED\"   },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventConnectionRejectedEventData);
            MediaLiveEventConnectionRejectedEventData eventData = (MediaLiveEventConnectionRejectedEventData)events[0].Data;
        }

        [Fact]
        public void ConsumeMediaLiveEventEncoderDisconnectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventEncoderDisconnected\",  \"eventTime\": \"2018-10-12T15:52:19.8982128\",  \"id\": \"e4b55140-42d2-4c24-b08e-9aa12f1587fc\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"resultCode\": \"MPE_CLIENT_TERMINATED_SESSION\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";
            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventEncoderDisconnectedEventData);
            MediaLiveEventEncoderDisconnectedEventData eventData = (MediaLiveEventEncoderDisconnectedEventData)events[0].Data;
            Assert.Equal("MPE_CLIENT_TERMINATED_SESSION", eventData.ResultCode);

            Assert.Equal("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59", eventData.IngestUrl);
            Assert.Equal("Mystream1", eventData.StreamId);
            Assert.Equal("<ip address>", eventData.EncoderIp);
            Assert.Equal("3557", eventData.EncoderPort);
        }

        [Fact]
        public void ConsumeMediaLiveEventIncomingStreamReceivedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingStreamReceived\",  \"eventTime\": \"2018-10-12T15:52:16.5726463Z\",  \"id\": \"eb688fa1-5a19-4703-8aeb-6a65a09790da\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"trackType\": \"audio\",    \"trackName\": \"audio_160000\",    \"bitrate\": 160000,    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"timestamp\": \"66\",    \"duration\": \"1950\",    \"timescale\": \"1000\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventIncomingStreamReceivedEventData);
            MediaLiveEventIncomingStreamReceivedEventData eventData = (MediaLiveEventIncomingStreamReceivedEventData)events[0].Data;

            Assert.Equal("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59", eventData.IngestUrl);
            Assert.Equal("<ip address>", eventData.EncoderIp);
            Assert.Equal("3557", eventData.EncoderPort);
            Assert.Equal("audio", eventData.TrackType);
            Assert.Equal("audio_160000", eventData.TrackName);
            Assert.Equal(160000, eventData.Bitrate);
            Assert.Equal("66", eventData.Timestamp);
            Assert.Equal("1950", eventData.Duration);
            Assert.Equal("1000", eventData.Timescale);
        }
        

        [Fact]
        public void ConsumeMediaLiveEventIncomingStreamsOutOfSyncEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingStreamsOutOfSync\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"minLastTimestamp\": \"10999\",    \"typeOfStreamWithMinLastTimestamp\": \"video\",    \"maxLastTimestamp\": \"100999\",    \"typeOfStreamWithMaxLastTimestamp\": \"audio\",    \"timescaleOfMinLastTimestamp\": \"1000\",  \"timescaleOfMaxLastTimestamp\": \"1000\"    },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventIncomingStreamsOutOfSyncEventData);
            MediaLiveEventIncomingStreamsOutOfSyncEventData eventData = (MediaLiveEventIncomingStreamsOutOfSyncEventData)events[0].Data;
            Assert.Equal("10999", eventData.MinLastTimestamp);
            Assert.Equal("video", eventData.TypeOfStreamWithMinLastTimestamp);
            Assert.Equal("100999", eventData.MaxLastTimestamp);
            Assert.Equal("audio", eventData.TypeOfStreamWithMaxLastTimestamp);
            Assert.Equal("1000", eventData.TimescaleOfMinLastTimestamp);
            Assert.Equal("1000", eventData.TimescaleOfMaxLastTimestamp);
        }

        [Fact]
        public void ConsumeMediaLiveEventIncomingVideoStreamsOutOfSyncEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"firstTimestamp\": \"10999\",    \"firstDuration\": \"2000\",    \"secondTimestamp\": \"100999\",    \"secondDuration\": \"2000\",    \"timescale\": \"1000\",  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventIncomingVideoStreamsOutOfSyncEventData);
            MediaLiveEventIncomingVideoStreamsOutOfSyncEventData eventData = (MediaLiveEventIncomingVideoStreamsOutOfSyncEventData)events[0].Data;
            Assert.Equal("10999", eventData.FirstTimestamp);
            Assert.Equal("2000", eventData.FirstDuration);
            Assert.Equal("100999", eventData.SecondTimestamp);
            Assert.Equal("2000", eventData.SecondDuration);
            Assert.Equal("1000", eventData.Timescale);
        }

        [Fact]
        public void ConsumeMediaLiveEventIncomingDataChunkDroppedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingDataChunkDropped\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"timestamp\": \"8999\",    \"trackType\": \"video\",    \"trackName\": \"video1\",    \"bitrate\": 2500000,    \"timescale\": \"1000\",    \"resultCode\": \"FragmentDrop_OverlapTimestamp\",  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventIncomingDataChunkDroppedEventData);
            MediaLiveEventIncomingDataChunkDroppedEventData eventData = (MediaLiveEventIncomingDataChunkDroppedEventData)events[0].Data;
            Assert.Equal("8999", eventData.Timestamp);
            Assert.Equal("video", eventData.TrackType);
            Assert.Equal("video1", eventData.TrackName);
            Assert.Equal(2500000, eventData.Bitrate);
            Assert.Equal("1000", eventData.Timescale);
            Assert.Equal("FragmentDrop_OverlapTimestamp", eventData.ResultCode);
        }

        [Fact]
        public void ConsumeMediaLiveEventIngestHeartbeatEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIngestHeartbeat\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"incomingBitrate\": 500726,    \"lastTimestamp\": \"11999\",    \"timescale\": \"1000\",    \"overlapCount\": 0,    \"discontinuityCount\": 0,    \"nonincreasingCount\": 0,    \"unexpectedBitrate\": true,    \"state\": \"Running\",    \"healthy\": false  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventIngestHeartbeatEventData);
            MediaLiveEventIngestHeartbeatEventData eventData = (MediaLiveEventIngestHeartbeatEventData)events[0].Data;
            Assert.Equal("video", eventData.TrackType);
            Assert.Equal("video", eventData.TrackName);
            Assert.Equal(2500000, eventData.Bitrate);
            Assert.Equal(500726, eventData.IncomingBitrate);
            Assert.Equal("11999", eventData.LastTimestamp);
            Assert.Equal("1000", eventData.Timescale);
            Assert.Equal(0, eventData.OverlapCount);
            Assert.Equal(0, eventData.DiscontinuityCount);
            Assert.Equal(0, eventData.NonincreasingCount);
            Assert.True(eventData.UnexpectedBitrate);
            Assert.Equal("Running", eventData.State);
            Assert.False(eventData.Healthy);
        }

        [Fact]
        public void ConsumeMediaLiveEventTrackDiscontinuityDetectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventTrackDiscontinuityDetected\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"previousTimestamp\": \"10999\",    \"newTimestamp\": \"14999\",    \"timescale\": \"1000\",    \"discontinuityGap\": 4000,  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaLiveEventTrackDiscontinuityDetectedEventData);
            MediaLiveEventTrackDiscontinuityDetectedEventData eventData = (MediaLiveEventTrackDiscontinuityDetectedEventData)events[0].Data;
            Assert.Equal("video", eventData.TrackType);
            Assert.Equal("video", eventData.TrackName);
            Assert.Equal(2500000, eventData.Bitrate);
            Assert.Equal("10999", eventData.PreviousTimestamp);
            Assert.Equal("14999", eventData.NewTimestamp);
            Assert.Equal("1000", eventData.Timescale);
            Assert.Equal("4000", eventData.DiscontinuityGap);
        }

        // Resource Manager (Azure Subscription/Resource Group) events
        [Fact]
        public void ConsumeResourceWriteSuccessEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceWriteSuccess\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceWriteSuccessData);
            ResourceWriteSuccessData eventData = (ResourceWriteSuccessData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceWriteFailureEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceWriteFailure\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceWriteFailureData);
            ResourceWriteFailureData eventData = (ResourceWriteFailureData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceWriteCancelEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceWriteCancel\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceWriteCancelData);
            ResourceWriteCancelData eventData = (ResourceWriteCancelData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceDeleteSuccessEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceDeleteSuccess\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceDeleteSuccessData);
            ResourceDeleteSuccessData eventData = (ResourceDeleteSuccessData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceDeleteFailureEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceDeleteFailure\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceDeleteFailureData);
            ResourceDeleteFailureData eventData = (ResourceDeleteFailureData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceDeleteCancelEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceDeleteCancel\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceDeleteCancelData);
            ResourceDeleteCancelData eventData = (ResourceDeleteCancelData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceActionSuccessEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceActionSuccess\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceActionSuccessData);
            ResourceActionSuccessData eventData = (ResourceActionSuccessData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceActionFailureEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceActionFailure\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceActionFailureData);
            ResourceActionFailureData eventData = (ResourceActionFailureData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }

        [Fact]
        public void ConsumeResourceActionCancelEvent()
        {
            string requestContent = "[   {     \"topic\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.Resources.ResourceActionCancel\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },      \"dataVersion\": \"\",      \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ResourceActionCancelData);
            ResourceActionCancelData eventData = (ResourceActionCancelData)events[0].Data;
            Assert.Equal("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
        }


        // ServiceBus events
        [Fact]
        public void ConsumeServiceBusActiveMessagesAvailableWithNoListenersEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"eventType\": \"Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners\",  \"eventTime\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ServiceBusActiveMessagesAvailableWithNoListenersEventData);
            ServiceBusActiveMessagesAvailableWithNoListenersEventData eventData = (ServiceBusActiveMessagesAvailableWithNoListenersEventData)events[0].Data;
            Assert.Equal("testns1", eventData.NamespaceName);
        }

        [Fact]
        public void ConsumeServiceBusDeadletterMessagesAvailableWithNoListenersEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"eventType\": \"Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener\",  \"eventTime\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ServiceBusDeadletterMessagesAvailableWithNoListenersEventData);
            ServiceBusDeadletterMessagesAvailableWithNoListenersEventData eventData = (ServiceBusDeadletterMessagesAvailableWithNoListenersEventData)events[0].Data;
            Assert.Equal("testns1", eventData.NamespaceName);
        }

        // Storage events
        [Fact]
        public void ConsumeStorageBlobCreatedEvent()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"eventType\": \"Microsoft.Storage.BlobCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\",  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageBlobCreatedEventData);
            StorageBlobCreatedEventData eventData = (StorageBlobCreatedEventData)events[0].Data;
            Assert.Equal("https://myaccount.blob.core.windows.net/testcontainer/file1.txt", eventData.Url);
        }

        [Fact]
        public void ConsumeStorageBlobDeletedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageBlobDeletedEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[0].Data;
            Assert.Equal("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }

        [Fact]
        public void ConsumeStorageBlobRenamedEvent()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobRenamed\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"RenameFile\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"destinationUrl\": \"https://myaccount.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\",  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageBlobRenamedEventData);
            StorageBlobRenamedEventData eventData = (StorageBlobRenamedEventData)events[0].Data;
            Assert.Equal("https://myaccount.blob.core.windows.net/testcontainer/testfile.txt", eventData.DestinationUrl);
        }

        [Fact]
        public void ConsumeStorageDirectoryCreatedEvent()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"CreateDirectory\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"00000000000000EB000000000000C65A\",  },  \"dataVersion\": \"2\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageDirectoryCreatedEventData);
            StorageDirectoryCreatedEventData eventData = (StorageDirectoryCreatedEventData)events[0].Data;
            Assert.Equal("https://myaccount.blob.core.windows.net/testcontainer/testDir", eventData.Url);
        }

        [Fact]
        public void ConsumeStorageDirectoryDeletedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageDirectoryDeletedEventData);
            StorageDirectoryDeletedEventData eventData = (StorageDirectoryDeletedEventData)events[0].Data;
            Assert.Equal("https://example.blob.core.windows.net/testcontainer/testDir", eventData.Url);
        }

        [Fact]
        public void ConsumeStorageDirectoryRenamedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryRenamed\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"destinationUrl\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageDirectoryRenamedEventData);
            StorageDirectoryRenamedEventData eventData = (StorageDirectoryRenamedEventData)events[0].Data;
            Assert.Equal("https://example.blob.core.windows.net/testcontainer/testDir", eventData.DestinationUrl);
        }

        [Fact]
        public void ConsumeWebAppUpdatedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.AppUpdated\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebAppUpdatedEventData);
            WebAppUpdatedEventData eventData = (WebAppUpdatedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebBackupOperationStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.BackupOperationStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebBackupOperationStartedEventData);
            WebBackupOperationStartedEventData eventData = (WebBackupOperationStartedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebBackupOperationCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.BackupOperationCompleted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebBackupOperationCompletedEventData);
            WebBackupOperationCompletedEventData eventData = (WebBackupOperationCompletedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebBackupOperationFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.BackupOperationFailed\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebBackupOperationFailedEventData);
            WebBackupOperationFailedEventData eventData = (WebBackupOperationFailedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebRestoreOperationStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.RestoreOperationStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebRestoreOperationStartedEventData);
            WebRestoreOperationStartedEventData eventData = (WebRestoreOperationStartedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebRestoreOperationCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.RestoreOperationCompleted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebRestoreOperationCompletedEventData);
            WebRestoreOperationCompletedEventData eventData = (WebRestoreOperationCompletedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebRestoreOperationFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.RestoreOperationFailed\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebRestoreOperationFailedEventData);
            WebRestoreOperationFailedEventData eventData = (WebRestoreOperationFailedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }
        
        [Fact]
        public void ConsumeWebSlotSwapStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebSlotSwapStartedEventData);
            WebSlotSwapStartedEventData eventData = (WebSlotSwapStartedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebSlotSwapCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapCompleted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebSlotSwapCompletedEventData);
            WebSlotSwapCompletedEventData eventData = (WebSlotSwapCompletedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebSlotSwapFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapFailed\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebSlotSwapFailedEventData);
            WebSlotSwapFailedEventData eventData = (WebSlotSwapFailedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebSlotSwapWithPreviewStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapWithPreviewStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebSlotSwapWithPreviewStartedEventData);
            WebSlotSwapWithPreviewStartedEventData eventData = (WebSlotSwapWithPreviewStartedEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebSlotSwapWithPreviewCancelledEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapWithPreviewCancelled\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": null,\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebSlotSwapWithPreviewCancelledEventData);
            WebSlotSwapWithPreviewCancelledEventData eventData = (WebSlotSwapWithPreviewCancelledEventData)events[0].Data;
            Assert.Equal(siteName, eventData.Name);
        }

        [Fact]
        public void ConsumeWebAppServicePlanUpdatedEvent()
        {
            string planName = "testPlan01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/serverfarms/testPlan01\", \"subject\": \"/Microsoft.Web/serverfarms/testPlan01\",\"eventType\": \"Microsoft.Web.AppServicePlanUpdated\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appServicePlanEventTypeDetail\": {{ \"stampKind\": \"Public\",\"action\": \"Updated\",\"status\": \"Started\" }},\"name\": \"{planName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is WebAppServicePlanUpdatedEventData);
            WebAppServicePlanUpdatedEventData eventData = (WebAppServicePlanUpdatedEventData)events[0].Data;
            Assert.Equal(planName, eventData.Name);
        }

        // TODO: When new event types are introduced, add one test here for each event type

        static Stream GetStreamFromString(string eventData)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(eventData);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
