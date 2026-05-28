// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
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
            yield return new object[]
            {
                new Uri(
                    "https://account.core.table.windows.net/table?tn=table&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D")
            };
            yield return new object[]
            {
                new Uri(
                    "https://127.0.0.1/account/table?tn=table&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D")
            };
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
        [TestCase(new object[] { "tablename", "r", TableSasPermissions.Read })]
        [TestCase(new object[] { "tablename", "rd", TableSasPermissions.Read | TableSasPermissions.Delete })]
        [TestCase(new object[] { "tablename", "u", TableSasPermissions.Update })]
        [TestCase(new object[] { "tablename", "raud", TableSasPermissions.All })]
        [TestCase(new object[] { "TABLENAME", "RAUD", TableSasPermissions.All })]
        public void SetPermissions(string tableName, string permissionsString, TableSasPermissions permissions)
        {
            var tableSasBuilder = new TableSasBuilder(tableName, permissionsString, DateTimeOffset.Now);

            Assert.AreEqual(permissionsString.ToLowerInvariant(), tableSasBuilder.Permissions);

            tableSasBuilder.SetPermissions(permissions);

            Assert.AreEqual(permissionsString.ToLowerInvariant(), tableSasBuilder.Permissions);
            Assert.AreEqual(tableName, tableSasBuilder.TableName);
        }

        [Test]
        public void UseParameterlessCtor()
        {
            var now = DateTimeOffset.Now;
            var tableSasBuilder = new TableSasBuilder
            {
                TableName = "table",
                ExpiresOn = now.AddHours(1)
            };
            tableSasBuilder.SetPermissions(TableSasPermissions.Read);

            Assert.AreEqual("table", tableSasBuilder.TableName);
            Assert.AreEqual("r", tableSasBuilder.Permissions);
            Assert.AreEqual(now.AddHours(1), tableSasBuilder.ExpiresOn);
        }
    }
}
