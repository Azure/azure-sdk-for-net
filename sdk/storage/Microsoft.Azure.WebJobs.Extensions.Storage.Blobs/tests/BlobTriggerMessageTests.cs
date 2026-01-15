// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests
{
    using global::Azure.Storage.Blobs.Models;
    using Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners;
    using Newtonsoft.Json;
    using NUnit.Framework;

    public class BlobTriggerMessageTests
    {
        [TestCase("containerName", "blobName", BlobType.Block, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"BlockBlob\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        [TestCase("containerName", "blobName", BlobType.Append, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"AppendBlob\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        [TestCase("containerName", "blobName", BlobType.Page, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"PageBlob\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        public void CanSerializeBlobTriggerMessage(string containerName, string blobName, BlobType blobType, string etag, string functionId, string expectedMessage)
        {
            var message = new BlobTriggerMessage()
            {
                ContainerName = containerName,
                BlobName = blobName,
                BlobType = blobType,
                ETag = etag,
                FunctionId = functionId,
            };

            var serializedMessage = JsonConvert.SerializeObject(message, Formatting.None);

            Assert.That(serializedMessage, Is.EqualTo(expectedMessage));
        }

        [TestCase("containerName", "blobName", BlobType.Block, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"Block\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        [TestCase("containerName", "blobName", BlobType.Append, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"Append\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        [TestCase("containerName", "blobName", BlobType.Page, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"Page\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        public void CanDeserializeBlobTriggerMessage(string containerName, string blobName, BlobType blobType, string etag, string functionId, string incomingMessage)
        {
            var message = JsonConvert.DeserializeObject<BlobTriggerMessage>(incomingMessage);

            Assert.That(message.ContainerName, Is.EqualTo(containerName));
            Assert.That(message.BlobName, Is.EqualTo(blobName));
            Assert.That(message.BlobType, Is.EqualTo(blobType));
            Assert.That(message.ETag, Is.EqualTo(etag));
            Assert.That(message.FunctionId, Is.EqualTo(functionId));
        }

        // In track 1 BlobType enum had different values.
        [TestCase("containerName", "blobName", BlobType.Block, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"BlockBlob\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        [TestCase("containerName", "blobName", BlobType.Append, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"AppendBlob\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        [TestCase("containerName", "blobName", BlobType.Page, "etag", "functionId",
            "{\"Type\":\"BlobTrigger\",\"FunctionId\":\"functionId\",\"BlobType\":\"PageBlob\",\"ContainerName\":\"containerName\",\"BlobName\":\"blobName\",\"ETag\":\"etag\"}")]
        public void CanDeserializeTrack1BlobTriggerMessage(string containerName, string blobName, BlobType blobType, string etag, string functionId, string incomingMessage)
        {
            var message = JsonConvert.DeserializeObject<BlobTriggerMessage>(incomingMessage);

            Assert.That(message.ContainerName, Is.EqualTo(containerName));
            Assert.That(message.BlobName, Is.EqualTo(blobName));
            Assert.That(message.BlobType, Is.EqualTo(blobType));
            Assert.That(message.ETag, Is.EqualTo(etag));
            Assert.That(message.FunctionId, Is.EqualTo(functionId));
        }
    }
}
