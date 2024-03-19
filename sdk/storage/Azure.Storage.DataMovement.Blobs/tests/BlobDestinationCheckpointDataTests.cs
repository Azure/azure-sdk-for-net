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
using System.Linq;
using System.Collections.Generic;
using System;

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

        private BlobDestinationCheckpointData CreatePreserveValues()
        {
            return new BlobDestinationCheckpointData(
                DefaultBlobType,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default);
        }

        private BlobDestinationCheckpointData CreateSetSampleValues()
        {
            return new BlobDestinationCheckpointData(
                blobType: DefaultBlobType,
                contentType: new(DefaultContentType),
                contentEncoding: new(DefaultContentEncoding),
                contentLanguage: new(DefaultContentLanguage),
                contentDisposition: new(DefaultContentDisposition),
                cacheControl: new(DefaultCacheControl),
                accessTier: new(DefaultAccessTier),
                metadata: DefaultMetadata,
                tags: DefaultTags);
        }

        private void TestAssertSerializedData(BlobDestinationCheckpointData data)
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.2.bin");
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
        public void Ctor()
        {
            BlobDestinationCheckpointData data = CreatePreserveValues();

            Assert.AreEqual(DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion, data.Version);
            Assert.AreEqual(DefaultBlobType, data.BlobType);
            Assert.AreEqual(true, data.PreserveContentType);
            Assert.IsEmpty(data.ContentTypeBytes);
            Assert.AreEqual(true, data.PreserveContentEncoding);
            Assert.IsEmpty(data.ContentEncodingBytes);
            Assert.AreEqual(true, data.PreserveContentLanguage);
            Assert.IsEmpty(data.ContentLanguageBytes);
            Assert.AreEqual(true, data.PreserveContentDisposition);
            Assert.IsEmpty(data.ContentDispositionBytes);
            Assert.AreEqual(true, data.PreserveCacheControl);
            Assert.IsEmpty(data.CacheControlBytes);
            Assert.AreEqual(true, data.PreserveAccessTier);
            Assert.IsNull(data.AccessTier);
            Assert.AreEqual(true, data.PreserveMetadata);
            Assert.IsNull(data.Metadata);
            Assert.AreEqual(false, data.PreserveTags);
            Assert.IsNull(data.Tags);
        }

        [Test]
        public void Ctor_SetValues()
        {
            BlobDestinationCheckpointData data = CreateSetSampleValues();

            VerifySampleValues(data, DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion);
        }

        [Test]
        public void Serialize()
        {
            BlobDestinationCheckpointData data = CreateSetSampleValues();
            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveTags()
        {
            BlobDestinationCheckpointData data = CreateSetSampleValues();
            data.Tags = default;
            data.PreserveTags = true;
            data.TagsBytes = default;

            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.2.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                // Act
                data.Serialize(dataStream);

                BinaryReader reader = new(fileStream);
                List<byte> expected = reader.ReadBytes((int)fileStream.Length).ToList();
                // Change to expected Preserve Tags value - true
                expected[DataMovementBlobConstants.DestinationCheckpointData.PreserveTagsIndex] = 1;
                int tagsOffset = expected[DataMovementBlobConstants.DestinationCheckpointData.TagsOffsetIndex];
                int tagsLength = expected[DataMovementBlobConstants.DestinationCheckpointData.TagsLengthIndex];
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsOffsetIndex] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsOffsetIndex+1] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsOffsetIndex+2] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsOffsetIndex+3] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsLengthIndex] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsLengthIndex+1] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsLengthIndex+2] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointData.TagsLengthIndex+3] = 255;
                // Remove Tags
                expected.RemoveRange(tagsOffset, tagsLength);

                // Get serialized data
                byte[] actual = dataStream.ToArray();

                // Verify
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Serialize_PreserveAccessTier()
        {
            // Arrange
            BlobDestinationCheckpointData data = CreateSetSampleValues();
            data.PreserveAccessTier = true;
            data.AccessTier = default;

            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.2.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                // Act
                data.Serialize(dataStream);

                BinaryReader reader = new(fileStream);
                List<byte> expected = reader.ReadBytes((int)fileStream.Length).ToList();
                // Change to expected AccessTier value - true
                expected[DataMovementBlobConstants.DestinationCheckpointData.PreserveAccessTierIndex] = 1;
                expected[DataMovementBlobConstants.DestinationCheckpointData.AccessTierValueIndex] = 0;

                // Get serialized data
                byte[] actual = dataStream.ToArray();

                // Verify
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Deserialize()
        {
            BlobDestinationCheckpointData data = CreateSetSampleValues();

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex))
            {
                data.Serialize(stream);
                stream.Position = 0;
                BlobDestinationCheckpointData deserialized = BlobDestinationCheckpointData.Deserialize(stream);
                VerifySampleValues(deserialized, DataMovementBlobConstants.DestinationCheckpointData.SchemaVersion);
            }
        }

        [Test]
        public void Deserialize_File_Version_2()
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointData.2.bin");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                stream.Position = 0;
                BlobDestinationCheckpointData deserialized = BlobDestinationCheckpointData.Deserialize(stream);
                VerifySampleValues(deserialized, 2);
            }
        }

        private void VerifySampleValues(BlobDestinationCheckpointData data, int version)
        {
            Assert.AreEqual(version, data.Version);
            Assert.AreEqual(DefaultBlobType, data.BlobType);
            Assert.AreEqual(false, data.PreserveContentType);
            Assert.AreEqual(StringToByteArray(DefaultContentType), data.ContentTypeBytes);
            Assert.AreEqual(false, data.PreserveContentEncoding);
            Assert.AreEqual(StringToByteArray(DefaultContentEncoding), data.ContentEncodingBytes);
            Assert.AreEqual(false, data.PreserveContentLanguage);
            Assert.AreEqual(StringToByteArray(DefaultContentLanguage), data.ContentLanguageBytes);
            Assert.AreEqual(false, data.PreserveContentDisposition);
            Assert.AreEqual(StringToByteArray(DefaultContentDisposition), data.ContentDispositionBytes);
            Assert.AreEqual(false, data.PreserveCacheControl);
            Assert.AreEqual(StringToByteArray(DefaultCacheControl), data.CacheControlBytes);
            Assert.AreEqual(false, data.PreserveAccessTier);
            Assert.AreEqual(DefaultAccessTier, data.AccessTier.Value);
            Assert.AreEqual(false, data.PreserveMetadata);
            CollectionAssert.AreEquivalent(DefaultMetadata.Value, data.Metadata.Value);
            Assert.AreEqual(false, data.PreserveTags);
            CollectionAssert.AreEquivalent(DefaultTags.Value, data.Tags.Value);
        }

        [Test]
        public void Deserialize_IncorrectSchemaVersion()
        {
            int incorrectSchemaVersion = 1;
            BlobDestinationCheckpointData data = CreatePreserveValues();
            data.Version = incorrectSchemaVersion;

            using MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointData.VariableLengthStartIndex);
            data.Serialize(dataStream);
            dataStream.Position = 0;
            TestHelper.AssertExpectedException(
                () => BlobDestinationCheckpointData.Deserialize(dataStream),
                new ArgumentException($"The checkpoint file schema version {incorrectSchemaVersion} is not supported by this version of the SDK."));
        }
    }
}
