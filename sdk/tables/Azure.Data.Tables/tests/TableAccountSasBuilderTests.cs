// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Data.Tables.Test
{
    public class TableAccountSasBuilderTests
    {
        [Test]
        public void ValidatesArgs()
        {
            Assert.Throws<ArgumentNullException>(() => new TableAccountSasBuilder(null, TableAccountSasResourceTypes.All, DateTimeOffset.Now));
            Assert.Throws<ArgumentException>(() => new TableAccountSasBuilder(string.Empty, TableAccountSasResourceTypes.All, DateTimeOffset.Now));
            Assert.Throws<ArgumentNullException>(() => new TableAccountSasBuilder(null));

            var uriWithoutResourceTypes = new Uri("https://account.core.table.windows.net/table?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D");
            Assert.Throws<ArgumentException>(() => new TableAccountSasBuilder(uriWithoutResourceTypes));
        }

        public static IEnumerable<object[]> UriInputs()
        {
            yield return new object[] { new Uri("https://account.core.table.windows.net/table?srt=s&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D") };
            yield return new object[] { new Uri("https://127.0.0.1/account/table?srt=s&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D") };
        }

        [Test]
        [TestCaseSource(nameof(UriInputs))]
        public void ParseUri(Uri uri)
        {
            // Act
            var TableAccountSasBuilder = new TableAccountSasBuilder(uri);

            // Assert
            Assert.AreEqual(TableSasProtocol.Https, TableAccountSasBuilder.Protocol);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), TableAccountSasBuilder.ExpiresOn);
            Assert.AreEqual("", TableAccountSasBuilder.Identifier);
            Assert.AreEqual(TableSasIPRange.Parse("168.1.5.60-168.1.5.70"), TableAccountSasBuilder.IPRange);
            Assert.AreEqual("rw", TableAccountSasBuilder.Permissions);
            Assert.AreEqual(TableAccountSasResourceTypes.Service, TableAccountSasBuilder.ResourceTypes);
            Assert.AreEqual(TableSasProtocol.Https, TableAccountSasBuilder.Protocol);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), TableAccountSasBuilder.StartsOn);
            Assert.AreEqual("2015-04-05", TableAccountSasBuilder.Version);
        }
        [Test]
        [TestCase(new object[] { "r", TableAccountSasPermissions.Read, TableAccountSasResourceTypes.Container })]
        [TestCase(new object[] { "rd", TableAccountSasPermissions.Read | TableAccountSasPermissions.Delete, TableAccountSasResourceTypes.Container })]
        [TestCase(new object[] { "u", TableAccountSasPermissions.Update, TableAccountSasResourceTypes.Container })]
        [TestCase(new object[] { "rwdlau", TableAccountSasPermissions.All, TableAccountSasResourceTypes.Container })]
        public void SetPermissions(string permissionsString, TableAccountSasPermissions permissions, TableAccountSasResourceTypes resourceTypes)
        {
            var TableAccountSasBuilder = new TableAccountSasBuilder(permissionsString, resourceTypes, DateTimeOffset.Now);

            Assert.That(TableAccountSasBuilder.Permissions, Is.EqualTo(permissionsString));

            TableAccountSasBuilder.SetPermissions(permissions);

            Assert.That(TableAccountSasBuilder.Permissions, Is.EqualTo(permissionsString));
        }
    }
}
