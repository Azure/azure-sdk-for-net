// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.DataProtectionBackup;
using Azure.ResourceManager.DataProtectionBackup.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataProtectionBackup.Tests.Unit
{
    public class DataProtectionBackupJobPropertiesTests
    {
        [TestCase("PT34M34.9902732S", 20749902732L)]
        [TestCase("00:34:34.9902732", 20749902732L)]
        [TestCase("P1DT2H3M4.5S", 937845000000L)]
        [TestCase("1.02:03:04.5000000", 937845000000L)]
        public void DeserializeDuration(string duration, long expectedTicks)
        {
            DataProtectionBackupJobProperties job = ModelReaderWriter.Read<DataProtectionBackupJobProperties>(
                BinaryData.FromString($"{{\"duration\":\"{duration}\"}}"),
                ModelReaderWriterOptions.Json,
                AzureResourceManagerDataProtectionBackupContext.Default);

            Assert.That(job.Duration, Is.EqualTo(TimeSpan.FromTicks(expectedTicks)));
        }

        [Test]
        public void DeserializeInvalidDurationThrows()
        {
            Assert.Throws<FormatException>(() =>
            {
                ModelReaderWriter.Read<DataProtectionBackupJobProperties>(
                    BinaryData.FromString("{\"duration\":\"not-a-duration\"}"),
                    ModelReaderWriterOptions.Json,
                    AzureResourceManagerDataProtectionBackupContext.Default);
            });
        }

        [Test]
        public void SerializeDurationAsIso8601()
        {
            DataProtectionBackupJobProperties job = new DataProtectionBackupJobProperties(
                "activity",
                "instance",
                new ResourceIdentifier("/subscriptions/sub/resourceGroups/group/providers/Microsoft.Storage/storageAccounts/account"),
                new AzureLocation("eastus"),
                "source",
                "type",
                false,
                "Backup",
                "Backup",
                false,
                "group",
                "subscription",
                new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero),
                "Completed",
                "subscription",
                Array.Empty<string>(),
                "vault")
            {
                Duration = TimeSpan.FromTicks(20749902732)
            };

            BinaryData serialized = ModelReaderWriter.Write(
                job,
                ModelReaderWriterOptions.Json,
                AzureResourceManagerDataProtectionBackupContext.Default);

            using JsonDocument document = JsonDocument.Parse(serialized.ToString());
            Assert.That(document.RootElement.GetProperty("duration").GetString(), Is.EqualTo("PT34M34.9902732S"));
        }
    }
}
