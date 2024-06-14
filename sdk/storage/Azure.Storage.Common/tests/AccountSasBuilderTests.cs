// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class AccountSasBuilderTests
    {
        [Test]
        public void GetStringToSign()
        {
            // Arrange
            string accountName = "accountname";

            // This is not a real account key.  This is here for testing purposes only.  This is not a security issue.
            string accountKey = "dGVzdHRlc3R0ZXN0";

            DateTimeOffset expiresOn = new DateTimeOffset(2024, 6, 14, 10, 59, 2, TimeSpan.Zero);
            DateTimeOffset startsOn = new DateTimeOffset(2024, 5, 13, 9, 58, 1, TimeSpan.Zero);

            AccountSasBuilder sasBuilder = new AccountSasBuilder(
                AccountSasPermissions.All,
                expiresOn: expiresOn,
                AccountSasServices.All,
                AccountSasResourceTypes.All);

            sasBuilder.Version = "2024-11-03";
            sasBuilder.Protocol = SasProtocol.Https;
            sasBuilder.StartsOn = startsOn;
            sasBuilder.IPRange = new SasIPRange(
                start: IPAddress.Parse("1.1.1.1"),
                end: IPAddress.Parse("2.2.2.2"));
            sasBuilder.EncryptionScope = "encryptionScope";

            // Act
            string stringToSign = sasBuilder.GetStringToSign(new StorageSharedKeyCredential(accountName, accountKey));

            // Assert
            Assert.AreEqual(
                "accountname\nrwdxylacuptfi\nbfqt\nsco\n2024-05-13T09:58:01Z\n2024-06-14T10:59:02Z\n1.1.1.1-2.2.2.2\nhttps\n2024-11-04\nencryptionScope\n",
                stringToSign);
        }
    }
}
