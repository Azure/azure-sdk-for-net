// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Storage.Sas;
using Azure.Storage.Test;
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
        public void BlobUriBuilder_LocalDockerUrl_PortTest()
        {
            // Arrange
            // BlobEndpoint from https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator#connect-to-the-emulator-account-using-the-well-known-account-name-and-key
            var uriString = "http://docker_container:10000/devstoreaccount1/containername";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("docker_container", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("containername", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void BlobUriBuilder_CustomUri_AccountContainerBlobTest()
        {
            // Arrange
            var uriString = "https://www.mycustomname.com/containername/blobname";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("www.mycustomname.com", blobUriBuilder.Host);
            Assert.AreEqual(String.Empty, blobUriBuilder.AccountName);
            Assert.AreEqual("containername", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blobname", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);

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

        [Test]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void BlobUriBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.blob.core.windows.net/container/blob?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(initialUri);

            // Act
            Uri resultUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual(initialUri, resultUri);
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [Test]
        public void BlobUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.blob.core.windows.net/container/blob?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");

            // Act
            try
            {
                new BlobUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.IsTrue(e.Message.Contains("was not recognized as a valid DateTime."));
            }
        }
    }
}
