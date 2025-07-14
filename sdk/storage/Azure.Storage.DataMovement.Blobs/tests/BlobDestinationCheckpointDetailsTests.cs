// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using Azure.Storage.Test;
using BaseBlobs::Azure.Storage.Blobs.Models;
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
    public class BlobDestinationCheckpointDetailsTests
    {
        private const BlobType DefaultBlobType = BlobType.Block;
        private const string DefaultContentType = "text/plain";
        private const string DefaultContentEncoding = "gzip";
        private const string DefaultContentLanguage = "en-US";
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private AccessTier DefaultAccessTier = AccessTier.Hot;
        private readonly Metadata DefaultMetadata = DataProvider.BuildMetadata();
        private readonly Tags DefaultTags = DataProvider.BuildTags();

        private static byte[] StringToByteArray(string value) => Encoding.UTF8.GetBytes(value);

        private BlobDestinationCheckpointDetails CreatePreserveValues()
        => new BlobDestinationCheckpointDetails(
                false,
                default,
                false,
                default,
                false,
                default,
                false,
                default,
                false,
                default,
                false,
                default,
                false,
                default,
                false,
                default,
                false,
                default);

        private BlobDestinationCheckpointDetails CreateSetSampleValues()
        => new BlobDestinationCheckpointDetails(
                isBlobTypeSet: true,
                blobType: DefaultBlobType,
                isContentTypeSet: true,
                contentType: DefaultContentType,
                isContentEncodingSet: true,
                contentEncoding: DefaultContentEncoding,
                isContentLanguageSet: true,
                contentLanguage: DefaultContentLanguage,
                isContentDispositionSet: true,
                contentDisposition: DefaultContentDisposition,
                isCacheControlSet: true,
                cacheControl: DefaultCacheControl,
                isAccessTierSet: true,
                accessTier: DefaultAccessTier,
                isMetadataSet: true,
                metadata: DefaultMetadata,
                preserveTags: false,
                tags: DefaultTags);

        private BlobDestinationCheckpointDetails CreateSetDefaultValues()
        => new BlobDestinationCheckpointDetails(
                true,
                default,
                true,
                default,
                true,
                default,
                true,
                default,
                true,
                default,
                true,
                default,
                true,
                default,
                true,
                default,
                false,
                default);

        private void TestAssertSerializedData(BlobDestinationCheckpointDetails data)
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointDetails.4.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex))
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
            BlobDestinationCheckpointDetails data = CreatePreserveValues();

            Assert.AreEqual(DataMovementBlobConstants.DestinationCheckpointDetails.SchemaVersion, data.Version);
            Assert.AreEqual(false, data.IsBlobTypeSet);
            Assert.IsNull(data.BlobType);
            Assert.AreEqual(false, data.IsContentTypeSet);
            Assert.IsEmpty(data.ContentTypeBytes);
            Assert.AreEqual(false, data.IsContentEncodingSet);
            Assert.IsEmpty(data.ContentEncodingBytes);
            Assert.AreEqual(false, data.IsContentLanguageSet);
            Assert.IsEmpty(data.ContentLanguageBytes);
            Assert.AreEqual(false, data.IsContentDispositionSet);
            Assert.IsEmpty(data.ContentDispositionBytes);
            Assert.AreEqual(false, data.IsCacheControlSet);
            Assert.IsEmpty(data.CacheControlBytes);
            Assert.AreEqual(false, data.IsAccessTierSet);
            Assert.IsNull(data.AccessTierValue);
            Assert.AreEqual(false, data.IsMetadataSet);
            Assert.IsNull(data.Metadata);
            Assert.AreEqual(false, data.PreserveTags);
            Assert.IsNull(data.Tags);
        }

        [Test]
        public void Ctor_SetValues()
        {
            BlobDestinationCheckpointDetails data = CreateSetSampleValues();

            VerifySampleValues_Version4(data);
        }

        [Test]
        public void Serialize()
        {
            BlobDestinationCheckpointDetails data = CreateSetSampleValues();
            TestAssertSerializedData(data);
        }

        [Test]
        public void Serialize_NoPreserveTags()
        {
            BlobDestinationCheckpointDetails data = CreateSetSampleValues();
            data.Tags = default;
            data.PreserveTags = true;
            data.TagsBytes = default;

            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointDetails.4.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                // Act
                data.Serialize(dataStream);

                BinaryReader reader = new(fileStream);
                List<byte> expected = reader.ReadBytes((int)fileStream.Length).ToList();
                // Change to expected Preserve Tags value - true
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.PreserveTagsIndex] = 1;
                int tagsOffset = expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex];
                int tagsLength = expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex];
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex+1] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex+2] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex+3] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex+1] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex+2] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex+3] = 255;
                // Remove Tags
                expected.RemoveRange(tagsOffset, tagsLength);

                // Get serialized data
                byte[] actual = dataStream.ToArray();

                // Verify
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Serialize_SetAccessTier()
        {
            // Arrange
            BlobDestinationCheckpointDetails data = CreateSetSampleValues();
            data.AccessTierValue = AccessTier.Cold;

            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointDetails.4.bin");
            using (MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex))
            using (FileStream fileStream = File.OpenRead(samplePath))
            {
                // Act
                data.Serialize(dataStream);

                BinaryReader reader = new(fileStream);
                List<byte> expected = reader.ReadBytes((int)fileStream.Length).ToList();
                // Change to expected AccessTier value
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.AccessTierValueIndex] = 3;

                // Get serialized data
                byte[] actual = dataStream.ToArray();

                // Verify
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Deserialize()
        {
            BlobDestinationCheckpointDetails data = CreateSetSampleValues();

            using (Stream stream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex))
            {
                data.Serialize(stream);
                stream.Position = 0;
                BlobDestinationCheckpointDetails deserialized = BlobDestinationCheckpointDetails.Deserialize(stream);
                VerifySampleValues_Version4(deserialized);
            }
        }

        [Test]
        public void Deserialize_File_Version_3()
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointDetails.3.bin");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                stream.Position = 0;
                BlobDestinationCheckpointDetails deserialized = BlobDestinationCheckpointDetails.Deserialize(stream);
                VerifySampleValues_Version3(deserialized);
            }
        }

        [Test]
        public void Deserialize_File_Version_4()
        {
            string samplePath = Path.Combine("Resources", "BlobDestinationCheckpointDetails.4.bin");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                stream.Position = 0;
                BlobDestinationCheckpointDetails deserialized = BlobDestinationCheckpointDetails.Deserialize(stream);
                VerifySampleValues_Version4(deserialized);
            }
        }

        private void VerifySampleValues_Version3(BlobDestinationCheckpointDetails data)
        {
            Assert.AreEqual(4, data.Version);
            Assert.IsTrue(data.IsBlobTypeSet);
            Assert.AreEqual(DefaultBlobType, data.BlobType);
            Assert.AreEqual(true, data.IsContentTypeSet);
            Assert.AreEqual(StringToByteArray(DefaultContentType), data.ContentTypeBytes);
            Assert.AreEqual(true, data.IsContentEncodingSet);
            Assert.AreEqual(StringToByteArray(DefaultContentEncoding), data.ContentEncodingBytes);
            Assert.AreEqual(true, data.IsContentLanguageSet);
            Assert.AreEqual(StringToByteArray(DefaultContentLanguage), data.ContentLanguageBytes);
            Assert.AreEqual(true, data.IsContentDispositionSet);
            Assert.AreEqual(StringToByteArray(DefaultContentDisposition), data.ContentDispositionBytes);
            Assert.AreEqual(true, data.IsCacheControlSet);
            Assert.AreEqual(StringToByteArray(DefaultCacheControl), data.CacheControlBytes);
            Assert.AreEqual(true, data.IsAccessTierSet);
            Assert.AreEqual(DefaultAccessTier, data.AccessTierValue);
            Assert.AreEqual(true, data.IsMetadataSet);
            CollectionAssert.AreEquivalent(DefaultMetadata, data.Metadata);
            Assert.AreEqual(false, data.PreserveTags);
            CollectionAssert.AreEquivalent(DefaultTags, data.Tags);
        }

        private void VerifySampleValues_Version4(BlobDestinationCheckpointDetails data)
        {
            Assert.AreEqual(4, data.Version);
            Assert.IsTrue(data.IsBlobTypeSet);
            Assert.AreEqual(DefaultBlobType, data.BlobType);
            Assert.AreEqual(true, data.IsContentTypeSet);
            Assert.AreEqual(StringToByteArray(DefaultContentType), data.ContentTypeBytes);
            Assert.AreEqual(true, data.IsContentEncodingSet);
            Assert.AreEqual(StringToByteArray(DefaultContentEncoding), data.ContentEncodingBytes);
            Assert.AreEqual(true, data.IsContentLanguageSet);
            Assert.AreEqual(StringToByteArray(DefaultContentLanguage), data.ContentLanguageBytes);
            Assert.AreEqual(true, data.IsContentDispositionSet);
            Assert.AreEqual(StringToByteArray(DefaultContentDisposition), data.ContentDispositionBytes);
            Assert.AreEqual(true, data.IsCacheControlSet);
            Assert.AreEqual(StringToByteArray(DefaultCacheControl), data.CacheControlBytes);
            Assert.AreEqual(true, data.IsAccessTierSet);
            Assert.AreEqual(DefaultAccessTier, data.AccessTierValue);
            Assert.AreEqual(true, data.IsMetadataSet);
            CollectionAssert.AreEquivalent(DefaultMetadata, data.Metadata);
            Assert.AreEqual(false, data.PreserveTags);
            CollectionAssert.AreEquivalent(DefaultTags, data.Tags);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void Deserialize_IncorrectSchemaVersion(int incorrectSchemaVersion)
        {
            BlobDestinationCheckpointDetails data = CreatePreserveValues();
            data.Version = incorrectSchemaVersion;

            using MemoryStream dataStream = new MemoryStream(DataMovementBlobConstants.DestinationCheckpointDetails.VariableLengthStartIndex);
            data.Serialize(dataStream);
            dataStream.Position = 0;
            TestHelper.AssertExpectedException(
                () => BlobDestinationCheckpointDetails.Deserialize(dataStream),
                new ArgumentException($"The checkpoint file schema version {incorrectSchemaVersion} is not supported by this version of the SDK."));
        }

        [Test]
        public void RoundTrip_Version_4()
        {
            BlobDestinationCheckpointDetails original = CreateSetSampleValues();
            using MemoryStream serialized = new();
            original.Serialize(serialized);
            serialized.Position = 0;
            BlobDestinationCheckpointDetails deserialized = BlobDestinationCheckpointDetails.Deserialize(serialized);

            Assert.AreEqual(DataMovementBlobConstants.DestinationCheckpointDetails.SchemaVersion, deserialized.Version);
            Assert.AreEqual(original.Version, deserialized.Version);
            Assert.AreEqual(original.IsBlobTypeSet, deserialized.IsBlobTypeSet);
            Assert.AreEqual(original.BlobType, deserialized.BlobType);
            Assert.AreEqual(original.IsContentTypeSet, deserialized.IsContentTypeSet);
            Assert.AreEqual(original.ContentTypeBytes, deserialized.ContentTypeBytes);
            Assert.AreEqual(original.IsContentEncodingSet, deserialized.IsContentEncodingSet);
            Assert.AreEqual(original.ContentEncodingBytes, deserialized.ContentEncodingBytes);
            Assert.AreEqual(original.IsContentLanguageSet, deserialized.IsContentLanguageSet);
            Assert.AreEqual(original.ContentLanguageBytes, deserialized.ContentLanguageBytes);
            Assert.AreEqual(original.IsContentDispositionSet, deserialized.IsContentDispositionSet);
            Assert.AreEqual(original.ContentDispositionBytes, deserialized.ContentDispositionBytes);
            Assert.AreEqual(original.IsCacheControlSet, deserialized.IsCacheControlSet);
            Assert.AreEqual(original.CacheControlBytes, deserialized.CacheControlBytes);
            Assert.AreEqual(original.IsAccessTierSet, deserialized.IsAccessTierSet);
            Assert.AreEqual(original.AccessTierValue, deserialized.AccessTierValue);
            Assert.AreEqual(original.IsMetadataSet, deserialized.IsMetadataSet);
            Assert.AreEqual(original.Metadata, deserialized.Metadata);
            Assert.AreEqual(original.PreserveTags, deserialized.PreserveTags);
            Assert.AreEqual(original.Tags, deserialized.Tags);
        }
    }
}
