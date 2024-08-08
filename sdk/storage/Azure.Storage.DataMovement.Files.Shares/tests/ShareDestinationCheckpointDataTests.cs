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
    public class ShareDestinationCheckpointDataTests
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

        private ShareFileDestinationCheckpointData CreateDefaultValues()
        => new ShareFileDestinationCheckpointData(
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default,
                default);

        private ShareFileDestinationCheckpointData CreateNoPreserveValues()
        => new ShareFileDestinationCheckpointData(
                new(false),
                new(false),
                new(false),
                new(false),
                new(false),
                new(false),
                false,
                new(false),
                new(false),
                new(false),
                new(false),
                new(false));

        private ShareFileDestinationCheckpointData CreatePreserveValues()
        => new ShareFileDestinationCheckpointData(
                new(true),
                new(true),
                new(true),
                new(true),
                new(true),
                new(true),
                true,
                new(true),
                new(true),
                new(true),
                new(true),
                new(true));

        private ShareFileDestinationCheckpointData CreateSetSampleValues()
        => new ShareFileDestinationCheckpointData(
                contentType: new(DefaultContentType),
                contentEncoding: new(DefaultContentEncoding),
                contentLanguage: new(DefaultContentLanguage),
                contentDisposition: new(DefaultContentDisposition),
                cacheControl: new(DefaultCacheControl),
                fileAttributes: new(DefaultFileAttributes.Value),
                preserveFilePermission: false,
                fileCreatedOn: new(DefaultFileCreatedOn.Value),
                fileLastWrittenOn: new(DefaultFileLastWrittenOn.Value),
                fileChangedOn: new(DefaultFileChangedOn.Value),
                fileMetadata: new(DefaultFileMetadata),
                directoryMetadata: new(DefaultDirectoryMetadata));

        private void AssertEquals(ShareFileDestinationCheckpointData left, ShareFileDestinationCheckpointData right)
        {
            Assert.That(left.Version, Is.EqualTo(right.Version));

            Assert.That(left.PreserveFileAttributes, Is.EqualTo(right.PreserveFileAttributes));
            Assert.That(left.FileAttributes.Preserve, Is.EqualTo(right.FileAttributes.Preserve));
            if (!left.PreserveFileAttributes && left.FileAttributes != default)
            {
                Assert.That(left.FileAttributes.Value, Is.EqualTo(right.FileAttributes.Value));
            }

            Assert.That(left.PreserveFilePermission, Is.EqualTo(right.PreserveFilePermission));
            Assert.That(left.PreserveFileCreatedOn, Is.EqualTo(right.PreserveFileCreatedOn));
            Assert.That(left.FileCreatedOn.Preserve, Is.EqualTo(right.FileCreatedOn.Preserve));
            if (!left.PreserveFileCreatedOn && left.FileCreatedOn != default)
            {
                Assert.That(left.FileCreatedOn.Value, Is.EqualTo(right.FileCreatedOn.Value));
            }

            Assert.That(left.PreserveFileLastWrittenOn, Is.EqualTo(right.PreserveFileLastWrittenOn));
            Assert.That(left.FileLastWrittenOn.Preserve, Is.EqualTo(right.FileLastWrittenOn.Preserve));
            if (!left.PreserveFileLastWrittenOn && left.FileLastWrittenOn != default)
            {
                Assert.That(left.FileLastWrittenOn.Value, Is.EqualTo(right.FileLastWrittenOn.Value));
            }

            Assert.That(left.PreserveFileChangedOn, Is.EqualTo(right.PreserveFileChangedOn));
            Assert.That(left.FileChangedOn.Preserve, Is.EqualTo(right.FileChangedOn.Preserve));
            if (!left.PreserveFileChangedOn && left.FileChangedOn != default)
            {
                Assert.That(left.FileChangedOn.Value, Is.EqualTo(right.FileChangedOn.Value));
            }

            Assert.That(left.PreserveContentType, Is.EqualTo(right.PreserveContentType));
            Assert.That(left.ContentType.Preserve, Is.EqualTo(right.ContentType.Preserve));
            if (!left.PreserveContentType && left.ContentType != default)
            {
                Assert.That(left.ContentType.Value, Is.EqualTo(right.ContentType.Value));
            }

            Assert.That(left.PreserveContentEncoding, Is.EqualTo(right.PreserveContentEncoding));
            Assert.That(left.ContentEncoding.Preserve, Is.EqualTo(right.ContentEncoding.Preserve));
            if (!left.PreserveContentEncoding && left.ContentEncoding != default)
            {
                Assert.That(left.ContentEncoding.Value, Is.EqualTo(right.ContentEncoding.Value));
            }

            Assert.That(left.PreserveContentLanguage, Is.EqualTo(right.PreserveContentLanguage));
            Assert.That(left.ContentLanguage.Preserve, Is.EqualTo(right.ContentLanguage.Preserve));
            if (!left.PreserveContentLanguage && left.ContentLanguage != default)
            {
                Assert.That(left.ContentLanguage.Value, Is.EqualTo(right.ContentLanguage.Value));
            }

            Assert.That(left.PreserveContentDisposition, Is.EqualTo(right.PreserveContentDisposition));
            Assert.That(left.ContentDisposition.Preserve, Is.EqualTo(right.ContentDisposition.Preserve));
            if (!left.PreserveContentDisposition && left.ContentDisposition != default)
            {
                Assert.That(left.ContentDisposition.Value, Is.EqualTo(right.ContentDisposition.Value));
            }

            Assert.That(left.PreserveCacheControl, Is.EqualTo(right.PreserveCacheControl));
            Assert.That(left.CacheControl.Preserve, Is.EqualTo(right.CacheControl.Preserve));
            if (!left.PreserveCacheControl && left.CacheControl != default)
            {
                Assert.That(left.CacheControl.Value, Is.EqualTo(right.CacheControl.Value));
            }

            Assert.That(left.PreserveFileMetadata, Is.EqualTo(right.PreserveFileMetadata));
            Assert.That(left.FileMetadata.Preserve, Is.EqualTo(right.FileMetadata.Preserve));
            if (!left.PreserveFileMetadata && left.FileMetadata != default && left.FileMetadata.Value.Count > 0)
            {
                Assert.That(left.FileMetadata.Value, Is.EqualTo(right.FileMetadata.Value));
            }

            Assert.That(left.PreserveDirectoryMetadata, Is.EqualTo(right.PreserveDirectoryMetadata));
            Assert.That(left.DirectoryMetadata.Preserve, Is.EqualTo(right.DirectoryMetadata.Preserve));
            if (!left.PreserveDirectoryMetadata && left.DirectoryMetadata != default && left.DirectoryMetadata.Value.Count > 0)
            {
                Assert.That(left.DirectoryMetadata.Value, Is.EqualTo(right.DirectoryMetadata.Value));
            }
        }

        private byte[] CreateSerializedPreserve()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion);
            writer.WritePreservablePropertyOffset(true, DataMovementConstants.IntSizeInBytes, ref currentVariableLengthIndex);
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

        private byte[] CreateSerializedNoPreserve()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion);
            writer.WritePreservablePropertyOffset(false, 0, ref currentVariableLengthIndex);
            writer.Write(false);
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

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion);
            writer.WritePreservablePropertyOffset(false, DataMovementConstants.IntSizeInBytes, ref currentVariableLengthIndex);
            writer.Write(preserveFilePermission);
            writer.WritePreservablePropertyOffset(false, fileCreatedOn.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, fileLastWrittenOn.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, fileChangedOn.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, contentType.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, contentEncoding.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, contentLanguage.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, contentDisposition.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, cacheControl.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, fileMetadata.Length, ref currentVariableLengthIndex);
            writer.WritePreservablePropertyOffset(false, directoryMetadata.Length, ref currentVariableLengthIndex);
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
            ShareFileDestinationCheckpointData data = CreateDefaultValues();

            Assert.AreEqual(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion, data.Version);
            Assert.IsTrue(data.PreserveFileAttributes);
            Assert.IsNull(data.FileAttributes);
            Assert.IsFalse(data.PreserveFilePermission);
            Assert.IsTrue(data.PreserveFileCreatedOn);
            Assert.IsNull(data.FileCreatedOn);
            Assert.IsTrue(data.PreserveFileLastWrittenOn);
            Assert.IsNull(data.FileLastWrittenOn);
            Assert.IsTrue(data.PreserveFileChangedOn);
            Assert.IsNull(data.FileChangedOn);
            Assert.IsTrue(data.PreserveContentType);
            Assert.IsEmpty(data.ContentTypeBytes);
            Assert.IsTrue(data.PreserveContentEncoding);
            Assert.IsEmpty(data.ContentEncodingBytes);
            Assert.IsTrue(data.PreserveContentLanguage);
            Assert.IsEmpty(data.ContentLanguageBytes);
            Assert.IsTrue(data.PreserveContentDisposition);
            Assert.IsEmpty(data.ContentDispositionBytes);
            Assert.IsTrue(data.PreserveCacheControl);
            Assert.IsEmpty(data.CacheControlBytes);
            Assert.IsTrue(data.PreserveFileMetadata);
            Assert.IsNull(data.FileMetadata);
            Assert.IsTrue(data.PreserveDirectoryMetadata);
            Assert.IsNull(data.DirectoryMetadata);
        }

        [Test]
        public void Ctor_SetValues()
        {
            ShareFileDestinationCheckpointData data = CreateSetSampleValues();

            Assert.That(data.Version, Is.EqualTo(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion));
            Assert.IsFalse(data.PreserveFileAttributes);
            Assert.That(data.FileAttributes.Value, Is.EqualTo(DefaultFileAttributes));
            Assert.IsFalse(data.PreserveFilePermission);
            Assert.IsFalse(data.PreserveFileCreatedOn);
            Assert.That(data.FileCreatedOn.Value, Is.EqualTo(DefaultFileCreatedOn));
            Assert.IsFalse(data.PreserveFileLastWrittenOn);
            Assert.That(data.FileLastWrittenOn.Value, Is.EqualTo(DefaultFileLastWrittenOn));
            Assert.IsFalse(data.PreserveFileChangedOn);
            Assert.That(data.FileChangedOn.Value, Is.EqualTo(DefaultFileChangedOn));
            Assert.IsFalse(data.PreserveContentType);
            Assert.That(data.ContentType.Value, Is.EqualTo(DefaultContentType));
            Assert.IsFalse(data.PreserveContentEncoding);
            Assert.That(data.ContentEncoding.Value, Is.EqualTo(DefaultContentEncoding));
            Assert.IsFalse(data.PreserveContentLanguage);
            Assert.That(data.ContentLanguage.Value, Is.EqualTo(DefaultContentLanguage));
            Assert.IsFalse(data.PreserveContentDisposition);
            Assert.That(data.ContentDisposition.Value, Is.EqualTo(DefaultContentDisposition));
            Assert.IsFalse(data.PreserveCacheControl);
            Assert.That(data.CacheControl.Value, Is.EqualTo(DefaultCacheControl));
            Assert.IsFalse(data.PreserveFileMetadata);
            Assert.That(data.FileMetadata.Value, Is.EqualTo(DefaultFileMetadata));
            Assert.IsFalse(data.PreserveDirectoryMetadata);
            Assert.That(data.DirectoryMetadata.Value, Is.EqualTo(DefaultDirectoryMetadata));
        }

        [Test]
        public void Ctor_Preserve()
        {
            ShareFileDestinationCheckpointData data = CreatePreserveValues();

            Assert.AreEqual(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion, data.Version);
            Assert.IsTrue(data.PreserveFileAttributes);
            Assert.IsTrue(data.FileAttributes.Preserve);
            Assert.IsNull(data.FileAttributes.Value);
            Assert.IsTrue(data.PreserveFilePermission);
            Assert.IsTrue(data.PreserveFileCreatedOn);
            Assert.IsTrue(data.FileCreatedOn.Preserve);
            Assert.IsNull(data.FileCreatedOn.Value);
            Assert.IsTrue(data.PreserveFileLastWrittenOn);
            Assert.IsTrue(data.FileLastWrittenOn.Preserve);
            Assert.IsNull(data.FileLastWrittenOn.Value);
            Assert.IsTrue(data.PreserveFileChangedOn);
            Assert.IsTrue(data.FileChangedOn.Preserve);
            Assert.IsNull(data.FileChangedOn.Value);
            Assert.IsTrue(data.PreserveContentType);
            Assert.IsTrue(data.ContentType.Preserve);
            Assert.IsNull(data.ContentType.Value);
            Assert.IsTrue(data.PreserveContentEncoding);
            Assert.IsTrue(data.ContentEncoding.Preserve);
            Assert.IsNull(data.ContentEncoding.Value);
            Assert.IsTrue(data.PreserveContentLanguage);
            Assert.IsTrue(data.ContentLanguage.Preserve);
            Assert.IsNull(data.ContentLanguage.Value);
            Assert.IsTrue(data.PreserveContentDisposition);
            Assert.IsTrue(data.ContentDisposition.Preserve);
            Assert.IsNull(data.ContentDisposition.Value);
            Assert.IsTrue(data.PreserveCacheControl);
            Assert.IsTrue(data.CacheControl.Preserve);
            Assert.IsNull(data.CacheControl.Value);
            Assert.IsTrue(data.PreserveFileMetadata);
            Assert.IsTrue(data.FileMetadata.Preserve);
            Assert.IsNull(data.FileMetadata.Value);
            Assert.IsTrue(data.PreserveDirectoryMetadata);
            Assert.IsTrue(data.DirectoryMetadata.Preserve);
            Assert.IsNull(data.DirectoryMetadata.Value);
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = CreateSerializedSetValues();

            ShareFileDestinationCheckpointData data = CreateSetSampleValues();
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
            ShareFileDestinationCheckpointData deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointData.Deserialize(stream);
            }

            AssertEquals(deserialized, CreateSetSampleValues());
        }

        [Test]
        public void Deserialize_Preserve()
        {
            byte[] serialized = CreateSerializedPreserve();
            ShareFileDestinationCheckpointData deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointData.Deserialize(stream);
            }

            AssertEquals(deserialized, CreatePreserveValues());
        }

        [Test]
        public void Deserialize_NoPreserve()
        {
            byte[] serialized = CreateSerializedNoPreserve();
            ShareFileDestinationCheckpointData deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointData.Deserialize(stream);
            }

            AssertEquals(deserialized, CreateNoPreserveValues());
        }

        [Test]
        public void Deserialize_IncorrectSchemaVersion()
        {
            int incorrectSchemaVersion = 1;
            ShareFileDestinationCheckpointData data = CreatePreserveValues();
            data.Version = incorrectSchemaVersion;

            using MemoryStream dataStream = new MemoryStream(DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex);
            data.SerializeInternal(dataStream);
            dataStream.Position = 0;
            TestHelper.AssertExpectedException(
                () => ShareFileDestinationCheckpointData.Deserialize(dataStream),
                new ArgumentException($"The checkpoint file schema version {incorrectSchemaVersion} is not supported by this version of the SDK."));
        }

        [Test]
        public void RoundTrip()
        {
            ShareFileDestinationCheckpointData original = CreateSetSampleValues();
            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileDestinationCheckpointData deserialized = ShareFileDestinationCheckpointData.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }
    }
}
