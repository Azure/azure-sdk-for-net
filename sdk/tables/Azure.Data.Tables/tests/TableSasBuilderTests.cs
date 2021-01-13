// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Data.Tables.Test
{
    public class TableSasBuilderTests
    {
        [Test]
        public void ValidatesArgs()
        {
            Assert.Throws<ArgumentNullException>(() => new TableSasBuilder(null, TableSasPermissions.Add, DateTimeOffset.Now));
            Assert.Throws<ArgumentException>(() => new TableSasBuilder(string.Empty, TableSasPermissions.Add, DateTimeOffset.Now));
            Assert.Throws<ArgumentNullException>(() => new TableSasBuilder("table", null, DateTimeOffset.Now));
            Assert.Throws<ArgumentException>(() => new TableSasBuilder("table", string.Empty, DateTimeOffset.Now));
            Assert.Throws<ArgumentNullException>(() => new TableSasBuilder(null));
        }

        public static IEnumerable<object[]> UriInputs()
        {
            yield return new object[] { new Uri("https://account.core.table.windows.net/table?tn=table&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D") };
            yield return new object[] { new Uri("https://127.0.0.1/account/table?tn=table&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D") };
        }

        [Test]
        [TestCaseSource(nameof(UriInputs))]
        public void ParseUri(Uri uri)
        {
            // Act
            var tableSasBuilder = new TableSasBuilder(uri);

            // Assert
            Assert.AreEqual(TableSasProtocol.Https, tableSasBuilder.Protocol);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), tableSasBuilder.ExpiresOn);
            Assert.AreEqual("", tableSasBuilder.Identifier);
            Assert.AreEqual(TableSasIPRange.Parse("168.1.5.60-168.1.5.70"), tableSasBuilder.IPRange);
            Assert.AreEqual("rw", tableSasBuilder.Permissions);
            Assert.AreEqual(TableSasProtocol.Https, tableSasBuilder.Protocol);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), tableSasBuilder.StartsOn);
            Assert.AreEqual("2015-04-05", tableSasBuilder.Version);
        }
        [Test]
        [TestCase(new object[] { "r", TableSasPermissions.Read })]
        [TestCase(new object[] { "rd", TableSasPermissions.Read | TableSasPermissions.Delete })]
        [TestCase(new object[] { "u", TableSasPermissions.Update })]
        [TestCase(new object[] { "raud", TableSasPermissions.All })]
        public void SetPermissions(string permissionsString, TableSasPermissions permissions)
        {
            var tableSasBuilder = new TableSasBuilder("table", permissionsString, DateTimeOffset.Now);

            Assert.That(tableSasBuilder.Permissions, Is.EqualTo(permissionsString));

            tableSasBuilder.SetPermissions(permissions);

            Assert.That(tableSasBuilder.Permissions, Is.EqualTo(permissionsString));
        }
    }
}
