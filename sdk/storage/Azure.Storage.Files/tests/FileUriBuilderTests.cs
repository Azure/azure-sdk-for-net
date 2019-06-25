// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Files.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Test
{
    [TestFixture]
    public class FileUriBuilderTests : FileTestBase
    {
        public FileUriBuilderTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        //TODO address the flakiness of this test.
        [Test]
        public void FileUriBuilder_RoundTrip()
        {
            var serviceUri = this.GetServiceClient_AccountSas();
            var blobUriBuilder = new FileUriBuilder(serviceUri.Uri);

            var blobUri = blobUriBuilder.ToUri();

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
            var fileUriBuilder = new FileUriBuilder(originalUri.Uri);
            var newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("comp=list", fileUriBuilder.UnparsedParams);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_ShareTest()
        {
            // Arrange
            var uriString = "https://account.core.file.windows.net/share?restype=share";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new FileUriBuilder(originalUri.Uri);
            var newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.core.file.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("restype=share", fileUriBuilder.UnparsedParams);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_PathTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share/path?restype=directory&comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new FileUriBuilder(originalUri.Uri);
            var newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("path", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("restype=directory&comp=list", fileUriBuilder.UnparsedParams);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_SnapshotTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share?snapshot=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new FileUriBuilder(originalUri.Uri);
            var newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", fileUriBuilder.Snapshot);
            Assert.IsNull(fileUriBuilder.Sas);
            Assert.AreEqual("", fileUriBuilder.UnparsedParams);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void FileUriBuilder_SasTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share?comp=list&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new FileUriBuilder(originalUri.Uri);
            var newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual(443, fileUriBuilder.Port);
            Assert.AreEqual("share", fileUriBuilder.ShareName);
            Assert.AreEqual("", fileUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", fileUriBuilder.Snapshot);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), fileUriBuilder.Sas.ExpiryTime);
            Assert.AreEqual("", fileUriBuilder.Sas.Identifier);
            Assert.AreEqual(IPRange.Parse("168.1.5.60-168.1.5.70"), fileUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", fileUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, fileUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", fileUriBuilder.Sas.Resource);
            Assert.AreEqual("", fileUriBuilder.Sas.ResourceTypes);
            Assert.AreEqual("", fileUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", fileUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), fileUriBuilder.Sas.StartTime);
            Assert.AreEqual("2015-04-05", fileUriBuilder.Sas.Version);

            Assert.AreEqual("comp=list", fileUriBuilder.UnparsedParams);

            Assert.AreEqual(originalUri, newUri);
        }
    }
}
