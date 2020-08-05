// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventGrid.Models;
using Azure.Messaging.EventGrid.SystemEvents;
using Microsoft.Azure.EventGrid.Tests;
using NUnit.Framework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class ConsumeEventTests
    {
        public readonly EventGridConsumer _eventGridConsumer;

        public ConsumeEventTests()
        {
            _eventGridConsumer = new EventGridConsumer();
        }

        [Test]
        public void ConsumeStorageBlobDeletedEventWithExtraProperty()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = _eventGridConsumer.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageBlobDeletedEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[0].Data;
            Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }

        [Test]
        public void ConsumeCustomEvents()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridConsumerOptions consumerOptions = new EventGridConsumerOptions();
            consumerOptions.CustomEventTypeMappings.Add("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData));
            EventGridConsumer eventGridConsumer2 = new EventGridConsumer(consumerOptions);

            EventGridEvent[] events = eventGridConsumer2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is ContosoItemReceivedEventData);
            ContosoItemReceivedEventData eventData = (ContosoItemReceivedEventData)events[0].Data;
            Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData.ItemSku);
        }

        [Test]
        public void ConsumeCustomEventWithArrayData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": [{    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553\"  }],  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridConsumerOptions consumerOptions = new EventGridConsumerOptions();
            consumerOptions.CustomEventTypeMappings.Add("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData[]));
            EventGridConsumer eventGridConsumer2 = new EventGridConsumer(consumerOptions);

            EventGridEvent[] events = eventGridConsumer2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);

            //if (events[0].Data is BinaryData)
            //{
            //    BinaryData binaryData = (BinaryData)events[0].Data;
            //    ContosoItemReceivedEventData[] data = binaryData.Deserialize<ContosoItemReceivedEventData[]>();
            //}

            Assert.True(events[0].Data is ContosoItemReceivedEventData[]);
            ContosoItemReceivedEventData[] eventData = (ContosoItemReceivedEventData[])events[0].Data;
            Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData[0].ItemSku);
        }

        [Test]
        public void ConsumeCustomEventWithBooleanData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": true,  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridConsumerOptions consumerOptions = new EventGridConsumerOptions();
            consumerOptions.CustomEventTypeMappings.Add("Contoso.Items.ItemReceived", typeof(bool));
            EventGridConsumer eventGridConsumer2 = new EventGridConsumer(consumerOptions);

            EventGridEvent[] events = eventGridConsumer2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is bool);
            bool eventData = (bool)events[0].Data;
            Assert.True(eventData);
        }

        [Test]
        public void ConsumeCustomEventWithStringData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": \"stringdata\",  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridConsumerOptions consumerOptions = new EventGridConsumerOptions();
            consumerOptions.CustomEventTypeMappings.Add("Contoso.Items.ItemReceived", typeof(string));
            EventGridConsumer eventGridConsumer2 = new EventGridConsumer(consumerOptions);

            EventGridEvent[] events = eventGridConsumer2.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is string);
            string eventData = (string)events[0].Data;
            Assert.AreEqual("stringdata", eventData);
        }

        [Test]
        public void ConsumeStorageBlobDeletedCloudEventWithAdditionalProperties()
        {
            string requestContent = "[{\"key\": \"value\",  \"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  }, \"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = _eventGridConsumer.DeserializeCloudEvents(requestContent);

            Assert.NotNull(events);
            Assert.True(events[0].Data is StorageBlobDeletedEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[0].Data;
            Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }

        [Test]
        public void ConsumeCloudEventWithBinaryDataPayload()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data_base64\": \"ZGF0YQ==\", \"type\":\"BinaryDataType\",\"specversion\":\"1.0\"}]";

            EventGridConsumerOptions consumerOptions = new EventGridConsumerOptions();
            consumerOptions.CustomEventTypeMappings.Add("BinaryDataType", typeof(byte[]));
            CloudEvent[] events = _eventGridConsumer.DeserializeCloudEvents(requestContent);
            if (events[0].Data is byte[])
            {
                byte[] data = (byte[])events[0].Data;
            }
        }

        [Test]
        public void ConsumeMultipleCloudEventsInSameBatch()
        {
            string requestContent = "[" +
                "{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",\"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },\"type\":\"Microsoft.Storage.BlobCreated\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"2947780a-356b-c5a5-feb4-f5261fb2f155\",\"source\":\"Subject-1\",\"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },\"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"cb14e05b-50c6-67dc-cafa-f4bcff3bf520\",\"source\":\"Subject-2\",\"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },\"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = _eventGridConsumer.DeserializeCloudEvents(requestContent);

            Assert.NotNull(events);
            Assert.AreEqual(3, events.Length);
            Assert.True(events[0].Data is StorageBlobCreatedEventData);
            Assert.True(events[1].Data is StorageBlobDeletedEventData);
            Assert.True(events[2].Data is StorageBlobDeletedEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[2].Data;
            Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }

        [Test]
        public void TestCustomEventMappings()
        {
            EventGridConsumerOptions consumerOptions = new EventGridConsumerOptions();
            consumerOptions.CustomEventTypeMappings.Add("Contoso.Items.ItemSent", typeof(ContosoItemSentEventData));
            consumerOptions.CustomEventTypeMappings.Add("Contoso.Items.ItemReceived", typeof(ContosoItemReceivedEventData));
            EventGridConsumer eventGridConsumer2 = new EventGridConsumer(consumerOptions);

            Assert.True(consumerOptions.CustomEventTypeMappings.TryGetValue("Contoso.Items.ItemSent", out Type retrievedType));
            Assert.AreEqual(typeof(ContosoItemSentEventData), retrievedType);

            Assert.True(consumerOptions.CustomEventTypeMappings.TryGetValue("Contoso.Items.ItemReceived", out retrievedType));
            Assert.AreEqual(typeof(ContosoItemReceivedEventData), retrievedType);
        }

        [Test]
        public void ConsumeMultipleEventsInSameBatch()
        {
            string requestContent = "[ " +
                "{  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"eventType\": \"Microsoft.Storage.BlobCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, " +
                "{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, " +
                "{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            var events = _eventGridConsumer.DeserializeEventGridEvents(requestContent);

            Assert.NotNull(events);
            Assert.AreEqual(3, events.Length);
            Assert.True(events[0].Data is StorageBlobCreatedEventData);
            Assert.True(events[1].Data is StorageBlobDeletedEventData);
            Assert.True(events[2].Data is StorageBlobDeletedEventData);
            StorageBlobDeletedEventData eventData = (StorageBlobDeletedEventData)events[2].Data;
            Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
        }
    }
}
