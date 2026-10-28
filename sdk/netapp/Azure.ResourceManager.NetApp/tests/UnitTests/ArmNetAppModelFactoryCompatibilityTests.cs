// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetApp.Tests
{
    public class ArmNetAppModelFactoryCompatibilityTests
    {
        private const string ResourceGroupId = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test";

        private static IEnumerable<TestCaseData> ElasticFactoryTagDefaults()
        {
            yield return new TestCaseData(
                ArmNetAppModelFactory.NetAppElasticAccountData(),
                ArmNetAppModelFactory.NetAppElasticAccountData(tags: null))
                .SetName("ElasticAccountFactoryProvidesMutableDefaultTags");
            yield return new TestCaseData(
                ArmNetAppModelFactory.NetAppElasticCapacityPoolData(),
                ArmNetAppModelFactory.NetAppElasticCapacityPoolData(tags: null))
                .SetName("ElasticCapacityPoolFactoryProvidesMutableDefaultTags");
            yield return new TestCaseData(
                ArmNetAppModelFactory.NetAppElasticVolumeData(),
                ArmNetAppModelFactory.NetAppElasticVolumeData(tags: null))
                .SetName("ElasticVolumeFactoryProvidesMutableDefaultTags");
            yield return new TestCaseData(
                ArmNetAppModelFactory.NetAppElasticSnapshotPolicyData(),
                ArmNetAppModelFactory.NetAppElasticSnapshotPolicyData(tags: null))
                .SetName("ElasticSnapshotPolicyFactoryProvidesMutableDefaultTags");
            yield return new TestCaseData(
                ArmNetAppModelFactory.NetAppElasticBackupPolicyData(),
                ArmNetAppModelFactory.NetAppElasticBackupPolicyData(tags: null))
                .SetName("ElasticBackupPolicyFactoryProvidesMutableDefaultTags");
            yield return new TestCaseData(
                ArmNetAppModelFactory.NetAppElasticBackupVaultData(),
                ArmNetAppModelFactory.NetAppElasticBackupVaultData(tags: null))
                .SetName("ElasticBackupVaultFactoryProvidesMutableDefaultTags");
        }

        [TestCaseSource(nameof(ElasticFactoryTagDefaults))]
        public void ElasticFactoryProvidesMutableDefaultTags(TrackedResourceData omittedTags, TrackedResourceData nullTags)
        {
            foreach (TrackedResourceData data in new[] { omittedTags, nullTags })
            {
                Assert.That(data.Tags, Is.Not.Null.And.Empty);
                data.Tags.Add("env", "test");
                Assert.That(data.Tags["env"], Is.EqualTo("test"));
            }
            Assert.That(omittedTags.Tags, Is.Not.SameAs(nullTags.Tags));
        }

        [Test]
        public void ElasticAccountFactoryPreservesResourceMetadataAndNestedEncryption()
        {
            var id = new ResourceIdentifier(ResourceGroupId + "/providers/Microsoft.NetApp/elasticAccounts/account");
            var systemData = new SystemData();
            var tags = new Dictionary<string, string> { ["purpose"] = "compatibility" };
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var keyVaultId = new ResourceIdentifier(ResourceGroupId + "/providers/Microsoft.KeyVault/vaults/vault");
            var encryptionIdentity = ArmNetAppModelFactory.ElasticEncryptionIdentity("principal", keyVaultId, "client");
            var keyVault = ArmNetAppModelFactory.ElasticKeyVaultProperties(new Uri("https://example.vault.azure.net"), "key", keyVaultId);
            var encryption = ArmNetAppModelFactory.ElasticEncryption(new NetAppKeySource("Microsoft.KeyVault"), keyVault, encryptionIdentity);
            var properties = ArmNetAppModelFactory.ElasticAccountProperties(new NetAppProvisioningState("Succeeded"), encryption);
            var eTag = new ETag("\"test-etag\"");

            NetAppElasticAccountData account = ArmNetAppModelFactory.NetAppElasticAccountData(
                id, "account", new ResourceType("Microsoft.NetApp/elasticAccounts"), systemData,
                tags, AzureLocation.WestUS2, properties, eTag, identity);

            Assert.That(account.Id, Is.EqualTo(id));
            Assert.That(account.Name, Is.EqualTo("account"));
            Assert.That(account.ResourceType, Is.EqualTo(new ResourceType("Microsoft.NetApp/elasticAccounts")));
            Assert.That(account.SystemData, Is.SameAs(systemData));
            Assert.That(account.Tags, Is.EquivalentTo(tags));
            Assert.That(account.Location, Is.EqualTo(AzureLocation.WestUS2));
            Assert.That(account.Properties, Is.SameAs(properties));
            Assert.That(account.ETag, Is.EqualTo(eTag));
            Assert.That(account.Identity, Is.SameAs(identity));
            Assert.That(properties.ProvisioningState, Is.EqualTo(new NetAppProvisioningState("Succeeded")));
            Assert.That(properties.Encryption, Is.SameAs(encryption));
            Assert.That(encryption.KeyVaultProperties, Is.SameAs(keyVault));
            Assert.That(encryption.Identity, Is.SameAs(encryptionIdentity));
            Assert.That(encryptionIdentity.PrincipalId, Is.EqualTo("principal"));
            Assert.That(encryptionIdentity.UserAssignedIdentity, Is.EqualTo(keyVaultId));
            Assert.That(encryptionIdentity.FederatedClientId, Is.EqualTo("client"));
            Assert.That(keyVault.KeyVaultUri, Is.EqualTo(new Uri("https://example.vault.azure.net")));
            Assert.That(keyVault.KeyName, Is.EqualTo("key"));
            Assert.That(keyVault.KeyVaultResourceId, Is.EqualTo(keyVaultId));
        }

        [Test]
        public void ElasticVolumeFactoryPreservesCollectionsAndNestedProperties()
        {
            var snapshotId = new ResourceIdentifier(ResourceGroupId + "/providers/Microsoft.NetApp/elasticAccounts/account/capacityPools/pool/volumes/volume/snapshots/snapshot");
            var backupId = new ResourceIdentifier(ResourceGroupId + "/providers/Microsoft.NetApp/elasticAccounts/account/backupVaults/vault/backups/backup");
            var rule = ArmNetAppModelFactory.ElasticExportPolicyRule(ruleIndex: 3, allowedClients: new[] { "10.0.0.0/24" });
            var target = ArmNetAppModelFactory.ElasticMountTargetProperties(IPAddress.Parse("10.0.0.4"), "server.example");
            var backup = ArmNetAppModelFactory.ElasticVolumeBackupProperties(snapshotId, elasticBackupVaultResourceId: backupId);
            var protection = ArmNetAppModelFactory.ElasticVolumeDataProtectionProperties(snapshotId, backup);
            var protocols = new[] { new ElasticProtocolType("NFSv3"), new ElasticProtocolType("NFSv4") };

            ElasticVolumeProperties properties = ArmNetAppModelFactory.ElasticVolumeProperties(
                "path", 1024, new[] { rule }, protocols,
                new NetAppProvisioningState("Succeeded"), new ElasticResourceAvailabilityStatus("Available"),
                snapshotId, new[] { target }, protection, new SnapshotDirectoryVisibility("Visible"),
                new ElasticSmbEncryption("Enabled"), backupId, new ElasticVolumeRestorationState("Restoring"));

            Assert.That(properties.FilePath, Is.EqualTo("path"));
            Assert.That(properties.Size, Is.EqualTo(1024));
            Assert.That(properties.ExportRules[0], Is.SameAs(rule));
            Assert.That(rule.RuleIndex, Is.EqualTo(3));
            Assert.That(rule.AllowedClients, Is.EqualTo(new[] { "10.0.0.0/24" }));
            Assert.That(properties.ProtocolTypes, Is.EqualTo(protocols));
            Assert.That(properties.ProvisioningState, Is.EqualTo(new NetAppProvisioningState("Succeeded")));
            Assert.That(properties.AvailabilityStatus, Is.EqualTo(new ElasticResourceAvailabilityStatus("Available")));
            Assert.That(properties.SnapshotResourceId, Is.EqualTo(snapshotId));
            Assert.That(properties.MountTargets[0], Is.SameAs(target));
            Assert.That(target.IpAddress, Is.EqualTo(IPAddress.Parse("10.0.0.4")));
            Assert.That(target.SmbServerFqdn, Is.EqualTo("server.example"));
            Assert.That(properties.DataProtection, Is.SameAs(protection));
            Assert.That(protection.Backup, Is.SameAs(backup));
            Assert.That(protection.SnapshotPolicyResourceId, Is.EqualTo(snapshotId));
            Assert.That(backup.ElasticBackupPolicyResourceId, Is.EqualTo(snapshotId));
            Assert.That(backup.ElasticBackupVaultResourceId, Is.EqualTo(backupId));
            Assert.That(properties.SnapshotDirectoryVisibility, Is.EqualTo(new SnapshotDirectoryVisibility("Visible")));
            Assert.That(properties.SmbEncryption, Is.EqualTo(new ElasticSmbEncryption("Enabled")));
            Assert.That(properties.BackupResourceId, Is.EqualTo(backupId));
            Assert.That(properties.RestorationState, Is.EqualTo(new ElasticVolumeRestorationState("Restoring")));
        }

        [Test]
        public void ElasticCapacityPoolFactoryPreservesZones()
        {
            var properties = ArmNetAppModelFactory.ElasticCapacityPoolProperties(
                size: 4096, totalThroughputMibps: 125.5, currentZone: "2");
            var eTag = new ETag("\"pool-etag\"");

            NetAppElasticCapacityPoolData pool = ArmNetAppModelFactory.NetAppElasticCapacityPoolData(
                location: AzureLocation.WestUS2, properties: properties, eTag: eTag, zones: new[] { "1", "2" });

            Assert.That(pool.Location, Is.EqualTo(AzureLocation.WestUS2));
            Assert.That(pool.Properties, Is.SameAs(properties));
            Assert.That(pool.ETag, Is.EqualTo(eTag));
            Assert.That(pool.Zones, Is.EqualTo(new[] { "1", "2" }));
            Assert.That(properties.Size, Is.EqualTo(4096));
            Assert.That(properties.TotalThroughputMibps, Is.EqualTo(125.5));
            Assert.That(properties.CurrentZone, Is.EqualTo("2"));
        }

        [Test]
        public void SnapshotPolicyFactoriesPreserveScheduleValues()
        {
            var hourly = ArmNetAppModelFactory.ElasticSnapshotPolicyHourlySchedule(2, 15);
            var daily = ArmNetAppModelFactory.ElasticSnapshotPolicyDailySchedule(3, 4, 20);
            var days = new[] { new Models.DayOfWeek("Monday"), new Models.DayOfWeek("Friday") };
            var weekly = ArmNetAppModelFactory.ElasticSnapshotPolicyWeeklySchedule(4, days, 5, 25);
            var monthly = ArmNetAppModelFactory.ElasticSnapshotPolicyMonthlySchedule(5, new[] { 1, 15 }, 6, 30);

            ElasticSnapshotPolicyProperties policy = ArmNetAppModelFactory.ElasticSnapshotPolicyProperties(
                hourly, daily, weekly, monthly, new ElasticSnapshotPolicyStatus("Enabled"), new NetAppProvisioningState("Succeeded"));

            Assert.That(policy.HourlySchedule, Is.SameAs(hourly));
            Assert.That(hourly.SnapshotsToKeep, Is.EqualTo(2));
            Assert.That(hourly.Minute, Is.EqualTo(15));
            Assert.That(policy.DailySchedule, Is.SameAs(daily));
            Assert.That(daily.SnapshotsToKeep, Is.EqualTo(3));
            Assert.That(daily.Hour, Is.EqualTo(4));
            Assert.That(daily.Minute, Is.EqualTo(20));
            Assert.That(policy.WeeklySchedule, Is.SameAs(weekly));
            Assert.That(weekly.SnapshotsToKeep, Is.EqualTo(4));
            Assert.That(weekly.Days, Is.EqualTo(days));
            Assert.That(weekly.Hour, Is.EqualTo(5));
            Assert.That(weekly.Minute, Is.EqualTo(25));
            Assert.That(policy.MonthlySchedule, Is.SameAs(monthly));
            Assert.That(monthly.SnapshotsToKeep, Is.EqualTo(5));
            Assert.That(monthly.DaysOfMonth, Is.EqualTo(new[] { 1, 15 }));
            Assert.That(monthly.Hour, Is.EqualTo(6));
            Assert.That(monthly.Minute, Is.EqualTo(30));
            Assert.That(policy.PolicyStatus, Is.EqualTo(new ElasticSnapshotPolicyStatus("Enabled")));
            Assert.That(policy.ProvisioningState, Is.EqualTo(new NetAppProvisioningState("Succeeded")));
        }

        [Test]
        public void SecretPasswordFactoriesPreserveArguments()
        {
            var uri = new Uri("https://example.vault.azure.net");
            var vault = ArmNetAppModelFactory.NetAppSecretPasswordKeyVaultPatchProperties(uri, "secret");
            var identity = ArmNetAppModelFactory.NetAppSecretPasswordIdentity("principal", "identity");

            NetAppSecretPassword password = ArmNetAppModelFactory.NetAppSecretPassword(vault, identity);

            Assert.That(password.KeyVaultProperties, Is.SameAs(vault));
            Assert.That(vault.KeyVaultUri, Is.EqualTo(uri));
            Assert.That(vault.SecretName, Is.EqualTo("secret"));
            Assert.That(password.Identity, Is.SameAs(identity));
            Assert.That(identity.PrincipalId, Is.EqualTo("principal"));
            Assert.That(identity.UserAssignedIdentity, Is.EqualTo("identity"));
        }
    }
}
