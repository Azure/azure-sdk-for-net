// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Azure.Storage.Test;
using BaseBlobs::Azure.Storage.Blobs.Models;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

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

                Assert.That(actual, Is.EqualTo(expected).AsCollection);
            }
        }

        [Test]
        public void Ctor()
        {
            BlobDestinationCheckpointDetails data = CreatePreserveValues();

            Assert.That(data.Version, Is.EqualTo(DataMovementBlobConstants.DestinationCheckpointDetails.SchemaVersion));
            Assert.That(data.IsBlobTypeSet, Is.EqualTo(false));
            Assert.That(data.BlobType, Is.Null);
            Assert.That(data.IsContentTypeSet, Is.EqualTo(false));
            Assert.That(data.ContentTypeBytes, Is.Empty);
            Assert.That(data.IsContentEncodingSet, Is.EqualTo(false));
            Assert.That(data.ContentEncodingBytes, Is.Empty);
            Assert.That(data.IsContentLanguageSet, Is.EqualTo(false));
            Assert.That(data.ContentLanguageBytes, Is.Empty);
            Assert.That(data.IsContentDispositionSet, Is.EqualTo(false));
            Assert.That(data.ContentDispositionBytes, Is.Empty);
            Assert.That(data.IsCacheControlSet, Is.EqualTo(false));
            Assert.That(data.CacheControlBytes, Is.Empty);
            Assert.That(data.IsAccessTierSet, Is.EqualTo(false));
            Assert.That(data.AccessTierValue, Is.Null);
            Assert.That(data.IsMetadataSet, Is.EqualTo(false));
            Assert.That(data.Metadata, Is.Null);
            Assert.That(data.PreserveTags, Is.EqualTo(false));
            Assert.That(data.Tags, Is.Null);
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
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex + 1] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex + 2] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsOffsetIndex + 3] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex + 1] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex + 2] = 255;
                expected[DataMovementBlobConstants.DestinationCheckpointDetails.TagsLengthIndex + 3] = 255;
                // Remove Tags
                expected.RemoveRange(tagsOffset, tagsLength);

                // Get serialized data
                byte[] actual = dataStream.ToArray();

                // Verify
                Assert.That(actual, Is.EqualTo(expected).AsCollection);
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
                Assert.That(actual, Is.EqualTo(expected).AsCollection);
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
            Assert.That(data.Version, Is.EqualTo(4));
            Assert.That(data.IsBlobTypeSet, Is.True);
            Assert.That(data.BlobType, Is.EqualTo(DefaultBlobType));
            Assert.That(data.IsContentTypeSet, Is.EqualTo(true));
            Assert.That(data.ContentTypeBytes, Is.EqualTo(StringToByteArray(DefaultContentType)));
            Assert.That(data.IsContentEncodingSet, Is.EqualTo(true));
            Assert.That(data.ContentEncodingBytes, Is.EqualTo(StringToByteArray(DefaultContentEncoding)));
            Assert.That(data.IsContentLanguageSet, Is.EqualTo(true));
            Assert.That(data.ContentLanguageBytes, Is.EqualTo(StringToByteArray(DefaultContentLanguage)));
            Assert.That(data.IsContentDispositionSet, Is.EqualTo(true));
            Assert.That(data.ContentDispositionBytes, Is.EqualTo(StringToByteArray(DefaultContentDisposition)));
            Assert.That(data.IsCacheControlSet, Is.EqualTo(true));
            Assert.That(data.CacheControlBytes, Is.EqualTo(StringToByteArray(DefaultCacheControl)));
            Assert.That(data.IsAccessTierSet, Is.EqualTo(true));
            Assert.That(data.AccessTierValue, Is.EqualTo(DefaultAccessTier));
            Assert.That(data.IsMetadataSet, Is.EqualTo(true));
            Assert.That(data.Metadata, Is.EquivalentTo(DefaultMetadata));
            Assert.That(data.PreserveTags, Is.EqualTo(false));
            Assert.That(data.Tags, Is.EquivalentTo(DefaultTags));
        }

        private void VerifySampleValues_Version4(BlobDestinationCheckpointDetails data)
        {
            Assert.That(data.Version, Is.EqualTo(4));
            Assert.That(data.IsBlobTypeSet, Is.True);
            Assert.That(data.BlobType, Is.EqualTo(DefaultBlobType));
            Assert.That(data.IsContentTypeSet, Is.EqualTo(true));
            Assert.That(data.ContentTypeBytes, Is.EqualTo(StringToByteArray(DefaultContentType)));
            Assert.That(data.IsContentEncodingSet, Is.EqualTo(true));
            Assert.That(data.ContentEncodingBytes, Is.EqualTo(StringToByteArray(DefaultContentEncoding)));
            Assert.That(data.IsContentLanguageSet, Is.EqualTo(true));
            Assert.That(data.ContentLanguageBytes, Is.EqualTo(StringToByteArray(DefaultContentLanguage)));
            Assert.That(data.IsContentDispositionSet, Is.EqualTo(true));
            Assert.That(data.ContentDispositionBytes, Is.EqualTo(StringToByteArray(DefaultContentDisposition)));
            Assert.That(data.IsCacheControlSet, Is.EqualTo(true));
            Assert.That(data.CacheControlBytes, Is.EqualTo(StringToByteArray(DefaultCacheControl)));
            Assert.That(data.IsAccessTierSet, Is.EqualTo(true));
            Assert.That(data.AccessTierValue, Is.EqualTo(DefaultAccessTier));
            Assert.That(data.IsMetadataSet, Is.EqualTo(true));
            Assert.That(data.Metadata, Is.EquivalentTo(DefaultMetadata));
            Assert.That(data.PreserveTags, Is.EqualTo(false));
            Assert.That(data.Tags, Is.EquivalentTo(DefaultTags));
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

            Assert.That(deserialized.Version, Is.EqualTo(DataMovementBlobConstants.DestinationCheckpointDetails.SchemaVersion));
            Assert.That(deserialized.Version, Is.EqualTo(original.Version));
            Assert.That(deserialized.IsBlobTypeSet, Is.EqualTo(original.IsBlobTypeSet));
            Assert.That(deserialized.BlobType, Is.EqualTo(original.BlobType));
            Assert.That(deserialized.IsContentTypeSet, Is.EqualTo(original.IsContentTypeSet));
            Assert.That(deserialized.ContentTypeBytes, Is.EqualTo(original.ContentTypeBytes));
            Assert.That(deserialized.IsContentEncodingSet, Is.EqualTo(original.IsContentEncodingSet));
            Assert.That(deserialized.ContentEncodingBytes, Is.EqualTo(original.ContentEncodingBytes));
            Assert.That(deserialized.IsContentLanguageSet, Is.EqualTo(original.IsContentLanguageSet));
            Assert.That(deserialized.ContentLanguageBytes, Is.EqualTo(original.ContentLanguageBytes));
            Assert.That(deserialized.IsContentDispositionSet, Is.EqualTo(original.IsContentDispositionSet));
            Assert.That(deserialized.ContentDispositionBytes, Is.EqualTo(original.ContentDispositionBytes));
            Assert.That(deserialized.IsCacheControlSet, Is.EqualTo(original.IsCacheControlSet));
            Assert.That(deserialized.CacheControlBytes, Is.EqualTo(original.CacheControlBytes));
            Assert.That(deserialized.IsAccessTierSet, Is.EqualTo(original.IsAccessTierSet));
            Assert.That(deserialized.AccessTierValue, Is.EqualTo(original.AccessTierValue));
            Assert.That(deserialized.IsMetadataSet, Is.EqualTo(original.IsMetadataSet));
            Assert.That(deserialized.Metadata, Is.EqualTo(original.Metadata));
            Assert.That(deserialized.PreserveTags, Is.EqualTo(original.PreserveTags));
            Assert.That(deserialized.Tags, Is.EqualTo(original.Tags));
        }
    }
}
