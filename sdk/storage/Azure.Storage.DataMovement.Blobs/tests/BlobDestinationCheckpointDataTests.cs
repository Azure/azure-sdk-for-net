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
using System.Text;

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
        private AccessTier DefaultAccessTier = AccessTier.Hot;
        private readonly DataTransferProperty<Metadata> DefaultMetadata = new(DataProvider.BuildMetadata());
        private readonly DataTransferProperty<Tags> DefaultTags = new(DataProvider.BuildTags());

        private static byte[] StringToByteArray(string value) => Encoding.UTF8.GetBytes(value);

        private BlobDestinationCheckpointData CreateDefault()
        {
            return new BlobDestinationCheckpointData(
                DefaultBlobType,
                new(DefaultContentType),
                new(DefaultContentEncoding),
                new(DefaultContentLanguage),
                new(DefaultContentDisposition),
                new(DefaultCacheControl),
                new(DefaultAccessTier),
                DefaultMetadata,
                DefaultTags);
        }

        private void TestAssertSerializedData(BlobDestinationCheckpointData data)
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.1.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.OptionalIndexValuesStartIndex))
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
        public void Ctor()
        {
            BlobDestinationCheckpointData data = CreateDefault();

            Assert.AreEqual(DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion, data.Version);
            Assert.AreEqual(DefaultBlobType, data.BlobType);
            Assert.AreEqual(true, data.PreserveContentType);
            Assert.AreEqual(StringToByteArray(DefaultContentType), data.ContentTypeBytes);
            Assert.AreEqual(true, data.PreserveContentEncoding);
            Assert.AreEqual(StringToByteArray(DefaultContentEncoding), data.ContentEncodingBytes);
            Assert.AreEqual(true, data.PreserveContentLanguage);
            Assert.AreEqual(StringToByteArray(DefaultContentLanguage), data.ContentLanguageBytes);
            Assert.AreEqual(true, data.PreserveContentDisposition);
            Assert.AreEqual(StringToByteArray(DefaultContentDisposition), data.ContentDispositionBytes);
            Assert.AreEqual(true, data.PreserveCacheControl);
            Assert.AreEqual(StringToByteArray(DefaultCacheControl), data.CacheControlBytes);
            Assert.AreEqual(true, data.PreserveAccessTier);
            Assert.AreEqual(DefaultAccessTier, data.AccessTier);
            Assert.AreEqual(true, data.PreserveMetadata);
            CollectionAssert.AreEquivalent(DefaultMetadata.Value, data.Metadata.Value);
            Assert.AreEqual(true, data.PreserveTags);
            CollectionAssert.AreEquivalent(DefaultTags.Value, data.Tags.Value);
        }

        [Test]
        public void Serialize()
        {
            BlobDestinationCheckpointData data = CreateDefault();
            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveContentType()
        {
            BlobDestinationCheckpointData data = CreateDefault();
            data.PreserveContentType = false;
            data.ContentTypeBytes = default;

            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveContentEncoding()
        {
            BlobDestinationCheckpointData data = CreateDefault();
            data.PreserveContentEncoding = false;
            data.ContentEncodingBytes = default;
            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveContentLanguage()
        {
            BlobDestinationCheckpointData data = CreateDefault();
            data.PreserveContentLanguage = false;
            data.ContentLanguageBytes = default;
            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveContentDisposition()
        {
            BlobDestinationCheckpointData data = CreateDefault();
            data.PreserveContentDisposition = false;
            data.ContentDispositionBytes = default;
            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveAccessTier()
        {
            BlobDestinationCheckpointData data = CreateDefault();
            data.PreserveAccessTier = false;
            data.AccessTier = default;
            TestAssertSerializedData(data);
        }

        [Test]
        public void Deserialize()
        {
            BlobDestinationCheckpointData data = CreateDefault();

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.OptionalIndexValuesStartIndex))
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
            Assert.AreEqual(true, deserialized.PreserveContentType);
            Assert.AreEqual(StringToByteArray(DefaultContentType), deserialized.ContentTypeBytes);
            Assert.AreEqual(true, deserialized.PreserveContentEncoding);
            Assert.AreEqual(StringToByteArray(DefaultContentEncoding), deserialized.ContentEncodingBytes);
            Assert.AreEqual(true, deserialized.PreserveContentLanguage);
            Assert.AreEqual(StringToByteArray(DefaultContentLanguage), deserialized.ContentLanguageBytes);
            Assert.AreEqual(true, deserialized.PreserveContentDisposition);
            Assert.AreEqual(StringToByteArray(DefaultContentDisposition), deserialized.ContentDispositionBytes);
            Assert.AreEqual(true, deserialized.PreserveCacheControl);
            Assert.AreEqual(StringToByteArray(DefaultCacheControl), deserialized.CacheControlBytes);
            Assert.AreEqual(true, deserialized.PreserveAccessTier);
            Assert.AreEqual(DefaultAccessTier, deserialized.AccessTier);
            Assert.AreEqual(true, deserialized.PreserveMetadata);
            CollectionAssert.AreEquivalent(DefaultMetadata.Value, deserialized.Metadata.Value);
            Assert.AreEqual(true, deserialized.PreserveTags);
            CollectionAssert.AreEquivalent(DefaultTags.Value, deserialized.Tags.Value);
        }
    }
}
