// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Azure.Storage.Blobs.Models;
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

            Assert.AreEqual(2, changeFeedEvent.EventData.PreviousInfo.Count);
            Assert.AreEqual("2022-02-17T13:05:19.6788227Z", changeFeedEvent.EventData.PreviousInfo["SoftDeleteSnapshot"]);
            Assert.AreEqual("2022-02-17T16:11:52.0781797Z", changeFeedEvent.EventData.PreviousInfo["LastVersion"]);

            Assert.AreEqual(
                "2022-02-17T16:09:16.7261278Z",
                changeFeedEvent.EventData.Snapshot);

            Assert.AreEqual(6, changeFeedEvent.EventData.UpdatedBlobProperties.Count);

            Assert.AreEqual("ContentLanguage", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PropertyName);
            Assert.AreEqual("pl-Pl", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].NewValue);
            Assert.AreEqual("nl-NL", changeFeedEvent.EventData.UpdatedBlobProperties["ContentLanguage"].PreviousValue);

            Assert.AreEqual("CacheControl", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PropertyName);
            Assert.AreEqual("max-age=100", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].NewValue);
            Assert.AreEqual("max-age=99", changeFeedEvent.EventData.UpdatedBlobProperties["CacheControl"].PreviousValue);

            Assert.AreEqual("ContentEncoding", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PropertyName);
            Assert.AreEqual("gzip, identity", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].NewValue);
            Assert.AreEqual("gzip", changeFeedEvent.EventData.UpdatedBlobProperties["ContentEncoding"].PreviousValue);

            Assert.AreEqual("ContentMD5", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PropertyName);
            Assert.AreEqual("Q2h1Y2sgSW51ZwDIAXR5IQ==", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].NewValue);
            Assert.AreEqual("Q2h1Y2sgSW=", changeFeedEvent.EventData.UpdatedBlobProperties["ContentMD5"].PreviousValue);

            Assert.AreEqual("ContentDisposition", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PropertyName);
            Assert.AreEqual("attachment", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].NewValue);
            Assert.AreEqual("", changeFeedEvent.EventData.UpdatedBlobProperties["ContentDisposition"].PreviousValue);

            Assert.AreEqual("ContentType", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PropertyName);
            Assert.AreEqual("application/json", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].NewValue);
            Assert.AreEqual("application/octet-stream", changeFeedEvent.EventData.UpdatedBlobProperties["ContentType"].PreviousValue);
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
