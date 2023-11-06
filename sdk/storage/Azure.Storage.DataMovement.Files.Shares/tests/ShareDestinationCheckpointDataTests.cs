// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        private readonly Metadata DefaultMetadata = DataProvider.BuildMetadata();

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
                DefaultMetadata);
        }

        private void AssertEquals(ShareFileDestinationCheckpointData left, ShareFileDestinationCheckpointData right)
        {
            Assert.That(left.Version, Is.EqualTo(right.Version));
            Assert.That(left.ContentHeaders.ContentType, Is.EqualTo(right.ContentHeaders.ContentType));
            Assert.That(left.ContentHeaders.ContentEncoding, Is.EqualTo(right.ContentHeaders.ContentEncoding));
            Assert.That(left.ContentHeaders.ContentLanguage, Is.EqualTo(right.ContentHeaders.ContentLanguage));
            Assert.That(left.ContentHeaders.ContentDisposition, Is.EqualTo(right.ContentHeaders.ContentDisposition));
            Assert.That(left.ContentHeaders.CacheControl, Is.EqualTo(right.ContentHeaders.CacheControl));
            Assert.That(left.Metadata, Is.EqualTo(right.Metadata));
        }

        private byte[] CreateSerializedDefault()
        {
            using MemoryStream stream = new();
            using BinaryWriter writer = new(stream);

            byte[] contentType = Encoding.UTF8.GetBytes(DefaultContentType);
            byte[] contentEncoding = Encoding.UTF8.GetBytes(string.Join(",", DefaultContentEncoding));
            byte[] contentLanguage = Encoding.UTF8.GetBytes(string.Join(",", DefaultContentLanguage));
            byte[] contentDisposition = Encoding.UTF8.GetBytes(DefaultContentDisposition);
            byte[] cacheControl = Encoding.UTF8.GetBytes(DefaultCacheControl);
            byte[] metadata = Encoding.UTF8.GetBytes(DefaultMetadata.DictionaryToString());

            int currentVariableLengthIndex = DataMovementShareConstants.DestinationCheckpointData.VariableLengthStartIndex;
            writer.Write(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion);
            writer.WriteVariableLengthFieldInfo(contentType.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(contentEncoding.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(contentLanguage.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(contentDisposition.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(cacheControl.Length, ref currentVariableLengthIndex);
            writer.WriteVariableLengthFieldInfo(metadata.Length, ref currentVariableLengthIndex);
            writer.Write(contentType);
            writer.Write(contentEncoding);
            writer.Write(contentLanguage);
            writer.Write(contentDisposition);
            writer.Write(cacheControl);
            writer.Write(metadata);

            return stream.ToArray();
        }

        [Test]
        public void Ctor()
        {
            ShareFileDestinationCheckpointData data = CreateDefault();

            Assert.That(data.Version, Is.EqualTo(DataMovementShareConstants.DestinationCheckpointData.SchemaVersion));
            Assert.That(data.ContentHeaders.ContentType, Is.EqualTo(DefaultContentType));
            Assert.That(data.ContentHeaders.ContentEncoding, Is.EqualTo(DefaultContentEncoding));
            Assert.That(data.ContentHeaders.ContentLanguage, Is.EqualTo(DefaultContentLanguage));
            Assert.That(data.ContentHeaders.ContentDisposition, Is.EqualTo(DefaultContentDisposition));
            Assert.That(data.ContentHeaders.CacheControl, Is.EqualTo(DefaultCacheControl));
            Assert.That(data.Metadata, Is.EqualTo(DefaultMetadata));
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
