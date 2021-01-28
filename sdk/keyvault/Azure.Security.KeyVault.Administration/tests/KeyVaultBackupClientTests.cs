// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Security.KeyVault.Administration.Models;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    [TestFixture]
    public class KeyVaultBackupClientTests
    {
        private const string folderUri = "https://contoso.blob.core.windows.net/backups";
        public static readonly object[] s_folderUris =
        {
            new object[]{ $"{folderUri}/mhsm-foo-2020120716295228", folderUri, "mhsm-foo-2020120716295228" },
            new object[]{ $"{folderUri}/foo/bar/mhsm-foo-2020120716295228", folderUri, "foo/bar/mhsm-foo-2020120716295228" },
            new object[]{ $"{folderUri}/foo/bar/fizz/mhsm-foo-2020120716295228", folderUri, "foo/bar/fizz/mhsm-foo-2020120716295228" },
            new object[]{ $"{folderUri}/foo/bar/fizz/buzz/mhsm-foo-2020120716295228", folderUri, "foo/bar/fizz/buzz/mhsm-foo-2020120716295228" },
        };

        [Test]
        [TestCaseSource("s_folderUris")]
        public void ParseFolderName(string uri, string expectedUri, string expectedFolder)
        {
            var folderUri = new Uri(uri);
            KeyVaultBackupClient.ParseFolderName(folderUri, out string containerUriString, out string folderName);

            Assert.That(containerUriString, Is.EqualTo(expectedUri));
            Assert.That(folderName, Is.EqualTo(expectedFolder));
        }
    }
}
