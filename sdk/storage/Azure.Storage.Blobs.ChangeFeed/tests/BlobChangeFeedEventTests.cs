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
            Assert.That(
                changeFeedEvent.SchemaVersion,
                Is.EqualTo(1));
            Assert.That(
                changeFeedEvent.Topic,
                Is.EqualTo("/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV"));
            Assert.That(
                changeFeedEvent.Subject,
                Is.EqualTo("/blobServices/default/containers/apitestcontainerver/blobs/20220217_125928329_Blob_oaG6iu7ImEB1cX8M"));
            Assert.That(
                changeFeedEvent.EventType,
                Is.EqualTo(BlobChangeFeedEventType.BlobCreated));
            Assert.That(
                changeFeedEvent.EventTime,
                Is.EqualTo(DateTimeOffset.Parse("2022-02-17T12:59:41.4003102Z")));
            Assert.That(
                changeFeedEvent.Id,
                Is.EqualTo(Guid.Parse("322343e3-8020-0000-00fe-233467066726")));
            Assert.That(
                changeFeedEvent.EventData.BlobOperationName,
                Is.EqualTo(BlobOperationName.PutBlob));
            Assert.That(
                changeFeedEvent.EventData.ClientRequestId,
                Is.EqualTo("f0270546-168e-4398-8fa8-107a1ac214d2"));
            Assert.That(
                changeFeedEvent.EventData.RequestId,
                Is.EqualTo(Guid.Parse("322343e3-8020-0000-00fe-233467000000")));
            Assert.That(
                changeFeedEvent.EventData.ETag,
                Is.EqualTo(new ETag("0x8D9F2155CBF7928")));
            Assert.That(
                changeFeedEvent.EventData.ContentType,
                Is.EqualTo("application/octet-stream"));
            Assert.That(
                changeFeedEvent.EventData.ContentLength,
                Is.EqualTo(128));
            Assert.That(
                changeFeedEvent.EventData.BlobType,
                Is.EqualTo(BlobType.Block));
            Assert.That(
                changeFeedEvent.EventData.Uri,
                Is.EqualTo(new Uri("https://www.myurl.com")));
            Assert.That(
                changeFeedEvent.EventData.Sequencer,
                Is.EqualTo("00000000000000010000000000000002000000000000001d"));
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
            Assert.That(
                changeFeedEvent.SchemaVersion,
                Is.EqualTo(3));
            Assert.That(
                changeFeedEvent.Topic,
                Is.EqualTo("/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV"));
            Assert.That(
                changeFeedEvent.Subject,
                Is.EqualTo("/blobServices/default/containers/apitestcontainerver/blobs/20220217_130510699_Blob_oaG6iu7ImEB1cX8M"));
            Assert.That(
                changeFeedEvent.EventType,
                Is.EqualTo(BlobChangeFeedEventType.BlobCreated));
            Assert.That(
                changeFeedEvent.EventTime,
                Is.EqualTo(DateTimeOffset.Parse("2022-02-17T13:05:19.6798242Z")));
            Assert.That(
                changeFeedEvent.Id,
                Is.EqualTo(Guid.Parse("eefe8fc8-8020-0000-00fe-23346706daaa")));
            Assert.That(
                changeFeedEvent.EventData.BlobOperationName,
                Is.EqualTo(BlobOperationName.PutBlob));
            Assert.That(
                changeFeedEvent.EventData.ClientRequestId,
                Is.EqualTo("00c0b6b7-bb67-4748-a3dc-86464863d267"));
            Assert.That(
                changeFeedEvent.EventData.RequestId,
                Is.EqualTo(Guid.Parse("eefe8fc8-8020-0000-00fe-233467000000")));
            Assert.That(
                changeFeedEvent.EventData.ETag,
                Is.EqualTo(new ETag("0x8D9F216266170DC")));
            Assert.That(
                changeFeedEvent.EventData.ContentType,
                Is.EqualTo("application/octet-stream"));
            Assert.That(
                changeFeedEvent.EventData.ContentLength,
                Is.EqualTo(128));
            Assert.That(
                changeFeedEvent.EventData.BlobType,
                Is.EqualTo(BlobType.Block));
            Assert.That(
                changeFeedEvent.EventData.Uri,
                Is.EqualTo(new Uri("https://www.myurl.com")));
            Assert.That(
                changeFeedEvent.EventData.Sequencer,
                Is.EqualTo("00000000000000010000000000000002000000000000001d"));

            Assert.That(changeFeedEvent.EventData.PreviousInfo.SoftDeleteSnapshot, Is.EqualTo("2022-02-17T13:08:42.4825913Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.WasBlobSoftDeleted, Is.True);
            Assert.That(changeFeedEvent.EventData.PreviousInfo.NewBlobVersion, Is.EqualTo("2024-02-17T16:11:52.0781797Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.OldBlobVersion, Is.EqualTo("2022-02-17T16:11:52.0781797Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.PreviousTier, Is.EqualTo(AccessTier.Hot));

            Assert.That(
                changeFeedEvent.EventData.Snapshot,
                Is.EqualTo("2022-02-17T16:09:16.7261278Z"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties.Count, Is.EqualTo(6));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName, Is.EqualTo("ContentLanguage"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue, Is.EqualTo("pl-Pl"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].OldValue, Is.EqualTo("nl-NL"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName, Is.EqualTo("CacheControl"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue, Is.EqualTo("max-age=100"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].OldValue, Is.EqualTo("max-age=99"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName, Is.EqualTo("ContentEncoding"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue, Is.EqualTo("gzip, identity"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].OldValue, Is.EqualTo("gzip"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName, Is.EqualTo("ContentMD5"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue, Is.EqualTo("Q2h1Y2sgSW51ZwDIAXR5IQ=="));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].OldValue, Is.EqualTo("Q2h1Y2sgSW="));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName, Is.EqualTo("ContentDisposition"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue, Is.EqualTo("attachment"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].OldValue, Is.Empty);

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName, Is.EqualTo("ContentType"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue, Is.EqualTo("application/json"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].OldValue, Is.EqualTo("application/octet-stream"));
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
            Assert.That(
                changeFeedEvent.SchemaVersion,
                Is.EqualTo(4));
            Assert.That(
                changeFeedEvent.Topic,
                Is.EqualTo("/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV"));
            Assert.That(
                changeFeedEvent.Subject,
                Is.EqualTo("/blobServices/default/containers/apitestcontainerver/blobs/20220217_130833395_Blob_oaG6iu7ImEB1cX8M"));
            Assert.That(
                changeFeedEvent.EventType,
                Is.EqualTo(BlobChangeFeedEventType.BlobCreated));
            Assert.That(
                changeFeedEvent.EventTime,
                Is.EqualTo(DateTimeOffset.Parse("2022-02-17T13:08:42.4835902Z")));
            Assert.That(
                changeFeedEvent.Id,
                Is.EqualTo(Guid.Parse("ca76bce1-8020-0000-00ff-23346706e769")));
            Assert.That(
                changeFeedEvent.EventData.BlobOperationName,
                Is.EqualTo(BlobOperationName.PutBlob));
            Assert.That(
                changeFeedEvent.EventData.ClientRequestId,
                Is.EqualTo("58fbfee9-6cf5-4096-9666-c42980beee65"));
            Assert.That(
                changeFeedEvent.EventData.RequestId,
                Is.EqualTo(Guid.Parse("ca76bce1-8020-0000-00ff-233467000000")));
            Assert.That(
                changeFeedEvent.EventData.ETag,
                Is.EqualTo(new ETag("0x8D9F2169F42D701")));
            Assert.That(
                changeFeedEvent.EventData.ContentType,
                Is.EqualTo("application/octet-stream"));
            Assert.That(
                changeFeedEvent.EventData.ContentLength,
                Is.EqualTo(128));
            Assert.That(
                changeFeedEvent.EventData.BlobType,
                Is.EqualTo(BlobType.Block));
            Assert.That(
                changeFeedEvent.EventData.BlobVersion,
                Is.EqualTo("2022-02-17T16:11:52.5901564Z"));
            Assert.That(
                changeFeedEvent.EventData.ContainerVersion,
                Is.EqualTo("0000000000000001"));
            Assert.That(
                changeFeedEvent.EventData.BlobAccessTier,
                Is.EqualTo(AccessTier.Archive));
            Assert.That(
                changeFeedEvent.EventData.Uri,
                Is.EqualTo(new Uri("https://www.myurl.com")));
            Assert.That(
                changeFeedEvent.EventData.Sequencer,
                Is.EqualTo("00000000000000010000000000000002000000000000001d"));

            Assert.That(changeFeedEvent.EventData.PreviousInfo.SoftDeleteSnapshot, Is.EqualTo("2022-02-17T13:08:42.4825913Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.WasBlobSoftDeleted, Is.True);
            Assert.That(changeFeedEvent.EventData.PreviousInfo.NewBlobVersion, Is.EqualTo("2024-02-17T16:11:52.0781797Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.OldBlobVersion, Is.EqualTo("2022-02-17T16:11:52.0781797Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.PreviousTier, Is.EqualTo(AccessTier.Hot));

            Assert.That(
                changeFeedEvent.EventData.Snapshot,
                Is.EqualTo("2022-02-17T16:09:16.7261278Z"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties.Count, Is.EqualTo(6));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName, Is.EqualTo("ContentLanguage"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue, Is.EqualTo("pl-Pl"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].OldValue, Is.EqualTo("nl-NL"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName, Is.EqualTo("CacheControl"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue, Is.EqualTo("max-age=100"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].OldValue, Is.EqualTo("max-age=99"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName, Is.EqualTo("ContentEncoding"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue, Is.EqualTo("gzip, identity"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].OldValue, Is.EqualTo("gzip"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName, Is.EqualTo("ContentMD5"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue, Is.EqualTo("Q2h1Y2sgSW51ZwDIAXR5IQ=="));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].OldValue, Is.EqualTo("Q2h1Y2sgSW="));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName, Is.EqualTo("ContentDisposition"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue, Is.EqualTo("attachment"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].OldValue, Is.Empty);

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName, Is.EqualTo("ContentType"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue, Is.EqualTo("application/json"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].OldValue, Is.EqualTo("application/octet-stream"));

            Assert.That(changeFeedEvent.EventData.LongRunningOperationInfo.DestinationAccessTier, Is.EqualTo(AccessTier.Hot));
            Assert.That(changeFeedEvent.EventData.LongRunningOperationInfo.IsAsync, Is.True);
            Assert.That(changeFeedEvent.EventData.LongRunningOperationInfo.CopyId, Is.EqualTo("copyId"));
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
            Assert.That(
                changeFeedEvent.SchemaVersion,
                Is.EqualTo(5));
            Assert.That(
                changeFeedEvent.Topic,
                Is.EqualTo("/subscriptions/dd40261b-437d-43d0-86cf-ef222b78fd15/resourceGroups/haambaga/providers/Microsoft.Storage/storageAccounts/HAAMBAGA-DEV"));
            Assert.That(
                changeFeedEvent.Subject,
                Is.EqualTo("/blobServices/default/containers/apitestcontainerver/blobs/20220217_131202494_Blob_oaG6iu7ImEB1cX8M"));
            Assert.That(
                changeFeedEvent.EventType,
                Is.EqualTo(BlobChangeFeedEventType.BlobCreated));
            Assert.That(
                changeFeedEvent.EventTime,
                Is.EqualTo(DateTimeOffset.Parse("2022-02-17T13:12:11.5746587Z")));
            Assert.That(
                changeFeedEvent.Id,
                Is.EqualTo(Guid.Parse("62616073-8020-0000-00ff-233467060cc0")));
            Assert.That(
                changeFeedEvent.EventData.BlobOperationName,
                Is.EqualTo(BlobOperationName.PutBlob));
            Assert.That(
                changeFeedEvent.EventData.ClientRequestId,
                Is.EqualTo("b3f9b39a-ae5a-45ac-afad-95ac9e9f2791"));
            Assert.That(
                changeFeedEvent.EventData.RequestId,
                Is.EqualTo(Guid.Parse("62616073-8020-0000-00ff-233467000000")));
            Assert.That(
                changeFeedEvent.EventData.ETag,
                Is.EqualTo(new ETag("0x8D9F2171BE32588")));
            Assert.That(
                changeFeedEvent.EventData.ContentType,
                Is.EqualTo("application/octet-stream"));
            Assert.That(
                changeFeedEvent.EventData.ContentLength,
                Is.EqualTo(128));
            Assert.That(
                changeFeedEvent.EventData.BlobType,
                Is.EqualTo(BlobType.Block));
            Assert.That(
                changeFeedEvent.EventData.BlobVersion,
                Is.EqualTo("2022-02-17T16:11:52.5901564Z"));
            Assert.That(
                changeFeedEvent.EventData.ContainerVersion,
                Is.EqualTo("0000000000000001"));
            Assert.That(
                changeFeedEvent.EventData.BlobAccessTier,
                Is.EqualTo(AccessTier.Archive));
            Assert.That(
                changeFeedEvent.EventData.Uri,
                Is.EqualTo(new Uri("https://www.myurl.com")));
            Assert.That(
                changeFeedEvent.EventData.Sequencer,
                Is.EqualTo("00000000000000010000000000000002000000000000001d"));

            Assert.That(changeFeedEvent.EventData.PreviousInfo.SoftDeleteSnapshot, Is.EqualTo("2022-02-17T13:12:11.5726507Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.WasBlobSoftDeleted, Is.True);
            Assert.That(changeFeedEvent.EventData.PreviousInfo.NewBlobVersion, Is.EqualTo("2024-02-17T16:11:52.0781797Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.OldBlobVersion, Is.EqualTo("2022-02-17T16:11:52.0781797Z"));
            Assert.That(changeFeedEvent.EventData.PreviousInfo.PreviousTier, Is.EqualTo(AccessTier.Hot));

            Assert.That(
                changeFeedEvent.EventData.Snapshot,
                Is.EqualTo("2022-02-17T16:09:16.7261278Z"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties.Count, Is.EqualTo(6));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName, Is.EqualTo("ContentLanguage"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue, Is.EqualTo("pl-Pl"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].OldValue, Is.EqualTo("nl-NL"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName, Is.EqualTo("CacheControl"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue, Is.EqualTo("max-age=100"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].OldValue, Is.EqualTo("max-age=99"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName, Is.EqualTo("ContentEncoding"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue, Is.EqualTo("gzip, identity"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].OldValue, Is.EqualTo("gzip"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName, Is.EqualTo("ContentMD5"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue, Is.EqualTo("Q2h1Y2sgSW51ZwDIAXR5IQ=="));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].OldValue, Is.EqualTo("Q2h1Y2sgSW="));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName, Is.EqualTo("ContentDisposition"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue, Is.EqualTo("attachment"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].OldValue, Is.Empty);

            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName, Is.EqualTo("ContentType"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue, Is.EqualTo("application/json"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].OldValue, Is.EqualTo("application/octet-stream"));

            Assert.That(changeFeedEvent.EventData.LongRunningOperationInfo.DestinationAccessTier, Is.EqualTo(AccessTier.Hot));
            Assert.That(changeFeedEvent.EventData.LongRunningOperationInfo.IsAsync, Is.True);
            Assert.That(changeFeedEvent.EventData.LongRunningOperationInfo.CopyId, Is.EqualTo("copyId"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobTags.OldTags.Count, Is.EqualTo(2));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobTags.OldTags["Tag1"], Is.EqualTo("Value1_3"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobTags.OldTags["Tag2"], Is.EqualTo("Value2_3"));

            Assert.That(changeFeedEvent.EventData.UpdatedBlobTags.NewTags.Count, Is.EqualTo(2));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobTags.NewTags["Tag1"], Is.EqualTo("Value1_4"));
            Assert.That(changeFeedEvent.EventData.UpdatedBlobTags.NewTags["Tag2"], Is.EqualTo("Value2_4"));
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
