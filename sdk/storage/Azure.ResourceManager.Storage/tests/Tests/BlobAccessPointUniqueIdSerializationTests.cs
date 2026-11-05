// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class BlobAccessPointUniqueIdSerializationTests
    {
        private static readonly Guid UniqueId = new Guid("12345678-1234-5678-9abc-123456789abc");

        [Test]
        public void RequiredUniqueIdRoundTrips()
        {
            var model = new BlobAccessPointConnectionTestContent(UniqueId);

            BinaryData json = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(json);
            Assert.AreEqual(UniqueId.ToString("D"), document.RootElement.GetProperty("uniqueId").GetString());

            var result = ModelReaderWriter.Read<BlobAccessPointConnectionTestContent>(json, ModelReaderWriterOptions.Json);
            Assert.AreEqual(UniqueId, result.UniqueId);
            Assert.AreEqual(UniqueId, ArmStorageModelFactory.BlobAccessPointConnectionTestContent(UniqueId).UniqueId);
        }

        [Test]
        public void OptionalUniqueIdRoundTrips()
        {
            var model = ArmStorageModelFactory.BlobAccessPointConfigurationProperties(uniqueId: UniqueId);

            BinaryData json = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json);
            using JsonDocument document = JsonDocument.Parse(json);
            Assert.AreEqual(UniqueId.ToString("D"), document.RootElement.GetProperty("uniqueId").GetString());

            var result = ModelReaderWriter.Read<BlobAccessPointConfigurationProperties>(json, ModelReaderWriterOptions.Json);
            Assert.AreEqual(UniqueId, result.UniqueId);
        }

        [TestCase("{}")]
        [TestCase("{\"uniqueId\":null}")]
        public void OptionalUniqueIdCanBeAbsent(string json)
        {
            var result = ModelReaderWriter.Read<BlobAccessPointConfigurationProperties>(
                BinaryData.FromString(json), ModelReaderWriterOptions.Json);

            Assert.IsNull(result.UniqueId);
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase("not-a-guid")]
        public void RequiredUniqueIdRejectsInvalidJson(string value)
        {
            BinaryData json = BinaryData.FromString(JsonSerializer.Serialize(new { uniqueId = value }));

            Assert.Throws<FormatException>(() =>
                ModelReaderWriter.Read<BlobAccessPointConnectionTestContent>(json, ModelReaderWriterOptions.Json));
        }

        [TestCase("")]
        [TestCase("   ")]
        [TestCase("not-a-guid")]
        public void OptionalUniqueIdRejectsInvalidJson(string value)
        {
            BinaryData json = BinaryData.FromString(JsonSerializer.Serialize(new { uniqueId = value }));

            Assert.Throws<FormatException>(() =>
                ModelReaderWriter.Read<BlobAccessPointConfigurationProperties>(json, ModelReaderWriterOptions.Json));
        }
    }
}
