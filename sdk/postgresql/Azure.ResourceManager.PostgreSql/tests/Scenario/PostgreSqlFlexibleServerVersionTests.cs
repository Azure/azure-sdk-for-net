// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.PostgreSql.Tests
{
    public class PostgreSqlFlexibleServerVersionTests
    {
        [TestCase("16", "J")]
        [TestCase("16", "W")]
        [TestCase("19-preview", "J")]
        [TestCase("19-preview", "W")]
        public void ServerAndPatchVersionsRoundTripAsStrings(string value, string format)
        {
            var version = new PostgreSqlFlexibleServerVersion(value);
            var options = new ModelReaderWriterOptions(format);
            var server = new PostgreSqlFlexibleServerData(AzureLocation.WestUS) { Version = version };
            BinaryData serverData = ModelReaderWriter.Write(server, options);
            using JsonDocument serverJson = JsonDocument.Parse(serverData);
            Assert.That(serverJson.RootElement.GetProperty("properties").GetProperty("version").GetString(), Is.EqualTo(value));
            Assert.That(ModelReaderWriter.Read<PostgreSqlFlexibleServerData>(serverData, options).Version, Is.EqualTo(version));

            var patch = new PostgreSqlFlexibleServerPatch { Version = version };
            BinaryData patchData = ModelReaderWriter.Write(patch, options);
            using JsonDocument patchJson = JsonDocument.Parse(patchData);
            Assert.That(patchJson.RootElement.GetProperty("properties").GetProperty("version").GetString(), Is.EqualTo(value));
            Assert.That(ModelReaderWriter.Read<PostgreSqlFlexibleServerPatch>(patchData, options).Version, Is.EqualTo(version));
        }

        [TestCase("{}")]
        [TestCase("{\"properties\":{}}")]
        [TestCase("{\"properties\":{\"version\":null}}")]
        public void ServerAndPatchVersionsCanBeOmittedOrNull(string json)
        {
            var server = ModelReaderWriter.Read<PostgreSqlFlexibleServerData>(BinaryData.FromString(json));
            Assert.That(server.Version, Is.Null);
            using JsonDocument serverJson = JsonDocument.Parse(ModelReaderWriter.Write(server));
            Assert.That(serverJson.RootElement.TryGetProperty("properties", out JsonElement serverProperties)
                && serverProperties.TryGetProperty("version", out _), Is.False);

            var patch = ModelReaderWriter.Read<PostgreSqlFlexibleServerPatch>(BinaryData.FromString(json));
            Assert.That(patch.Version, Is.Null);
            using JsonDocument patchJson = JsonDocument.Parse(ModelReaderWriter.Write(patch));
            Assert.That(patchJson.RootElement.TryGetProperty("properties", out JsonElement patchProperties)
                && patchProperties.TryGetProperty("version", out _), Is.False);
        }

        [TestCase("16")]
        [TestCase("19-preview")]
        public void UpgradeVersionsRoundTripAsStrings(string value)
        {
            var version = new PostgreSqlFlexibleServerVersion(value);
            var content = new StartMajorVersionUpgradePrecheckContent(version);
            var wireOptions = new ModelReaderWriterOptions("W");
            BinaryData contentData = ModelReaderWriter.Write(content, wireOptions);
            using JsonDocument contentJson = JsonDocument.Parse(contentData);
            Assert.That(contentJson.RootElement.GetProperty("targetVersion").GetString(), Is.EqualTo(value));
            Assert.That(ModelReaderWriter.Read<StartMajorVersionUpgradePrecheckContent>(contentData, wireOptions).TargetVersion, Is.EqualTo(version));

            var precheck = ArmPostgreSqlFlexibleServersModelFactory.MajorVersionUpgradePrecheckProperties(targetVersion: version);
            BinaryData precheckData = ModelReaderWriter.Write(precheck);
            using JsonDocument precheckJson = JsonDocument.Parse(precheckData);
            Assert.That(precheckJson.RootElement.GetProperty("targetVersion").GetString(), Is.EqualTo(value));
            Assert.That(ModelReaderWriter.Read<MajorVersionUpgradePrecheckProperties>(precheckData).TargetVersion, Is.EqualTo(version));

            var sequence = ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlMajorVersionUpgradeSequence(
                sourceVersion: PostgreSqlFlexibleServerVersion.Ver15, targetVersion: version);
            BinaryData sequenceData = ModelReaderWriter.Write(sequence);
            using JsonDocument sequenceJson = JsonDocument.Parse(sequenceData);
            Assert.That(sequenceJson.RootElement.GetProperty("sourceVersion").GetString(), Is.EqualTo("15"));
            Assert.That(sequenceJson.RootElement.GetProperty("targetVersion").GetString(), Is.EqualTo(value));
            var restoredSequence = ModelReaderWriter.Read<PostgreSqlMajorVersionUpgradeSequence>(sequenceData);
            Assert.That(restoredSequence.SourceVersion, Is.EqualTo(PostgreSqlFlexibleServerVersion.Ver15));
            Assert.That(restoredSequence.TargetVersion, Is.EqualTo(version));
        }

        [TestCase("{}")]
        [TestCase("{\"sourceVersion\":null,\"targetVersion\":null}")]
        public void UpgradeResponseVersionsCanBeOmittedOrNull(string json)
        {
            var precheck = ModelReaderWriter.Read<MajorVersionUpgradePrecheckProperties>(BinaryData.FromString(json));
            Assert.That(precheck.TargetVersion, Is.Null);
            var sequence = ModelReaderWriter.Read<PostgreSqlMajorVersionUpgradeSequence>(BinaryData.FromString(json));
            Assert.That(sequence.SourceVersion, Is.Null);
            Assert.That(sequence.TargetVersion, Is.Null);
        }

        [Test]
        public void HistoricalModelFactoriesPreserveVersionWhenOtherPropertiesAreNull()
        {
            var version = new PostgreSqlFlexibleServerVersion("19-preview");
            var servers = new[]
            {
                ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerData(
                    default, default, default, default, default, default, default, default, default, default,
                    version, default, default, default, storageSizeInGB: default,
                    default, default, default, default, default, default,
                    default, default, default, default, default, default),
                ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerData(
                    default, default, default, default, default, default, default, default, default, default,
                    version, default, default, default, storage: default,
                    default, default, default, default, default, default,
                    default, default, default, default, default, default, default, default),
                ArmPostgreSqlFlexibleServersModelFactory.PostgreSqlFlexibleServerData(
                    default, default, default, default, default, default, default, default, default, default,
                    version, default, default, default, storage: default,
                    default, default, default, default, default, default,
                    default, default, default, default, default, default, default, default, cluster: default)
            };

            foreach (PostgreSqlFlexibleServerData server in servers)
            {
                Assert.That(server.Version, Is.EqualTo(version));
            }
        }
    }
}
