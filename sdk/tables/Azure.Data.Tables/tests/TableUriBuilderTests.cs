// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Data.Tables.Sas;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("account.core.table.windows.net"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo("comp=list"));

                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("account.core.table.windows.net"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo(""));
                Assert.That(tableuribuilder.Tablename, Is.EqualTo("table"));
                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("account.core.table.windows.net"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(8080));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo(""));
                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("account.core.table.windows.net"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.Sas.ExpiresOn, Is.EqualTo(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero)));
                Assert.That(tableuribuilder.Sas.Identifier, Is.EqualTo(""));
                Assert.That(tableuribuilder.Sas.IPRange, Is.EqualTo(TableSasIPRange.Parse("168.1.5.60-168.1.5.70")));
                Assert.That(tableuribuilder.Sas.Permissions, Is.EqualTo("rw"));
                Assert.That(tableuribuilder.Sas.Protocol, Is.EqualTo(TableSasProtocol.Https));
                Assert.That(tableuribuilder.Sas.Resource, Is.EqualTo("b"));
                Assert.That(tableuribuilder.Sas.ResourceTypes, Is.Null);
                Assert.That(tableuribuilder.Sas.Signature, Is.EqualTo("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk="));
                Assert.That(tableuribuilder.Sas.StartsOn, Is.EqualTo(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero)));
                Assert.That(tableuribuilder.Sas.Version, Is.EqualTo("2015-04-05"));

                Assert.That(tableuribuilder.Query, Is.EqualTo(""));

                Assert.That(newUri.ToString(), Is.EqualTo(originalUri.Uri.ToString()));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("127.0.0.1"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.AccountName, Is.EqualTo("account"));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo("comp=list"));
                Assert.That(tableuribuilder.Tablename, Is.EqualTo(""));
                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("127.0.0.1"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.AccountName, Is.EqualTo("account"));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo(""));

                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("127.0.0.1"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(8080));
                Assert.That(tableuribuilder.AccountName, Is.EqualTo("account"));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo(""));

                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("127.0.0.1"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.AccountName, Is.EqualTo("account"));
                Assert.That(tableuribuilder.Sas, Is.Null);
                Assert.That(tableuribuilder.Query, Is.EqualTo(""));

                Assert.That(newUri, Is.EqualTo(originalUri));
            });
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

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(tableuribuilder.Scheme, Is.EqualTo("https"));
                Assert.That(tableuribuilder.Host, Is.EqualTo("127.0.0.1"));
                Assert.That(tableuribuilder.Port, Is.EqualTo(443));
                Assert.That(tableuribuilder.AccountName, Is.EqualTo("account"));

                Assert.That(tableuribuilder.Sas.ExpiresOn, Is.EqualTo(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero)));
                Assert.That(tableuribuilder.Sas.Identifier, Is.EqualTo(""));
                Assert.That(tableuribuilder.Sas.IPRange, Is.EqualTo(TableSasIPRange.Parse("168.1.5.60-168.1.5.70")));
                Assert.That(tableuribuilder.Sas.Permissions, Is.EqualTo("rw"));
                Assert.That(tableuribuilder.Sas.Protocol, Is.EqualTo(TableSasProtocol.Https));
                Assert.That(tableuribuilder.Sas.Resource, Is.EqualTo("b"));
                Assert.That(tableuribuilder.Sas.ResourceTypes, Is.Null);
                Assert.That(tableuribuilder.Sas.Signature, Is.EqualTo("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk="));
                Assert.That(tableuribuilder.Sas.StartsOn, Is.EqualTo(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero)));
                Assert.That(tableuribuilder.Sas.Version, Is.EqualTo("2015-04-05"));

                Assert.That(tableuribuilder.Query, Is.EqualTo(""));

                Assert.That(newUri, Is.EqualTo(originalUri));
            });
        }

        [Test]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void TableBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.table.core.windows.net/table?tn=tablename&sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");
            TableUriBuilder tableuribuilder = new TableUriBuilder(initialUri);

            // Act
            Uri resultUri = tableuribuilder.ToUri();

            Assert.Multiple(() =>
            {
                // Assert
                Assert.That(resultUri.ToString(), Is.EqualTo(initialUri.ToString()));
                Assert.That(resultUri.PathAndQuery, Does.Contain($"st={WebUtility.UrlEncode(startTime)}"));
            });
            Assert.That(resultUri.PathAndQuery, Does.Contain($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [Test]
        public void TableUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.table.core.windows.net/table?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");

            // Act
            try
            {
                new TableUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.That(e.Message, Does.Contain("was not recognized as a valid DateTime."));
            }
        }
    }
}
