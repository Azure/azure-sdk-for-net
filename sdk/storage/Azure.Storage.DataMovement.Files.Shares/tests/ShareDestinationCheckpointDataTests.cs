// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage.Files.Shares.Models;
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
        private const string DefaultFilePermissionKey = "MyPermissionKey";
        private readonly DateTimeOffset? DefaultFileCreatedOn = new DateTimeOffset(1568421685415L, TimeSpan.FromHours(-7));
        private readonly DateTimeOffset? DefaultFileLastWrittenOn = new DateTimeOffset(5848615861563L, TimeSpan.FromHours(4));
        private readonly DateTimeOffset? DefaultFileChangedOn = new DateTimeOffset(9841238965187L, TimeSpan.FromHours(0));

        private ShareFileDestinationCheckpointData CreateDefault()
        {
            return new ShareFileDestinationCheckpointData(
                new ShareFileHttpHeaders()
                {
                    ContentType = DefaultContentType,
                    ContentEncoding = DefaultContentEncoding,
                    ContentLanguage = DefaultContentLanguage,
                    ContentDisposition = DefaultContentDisposition,
                    CacheControl = DefaultCacheControl,
                },
                DefaultFileMetadata,
                DefaultDirectoryMetadata,
                new FileSmbProperties
                {
                    FileAttributes = DefaultFileAttributes,
                    FilePermissionKey = DefaultFilePermissionKey,
                    FileCreatedOn = DefaultFileCreatedOn,
                    FileLastWrittenOn = DefaultFileLastWrittenOn,
                    FileChangedOn = DefaultFileChangedOn,
                });
        }

        private void AssertEquals(ShareFileDestinationCheckpointData left, ShareFileDestinationCheckpointData right)
        {
            Assert.That(left.Version, Is.EqualTo(right.Version));
            Assert.That(left.ContentHeaders.ContentType, Is.EqualTo(right.ContentHeaders.ContentType));
            Assert.That(left.ContentHeaders.ContentEncoding, Is.EqualTo(right.ContentHeaders.ContentEncoding));
            Assert.That(left.ContentHeaders.ContentLanguage, Is.EqualTo(right.ContentHeaders.ContentLanguage));
            Assert.That(left.ContentHeaders.ContentDisposition, Is.EqualTo(right.ContentHeaders.ContentDisposition));
            Assert.That(left.ContentHeaders.CacheControl, Is.EqualTo(right.ContentHeaders.CacheControl));
            Assert.That(left.FileMetadata, Is.EqualTo(right.FileMetadata));
            Assert.That(left.DirectoryMetadata, Is.EqualTo(right.DirectoryMetadata));
            Assert.That(left.SmbProperties.FileAttributes, Is.EqualTo(right.SmbProperties.FileAttributes));
            Assert.That(left.SmbProperties.FilePermissionKey, Is.EqualTo(right.SmbProperties.FilePermissionKey));
            Assert.That(left.SmbProperties.FileCreatedOn, Is.EqualTo(right.SmbProperties.FileCreatedOn));
            Assert.That(left.SmbProperties.FileLastWrittenOn, Is.EqualTo(right.SmbProperties.FileLastWrittenOn));
            Assert.That(left.SmbProperties.FileChangedOn, Is.EqualTo(right.SmbProperties.FileChangedOn));
        }

        private byte[] CreateSerializedDefault()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            byte[] filePermissionKey = Encoding.UTF8.GetBytes(DefaultFilePermissionKey);
            byte[] contentType = Encoding.UTF8.GetBytes(DefaultContentType);
            byte[] contentEncoding = Encoding.UTF8.GetBytes(string.Join(",", DefaultContentEncoding));
            byte[] contentLanguage = Encoding.UTF8.GetBytes(string.Join(",", DefaultContentLanguage));
            byte[] contentDisposition = Encoding.UTF8.GetBytes(DefaultContentDisposition);
            byte[] cacheControl = Encoding.UTF8.GetBytes(DefaultCacheControl);
            byte[] fileMetadata = Encoding.UTF8.GetBytes(DefaultFileMetadata.DictionaryToString());
            byte[] directoryMetadata = Encoding.UTF8.GetBytes(DefaultDirectoryMetadata.DictionaryToString());

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion);
            writer.Write((int?)DefaultFileAttributes);
            writer.WriteVariableLengthFieldInfo(filePermissionKey.Length, ref currentVariableLengthIndex);
            writer.Write(DefaultFileCreatedOn);
            writer.Write(DefaultFileLastWrittenOn);
            writer.Write(DefaultFileChangedOn);
            writer.WriteVariableLengthFieldInfo(contentType.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(contentEncoding.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(contentLanguage.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(contentDisposition.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(cacheControl.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(fileMetadata.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(directoryMetadata.Length, ref currentVariableLengthIndex);
            writer.Write(filePermissionKey);
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
            ShareFileDestinationCheckpointData data = CreateDefault();

            Assert.That(data.Version, Is.EqualTo(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion));
            Assert.That(data.SmbProperties.FileAttributes, Is.EqualTo(DefaultFileAttributes));
            Assert.That(data.SmbProperties.FilePermissionKey, Is.EqualTo(DefaultFilePermissionKey));
            Assert.That(data.SmbProperties.FileCreatedOn, Is.EqualTo(DefaultFileCreatedOn));
            Assert.That(data.SmbProperties.FileLastWrittenOn, Is.EqualTo(DefaultFileLastWrittenOn));
            Assert.That(data.SmbProperties.FileChangedOn, Is.EqualTo(DefaultFileChangedOn));
            Assert.That(data.ContentHeaders.ContentType, Is.EqualTo(DefaultContentType));
            Assert.That(data.ContentHeaders.ContentEncoding, Is.EqualTo(DefaultContentEncoding));
            Assert.That(data.ContentHeaders.ContentLanguage, Is.EqualTo(DefaultContentLanguage));
            Assert.That(data.ContentHeaders.ContentDisposition, Is.EqualTo(DefaultContentDisposition));
            Assert.That(data.ContentHeaders.CacheControl, Is.EqualTo(DefaultCacheControl));
            Assert.That(data.FileMetadata, Is.EqualTo(DefaultFileMetadata));
            Assert.That(data.DirectoryMetadata, Is.EqualTo(DefaultDirectoryMetadata));
            ;
        }

        [Test]
        public void Serialize()
        {
            byte[] expected = CreateSerializedDefault();

            ShareFileDestinationCheckpointData data = CreateDefault();
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
            byte[] serialized = CreateSerializedDefault();
            ShareFileDestinationCheckpointData deserialized;

            using (MemoryStream stream = new(serialized))
            {
                deserialized = ShareFileDestinationCheckpointData.Deserialize(stream);
            }

            AssertEquals(deserialized, CreateDefault());
        }

        [Test]
        public void RoundTrip()
        {
            ShareFileDestinationCheckpointData original = CreateDefault();
            using MemoryStream serialized = new();
            original.SerializeInternal(serialized);
            serialized.Position = 0;
            ShareFileDestinationCheckpointData deserialized = ShareFileDestinationCheckpointData.Deserialize(serialized);

            AssertEquals(original, deserialized);
        }
    }
}
