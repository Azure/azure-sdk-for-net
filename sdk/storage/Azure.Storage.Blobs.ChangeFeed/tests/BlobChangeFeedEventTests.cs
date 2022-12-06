// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Internal.Avro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class BlobChangeFeedEventTests : ChangeFeedTestBase
    {
        public BlobChangeFeedEventTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void SchemaV1Test()
        {
            // Arrange
            string rawText = File.ReadAllText(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"EventSchemaV1.json"}");

            Dictionary<string, object> rawDictionary = DeserializeEvent(rawText);

            // Act
            BlobChangeFeedEvent changeFeedEvent = new BlobChangeFeedEvent(rawDictionary);

            // Assert
            Assert.AreEqual(
                1,
                changeFeedEvent.SchemaVersion);
            Assert.AreEqual(
                "/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV",
                changeFeedEvent.Topic);
            Assert.AreEqual(
                "/blobServices/default/containers/apitestcontainerver/blobs/20220217_125928329_Blob_oaG6iu7ImEB1cX8M",
                changeFeedEvent.Subject);
            Assert.AreEqual(
                BlobChangeFeedEventType.BlobCreated,
                changeFeedEvent.EventType);
            Assert.AreEqual(
                DateTimeOffset.Parse("2022-02-17T12:59:41.4003102Z"),
                changeFeedEvent.EventTime);
            Assert.AreEqual(
                Guid.Parse("322343e3-8020-0000-00fe-233467066726"),
                changeFeedEvent.Id);
            Assert.AreEqual(
                BlobOperationName.PutBlob,
                changeFeedEvent.EventData.BlobOperationName);
            Assert.AreEqual(
                "f0270546-168e-4398-8fa8-107a1ac214d2",
                changeFeedEvent.EventData.ClientRequestId);
            Assert.AreEqual(
                Guid.Parse("322343e3-8020-0000-00fe-233467000000"),
                changeFeedEvent.EventData.RequestId);
            Assert.AreEqual(
                new ETag("0x8D9F2155CBF7928"),
                changeFeedEvent.EventData.ETag);
            Assert.AreEqual(
                "application/octet-stream",
                changeFeedEvent.EventData.ContentType);
            Assert.AreEqual(
                128,
                changeFeedEvent.EventData.ContentLength);
            Assert.AreEqual(
                BlobType.Block,
                changeFeedEvent.EventData.BlobType);
            Assert.AreEqual(
                new Uri("https://www.myurl.com"),
                changeFeedEvent.EventData.Uri);
            Assert.AreEqual(
                "00000000000000010000000000000002000000000000001d",
                changeFeedEvent.EventData.Sequencer);
        }

        [Test]
        public void SchemaV3Test()
        {
            // Arrange
            string rawText = File.ReadAllText(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"EventSchemaV3.json"}");

            Dictionary<string, object> rawDictionary = DeserializeEvent(rawText);

            // Act
            BlobChangeFeedEvent changeFeedEvent = new BlobChangeFeedEvent(rawDictionary);

            // Assert
            Assert.AreEqual(
                3,
                changeFeedEvent.SchemaVersion);
            Assert.AreEqual(
                "/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV",
                changeFeedEvent.Topic);
            Assert.AreEqual(
                "/blobServices/default/containers/apitestcontainerver/blobs/20220217_130510699_Blob_oaG6iu7ImEB1cX8M",
                changeFeedEvent.Subject);
            Assert.AreEqual(
                BlobChangeFeedEventType.BlobCreated,
                changeFeedEvent.EventType);
            Assert.AreEqual(
                DateTimeOffset.Parse("2022-02-17T13:05:19.6798242Z"),
                changeFeedEvent.EventTime);
            Assert.AreEqual(
                Guid.Parse("eefe8fc8-8020-0000-00fe-23346706daaa"),
                changeFeedEvent.Id);
            Assert.AreEqual(
                BlobOperationName.PutBlob,
                changeFeedEvent.EventData.BlobOperationName);
            Assert.AreEqual(
                "00c0b6b7-bb67-4748-a3dc-86464863d267",
                changeFeedEvent.EventData.ClientRequestId);
            Assert.AreEqual(
                Guid.Parse("eefe8fc8-8020-0000-00fe-233467000000"),
                changeFeedEvent.EventData.RequestId);
            Assert.AreEqual(
                new ETag("0x8D9F216266170DC"),
                changeFeedEvent.EventData.ETag);
            Assert.AreEqual(
                "application/octet-stream",
                changeFeedEvent.EventData.ContentType);
            Assert.AreEqual(
                128,
                changeFeedEvent.EventData.ContentLength);
            Assert.AreEqual(
                BlobType.Block,
                changeFeedEvent.EventData.BlobType);
            Assert.AreEqual(
                new Uri("https://www.myurl.com"),
                changeFeedEvent.EventData.Uri);
            Assert.AreEqual(
                "00000000000000010000000000000002000000000000001d",
                changeFeedEvent.EventData.Sequencer);

            Assert.AreEqual("2022-02-17T13:08:42.4825913Z", changeFeedEvent.EventData.PreviousInfo.SoftDeleteSnapshot);
            Assert.IsTrue(changeFeedEvent.EventData.PreviousInfo.WasBlobSoftDeleted);
            Assert.AreEqual("2024-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo.NewBlobVersion);
            Assert.AreEqual("2022-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo.OldBlobVersion);
            Assert.AreEqual(AccessTier.Hot, changeFeedEvent.EventData.PreviousInfo.PreviousTier);

            Assert.AreEqual(
                "2022-02-17T16:09:16.7261278Z",
                changeFeedEvent.EventData.Snapshot);

            Assert.AreEqual(6, changeFeedEvent.EventData.UpdatedBlobProperties.Count);

            Assert.AreEqual("ContentLanguage", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName);
            Assert.AreEqual("pl-Pl", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue);
            Assert.AreEqual("nl-NL", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].OldValue);

            Assert.AreEqual("CacheControl", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName);
            Assert.AreEqual("max-age=100", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue);
            Assert.AreEqual("max-age=99", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].OldValue);

            Assert.AreEqual("ContentEncoding", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName);
            Assert.AreEqual("gzip, identity", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue);
            Assert.AreEqual("gzip", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].OldValue);

            Assert.AreEqual("ContentMD5", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName);
            Assert.AreEqual("Q2h1Y2sgSW51ZwDIAXR5IQ==", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue);
            Assert.AreEqual("Q2h1Y2sgSW=", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].OldValue);

            Assert.AreEqual("ContentDisposition", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName);
            Assert.AreEqual("attachment", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue);
            Assert.AreEqual("", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].OldValue);

            Assert.AreEqual("ContentType", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName);
            Assert.AreEqual("application/json", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue);
            Assert.AreEqual("application/octet-stream", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].OldValue);
        }

        [Test]
        public void SchemaV4Test()
        {
            // Arrange
            string rawText = File.ReadAllText(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"EventSchemaV4.json"}");

            Dictionary<string, object> rawDictionary = DeserializeEvent(rawText);

            // Act
            BlobChangeFeedEvent changeFeedEvent = new BlobChangeFeedEvent(rawDictionary);

            // Assert
            Assert.AreEqual(
                4,
                changeFeedEvent.SchemaVersion);
            Assert.AreEqual(
                "/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV",
                changeFeedEvent.Topic);
            Assert.AreEqual(
                "/blobServices/default/containers/apitestcontainerver/blobs/20220217_130833395_Blob_oaG6iu7ImEB1cX8M",
                changeFeedEvent.Subject);
            Assert.AreEqual(
                BlobChangeFeedEventType.BlobCreated,
                changeFeedEvent.EventType);
            Assert.AreEqual(
                DateTimeOffset.Parse("2022-02-17T13:08:42.4835902Z"),
                changeFeedEvent.EventTime);
            Assert.AreEqual(
                Guid.Parse("ca76bce1-8020-0000-00ff-23346706e769"),
                changeFeedEvent.Id);
            Assert.AreEqual(
                BlobOperationName.PutBlob,
                changeFeedEvent.EventData.BlobOperationName);
            Assert.AreEqual(
                "58fbfee9-6cf5-4096-9666-c42980beee65",
                changeFeedEvent.EventData.ClientRequestId);
            Assert.AreEqual(
                Guid.Parse("ca76bce1-8020-0000-00ff-233467000000"),
                changeFeedEvent.EventData.RequestId);
            Assert.AreEqual(
                new ETag("0x8D9F2169F42D701"),
                changeFeedEvent.EventData.ETag);
            Assert.AreEqual(
                "application/octet-stream",
                changeFeedEvent.EventData.ContentType);
            Assert.AreEqual(
                128,
                changeFeedEvent.EventData.ContentLength);
            Assert.AreEqual(
                BlobType.Block,
                changeFeedEvent.EventData.BlobType);
            Assert.AreEqual(
                "2022-02-17T16:11:52.5901564Z",
                changeFeedEvent.EventData.BlobVersion);
            Assert.AreEqual(
                "0000000000000001",
                changeFeedEvent.EventData.ContainerVersion);
            Assert.AreEqual(
                AccessTier.Archive,
                changeFeedEvent.EventData.BlobAccessTier);
            Assert.AreEqual(
                new Uri("https://www.myurl.com"),
                changeFeedEvent.EventData.Uri);
            Assert.AreEqual(
                "00000000000000010000000000000002000000000000001d",
                changeFeedEvent.EventData.Sequencer);

            Assert.AreEqual("2022-02-17T13:08:42.4825913Z", changeFeedEvent.EventData.PreviousInfo.SoftDeleteSnapshot);
            Assert.IsTrue(changeFeedEvent.EventData.PreviousInfo.WasBlobSoftDeleted);
            Assert.AreEqual("2024-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo.NewBlobVersion);
            Assert.AreEqual("2022-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo.OldBlobVersion);
            Assert.AreEqual(AccessTier.Hot, changeFeedEvent.EventData.PreviousInfo.PreviousTier);

            Assert.AreEqual(
                "2022-02-17T16:09:16.7261278Z",
                changeFeedEvent.EventData.Snapshot);

            Assert.AreEqual(6, changeFeedEvent.EventData.UpdatedBlobProperties.Count);

            Assert.AreEqual("ContentLanguage", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName);
            Assert.AreEqual("pl-Pl", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue);
            Assert.AreEqual("nl-NL", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].OldValue);

            Assert.AreEqual("CacheControl", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName);
            Assert.AreEqual("max-age=100", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue);
            Assert.AreEqual("max-age=99", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].OldValue);

            Assert.AreEqual("ContentEncoding", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName);
            Assert.AreEqual("gzip, identity", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue);
            Assert.AreEqual("gzip", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].OldValue);

            Assert.AreEqual("ContentMD5", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName);
            Assert.AreEqual("Q2h1Y2sgSW51ZwDIAXR5IQ==", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue);
            Assert.AreEqual("Q2h1Y2sgSW=", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].OldValue);

            Assert.AreEqual("ContentDisposition", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName);
            Assert.AreEqual("attachment", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue);
            Assert.AreEqual("", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].OldValue);

            Assert.AreEqual("ContentType", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName);
            Assert.AreEqual("application/json", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue);
            Assert.AreEqual("application/octet-stream", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].OldValue);

            Assert.AreEqual(AccessTier.Hot, changeFeedEvent.EventData.LongRunningOperationInfo.DestinationAccessTier);
            Assert.IsTrue(changeFeedEvent.EventData.LongRunningOperationInfo.IsAsync);
            Assert.AreEqual("copyId", changeFeedEvent.EventData.LongRunningOperationInfo.CopyId);
        }

        [Test]
        public void SchemaV5Test()
        {
            // Arrange
            string rawText = File.ReadAllText(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{"EventSchemaV5.json"}");

            Dictionary<string, object> rawDictionary = DeserializeEvent(rawText);

            // Act
            BlobChangeFeedEvent changeFeedEvent = new BlobChangeFeedEvent(rawDictionary);

            // Assert
            Assert.AreEqual(
                5,
                changeFeedEvent.SchemaVersion);
            Assert.AreEqual(
                "/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV",
                changeFeedEvent.Topic);
            Assert.AreEqual(
                "/blobServices/default/containers/apitestcontainerver/blobs/20220217_131202494_Blob_oaG6iu7ImEB1cX8M",
                changeFeedEvent.Subject);
            Assert.AreEqual(
                BlobChangeFeedEventType.BlobCreated,
                changeFeedEvent.EventType);
            Assert.AreEqual(
                DateTimeOffset.Parse("2022-02-17T13:12:11.5746587Z"),
                changeFeedEvent.EventTime);
            Assert.AreEqual(
                Guid.Parse("62616073-8020-0000-00ff-233467060cc0"),
                changeFeedEvent.Id);
            Assert.AreEqual(
                BlobOperationName.PutBlob,
                changeFeedEvent.EventData.BlobOperationName);
            Assert.AreEqual(
                "b3f9b39a-ae5a-45ac-afad-95ac9e9f2791",
                changeFeedEvent.EventData.ClientRequestId);
            Assert.AreEqual(
                Guid.Parse("62616073-8020-0000-00ff-233467000000"),
                changeFeedEvent.EventData.RequestId);
            Assert.AreEqual(
                new ETag("0x8D9F2171BE32588"),
                changeFeedEvent.EventData.ETag);
            Assert.AreEqual(
                "application/octet-stream",
                changeFeedEvent.EventData.ContentType);
            Assert.AreEqual(
                128,
                changeFeedEvent.EventData.ContentLength);
            Assert.AreEqual(
                BlobType.Block,
                changeFeedEvent.EventData.BlobType);
            Assert.AreEqual(
                "2022-02-17T16:11:52.5901564Z",
                changeFeedEvent.EventData.BlobVersion);
            Assert.AreEqual(
                "0000000000000001",
                changeFeedEvent.EventData.ContainerVersion);
            Assert.AreEqual(
                AccessTier.Archive,
                changeFeedEvent.EventData.BlobAccessTier);
            Assert.AreEqual(
                new Uri("https://www.myurl.com"),
                changeFeedEvent.EventData.Uri);
            Assert.AreEqual(
                "00000000000000010000000000000002000000000000001d",
                changeFeedEvent.EventData.Sequencer);

            Assert.AreEqual("2022-02-17T13:12:11.5726507Z", changeFeedEvent.EventData.PreviousInfo.SoftDeleteSnapshot);
            Assert.IsTrue(changeFeedEvent.EventData.PreviousInfo.WasBlobSoftDeleted);
            Assert.AreEqual("2024-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo.NewBlobVersion);
            Assert.AreEqual("2022-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo.OldBlobVersion);
            Assert.AreEqual(AccessTier.Hot, changeFeedEvent.EventData.PreviousInfo.PreviousTier);

            Assert.AreEqual(
                "2022-02-17T16:09:16.7261278Z",
                changeFeedEvent.EventData.Snapshot);

            Assert.AreEqual(6, changeFeedEvent.EventData.UpdatedBlobProperties.Count);

            Assert.AreEqual("ContentLanguage", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName);
            Assert.AreEqual("pl-Pl", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue);
            Assert.AreEqual("nl-NL", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].OldValue);

            Assert.AreEqual("CacheControl", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName);
            Assert.AreEqual("max-age=100", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue);
            Assert.AreEqual("max-age=99", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].OldValue);

            Assert.AreEqual("ContentEncoding", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName);
            Assert.AreEqual("gzip, identity", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue);
            Assert.AreEqual("gzip", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].OldValue);

            Assert.AreEqual("ContentMD5", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName);
            Assert.AreEqual("Q2h1Y2sgSW51ZwDIAXR5IQ==", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue);
            Assert.AreEqual("Q2h1Y2sgSW=", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].OldValue);

            Assert.AreEqual("ContentDisposition", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName);
            Assert.AreEqual("attachment", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue);
            Assert.AreEqual("", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].OldValue);

            Assert.AreEqual("ContentType", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName);
            Assert.AreEqual("application/json", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue);
            Assert.AreEqual("application/octet-stream", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].OldValue);

            Assert.AreEqual(AccessTier.Hot, changeFeedEvent.EventData.LongRunningOperationInfo.DestinationAccessTier);
            Assert.IsTrue(changeFeedEvent.EventData.LongRunningOperationInfo.IsAsync);
            Assert.AreEqual("copyId", changeFeedEvent.EventData.LongRunningOperationInfo.CopyId);

            Assert.AreEqual(2, changeFeedEvent.EventData.UpdatedBlobTags.OldTags.Count);
            Assert.AreEqual("Value1_3", changeFeedEvent.EventData.UpdatedBlobTags.OldTags["Tag1"]);
            Assert.AreEqual("Value2_3", changeFeedEvent.EventData.UpdatedBlobTags.OldTags["Tag2"]);

            Assert.AreEqual(2, changeFeedEvent.EventData.UpdatedBlobTags.NewTags.Count);
            Assert.AreEqual("Value1_4", changeFeedEvent.EventData.UpdatedBlobTags.NewTags["Tag1"]);
            Assert.AreEqual("Value2_4", changeFeedEvent.EventData.UpdatedBlobTags.NewTags["Tag2"]);
        }

        [Test]
        [Ignore("For debugging specific avro files")]
        public async Task AvroTest()
        {
            using Stream stream = File.OpenRead($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{""}");
            AvroReader avroReader = new AvroReader(stream);
            Chunk chunk = new Chunk(
                avroReader: avroReader,
                blockOffset: 0,
                eventIndex: 0,
                chunkPath: null);

            List<BlobChangeFeedEvent> events = new List<BlobChangeFeedEvent>();
            while (chunk.HasNext())
            {
                BlobChangeFeedEvent changeFeedEvent = await chunk.Next(async: true);
                events.Add(changeFeedEvent);
            }
        }

        private Dictionary<string, object> DeserializeEvent(string rawText)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                DateParseHandling = DateParseHandling.None
            };
            Dictionary<string, object> rawDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(rawText, settings);
            ConvertChildOJObjectsToDictionaries(rawDictionary);
            return rawDictionary;
        }

        private void ConvertChildOJObjectsToDictionaries(Dictionary<string, object> dictionary)
        {
            foreach (string key in dictionary.Keys.ToList())
            {
                if (dictionary[key].GetType() == typeof(JObject))
                {
                    dictionary[key] = ((JObject)dictionary[key]).ToObject<Dictionary<string, object>>();
                    ConvertChildOJObjectsToDictionaries((Dictionary<string, object>)dictionary[key]);
                }
            }
        }
    }
}
