// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.DataProtectionBackup;
using Azure.Core;
using Azure.ResourceManager.DataProtectionBackup.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataProtectionBackup.Tests.Unit
{
    public class BackupVaultTests
    {
        [TestCase]
        public void ValidateDataSourceInfo()
        {
            var dataSourceInfo = new DataSourceInfo(new ResourceIdentifier("/subs/id"))
            {
                ResourceUriString = "/sub/test"
            };
            var dataSourceSetInfo = new DataSourceSetInfo(new ResourceIdentifier("/subs/id"))
            {
                ResourceUriString = "/sub/test"
            };

#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNull(dataSourceInfo.ResourceUri);
            Assert.IsNull(dataSourceSetInfo.ResourceUri);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.AreEqual("/sub/test", dataSourceInfo.ResourceUriString);
            Assert.NotNull("/sub/test", dataSourceSetInfo.ResourceUriString);
        }

        [Test]
        public void DeserializeBackupJobWithConstantDuration()
        {
            BinaryData payload = new BinaryData(
                "{\"activityID\":\"activity\",\"backupInstanceFriendlyName\":\"instance\",\"dataSourceId\":\"/subscriptions/subscriptions/resourceGroups/group/providers/Microsoft.Storage/storageAccounts/account\",\"dataSourceLocation\":\"eastus\",\"dataSourceName\":\"source\",\"dataSourceType\":\"type\",\"duration\":\"00:34:34.9902732\",\"isUserTriggered\":false,\"operation\":\"Backup\",\"operationCategory\":\"Backup\",\"progressEnabled\":false,\"sourceResourceGroup\":\"group\",\"sourceSubscriptionId\":\"subscription\",\"startTime\":\"2026-01-01T00:00:00Z\",\"status\":\"Completed\",\"subscriptionId\":\"subscription\",\"supportedActions\":[],\"vaultName\":\"vault\"}");

            DataProtectionBackupJobProperties job = ModelReaderWriter.Read<DataProtectionBackupJobProperties>(
                payload,
                ModelReaderWriterOptions.Json,
                AzureResourceManagerDataProtectionBackupContext.Default);

            Assert.That(job.Duration, Is.EqualTo(TimeSpan.Parse("00:34:34.9902732")));
        }
    }
}
