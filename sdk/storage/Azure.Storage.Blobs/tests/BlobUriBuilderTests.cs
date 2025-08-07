// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
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

        [RecordedTest]
        public void BlobUriBuilder_RoundTrip()
        {
            BlobServiceClient service = GetServiceClient_AccountSas();
            var blobUriBuilder = new BlobUriBuilder(service.Uri);

            Uri blobUri = blobUriBuilder.ToUri();

            var expectedUri = WebUtility.UrlDecode(service.Uri.AbsoluteUri);
            var actualUri = WebUtility.UrlDecode(blobUri.AbsoluteUri);

            Assert.AreEqual(expectedUri, actualUri);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        [Combinatorial]
        public void BlobUriBuilder_OuterSlashes_ConstructorTest(
            [Values(true, false)] bool trimsSlash,
            [Values("foo/bar", "/foo/bar/", "/////foo/bar", "foo/bar/////")] string blobName
        )
        {
            // Arrange
            const string trimmedName = "foo/bar";
            var containerUriString = "https://account.blob.core.windows.net/container";
            var originalUri = new UriBuilder(containerUriString + "/" + blobName);
            var noSlashUri = new UriBuilder(containerUriString + "/" + trimmedName);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri, trimBlobNameSlashes: trimsSlash);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            // blob name was trimmed when set via constructor uri
            if (trimsSlash)
            {
                Assert.AreEqual(trimmedName, blobUriBuilder.BlobName);
            }
            else
            {
                Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            }
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            if (trimsSlash)
            {
                Assert.AreEqual(noSlashUri, newUri);
            }
            else
            {
                Assert.AreEqual(originalUri, newUri);
            }
        }

        [RecordedTest]
        [Combinatorial]
        public void BlobUriBuilder_OuterSlashes_PropertyTest(
            [Values(true, false)] bool trimsSlash,
            [Values("foo/bar", "/foo/bar/", "/////foo/bar", "foo/bar/////")] string blobName
        )
        {
            // Arrange
            const string trimmedName = "foo/bar";
            var containerUriString = "https://account.blob.core.windows.net/container";
            var originalUri = new UriBuilder(containerUriString + "/" + blobName);
            var noSlashUri = new UriBuilder(containerUriString + "/" + trimmedName);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri, trimBlobNameSlashes: trimsSlash)
            {
                BlobName = blobName
            };
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            // blob name was NOT trimmed when set via property
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            if (trimsSlash)
            {
                Assert.AreEqual(noSlashUri, newUri);
            }
            else
            {
                Assert.AreEqual(originalUri, newUri);
            }
        }

        [RecordedTest]
        public void BlobUriBuilder_MiddleRepeatedSlashes_ConstructorTest(
            [Values(true, false)] bool trimsSlash // middle slashes were always preserved regardless of flag
        )
        {
            // Arrange
            const string blobName = "foo/////bar";
            const string trimmedName = "foo/bar";
            var containerUriString = "https://account.blob.core.windows.net/container";
            var originalUri = new UriBuilder(containerUriString + "/" + blobName);
            var noSlashUri = new UriBuilder(containerUriString + "/" + trimmedName);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri, trimBlobNameSlashes: trimsSlash);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_MiddleRepeatedSlashes_PropertyTest(
            [Values(true, false)] bool trimsSlash // middle slashes were always preserved regardless of flag
        )
        {
            // Arrange
            const string blobName = "foo/////bar";
            const string trimmedName = "foo/bar";
            var containerUriString = "https://account.blob.core.windows.net/container";
            var originalUri = new UriBuilder(containerUriString + "/" + blobName);
            var noSlashUri = new UriBuilder(containerUriString + "/" + trimmedName);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri, trimBlobNameSlashes: trimsSlash)
            {
                BlobName = blobName
            };
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", blobUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", blobUriBuilder.Host);
            Assert.AreEqual("account", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual(blobName, blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(443, blobUriBuilder.Port);
            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public async Task ClientTargetsWithAppropriateSlash()
        {
            // blob name starts and ends with slash, not a path separator
            const string blobClientName = "///blob///client///";
            const string blockBlobClientName = "///blockblob///client///";
            const string pageBlobClientName = "///pageblob///client///";
            const string appendBlobClientName = "///appendblob///client///";
            const string blobBaseClientName = "///blobbase///client///";

            // Arrange
            var assertPolicy = new AssertMessageContentsPolicy(checkRequest: req => Assert.That(
                req.Uri.Path.Substring(req.Uri.Path.IndexOf('/') + 1), // extract blob name from uri path
                Does.Match(@"\/\/\/\w+\/\/\/\w+\/\/\/"))); // matches "///<alphanum>///<alphanum>///"

            BlobClientOptions options = GetOptions();
            options.TrimBlobNameSlashes = false;
            options.AddPolicy(
                assertPolicy,
                Core.HttpPipelinePosition.BeforeTransport);

            await using DisposingContainer container = await BlobsClientBuilder.GetTestContainerAsync(
                BlobsClientBuilder.GetServiceClient_SharedKey(options));

            BlobClient blob = container.Container.GetBlobClient(blobClientName);
            BlockBlobClient blockBlob = container.Container.GetBlockBlobClient(blockBlobClientName);
            PageBlobClient pageBlob = container.Container.GetPageBlobClient(pageBlobClientName);
            AppendBlobClient appendBlob = container.Container.GetAppendBlobClient(appendBlobClientName);
            BlobBaseClient blobBase = container.Container.GetBlobBaseClient(blobBaseClientName);

            // Act
            var content = BinaryData.FromString("Hello world!");

            using (assertPolicy.CheckRequestScope())
            {
                // any request with each of these clients
                await blob.UploadAsync(content);
                await blockBlob.StageBlockAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes("foo")), content.ToStream());
                await pageBlob.CreateIfNotExistsAsync(Constants.KB);
                await appendBlob.CreateIfNotExistsAsync();
                await blobBase.ExistsAsync();
            }

            // assertions in pipeline
        }

        [RecordedTest]
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

        [RecordedTest]
        public void BlobUriBuilder_RegularUrl_SnapshotTest()
        {
            // Arrange
            IList<string> snapshotUris = new List<string>()
            {
                "https://account.blob.core.windows.net/container/blob?snapshot=2011-03-09T01:42:34.9360000Z",
                "https://account.blob.core.windows.net/container/blob?sNAPSHOT=2011-03-09T01:42:34.9360000Z",
                "https://account.blob.core.windows.net/container/blob?snapShot=2011-03-09T01:42:34.9360000Z",
                "https://account.blob.core.windows.net/container/blob?sNaPsHoT=2011-03-09T01:42:34.9360000Z",
            };

            foreach (var uriString in snapshotUris)
            {
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
                Assert.IsTrue(string.Equals(originalUri.Uri.AbsoluteUri, newUri.AbsoluteUri, StringComparison.OrdinalIgnoreCase));
            }
        }

        [RecordedTest]
        public void BlobUriBuilder_RegularUrl_VersionIdTest()
        {
            // Arrange
            IList<string> snapshotUris = new List<string>()
            {
                "https://account.blob.core.windows.net/container/blob?versionid=2011-03-09T01:42:34.9360000Z",
                "https://account.blob.core.windows.net/container/blob?versionId=2011-03-09T01:42:34.9360000Z",
                "https://account.blob.core.windows.net/container/blob?VersionId=2011-03-09T01:42:34.9360000Z",
                "https://account.blob.core.windows.net/container/blob?VERSIONID=2011-03-09T01:42:34.9360000Z",
            };

            foreach (var uriString in snapshotUris)
            {
                // Arrange
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
                Assert.IsTrue(string.Equals(originalUri.Uri.AbsoluteUri, newUri.AbsoluteUri, StringComparison.OrdinalIgnoreCase));
            }
        }

        [RecordedTest]
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

        [RecordedTest]
        public void BlobUriBuilder_RegularUrl_CNAME()
        {
            var blobUriBuilder = new BlobUriBuilder(new Uri("http://www.contoso.com"));
            Assert.AreEqual(string.Empty, blobUriBuilder.AccountName);
        }

        [RecordedTest]
        public void BlobUriBuilder_AccountNamePeriod()
        {
            var blobUriBuilder = new BlobUriBuilder(new Uri("https://account.z.blob.core.windows.net/share/dir"));

            Assert.AreEqual("account", blobUriBuilder.AccountName);
        }

        [RecordedTest]
        public void BlobUriBuilder_AccountNameError()
        {
            var blobUriBuilder = new BlobUriBuilder(new Uri("http://notaurl"));

            Assert.IsEmpty(blobUriBuilder.AccountName);
        }

        [RecordedTest]
        public void BlobUriBuilder_RegularUrl_MalformedSubdomain()
        {
            // account and blob swapped
            var blobUriBuilder1 = new BlobUriBuilder(new Uri("https://blob.account.core.windows.net/container/blob"));

            // wrong service
            var blobUriBuilder2 = new BlobUriBuilder(new Uri("https://account.file.core.windows.net/container/blob"));

            // empty service
            var blobUriBuilder3 = new BlobUriBuilder(new Uri("https://account./container/blob"));

            Assert.AreEqual(string.Empty, blobUriBuilder1.AccountName);
            Assert.AreEqual(string.Empty, blobUriBuilder2.AccountName);
            Assert.AreEqual(string.Empty, blobUriBuilder3.AccountName);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public void BlobUriBuilder_IPStyleUrl_PortTest()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account";
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
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(8080, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_IPStyleUrl_PortTestContainer()
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

        [RecordedTest]
        public void BlobUriBuilder_IPStyleUrl_PortTestBlob()
        {
            // Arrange
            var uriString = "https://127.0.0.1:8080/account/container/blob";
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
            Assert.AreEqual(8080, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_PortTest_SlashUri()
        {
            // Arrange
            var originalUri = new UriBuilder("http://localhost:10000/devstoreaccount1/container/%E6%96%91%E9%BB%9E");

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("localhost", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("斑點", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_IPStyleUrl_NonAsciiUri()
        {
            // Arrange
            var originalUri = new UriBuilder("http://localhost:10000/devstoreaccount1/container/斑點");

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("localhost", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("斑點", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_LocalDockerUrl_PortTest()
        {
            // Arrange
            // BlobEndpoint from https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator#connect-to-the-emulator-account-using-the-well-known-account-name-and-key
            var uriString = "http://docker_container:10000/devstoreaccount1";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("docker_container", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_LocalDockerUrl_PortTestContainer()
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

        [RecordedTest]
        public void BlobUriBuilder_LocalDockerUrl_PortTestBlob()
        {
            // Arrange
            // BlobEndpoint from https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator#connect-to-the-emulator-account-using-the-well-known-account-name-and-key
            var uriString = "http://docker_container:10000/devstoreaccount1/containername/blobname";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("docker_container", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("containername", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blobname", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_LocalDockerUrl_Azurite()
        {
            // Arrange
            var uriString = "http://azure-storage-emulator-azurite:10000/devstoreaccount1";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("azure-storage-emulator-azurite", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_LocalDockerUrl_AzuriteContainer()
        {
            // Arrange
            var uriString = "http://azure-storage-emulator-azurite:10000/devstoreaccount1/container";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("azure-storage-emulator-azurite", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
        public void BlobUriBuilder_LocalDockerUrl_AzuriteBlob()
        {
            // Arrange
            var uriString = "http://azure-storage-emulator-azurite:10000/devstoreaccount1/container/blob";
            var originalUri = new UriBuilder(uriString);

            // Act
            var blobUriBuilder = new BlobUriBuilder(originalUri.Uri);
            Uri newUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("http", blobUriBuilder.Scheme);
            Assert.AreEqual("azure-storage-emulator-azurite", blobUriBuilder.Host);
            Assert.AreEqual("devstoreaccount1", blobUriBuilder.AccountName);
            Assert.AreEqual("container", blobUriBuilder.BlobContainerName);
            Assert.AreEqual("blob", blobUriBuilder.BlobName);
            Assert.AreEqual("", blobUriBuilder.Snapshot);
            Assert.IsNull(blobUriBuilder.Sas);
            Assert.AreEqual("", blobUriBuilder.Query);
            Assert.AreEqual(10000, blobUriBuilder.Port);

            Assert.AreEqual(originalUri, newUri);
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void BlobUriBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.blob.core.windows.net/container/blob?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(initialUri);

            // Act
            Uri resultUri = blobUriBuilder.ToUri();

            // Assert
            Assert.AreEqual(initialUri, resultUri);
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [RecordedTest]
        public void BlobUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.blob.core.windows.net/container/blob?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");

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

        [RecordedTest]
        public void BlobBaseClient_SetNameFields_TrimBlobNameSlashes([Values("blobname", "/blobname", "//blobname", "vdir//blobname", "/vdir//blobname")] string blobName, [Values(true, false)] bool trimBlobNameSlashes)
        {
            // arrange
            var accountName = "account";
            var containerName = "container";
            var uriPrefix = $"https://{accountName}.blob.core.windows.net/{containerName}/";
            var options = new BlobClientOptions() { TrimBlobNameSlashes = trimBlobNameSlashes };

            // act
            var blobBase = new BlobBaseClient(new Uri(string.Concat(uriPrefix, blobName)), options);

            // verify
            if (trimBlobNameSlashes)
            {
                Assert.AreEqual(blobName.Trim('/'), blobBase.Name);
            }
            else
            {
                Assert.AreEqual(blobName, blobBase.Name);
            }
            Assert.AreEqual(containerName, blobBase.BlobContainerName);
            Assert.AreEqual(accountName, blobBase.AccountName);
        }
    }
}
