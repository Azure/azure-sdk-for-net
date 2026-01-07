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
            var dataSourceInfo = new DataSourceInfo(new ResourceIdentifier("/subs/id"))
            {
                ResourceUriString = "/sub/test"
            };
            var dataSourceSetInfo = new DataSourceSetInfo(new ResourceIdentifier("/subs/id"))
            {
                ResourceUriString = "/sub/test"
            };

#pragma warning disable CS0618 // Type or member is obsolete
            Assert.That(dataSourceInfo.ResourceUri, Is.Null);
            Assert.That(dataSourceSetInfo.ResourceUri, Is.Null);
#pragma warning restore CS0618 // Type or member is obsolete
            Assert.That(dataSourceInfo.ResourceUriString, Is.EqualTo("/sub/test"));
            Assert.That("/sub/test", Is.Not.Null, dataSourceSetInfo.ResourceUriString);
        }
    }
}
