// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var dataSourceInfo = new DataSourceInfo(new ResourceIdentifier("/subs/id"));
            var dataSourceSetInfo = new DataSourceSetInfo(new ResourceIdentifier("/subs/id"));

#pragma warning disable CS0618 // Type or member is obsolete
            Assert.IsNull(dataSourceInfo.ResourceUri);
            Assert.IsNull(dataSourceSetInfo.ResourceUri);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
