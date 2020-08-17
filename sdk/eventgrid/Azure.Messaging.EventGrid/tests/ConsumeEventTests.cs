// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;
using System.Collections;
using Azure.Core.Serialization;

namespace Azure.Messaging.EventGrid.Tests
{
    public class ConsumeEventTests
    {
        #region EventGridEvent tests

        [Test]
        public void ConsumeStorageBlobDeletedEventWithExtraProperty()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent);

            Assert.NotNull(events);
            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.SystemData != null)
                {
                    switch (egEvent.SystemData)
                    {
                        case StorageBlobDeletedEventData blobDeleted:
                            Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                            break;
                    }
                }
            }
        }

        [Test]
        public void ConsumeMultipleEventsInSameBatch()
        {
            string requestContent = "[ " +
                "{  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"eventType\": \"Microsoft.Storage.BlobCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, " +
                "{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, " +
                "{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent);

            Assert.NotNull(events);
            Assert.AreEqual(3, events.Length);
            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.SystemData != null)
                {
                    switch (egEvent.SystemData)
                    {
                        case StorageBlobCreatedEventData blobCreated:
                            Assert.AreEqual("https://myaccount.blob.core.windows.net/testcontainer/file1.txt", blobCreated.Url);
                            break;
                        case StorageBlobDeletedEventData blobDeleted:
                            Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                            break;
                    }
                }
            }
        }

        #region Custom event tests
        [Test]
        public void ConsumeCustomEvents()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent, new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    ContosoItemReceivedEventData eventData = egEvent.GetData<ContosoItemReceivedEventData>();
                    Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData.ItemSku);
                }
            }
        }

        [Test]
        public void ConsumeCustomEventWithArrayData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": [{    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553\"  }],  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent, new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    ContosoItemReceivedEventData[] eventData = egEvent.GetData<ContosoItemReceivedEventData[]>();
                    Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData[0].ItemSku);
                }
            }
        }
        #endregion

        #region Primitive/string data tests
        [Test]
        public void ConsumeCustomEventWithBooleanData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": true,  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent);

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    BinaryData binaryEventData = egEvent.GetData();
                    bool eventData = binaryEventData.Deserialize<bool>();
                    Assert.True(eventData);
                }
            }
        }

        [Test]
        public void ConsumeCustomEventWithStringData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": \"stringdata\",  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent);

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    BinaryData binaryEventData = egEvent.GetData();
                    string eventData = binaryEventData.Deserialize<string>();
                    // note: binaryEventData.ToString() returns ""stringdata""?
                    Assert.AreEqual("stringdata", eventData);
                }
            }
        }
        #endregion
        #endregion

        #region CloudEvent tests
        [Test]
        public void ConsumeStorageBlobDeletedCloudEventWithAdditionalProperties()
        {
            string requestContent = "[{\"key\": \"value\",  \"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  }, \"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);
            Assert.NotNull(events);

            if (events[0].Type == "Microsoft.Storage.BlobDeleted")
            {
                StorageBlobDeletedEventData eventData = events[0].GetData<StorageBlobDeletedEventData>();
                Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", eventData.Url);
            }
        }

        [Test]
        public void ConsumeCloudEventWithNoData()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);
            var eventData = events[0].GetData<object>();

            Assert.AreEqual(eventData, null);
            Assert.AreEqual(events[0].Type, "");
        }

        [Test]
        public void ConsumeCloudEventWithExplicitlyNullData()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\", \"data\":null, \"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);
            var eventData1 = events[0].GetData<object>();
            BinaryData eventData2 = events[0].GetData();

            Assert.AreEqual(eventData1, null);
            Assert.AreEqual(eventData2.Bytes, new ReadOnlyMemory<byte>());
            Assert.AreEqual(events[0].Type, "");
        }

        [Test]
        public void ConsumeCloudEventWithBinaryDataPayload()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data_base64\": \"ZGF0YQ==\", \"type\":\"BinaryDataType\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);
            if (events[0].Type == "Test.Items.BinaryDataType")
            {
                ReadOnlyMemory<byte> eventData = events[0].GetData().Bytes;
                Assert.AreEqual(Convert.ToBase64String(eventData.ToArray()), "ZGF0YQ==");
            }
        }

        [Test]
        public void ConsumeMultipleCloudEventsInSameBatch()
        {
            string requestContent = "[" +
                "{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",\"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },\"type\":\"Microsoft.Storage.BlobCreated\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"2947780a-356b-c5a5-feb4-f5261fb2f155\",\"source\":\"Subject-1\",\"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },\"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"cb14e05b-50c6-67dc-cafa-f4bcff3bf520\",\"source\":\"Subject-2\",\"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },\"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data_base64\": \"ZGF0YQ==\", \"type\":\"BinaryDataType\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);

            Assert.NotNull(events);
            Assert.AreEqual(4, events.Length);
            foreach (CloudEvent cloudEvent in events)
            {
                switch (cloudEvent.SystemData, cloudEvent.Type)
                {
                    case (StorageBlobCreatedEventData blobCreated, _):
                        Assert.AreEqual("https://myaccount.blob.core.windows.net/testcontainer/file1.txt", blobCreated.Url);
                        break;
                    case (StorageBlobDeletedEventData blobDeleted, _):
                        Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                        break;
                    case (null, "Test.Items.BinaryDataType"):
                        ReadOnlyMemory<byte> eventData = events[0].GetData().Bytes;
                        Assert.AreEqual(Convert.ToBase64String(eventData.ToArray()), "ZGF0YQ==");
                        break;
                }
            }
        }

        #endregion
    }
}
