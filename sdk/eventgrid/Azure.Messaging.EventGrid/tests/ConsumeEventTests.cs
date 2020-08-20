// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;
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
                switch (egEvent.EventType)
                {
                    case "Microsoft.Storage.BlobDeleted":
                        StorageBlobDeletedEventData blobDeleted = (StorageBlobDeletedEventData)egEvent.GetData();
                        Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                        break;
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
                switch (egEvent.EventType)
                {
                    case "Microsoft.Storage.BlobCreated":
                        StorageBlobCreatedEventData blobCreated = (StorageBlobCreatedEventData)egEvent.GetData();
                        Assert.AreEqual("https://myaccount.blob.core.windows.net/testcontainer/file1.txt", blobCreated.Url);
                        break;
                    case "Microsoft.Storage.BlobDeleted":
                        StorageBlobDeletedEventData blobDeleted = (StorageBlobDeletedEventData)egEvent.GetData();
                        Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                        break;
                }
            }
        }

        #region Custom event tests
        [Test]
        public void ConsumeCustomEvents()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent);

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    ContosoItemReceivedEventData eventData = egEvent.GetData<ContosoItemReceivedEventData>(new JsonObjectSerializer(
                        new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }));
                    Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", eventData.ItemSku);
                }
            }
        }

        [Test]
        public void ConsumeCustomEventWithArrayData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": [{    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553\"  }],  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.Parse(requestContent);

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    ContosoItemReceivedEventData[] eventData = egEvent.GetData<ContosoItemReceivedEventData[]>(new JsonObjectSerializer(
                        new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }));
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
                    BinaryData binaryEventData = (BinaryData)egEvent.GetData();
                    Assert.True(binaryEventData.Deserialize<bool>());
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
                    BinaryData binaryEventData = (BinaryData)egEvent.GetData();
                    Assert.AreEqual("stringdata", binaryEventData.Deserialize<string>());
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
            var eventData1 = events[0].GetData<object>();
            var eventData2 = events[0].GetData();

            Assert.AreEqual(eventData1, null);
            Assert.AreEqual(eventData2, null);
            Assert.AreEqual(events[0].Type, "");
        }

        [Test]
        public void ConsumeCloudEventWithExplicitlyNullData()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\", \"data\":null, \"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);
            var eventData1 = events[0].GetData<object>();
            var eventData2 = events[0].GetData();

            Assert.AreEqual(eventData1, null);
            Assert.AreEqual(eventData2, null);
            Assert.AreEqual(events[0].Type, "");
        }

        [Test]
        public void ConsumeCloudEventWithStringData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\":\"/contoso/items\",  \"subject\": \"\",  \"data\": \"stringdata\",  \"type\": \"Contoso.Items.ItemReceived\",  \"time\": \"2018-01-25T22:12:19.4556811Z\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);

            Assert.NotNull(events);
            BinaryData binaryEventData = (BinaryData)events[0].GetData();
            string eventData = binaryEventData.Deserialize<string>();
            Assert.AreEqual("stringdata", eventData);
        }

        [Test]
        public void ConsumeCloudEventWithBinaryDataPayload()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data_base64\": \"ZGF0YQ==\", \"type\":\"BinaryDataType\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.Parse(requestContent);
            if (events[0].Type == "Test.Items.BinaryDataType")
            {
                var eventData = (byte[])events[0].GetData();
                Assert.AreEqual(Convert.ToBase64String(eventData), "ZGF0YQ==");
            }
        }

        [Test]
        public void ConsumeMultipleCloudEventsInSameBatch()
        {
            string requestContent = "[" +
                "{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",\"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },\"type\":\"Microsoft.Storage.BlobCreated\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"2947780a-356b-c5a5-feb4-f5261fb2f155\",\"source\":\"Subject-1\",\"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },\"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"cb14e05b-50c6-67dc-cafa-f4bcff3bf520\",\"source\":\"Subject-2\",\"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },\"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",\"data_base64\": \"ZGF0YQ==\",\"type\":\"BinaryDataType\",\"specversion\":\"1.0\"}," +
                "{\"id\":\"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",\"source\":\"/contoso/items\",\"subject\": \"\",\"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"type\": \"Contoso.Items.ItemReceived\"}]";

            ObjectSerializer camelCaseSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            CloudEvent[] events = CloudEvent.Parse(requestContent);

            Assert.NotNull(events);
            Assert.AreEqual(5, events.Length);
            foreach (CloudEvent cloudEvent in events)
            {
                switch (cloudEvent.GetData(), cloudEvent.Type)
                {
                    case (StorageBlobCreatedEventData blobCreated, _):
                        Assert.AreEqual("https://myaccount.blob.core.windows.net/testcontainer/file1.txt", blobCreated.Url);
                        break;
                    case (StorageBlobDeletedEventData blobDeleted, _):
                        Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                        break;
                    case (BinaryData binaryData, "BinaryDataType"):
                        Assert.AreEqual(Convert.ToBase64String(binaryData.Bytes.ToArray()), "ZGF0YQ==");
                        break;
                    case (BinaryData, "Contoso.Items.ItemReceived"):
                        ContosoItemReceivedEventData itemReceived = cloudEvent.GetData<ContosoItemReceivedEventData>(camelCaseSerializer);
                        Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", itemReceived.ItemSku);
                        break;
                }

                //switch (cloudEvent.Type)
                //{
                //    case "Microsoft.Storage.BlobCreated":
                //        StorageBlobCreatedEventData blobCreated = (StorageBlobCreatedEventData)cloudEvent.GetData();
                //        Assert.AreEqual("https://myaccount.blob.core.windows.net/testcontainer/file1.txt", blobCreated.Url);
                //        break;
                //    case "Microsoft.Storage.BlobDeleted":
                //        StorageBlobDeletedEventData blobDeleted = (StorageBlobDeletedEventData)cloudEvent.GetData();
                //        Assert.AreEqual("https://example.blob.core.windows.net/testcontainer/testfile.txt", blobDeleted.Url);
                //        break;
                //    case "BinaryDataType":
                //        byte[] binaryData = (byte[])cloudEvent.GetData();
                //        Assert.AreEqual(Convert.ToBase64String(binaryData), "ZGF0YQ==");
                //        break;
                //    case "Contoso.Items.ItemReceived":
                //        ContosoItemReceivedEventData itemReceived = cloudEvent.GetData<ContosoItemReceivedEventData>(camelCaseSerializer);
                //        Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", itemReceived.ItemSku);
                //        break;
                //}
            }
        }

        #endregion
    }
}
