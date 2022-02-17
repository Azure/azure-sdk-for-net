// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Azure.Storage.Blobs.Models;
using Newtonsoft.Json;
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

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                DateParseHandling = DateParseHandling.None
            };
            Dictionary<string, object> rawDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(rawText, settings);

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
    }
}
