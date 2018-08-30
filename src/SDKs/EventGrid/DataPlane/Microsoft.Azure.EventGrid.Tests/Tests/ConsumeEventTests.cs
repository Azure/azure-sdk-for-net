// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.EventGrid.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

        // Media Services events
        [Fact]
        public void ConsumeMediaServicesJobStateChangedEvent()
        {
            string requestContent = "[   {    \"topic\": \"/subscriptions/{subscription id}/resourceGroups/amsResourceGroup/providers/Microsoft.Media/mediaservices/amsaccount\",    \"subject\": \"transforms/VideoAnalyzerTransform/jobs/{job id}\",    \"eventType\": \"Microsoft.Media.JobStateChange\",    \"eventTime\": \"2018-04-20T21:26:13.8978772\",    \"id\": \"<id>\",    \"data\": {      \"previousState\": \"Processing\",      \"state\": \"Finished\"    },    \"dataVersion\": \"1.0\",    \"metadataVersion\": \"1\"  }]";

            var events = this.eventGridSubscriber.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is MediaJobStateChangeEventData);
            MediaJobStateChangeEventData eventData = (MediaJobStateChangeEventData)events[0].Data;
            Assert.Equal(JobState.Finished, eventData.State);
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
