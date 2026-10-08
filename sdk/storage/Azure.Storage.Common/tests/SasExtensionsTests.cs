// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Net;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    [TestFixture]
    public class SasExtensionsTests
    {
        [Test]
        public void AccountSasPermission_Round_Trip()
        {
            AccountSasServices services = SasExtensions.ParseAccountServices("bfqt");
            Assert.IsTrue(services.HasFlag(AccountSasServices.Blobs));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Files));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Queues));
            Assert.IsTrue(services.HasFlag(AccountSasServices.Tables));
            Assert.AreEqual(services.ToPermissionsString(), "bfqt");
        }

        [Test]
        public void AccountSasBuilder_ToSasQueryParameters_NormalizesDateTimesToUtc()
        {
            DateTimeOffset startsOn = new DateTimeOffset(2026, 01, 01, 10, 00, 00, TimeSpan.FromHours(3));
            DateTimeOffset expiresOn = new DateTimeOffset(2026, 01, 01, 13, 30, 00, TimeSpan.FromHours(3));

            AccountSasBuilder builder = new AccountSasBuilder
            {
                StartsOn = startsOn,
                ExpiresOn = expiresOn,
                Services = AccountSasServices.Blobs,
                ResourceTypes = AccountSasResourceTypes.Object
            };
            builder.SetPermissions(AccountSasPermissions.Read);

            StorageSharedKeyCredential credential = new StorageSharedKeyCredential("account", Convert.ToBase64String(new byte[32]));

            string query = builder.ToSasQueryParameters(credential).ToString();
            string expectedStart = WebUtility.UrlEncode(startsOn.ToUniversalTime().ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture));
            string expectedExpiry = WebUtility.UrlEncode(expiresOn.ToUniversalTime().ToString(Constants.SasTimeFormatSeconds, CultureInfo.InvariantCulture));

            StringAssert.Contains($"st={expectedStart}", query);
            StringAssert.Contains($"se={expectedExpiry}", query);
        }
    }
}
