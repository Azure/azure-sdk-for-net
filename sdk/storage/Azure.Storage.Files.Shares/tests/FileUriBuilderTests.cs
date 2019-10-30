// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.Testing;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Sas;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class FileUriBuilderTests : FileTestBase
    {
        public FileUriBuilderTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        //TODO address the flakiness of this test.
        [Test]
        public void FileUriBuilder_RoundTrip()
        {
            ShareServiceClient serviceUri = GetServiceClient_AccountSas();
            var blobUriBuilder = new ShareUriBuilder(serviceUri.Uri);

            Uri blobUri = blobUriBuilder.ToUri();

            var expectedUri = WebUtility.UrlDecode(serviceUri.Uri.AbsoluteUri);
            var actualUri = WebUtility.UrlDecode(blobUri.AbsoluteUri);

            Assert.AreEqual(expectedUri, actualUri, "Flaky test -- potential signature generation issue not properly encoding space and + in the output");
        }

        [Test]
        public void FileUriBuilder_AccountTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("comp=list", fileUriBuilder.Query);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_ShareTest()
        {
            // Arrange
            var uriString = "https://account.core.file.windows.net/share?restype=share";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.core.file.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("restype=share", fileUriBuilder.Query);
            Assert.AreEqual(originalUri, newUri);
            Assert.AreEqual(string.Empty, fileUriBuilder.LastDirectoryOrFileName);
        }

        [Test]
        public void FileUriBuilder_PathTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share/path?restype=directory&comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("path", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("path", fileUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("restype=directory&comp=list", fileUriBuilder.Query);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_PathTrailingSlash()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share/path/?restype=directory&comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Assert.AreEqual("path", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("path", fileUriBuilder.LastDirectoryOrFileName);
        }

        [Test]
        public void FileUriBuilder_SnapshotTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share?snapshot=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("", fileUriBuilder.Query);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_SasTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share?comp=list&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), fileUriBuilder.Sas.ExpiresOn);
            Assert.AreEqual("", fileUriBuilder.Sas.Identifier);
            Assert.AreEqual(SasIPRange.Parse("168.1.5.60-168.1.5.70"), fileUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", fileUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, fileUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", fileUriBuilder.Sas.Resource);
            Assert.IsNull(fileUriBuilder.Sas.ResourceTypes);
            Assert.IsNull(fileUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", fileUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), fileUriBuilder.Sas.StartsOn);
            Assert.AreEqual("2015-04-05", fileUriBuilder.Sas.Version);

            Assert.AreEqual("comp=list", fileUriBuilder.Query);

            Assert.AreEqual(originalUri, newUri);
        }
    }
}
