// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    public class ShareDestinationCheckpointDetailsTests
    {
        private const string DefaultContentType = "text/plain";
        private readonly string[] DefaultContentEncoding = new string[] { "gzip" };
        private readonly string[] DefaultContentLanguage = new string[] { "en-US" };
        private const string DefaultContentDisposition = "inline";
        private const string DefaultCacheControl = "no-cache";
        private readonly Metadata DefaultFileMetadata = new Dictionary<string, string>(DataProvider.BuildMetadata())
        {
            { "MetadataFor", "Files" }
        };
        private readonly Metadata DefaultDirectoryMetadata = new Dictionary<string, string>(DataProvider.BuildMetadata())
        {
            { "MetadataFor", "Directories" }
        };
        // just a few different flags, no meaning
        private readonly NtfsFileAttributes? DefaultFileAttributes = NtfsFileAttributes.Temporary | NtfsFileAttributes.Archive;
        private const string DefaultPermissions = "rwxrwxrwx";
        private const string DefaultFilePermissionKey = "MyPermissionKey";
        private readonly DateTimeOffset? DefaultFileCreatedOn = new DateTimeOffset(2019, 2, 19, 4, 3, 5, TimeSpan.FromMinutes(5));
        private readonly DateTimeOffset? DefaultFileLastWrittenOn = new DateTimeOffset(2024, 11, 24, 11, 23, 45, TimeSpan.FromHours(10));
        private readonly DateTimeOffset? DefaultFileChangedOn = new DateTimeOffset(2023, 12, 25, 12, 34, 56, TimeSpan.FromMinutes(11));

        private ShareFileDestinationCheckpointDetails CreateDefaultValues()
        => new ShareFileDestinationCheckpointDetails(
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

        private ShareFileDestinationCheckpointDetails CreateNoPreserveValues()
        => new ShareFileDestinationCheckpointDetails(
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
                default);

        private ShareFileDestinationCheckpointDetails CreatePreserveValues()
        => new ShareFileDestinationCheckpointDetails(
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
                true,
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

        private ShareFileDestinationCheckpointDetails CreateSetSampleValues()
        => new ShareFileDestinationCheckpointDetails(
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
                isFileAttributesSet: true,
                fileAttributes: DefaultFileAttributes,
                filePermissions: false,
                isFileCreatedOnSet: true,
                fileCreatedOn: DefaultFileCreatedOn,
                isFileLastWrittenOnSet: true,
                fileLastWrittenOn: DefaultFileLastWrittenOn,
                isFileChangedOnSet: true,
                fileChangedOn: DefaultFileChangedOn,
                isFileMetadataSet: true,
                fileMetadata: DefaultFileMetadata,
                isDirectoryMetadataSet: true,
                directoryMetadata: DefaultDirectoryMetadata);

        private void AssertEquals(ShareFileDestinationCheckpointDetails left, ShareFileDestinationCheckpointDetails right)
        {
            Assert.That(left.Version, Is.EqualTo(right.Version));

            Assert.That(left.IsFileAttributesSet, Is.EqualTo(right.IsFileAttributesSet));
            if (left.IsFileAttributesSet && left.FileAttributes != default)
            {
                Assert.That(left.FileAttributes, Is.EqualTo(right.FileAttributes));
            }

            Assert.That(left.FilePermission, Is.EqualTo(right.FilePermission));
            Assert.That(left.IsFileCreatedOnSet, Is.EqualTo(right.IsFileCreatedOnSet));
            if (!left.IsFileCreatedOnSet && left.FileCreatedOn != default)
            {
                Assert.That(left.FileCreatedOn, Is.EqualTo(right.FileCreatedOn));
            }

            Assert.That(left.IsFileLastWrittenOnSet, Is.EqualTo(right.IsFileLastWrittenOnSet));
            if (!left.IsFileLastWrittenOnSet && left.FileLastWrittenOn != default)
            {
                Assert.That(left.FileLastWrittenOn, Is.EqualTo(right.FileLastWrittenOn));
            }

            Assert.That(left.IsFileChangedOnSet, Is.EqualTo(right.IsFileChangedOnSet));
            if (!left.IsFileChangedOnSet && left.FileChangedOn != default)
            {
                Assert.That(left.FileChangedOn, Is.EqualTo(right.FileChangedOn));
            }

            Assert.That(left.IsContentTypeSet, Is.EqualTo(right.IsContentTypeSet));
            if (!left.IsContentTypeSet && left.ContentType != default)
            {
                Assert.That(left.ContentType, Is.EqualTo(right.ContentType));
            }

            Assert.That(left.IsContentEncodingSet, Is.EqualTo(right.IsContentEncodingSet));
            if (!left.IsContentEncodingSet && left.ContentEncoding != default)
            {
                Assert.That(left.ContentEncoding, Is.EqualTo(right.ContentEncoding));
            }

            Assert.That(left.IsContentLanguageSet, Is.EqualTo(right.IsContentLanguageSet));
            if (!left.IsContentLanguageSet && left.ContentLanguage != default)
            {
                Assert.That(left.ContentLanguage, Is.EqualTo(right.ContentLanguage));
            }

            Assert.That(left.IsContentDispositionSet, Is.EqualTo(right.IsContentDispositionSet));
            if (!left.IsContentDispositionSet && left.ContentDisposition != default)
            {
                Assert.That(left.ContentDisposition, Is.EqualTo(right.ContentDisposition));
            }

            Assert.That(left.IsCacheControlSet, Is.EqualTo(right.IsCacheControlSet));
            if (!left.IsCacheControlSet && left.CacheControl != default)
            {
                Assert.That(left.CacheControl, Is.EqualTo(right.CacheControl));
            }

            Assert.That(left.IsFileMetadataSet, Is.EqualTo(right.IsFileMetadataSet));
            if (!left.IsFileMetadataSet && left.FileMetadata != default && left.FileMetadata.Count > 0)
            {
                Assert.That(left.FileMetadata, Is.EqualTo(right.FileMetadata));
            }

            Assert.That(left.IsDirectoryMetadataSet, Is.EqualTo(right.IsDirectoryMetadataSet));
            if (!left.IsDirectoryMetadataSet && left.DirectoryMetadata != default && left.DirectoryMetadata.Count > 0)
            {
                Assert.That(left.DirectoryMetadata, Is.EqualTo(right.DirectoryMetadata));
            }
        }

        private byte[] CreateSerializedPreserve()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion);
            writer.WritePreservablePropertyOffset(false, DataMovementConstants.IntSizeInBytes, ref currentVariableLengthIndex);
            writer.Write(true);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);

            return stream.ToArray();
        }

        private byte[] CreateSerializedNoPreserve()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.Write(false);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, 0, ref currentVariableLengthIndex);

            return stream.ToArray();
        }

        private byte[] CreateSerializedSetValues()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            bool preserveFilePermission = false;
            byte[] fileCreatedOn = Encoding.UTF8.GetBytes(DefaultFileCreatedOn.Value.ToString("o"));
            byte[] fileLastWrittenOn = Encoding.UTF8.GetBytes(DefaultFileLastWrittenOn.Value.ToString("o"));
            byte[] fileChangedOn = Encoding.UTF8.GetBytes(DefaultFileChangedOn.Value.ToString("o"));
            byte[] contentType = Encoding.UTF8.GetBytes(DefaultContentType);
            byte[] contentEncoding = Encoding.UTF8.GetBytes(string.Join(",", DefaultContentEncoding));
            byte[] contentLanguage = Encoding.UTF8.GetBytes(string.Join(",", DefaultContentLanguage));
            byte[] contentDisposition = Encoding.UTF8.GetBytes(DefaultContentDisposition);
            byte[] cacheControl = Encoding.UTF8.GetBytes(DefaultCacheControl);
            byte[] fileMetadata = Encoding.UTF8.GetBytes(DefaultFileMetadata.DictionaryToString());
            byte[] directoryMetadata = Encoding.UTF8.GetBytes(DefaultDirectoryMetadata.DictionaryToString());

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointDetails.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion);
            writer.WritePreservablePropertyOffset(true, DataMovementConstants.IntSizeInBytes, ref currentVariableLengthIndex);
            writer.Write(preserveFilePermission);
            writer.WritePreservablePropertyOffset(true, fileCreatedOn.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, fileLastWrittenOn.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, fileChangedOn.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, contentType.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, contentEncoding.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, contentLanguage.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, contentDisposition.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, cacheControl.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, fileMetadata.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(true, directoryMetadata.Length, ref currentVariableLengthIndex);
            writer.Write((int)DefaultFileAttributes);
            writer.Write(fileCreatedOn);
            writer.Write(fileLastWrittenOn);
            writer.Write(fileChangedOn);
            writer.Write(contentType);
            writer.Write(contentEncoding);
            writer.Write(contentLanguage);
            writer.Write(contentDisposition);
            writer.Write(cacheControl);
            writer.Write(fileMetadata);
            writer.Write(directoryMetadata);

            return stream.ToArray();
        }

        [Test]
        public void Ctor()
        {
            ShareFileDestinationCheckpointDetails data = CreateDefaultValues();

            Assert.AreEqual(DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion, data.Version);
            Assert.IsFalse(data.IsFileAttributesSet);
            Assert.IsNull(data.FileAttributes);
            Assert.IsFalse(data.FilePermission);
            Assert.IsFalse(data.IsFileCreatedOnSet);
            Assert.IsNull(data.FileCreatedOn);
            Assert.IsFalse(data.IsFileLastWrittenOnSet);
            Assert.IsNull(data.FileLastWrittenOn);
            Assert.IsFalse(data.IsFileChangedOnSet);
            Assert.IsNull(data.FileChangedOn);
            Assert.IsFalse(data.IsContentTypeSet);
            Assert.IsEmpty(data.ContentTypeBytes);
            Assert.IsFalse(data.IsContentEncodingSet);
            Assert.IsEmpty(data.ContentEncodingBytes);
            Assert.IsFalse(data.IsContentLanguageSet);
            Assert.IsEmpty(data.ContentLanguageBytes);
            Assert.IsFalse(data.IsContentDispositionSet);
            Assert.IsEmpty(data.ContentDispositionBytes);
            Assert.IsFalse(data.IsCacheControlSet);
            Assert.IsEmpty(data.CacheControlBytes);
            Assert.IsFalse(data.IsFileMetadataSet);
            Assert.IsNull(data.FileMetadata);
            Assert.IsFalse(data.IsDirectoryMetadataSet);
            Assert.IsNull(data.DirectoryMetadata);
        }

        [Test]
        public void Ctor_SetValues()
        {
            ShareFileDestinationCheckpointDetails data = CreateSetSampleValues();

            Assert.That(data.Version, Is.EqualTo(DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion));
            Assert.IsTrue(data.IsFileAttributesSet);
            Assert.That(data.FileAttributes, Is.EqualTo(DefaultFileAttributes));
            Assert.IsFalse(data.FilePermission);
            Assert.IsTrue(data.IsFileCreatedOnSet);
            Assert.That(data.FileCreatedOn.Value, Is.EqualTo(DefaultFileCreatedOn));
            Assert.IsTrue(data.IsFileLastWrittenOnSet);
            Assert.That(data.FileLastWrittenOn.Value, Is.EqualTo(DefaultFileLastWrittenOn));
            Assert.IsTrue(data.IsFileChangedOnSet);
            Assert.That(data.FileChangedOn.Value, Is.EqualTo(DefaultFileChangedOn));
            Assert.IsTrue(data.IsContentTypeSet);
            Assert.That(data.ContentType, Is.EqualTo(DefaultContentType));
            Assert.IsTrue(data.IsContentEncodingSet);
            Assert.That(data.ContentEncoding, Is.EqualTo(DefaultContentEncoding));
            Assert.IsTrue(data.IsContentLanguageSet);
            Assert.That(data.ContentLanguage, Is.EqualTo(DefaultContentLanguage));
            Assert.IsTrue(data.IsContentDispositionSet);
            Assert.That(data.ContentDisposition, Is.EqualTo(DefaultContentDisposition));
            Assert.IsTrue(data.IsCacheControlSet);
            Assert.That(data.CacheControl, Is.EqualTo(DefaultCacheControl));
            Assert.IsTrue(data.IsFileMetadataSet);
            Assert.That(data.FileMetadata, Is.EqualTo(DefaultFileMetadata));
            Assert.IsTrue(data.IsDirectoryMetadataSet);
            Assert.That(data.DirectoryMetadata, Is.EqualTo(DefaultDirectoryMetadata));
        }

        [Test]
        public void Ctor_Preserve()
        {
            ShareFileDestinationCheckpointDetails data = CreatePreserveValues();

            Assert.AreEqual(DataMovementShareConstants.DestinationCheckpointDetails.SchemaVersion, data.Version);
            Assert.IsFalse(data.IsFileAttributesSet);
            Assert.IsNull(data.FileAttributes);
            Assert.IsTrue(data.FilePermission);
            Assert.IsFalse(data.IsFileCreatedOnSet);
            Assert.IsNull(data.FileCreatedOn);
            Assert.IsFalse(data.IsFileLastWrittenOnSet);
            Assert.IsNull(data.FileLastWrittenOn);
            Assert.IsFalse(data.IsFileChangedOnSet);
            Assert.IsNull(data.FileChangedOn);
            Assert.IsFalse(data.IsContentTypeSet);
            Assert.IsNull(data.ContentType);
            Assert.IsFalse(data.IsContentEncodingSet);
            Assert.IsNull(data.ContentEncoding);
            Assert.IsFalse(data.IsContentLanguageSet);
            Assert.IsNull(data.ContentLanguage);
            Assert.IsFalse(data.IsContentDispositionSet);
            Assert.IsNull(data.ContentDisposition);
            Assert.IsFalse(data.IsCacheControlSet);
            Assert.IsNull(data.CacheControl);
            Assert.IsFalse(data.IsFileMetadataSet);
            Assert.IsNull(data.FileMetadata);
            Assert.IsFalse(data.IsDirectoryMetadataSet);
            Assert.IsNull(data.DirectoryMetadata);
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = CreateSerializedSetValues();

            ShareFileDestinationCheckpointDetails data = CreateSetSampleValues();
            byte[] actual;
            using (MemoryStream stream = new())
            {
                data.SerializeInternal(stream);
                actual = stream.ToArray();
            }

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Deserialize()
        {
            byte[] serialized = CreateSerializedSetValues();
            ShareFileDestinationCheckpointDetails deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointDetails.Deserialize(stream);
            }

            AssertEquals(deserialized, CreateSetSampleValues());
        }

        [Test]
        public void Deserialize_Preserve()
        {
            byte[] serialized = CreateSerializedPreserve();
            ShareFileDestinationCheckpointDetails deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointDetails.Deserialize(stream);
            }

            AssertEquals(deserialized, CreatePreserveValues());
        }

        [Test]
        public void Deserialize_NoPreserve()
        {
            byte[] serialized = CreateSerializedNoPreserve();
            ShareFileDestinationCheckpointDetails deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointDetails.Deserialize(stream);
            }

            AssertEquals(deserialized, CreateNoPreserveValues());
        }

        [Test]
        public void Deserialize_IncorrectSchemaVersion()
        {
            int incorrectSchemaVersion = 1;
            ShareFileDestinationCheckpointDetails data = CreatePreserveValues();
            data.Version = incorrectSchemaVersion;

            using MemoryStream dataStream = new MemoryStream(DataMovementShareConstants.DestinationCheckpointDetails.VariableLengthStartIndex);
            data.SerializeInternal(dataStream);
            dataStream.Position = 0;
            TestHelper.AssertExpectedException(
                () => ShareFileDestinationCheckpointDetails.Deserialize(dataStream),
                new ArgumentException($"The checkpoint file schema version {incorrectSchemaVersion} is not supported by this version of the SDK."));
        }

        [Test]
        public void RoundTrip()
        {
            ShareFileDestinationCheckpointDetails original = CreateSetSampleValues();
            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileDestinationCheckpointDetails deserialized = ShareFileDestinationCheckpointDetails.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }
    }
}
