// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Data.Tables.Test
{
    public class TableUriBuilderTests
    {
        [Test]
        public void TableUriBuilder_RegularUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://account.core.table.windows.net?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("account.core.table.windows.net", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("comp=list", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_RegularUrl_TableTest()
        {
            // Arrange
            var uriString = "https://account.core.table.windows.net/table";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("account.core.table.windows.net", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_RegularUrl_PortTest()
        {
            // Arrange
            var uriString = "https://account.core.table.windows.net:8080/table";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("account.core.table.windows.net", tableuribuilder.Host);
            Assert.AreEqual(8080, tableuribuilder.Port);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("", tableuribuilder.Query);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_RegularUrl_SasTest()
        {
            // Arrange
            var uriString = "https://account.core.table.windows.net/table?tn=table&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("account.core.table.windows.net", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), tableuribuilder.Sas.ExpiresOn);
            Assert.AreEqual("", tableuribuilder.Sas.Identifier);
            Assert.AreEqual(TableSasIPRange.Parse("168.1.5.60-168.1.5.70"), tableuribuilder.Sas.IPRange);
            Assert.AreEqual("rw", tableuribuilder.Sas.Permissions);
            Assert.AreEqual(TableSasProtocol.Https, tableuribuilder.Sas.Protocol);
            Assert.AreEqual("b", tableuribuilder.Sas.Resource);
            Assert.IsNull(tableuribuilder.Sas.ResourceTypes);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", tableuribuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), tableuribuilder.Sas.StartsOn);
            Assert.AreEqual("2015-04-05", tableuribuilder.Sas.Version);

            Assert.AreEqual("", tableuribuilder.Query);

            Assert.That(newUri.ToString(), Is.EqualTo(originalUri.Uri.ToString()));
        }

        [Test]
        public void TableUriBuilder_IPStyleUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("127.0.0.1", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.AreEqual("account", tableuribuilder.AccountName);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("comp=list", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_IPStyleUrl_TableTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/table";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("127.0.0.1", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.AreEqual("account", tableuribuilder.AccountName);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_IPStyleUrl_PortTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account/table";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("127.0.0.1", tableuribuilder.Host);
            Assert.AreEqual(8080, tableuribuilder.Port);
            Assert.AreEqual("account", tableuribuilder.AccountName);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_IPStyleUrl_AccountOnlyTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("127.0.0.1", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.AreEqual("account", tableuribuilder.AccountName);
            Assert.IsNull(tableuribuilder.Sas);
            Assert.AreEqual("", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void TableUriBuilder_IPStyleUrl_SasTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/table?tn=table&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var tableuribuilder = new TableUriBuilder(originalUri.Uri);
            Uri newUri = tableuribuilder.ToUri();

            // Assert
            Assert.AreEqual("https", tableuribuilder.Scheme);
            Assert.AreEqual("127.0.0.1", tableuribuilder.Host);
            Assert.AreEqual(443, tableuribuilder.Port);
            Assert.AreEqual("account", tableuribuilder.AccountName);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), tableuribuilder.Sas.ExpiresOn);
            Assert.AreEqual("", tableuribuilder.Sas.Identifier);
            Assert.AreEqual(TableSasIPRange.Parse("168.1.5.60-168.1.5.70"), tableuribuilder.Sas.IPRange);
            Assert.AreEqual("rw", tableuribuilder.Sas.Permissions);
            Assert.AreEqual(TableSasProtocol.Https, tableuribuilder.Sas.Protocol);
            Assert.AreEqual("b", tableuribuilder.Sas.Resource);
            Assert.IsNull(tableuribuilder.Sas.ResourceTypes);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", tableuribuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), tableuribuilder.Sas.StartsOn);
            Assert.AreEqual("2015-04-05", tableuribuilder.Sas.Version);

            Assert.AreEqual("", tableuribuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void TableBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.table.core.windows.net/table?tn=tablename&sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");
            TableUriBuilder tableuribuilder = new TableUriBuilder(initialUri);

            // Act
            Uri resultUri = tableuribuilder.ToUri();

            // Assert
            Assert.That(resultUri.ToString(), Is.EqualTo(initialUri.ToString()));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [Test]
        public void TableUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.table.core.windows.net/table?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");

            // Act
            try
            {
                new TableUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.IsTrue(e.Message.Contains("was not recognized as a valid DateTime."));
            }
        }
    }
}
