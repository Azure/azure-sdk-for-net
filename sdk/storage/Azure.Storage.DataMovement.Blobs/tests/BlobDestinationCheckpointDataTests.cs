// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;

using Azure.Storage.Test;
using Azure.Storage.Blobs.Models;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using System.IO;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    public class BlobDestinationCheckpointDataTests
    {
        private const BlobType DefaultBlobType = BlobType.Block;
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private readonly Metadata DefaultMetadata = DataProvider.BuildMetadata();
        private readonly Tags DefaultTags = DataProvider.BuildTags();

        private BlobDestinationCheckpointData CreateDefault()
        {
            return new BlobDestinationCheckpointData(
                DefaultBlobType,
                new BlobHttpHeaders()
                {
                    ContentType = DefaultContentType,
                    ContentEncoding = DefaultContentEncoding,
                    ContentLanguage = DefaultContentLanguage,
                    ContentDisposition = DefaultContentDisposition,
                    CacheControl = DefaultCacheControl,
                },
                AccessTier.Hot,
                DefaultMetadata,
                DefaultTags);
        }

        [Test]
        public void Ctor()
        {
            BlobDestinationCheckpointData data = CreateDefault();

            Assert.AreEqual(DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion, data.Version);
            Assert.AreEqual(DefaultBlobType, data.BlobType);
            Assert.AreEqual(DefaultContentType, data.ContentHeaders.ContentType);
            Assert.AreEqual(DefaultContentEncoding, data.ContentHeaders.ContentEncoding);
            Assert.AreEqual(DefaultContentLanguage, data.ContentHeaders.ContentLanguage);
            Assert.AreEqual(DefaultContentDisposition, data.ContentHeaders.ContentDisposition);
            Assert.AreEqual(DefaultCacheControl, data.ContentHeaders.CacheControl);
            Assert.AreEqual(AccessTier.Hot, data.AccessTier);
            CollectionAssert.AreEquivalent(DefaultMetadata, data.Metadata);
            CollectionAssert.AreEquivalent(DefaultTags, data.Tags);
        }

        [Test]
        public void Serialize()
        {
            BlobDestinationCheckpointData data = CreateDefault();

            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.1.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                data.Serialize(dataStream);

                BinaryReader reader = new(fileStream);
                byte[] expected = reader.ReadBytes((int)fileStream.Length);
                byte[] actual = dataStream.ToArray();

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Deserialize()
        {
            BlobDestinationCheckpointData data = CreateDefault();

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            {
                data.Serialize(stream);
                stream.Position = 0;
                DeserializeAndVerify(stream, DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion);
            }
        }

        [Test]
        public void Deserialize_File_Version_1()
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.1.bin");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                stream.Position = 0;
                DeserializeAndVerify(stream, 1);
            }
        }

        private void DeserializeAndVerify(Stream stream, int version)
        {
            BlobDestinationCheckpointData deserialized = BlobDestinationCheckpointData.Deserialize(stream);

            Assert.AreEqual(version, deserialized.Version);
            Assert.AreEqual(DefaultBlobType, deserialized.BlobType);
            Assert.AreEqual(DefaultContentType, deserialized.ContentHeaders.ContentType);
            Assert.AreEqual(DefaultContentEncoding, deserialized.ContentHeaders.ContentEncoding);
            Assert.AreEqual(DefaultContentLanguage, deserialized.ContentHeaders.ContentLanguage);
            Assert.AreEqual(DefaultContentDisposition, deserialized.ContentHeaders.ContentDisposition);
            Assert.AreEqual(DefaultCacheControl, deserialized.ContentHeaders.CacheControl);
            Assert.AreEqual(AccessTier.Hot, deserialized.AccessTier);
            CollectionAssert.AreEquivalent(DefaultMetadata, deserialized.Metadata);
            CollectionAssert.AreEquivalent(DefaultTags, deserialized.Tags);
        }
    }
}
