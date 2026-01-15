// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json;
using Azure.Messaging.EventGrid.SystemEvents;
using NUnit.Framework;
using Azure.Core.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Azure.Messaging.EventGrid.Models;
using AcsRouterJobStatus = Azure.Messaging.EventGrid.Models.AcsRouterJobStatus;

namespace Azure.Messaging.EventGrid.Tests
{
    public class ConsumeEventTests
    {
        #region EventGridEvent tests

        #region Miscellaneous tests
        [Test]
        public void ParsesEventGridEnvelope()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"mySubject\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));
            var egEvent = events[0];
            Assert.That(egEvent.Topic, Is.EqualTo("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"));
            Assert.That(egEvent.Id, Is.EqualTo("2d1781af-3a4c-4d7c-bd0c-e34b19da4e66"));
            Assert.That(egEvent.Subject, Is.EqualTo("mySubject"));
            Assert.That(egEvent.EventType, Is.EqualTo(SystemEventNames.EventGridSubscriptionValidation));
            Assert.That(egEvent.EventTime, Is.EqualTo(DateTimeOffset.Parse("2018-01-25T22:12:19.4556811Z")));
            Assert.That(egEvent.DataVersion, Is.EqualTo("1"));
        }

        [Test]
        public void ParsesEventGridEnvelopeUsingConverter()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"mySubject\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = JsonSerializer.Deserialize<EventGridEvent[]>(requestContent);
            var egEvent = events[0];
            Assert.That(egEvent.Topic, Is.EqualTo("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"));
            Assert.That(egEvent.Id, Is.EqualTo("2d1781af-3a4c-4d7c-bd0c-e34b19da4e66"));
            Assert.That(egEvent.Subject, Is.EqualTo("mySubject"));
            Assert.That(egEvent.EventType, Is.EqualTo(SystemEventNames.EventGridSubscriptionValidation));
            Assert.That(egEvent.EventTime, Is.EqualTo(DateTimeOffset.Parse("2018-01-25T22:12:19.4556811Z")));
            Assert.That(egEvent.DataVersion, Is.EqualTo("1"));
        }

        [Test]
        public void ConsumeStorageBlobDeletedEventWithExtraProperty()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            foreach (EventGridEvent egEvent in events)
            {
                switch (egEvent.EventType)
                {
                    case SystemEventNames.StorageBlobDeleted:
                        StorageBlobDeletedEventData blobDeleted = egEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                        Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                        Assert.That(egEvent.Topic, Is.EqualTo("/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount"));
                        break;
                }
            }
        }

        [Test]
        public void ConsumeEventNotWrappedInAnArray()
        {
            string requestContent = "{  \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            foreach (EventGridEvent egEvent in events)
            {
                switch (egEvent.EventType)
                {
                    case SystemEventNames.StorageBlobDeleted:
                        StorageBlobDeletedEventData blobDeleted = egEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                        Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                        break;
                }
            }
        }

        [Test]
        public void ConsumeEventNotWrappedInAnArrayWithConverter()
        {
            string requestContent = "{  \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}";

            EventGridEvent egEvent = JsonSerializer.Deserialize<EventGridEvent>(requestContent);

            Assert.NotNull(egEvent);
            switch (egEvent.EventType)
            {
                case SystemEventNames.StorageBlobDeleted:
                    StorageBlobDeletedEventData blobDeleted = egEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                    Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                    break;
            }
        }

        [Test]
        public void ConsumeMultipleEventsInSameBatch()
        {
            string requestContent = "[ " +
                "{  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"eventType\": \"Microsoft.Storage.BlobCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, " +
                "{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}, " +
                "{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events.Length, Is.EqualTo(3));
            foreach (EventGridEvent egEvent in events)
            {
                switch (egEvent.EventType)
                {
                    case SystemEventNames.StorageBlobCreated:
                        StorageBlobCreatedEventData blobCreated = egEvent.Data.ToObjectFromJson<StorageBlobCreatedEventData>();
                        Assert.That(blobCreated.Url, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/file1.txt"));
                        break;
                    case SystemEventNames.StorageBlobDeleted:
                        StorageBlobDeletedEventData blobDeleted = egEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                        Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                        break;
                }
            }
        }

        [Test]
        public void ConsumeEventUsingBinaryDataExtensionMethod()
        {
            BinaryData messageBody = new BinaryData("{  \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}");

            EventGridEvent egEvent = EventGridEvent.Parse(messageBody);

            Assert.NotNull(egEvent);
            switch (egEvent.EventType)
            {
                case SystemEventNames.StorageBlobDeleted:
                    StorageBlobDeletedEventData blobDeleted = egEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                    Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                    break;
            }
        }

        [Test]
        public void EGEventParseThrowsIfMissingRequiredProperties()
        {
            // missing Id and dataVersion
            string requestContent = "[{  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\"}]";

            Assert.That(() => EventGridEvent.ParseMany(new BinaryData(requestContent)),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void EGEventParseThrowsOnNullInput()
        {
            Assert.That(() => EventGridEvent.ParseMany(null),
                Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => EventGridEvent.Parse(null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ParseBinaryDataThrowsOnMultipleEgEvents()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"mySubject\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}, {  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"mySubject\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            Assert.That(() => EventGridEvent.Parse(new BinaryData(requestContent)),
                Throws.InstanceOf<ArgumentException>());
        }
        #endregion

        #region Custom event tests
        [Test]
        public void ConsumeCustomEvents()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    ContosoItemReceivedEventData eventData = egEvent.Data.ToObject<ContosoItemReceivedEventData>(new JsonObjectSerializer(
                        new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }));
                    Assert.That(eventData.ItemSku, Is.EqualTo("512d38b6-c7b8-40c8-89fe-f46f9e9622b6"));
                }
            }
        }

        [Test]
        public void ConsumeCustomEventWithArrayData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": [{    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553\"  }],  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    ContosoItemReceivedEventData[] eventData = egEvent.Data.ToObject<ContosoItemReceivedEventData[]>(new JsonObjectSerializer(
                        new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        }));
                    Assert.That(eventData[0].ItemSku, Is.EqualTo("512d38b6-c7b8-40c8-89fe-f46f9e9622b6"));
                }
            }
        }
        #endregion

        #region Primitive/string data tests
        [Test]
        public void ConsumeCustomEventWithBooleanData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": true,  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    BinaryData binaryEventData = egEvent.Data;
                    Assert.That(binaryEventData.ToObjectFromJson<bool>(), Is.True);
                }
            }
        }

        [Test]
        public void ConsumeCustomEventWithStringData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": \"stringdata\",  \"eventType\": \"Contoso.Items.ItemReceived\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);

            foreach (EventGridEvent egEvent in events)
            {
                if (egEvent.EventType == "Contoso.Items.ItemReceived")
                {
                    BinaryData binaryEventData = egEvent.Data;
                    Assert.That(binaryEventData.ToObjectFromJson<string>(), Is.EqualTo("stringdata"));
                }
            }
        }
        #endregion

        #region AppConfiguration events
        [Test]
        public void ConsumeAppConfigurationKeyValueDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.AppConfiguration.KeyValueDeleted\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"key\":\"key1\",\"label\":\"label1\",\"etag\":\"etag1\"}, \"dataVersion\": \"\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as AppConfigurationKeyValueDeletedEventData).Key, Is.EqualTo("key1"));
        }

        [Test]
        public void ConsumeAppConfigurationKeyValueModifiedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.AppConfiguration.KeyValueModified\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"key\":\"key1\",\"label\":\"label1\",\"etag\":\"etag1\"}, \"dataVersion\": \"\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as AppConfigurationKeyValueModifiedEventData).Key, Is.EqualTo("key1"));
        }
        #endregion

        #region ContainerRegistry events
        [Test]
        public void ConsumeContainerRegistryImagePushedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ImagePushed\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}},  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryImagePushedEventData).Request.Addr, Is.EqualTo("127.0.0.1"));
        }

        [Test]
        public void ConsumeContainerRegistryImageDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ImageDeleted\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}},  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryImageDeletedEventData).Actor.Name, Is.EqualTo("testactor"));
        }

        [Test]
        public void ConsumeContainerRegistryChartDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ChartDeleted\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"id\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"action1\",\"target\":{\"mediaType\":\"mediatype1\",\"size\":20,\"digest\":\"digest1\",\"repository\":null,\"tag\":null,\"name\":\"name1\",\"version\":null}}, \"dataVersion\":\"\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryChartDeletedEventData).Target.MediaType, Is.EqualTo("mediatype1"));
        }

        [Test]
        public void ConsumeContainerRegistryChartPushedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.ContainerRegistry.ChartPushed\",  \"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"id\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"action1\",\"target\":{\"mediaType\":\"mediatype1\",\"size\":40,\"digest\":\"digest1\",\"repository\":null,\"tag\":null,\"name\":\"name1\",\"version\":null}}, \"dataVersion\":\"\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryChartPushedEventData).Target.MediaType, Is.EqualTo("mediatype1"));
        }
        #endregion

        #region Container service events
        [Test]
        public void ConsumeContainerServiceSupportEndedEvent()
        {
            string requestContent = @"
            {
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""eventType"": ""Microsoft.ContainerService.ClusterSupportEnded"",
                ""eventTime"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""kubernetesVersion"": ""1.23.15""
                },
                ""dataVersion"": ""1"",
                ""metadataVersion"": ""1""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceClusterSupportEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
            Assert.That((eventData as ContainerServiceClusterSupportEndedEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
        }

        [Test]
        public void ConsumeContainerServiceSupportEndingEvent()
        {
            string requestContent = @"
            {
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""eventType"": ""Microsoft.ContainerService.ClusterSupportEnding"",
                ""eventTime"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""kubernetesVersion"": ""1.23.15""
                },
                ""dataVersion"": ""1"",
                ""metadataVersion"": ""1""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceClusterSupportEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
            Assert.That((eventData as ContainerServiceClusterSupportEndingEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
        }

        [Test]
        public void ConsumeContainerServiceNodePoolRollingFailed()
        {
            string requestContent = @"
            {
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""eventType"": ""Microsoft.ContainerService.NodePoolRollingFailed"",
                ""eventTime"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""nodePoolName"": ""nodepool1""
                },
                ""dataVersion"": ""1"",
                ""metadataVersion"": ""1""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceNodePoolRollingEventData).NodePoolName, Is.EqualTo("nodepool1"));
            Assert.That((eventData as ContainerServiceNodePoolRollingFailedEventData).NodePoolName, Is.EqualTo("nodepool1"));
        }

        [Test]
        public void ConsumeContainerServiceNodePoolRollingStarted()
        {
            string requestContent = @"
            {
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""eventType"": ""Microsoft.ContainerService.NodePoolRollingStarted"",
                ""eventTime"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""nodePoolName"": ""nodepool1""
                },
                ""dataVersion"": ""1"",
                ""metadataVersion"": ""1""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceNodePoolRollingEventData).NodePoolName, Is.EqualTo("nodepool1"));
            Assert.That((eventData as ContainerServiceNodePoolRollingStartedEventData).NodePoolName, Is.EqualTo("nodepool1"));
        }

        [Test]
        public void ConsumeContainerServiceNodePoolRollingSucceeded()
        {
            string requestContent = @"
            {
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""eventType"": ""Microsoft.ContainerService.NodePoolRollingSucceeded"",
                ""eventTime"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""nodePoolName"": ""nodepool1""
                },
                ""dataVersion"": ""1"",
                ""metadataVersion"": ""1""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceNodePoolRollingEventData).NodePoolName, Is.EqualTo("nodepool1"));
            Assert.That((eventData as ContainerServiceNodePoolRollingSucceededEventData).NodePoolName, Is.EqualTo("nodepool1"));
        }
        #endregion

        #region IoTHub Device events
        [Test]
        public void ConsumeIoTHubDeviceCreatedEvent()
        {
            string requestContent = "[{ \"id\": \"2da5e9b4-4e38-04c1-cc58-9da0b37230c0\", \"topic\": \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\", \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\", \"eventType\": \"Microsoft.Devices.DeviceCreated\", \"eventTime\": \"2018-07-03T23:20:07.6532054Z\",    \"data\": {      \"twin\": {        \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",        \"etag\": \"AAAAAAAAAAE=\",        \"deviceEtag\": null,        \"status\": \"enabled\",        \"statusUpdateTime\": \"0001-01-01T00:00:00\",        \"connectionState\": \"Disconnected\",        \"lastActivityTime\": \"0001-01-01T00:00:00\",        \"cloudToDeviceMessageCount\": 0,        \"authenticationType\": \"sas\",        \"x509Thumbprint\": {          \"primaryThumbprint\": null,          \"secondaryThumbprint\": null        },        \"version\": 2,        \"properties\": {          \"desired\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          },          \"reported\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          }        }      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceCreatedEventData).Twin.Status, Is.EqualTo("enabled"));
        }

        [Test]
        public void ConsumeIoTHubDeviceDeletedEvent()
        {
            string requestContent = "[  {    \"id\": \"aaaf95c6-ed99-b307-e321-81d8e4f731a6\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceDeleted\",    \"eventTime\": \"2018-07-03T23:21:33.2753956Z\",    \"data\": {      \"twin\": {        \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",        \"etag\": \"AAAAAAAAAAI=\",        \"deviceEtag\": null,        \"status\": \"enabled\",        \"statusUpdateTime\": \"0001-01-01T00:00:00\",        \"connectionState\": \"Disconnected\",        \"lastActivityTime\": \"0001-01-01T00:00:00\",        \"cloudToDeviceMessageCount\": 0,        \"authenticationType\": \"sas\",        \"x509Thumbprint\": {          \"primaryThumbprint\": null,          \"secondaryThumbprint\": null        },        \"version\": 3,        \"tags\": {          \"testKey\": \"testValue\"        },        \"properties\": {          \"desired\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          },          \"reported\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          }        }      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceDeletedEventData).Twin.Etag, Is.EqualTo("AAAAAAAAAAI="));
        }

        [Test]
        public void ConsumeIoTHubDeviceConnectedEvent()
        {
            string requestContent = "[  {    \"id\": \"fbfd8ee1-cf78-74c6-dbcf-e1c58638ccbd\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceConnected\",    \"eventTime\": \"2018-07-03T23:20:11.6921933+00:00\",    \"data\": {      \"deviceConnectionStateEventInfo\": {        \"sequenceNumber\":          \"000000000000000001D4132452F67CE200000002000000000000000000000001\"      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",      \"moduleId\": \"\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceConnectedEventData).HubName, Is.EqualTo("EGTESTHUB1"));
        }

        [Test]
        public void ConsumeIoTHubDeviceDisconnectedEvent()
        {
            string requestContent = "[  {    \"id\": \"877f0b10-a086-98ec-27b8-6ae2dfbf5f67\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceDisconnected\",    \"eventTime\": \"2018-07-03T23:20:52.646434+00:00\",    \"data\": {      \"deviceConnectionStateEventInfo\": {        \"sequenceNumber\":          \"000000000000000001D4132452F67CE200000002000000000000000000000002\"      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",      \"moduleId\": \"\"    },    \"dataVersion\": \"\",    \"metadataVersion\": \"1\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceDisconnectedEventData).DeviceConnectionStateEventInfo.SequenceNumber, Is.EqualTo("000000000000000001D4132452F67CE200000002000000000000000000000002"));
        }

        [Test]
        public void ConsumeIoTHubDeviceTelemetryEvent()
        {
            string requestContent = "[{  \"id\": \"877f0b10-a086-98ec-27b8-6ae2dfbf5f67\",    \"topic\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"eventType\": \"Microsoft.Devices.DeviceTelemetry\",    \"eventTime\": \"2018-07-03T23:20:52.646434+00:00\",    \"data\": { \"body\": { \"Weather\": { \"Temperature\": 900  }, \"Location\": \"USA\"  },  \"properties\": {  \"Status\": \"Active\"  },  \"systemProperties\": { \"iothub-content-type\": \"application/json\", \"iothub-content-encoding\": \"utf-8\"   } }, \"dataVersion\": \"\"}   ]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceTelemetryEventData).Properties["Status"], Is.EqualTo("Active"));
        }
        #endregion

        #region EventGrid events

        //[Test]
        //public void ConsumeEventGridSubscriptionValidationEvent()
        //{
        //    string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"mySubject\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

        //    EventGridEvent[] events = EventGridEvent.Parse(requestContent);
        //    var egEvent = events[0];
        //    Assert.AreEqual("/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx", egEvent.Topic);
        //    Assert.AreEqual("2d1781af-3a4c-4d7c-bd0c-e34b19da4e66", egEvent.Id);
        //    Assert.AreEqual("mySubject", egEvent.Subject);

        //    Assert.NotNull(events);
        //    Assert.True(events[0].TryGetSystemEventData(out object eventData));
        //    Assert.True(events[0].GetData<SubscriptionValidationEventData>() is SubscriptionValidationEventData);
        //    Assert.AreEqual("512d38b6-c7b8-40c8-89fe-f46f9e9622b6", (eventData as SubscriptionValidationEventData).ValidationCode);
        //}

        [Test]
        public void ConsumeEventGridSubscriptionDeletedEvent()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"topic\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"eventSubscriptionId\": \"/subscriptions/id/resourceGroups/rg/providers/Microsoft.EventGrid/topics/topic1/providers/Microsoft.EventGrid/eventSubscriptions/eventsubscription1\"  },  \"eventType\": \"Microsoft.EventGrid.SubscriptionDeletedEvent\",  \"eventTime\": \"2018-01-25T22:12:19.4556811Z\",  \"metadataVersion\": \"1\",  \"dataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That(
                (eventData as SubscriptionDeletedEventData).EventSubscriptionId,
                Is.EqualTo("/subscriptions/id/resourceGroups/rg/providers/Microsoft.EventGrid/topics/topic1/providers/Microsoft.EventGrid/eventSubscriptions/eventsubscription1"));
        }
        #endregion

        #region Event Hub Events
        [Test]
        public void ConsumeEventHubCaptureFileCreatedEvent()
        {
            string requestContent = "[    {        \"topic\": \"/subscriptions/guid/resourcegroups/rgDataMigrationSample/providers/Microsoft.EventHub/namespaces/tfdatamigratens\",        \"subject\": \"eventhubs/hubdatamigration\",        \"eventType\": \"microsoft.EventHUB.CaptureFileCreated\",        \"eventTime\": \"2017-08-31T19:12:46.0498024Z\",        \"id\": \"14e87d03-6fbf-4bb2-9a21-92bd1281f247\",        \"data\": {            \"fileUrl\": \"https://tf0831datamigrate.blob.core.windows.net/windturbinecapture/tfdatamigratens/hubdatamigration/1/2017/08/31/19/11/45.avro\",            \"fileType\": \"AzureBlockBlob\",            \"partitionId\": \"1\",            \"sizeInBytes\": 249168,            \"eventCount\": 1500,            \"firstSequenceNumber\": 2400,            \"lastSequenceNumber\": 3899,            \"firstEnqueueTime\": \"2017-08-31T19:12:14.674Z\",            \"lastEnqueueTime\": \"2017-08-31T19:12:44.309Z\"        },        \"dataVersion\": \"\",        \"metadataVersion\": \"1\"    }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as EventHubCaptureFileCreatedEventData).FileType, Is.EqualTo("AzureBlockBlob"));
        }
        #endregion

        #region MachineLearningServices events
        [Test]
        public void ConsumeMachineLearningServicesModelRegisteredEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.ModelRegistered\",\"subject\":\"models/sklearn_regression_model:3\",\"eventTime\":\"2019-10-17T22:23:57.5350054+00:00\",\"id\":\"3b73ee51-bbf4-480d-9112-cfc23b41bfdb\",\"data\":{\"modelName\":\"sklearn_regression_model\",\"modelVersion\":\"3\",\"modelTags\":{\"area\":\"diabetes\",\"type\":\"regression\"},\"modelProperties\":{\"area\":\"test\"}},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var sysData = eventData as MachineLearningServicesModelRegisteredEventData;
            Assert.That(sysData.ModelName, Is.EqualTo("sklearn_regression_model"));
            Assert.That(sysData.ModelVersion, Is.EqualTo("3"));

            Assert.That(sysData.ModelTags is IDictionary, Is.True);
            IDictionary tags = (IDictionary)sysData.ModelTags;
            Assert.That(tags["type"], Is.EqualTo("regression"));

            Assert.That(sysData.ModelProperties is IDictionary, Is.True);
            IDictionary properties = (IDictionary)sysData.ModelProperties;
            Assert.That(properties["area"], Is.EqualTo("test"));
        }

        [Test]
        public void ConsumeMachineLearningServicesModelDeployedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.ModelDeployed\",\"subject\":\"endpoints/aciservice1\",\"eventTime\":\"2019-10-23T18:20:08.8824474+00:00\",\"id\":\"40d0b167-be44-477b-9d23-a2befba7cde0\",\"data\":{\"serviceName\":\"aciservice1\",\"serviceComputeType\":\"ACI\",\"serviceTags\":{\"mytag\":\"test tag\"},\"serviceProperties\":{\"myprop\":\"test property\"},\"modelIds\":\"my_first_model:1,my_second_model:1\"},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesModelDeployedEventData).ServiceName, Is.EqualTo("aciservice1"));
            Assert.That((eventData as MachineLearningServicesModelDeployedEventData).ModelIds.Split(',').Length, Is.EqualTo(2));
        }

        [Test]
        public void ConsumeMachineLearningServicesRunCompletedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.RunCompleted\",\"subject\":\"experiments/0fa9dfaa-cba3-4fa7-b590-23e48548f5c1/runs/AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"eventTime\":\"2019-10-18T19:29:55.8856038+00:00\",\"id\":\"044ac44d-462c-4043-99eb-d9e01dc760ab\",\"data\":{\"experimentId\":\"0fa9dfaa-cba3-4fa7-b590-23e48548f5c1\",\"experimentName\":\"automl-local-regression\",\"runId\":\"AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"runType\":\"automl\",\"RunTags\":{\"experiment_status\":\"ModelSelection\",\"experiment_status_descr\":\"Beginning model selection.\"},\"runProperties\":{\"num_iterations\":\"10\",\"target\":\"local\"}},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesRunCompletedEventData).RunId, Is.EqualTo("AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc"));
            Assert.That((eventData as MachineLearningServicesRunCompletedEventData).ExperimentName, Is.EqualTo("automl-local-regression"));
        }

        [Test]
        public void ConsumeMachineLearningServicesRunStatusChangedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"eventType\":\"Microsoft.MachineLearningServices.RunStatusChanged\",\"subject\":\"experiments/0fa9dfaa-cba3-4fa7-b590-23e48548f5c1/runs/AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"eventTime\":\"2020-03-09T23:53:04.4579724Z\",\"id\":\"aa8cd7df-fe28-5d5d-9b40-3342dbc2a887\",\"data\":{\"runStatus\": \"Running\",\"experimentId\":\"0fa9dfaa-cba3-4fa7-b590-23e48548f5c1\",\"experimentName\":\"automl-local-regression\",\"runId\":\"AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"runType\":\"automl\",\"runTags\":{\"experiment_status\":\"ModelSelection\",\"experiment_status_descr\":\"Beginning model selection.\"},\"runProperties\":{\"num_iterations\":\"10\",\"target\":\"local\"}},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesRunStatusChangedEventData).RunId, Is.EqualTo("AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc"));
            Assert.That((eventData as MachineLearningServicesRunStatusChangedEventData).ExperimentName, Is.EqualTo("automl-local-regression"));
            Assert.That((eventData as MachineLearningServicesRunStatusChangedEventData).RunStatus, Is.EqualTo("Running"));
            Assert.That((eventData as MachineLearningServicesRunStatusChangedEventData).RunType, Is.EqualTo("automl"));
        }

        [Test]
        public void ConsumeMachineLearningServicesDatasetDriftDetectedEvent()
        {
            string requestContent = "[{\"topic\":\"/subscriptions/60582a10-b9fd-49f1-a546-c4194134bba8/resourceGroups/copetersRG/providers/Microsoft.MachineLearningServices/workspaces/driftDemoWS\",\"eventType\":\"Microsoft.MachineLearningServices.DatasetDriftDetected\",\"subject\":\"datadrift/01d29aa4-e6a4-470a-9ef3-66660d21f8ef/run/01d29aa4-e6a4-470a-9ef3-66660d21f8ef_1571590300380\",\"eventTime\":\"2019-10-20T17:08:08.467191+00:00\",\"id\":\"2684de79-b145-4dcf-ad2e-6a1db798585f\",\"data\":{\"dataDriftId\":\"01d29aa4-e6a4-470a-9ef3-66660d21f8ef\",\"dataDriftName\":\"copetersDriftMonitor3\",\"runId\":\"01d29aa4-e6a4-470a-9ef3-66660d21f8ef_1571590300380\",\"baseDatasetId\":\"3c56d136-0f64-4657-a0e8-5162089a88a3\",\"tarAsSystemEventDatasetId\":\"d7e74d2e-c972-4266-b5fb-6c9c182d2a74\",\"driftCoefficient\":0.8350349068479208,\"startTime\":\"2019-07-04T00:00:00+00:00\",\"endTime\":\"2019-07-05T00:00:00+00:00\"},\"dataVersion\":\"2\",\"metadataVersion\":\"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesDatasetDriftDetectedEventData).DataDriftName, Is.EqualTo("copetersDriftMonitor3"));
        }
        #endregion

        #region Maps events
        [Test]
        public void ConsumeMapsGeofenceEnteredEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.Maps.GeofenceEntered\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":[\"id1\",\"id2\"],\"isEventPublished\":true}, \"dataVersion\":\"\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MapsGeofenceEnteredEventData).Geometries[0].Distance, Is.EqualTo(1.0));
        }

        [Test]
        public void ConsumeMapsGeofenceExitedEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.Maps.GeofenceExited\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":[\"id1\",\"id2\"],\"isEventPublished\":true}, \"dataVersion\":\"\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MapsGeofenceExitedEventData).Geometries[0].Distance, Is.EqualTo(1.0));
        }

        [Test]
        public void ConsumeMapsGeofenceResultEvent()
        {
            string requestContent = "[{  \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"topic\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"eventType\": \"Microsoft.Maps.GeofenceResult\",\"eventTime\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":[\"id1\",\"id2\"],\"isEventPublished\":true}, \"dataVersion\":\"\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MapsGeofenceResultEventData).Geometries[0].Distance, Is.EqualTo(1.0));
        }
        #endregion

        #region Media Services events
        [Test]
        public void ConsumeMediaMediaJobStateChangeEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobStateChange\",  \"eventTime\": \"2018-10-12T15:14:20.2412317\",  \"id\": \"341520d0-dac0-4930-97dd-3085538c624f\",  \"data\": {    \"previousState\": \"Scheduled\",    \"state\": \"Processing\",    \"correlationData\": {}  },  \"dataVersion\": \"2.0\",  \"metadataVersion\": \"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobStateChangeEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobStateChangeEventData).State, Is.EqualTo(MediaJobState.Processing));
        }

        [Test]
        public void ConsumeMediaJobOutputStateChangeEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputStateChange\",  \"eventTime\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"8d0305c0-28c0-4cc9-b613-776e4dd31e9a\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {\"code\":\"ServiceError\", \"message\":\"error message\", \"category\":\"Service\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputStateChangeEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobOutputStateChangeEventData).Output.State, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobOutputStateChangeEventData).Output is MediaJobOutputAsset, Is.True);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)(eventData as MediaJobOutputStateChangeEventData).Output;
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-2ac2fe75-6557-4de5-ab25-5713b74a6901"));

            Assert.That(outputAsset.Error.Category, Is.EqualTo(MediaJobErrorCategory.Service));
            Assert.That(outputAsset.Error.Code, Is.EqualTo(MediaJobErrorCode.ServiceError));
        }

        [Test]
        public void ConsumeMediaJobOutputStateChangeEvent_UnknownError()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputStateChange\",  \"eventTime\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"8d0305c0-28c0-4cc9-b613-776e4dd31e9a\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {\"code\":\"SomeNewCode\", \"message\":\"error message\", \"category\":\"SomeNewCategory\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputStateChangeEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobOutputStateChangeEventData).Output.State, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobOutputStateChangeEventData).Output is MediaJobOutputAsset, Is.True);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)(eventData as MediaJobOutputStateChangeEventData).Output;
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-2ac2fe75-6557-4de5-ab25-5713b74a6901"));

            Assert.That(outputAsset.Error.Category, Is.EqualTo((MediaJobErrorCategory)int.MaxValue));
            Assert.That(outputAsset.Error.Code, Is.EqualTo((MediaJobErrorCode)int.MaxValue));
        }

        [Test]
        public void ConsumeMediaJobScheduledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobScheduled\",  \"eventTime\": \"2018-10-12T15:14:11.3028183\",  \"id\": \"9b17dbf0-355d-4fb0-9a73-e76b150858c8\",  \"data\": {    \"previousState\": \"Queued\",    \"state\": \"Scheduled\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobScheduledEventData).PreviousState, Is.EqualTo(MediaJobState.Queued));
            Assert.That((eventData as MediaJobScheduledEventData).State, Is.EqualTo(MediaJobState.Scheduled));
        }

        [Test]
        public void ConsumeMediaJobProcessingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobProcessing\",  \"eventTime\": \"2018-10-12T15:14:20.2412317\",  \"id\": \"72162c44-c7f4-437a-9592-48b83cec2d18\",  \"data\": {    \"previousState\": \"Scheduled\",    \"state\": \"Processing\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobProcessingEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobProcessingEventData).State, Is.EqualTo(MediaJobState.Processing));
        }

        [Test]
        public void ConsumeMediaJobCancelingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobCanceling\",  \"eventTime\": \"2018-10-12T15:41:50.5513295\",  \"id\": \"1f9a488b-abe3-4fca-80b8-aae59bf7f123\",  \"data\": {    \"previousState\": \"Processing\",    \"state\": \"Canceling\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobCancelingEventData).PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobCancelingEventData).State, Is.EqualTo(MediaJobState.Canceling));
        }

        [Test]
        public void ConsumeMediaJobFinishedEvent()
        {
            string requestContent = "[{ \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-298338bb-f8d1-4d0f-9fde-544e0ac4d983\",  \"eventType\": \"Microsoft.Media.JobFinished\",  \"eventTime\": \"2018-10-01T20:58:26.7886175\",  \"id\": \"83f8464d-be94-48e5-b67b-46c6199fe28e\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-298338bb-f8d1-4d0f-9fde-544e0ac4d983\",       \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 100,        \"state\": \"Finished\"      }    ],    \"previousState\": \"Processing\",    \"state\": \"Finished\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\" }]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobFinishedEventData).PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobFinishedEventData).State, Is.EqualTo(MediaJobState.Finished));
            Assert.That((eventData as MediaJobFinishedEventData).Outputs.Count, Is.EqualTo(1));
            Assert.That((eventData as MediaJobFinishedEventData).Outputs[0] is MediaJobOutputAsset, Is.True);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)(eventData as MediaJobFinishedEventData).Outputs[0];

            Assert.That(outputAsset.State, Is.EqualTo(MediaJobState.Finished));
            Assert.That(outputAsset.Error, Is.Null);
            Assert.That(outputAsset.Progress, Is.EqualTo(100));
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-298338bb-f8d1-4d0f-9fde-544e0ac4d983"));
        }

        [Test]
        public void ConsumeMediaJobCanceledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobCanceled\",  \"eventTime\": \"2018-10-12T15:42:05.6519929\",  \"id\": \"3fef7871-f916-4980-8a45-e79a2675808b\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",        \"error\": {\"code\":\"ServiceError\", \"message\":\"error message\", \"category\":\"Service\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 83,        \"state\": \"Canceled\"      }    ],    \"previousState\": \"Canceling\",    \"state\": \"Canceled\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobCanceledEventData).PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That((eventData as MediaJobCanceledEventData).State, Is.EqualTo(MediaJobState.Canceled));
            Assert.That((eventData as MediaJobCanceledEventData).Outputs.Count, Is.EqualTo(1));
            Assert.That((eventData as MediaJobCanceledEventData).Outputs[0] is MediaJobOutputAsset, Is.True);

            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)(eventData as MediaJobCanceledEventData).Outputs[0];

            Assert.That(outputAsset.State, Is.EqualTo(MediaJobState.Canceled));
            Assert.That(outputAsset.Progress, Is.Not.EqualTo(100));
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-7a8215f9-0f8d-48a6-82ed-1ead772bc221"));
        }

        [Test]
        public void ConsumeMediaJobErroredEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobErrored\",  \"eventTime\": \"2018-10-12T15:29:20.9954767\",  \"id\": \"2749e9cf-4095-4723-9bc5-df8e15289135\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",        \"error\": {          \"category\": \"Service\",          \"code\": \"ServiceError\",          \"details\": [            {              \"code\": \"Internal\",              \"message\": \"Internal error in initializing the task for processing\"            }          ],          \"message\": \"Fatal service error, please contact support.\",          \"retry\": \"DoNotRetry\"        },        \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 83,        \"state\": \"Error\"      }    ],    \"previousState\": \"Processing\",    \"state\": \"Error\",    \"correlationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobErroredEventData).PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobErroredEventData).State, Is.EqualTo(MediaJobState.Error));
            Assert.That((eventData as MediaJobErroredEventData).Outputs.Count, Is.EqualTo(1));
            Assert.That((eventData as MediaJobErroredEventData).Outputs[0] is MediaJobOutputAsset, Is.True);

            Assert.That((eventData as MediaJobErroredEventData).Outputs[0].State, Is.EqualTo(MediaJobState.Error));
            Assert.NotNull((eventData as MediaJobErroredEventData).Outputs[0].Error);
            Assert.That((eventData as MediaJobErroredEventData).Outputs[0].Error.Category, Is.EqualTo(MediaJobErrorCategory.Service));
            Assert.That((eventData as MediaJobErroredEventData).Outputs[0].Error.Code, Is.EqualTo(MediaJobErrorCode.ServiceError));
        }

        [Test]
        public void ConsumeMediaJobOutputCanceledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobOutputCanceled\",  \"eventTime\": \"2018-10-12T15:42:04.949555\",  \"id\": \"9297cda2-4a50-4622-a679-c3785d27d512\",  \"data\": {    \"previousState\": \"Canceling\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",      \"error\": {\"code\":\"ServiceError\", \"message\":\"error message\", \"category\":\"Service\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Canceled\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputCanceledEventData).PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That((eventData as MediaJobOutputCanceledEventData).Output.State, Is.EqualTo(MediaJobState.Canceled));
            Assert.That((eventData as MediaJobOutputCanceledEventData).Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeMediaJobOutputCancelingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"eventType\": \"Microsoft.Media.JobOutputCanceling\",  \"eventTime\": \"2018-10-12T15:42:04.949555\",  \"id\": \"9297cda2-4a50-4622-a679-c3785d27d512\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Canceling\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputCancelingEventData).PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobOutputCancelingEventData).Output.State, Is.EqualTo(MediaJobState.Canceling));
            Assert.That((eventData as MediaJobOutputCancelingEventData).Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeMediaJobOutputErroredEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputErrored\",  \"eventTime\": \"2018-10-12T15:29:20.2621252\",  \"id\": \"bc9e6342-f081-49c2-a579-92f506a622c2\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Error\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputErroredEventData sysEvent = eventData as MediaJobOutputErroredEventData;
            Assert.That(sysEvent.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysEvent.Output.State, Is.EqualTo(MediaJobState.Error));
            Assert.That(sysEvent.Output is MediaJobOutputAsset, Is.True);
            Assert.NotNull(sysEvent.Output.Error);
            Assert.That(sysEvent.Output.Error.Category, Is.EqualTo(MediaJobErrorCategory.Service));
            Assert.That(sysEvent.Output.Error.Code, Is.EqualTo(MediaJobErrorCode.ServiceError));
        }

        [Test]
        public void ConsumeMediaJobOutputFinishedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputFinished\",  \"eventTime\": \"2018-10-12T15:29:20.2621252\",  \"id\": \"bc9e6342-f081-49c2-a579-92f506a622c2\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",            \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 100,      \"state\": \"Finished\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputFinishedEventData sysEvent = eventData as MediaJobOutputFinishedEventData;

            Assert.That(sysEvent.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysEvent.Output.State, Is.EqualTo(MediaJobState.Finished));
            Assert.That(sysEvent.Output is MediaJobOutputAsset, Is.True);
            Assert.That(sysEvent.Output.Progress, Is.EqualTo(100));

            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)sysEvent.Output;
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-2ac2fe75-6557-4de5-ab25-5713b74a6901"));
        }

        [Test]
        public void ConsumeMediaJobOutputProcessingEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputProcessing\",  \"eventTime\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"d48eeb0b-2bfa-4265-a2f8-624654c3781c\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputProcessingEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobOutputProcessingEventData).Output.State, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobOutputProcessingEventData).Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeMediaJobOutputScheduledEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"eventType\": \"Microsoft.Media.JobOutputScheduled\",  \"eventTime\": \"2018-10-12T15:14:11.2244618\",  \"id\": \"635ca6ea-5306-4590-b2e1-22f172759336\",  \"data\": {    \"previousState\": \"Queued\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Scheduled\"    },    \"jobCorrelationData\": {}  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputScheduledEventData).PreviousState, Is.EqualTo(MediaJobState.Queued));
            Assert.That((eventData as MediaJobOutputScheduledEventData).Output.State, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobOutputScheduledEventData).Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeMediaJobOutputProgressEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6981\",  \"eventType\": \"Microsoft.Media.JobOutputProgress\",  \"eventTime\": \"2018-10-12T15:14:11.2244618\",  \"id\": \"635ca6ea-5306-4590-b2e1-22f172759336\",  \"data\": {    \"jobCorrelationData\": {    \"Field1\": \"test1\",    \"Field2\": \"test2\" },    \"label\": \"TestLabel\",    \"progress\": 50 },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputProgressEventData sysData = eventData as MediaJobOutputProgressEventData;

            Assert.That(sysData.Label, Is.EqualTo("TestLabel"));
            Assert.That(sysData.Progress, Is.EqualTo(50));
            Assert.That(sysData.JobCorrelationData.ContainsKey("Field1"), Is.True);
            Assert.That(sysData.JobCorrelationData["Field1"], Is.EqualTo("test1"));
            Assert.That(sysData.JobCorrelationData.ContainsKey("Field2"), Is.True);
            Assert.That(sysData.JobCorrelationData["Field2"], Is.EqualTo("test2"));
        }

        [Test]
        public void ConsumeMediaLiveEventEncoderConnectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventEncoderConnected\",  \"eventTime\": \"2018-10-12T15:52:04.2013501\",  \"id\": \"3d1f5b26-c466-47e7-927b-900985e0c5d5\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventEncoderConnectedEventData sysData = eventData as MediaLiveEventEncoderConnectedEventData;

            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.StreamId, Is.EqualTo("Mystream1"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
        }

        [Test]
        public void ConsumeMediaLiveEventConnectionRejectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventConnectionRejected\",  \"eventTime\": \"2018-10-12T15:52:04.2013501\",  \"id\": \"3d1f5b26-c466-47e7-927b-900985e0c5d5\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"resultCode\": \"MPE_INGEST_CODEC_NOT_SUPPORTED\"   },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);

            var sysData = eventData as MediaLiveEventConnectionRejectedEventData;
            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.StreamId, Is.EqualTo("Mystream1"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
        }

        [Test]
        public void ConsumeMediaLiveEventEncoderDisconnectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventEncoderDisconnected\",  \"eventTime\": \"2018-10-12T15:52:19.8982128\",  \"id\": \"e4b55140-42d2-4c24-b08e-9aa12f1587fc\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"resultCode\": \"MPE_CLIENT_TERMINATED_SESSION\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var sysData = eventData as MediaLiveEventEncoderDisconnectedEventData;

            Assert.That(sysData.ResultCode, Is.EqualTo("MPE_CLIENT_TERMINATED_SESSION"));
            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.StreamId, Is.EqualTo("Mystream1"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
        }

        [Test]
        public void ConsumeMediaLiveEventIncomingStreamReceivedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingStreamReceived\",  \"eventTime\": \"2018-10-12T15:52:16.5726463Z\",  \"id\": \"eb688fa1-5a19-4703-8aeb-6a65a09790da\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"trackType\": \"audio\",    \"trackName\": \"audio_160000\",    \"bitrate\": 160000,    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"timestamp\": \"66\",    \"duration\": \"1950\",    \"timescale\": \"1000\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var sysData = eventData as MediaLiveEventIncomingStreamReceivedEventData;

            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
            Assert.That(sysData.TrackType, Is.EqualTo("audio"));
            Assert.That(sysData.TrackName, Is.EqualTo("audio_160000"));
            Assert.That(sysData.Bitrate, Is.EqualTo(160000));
            Assert.That(sysData.Timestamp, Is.EqualTo("66"));
            Assert.That(sysData.Duration, Is.EqualTo("1950"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
        }

        [Test]
        public void ConsumeMediaLiveEventIncomingStreamsOutOfSyncEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingStreamsOutOfSync\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"minLastTimestamp\": \"10999\",    \"typeOfStreamWithMinLastTimestamp\": \"video\",    \"maxLastTimestamp\": \"100999\",    \"typeOfStreamWithMaxLastTimestamp\": \"audio\",    \"timescaleOfMinLastTimestamp\": \"1000\",  \"timescaleOfMaxLastTimestamp\": \"1000\"    },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var sysData = eventData as MediaLiveEventIncomingStreamsOutOfSyncEventData;

            Assert.That(sysData.MinLastTimestamp, Is.EqualTo("10999"));
            Assert.That(sysData.TypeOfStreamWithMinLastTimestamp, Is.EqualTo("video"));
            Assert.That(sysData.MaxLastTimestamp, Is.EqualTo("100999"));
            Assert.That(sysData.TypeOfStreamWithMaxLastTimestamp, Is.EqualTo("audio"));
            Assert.That(sysData.TimescaleOfMinLastTimestamp, Is.EqualTo("1000"));
            Assert.That(sysData.TimescaleOfMaxLastTimestamp, Is.EqualTo("1000"));
        }

        [Test]
        public void ConsumeMediaLiveEventIncomingVideoStreamsOutOfSyncEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"firstTimestamp\": \"10999\",    \"firstDuration\": \"2000\",    \"secondTimestamp\": \"100999\",    \"secondDuration\": \"2000\",    \"timescale\": \"1000\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var sysData = eventData as MediaLiveEventIncomingVideoStreamsOutOfSyncEventData;

            Assert.That(sysData.FirstTimestamp, Is.EqualTo("10999"));
            Assert.That(sysData.FirstDuration, Is.EqualTo("2000"));
            Assert.That(sysData.SecondTimestamp, Is.EqualTo("100999"));
            Assert.That(sysData.SecondDuration, Is.EqualTo("2000"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
        }

        [Test]
        public void ConsumeMediaLiveEventIncomingDataChunkDroppedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIncomingDataChunkDropped\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"timestamp\": \"8999\",    \"trackType\": \"video\",    \"trackName\": \"video1\",    \"bitrate\": 2500000,    \"timescale\": \"1000\",    \"resultCode\": \"FragmentDrop_OverlapTimestamp\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var sysData = eventData as MediaLiveEventIncomingDataChunkDroppedEventData;

            Assert.That(sysData.Timestamp, Is.EqualTo("8999"));
            Assert.That(sysData.TrackType, Is.EqualTo("video"));
            Assert.That(sysData.TrackName, Is.EqualTo("video1"));
            Assert.That(sysData.Bitrate, Is.EqualTo(2500000));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
            Assert.That(sysData.ResultCode, Is.EqualTo("FragmentDrop_OverlapTimestamp"));
        }

        [Test]
        public void ConsumeMediaLiveEventIngestHeartbeatEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIngestHeartbeat\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"incomingBitrate\": 500726,    \"lastTimestamp\": \"11999\",    \"timescale\": \"1000\",    \"overlapCount\": 0,    \"discontinuityCount\": 0,    \"nonincreasingCount\": 0,    \"unexpectedBitrate\": true,    \"state\": \"Running\",    \"healthy\": false,  \"lastFragmentArrivalTime\": \"2021-05-14T23:50:00.00\", \"ingestDriftValue\": \"0\" },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventIngestHeartbeatEventData sysData = eventData as MediaLiveEventIngestHeartbeatEventData;
            Assert.That(sysData.TrackType, Is.EqualTo("video"));
            Assert.That(sysData.TrackName, Is.EqualTo("video"));
            Assert.That(sysData.Bitrate, Is.EqualTo(2500000));
            Assert.That(sysData.IncomingBitrate, Is.EqualTo(500726));
            Assert.That(sysData.LastTimestamp, Is.EqualTo("11999"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
            Assert.That(sysData.OverlapCount, Is.EqualTo(0));
            Assert.That(sysData.DiscontinuityCount, Is.EqualTo(0));
            Assert.That(sysData.NonincreasingCount, Is.EqualTo(0));
            Assert.That(sysData.UnexpectedBitrate, Is.True);
            Assert.That(sysData.State, Is.EqualTo("Running"));
            Assert.That(sysData.Healthy, Is.False);
            Assert.That(sysData.IngestDriftValue, Is.EqualTo(0));
            Assert.That(sysData.LastFragmentArrivalTime, Is.EqualTo(DateTimeOffset.Parse("2021-05-14T23:50:00.00Z")));

            requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventIngestHeartbeat\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"incomingBitrate\": 500726,    \"lastTimestamp\": \"11999\",    \"timescale\": \"1000\",    \"overlapCount\": 0,    \"discontinuityCount\": 0,    \"nonincreasingCount\": 0,    \"unexpectedBitrate\": true,    \"state\": \"Running\",    \"healthy\": false,  \"lastFragmentArrivalTime\": \"2021-05-14T23:50:00.00\", \"ingestDriftValue\": \"n/a\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            events = EventGridEvent.ParseMany(new BinaryData(requestContent));
            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out eventData), Is.True);
            sysData = eventData as MediaLiveEventIngestHeartbeatEventData;
            // n/a should be translated to null IngestDriftValue
            Assert.IsNull(sysData.IngestDriftValue);
        }

        [Test]
        public void ConsumeMediaLiveEventChannelArchiveHeartbeatEvent()
        {
            string requestContent = @"[
            {
                ""topic"": ""/subscriptions/<subscription-id>/resourceGroups/<rg-name>/providers/Microsoft.Media/mediaservices/<account-name>"",
                ""subject"": ""liveEvent/mle1"",
                ""eventType"": ""Microsoft.Media.LiveEventChannelArchiveHeartbeat"",
                ""eventTime"": ""2021-05-14T23:50:00.324"",
                ""id"": ""7f450938-491f-41e1-b06f-c6cd3965d786"",
                ""data"": {
                    ""channelLatencyMs"": ""10"",
                    ""latencyResultCode"": ""S_OK""
                },
                ""dataVersion"": ""1.0"",
                ""metadataVersion"": ""1""
            }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventChannelArchiveHeartbeatEventData sysData = eventData as MediaLiveEventChannelArchiveHeartbeatEventData;
            Assert.That(sysData.ChannelLatency, Is.EqualTo(TimeSpan.FromMilliseconds(10)));
            Assert.That(sysData.LatencyResultCode, Is.EqualTo("S_OK"));

            requestContent = @"[
            {
                ""topic"": ""/subscriptions/<subscription-id>/resourceGroups/<rg-name>/providers/Microsoft.Media/mediaservices/<account-name>"",
                ""subject"": ""liveEvent/mle1"",
                ""eventType"": ""Microsoft.Media.LiveEventChannelArchiveHeartbeat"",
                ""eventTime"": ""2021-05-14T23:50:00.324"",
                ""id"": ""7f450938-491f-41e1-b06f-c6cd3965d786"",
                ""data"": {
                    ""channelLatencyMs"": ""n/a"",
                    ""latencyResultCode"": ""S_OK""
                },
                ""dataVersion"": ""1.0"",
                ""metadataVersion"": ""1""
            }]";

            events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out eventData), Is.True);
            sysData = eventData as MediaLiveEventChannelArchiveHeartbeatEventData;

            // n/a should be translated to null ChannelLatency
            Assert.IsNull(sysData.ChannelLatency);
            Assert.That(sysData.LatencyResultCode, Is.EqualTo("S_OK"));
        }

        [Test]
        public void ConsumeMediaLiveEventTrackDiscontinuityDetectedEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"eventType\": \"Microsoft.Media.LiveEventTrackDiscontinuityDetected\",  \"eventTime\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"previousTimestamp\": \"10999\",    \"newTimestamp\": \"14999\",    \"timescale\": \"1000\",    \"discontinuityGap\": \"4000\"  },  \"dataVersion\": \"1.0\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventTrackDiscontinuityDetectedEventData sysData = eventData as MediaLiveEventTrackDiscontinuityDetectedEventData;
            Assert.That(sysData.TrackType, Is.EqualTo("video"));
            Assert.That(sysData.TrackName, Is.EqualTo("video"));
            Assert.That(sysData.Bitrate, Is.EqualTo(2500000));
            Assert.That(sysData.PreviousTimestamp, Is.EqualTo("10999"));
            Assert.That(sysData.NewTimestamp, Is.EqualTo("14999"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
            Assert.That(sysData.DiscontinuityGap, Is.EqualTo("4000"));
        }
        #endregion

        #region Resource Manager (Azure Subscription/Resource Group) events

        private const string Authorization = "{\"scope\":\"/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/function/host/default\",\"action\":\"Microsoft.Web/sites/host/listKeys/action\",\"evidence\":{\"role\":\"Azure EventGrid Service BuiltIn Role\",\"roleAssignmentScope\":\"/subscriptions/sub\",\"roleAssignmentId\":\"rid\",\"roleDefinitionId\":\"rd\",\"principalId\":\"principal\",\"principalType\":\"ServicePrincipal\"}}";

        private const string Claims = "{\"aud\":\"https://management.core.windows.net\",\"iat\":\"16303066\",\"nbf\":\"16303066\",\"exp\":\"16303066\"}";

        private const string HttpRequest = "{\"clientRequestId\":\"\",\"clientIpAddress\":\"ip\",\"method\":\"POST\",\"url\":\"https://management.azure.com/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/function/host/default/listKeys?api-version=2018-11-01\"}";

        [Test]
        public void ConsumeResourceWriteSuccessEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceWriteSuccess"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceWriteSuccessEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceWriteFailureEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceWriteFailure"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceWriteFailureEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceWriteCancelEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceWriteCancel"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceWriteCancelEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceDeleteSuccessEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceDeleteSuccess"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceDeleteSuccessEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceDeleteFailureEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceDeleteFailure"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceDeleteFailureEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceDeleteCancelEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceDeleteCancel"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceDeleteCancelEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceActionSuccessEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceActionSuccess"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceActionSuccessEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceActionFailureEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceActionFailure"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            var moddel = EventGridModelFactory.AcsChatThreadCreatedWithUserEventData(participants: new ReadOnlyCollection<AcsChatThreadParticipantProperties>(new List<AcsChatThreadParticipantProperties>()));
            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceActionFailureEventData;

            AssertResourceEventData(eventData);
        }

        [Test]
        public void ConsumeResourceActionCancelEvent()
        {
            string requestContent = $@"[{{""topic"":""/subscriptions/subscription-id"", ""subject"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",    ""eventType"":""Microsoft.Resources.ResourceActionCancel"",    ""eventTime"":""2017-08-16T03:54:38.2696833Z"",    ""id"":""25b3b0d0-d79b-44d5-9963-440d4e6a9bba"",    ""data"": {{ ""authorization"":{Authorization},   ""claims"":{Claims},  ""correlationId"":""54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6"",  ""httpRequest"":{HttpRequest},   ""resourceProvider"":""Microsoft.EventGrid"",  ""resourceUri"":""/subscriptions/subscription-id/resourceGroups/resource-group/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501"",        ""operationName"":""Microsoft.EventGrid/eventSubscriptions/write"",    ""status"":""Succeeded"",   ""subscriptionId"":""subscription-id"",  ""tenantId"":""72f988bf-86f1-41af-91ab-2d7cd011db47""        }},      ""dataVersion"": """",    ""metadataVersion"": ""1""  }}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object data), Is.True);
            var eventData = data as ResourceActionCancelEventData;

            AssertResourceEventData(eventData);
        }

        // Using dynamic to avoid duplicating the test cases for each event. The events don't share a common base type but they all have the
        // properties being tested below.
        private static void AssertResourceEventData(dynamic eventData)
        {
            Assert.NotNull(eventData);
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", eventData.TenantId);
            var authorizationJson = JsonDocument.Parse(eventData.Authorization).RootElement;
            Assert.AreEqual("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/function/host/default",
                authorizationJson.GetProperty("scope").GetString());
            Assert.AreEqual("/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/function/host/default",
                eventData.AuthorizationValue.Scope);
            Assert.AreEqual("Microsoft.Web/sites/host/listKeys/action", authorizationJson.GetProperty("action").GetString());
            Assert.AreEqual("Microsoft.Web/sites/host/listKeys/action", eventData.AuthorizationValue.Action);
            Assert.AreEqual(
                "{\"role\":\"Azure EventGrid Service BuiltIn Role\",\"roleAssignmentScope\":\"/subscriptions/sub\",\"roleAssignmentId\":\"rid\",\"roleDefinitionId\":\"rd\",\"principalId\":\"principal\",\"principalType\":\"ServicePrincipal\"}",
                authorizationJson.GetProperty("evidence").GetRawText());
            Assert.AreEqual("Azure EventGrid Service BuiltIn Role", eventData.AuthorizationValue.Evidence["role"]);
            Assert.AreEqual("/subscriptions/sub", eventData.AuthorizationValue.Evidence["roleAssignmentScope"]);
            Assert.AreEqual("ServicePrincipal", eventData.AuthorizationValue.Evidence["principalType"]);

            var claimsJson = JsonDocument.Parse(eventData.Claims).RootElement;
            Assert.AreEqual("https://management.core.windows.net", claimsJson.GetProperty("aud").GetString());
            Assert.AreEqual("https://management.core.windows.net", eventData.ClaimsValue["aud"]);

            var httpRequestJson = JsonDocument.Parse(eventData.HttpRequest).RootElement;
            Assert.AreEqual("POST", httpRequestJson.GetProperty("method").GetString());
            Assert.AreEqual("POST", eventData.HttpRequestValue.Method.ToString());
            Assert.AreEqual(
                "https://management.azure.com/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/function/host/default/listKeys?api-version=2018-11-01",
                httpRequestJson.GetProperty("url").GetString());
            Assert.AreEqual(
                "https://management.azure.com/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/sites/function/host/default/listKeys?api-version=2018-11-01",
                eventData.HttpRequestValue.Url);
        }
        #endregion

        #region ServiceBus events
        [Test]
        public void ConsumeServiceBusActiveMessagesAvailableWithNoListenersEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"eventType\": \"Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners\",  \"eventTime\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ServiceBusActiveMessagesAvailableWithNoListenersEventData).NamespaceName, Is.EqualTo("testns1"));
        }

        [Test]
        public void ConsumeServiceBusDeadletterMessagesAvailableWithNoListenersEvent()
        {
            string requestContent = "[{  \"topic\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"eventType\": \"Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListeners\",  \"eventTime\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ServiceBusDeadletterMessagesAvailableWithNoListenersEventData).NamespaceName, Is.EqualTo("testns1"));
        }
        #endregion

        #region Storage events
        [Test]
        public void ConsumeStorageBlobCreatedEvent()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"eventType\": \"Microsoft.Storage.BlobCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\" },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobCreatedEventData).Url, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/file1.txt"));
        }

        [Test]
        public void ConsumeStorageBlobDeletedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobDeletedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
        }

        [Test]
        public void ConsumeStorageBlobRenamedEvent()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"eventType\": \"Microsoft.Storage.BlobRenamed\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"RenameFile\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"destinationUrl\": \"https://myaccount.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobRenamedEventData).DestinationUrl, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/testfile.txt"));
        }

        [Test]
        public void ConsumeStorageDirectoryCreatedEvent()
        {
            string requestContent = "[ {  \"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryCreated\",  \"eventTime\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"CreateDirectory\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"dataVersion\": \"2\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryCreatedEventData).Url, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeStorageDirectoryDeletedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\", \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryDeletedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
            Assert.IsNull((eventData as StorageDirectoryDeletedEventData).Recursive);
        }

        [Test]
        public void ConsumeStorageDirectoryDeletedEvent_Recursive()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",   \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryDeleted\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": { \"recursive\":\"true\",   \"api\": \"DeleteDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryDeletedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
            Assert.That((eventData as StorageDirectoryDeletedEventData).Recursive, Is.True);
        }

        [Test]
        public void ConsumeStorageDirectoryRenamedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.DirectoryRenamed\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"destinationUrl\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1\",  \"metadataVersion\": \"1\"}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryRenamedEventData).DestinationUrl, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeStorageAsyncOperationInitiatedEvent()
        {
            string requestContent = "[{    \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.AsyncOperationInitiated\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1.0\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageAsyncOperationInitiatedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeStorageBlobTierChangedEvent()
        {
            string requestContent = "[{   \"topic\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"eventType\": \"Microsoft.Storage.BlobTierChanged\",  \"eventTime\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"dataVersion\": \"1.0\"}]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobTierChangedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeStorageTaskQueuedEvent()
        {
            string requestContent = @"[{
            ""topic"": ""/subscriptions/c86a9c18-8373-41fa-92d4-1d7bdc16977b/resourceGroups/shulin-rg/providers/Microsoft.Storage/storageAccounts/shulinstcanest2"",
            ""subject"": ""DataManagement/StorageTasks"",
            ""eventType"": ""Microsoft.Storage.StorageTaskQueued"",
            ""id"": ""7fddaf06-24e8-4d57-9b66-5b7ab920a626"",
            ""data"": {
                ""queuedDateTime"": ""2023-03-23T16:43:50Z"",
                ""taskExecutionId"": ""deletetest-2023-03-23T16:42:33.8658256Z_2023-03-23T16:42:58.8983000Z""
            },
            ""dataVersion"": ""1.0"",
            ""metadataVersion"": ""1"",
            ""eventTime"": ""2023-03-23T16:43:50Z""
        }]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageTaskQueuedEventData).TaskExecutionId, Is.EqualTo("deletetest-2023-03-23T16:42:33.8658256Z_2023-03-23T16:42:58.8983000Z"));
            Assert.That((eventData as StorageTaskQueuedEventData).QueuedDateTime, Is.EqualTo(DateTimeOffset.Parse("2023-03-23T16:43:50Z")));
        }

        [Test]
        public void ConsumeStorageTaskCompletedEvent()
        {
            string requestContent = @"[{
            ""topic"": ""/subscriptions/c86a9c18-8373-41fa-92d4-1d7bdc16977b/resourceGroups/shulin-rg/providers/Microsoft.Storage/storageAccounts/shulinstcanest2"",
            ""subject"": ""DataManagement/StorageTasks"",
            ""eventType"": ""Microsoft.Storage.StorageTaskCompleted"",
            ""id"": ""7fddaf06-24e8-4d57-9b66-5b7ab920a626"",
            ""data"": {
                ""status"": ""Succeeded"",
                ""completedDateTime"": ""2023-03-23T16:52:58Z"",
                ""taskExecutionId"": ""deletetest-2023-03-23T16:42:33.8658256Z_2023-03-23T16:42:58.8983000Z"",
                ""taskName"": ""delete123"",
                ""summaryReportBlobUrl"": ""https://shulinstcanest2.blob.core.windows.net/report/delete123_deletetest_2023-03-23T16:43:50/SummaryReport.json""
            },
            ""dataVersion"": ""1.0"",
            ""metadataVersion"": ""1"",
            ""eventTime"": ""2023-03-23T16:43:50Z""
        }]";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageTaskCompletedEventData).Status, Is.EqualTo(StorageTaskCompletedStatus.Succeeded));
            Assert.That((eventData as StorageTaskCompletedEventData).CompletedDateTime, Is.EqualTo(DateTimeOffset.Parse("2023-03-23T16:52:58Z")));
            Assert.That((eventData as StorageTaskCompletedEventData).TaskExecutionId, Is.EqualTo("deletetest-2023-03-23T16:42:33.8658256Z_2023-03-23T16:42:58.8983000Z"));
            Assert.That((eventData as StorageTaskCompletedEventData).TaskName, Is.EqualTo("delete123"));
            Assert.That((eventData as StorageTaskCompletedEventData).SummaryReportBlobUri.AbsoluteUri, Is.EqualTo("https://shulinstcanest2.blob.core.windows.net/report/delete123_deletetest_2023-03-23T16:43:50/SummaryReport.json"));
        }
        #endregion

        #region App Service events
        [Test]
        public void ConsumeWebAppUpdatedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.AppUpdated\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebAppUpdatedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebBackupOperationStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.BackupOperationStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebBackupOperationStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebBackupOperationCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.BackupOperationCompleted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebBackupOperationCompletedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebBackupOperationFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.BackupOperationFailed\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebBackupOperationFailedEventData).Name, Is.EqualTo(siteName));

            var sysEvent = events[0].Data.ToObjectFromJson<WebBackupOperationFailedEventData>();
            Assert.That(sysEvent.Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebRestoreOperationStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.RestoreOperationStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebRestoreOperationStartedEventData).Name, Is.EqualTo(siteName));

            var sysEvent = events[0].Data.ToObjectFromJson<WebRestoreOperationStartedEventData>();
            Assert.That(sysEvent.Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebRestoreOperationCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.RestoreOperationCompleted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebRestoreOperationCompletedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebRestoreOperationFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.RestoreOperationFailed\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebRestoreOperationFailedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebSlotSwapStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebSlotSwapCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapCompleted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapCompletedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebSlotSwapFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapFailed\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapFailedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebSlotSwapWithPreviewStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapWithPreviewStarted\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapWithPreviewStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebSlotSwapWithPreviewCancelledEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"eventType\": \"Microsoft.Web.SlotSwapWithPreviewCancelled\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapWithPreviewCancelledEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeWebAppServicePlanUpdatedEvent()
        {
            string planName = "testPlan01";
            string requestContent = $"[{{\"topic\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/serverfarms/testPlan01\", \"subject\": \"/Microsoft.Web/serverfarms/testPlan01\",\"eventType\": \"Microsoft.Web.AppServicePlanUpdated\", \"eventTime\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appServicePlanEventTypeDetail\": {{ \"stampKind\": \"Public\",\"action\": \"Updated\",\"status\": \"Started\" }},\"name\": \"{planName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"dataVersion\": \"2\",\"metadataVersion\": \"1\"}}]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebAppServicePlanUpdatedEventData).Name, Is.EqualTo(planName));
        }
        #endregion

        #region Policy Insights
        [Test]
        public void ConsumePolicyInsightsPolicyStateChangedEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.PolicyInsights.PolicyStateChanged\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"timestamp\":\"2017-08-16T03:54:38.2696833Z\",  \"policyDefinitionId\":\"4c2359fe-001e-00ba-0e04-585868000000\",       \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"subscriptionId\":\"{subscription-id}\"   },   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as PolicyInsightsPolicyStateChangedEventData).PolicyDefinitionId, Is.EqualTo("4c2359fe-001e-00ba-0e04-585868000000"));
        }

        [Test]
        public void ConsumePolicyInsightsPolicyStateCreatedEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.PolicyInsights.PolicyStateCreated\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"timestamp\":\"2017-08-16T03:54:38.2696833Z\",  \"policyDefinitionId\":\"4c2359fe-001e-00ba-0e04-585868000000\",       \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"subscriptionId\":\"{subscription-id}\"   },   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as PolicyInsightsPolicyStateCreatedEventData).PolicyDefinitionId, Is.EqualTo("4c2359fe-001e-00ba-0e04-585868000000"));
        }

        [Test]
        public void ConsumePolicyInsightsPolicyStateDeletedEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"eventType\":\"Microsoft.PolicyInsights.PolicyStateDeleted\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"timestamp\":\"2017-08-16T03:54:38.2696833Z\",  \"policyDefinitionId\":\"4c2359fe-001e-00ba-0e04-585868000000\",       \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"subscriptionId\":\"{subscription-id}\"   },   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as PolicyInsightsPolicyStateDeletedEventData).PolicyDefinitionId, Is.EqualTo("4c2359fe-001e-00ba-0e04-585868000000"));
        }
        #endregion

        #region Communication events
        [Test]
        public void ConsumeAcsRecordingFileStatusUpdatedEventData()
        {
            string requestContent = "[   {      \"subject\":\"/recording/call/{call-id}/recordingId/{recording-id}\",    \"eventType\":\"Microsoft.Communication.RecordingFileStatusUpdated\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"recordingStorageInfo\": { \"recordingChunks\": [ { \"documentId\": \"0-eus-d12-801b3f3fc462fe8a01e6810cbff729b8\", \"index\": 0, \"endReason\": \"SessionEnded\", \"contentLocation\": \"https://storage.asm.skype.com/v1/objects/0-eus-d12-801b3f3fc462fe8a01e6810cbff729b8/content/video\", \"metadataLocation\": \"https://storage.asm.skype.com/v1/objects/0-eus-d12-801b3f3fc462fe8a01e6810cbff729b8/content/acsmetadata\" }]}, \"recordingChannelType\": \"Mixed\", \"recordingContentType\": \"Audio\", \"recordingFormatType\": \"Mp3\"},   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var recordingEvent = eventData as AcsRecordingFileStatusUpdatedEventData;
            Assert.IsNotNull(recordingEvent);
            Assert.That(recordingEvent.ChannelType, Is.EqualTo(AcsRecordingChannelType.Mixed));
            Assert.That(recordingEvent.ContentType, Is.EqualTo(AcsRecordingContentType.Audio));
            Assert.That(recordingEvent.FormatType, Is.EqualTo(AcsRecordingFormatType.Mp3));

            // back compat
            Assert.That(recordingEvent.RecordingChannelType, Is.EqualTo(RecordingChannelType.Mixed));
            Assert.That(recordingEvent.RecordingContentType, Is.EqualTo(RecordingContentType.Audio));
            Assert.That(recordingEvent.RecordingFormatType, Is.EqualTo(RecordingFormatType.Mp3));
        }

        [Test]
        public void ConsumeAcsEmailDeliveryReportReceivedEvent()
        {
            string requestContent = @"{
                ""id"": ""5f04f77c-2a6a-43bd-9b74-576a64c01f9e"",
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
                ""subject"": ""sender/test2@contoso.org/message/950850f5-bcdf-4315-b77a-6447cf56fac9"",
                ""data"": {
                    ""sender"": ""test2@contoso.org"",
                    ""recipient"": ""test1@contoso.com"",
                    ""messageId"": ""950850f5-bcdf-4315-b77a-6447cf56fac9"",
                    ""status"": ""delivered"",
                    ""deliveryAttemptTimestamp"": ""2023-02-09T19:46:12.2480265+00:00"",
                    ""deliveryStatusDetails"": {
                        ""statusMessage"": ""DestinationMailboxFull""
                    }
                },
                ""eventType"": ""Microsoft.Communication.EmailDeliveryReportReceived"",
                ""dataVersion"": ""1.0"",
                ""metadataVersion"": ""1"",
                ""eventTime"": ""2023-02-09T19:46:12.2478002Z""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var emailEvent = eventData as AcsEmailDeliveryReportReceivedEventData;
            Assert.IsNotNull(emailEvent);
            Assert.That(emailEvent.Sender, Is.EqualTo("test2@contoso.org"));
            Assert.That(emailEvent.Recipient, Is.EqualTo("test1@contoso.com"));
            Assert.That(emailEvent.Status, Is.EqualTo(AcsEmailDeliveryReportStatus.Delivered));
            Assert.That(emailEvent.DeliveryStatusDetails.StatusMessage, Is.EqualTo("DestinationMailboxFull"));
            Assert.That(emailEvent.DeliveryAttemptTimestamp, Is.EqualTo(DateTimeOffset.Parse("2023-02-09T19:46:12.2480265+00:00")));
        }

        [Test]
        public void ConsumeAcsIncomingCallEvent()
        {
            string requestContent = @"{
                ""id"": ""e80026e7-e298-46ba-bc42-dab0eda92581"",
                ""topic"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
                ""subject"": ""/caller/{caller-id}/recipient/{recipient-id}"",
                ""data"": {
                    ""to"": {
                        ""kind"": ""communicationUser"",
                        ""rawId"": ""{recipient-id}"",
                        ""communicationUser"": {
                            ""id"": ""{recipient-id}""
                        }
                    },
                    ""from"": {
                        ""kind"": ""communicationUser"",
                        ""rawId"": ""{caller-id}"",
                        ""communicationUser"": {
                            ""id"": ""{caller-id}""
                        }
                    },
                    ""serverCallId"": ""{server-call-id}"",
                    ""callerDisplayName"": ""VOIP Caller"",
                    ""customContext"": {
                        ""sipHeaders"": {
                            ""userToUser"": ""616d617a6f6e5f6368696;encoding=hex"",
                            ""X-MS-Custom-myheader1"": ""35567842"",
                            ""X-MS-Custom-myheader2"": ""customsipheadervalue""
                        },
                        ""voipHeaders"": {
                            ""customHeader"": ""customValue""
                        }
                    },
                    ""incomingCallContext"": ""{incoming-call-contextValue}"",
                    ""correlationId"": ""correlationId""
                },
                ""eventType"": ""Microsoft.Communication.IncomingCall"",
                ""dataVersion"": ""1.0"",
                ""metadataVersion"": ""1"",
                ""eventTime"": ""2023-04-04T17:18:42.5542219Z""
            }";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var incomingCallEvent = eventData as AcsIncomingCallEventData;
            Assert.IsNotNull(incomingCallEvent);
            Assert.That(incomingCallEvent.ToCommunicationIdentifier.CommunicationUser.Id, Is.EqualTo("{recipient-id}"));
            Assert.That(incomingCallEvent.FromCommunicationIdentifier.CommunicationUser.Id, Is.EqualTo("{caller-id}"));
            Assert.That(incomingCallEvent.CallerDisplayName, Is.EqualTo("VOIP Caller"));
            Assert.That(incomingCallEvent.CustomContext.SipHeaders["userToUser"], Is.EqualTo("616d617a6f6e5f6368696;encoding=hex"));
            Assert.That(incomingCallEvent.CustomContext.SipHeaders["X-MS-Custom-myheader1"], Is.EqualTo("35567842"));
            Assert.That(incomingCallEvent.CustomContext.SipHeaders["X-MS-Custom-myheader2"], Is.EqualTo("customsipheadervalue"));
            Assert.That(incomingCallEvent.CustomContext.VoipHeaders["customHeader"], Is.EqualTo("customValue"));
            Assert.That(incomingCallEvent.IncomingCallContext, Is.EqualTo("{incoming-call-contextValue}"));
            Assert.That(incomingCallEvent.CorrelationId, Is.EqualTo("correlationId"));
        }
        #endregion

        #region Health Data Services events
        [Test]
        public void ConsumeFhirResourceCreatedEvent()
        {
            string requestContent = "[   {  \"subject\":\"{fhir-account}.fhir.azurehealthcareapis.com/Patient/e0a1f743-1a70-451f-830e-e96477163902\",    \"eventType\":\"Microsoft.HealthcareApis.FhirResourceCreated\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"resourceType\": \"Patient\",  \"resourceFhirAccount\": \"{fhir-account}.fhir.azurehealthcareapis.com\", \"resourceFhirId\": \"e0a1f743-1a70-451f-830e-e96477163902\", \"resourceVersionId\": 1 },   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareFhirResourceCreatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.FhirResourceType, Is.EqualTo(HealthcareFhirResourceType.Patient));
            Assert.That(healthEvent.FhirServiceHostName, Is.EqualTo("{fhir-account}.fhir.azurehealthcareapis.com"));
            Assert.That(healthEvent.FhirResourceId, Is.EqualTo("e0a1f743-1a70-451f-830e-e96477163902"));
            Assert.That(healthEvent.FhirResourceVersionId, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeFhirResourceUpdatedEvent()
        {
            string requestContent = "[   {  \"subject\":\"{fhir-account}.fhir.azurehealthcareapis.com/Patient/e0a1f743-1a70-451f-830e-e96477163902\",    \"eventType\":\"Microsoft.HealthcareApis.FhirResourceUpdated\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"resourceType\": \"Patient\",  \"resourceFhirAccount\": \"{fhir-account}.fhir.azurehealthcareapis.com\", \"resourceFhirId\": \"e0a1f743-1a70-451f-830e-e96477163902\", \"resourceVersionId\": 1 },   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareFhirResourceUpdatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.FhirResourceType, Is.EqualTo(HealthcareFhirResourceType.Patient));
            Assert.That(healthEvent.FhirServiceHostName, Is.EqualTo("{fhir-account}.fhir.azurehealthcareapis.com"));
            Assert.That(healthEvent.FhirResourceId, Is.EqualTo("e0a1f743-1a70-451f-830e-e96477163902"));
            Assert.That(healthEvent.FhirResourceVersionId, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeFhirResourceDeletedEvent()
        {
            string requestContent = "[   {  \"subject\":\"{fhir-account}.fhir.azurehealthcareapis.com/Patient/e0a1f743-1a70-451f-830e-e96477163902\",    \"eventType\":\"Microsoft.HealthcareApis.FhirResourceDeleted\",    \"eventTime\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"resourceType\": \"Patient\",  \"resourceFhirAccount\": \"{fhir-account}.fhir.azurehealthcareapis.com\", \"resourceFhirId\": \"e0a1f743-1a70-451f-830e-e96477163902\", \"resourceVersionId\": 1 },   \"dataVersion\": \"1.0\"  }]";

            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareFhirResourceDeletedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.FhirResourceType, Is.EqualTo(HealthcareFhirResourceType.Patient));
            Assert.That(healthEvent.FhirServiceHostName, Is.EqualTo("{fhir-account}.fhir.azurehealthcareapis.com"));
            Assert.That(healthEvent.FhirResourceId, Is.EqualTo("e0a1f743-1a70-451f-830e-e96477163902"));
            Assert.That(healthEvent.FhirResourceVersionId, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeDicomImageCreatedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}"",
            ""subject"": ""{dicom-account}.dicom.azurehealthcareapis.com/v1/studies/1.2.3.4.3/series/1.2.3.4.3.9423673/instances/1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
            ""eventType"": ""Microsoft.HealthcareApis.DicomImageCreated"",
            ""dataVersion"": ""1"",
            ""metadataVersion"": ""1"",
            ""eventTime"": ""2022-09-15T01:14:04.5613214Z"",
            ""id"": ""d621839d-958b-4142-a638-bb966b4f7dfd"",
            ""data"": {
                ""partitionName"": ""Microsoft.Default"",
                ""imageStudyInstanceUid"": ""1.2.3.4.3"",
                ""imageSeriesInstanceUid"": ""1.2.3.4.3.9423673"",
                ""imageSopInstanceUid"": ""1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
                ""serviceHostName"": ""{dicom-account}.dicom.azurehealthcareapis.com"",
                ""sequenceNumber"": 1
            },
            ""specVersion"": ""1.0""
        }";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareDicomImageCreatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.ImageStudyInstanceUid, Is.EqualTo("1.2.3.4.3"));
            Assert.That(healthEvent.ImageSeriesInstanceUid, Is.EqualTo("1.2.3.4.3.9423673"));
            Assert.That(healthEvent.ImageSopInstanceUid, Is.EqualTo("1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"));
            Assert.That(healthEvent.SequenceNumber, Is.EqualTo(1));
            Assert.That(healthEvent.PartitionName, Is.EqualTo("Microsoft.Default"));
        }

        [Test]
        public void ConsumeDicomImageUpdatedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}"",
            ""subject"": ""{dicom-account}.dicom.azurehealthcareapis.com/v1/studies/1.2.3.4.3/series/1.2.3.4.3.9423673/instances/1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
            ""eventType"": ""Microsoft.HealthcareApis.DicomImageUpdated"",
            ""dataVersion"": ""1"",
            ""metadataVersion"": ""1"",
            ""eventTime"": ""2022-09-15T01:14:04.5613214Z"",
            ""id"": ""d621839d-958b-4142-a638-bb966b4f7dfd"",
            ""data"": {
                ""partitionName"": ""Microsoft.Default"",
                ""imageStudyInstanceUid"": ""1.2.3.4.3"",
                ""imageSeriesInstanceUid"": ""1.2.3.4.3.9423673"",
                ""imageSopInstanceUid"": ""1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
                ""serviceHostName"": ""{dicom-account}.dicom.azurehealthcareapis.com"",
                ""sequenceNumber"": 1
            },
            ""specVersion"": ""1.0""
        }";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareDicomImageUpdatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.ImageStudyInstanceUid, Is.EqualTo("1.2.3.4.3"));
            Assert.That(healthEvent.ImageSeriesInstanceUid, Is.EqualTo("1.2.3.4.3.9423673"));
            Assert.That(healthEvent.ImageSopInstanceUid, Is.EqualTo("1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"));
            Assert.That(healthEvent.SequenceNumber, Is.EqualTo(1));
            Assert.That(healthEvent.PartitionName, Is.EqualTo("Microsoft.Default"));
        }

        [Test]
        public void ConsumeDicomImageDeletedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}"",
            ""subject"": ""{dicom-account}.dicom.azurehealthcareapis.com/v1/studies/1.2.3.4.3/series/1.2.3.4.3.9423673/instances/1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
            ""eventType"": ""Microsoft.HealthcareApis.DicomImageDeleted"",
            ""dataVersion"": ""1"",
            ""metadataVersion"": ""1"",
            ""eventTime"": ""2022-09-15T01:14:04.5613214Z"",
            ""id"": ""d621839d-958b-4142-a638-bb966b4f7dfd"",
            ""data"": {
                ""partitionName"": ""Microsoft.Default"",
                ""imageStudyInstanceUid"": ""1.2.3.4.3"",
                ""imageSeriesInstanceUid"": ""1.2.3.4.3.9423673"",
                ""imageSopInstanceUid"": ""1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
                ""serviceHostName"": ""{dicom-account}.dicom.azurehealthcareapis.com"",
                ""sequenceNumber"": 1
            },
            ""specVersion"": ""1.0""
        }";
            EventGridEvent[] events = EventGridEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareDicomImageDeletedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.ImageStudyInstanceUid, Is.EqualTo("1.2.3.4.3"));
            Assert.That(healthEvent.ImageSeriesInstanceUid, Is.EqualTo("1.2.3.4.3.9423673"));
            Assert.That(healthEvent.ImageSopInstanceUid, Is.EqualTo("1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"));
            Assert.That(healthEvent.SequenceNumber, Is.EqualTo(1));
            Assert.That(healthEvent.PartitionName, Is.EqualTo("Microsoft.Default"));
        }
        #endregion
        #endregion

        #region CloudEvent tests

        #region Miscellaneous tests

        [Test]
        public void ParsesCloudEventEnvelope()
        {
            string requestContent = "[{\"key\": \"value\",  \"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",   \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  }, \"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\", \"dataschema\":\"1.0\", \"subject\":\"subject\", \"datacontenttype\": \"text/plain\", \"time\": \"2017-08-16T01:57:26.005121Z\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            var cloudEvent = events[0];

            Assert.That(cloudEvent.Id, Is.EqualTo("994bc3f8-c90c-6fc3-9e83-6783db2221d5"));
            Assert.That(cloudEvent.Source, Is.EqualTo("Subject-0"));
            Assert.That(cloudEvent.Type, Is.EqualTo(SystemEventNames.StorageBlobDeleted));
            Assert.That(cloudEvent.DataContentType, Is.EqualTo("text/plain"));
            Assert.That(cloudEvent.Subject, Is.EqualTo("subject"));
            Assert.That(cloudEvent.DataSchema, Is.EqualTo("1.0"));
            Assert.That(cloudEvent.Time, Is.EqualTo(DateTimeOffset.Parse("2017-08-16T01:57:26.005121Z")));
            cloudEvent.ExtensionAttributes.TryGetValue("key", out var value);
            Assert.That(value, Is.EqualTo("value"));
        }

        [Test]
        public void ConsumeCloudEventsWithAdditionalProperties()
        {
            string requestContent = "[{\"key\": \"value\",  \"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  }, \"type\":\"Microsoft.Storage.BlobDeleted\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));
            Assert.NotNull(events);

            if (events[0].Type == SystemEventNames.StorageBlobDeleted)
            {
                StorageBlobDeletedEventData eventData = events[0].Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                Assert.That(eventData.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
            }

            events[0].ExtensionAttributes.TryGetValue("key", out var value);
            Assert.That(value, Is.EqualTo("value"));
        }

        [Test]
        public void ConsumeCloudEventUsingBinaryDataExtensionMethod()
        {
            BinaryData messageBody = new BinaryData("{  \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"type\": \"Microsoft.Storage.BlobDeleted\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  }}");

            CloudEvent cloudEvent = CloudEvent.Parse(messageBody, skipValidation: true);

            Assert.NotNull(cloudEvent);
            switch (cloudEvent.Type)
            {
                case SystemEventNames.StorageBlobDeleted:
                    StorageBlobDeletedEventData blobDeleted = cloudEvent.Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                    Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                    break;
            }
        }

        [Test]
        public void ConsumeCloudEventNotWrappedInAnArray()
        {
            string requestContent = "{  \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"type\": \"Microsoft.Storage.BlobDeleted\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",   \"brandNewProperty\": \"0000000000000281000000000002F5CA\", \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  }}";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent), skipValidation: true);

            Assert.NotNull(events);
            if (events[0].Type == SystemEventNames.StorageBlobDeleted)
            {
                StorageBlobDeletedEventData eventData = events[0].Data.ToObjectFromJson<StorageBlobDeletedEventData>();
                Assert.That(eventData.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
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
                "{\"id\":\"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",\"source\":\"/contoso/items\",\"subject\": \"\",\"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"type\": \"Contoso.Items.ItemReceived\",\"specversion\":\"1.0\"}]";

            ObjectSerializer camelCaseSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events.Length, Is.EqualTo(5));
            foreach (CloudEvent cloudEvent in events)
            {
                if (cloudEvent.TryGetSystemEventData(out object eventData))
                {
                    switch (eventData)
                    {
                        case StorageBlobCreatedEventData blobCreated:
                            Assert.That(blobCreated.Url, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/file1.txt"));
                            break;
                        case StorageBlobDeletedEventData blobDeleted:
                            Assert.That(blobDeleted.Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
                            break;
                    }
                }
                else
                {
                    switch (cloudEvent.Type)
                    {
                        case "BinaryDataType":
                            Assert.That(Convert.ToBase64String(cloudEvent.Data.ToArray()), Is.EqualTo("ZGF0YQ=="));
                            Assert.That(cloudEvent.TryGetSystemEventData(out var _), Is.False);
                            break;
                        case "Contoso.Items.ItemReceived":
                            ContosoItemReceivedEventData itemReceived = cloudEvent.Data.ToObject<ContosoItemReceivedEventData>(camelCaseSerializer);
                            Assert.That(itemReceived.ItemSku, Is.EqualTo("512d38b6-c7b8-40c8-89fe-f46f9e9622b6"));
                            Assert.That(cloudEvent.TryGetSystemEventData(out var _), Is.False);
                            break;
                    }
                }
            }
        }
        #endregion

        #region Custom event tests
        [Test]
        public void ConsumeCloudEventWithBinaryDataPayload()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"source\":\"Subject-0\",  \"data_base64\": \"ZGF0YQ==\", \"type\":\"Test.Items.BinaryDataType\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));
            if (events[0].Type == "Test.Items.BinaryDataType")
            {
                var eventData = (BinaryData)events[0].Data;
                Assert.That(eventData.ToString(), Is.EqualTo("data"));
            }
        }

        [Test]
        public void ConsumeCloudEventWithCustomEventPayload()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\":\"/contoso/items\",  \"subject\": \"\",  \"data\": {    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"type\": \"Contoso.Items.ItemReceived\", \"specversion\": \"1.0\"}]";

            ObjectSerializer camelCaseSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);

            ContosoItemReceivedEventData eventData = events[0].Data.ToObject<ContosoItemReceivedEventData>(camelCaseSerializer);
            Assert.That(eventData.ItemSku, Is.EqualTo("512d38b6-c7b8-40c8-89fe-f46f9e9622b6"));
        }

        [Test]
        public void ConsumeCloudEventWithArrayDataPayload()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\":\"/contoso/items\", \"subject\": \"\",  \"data\": [{    \"itemSku\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"itemUri\": \"https://rp-eastus2.eventgrid.azure.net:553\"  }],  \"type\": \"Contoso.Items.ItemReceived\", \"specversion\": \"1.0\"}]";

            ObjectSerializer camelCaseSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);

            ContosoItemReceivedEventData[] eventData = events[0].Data.ToObject<ContosoItemReceivedEventData[]>(camelCaseSerializer);
            Assert.That(eventData[0].ItemSku, Is.EqualTo("512d38b6-c7b8-40c8-89fe-f46f9e9622b6"));
        }
        #endregion

        #region Null data tests
        [Test]
        public void ConsumeCloudEventWithNoData()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\",\"type\":\"type\",\"source\":\"Subject-0\",\"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));
            var eventData1 = events[0].Data;

            Assert.That(null, Is.EqualTo(eventData1));
            Assert.That(events[0].Type, Is.EqualTo("type"));
        }

        [Test]
        public void ConsumeCloudEventWithExplicitlyNullData()
        {
            string requestContent = "[{\"id\":\"994bc3f8-c90c-6fc3-9e83-6783db2221d5\", \"type\":\"type\", \"source\":\"Subject-0\", \"data\":null, \"specversion\":\"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));
            Assert.IsNull(events[0].Data.ToObjectFromJson<object>());
            Assert.That(events[0].Type, Is.EqualTo("type"));
        }
        #endregion

        #region Primitive/string data tests
        [Test]
        public void ConsumeCloudEventWithBooleanData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\":\"/contoso/items\",  \"subject\": \"\",  \"data\": true,  \"type\": \"Contoso.Items.ItemReceived\",  \"time\": \"2018-01-25T22:12:19.4556811Z\", \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            BinaryData binaryEventData = events[0].Data;
            bool eventData = binaryEventData.ToObjectFromJson<bool>();
            Assert.That(eventData, Is.True);
        }

        [Test]
        public void ConsumeCloudEventWithStringData()
        {
            string requestContent = "[{  \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\":\"/contoso/items\",  \"subject\": \"\",  \"data\": \"stringdata\",  \"type\": \"Contoso.Items.ItemReceived\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            BinaryData binaryEventData = events[0].Data;
            string eventData = binaryEventData.ToObjectFromJson<string>();
            Assert.That(eventData, Is.EqualTo("stringdata"));
        }
        #endregion

        #region AppConfiguration events
        [Test]
        public void ConsumeCloudEventAppConfigurationKeyValueDeletedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.AppConfiguration.KeyValueDeleted\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"key\":\"key1\",\"label\":\"label1\",\"etag\":\"etag1\"}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as AppConfigurationKeyValueDeletedEventData).Key, Is.EqualTo("key1"));

            var sysEvent = events[0].Data.ToObjectFromJson<AppConfigurationKeyValueDeletedEventData>();
            Assert.That(sysEvent.Key, Is.EqualTo("key1"));
        }

        [Test]
        public void ConsumeCloudEventAppConfigurationKeyValueModifiedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.AppConfiguration.KeyValueModified\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"key\":\"key1\",\"label\":\"label1\",\"etag\":\"etag1\"}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as AppConfigurationKeyValueModifiedEventData).Key, Is.EqualTo("key1"));

            var sysEvent = events[0].Data.ToObjectFromJson<AppConfigurationKeyValueModifiedEventData>();
            Assert.That(sysEvent.Key, Is.EqualTo("key1"));
        }

        [Test]
        public void ConsumeCloudEventAppConfigurationSnapshotCreatedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.AppConfiguration.SnapshotCreated\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"name\":\"Foo\",\"etag\":\"FnUExLaj2moIi4tJX9AXn9sakm0\",\"syncToken\":\"zAJw6V16=Njo1IzUxNjQ2NzM=;sn=5164673\"}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as AppConfigurationSnapshotCreatedEventData).Name, Is.EqualTo("Foo"));
            Assert.That((eventData as AppConfigurationSnapshotCreatedEventData).SyncToken, Is.EqualTo("zAJw6V16=Njo1IzUxNjQ2NzM=;sn=5164673"));

            var sysEvent = events[0].Data.ToObjectFromJson<AppConfigurationSnapshotCreatedEventData>();
            Assert.That(sysEvent.Name, Is.EqualTo("Foo"));
        }

        [Test]
        public void ConsumeCloudEventAppConfigurationSnapshotModifiedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.AppConfiguration.SnapshotModified\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"name\":\"Foo\",\"etag\":\"FnUExLaj2moIi4tJX9AXn9sakm0\",\"syncToken\":\"zAJw6V16=Njo1IzUxNjQ2NzM=;sn=5164673\"}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as AppConfigurationSnapshotModifiedEventData).Name, Is.EqualTo("Foo"));
            Assert.That((eventData as AppConfigurationSnapshotModifiedEventData).SyncToken, Is.EqualTo("zAJw6V16=Njo1IzUxNjQ2NzM=;sn=5164673"));

            var sysEvent = events[0].Data.ToObjectFromJson<AppConfigurationSnapshotModifiedEventData>();
            Assert.That(sysEvent.Name, Is.EqualTo("Foo"));
        }
        #endregion

        #region ContainerRegistry events
        [Test]
        public void ConsumeCloudEventContainerRegistryImagePushedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.ContainerRegistry.ImagePushed\",  \"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryImagePushedEventData).Request.Addr, Is.EqualTo("127.0.0.1"));

            var sysEvent = events[0].Data.ToObjectFromJson<ContainerRegistryImagePushedEventData>();
            Assert.That(sysEvent.Request.Addr, Is.EqualTo("127.0.0.1"));
        }

        [Test]
        public void ConsumeCloudEventContainerRegistryImageDeletedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.ContainerRegistry.ImageDeleted\",  \"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"eventID\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"testaction\",\"target\":{\"mediaType\":\"test\",\"size\":20,\"digest\":\"digest1\",\"length\":20,\"repository\":\"test\",\"url\":\"url1\",\"tag\":\"test\"},\"request\":{\"id\":\"id\",\"addr\":\"127.0.0.1\",\"host\":\"test\",\"method\":\"method1\",\"useragent\":\"useragent1\"},\"actor\":{\"name\":\"testactor\"},\"source\":{\"addr\":\"127.0.0.1\",\"instanceID\":\"id\"}}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryImageDeletedEventData).Actor.Name, Is.EqualTo("testactor"));

            var sysEvent = events[0].Data.ToObjectFromJson<ContainerRegistryImageDeletedEventData>();
            Assert.That(sysEvent.Actor.Name, Is.EqualTo("testactor"));
        }

        [Test]
        public void ConsumeCloudEventContainerRegistryChartDeletedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.ContainerRegistry.ChartDeleted\",  \"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"id\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"action1\",\"target\":{\"mediaType\":\"mediatype1\",\"size\":20,\"digest\":\"digest1\",\"repository\":null,\"tag\":null,\"name\":\"name1\",\"version\":null}}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryChartDeletedEventData).Target.MediaType, Is.EqualTo("mediatype1"));
        }

        [Test]
        public void ConsumeCloudEventContainerRegistryChartPushedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.ContainerRegistry/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.ContainerRegistry.ChartPushed\",  \"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"id\":\"id\",\"timestamp\":\"2018-06-20T12:00:33.6125843-07:00\",\"action\":\"action1\",\"target\":{\"mediaType\":\"mediatype1\",\"size\":40,\"digest\":\"digest1\",\"repository\":null,\"tag\":null,\"name\":\"name1\",\"version\":null}}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerRegistryChartPushedEventData).Target.MediaType, Is.EqualTo("mediatype1"));
        }
        #endregion

        #region Container service events
        [Test]
        public void ConsumeCloudEventContainerServiceSupportEndedEvent()
        {
            string requestContent = @"
            {
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""type"": ""Microsoft.ContainerService.ClusterSupportEnded"",
                ""time"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""kubernetesVersion"": ""1.23.15""
                },
                ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceClusterSupportEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
            Assert.That((eventData as ContainerServiceClusterSupportEndedEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
        }

        [Test]
        public void ConsumeCloudEventContainerServiceSupportEndingEvent()
        {
            string requestContent = @"
            {
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""type"": ""Microsoft.ContainerService.ClusterSupportEnding"",
                ""time"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""kubernetesVersion"": ""1.23.15""
                },
                ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceClusterSupportEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
            Assert.That((eventData as ContainerServiceClusterSupportEndingEventData).KubernetesVersion, Is.EqualTo("1.23.15"));
        }

        [Test]
        public void ConsumeCloudEventContainerServiceNodePoolRollingFailed()
        {
            string requestContent = @"
            {
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""type"": ""Microsoft.ContainerService.NodePoolRollingFailed"",
                ""time"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""nodePoolName"": ""nodepool1""
                },
                ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceNodePoolRollingEventData).NodePoolName, Is.EqualTo("nodepool1"));
            Assert.That((eventData as ContainerServiceNodePoolRollingFailedEventData).NodePoolName, Is.EqualTo("nodepool1"));
        }

        [Test]
        public void ConsumeCloudEventContainerServiceNodePoolRollingStarted()
        {
            string requestContent = @"
            {
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""type"": ""Microsoft.ContainerService.NodePoolRollingStarted"",
                ""time"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""nodePoolName"": ""nodepool1""
                },
                ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceNodePoolRollingEventData).NodePoolName, Is.EqualTo("nodepool1"));
            Assert.That((eventData as ContainerServiceNodePoolRollingStartedEventData).NodePoolName, Is.EqualTo("nodepool1"));
        }

        [Test]
        public void ConsumeCloudEventContainerServiceNodePoolRollingSucceeded()
        {
            string requestContent = @"
            {
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.ContainerService/managedClusters/{cluster}"",
                ""subject"": ""{cluster}"",
                ""type"": ""Microsoft.ContainerService.NodePoolRollingSucceeded"",
                ""time"": ""2023-03-29T18:00:00.0000000Z"",
                ""id"": ""1234567890abcdef1234567890abcdef12345678"",
                ""data"": {
                    ""nodePoolName"": ""nodepool1""
                },
                ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ContainerServiceNodePoolRollingEventData).NodePoolName, Is.EqualTo("nodepool1"));
            Assert.That((eventData as ContainerServiceNodePoolRollingSucceededEventData).NodePoolName, Is.EqualTo("nodepool1"));
        }
        #endregion

        #region IoTHub Device events
        [Test]
        public void ConsumeCloudEventIoTHubDeviceCreatedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",  \"id\": \"2da5e9b4-4e38-04c1-cc58-9da0b37230c0\", \"source\": \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\", \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\", \"type\": \"Microsoft.Devices.DeviceCreated\", \"time\": \"2018-07-03T23:20:07.6532054Z\",    \"data\": {      \"twin\": {        \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",        \"etag\": \"AAAAAAAAAAE=\",        \"deviceEtag\": null,        \"status\": \"enabled\",        \"statusUpdateTime\": \"0001-01-01T00:00:00\",        \"connectionState\": \"Disconnected\",        \"lastActivityTime\": \"0001-01-01T00:00:00\",        \"cloudToDeviceMessageCount\": 0,        \"authenticationType\": \"sas\",        \"x509Thumbprint\": {          \"primaryThumbprint\": null,          \"secondaryThumbprint\": null        },        \"version\": 2,        \"properties\": {          \"desired\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          },          \"reported\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          }        }      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\"    }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceCreatedEventData).Twin.Status, Is.EqualTo("enabled"));
        }

        [Test]
        public void ConsumeCloudEventIoTHubDeviceDeletedEvent()
        {
            string requestContent = "[  {\"specversion\": \"1.0\",     \"id\": \"aaaf95c6-ed99-b307-e321-81d8e4f731a6\",    \"source\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"type\": \"Microsoft.Devices.DeviceDeleted\",    \"time\": \"2018-07-03T23:21:33.2753956Z\",    \"data\": {      \"twin\": {        \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",        \"etag\": \"AAAAAAAAAAI=\",        \"deviceEtag\": null,        \"status\": \"enabled\",        \"statusUpdateTime\": \"0001-01-01T00:00:00\",        \"connectionState\": \"Disconnected\",        \"lastActivityTime\": \"0001-01-01T00:00:00\",        \"cloudToDeviceMessageCount\": 0,        \"authenticationType\": \"sas\",        \"x509Thumbprint\": {          \"primaryThumbprint\": null,          \"secondaryThumbprint\": null        },        \"version\": 3,        \"tags\": {          \"testKey\": \"testValue\"        },        \"properties\": {          \"desired\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          },          \"reported\": {            \"$metadata\": {              \"$lastUpdated\": \"2018-07-03T23:20:07.6532054Z\"            },            \"$version\": 1          }        }      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\"    }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceDeletedEventData).Twin.Etag, Is.EqualTo("AAAAAAAAAAI="));
        }

        [Test]
        public void ConsumeCloudEventIoTHubDeviceConnectedEvent()
        {
            string requestContent = "[  {\"specversion\": \"1.0\",     \"id\": \"fbfd8ee1-cf78-74c6-dbcf-e1c58638ccbd\",    \"source\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"type\": \"Microsoft.Devices.DeviceConnected\",    \"time\": \"2018-07-03T23:20:11.6921933+00:00\",    \"data\": {      \"deviceConnectionStateEventInfo\": {        \"sequenceNumber\":          \"000000000000000001D4132452F67CE200000002000000000000000000000001\"      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",      \"moduleId\": \"\"    }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceConnectedEventData).HubName, Is.EqualTo("EGTESTHUB1"));
        }

        [Test]
        public void ConsumeCloudEventIoTHubDeviceDisconnectedEvent()
        {
            string requestContent = "[  { \"specversion\": \"1.0\",    \"id\": \"877f0b10-a086-98ec-27b8-6ae2dfbf5f67\",    \"source\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"type\": \"Microsoft.Devices.DeviceDisconnected\",    \"time\": \"2018-07-03T23:20:52.646434+00:00\",    \"data\": {      \"deviceConnectionStateEventInfo\": {        \"sequenceNumber\":          \"000000000000000001D4132452F67CE200000002000000000000000000000002\"      },      \"hubName\": \"EGTESTHUB1\",      \"deviceId\": \"48e44e11-1437-4907-83b1-4a8d7e89859e\",      \"moduleId\": \"\"    }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceDisconnectedEventData).DeviceConnectionStateEventInfo.SequenceNumber, Is.EqualTo("000000000000000001D4132452F67CE200000002000000000000000000000002"));
        }

        [Test]
        public void ConsumeCloudEventIoTHubDeviceTelemetryEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"877f0b10-a086-98ec-27b8-6ae2dfbf5f67\",    \"source\":      \"/SUBSCRIPTIONS/BDF55CDD-8DAB-4CF4-9B2F-C21E8A780472/RESOURCEGROUPS/EGTESTRG/PROVIDERS/MICROSOFT.DEVICES/IOTHUBS/EGTESTHUB1\",    \"subject\": \"devices/48e44e11-1437-4907-83b1-4a8d7e89859e\",    \"type\": \"Microsoft.Devices.DeviceTelemetry\",    \"time\": \"2018-07-03T23:20:52.646434+00:00\",    \"data\": { \"body\": { \"Weather\": { \"Temperature\": 900  }, \"Location\": \"USA\"  },  \"properties\": {  \"Status\": \"Active\"  },  \"systemProperties\": { \"iothub-content-type\": \"application/json\", \"iothub-content-encoding\": \"utf-8\"   } }}   ]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as IotHubDeviceTelemetryEventData).Properties["Status"], Is.EqualTo("Active"));
        }
        #endregion

        #region EventGrid events
        [Test]
        public void ConsumeCloudEventEventGridSubscriptionValidationEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"validationCode\": \"512d38b6-c7b8-40c8-89fe-f46f9e9622b6\",    \"validationUrl\": \"https://rp-eastus2.eventgrid.azure.net:553/eventsubscriptions/estest/validate?id=B2E34264-7D71-453A-B5FB-B62D0FDC85EE&t=2018-04-26T20:30:54.4538837Z&apiVersion=2018-05-01-preview&token=1BNqCxBBSSE9OnNSfZM4%2b5H9zDegKMY6uJ%2fO2DFRkwQ%3d\"  },  \"type\": \"Microsoft.EventGrid.SubscriptionValidationEvent\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as SubscriptionValidationEventData).ValidationCode, Is.EqualTo("512d38b6-c7b8-40c8-89fe-f46f9e9622b6"));
        }

        [Test]
        public void ConsumeCloudEventEventGridSubscriptionDeletedEvent()
        {
            string requestContent = "[{ \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {    \"eventSubscriptionId\": \"/subscriptions/id/resourceGroups/rg/providers/Microsoft.EventGrid/topics/topic1/providers/Microsoft.EventGrid/eventSubscriptions/eventsubscription1\"  },  \"type\": \"Microsoft.EventGrid.SubscriptionDeletedEvent\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as SubscriptionDeletedEventData).EventSubscriptionId, Is.EqualTo("/subscriptions/id/resourceGroups/rg/providers/Microsoft.EventGrid/topics/topic1/providers/Microsoft.EventGrid/eventSubscriptions/eventsubscription1"));
        }

        [Test]
        public void ConsumeCloudEventEventGridMqttClientCreatedOrUpdatedEvent()
        {
            string requestContent = "[{ \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"createdOn\": \"2023-07-29T01:14:34.2048108Z\", \"updatedOn\": \"2023-07-29T01:14:34.2048108Z\",\"namespaceName\": \"myns\",\"clientName\": \"client1\",\"clientAuthenticationName\": \"client1\",\"state\": \"Enabled\",\"attributes\": {\"attribute1\": \"value1\"}  },  \"type\": \"Microsoft.EventGrid.MQTTClientCreatedOrUpdated\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as EventGridMqttClientCreatedOrUpdatedEventData).ClientName, Is.EqualTo("client1"));
            Assert.That((eventData as EventGridMqttClientCreatedOrUpdatedEventData).NamespaceName, Is.EqualTo("myns"));
            Assert.That((eventData as EventGridMqttClientCreatedOrUpdatedEventData).ClientAuthenticationName, Is.EqualTo("client1"));
        }

        [Test]
        public void ConsumeCloudEventEventGridMqttClientDeletedEvent()
        {
            string requestContent = "[{ \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"namespaceName\": \"myns\",\"clientName\": \"client1\",\"clientAuthenticationName\": \"client1\" },  \"type\": \"Microsoft.EventGrid.MQTTClientDeleted\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as EventGridMqttClientDeletedEventData).ClientName, Is.EqualTo("client1"));
            Assert.That((eventData as EventGridMqttClientDeletedEventData).NamespaceName, Is.EqualTo("myns"));
            Assert.That((eventData as EventGridMqttClientDeletedEventData).ClientAuthenticationName, Is.EqualTo("client1"));
        }

        [Test]
        public void ConsumeCloudEventEventGridMqttClientSessionConnectedEvent()
        {
            string requestContent = "[{ \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"namespaceName\": \"myns\",\"clientSessionName\": \"session\",\"clientAuthenticationName\": \"client1\", \"sequenceNumber\": 1 },  \"type\": \"Microsoft.EventGrid.MQTTClientSessionConnected\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as EventGridMqttClientSessionConnectedEventData).ClientSessionName, Is.EqualTo("session"));
            Assert.That((eventData as EventGridMqttClientSessionConnectedEventData).NamespaceName, Is.EqualTo("myns"));
            Assert.That((eventData as EventGridMqttClientSessionConnectedEventData).ClientAuthenticationName, Is.EqualTo("client1"));
            Assert.That((eventData as EventGridMqttClientSessionConnectedEventData).SequenceNumber, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeCloudEventEventGridMqttClientSessionDisconnectedEvent()
        {
            string requestContent = "[{ \"id\": \"2d1781af-3a4c-4d7c-bd0c-e34b19da4e66\",  \"source\": \"/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\",  \"subject\": \"\",  \"data\": {  \"namespaceName\": \"myns\",\"clientSessionName\": \"session\",\"clientAuthenticationName\": \"client1\", \"sequenceNumber\": 1, \"disconnectionReason\": \"ClientInitiatedDisconnect\" },  \"type\": \"Microsoft.EventGrid.MQTTClientSessionDisconnected\",  \"time\": \"2018-01-25T22:12:19.4556811Z\",  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as EventGridMqttClientSessionDisconnectedEventData).ClientSessionName, Is.EqualTo("session"));
            Assert.That((eventData as EventGridMqttClientSessionDisconnectedEventData).NamespaceName, Is.EqualTo("myns"));
            Assert.That((eventData as EventGridMqttClientSessionDisconnectedEventData).ClientAuthenticationName, Is.EqualTo("client1"));
            Assert.That((eventData as EventGridMqttClientSessionDisconnectedEventData).SequenceNumber, Is.EqualTo(1));
            Assert.That((eventData as EventGridMqttClientSessionDisconnectedEventData).DisconnectionReason, Is.EqualTo(EventGridMqttClientDisconnectionReason.ClientInitiatedDisconnect));
        }
        #endregion

        #region Event Hub Events
        [Test]
        public void ConsumeCloudEventEventHubCaptureFileCreatedEvent()
        {
            string requestContent = "[    {        \"source\": \"/subscriptions/guid/resourcegroups/rgDataMigrationSample/providers/Microsoft.EventHub/namespaces/tfdatamigratens\",        \"subject\": \"eventhubs/hubdatamigration\",        \"type\": \"microsoft.EventHUB.CaptureFileCreated\",        \"time\": \"2017-08-31T19:12:46.0498024Z\",        \"id\": \"14e87d03-6fbf-4bb2-9a21-92bd1281f247\",        \"data\": {            \"fileUrl\": \"https://tf0831datamigrate.blob.core.windows.net/windturbinecapture/tfdatamigratens/hubdatamigration/1/2017/08/31/19/11/45.avro\",            \"fileType\": \"AzureBlockBlob\",            \"partitionId\": \"1\",            \"sizeInBytes\": 249168,            \"eventCount\": 1500,            \"firstSequenceNumber\": 2400,            \"lastSequenceNumber\": 3899,            \"firstEnqueueTime\": \"2017-08-31T19:12:14.674Z\",            \"lastEnqueueTime\": \"2017-08-31T19:12:44.309Z\"        },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as EventHubCaptureFileCreatedEventData).FileType, Is.EqualTo("AzureBlockBlob"));
            Assert.That((eventData as EventHubCaptureFileCreatedEventData).Fileurl, Is.EqualTo("https://tf0831datamigrate.blob.core.windows.net/windturbinecapture/tfdatamigratens/hubdatamigration/1/2017/08/31/19/11/45.avro"));
        }
        #endregion

        #region MachineLearningServices events
        [Test]
        public void ConsumeCloudEventMachineLearningServicesModelRegisteredEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"source\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"type\":\"Microsoft.MachineLearningServices.ModelRegistered\",\"source\":\"models/sklearn_regression_model:3\",\"time\":\"2019-10-17T22:23:57.5350054+00:00\",\"id\":\"3b73ee51-bbf4-480d-9112-cfc23b41bfdb\",\"data\":{\"modelName\":\"sklearn_regression_model\",\"modelVersion\":\"3\",\"modelTags\":{\"area\":\"diabetes\",\"type\":\"regression\"},\"modelProperties\":{\"area\":\"test\"}}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesModelRegisteredEventData).ModelName, Is.EqualTo("sklearn_regression_model"));
            Assert.That((eventData as MachineLearningServicesModelRegisteredEventData).ModelVersion, Is.EqualTo("3"));

            Assert.That((eventData as MachineLearningServicesModelRegisteredEventData).ModelTags is IDictionary, Is.True);
            IDictionary tags = (IDictionary)(eventData as MachineLearningServicesModelRegisteredEventData).ModelTags;
            Assert.That(tags["type"], Is.EqualTo("regression"));

            Assert.That((eventData as MachineLearningServicesModelRegisteredEventData).ModelProperties is IDictionary, Is.True);
            IDictionary properties = (IDictionary)(eventData as MachineLearningServicesModelRegisteredEventData).ModelProperties;
            Assert.That(properties["area"], Is.EqualTo("test"));
        }

        [Test]
        public void ConsumeCloudEventMachineLearningServicesModelDeployedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"source\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"type\":\"Microsoft.MachineLearningServices.ModelDeployed\",\"subject\":\"endpoints/aciservice1\",\"time\":\"2019-10-23T18:20:08.8824474+00:00\",\"id\":\"40d0b167-be44-477b-9d23-a2befba7cde0\",\"data\":{\"serviceName\":\"aciservice1\",\"serviceComputeType\":\"ACI\",\"serviceTags\":{\"mytag\":\"test tag\"},\"serviceProperties\":{\"myprop\":\"test property\"},\"modelIds\":\"my_first_model:1,my_second_model:1\"}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesModelDeployedEventData).ServiceName, Is.EqualTo("aciservice1"));
            Assert.That((eventData as MachineLearningServicesModelDeployedEventData).ModelIds.Split(',').Length, Is.EqualTo(2));
        }

        [Test]
        public void ConsumeCloudEventMachineLearningServicesRunCompletedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"source\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"type\":\"Microsoft.MachineLearningServices.RunCompleted\",\"subject\":\"experiments/0fa9dfaa-cba3-4fa7-b590-23e48548f5c1/runs/AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"time\":\"2019-10-18T19:29:55.8856038+00:00\",\"id\":\"044ac44d-462c-4043-99eb-d9e01dc760ab\",\"data\":{\"experimentId\":\"0fa9dfaa-cba3-4fa7-b590-23e48548f5c1\",\"experimentName\":\"automl-local-regression\",\"runId\":\"AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"runType\":\"automl\",\"RunTags\":{\"experiment_status\":\"ModelSelection\",\"experiment_status_descr\":\"Beginning model selection.\"},\"runProperties\":{\"num_iterations\":\"10\",\"target\":\"local\"}}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesRunCompletedEventData).RunId, Is.EqualTo("AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc"));
            Assert.That((eventData as MachineLearningServicesRunCompletedEventData).ExperimentName, Is.EqualTo("automl-local-regression"));
        }

        [Test]
        public void ConsumeCloudEventMachineLearningServicesRunStatusChangedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"source\":\"/subscriptions/a5fe3bc5-98f0-4c84-affc-a589f54d9b23/resourceGroups/jenns/providers/Microsoft.MachineLearningServices/workspaces/jenns-canary\",\"type\":\"Microsoft.MachineLearningServices.RunStatusChanged\",\"subject\":\"experiments/0fa9dfaa-cba3-4fa7-b590-23e48548f5c1/runs/AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"time\":\"2020-03-09T23:53:04.4579724Z\",\"id\":\"aa8cd7df-fe28-5d5d-9b40-3342dbc2a887\",\"data\":{\"runStatus\": \"Running\",\"experimentId\":\"0fa9dfaa-cba3-4fa7-b590-23e48548f5c1\",\"experimentName\":\"automl-local-regression\",\"runId\":\"AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc\",\"runType\":\"automl\",\"runTags\":{\"experiment_status\":\"ModelSelection\",\"experiment_status_descr\":\"Beginning model selection.\"},\"runProperties\":{\"num_iterations\":\"10\",\"target\":\"local\"}}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MachineLearningServicesRunStatusChangedEventData sysData = eventData as MachineLearningServicesRunStatusChangedEventData;
            Assert.That(sysData.RunId, Is.EqualTo("AutoML_ad912b2d-6467-4f32-a616-dbe4af6dd8fc"));
            Assert.That(sysData.ExperimentName, Is.EqualTo("automl-local-regression"));
            Assert.That(sysData.RunStatus, Is.EqualTo("Running"));
            Assert.That(sysData.RunType, Is.EqualTo("automl"));
        }

        [Test]
        public void ConsumeCloudEventMachineLearningServicesDatasetDriftDetectedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"source\":\"/subscriptions/60582a10-b9fd-49f1-a546-c4194134bba8/resourceGroups/copetersRG/providers/Microsoft.MachineLearningServices/workspaces/driftDemoWS\",\"type\":\"Microsoft.MachineLearningServices.DatasetDriftDetected\",\"subject\":\"datadrift/01d29aa4-e6a4-470a-9ef3-66660d21f8ef/run/01d29aa4-e6a4-470a-9ef3-66660d21f8ef_1571590300380\",\"time\":\"2019-10-20T17:08:08.467191+00:00\",\"id\":\"2684de79-b145-4dcf-ad2e-6a1db798585f\",\"data\":{\"dataDriftId\":\"01d29aa4-e6a4-470a-9ef3-66660d21f8ef\",\"dataDriftName\":\"copetersDriftMonitor3\",\"runId\":\"01d29aa4-e6a4-470a-9ef3-66660d21f8ef_1571590300380\",\"baseDatasetId\":\"3c56d136-0f64-4657-a0e8-5162089a88a3\",\"tarAsSystemEventDatasetId\":\"d7e74d2e-c972-4266-b5fb-6c9c182d2a74\",\"driftCoefficient\":0.8350349068479208,\"startTime\":\"2019-07-04T00:00:00+00:00\",\"endTime\":\"2019-07-05T00:00:00+00:00\"}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MachineLearningServicesDatasetDriftDetectedEventData).DataDriftName, Is.EqualTo("copetersDriftMonitor3"));
        }
        #endregion

        #region Maps events
        [Test]
        public void ConsumeCloudEventMapsGeofenceEnteredEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.Maps.GeofenceEntered\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":[\"id1\",\"id2\"],\"isEventPublished\":true}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MapsGeofenceEnteredEventData).Geometries[0].Distance, Is.EqualTo(1.0));
        }

        [Test]
        public void ConsumeCloudEventMapsGeofenceExitedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.Maps.GeofenceExited\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":[\"id1\",\"id2\"],\"isEventPublished\":true}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MapsGeofenceExitedEventData).Geometries[0].Distance, Is.EqualTo(1.0));
        }

        [Test]
        public void ConsumeCloudEventMapsGeofenceResultEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"id\": \"56afc886-767b-d359-d59e-0da7877166b2\",  \"source\": \"/SUBSCRIPTIONS/ID/RESOURCEGROUPS/rg/PROVIDERS/MICROSOFT.Maps/test1\",  \"subject\": \"test1\",  \"type\": \"Microsoft.Maps.GeofenceResult\",\"time\": \"2018-01-02T19:17:44.4383997Z\",  \"data\": {\"expiredGeofenceGeometryId\":[\"id1\",\"id2\"],\"geometries\":[{\"deviceId\":\"id1\",\"distance\":1.0,\"geometryId\":\"gid1\",\"nearestLat\":72.4,\"nearestLon\":100.4,\"udId\":\"id22\"}],\"invalidPeriodGeofenceGeometryId\":[\"id1\",\"id2\"],\"isEventPublished\":true}}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MapsGeofenceResultEventData).Geometries[0].Distance, Is.EqualTo(1.0));
        }
        #endregion

        #region Media Services events
        [Test]
        public void ConsumeCloudEventMediaMediaJobStateChangeEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobStateChange\",  \"time\": \"2018-10-12T15:14:20.2412317\",  \"id\": \"341520d0-dac0-4930-97dd-3085538c624f\",  \"data\": {    \"previousState\": \"Scheduled\",    \"state\": \"Processing\",    \"correlationData\": {}  },  \"specversion\": \"1.0\"}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobStateChangeEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobStateChangeEventData).State, Is.EqualTo(MediaJobState.Processing));
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputStateChangeEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobOutputStateChange\",  \"time\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"8d0305c0-28c0-4cc9-b613-776e4dd31e9a\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {\"code\":\"ServiceError\", \"message\":\"error message\", \"category\":\"Service\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputStateChangeEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobOutputStateChangeEventData).Output.State, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobOutputStateChangeEventData).Output is MediaJobOutputAsset, Is.True);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)(eventData as MediaJobOutputStateChangeEventData).Output;
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-2ac2fe75-6557-4de5-ab25-5713b74a6901"));
        }

        [Test]
        public void ConsumeCloudEventMediaJobScheduledEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\", \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobScheduled\",  \"time\": \"2018-10-12T15:14:11.3028183\",  \"id\": \"9b17dbf0-355d-4fb0-9a73-e76b150858c8\",  \"data\": {    \"previousState\": \"Queued\",    \"state\": \"Scheduled\",    \"correlationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobScheduledEventData).PreviousState, Is.EqualTo(MediaJobState.Queued));
            Assert.That((eventData as MediaJobScheduledEventData).State, Is.EqualTo(MediaJobState.Scheduled));
        }

        [Test]
        public void ConsumeCloudEventMediaJobProcessingEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobProcessing\",  \"time\": \"2018-10-12T15:14:20.2412317\",  \"id\": \"72162c44-c7f4-437a-9592-48b83cec2d18\",  \"data\": {    \"previousState\": \"Scheduled\",    \"state\": \"Processing\",    \"correlationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobProcessingEventData).PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobProcessingEventData).State, Is.EqualTo(MediaJobState.Processing));
        }

        [Test]
        public void ConsumeCloudEventMediaJobCancelingEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"type\": \"Microsoft.Media.JobCanceling\",  \"time\": \"2018-10-12T15:41:50.5513295\",  \"id\": \"1f9a488b-abe3-4fca-80b8-aae59bf7f123\",  \"data\": {    \"previousState\": \"Processing\",    \"state\": \"Canceling\",    \"correlationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobCancelingEventData).PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That((eventData as MediaJobCancelingEventData).State, Is.EqualTo(MediaJobState.Canceling));
        }

        [Test]
        public void ConsumeCloudEventMediaJobFinishedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-298338bb-f8d1-4d0f-9fde-544e0ac4d983\",  \"type\": \"Microsoft.Media.JobFinished\",  \"time\": \"2018-10-01T20:58:26.7886175\",  \"id\": \"83f8464d-be94-48e5-b67b-46c6199fe28e\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-298338bb-f8d1-4d0f-9fde-544e0ac4d983\",       \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 100,        \"state\": \"Finished\"      }    ],    \"previousState\": \"Processing\",    \"state\": \"Finished\",    \"correlationData\": {}  } }]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobFinishedEventData sysData = eventData as MediaJobFinishedEventData;
            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysData.State, Is.EqualTo(MediaJobState.Finished));
            Assert.That(sysData.Outputs.Count, Is.EqualTo(1));
            Assert.That(sysData.Outputs[0] is MediaJobOutputAsset, Is.True);
            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)sysData.Outputs[0];

            Assert.That(outputAsset.State, Is.EqualTo(MediaJobState.Finished));
            Assert.That(outputAsset.Error, Is.Null);
            Assert.That(outputAsset.Progress, Is.EqualTo(100));
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-298338bb-f8d1-4d0f-9fde-544e0ac4d983"));
        }

        [Test]
        public void ConsumeCloudEventMediaJobCanceledEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"type\": \"Microsoft.Media.JobCanceled\",  \"time\": \"2018-10-12T15:42:05.6519929\",  \"id\": \"3fef7871-f916-4980-8a45-e79a2675808b\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",        \"error\": {\"code\":\"ServiceError\", \"message\":\"error message\", \"category\":\"Service\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 83,        \"state\": \"Canceled\"      }    ],    \"previousState\": \"Canceling\",    \"state\": \"Canceled\",    \"correlationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobCanceledEventData sysData = eventData as MediaJobCanceledEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That(sysData.State, Is.EqualTo(MediaJobState.Canceled));
            Assert.That(sysData.Outputs.Count, Is.EqualTo(1));
            Assert.That(sysData.Outputs[0] is MediaJobOutputAsset, Is.True);

            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)sysData.Outputs[0];

            Assert.That(outputAsset.State, Is.EqualTo(MediaJobState.Canceled));
            Assert.That(outputAsset.Progress, Is.Not.EqualTo(100));
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-7a8215f9-0f8d-48a6-82ed-1ead772bc221"));
        }

        [Test]
        public void ConsumeCloudEventMediaJobErroredEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobErrored\",  \"time\": \"2018-10-12T15:29:20.9954767\",  \"id\": \"2749e9cf-4095-4723-9bc5-df8e15289135\",  \"data\": {    \"outputs\": [      {        \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",        \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",        \"error\": {          \"category\": \"Service\",          \"code\": \"ServiceError\",          \"details\": [            {              \"code\": \"Internal\",              \"message\": \"Internal error in initializing the task for processing\"            }          ],          \"message\": \"Fatal service error, please contact support.\",          \"retry\": \"DoNotRetry\"        },        \"label\": \"VideoAnalyzerPreset_0\",        \"progress\": 83,        \"state\": \"Error\"      }    ],    \"previousState\": \"Processing\",    \"state\": \"Error\",    \"correlationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobErroredEventData sysData = eventData as MediaJobErroredEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysData.State, Is.EqualTo(MediaJobState.Error));
            Assert.That(sysData.Outputs.Count, Is.EqualTo(1));
            Assert.That(sysData.Outputs[0] is MediaJobOutputAsset, Is.True);

            Assert.That(sysData.Outputs[0].State, Is.EqualTo(MediaJobState.Error));
            Assert.NotNull(sysData.Outputs[0].Error);
            Assert.That(sysData.Outputs[0].Error.Category, Is.EqualTo(MediaJobErrorCategory.Service));
            Assert.That(sysData.Outputs[0].Error.Code, Is.EqualTo(MediaJobErrorCode.ServiceError));
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputCanceledEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"type\": \"Microsoft.Media.JobOutputCanceled\",  \"time\": \"2018-10-12T15:42:04.949555\",  \"id\": \"9297cda2-4a50-4622-a679-c3785d27d512\",  \"data\": {    \"previousState\": \"Canceling\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",      \"error\": {\"code\":\"ServiceError\", \"message\":\"error message\", \"category\":\"Service\", \"retry\":\"DoNotRetry\", \"details\":[{\"code\":\"code\", \"message\":\"Service Error Message\"}]},      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Canceled\"    },    \"jobCorrelationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputCanceledEventData sysData = eventData as MediaJobOutputCanceledEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Canceling));
            Assert.That(sysData.Output.State, Is.EqualTo(MediaJobState.Canceled));
            Assert.That(sysData.Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputCancelingEvent()
        {
            string requestContent = "{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",  \"type\": \"Microsoft.Media.JobOutputCanceling\",  \"time\": \"2018-10-12T15:42:04.949555\",  \"id\": \"9297cda2-4a50-4622-a679-c3785d27d512\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-7a8215f9-0f8d-48a6-82ed-1ead772bc221\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Canceling\"    },    \"jobCorrelationData\": {}  }, \"specversion\": \"1.0\"}";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputCancelingEventData sysData = eventData as MediaJobOutputCancelingEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysData.Output.State, Is.EqualTo(MediaJobState.Canceling));
            Assert.That(sysData.Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputErroredEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobOutputErrored\",  \"time\": \"2018-10-12T15:29:20.2621252\",  \"id\": \"bc9e6342-f081-49c2-a579-92f506a622c2\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 83,      \"state\": \"Error\"    },    \"jobCorrelationData\": {}  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputErroredEventData sysData = eventData as MediaJobOutputErroredEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysData.Output.State, Is.EqualTo(MediaJobState.Error));
            Assert.That(sysData.Output is MediaJobOutputAsset, Is.True);
            Assert.NotNull(sysData.Output.Error);
            Assert.That(sysData.Output.Error.Category, Is.EqualTo(MediaJobErrorCategory.Service));
            Assert.That(sysData.Output.Error.Code, Is.EqualTo(MediaJobErrorCode.ServiceError));
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputFinishedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobOutputFinished\",  \"time\": \"2018-10-12T15:29:20.2621252\",  \"id\": \"bc9e6342-f081-49c2-a579-92f506a622c2\",  \"data\": {    \"previousState\": \"Processing\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",            \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 100,      \"state\": \"Finished\"    },    \"jobCorrelationData\": {}  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputFinishedEventData sysData = eventData as MediaJobOutputFinishedEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysData.Output.State, Is.EqualTo(MediaJobState.Finished));
            Assert.That(sysData.Output is MediaJobOutputAsset, Is.True);
            Assert.That(sysData.Output.Progress, Is.EqualTo(100));

            MediaJobOutputAsset outputAsset = (MediaJobOutputAsset)sysData.Output;
            Assert.That(outputAsset.AssetName, Is.EqualTo("output-2ac2fe75-6557-4de5-ab25-5713b74a6901"));
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputProcessingEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobOutputProcessing\",  \"time\": \"2018-10-12T15:14:17.8962704\",  \"id\": \"d48eeb0b-2bfa-4265-a2f8-624654c3781c\",  \"data\": {    \"previousState\": \"Scheduled\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Processing\"    },    \"jobCorrelationData\": {}  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputProcessingEventData sysData = eventData as MediaJobOutputProcessingEventData;

            Assert.That(sysData.PreviousState, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That(sysData.Output.State, Is.EqualTo(MediaJobState.Processing));
            Assert.That(sysData.Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputScheduledEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6901\",  \"type\": \"Microsoft.Media.JobOutputScheduled\",  \"time\": \"2018-10-12T15:14:11.2244618\",  \"id\": \"635ca6ea-5306-4590-b2e1-22f172759336\",  \"data\": {    \"previousState\": \"Queued\",    \"output\": {      \"@odata.type\": \"#Microsoft.Media.JobOutputAsset\",      \"assetName\": \"output-2ac2fe75-6557-4de5-ab25-5713b74a6901\",      \"error\": {        \"category\": \"Service\",        \"code\": \"ServiceError\",        \"details\": [          {            \"code\": \"Internal\",            \"message\": \"Internal error in initializing the task for processing\"          }        ],        \"message\": \"Fatal service error, please contact support.\",        \"retry\": \"DoNotRetry\"      },      \"label\": \"VideoAnalyzerPreset_0\",      \"progress\": 0,      \"state\": \"Scheduled\"    },    \"jobCorrelationData\": {}  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as MediaJobOutputScheduledEventData).PreviousState, Is.EqualTo(MediaJobState.Queued));
            Assert.That((eventData as MediaJobOutputScheduledEventData).Output.State, Is.EqualTo(MediaJobState.Scheduled));
            Assert.That((eventData as MediaJobOutputScheduledEventData).Output is MediaJobOutputAsset, Is.True);
        }

        [Test]
        public void ConsumeCloudEventMediaJobOutputProgressEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"transforms/VideoAnalyzerTransform/jobs/job-2ac2fe75-6557-4de5-ab25-5713b74a6981\",  \"type\": \"Microsoft.Media.JobOutputProgress\",  \"time\": \"2018-10-12T15:14:11.2244618\",  \"id\": \"635ca6ea-5306-4590-b2e1-22f172759336\",  \"data\": {    \"jobCorrelationData\": {    \"Field1\": \"test1\",    \"Field2\": \"test2\" },    \"label\": \"TestLabel\",    \"progress\": 50 }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaJobOutputProgressEventData sysData = eventData as MediaJobOutputProgressEventData;

            Assert.That(sysData.Label, Is.EqualTo("TestLabel"));
            Assert.That(sysData.Progress, Is.EqualTo(50));
            Assert.That(sysData.JobCorrelationData.ContainsKey("Field1"), Is.True);
            Assert.That(sysData.JobCorrelationData["Field1"], Is.EqualTo("test1"));
            Assert.That(sysData.JobCorrelationData.ContainsKey("Field2"), Is.True);
            Assert.That(sysData.JobCorrelationData["Field2"], Is.EqualTo("test2"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventEncoderConnectedEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventEncoderConnected\",  \"time\": \"2018-10-12T15:52:04.2013501\",  \"id\": \"3d1f5b26-c466-47e7-927b-900985e0c5d5\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\"  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventEncoderConnectedEventData sysData = eventData as MediaLiveEventEncoderConnectedEventData;

            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.StreamId, Is.EqualTo("Mystream1"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventConnectionRejectedEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventConnectionRejected\",  \"time\": \"2018-10-12T15:52:04.2013501\",  \"id\": \"3d1f5b26-c466-47e7-927b-900985e0c5d5\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"resultCode\": \"MPE_INGEST_CODEC_NOT_SUPPORTED\"   }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventConnectionRejectedEventData sysData = eventData as MediaLiveEventConnectionRejectedEventData;

            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.StreamId, Is.EqualTo("Mystream1"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventEncoderDisconnectedEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventEncoderDisconnected\",  \"time\": \"2018-10-12T15:52:19.8982128\",  \"id\": \"e4b55140-42d2-4c24-b08e-9aa12f1587fc\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"streamId\": \"Mystream1\",    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"resultCode\": \"MPE_CLIENT_TERMINATED_SESSION\"  }, \"specversion\": \"1.0\"}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventEncoderDisconnectedEventData sysData = eventData as MediaLiveEventEncoderDisconnectedEventData;

            Assert.That(sysData.ResultCode, Is.EqualTo("MPE_CLIENT_TERMINATED_SESSION"));

            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.StreamId, Is.EqualTo("Mystream1"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventIncomingStreamReceivedEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventIncomingStreamReceived\",  \"time\": \"2018-10-12T15:52:16.5726463Z\",  \"id\": \"eb688fa1-5a19-4703-8aeb-6a65a09790da\",  \"data\": {    \"ingestUrl\": \"rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59\",    \"trackType\": \"audio\",    \"trackName\": \"audio_160000\",    \"bitrate\": 160000,    \"encoderIp\": \"<ip address>\",    \"encoderPort\": \"3557\",    \"timestamp\": \"66\",    \"duration\": \"1950\",    \"timescale\": \"1000\"  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventIncomingStreamReceivedEventData sysData = eventData as MediaLiveEventIncomingStreamReceivedEventData;

            Assert.That(sysData.IngestUrl, Is.EqualTo("rtmp://liveevent-ec9d26a8.channel.media.azure.net:1935/live/cb5540b10a5646218c1328be95050c59"));
            Assert.That(sysData.EncoderIp, Is.EqualTo("<ip address>"));
            Assert.That(sysData.EncoderPort, Is.EqualTo("3557"));
            Assert.That(sysData.TrackType, Is.EqualTo("audio"));
            Assert.That(sysData.TrackName, Is.EqualTo("audio_160000"));
            Assert.That(sysData.Bitrate, Is.EqualTo(160000));
            Assert.That(sysData.Timestamp, Is.EqualTo("66"));
            Assert.That(sysData.Duration, Is.EqualTo("1950"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventIncomingStreamsOutOfSyncEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventIncomingStreamsOutOfSync\",  \"time\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"minLastTimestamp\": \"10999\",    \"typeOfStreamWithMinLastTimestamp\": \"video\",    \"maxLastTimestamp\": \"100999\",    \"typeOfStreamWithMaxLastTimestamp\": \"audio\",    \"timescaleOfMinLastTimestamp\": \"1000\",  \"timescaleOfMaxLastTimestamp\": \"1000\"    }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventIncomingStreamsOutOfSyncEventData sysData = eventData as MediaLiveEventIncomingStreamsOutOfSyncEventData;

            Assert.That(sysData.MinLastTimestamp, Is.EqualTo("10999"));
            Assert.That(sysData.TypeOfStreamWithMinLastTimestamp, Is.EqualTo("video"));
            Assert.That(sysData.MaxLastTimestamp, Is.EqualTo("100999"));
            Assert.That(sysData.TypeOfStreamWithMaxLastTimestamp, Is.EqualTo("audio"));
            Assert.That(sysData.TimescaleOfMinLastTimestamp, Is.EqualTo("1000"));
            Assert.That(sysData.TimescaleOfMaxLastTimestamp, Is.EqualTo("1000"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventIncomingVideoStreamsOutOfSyncEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync\",  \"time\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"firstTimestamp\": \"10999\",    \"firstDuration\": \"2000\",    \"secondTimestamp\": \"100999\",    \"secondDuration\": \"2000\",    \"timescale\": \"1000\"  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventIncomingVideoStreamsOutOfSyncEventData sysData = eventData as MediaLiveEventIncomingVideoStreamsOutOfSyncEventData;

            Assert.That(sysData.FirstTimestamp, Is.EqualTo("10999"));
            Assert.That(sysData.FirstDuration, Is.EqualTo("2000"));
            Assert.That(sysData.SecondTimestamp, Is.EqualTo("100999"));
            Assert.That(sysData.SecondDuration, Is.EqualTo("2000"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventIncomingDataChunkDroppedEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventIncomingDataChunkDropped\",  \"time\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"timestamp\": \"8999\",    \"trackType\": \"video\",    \"trackName\": \"video1\",    \"bitrate\": 2500000,    \"timescale\": \"1000\",    \"resultCode\": \"FragmentDrop_OverlapTimestamp\"  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventIncomingDataChunkDroppedEventData sysData = eventData as MediaLiveEventIncomingDataChunkDroppedEventData;

            Assert.That(sysData.Timestamp, Is.EqualTo("8999"));
            Assert.That(sysData.TrackType, Is.EqualTo("video"));
            Assert.That(sysData.TrackName, Is.EqualTo("video1"));
            Assert.That(sysData.Bitrate, Is.EqualTo(2500000));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
            Assert.That(sysData.ResultCode, Is.EqualTo("FragmentDrop_OverlapTimestamp"));
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventIngestHeartbeatEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventIngestHeartbeat\",  \"time\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"incomingBitrate\": 500726,    \"lastTimestamp\": \"11999\",    \"timescale\": \"1000\",    \"overlapCount\": 0,    \"discontinuityCount\": 0,    \"nonincreasingCount\": 0,    \"unexpectedBitrate\": true,    \"state\": \"Running\",    \"healthy\": false  }, \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventIngestHeartbeatEventData sysData = eventData as MediaLiveEventIngestHeartbeatEventData;

            Assert.That(sysData.TrackType, Is.EqualTo("video"));
            Assert.That(sysData.TrackName, Is.EqualTo("video"));
            Assert.That(sysData.Bitrate, Is.EqualTo(2500000));
            Assert.That(sysData.IncomingBitrate, Is.EqualTo(500726));
            Assert.That(sysData.LastTimestamp, Is.EqualTo("11999"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
            Assert.That(sysData.OverlapCount, Is.EqualTo(0));
            Assert.That(sysData.DiscontinuityCount, Is.EqualTo(0));
            Assert.That(sysData.NonincreasingCount, Is.EqualTo(0));
            Assert.That(sysData.UnexpectedBitrate, Is.True);
            Assert.That(sysData.State, Is.EqualTo("Running"));
            Assert.That(sysData.Healthy, Is.False);
        }

        [Test]
        public void ConsumeCloudEventMediaLiveEventTrackDiscontinuityDetectedEvent()
        {
            string requestContent = "[{\"specversion\": \"1.0\",   \"source\": \"/subscriptions/{subscription id}/resourceGroups/{resource group}/providers/Microsoft.Media/mediaservices/{account name}\",  \"subject\": \"liveEvent/liveevent-ec9d26a8\",  \"type\": \"Microsoft.Media.LiveEventTrackDiscontinuityDetected\",  \"time\": \"2018-10-12T15:52:37.3710102\",  \"id\": \"d84727e2-d9c0-4a21-a66b-8d23f06b3e06\",  \"data\": {    \"trackType\": \"video\",    \"trackName\": \"video\",    \"bitrate\": 2500000,    \"previousTimestamp\": \"10999\",    \"newTimestamp\": \"14999\",    \"timescale\": \"1000\",    \"discontinuityGap\": \"4000\"  }}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            MediaLiveEventTrackDiscontinuityDetectedEventData sysData = eventData as MediaLiveEventTrackDiscontinuityDetectedEventData;

            Assert.That(sysData.TrackType, Is.EqualTo("video"));
            Assert.That(sysData.TrackName, Is.EqualTo("video"));
            Assert.That(sysData.Bitrate, Is.EqualTo(2500000));
            Assert.That(sysData.PreviousTimestamp, Is.EqualTo("10999"));
            Assert.That(sysData.NewTimestamp, Is.EqualTo("14999"));
            Assert.That(sysData.Timescale, Is.EqualTo("1000"));
            Assert.That(sysData.DiscontinuityGap, Is.EqualTo("4000"));
        }
        #endregion

        #region Resource Manager (Azure Subscription/Resource Group) events
        [Test]
        public void ConsumeCloudEventResourceWriteSuccessEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceWriteSuccess\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },    \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            ResourceWriteSuccessEventData sysData = eventData as ResourceWriteSuccessEventData;

            Assert.That(sysData.TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceWriteFailureEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceWriteFailure\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },    \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);

            Assert.That((eventData as ResourceWriteFailureEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceWriteCancelEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceWriteCancel\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },    \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceWriteCancelEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceDeleteSuccessEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceDeleteSuccess\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceDeleteSuccessEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceDeleteFailureEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceDeleteFailure\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceDeleteFailureEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceDeleteCancelEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceDeleteCancel\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceDeleteCancelEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

    [Test]
        public void ConsumeCloudEventResourceActionSuccessEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceActionSuccess\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceActionSuccessEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceActionFailureEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceActionFailure\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceActionFailureEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }

        [Test]
        public void ConsumeCloudEventResourceActionCancelEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.Resources.ResourceActionCancel\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": {        \"authorization\":\"{azure_resource_manager_authorizations}\",        \"claims\":\"{azure_resource_manager_claims}\",        \"correlationId\":\"54ef1e39-6a82-44b3-abc1-bdeb6ce4d3c6\",        \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",        \"operationName\":\"Microsoft.EventGrid/eventSubscriptions/write\",        \"status\":\"Succeeded\",        \"subscriptionId\":\"{subscription-id}\",        \"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"        },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ResourceActionCancelEventData).TenantId, Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
        }
        #endregion

        #region ServiceBus events
        [Test]
        public void ConsumeCloudEventServiceBusActiveMessagesAvailableWithNoListenersEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"type\": \"Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners\",  \"time\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ServiceBusActiveMessagesAvailableWithNoListenersEventData).NamespaceName, Is.EqualTo("testns1"));
        }

        [Test]
        public void ConsumeCloudEventServiceBusDeadletterMessagesAvailableWithNoListenersEvent()
        {
            string requestContent = "[{  \"source\": \"/subscriptions/id/resourcegroups/rg/providers/Microsoft.ServiceBus/namespaces/testns1\",  \"subject\": \"topics/topic1/subscriptions/sub1\",  \"type\": \"Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListeners\",  \"time\": \"2018-02-14T05:12:53.4133526Z\",  \"id\": \"dede87b0-3656-419c-acaf-70c95ddc60f5\",  \"data\": {    \"namespaceName\": \"testns1\",    \"requestUri\": \"https://testns1.servicebus.windows.net/t1/subscriptions/sub1/messages/head\",    \"entityType\": \"subscriber\",    \"queueName\": \"queue1\",    \"topicName\": \"topic1\",    \"subscriptionName\": \"sub1\"  },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as ServiceBusDeadletterMessagesAvailableWithNoListenersEventData).NamespaceName, Is.EqualTo("testns1"));
        }
        #endregion

        #region Storage events
        [Test]
        public void ConsumeCloudEventStorageBlobCreatedEvent()
        {
            string requestContent = "[ {  \"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/file1.txt\",  \"type\": \"Microsoft.Storage.BlobCreated\",  \"time\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"PutBlockList\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"contentType\": \"text/plain\",    \"contentLength\": 447,    \"blobType\": \"BlockBlob\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/file1.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\" },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobCreatedEventData).Url, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/file1.txt"));
        }

        [Test]
        public void ConsumeCloudEventStorageBlobDeletedEvent()
        {
            string requestContent = "[{   \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"type\": \"Microsoft.Storage.BlobDeleted\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteBlob\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"contentType\": \"text/plain\",    \"blobType\": \"BlockBlob\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobDeletedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testfile.txt"));
        }

        [Test]
        public void ConsumeCloudEventStorageBlobRenamedEvent()
        {
            string requestContent = "[ {  \"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testfile.txt\",  \"type\": \"Microsoft.Storage.BlobRenamed\",  \"time\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"RenameFile\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"destinationUrl\": \"https://myaccount.blob.core.windows.net/testcontainer/testfile.txt\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobRenamedEventData).DestinationUrl, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/testfile.txt"));
        }

        [Test]
        public void ConsumeCloudEventStorageDirectoryCreatedEvent()
        {
            string requestContent = "[ {  \"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/myaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"type\": \"Microsoft.Storage.DirectoryCreated\",  \"time\": \"2017-08-16T01:57:26.005121Z\",  \"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",  \"data\": {    \"api\": \"CreateDirectory\",    \"clientRequestId\": \"799304a4-bbc5-45b6-9849-ec2c66be800a\",    \"requestId\": \"602a88ef-0001-00e6-1233-164607000000\",    \"eTag\": \"0x8D4E44A24ABE7F1\",    \"url\": \"https://myaccount.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"00000000000000EB000000000000C65A\"  },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryCreatedEventData).Url, Is.EqualTo("https://myaccount.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeCloudEventStorageDirectoryDeletedEvent()
        {
            string requestContent = "[{   \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"type\": \"Microsoft.Storage.DirectoryDeleted\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"DeleteDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },   \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryDeletedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeCloudEventStorageDirectoryRenamedEvent()
        {
            string requestContent = "[{   \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"type\": \"Microsoft.Storage.DirectoryRenamed\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"destinationUrl\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"specversion\": \"1.0\"}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageDirectoryRenamedEventData).DestinationUrl, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeCloudEventStorageAsyncOperationInitiatedEvent()
        {
            string requestContent = "[{   \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"type\": \"Microsoft.Storage.AsyncOperationInitiated\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"specversion\": \"1.0\"}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageAsyncOperationInitiatedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }

        [Test]
        public void ConsumeCloudEventStorageBlobTierChangedEvent()
        {
            string requestContent = "[{   \"source\": \"/subscriptions/id/resourceGroups/Storage/providers/Microsoft.Storage/storageAccounts/xstoretestaccount\",  \"subject\": \"/blobServices/default/containers/testcontainer/blobs/testDir\",  \"type\": \"Microsoft.Storage.BlobTierChanged\",  \"time\": \"2017-11-07T20:09:22.5674003Z\",  \"id\": \"4c2359fe-001e-00ba-0e04-58586806d298\",  \"data\": {    \"api\": \"RenameDirectory\",    \"requestId\": \"4c2359fe-001e-00ba-0e04-585868000000\",    \"url\": \"https://example.blob.core.windows.net/testcontainer/testDir\",    \"sequencer\": \"0000000000000281000000000002F5CA\",    \"storageDiagnostics\": {      \"batchId\": \"b68529f3-68cd-4744-baa4-3c0498ec19f0\"    }  },  \"specversion\": \"1.0\"}]";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as StorageBlobTierChangedEventData).Url, Is.EqualTo("https://example.blob.core.windows.net/testcontainer/testDir"));
        }
        #endregion

        #region App Service events
        [Test]
        public void ConsumeCloudEventWebAppUpdatedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.AppUpdated\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebAppUpdatedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebBackupOperationStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.BackupOperationStarted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebBackupOperationStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebBackupOperationCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.BackupOperationCompleted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebBackupOperationCompletedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebBackupOperationFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.BackupOperationFailed\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));
            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebBackupOperationFailedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebRestoreOperationStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.RestoreOperationStarted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebRestoreOperationStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebRestoreOperationCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.RestoreOperationCompleted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebRestoreOperationCompletedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebRestoreOperationFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.RestoreOperationFailed\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebRestoreOperationFailedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebSlotSwapStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.SlotSwapStarted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent), skipValidation: false);

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebSlotSwapCompletedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"specversion\": \"1.0\", \"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.SlotSwapCompleted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}}}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapCompletedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebSlotSwapFailedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.SlotSwapFailed\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},   \"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapFailedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebSlotSwapWithPreviewStartedEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.SlotSwapWithPreviewStarted\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},  \"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapWithPreviewStartedEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebSlotSwapWithPreviewCancelledEvent()
        {
            string siteName = "testSite01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/sites/testSite01\", \"subject\": \"/Microsoft.Web/sites/testSite01\",\"type\": \"Microsoft.Web.SlotSwapWithPreviewCancelled\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appEventTypeDetail\": {{ \"action\": \"Restarted\"}},\"name\": \"{siteName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},   \"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebSlotSwapWithPreviewCancelledEventData).Name, Is.EqualTo(siteName));
        }

        [Test]
        public void ConsumeCloudEventWebAppServicePlanUpdatedEvent()
        {
            string planName = "testPlan01";
            string requestContent = $"[{{\"source\": \"/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/testrg/providers/Microsoft.Web/serverfarms/testPlan01\", \"subject\": \"/Microsoft.Web/serverfarms/testPlan01\",\"type\": \"Microsoft.Web.AppServicePlanUpdated\", \"time\": \"2017-08-16T01:57:26.005121Z\",\"id\": \"602a88ef-0001-00e6-1233-1646070610ea\",\"data\": {{ \"appServicePlanEventTypeDetail\": {{ \"stampKind\": \"Public\",\"action\": \"Updated\",\"status\": \"Started\" }},\"name\": \"{planName}\",\"clientRequestId\": \"ce636635-2b81-4981-a9d4-cec28fb5b014\",\"correlationRequestId\": \"61baa426-c91f-4e58-b9c6-d3852c4d88d\",\"requestId\": \"0a4d5b5e-7147-482f-8e21-4219aaacf62a\",\"address\": \"/subscriptions/ef90e930-9d7f-4a60-8a99-748e0eea69de/resourcegroups/egcanarytest/providers/Microsoft.Web/sites/egtestapp/restart?api-version=2016-03-01\",\"verb\": \"POST\"}},\"specversion\": \"1.0\",\"specversion\": \"1.0\"}}]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as WebAppServicePlanUpdatedEventData).Name, Is.EqualTo(planName));
        }
        #endregion

        #region Policy Insights
        [Test]
        public void ConsumeCloudEventPolicyInsightsPolicyStateChangedEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.PolicyInsights.PolicyStateChanged\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"timestamp\":\"2017-08-16T03:54:38.2696833Z\",  \"policyDefinitionId\":\"4c2359fe-001e-00ba-0e04-585868000000\",       \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"subscriptionId\":\"{subscription-id}\"   },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as PolicyInsightsPolicyStateChangedEventData).PolicyDefinitionId, Is.EqualTo("4c2359fe-001e-00ba-0e04-585868000000"));
        }

        [Test]
        public void ConsumeCloudEventPolicyInsightsPolicyStateCreatedEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.PolicyInsights.PolicyStateCreated\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"timestamp\":\"2017-08-16T03:54:38.2696833Z\",  \"policyDefinitionId\":\"4c2359fe-001e-00ba-0e04-585868000000\",       \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"subscriptionId\":\"{subscription-id}\"   },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as PolicyInsightsPolicyStateCreatedEventData).PolicyDefinitionId, Is.EqualTo("4c2359fe-001e-00ba-0e04-585868000000"));
        }

        [Test]
        public void ConsumeCloudEventPolicyInsightsPolicyStateDeletedEvent()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"type\":\"Microsoft.PolicyInsights.PolicyStateDeleted\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"timestamp\":\"2017-08-16T03:54:38.2696833Z\",  \"policyDefinitionId\":\"4c2359fe-001e-00ba-0e04-585868000000\",       \"httpRequest\":\"{request-operation}\",        \"resourceProvider\":\"Microsoft.EventGrid\",        \"resourceUri\":\"/subscriptions/{subscription-id}/resourceGroups/{resource-group}/providers/Microsoft.EventGrid/eventSubscriptions/LogicAppdd584bdf-8347-49c9-b9a9-d1f980783501\",    \"subscriptionId\":\"{subscription-id}\"   },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            Assert.That((eventData as PolicyInsightsPolicyStateDeletedEventData).PolicyDefinitionId, Is.EqualTo("4c2359fe-001e-00ba-0e04-585868000000"));
        }
        #endregion

        #region Communication events
        [Test]
        public void ConsumeCloudEventAcsRecordingFileStatusUpdatedEventData()
        {
            string requestContent = "[   {     \"source\":\"/subscriptions/{subscription-id}\",     \"subject\":\"/recording/call/{call-id}/recordingId/{recording-id}\",    \"type\":\"Microsoft.Communication.RecordingFileStatusUpdated\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"recordingStorageInfo\": { \"recordingChunks\": [ { \"documentId\": \"0-eus-d12-801b3f3fc462fe8a01e6810cbff729b8\", \"index\": 0, \"endReason\": \"SessionEnded\", \"contentLocation\": \"https://storage.asm.skype.com/v1/objects/0-eus-d12-801b3f3fc462fe8a01e6810cbff729b8/content/video\", \"metadataLocation\": \"https://storage.asm.skype.com/v1/objects/0-eus-d12-801b3f3fc462fe8a01e6810cbff729b8/content/acsmetadata\" }]}, \"recordingChannelType\": \"Mixed\", \"recordingContentType\": \"Audio\", \"recordingFormatType\": \"Mp3\"},   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var recordingEvent = eventData as AcsRecordingFileStatusUpdatedEventData;
            Assert.IsNotNull(recordingEvent);
            Assert.That(recordingEvent.ChannelType, Is.EqualTo(AcsRecordingChannelType.Mixed));
            Assert.That(recordingEvent.ContentType, Is.EqualTo(AcsRecordingContentType.Audio));
            Assert.That(recordingEvent.FormatType, Is.EqualTo(AcsRecordingFormatType.Mp3));

            // back compat
            Assert.That(recordingEvent.RecordingChannelType, Is.EqualTo(RecordingChannelType.Mixed));
            Assert.That(recordingEvent.RecordingContentType, Is.EqualTo(RecordingContentType.Audio));
            Assert.That(recordingEvent.RecordingFormatType, Is.EqualTo(RecordingFormatType.Mp3));
        }

        [Test]
        public void ConsumeCloudEventAcsEmailDeliveryReportReceivedEvent()
        {
            string requestContent = @"{
                ""id"": ""5f04f77c-2a6a-43bd-9b74-576a64c01f9e"",
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
                ""subject"": ""sender/test2@contoso.org/message/950850f5-bcdf-4315-b77a-6447cf56fac9"",
                ""data"": {
                    ""sender"": ""test2@contoso.org"",
                    ""recipient"": ""test1@contoso.com"",
                    ""messageId"": ""950850f5-bcdf-4315-b77a-6447cf56fac9"",
                    ""status"": ""delivered"",
                    ""deliveryStatusDetails"": {
                        ""statusMessage"": ""DestinationMailboxFull""
                    },
                    ""deliveryAttemptTimestamp"": ""2023-02-09T19:46:12.2480265+00:00""
                },
                ""type"": ""Microsoft.Communication.EmailDeliveryReportReceived"",
                ""time"": ""2023-02-09T19:46:12.2478002Z"",
                ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var emailEvent = eventData as AcsEmailDeliveryReportReceivedEventData;
            Assert.IsNotNull(emailEvent);
            Assert.That(emailEvent.Sender, Is.EqualTo("test2@contoso.org"));
            Assert.That(emailEvent.Recipient, Is.EqualTo("test1@contoso.com"));
            Assert.That(emailEvent.Status, Is.EqualTo(AcsEmailDeliveryReportStatus.Delivered));
            Assert.That(emailEvent.DeliveryStatusDetails.StatusMessage, Is.EqualTo("DestinationMailboxFull"));
            Assert.That(emailEvent.DeliveryAttemptTimestamp, Is.EqualTo(DateTimeOffset.Parse("2023-02-09T19:46:12.2480265+00:00")));
        }

        [Test]
        public void ConsumeCloudEventAcsIncomingCallEvent()
        {
            string requestContent = @"{
                ""id"": ""e80026e7-e298-46ba-bc42-dab0eda92581"",
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
                ""subject"": ""/caller/{caller-id}/recipient/{recipient-id}"",
                ""data"": {
                    ""to"": {
                        ""kind"": ""communicationUser"",
                        ""rawId"": ""{recipient-id}"",
                        ""communicationUser"": {
                            ""id"": ""{recipient-id}""
                        }
                    },
                    ""from"": {
                        ""kind"": ""communicationUser"",
                        ""rawId"": ""{caller-id}"",
                        ""communicationUser"": {
                            ""id"": ""{caller-id}""
                        }
                    },
                    ""serverCallId"": ""{server-call-id}"",
                    ""callerDisplayName"": ""VOIP Caller"",
                    ""customContext"": {
                        ""sipHeaders"": {
                            ""userToUser"": ""616d617a6f6e5f6368696;encoding=hex"",
                            ""X-MS-Custom-myheader1"": ""35567842"",
                            ""X-MS-Custom-myheader2"": ""customsipheadervalue""
                        },
                        ""voipHeaders"": {
                            ""customHeader"": ""customValue""
                        }
                    },
                    ""incomingCallContext"": ""{incoming-call-contextValue}"",
                    ""correlationId"": ""correlationId""
                },
                ""type"": ""Microsoft.Communication.IncomingCall"",
                ""specversion"": ""1.0"",
                ""time"": ""2023-04-04T17:18:42.5542219Z""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var incomingCallEvent = eventData as AcsIncomingCallEventData;
            Assert.IsNotNull(incomingCallEvent);
            Assert.That(incomingCallEvent.ToCommunicationIdentifier.CommunicationUser.Id, Is.EqualTo("{recipient-id}"));
            Assert.That(incomingCallEvent.FromCommunicationIdentifier.CommunicationUser.Id, Is.EqualTo("{caller-id}"));
            Assert.That(incomingCallEvent.CallerDisplayName, Is.EqualTo("VOIP Caller"));
            Assert.That(incomingCallEvent.CustomContext.SipHeaders["userToUser"], Is.EqualTo("616d617a6f6e5f6368696;encoding=hex"));
            Assert.That(incomingCallEvent.CustomContext.SipHeaders["X-MS-Custom-myheader1"], Is.EqualTo("35567842"));
            Assert.That(incomingCallEvent.CustomContext.SipHeaders["X-MS-Custom-myheader2"], Is.EqualTo("customsipheadervalue"));
            Assert.That(incomingCallEvent.CustomContext.VoipHeaders["customHeader"], Is.EqualTo("customValue"));
            Assert.That(incomingCallEvent.IncomingCallContext, Is.EqualTo("{incoming-call-contextValue}"));
            Assert.That(incomingCallEvent.CorrelationId, Is.EqualTo("correlationId"));
        }

        [Test]
        public void ConsumeCloudEventAcsRouterJobClassificationFailedEvent()
        {
            string requestContent = @"{
                ""id"": ""e80026e7-e298-46ba-bc42-dab0eda92581"",
                ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
                ""subject"": ""job/{job-id}/channel/{channel-id}/classificationpolicy/{classificationpolicy-id}"",
                  ""data"": {
                    ""errors"": [
                      {
                        ""code"": ""Failure"",
                        ""message"": ""Classification failed due to <reason>"",
                        ""target"": null,
                        ""innererror"": {
                                        ""code"": ""InnerFailure"",
                                        ""message"": ""Classification failed due to <reason>"",
                                        ""target"": null},
                        ""details"": []
                      }
                    ],
                    ""jobId"": ""7f1df17b-570b-4ae5-9cf5-fe6ff64cc712"",
                    ""channelReference"": ""test-abc"",
                    ""channelId"": ""FooVoiceChannelId"",
                    ""classificationPolicyId"": ""test-policy"",
                    ""labels"": {
                      ""Locale"": ""en-us"",
                      ""Segment"": ""Enterprise"",
                      ""Token"": ""FooToken""
                    },
                    ""tags"": {
                      ""Locale"": ""en-us"",
                      ""Segment"": ""Enterprise"",
                      ""Token"": ""FooToken""
                    }
                  },
                  ""type"": ""Microsoft.Communication.RouterJobClassificationFailed"",
                  ""specversion"": ""1.0"",
                  ""time"": ""2022-02-17T00:55:25.1736293Z""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            events[0].TryGetSystemEventData(out object eventData);
            var routerJobClassificationFailedEvent = eventData as AcsRouterJobClassificationFailedEventData;
            Assert.IsNotNull(routerJobClassificationFailedEvent);
            var errors = routerJobClassificationFailedEvent.Errors;
            Assert.That(errors.Count, Is.EqualTo(1));
            Assert.That(errors[0].Code, Is.EqualTo("Failure"));
            Assert.That(errors[0].Message, Is.EqualTo("Classification failed due to <reason>"));
            StringAssert.Contains("Inner Errors:", errors[0].ToString());
        }

        [Test]
        public void ConsumeCloudEventAcsRouterJobQueuedEvent()
        {
            string requestContent = @"{
              ""id"": ""b6d8687a-5a1a-42ae-b8b5-ff7ec338c872"",
              ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
              ""subject"": ""job/{job-id}/channel/{channel-id}/queue/{queue-id}"",
              ""data"": {
                ""jobId"": ""7f1df17b-570b-4ae5-9cf5-fe6ff64cc712"",
                ""channelReference"": ""test-abc"",
                ""channelId"": ""FooVoiceChannelId"",
                ""queueId"": ""625fec06-ab81-4e60-b780-f364ed96ade1"",
                ""priority"": 1,
                ""labels"": {
                  ""Locale"": ""en-us"",
                  ""Segment"": ""Enterprise"",
                  ""Token"": ""FooToken""
                },
                ""tags"": {
                  ""Locale"": ""en-us"",
                  ""Segment"": ""Enterprise"",
                  ""Token"": ""FooToken""
                },
                ""requestedWorkerSelectors"": [
                  {
                    ""key"": ""string"",
                    ""labelOperator"": ""equal"",
                    ""value"": 5,
                    ""ttlSeconds"": 1000
                  }
                ],
                ""attachedWorkerSelectors"": [
                  {
                    ""key"": ""string"",
                    ""labelOperator"": ""equal"",
                    ""value"": 5,
                    ""ttlSeconds"": 1000,
                    ""state"": ""active""
                  }
                ]
              },
              ""type"": ""Microsoft.Communication.RouterJobQueued"",
              ""specversion"": ""1.0"",
              ""time"": ""2022-02-17T00:55:25.1736293Z""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            events[0].TryGetSystemEventData(out object eventData);
            var routerJobQueuedEventData = eventData as AcsRouterJobQueuedEventData;
            Assert.IsNotNull(routerJobQueuedEventData);
            var selectors = routerJobQueuedEventData.AttachedWorkerSelectors;
            Assert.That(selectors.Count, Is.EqualTo(1));
            Assert.That(selectors[0].TimeToLive, Is.EqualTo(TimeSpan.FromSeconds(1000)));
            Assert.That(selectors[0].LabelOperator, Is.EqualTo(Azure.Messaging.EventGrid.Models.AcsRouterLabelOperator.Equal));
            Assert.That(selectors[0].Operator, Is.EqualTo(Azure.Messaging.EventGrid.SystemEvents.AcsRouterLabelOperator.Equal));

            Assert.That(selectors[0].State, Is.EqualTo(Azure.Messaging.EventGrid.Models.AcsRouterWorkerSelectorState.Active));
            Assert.That(selectors[0].SelectorState, Is.EqualTo(Azure.Messaging.EventGrid.SystemEvents.AcsRouterWorkerSelectorState.Active));
        }

        [Test]
        public void ConsumeCloudEventAcsRouterJobReceivedEvent()
        {
            string requestContent = @"{
              ""id"": ""acdf8fa5-8ab4-4a65-874a-c1d2a4a97f2e"",
              ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{group-name}/providers/Microsoft.Communication/communicationServices/{communication-services-resource-name}"",
              ""subject"": ""job/{job-id}/channel/{channel-id}"",
              ""data"": {
                ""jobId"": ""7f1df17b-570b-4ae5-9cf5-fe6ff64cc712"",
                ""channelReference"": ""test-abc"",
                ""jobStatus"": ""PendingClassification"",
                ""channelId"": ""FooVoiceChannelId"",
                ""classificationPolicyId"": ""test-policy"",
                ""queueId"": ""queue-id"",
                ""priority"": 0,
                ""labels"": {
                  ""Locale"": ""en-us"",
                  ""Segment"": ""Enterprise"",
                  ""Token"": ""FooToken""
                },
                ""tags"": {
                  ""Locale"": ""en-us"",
                  ""Segment"": ""Enterprise"",
                  ""Token"": ""FooToken""
                },
                ""requestedWorkerSelectors"": [
                  {
                    ""key"": ""string"",
                    ""labelOperator"": ""equal"",
                    ""value"": 5,
                    ""ttlSeconds"": 36
                  }
                ],
                ""scheduledOn"": ""3/28/2007 7:13:50 PM +00:00"",
                ""unavailableForMatching"": false
              },
              ""type"": ""Microsoft.Communication.RouterJobReceived"",
              ""specversion"": ""1.0"",
              ""time"": ""2022-02-17T00:55:25.1736293Z""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            events[0].TryGetSystemEventData(out object eventData);
            var routerJobReceivedEventData = eventData as AcsRouterJobReceivedEventData;
            Assert.IsNotNull(routerJobReceivedEventData);
            Assert.That(routerJobReceivedEventData.JobStatus, Is.EqualTo(Azure.Messaging.EventGrid.Models.AcsRouterJobStatus.PendingClassification));
            Assert.That(routerJobReceivedEventData.Status, Is.EqualTo(Azure.Messaging.EventGrid.SystemEvents.AcsRouterJobStatus.PendingClassification));
        }
        #endregion

        #region Health Data Services events
        [Test]
        public void ConsumeCloudEventFhirResourceCreatedEvent()
        {
            string requestContent = "[   { \"source\": \"/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}\", \"subject\":\"{fhir-account}.fhir.azurehealthcareapis.com/Patient/e0a1f743-1a70-451f-830e-e96477163902\",    \"type\":\"Microsoft.HealthcareApis.FhirResourceCreated\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"resourceType\": \"Patient\",  \"resourceFhirAccount\": \"{fhir-account}.fhir.azurehealthcareapis.com\", \"resourceFhirId\": \"e0a1f743-1a70-451f-830e-e96477163902\", \"resourceVersionId\": 1 },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareFhirResourceCreatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.FhirResourceType, Is.EqualTo(HealthcareFhirResourceType.Patient));
            Assert.That(healthEvent.FhirServiceHostName, Is.EqualTo("{fhir-account}.fhir.azurehealthcareapis.com"));
            Assert.That(healthEvent.FhirResourceId, Is.EqualTo("e0a1f743-1a70-451f-830e-e96477163902"));
            Assert.That(healthEvent.FhirResourceVersionId, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeCloudEventFhirResourceUpdatedEvent()
        {
            string requestContent = "[   { \"source\": \"/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}\", \"subject\":\"{fhir-account}.fhir.azurehealthcareapis.com/Patient/e0a1f743-1a70-451f-830e-e96477163902\",    \"type\":\"Microsoft.HealthcareApis.FhirResourceUpdated\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"resourceType\": \"Patient\",  \"resourceFhirAccount\": \"{fhir-account}.fhir.azurehealthcareapis.com\", \"resourceFhirId\": \"e0a1f743-1a70-451f-830e-e96477163902\", \"resourceVersionId\": 1 },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareFhirResourceUpdatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.FhirResourceType, Is.EqualTo(HealthcareFhirResourceType.Patient));
            Assert.That(healthEvent.FhirServiceHostName, Is.EqualTo("{fhir-account}.fhir.azurehealthcareapis.com"));
            Assert.That(healthEvent.FhirResourceId, Is.EqualTo("e0a1f743-1a70-451f-830e-e96477163902"));
            Assert.That(healthEvent.FhirResourceVersionId, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeCloudEventFhirResourceDeletedEvent()
        {
            string requestContent = "[   { \"source\": \"/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}\", \"subject\":\"{fhir-account}.fhir.azurehealthcareapis.com/Patient/e0a1f743-1a70-451f-830e-e96477163902\",    \"type\":\"Microsoft.HealthcareApis.FhirResourceDeleted\",    \"time\":\"2017-08-16T03:54:38.2696833Z\",    \"id\":\"25b3b0d0-d79b-44d5-9963-440d4e6a9bba\",    \"data\": { \"resourceType\": \"Patient\",  \"resourceFhirAccount\": \"{fhir-account}.fhir.azurehealthcareapis.com\", \"resourceFhirId\": \"e0a1f743-1a70-451f-830e-e96477163902\", \"resourceVersionId\": 1 },   \"specversion\": \"1.0\"  }]";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareFhirResourceDeletedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.FhirResourceType, Is.EqualTo(HealthcareFhirResourceType.Patient));
            Assert.That(healthEvent.FhirServiceHostName, Is.EqualTo("{fhir-account}.fhir.azurehealthcareapis.com"));
            Assert.That(healthEvent.FhirResourceId, Is.EqualTo("e0a1f743-1a70-451f-830e-e96477163902"));
            Assert.That(healthEvent.FhirResourceVersionId, Is.EqualTo(1));
        }

        [Test]
        public void ConsumeCloudEventDicomImageCreatedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}"",
            ""subject"": ""{dicom-account}.dicom.azurehealthcareapis.com/v1/studies/1.2.3.4.3/series/1.2.3.4.3.9423673/instances/1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
            ""type"": ""Microsoft.HealthcareApis.DicomImageCreated"",
            ""time"": ""2022-09-15T01:14:04.5613214Z"",
            ""id"": ""d621839d-958b-4142-a638-bb966b4f7dfd"",
            ""data"": {
                ""partitionName"": ""Microsoft.Default"",
                ""imageStudyInstanceUid"": ""1.2.3.4.3"",
                ""imageSeriesInstanceUid"": ""1.2.3.4.3.9423673"",
                ""imageSopInstanceUid"": ""1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
                ""serviceHostName"": ""{dicom-account}.dicom.azurehealthcareapis.com"",
                ""sequenceNumber"": 1
            },
            ""specversion"": ""1.0""
        }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareDicomImageCreatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.ImageStudyInstanceUid, Is.EqualTo("1.2.3.4.3"));
            Assert.That(healthEvent.ImageSeriesInstanceUid, Is.EqualTo("1.2.3.4.3.9423673"));
            Assert.That(healthEvent.ImageSopInstanceUid, Is.EqualTo("1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"));
            Assert.That(healthEvent.SequenceNumber, Is.EqualTo(1));
            Assert.That(healthEvent.PartitionName, Is.EqualTo("Microsoft.Default"));
        }

        [Test]
        public void ConsumeCloudEventDicomImageUpdatedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}"",
            ""subject"": ""{dicom-account}.dicom.azurehealthcareapis.com/v1/studies/1.2.3.4.3/series/1.2.3.4.3.9423673/instances/1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
            ""type"": ""Microsoft.HealthcareApis.DicomImageUpdated"",
            ""time"": ""2022-09-15T01:14:04.5613214Z"",
            ""id"": ""d621839d-958b-4142-a638-bb966b4f7dfd"",
            ""data"": {
                ""partitionName"": ""Microsoft.Default"",
                ""imageStudyInstanceUid"": ""1.2.3.4.3"",
                ""imageSeriesInstanceUid"": ""1.2.3.4.3.9423673"",
                ""imageSopInstanceUid"": ""1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
                ""serviceHostName"": ""{dicom-account}.dicom.azurehealthcareapis.com"",
                ""sequenceNumber"": 1
            },
            ""specversion"": ""1.0""
        }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareDicomImageUpdatedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.ImageStudyInstanceUid, Is.EqualTo("1.2.3.4.3"));
            Assert.That(healthEvent.ImageSeriesInstanceUid, Is.EqualTo("1.2.3.4.3.9423673"));
            Assert.That(healthEvent.ImageSopInstanceUid, Is.EqualTo("1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"));
            Assert.That(healthEvent.SequenceNumber, Is.EqualTo(1));
            Assert.That(healthEvent.PartitionName, Is.EqualTo("Microsoft.Default"));
        }

        [Test]
        public void ConsumeCloudEventDicomImageDeletedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{resource-group-name}/providers/Microsoft.HealthcareApis/workspaces/{workspace-name}"",
            ""subject"": ""{dicom-account}.dicom.azurehealthcareapis.com/v1/studies/1.2.3.4.3/series/1.2.3.4.3.9423673/instances/1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
            ""type"": ""Microsoft.HealthcareApis.DicomImageDeleted"",
            ""time"": ""2022-09-15T01:14:04.5613214Z"",
            ""id"": ""d621839d-958b-4142-a638-bb966b4f7dfd"",
            ""data"": {
                ""partitionName"": ""Microsoft.Default"",
                ""imageStudyInstanceUid"": ""1.2.3.4.3"",
                ""imageSeriesInstanceUid"": ""1.2.3.4.3.9423673"",
                ""imageSopInstanceUid"": ""1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"",
                ""serviceHostName"": ""{dicom-account}.dicom.azurehealthcareapis.com"",
                ""sequenceNumber"": 1
            },
            ""specversion"": ""1.0""
        }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var healthEvent = eventData as HealthcareDicomImageDeletedEventData;
            Assert.IsNotNull(healthEvent);
            Assert.That(healthEvent.ImageStudyInstanceUid, Is.EqualTo("1.2.3.4.3"));
            Assert.That(healthEvent.ImageSeriesInstanceUid, Is.EqualTo("1.2.3.4.3.9423673"));
            Assert.That(healthEvent.ImageSopInstanceUid, Is.EqualTo("1.3.6.1.4.1.45096.2.296485376.2210.1633373143.864442"));
            Assert.That(healthEvent.SequenceNumber, Is.EqualTo(1));
            Assert.That(healthEvent.PartitionName, Is.EqualTo("Microsoft.Default"));
        }
        #endregion

        #region APIM
        [Test]
        public void ConsumeCloudEventGatewayApiAddedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}"",
            ""subject"": ""/gateways/{gateway-name}/apis/example-api"",
            ""type"": ""Microsoft.ApiManagement.GatewayAPIAdded"",
            ""time"": ""2021-07-02T00:47:47.8536532Z"",
            ""id"": ""92c502f2-a966-42a7-a428-d3b319844544"",
            ""data"": {
                ""resourceUri"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api""
            },
            ""specversion"": ""1.0""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var apimEvent = eventData as ApiManagementGatewayApiAddedEventData;
            Assert.IsNotNull(apimEvent);
            Assert.That(apimEvent.ResourceUri, Is.EqualTo("/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api"));
        }

        [Test]
        public void ConsumeCloudEventGatewayApiRemovedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}"",
            ""subject"": ""/gateways/{gateway-name}/apis/example-api"",
            ""type"": ""Microsoft.ApiManagement.GatewayAPIRemoved"",
            ""time"": ""2021-07-02T00:47:47.8536532Z"",
            ""id"": ""92c502f2-a966-42a7-a428-d3b319844544"",
            ""data"": {
                ""resourceUri"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api""
            },
            ""specversion"": ""1.0""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var apimEvent = eventData as ApiManagementGatewayApiRemovedEventData;
            Assert.IsNotNull(apimEvent);
            Assert.That(apimEvent.ResourceUri, Is.EqualTo("/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api"));
        }

        [Test]
        public void ConsumeCloudEventCertificateAuthorityCreatedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}"",
            ""subject"": ""/gateways/{gateway-name}/apis/example-api"",
            ""type"": ""Microsoft.ApiManagement.GatewayCertificateAuthorityCreated"",
            ""time"": ""2021-07-02T00:47:47.8536532Z"",
            ""id"": ""92c502f2-a966-42a7-a428-d3b319844544"",
            ""data"": {
                ""resourceUri"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api""
            },
            ""specversion"": ""1.0""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var apimEvent = eventData as ApiManagementGatewayCertificateAuthorityCreatedEventData;
            Assert.IsNotNull(apimEvent);
            Assert.That(apimEvent.ResourceUri, Is.EqualTo("/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api"));
        }

        [Test]
        public void ConsumeCloudEventCertificateAuthorityDeletedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}"",
            ""subject"": ""/gateways/{gateway-name}/apis/example-api"",
            ""type"": ""Microsoft.ApiManagement.GatewayCertificateAuthorityDeleted"",
            ""time"": ""2021-07-02T00:47:47.8536532Z"",
            ""id"": ""92c502f2-a966-42a7-a428-d3b319844544"",
            ""data"": {
                ""resourceUri"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api""
            },
            ""specversion"": ""1.0""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var apimEvent = eventData as ApiManagementGatewayCertificateAuthorityDeletedEventData;
            Assert.IsNotNull(apimEvent);
            Assert.That(apimEvent.ResourceUri, Is.EqualTo("/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api"));
        }

        [Test]
        public void ConsumeCloudEventCertificateAuthorityUpdatedEvent()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}"",
            ""subject"": ""/gateways/{gateway-name}/apis/example-api"",
            ""type"": ""Microsoft.ApiManagement.GatewayCertificateAuthorityUpdated"",
            ""time"": ""2021-07-02T00:47:47.8536532Z"",
            ""id"": ""92c502f2-a966-42a7-a428-d3b319844544"",
            ""data"": {
                ""resourceUri"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api""
            },
            ""specversion"": ""1.0""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var apimEvent = eventData as ApiManagementGatewayCertificateAuthorityUpdatedEventData;
            Assert.IsNotNull(apimEvent);
            Assert.That(apimEvent.ResourceUri, Is.EqualTo("/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.ApiManagement/service/{your-APIM-instance}/gateways/{gateway-name}/apis/example-api"));
        }
        #endregion

        #region DataBox

        [Test]
        public void ConsumeCloudEventDataBoxCopyCompleted()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.DataBox/jobs/{your-resource}"",
            ""subject"": ""/jobs/{your-resource}"",
            ""type"": ""Microsoft.DataBox.CopyCompleted"",
            ""time"": ""2022-10-16T02:51:26.4248221Z"",
            ""id"": ""759c892a-a628-4e48-a116-2e1d54c555ce"",
            ""data"": {
                ""serialNumber"": ""SampleSerialNumber"",
                ""stageName"": ""CopyCompleted"",
                ""stageTime"": ""2022-10-12T19:38:08.0218897Z""
            },
            ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var dataBoxEvent = eventData as DataBoxCopyCompletedEventData;
            Assert.IsNotNull(dataBoxEvent);
            Assert.That(dataBoxEvent.SerialNumber, Is.EqualTo("SampleSerialNumber"));
            Assert.That(dataBoxEvent.StageName, Is.EqualTo(DataBoxStageName.CopyCompleted));
            Assert.That(dataBoxEvent.StageTime, Is.EqualTo(DateTimeOffset.Parse("2022-10-12T19:38:08.0218897Z")));
        }

        [Test]
        public void ConsumeCloudEventDataBoxCopyStarted()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.DataBox/jobs/{your-resource}"",
            ""subject"": ""/jobs/{your-resource}"",
            ""type"": ""Microsoft.DataBox.CopyStarted"",
            ""time"": ""2022-10-16T02:51:26.4248221Z"",
            ""id"": ""759c892a-a628-4e48-a116-2e1d54c555ce"",
            ""data"": {
                ""serialNumber"": ""SampleSerialNumber"",
                ""stageName"": ""CopyStarted"",
                ""stageTime"": ""2022-10-12T19:38:08.0218897Z""
            },
            ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var dataBoxEvent = eventData as DataBoxCopyStartedEventData;
            Assert.IsNotNull(dataBoxEvent);
            Assert.That(dataBoxEvent.SerialNumber, Is.EqualTo("SampleSerialNumber"));
            Assert.That(dataBoxEvent.StageName, Is.EqualTo(DataBoxStageName.CopyStarted));
            Assert.That(dataBoxEvent.StageTime, Is.EqualTo(DateTimeOffset.Parse("2022-10-12T19:38:08.0218897Z")));
        }

        [Test]
        public void ConsumeCloudEventDataBoxOrderCompleted()
        {
            string requestContent = @"{
            ""source"": ""/subscriptions/{subscription-id}/resourceGroups/{your-rg}/providers/Microsoft.DataBox/jobs/{your-resource}"",
            ""subject"": ""/jobs/{your-resource}"",
            ""type"": ""Microsoft.DataBox.OrderCompleted"",
            ""time"": ""2022-10-16T02:51:26.4248221Z"",
            ""id"": ""759c892a-a628-4e48-a116-2e1d54c555ce"",
            ""data"": {
                ""serialNumber"": ""SampleSerialNumber"",
                ""stageName"": ""OrderCompleted"",
                ""stageTime"": ""2022-10-12T19:38:08.0218897Z""
            },
            ""specversion"": ""1.0""
            }";

            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var dataBoxEvent = eventData as DataBoxOrderCompletedEventData;
            Assert.IsNotNull(dataBoxEvent);
            Assert.That(dataBoxEvent.SerialNumber, Is.EqualTo("SampleSerialNumber"));
            Assert.That(dataBoxEvent.StageName, Is.EqualTo(DataBoxStageName.OrderCompleted));
            Assert.That(dataBoxEvent.StageTime, Is.EqualTo(DateTimeOffset.Parse("2022-10-12T19:38:08.0218897Z")));
        }
        #endregion
        #region Resource Notifications

        [Test]
        public void ConsumeCloudEventHealthResourcesAvailiabilityStatusChangedEvent()
        {
            string requestContent = @"{
              ""id"": ""1fb6fa94-d965-4306-abeq-4810f0774e97"",
              ""source"": ""/subscriptions/{subscription-id}"",
              ""subject"": ""/subscriptions/{subscription-id}/resourceGroups/{rg-name}/providers/Microsoft.Compute/virtualMachines/{vm-name}"",
              ""data"": {
                ""resourceInfo"": {
                  ""id"": ""/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Compute/virtualMachines/{vm-name}/providers/Microsoft.ResourceHealth/availabilityStatuses/{event-id}"",
                  ""name"": ""{event-id}"",
                  ""type"": ""Microsoft.ResourceHealth/availabilityStatuses"",
                  ""properties"": {
                    ""targetResourceId"": ""/subscriptions/{subscription-id}/resourceGroups/{rg-name}/providers/Microsoft.Compute/virtualMachines/{vm-name}"",
                    ""targetResourceType"": ""Microsoft.Compute/virtualMachines"",
                    ""occurredTime"": ""2023-07-24T19:20:37.9245071Z"",
                    ""previousAvailabilityState"": ""Unavailable"",
                    ""availabilityState"": ""Available""
                  }
                },
                ""operationalInfo"": {
                  ""resourceEventTime"": ""2023-07-24T19:20:37.9245071Z""
                },
                ""apiVersion"": ""2023-12-01""
              },
              ""type"": ""Microsoft.ResourceNotifications.HealthResources.AvailabilityStatusChanged"",
              ""specversion"": ""1.0"",
              ""time"": ""2023-07-24T19:20:37.9245071Z""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var availabilityStatusChangedEventData = eventData as ResourceNotificationsHealthResourcesAvailabilityStatusChangedEventData;
            Assert.IsNotNull(availabilityStatusChangedEventData);
            Assert.That(availabilityStatusChangedEventData.ResourceDetails.Name, Is.EqualTo("{event-id}"));
            Assert.That(
                availabilityStatusChangedEventData.ResourceDetails.Id,
                Is.EqualTo("/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Compute/virtualMachines/{vm-name}/providers/Microsoft.ResourceHealth/availabilityStatuses/{event-id}"));
            Assert.That(
                availabilityStatusChangedEventData.ResourceDetails.Resource.ToString(),
                Is.EqualTo("/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Compute/virtualMachines/{vm-name}/providers/Microsoft.ResourceHealth/availabilityStatuses/{event-id}"));
        }

        [Test]
        public void ConsumeCloudEventResourceDeletedEvent()
        {
            string requestContent = @"{
              ""id"": ""d4611260-d179-4f86-b196-3a9d4128be2d"",
              ""source"": ""/subscriptions/{subscription-id}"",
              ""subject"": ""/subscriptions/{subscription-id}/resourceGroups/{rg-name}/providers/Microsoft.Storage/storageAccounts/{storageAccount-name}"",
              ""data"": {
                ""resourceInfo"": {
                  ""id"": ""/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Storage/storageAccounts/{storageAccount-name}"",
                  ""name"": ""storageAccount-name"",
                  ""type"": ""Microsoft.Storage/storageAccounts""
                },
                ""operationalInfo"": {
                  ""resourceEventTime"": ""2023-07-28T20:11:36.6347858Z""
                }
              },
              ""type"": ""Microsoft.ResourceNotifications.Resources.Deleted"",
              ""specversion"": ""1.0"",
              ""time"": ""2023-07-28T20:11:36.6347858Z""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var resourceDeletedEventData = eventData as ResourceNotificationsResourceManagementDeletedEventData;
            Assert.IsNotNull(resourceDeletedEventData);
            Assert.That(resourceDeletedEventData.ResourceDetails.Resource.Name, Is.EqualTo("{storageAccount-name}"));
            Assert.That(
                resourceDeletedEventData.ResourceDetails.Resource.ToString(),
                Is.EqualTo("/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Storage/storageAccounts/{storageAccount-name}"));
        }

        [Test]
        public void ConsumeCloudEventResourceCreatedOrUpdatedEvent()
        {
            string requestContent = @"{
              ""id"": ""4eef929a-a65c-47dd-93e2-46b8c17c6c17"",
              ""source"": ""/subscriptions/{subscription-id}"",
              ""subject"": ""/subscriptions/{subscription-id}/resourceGroups/{rg-name}/providers/Microsoft.Storage/storageAccounts/{storageAccount-name}"",
              ""data"": {
                ""resourceInfo"": {
                  ""tags"": {},
                  ""id"": ""/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Storage/storageAccounts/{storageAccount-name}"",
                  ""name"": ""StorageAccount-name"",
                  ""type"": ""Microsoft.Storage/storageAccounts"",
                  ""location"": ""eastus"",
                  ""properties"": {
                    ""privateEndpointConnections"": [],
                    ""minimumTlsVersion"": ""TLS1_2"",
                    ""allowBlobPublicAccess"": 1,
                    ""allowSharedKeyAccess"": 1,
                    ""networkAcls"": {
                      ""bypass"": ""AzureServices"",
                      ""virtualNetworkRules"": [],
                      ""ipRules"": [],
                      ""defaultAction"": ""Allow""
                    },
                    ""supportsHttpsTrafficOnly"": 1,
                    ""encryption"": {
                      ""requireInfrastructureEncryption"": 0,
                      ""services"": {
                        ""file"": {
                          ""keyType"": ""Account"",
                          ""enabled"": 1,
                          ""lastEnabledTime"": ""2023-07-28T20:12:50.6380308Z""
                        },
                        ""blob"": {
                          ""keyType"": ""Account"",
                          ""enabled"": 1,
                          ""lastEnabledTime"": ""2023-07-28T20:12:50.6380308Z""
                        }
                      },
                      ""keySource"": ""Microsoft.Storage""
                    },
                    ""accessTier"": ""Hot"",
                    ""provisioningState"": ""Succeeded"",
                    ""creationTime"": ""2023-07-28T20:12:50.4661564Z"",
                    ""primaryEndpoints"": {
                      ""dfs"": ""https://{storageAccount-name}.dfs.core.windows.net/"",
                      ""web"": ""https://{storageAccount-name}.z13.web.core.windows.net/"",
                      ""blob"": ""https://{storageAccount-name}.blob.core.windows.net/"",
                      ""queue"": ""https://{storageAccount-name}.queue.core.windows.net/"",
                      ""table"": ""https://{storageAccount-name}.table.core.windows.net/"",
                      ""file"": ""https://{storageAccount-name}.file.core.windows.net/""
                    },
                    ""primaryLocation"": ""eastus"",
                    ""statusOfPrimary"": ""available"",
                    ""secondaryLocation"": ""westus"",
                    ""statusOfSecondary"": ""available"",
                    ""secondaryEndpoints"": {
                      ""dfs"": ""https://{storageAccount-name} -secondary.dfs.core.windows.net/"",
                      ""web"": ""https://{storageAccount-name}-secondary.z13.web.core.windows.net/"",
                      ""blob"": ""https://{storageAccount-name}-secondary.blob.core.windows.net/"",
                      ""queue"": ""https://{storageAccount-name}-secondary.queue.core.windows.net/"",
                      ""table"": ""https://{storageAccount-name}-secondary.table.core.windows.net/""
                    }
                  }
                },
                ""operationalInfo"": {
                  ""resourceEventTime"": ""2023-07-28T20:13:10.8418063Z""
                },
                ""apiVersion"": ""2019-06-01""
              },
              ""type"": ""Microsoft.ResourceNotifications.Resources.CreatedOrUpdated"",
              ""specversion"": ""1.0"",
              ""time"": ""2023-07-28T20:13:10.8418063Z""
            }";
            CloudEvent[] events = CloudEvent.ParseMany(new BinaryData(requestContent));

            Assert.NotNull(events);
            Assert.That(events[0].TryGetSystemEventData(out object eventData), Is.True);
            var resourceDeletedEventData = eventData as ResourceNotificationsResourceManagementCreatedOrUpdatedEventData;
            Assert.IsNotNull(resourceDeletedEventData);
            Assert.That(resourceDeletedEventData.ResourceDetails.Resource.Name, Is.EqualTo("{storageAccount-name}"));
            Assert.That(
                resourceDeletedEventData.ResourceDetails.Resource.ToString(),
                Is.EqualTo("/subscriptions/319a9601-1ec0-0000-aebc-8fe82724c81e/resourceGroups/{rg-name}/providers/Microsoft.Storage/storageAccounts/{storageAccount-name}"));
        }
        #endregion
        #endregion
    }
}
