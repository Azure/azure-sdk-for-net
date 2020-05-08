// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Storage.Sas;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobUriBuilderTests : BlobTestBase
    {
        public BlobUriBuilderTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void BlobUriBuilder_RoundTrip()
        {
            BlobServiceClient service = GetServiceClient_AccountSas();
            var blobUriBuilder = new BlobUriBuilder(service.Uri);

            Uri blobUri = blobUriBuilder.ToUri();

            var expectedUri = WebUtility.UrlDecode(service.Uri.AbsoluteUri);
            var actualUri = WebUtility.UrlDecode(blobUri.AbsoluteUri);

            Assert.AreEqual(expectedUri, actualUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("comp=list", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_ContainerTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/container";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_BlobTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/container/blob";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_PortTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net:8080/container";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(8080, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_SnapshotTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/container/blob?snapshot=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_VersionIdTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/container/blob?versionid=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", blobUriBuilder.VersionId);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_SasTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/container/blob?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), blobUriBuilder.Sas.ExpiresOn);
            Assert.AreEqual("", blobUriBuilder.Sas.Identifier);
            Assert.AreEqual(SasIPRange.Parse("168.1.5.60-168.1.5.70"), blobUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", blobUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, blobUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", blobUriBuilder.Sas.Resource);
            Assert.IsNull(blobUriBuilder.Sas.ResourceTypes);
            Assert.IsNull(blobUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", blobUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), blobUriBuilder.Sas.StartsOn);
            Assert.AreEqual("2015-04-05", blobUriBuilder.Sas.Version);

            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }


        [Test]
        public void BlobUriBuilder_RegularUrl_CNAME()
        {
            var blobUriBuilder = new BlobUriBuilder(new Uri("http://www.contoso.com"));
            Assert.AreEqual(string.Empty, blobUriBuilder.AccountName);
        }

        [Test]
        public void BlobUriBuilder_RegularUrl_MalformedSubdomain()
        {
            // core and blob swapped
            var blobUriBuilder1 = new BlobUriBuilder(new Uri("https://account.core.blob.windows.net/container/blob"));

            // account and blob swapped
            var blobUriBuilder2 = new BlobUriBuilder(new Uri("https://blob.account.core.windows.net/container/blob"));

            // wrong service
            var blobUriBuilder3 = new BlobUriBuilder(new Uri("https://account.file.core.windows.net/container/blob"));

            // empty service
            var blobUriBuilder4 = new BlobUriBuilder(new Uri("https://account./container/blob"));

            Assert.AreEqual(string.Empty, blobUriBuilder1.AccountName);
            Assert.AreEqual(string.Empty, blobUriBuilder2.AccountName);
            Assert.AreEqual(string.Empty, blobUriBuilder3.AccountName);
            Assert.AreEqual(string.Empty, blobUriBuilder4.AccountName);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_AccountTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("comp=list", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_ContainerTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/container";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_BlobTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/container/blob";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_PortTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account/container";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(8080, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_SnapshotTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/container/blob?snapshot=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_VersionIdTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/container/blob?versionid=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("2011-03-09T01:42:34.9360000Z", blobUriBuilder.VersionId);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_IPStyleUrl_SasTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1/account/container/blob?sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("127.0.0.1", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);

            Assert.AreEqual(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero), blobUriBuilder.Sas.ExpiresOn);
            Assert.AreEqual("", blobUriBuilder.Sas.Identifier);
            Assert.AreEqual(SasIPRange.Parse("168.1.5.60-168.1.5.70"), blobUriBuilder.Sas.IPRange);
            Assert.AreEqual("rw", blobUriBuilder.Sas.Permissions);
            Assert.AreEqual(SasProtocol.Https, blobUriBuilder.Sas.Protocol);
            Assert.AreEqual("b", blobUriBuilder.Sas.Resource);
            Assert.IsNull(blobUriBuilder.Sas.ResourceTypes);
            Assert.IsNull(blobUriBuilder.Sas.Services);
            Assert.AreEqual("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk=", blobUriBuilder.Sas.Signature);
            Assert.AreEqual(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero), blobUriBuilder.Sas.StartsOn);
            Assert.AreEqual("2015-04-05", blobUriBuilder.Sas.Version);

            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }
    }
}
