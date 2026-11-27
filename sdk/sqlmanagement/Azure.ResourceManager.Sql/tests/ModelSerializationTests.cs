// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.ResourceManager.Sql.Tests
{
    public class ModelSerializationTests
    {
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public void BackupImmutabilityUsesOriginalWireName(bool? shouldLockImmutability)
        {
            var data = new BackupShortTermRetentionPolicyData
            {
                ShouldLockImmutability = shouldLockImmutability
            };

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W")));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual(shouldLockImmutability.HasValue, properties.TryGetProperty("lockImmutability", out JsonElement value));
            if (shouldLockImmutability.HasValue)
            {
                Assert.AreEqual(shouldLockImmutability.Value, value.GetBoolean());
            }
            Assert.IsFalse(properties.TryGetProperty("shouldLockImmutability", out _));
        }

        [TestCase(true)]
        [TestCase(false)]
        [TestCase(null)]
        public void ManagedBackupImmutabilityUsesOriginalWireName(bool? shouldLockImmutability)
        {
            var data = new ManagedBackupShortTermRetentionPolicyData
            {
                ShouldLockImmutability = shouldLockImmutability
            };

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W")));
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.AreEqual(shouldLockImmutability.HasValue, properties.TryGetProperty("lockImmutability", out JsonElement value));
            if (shouldLockImmutability.HasValue)
            {
                Assert.AreEqual(shouldLockImmutability.Value, value.GetBoolean());
            }
            Assert.IsFalse(properties.TryGetProperty("shouldLockImmutability", out _));
        }

        [Test]
        public void DistributedAvailabilityGroupReadsErrorCodeFromOriginalWireName()
        {
            var json = BinaryData.FromString("{\"properties\":{\"mostRecentError\":\"12345\",\"mostRecentErrorMessage\":\"Replication failed\"}}");

            var data = ModelReaderWriter.Read<SqlDistributedAvailabilityGroupData>(json, new ModelReaderWriterOptions("W"));

            Assert.AreEqual("12345", data.MostRecentErrorCode);
            Assert.AreEqual("Replication failed", data.MostRecentErrorMessage);
        }
    }
}
