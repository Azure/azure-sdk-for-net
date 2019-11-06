// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.Testing;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Files.DataLake.Tests;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class DataLakeUriBuilderTests : DataLakeTestBase
    {
        public DataLakeUriBuilderTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        //TODO address the flakiness of this test.
        [Test]
        public void DataLakeUriBuilder_RoundTrip()
        {
            DataLakeServiceClient serviceUri = GetServiceClient_AccountSas();
            var dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri.Uri);

            Uri dataLakeUri = dataLakeUriBuilder.ToUri();

            var expectedUri = WebUtility.UrlDecode(serviceUri.Uri.AbsoluteUri);
            var actualUri = WebUtility.UrlDecode(dataLakeUri.AbsoluteUri);

            Assert.AreEqual(expectedUri, actualUri, "Flaky test -- potential signature generation issue not properly encoding space and + in the output");
        }

        [Test]
        public void DataLakeUriBuilder_AccountTest()
        {
            // Arrange
            var uriString = "https://account.blob.core.windows.net/fileSystem/path";
            var originalUri = new UriBuilder(uriString);

            // Act
            var dataLakeUriBuilder = new DataLakeUriBuilder(originalUri.Uri);
            Uri newUri = dataLakeUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", dataLakeUriBuilder.Scheme);
            Assert.AreEqual("account.blob.core.windows.net", dataLakeUriBuilder.Host);
            Assert.AreEqual("account", dataLakeUriBuilder.AccountName);
            Assert.AreEqual(443, dataLakeUriBuilder.Port);
            Assert.AreEqual("fileSystem", dataLakeUriBuilder.FileSystemName);
            Assert.AreEqual("path", dataLakeUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual("path", dataLakeUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", dataLakeUriBuilder.Snapshot);
            Assert.IsNull(dataLakeUriBuilder.Sas);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void DataLakeUriBuilder_ListPaths()
        {
            // Arrange
            var uriString = "https://account.dfs.core.windows.net/fileSystem?resource=filesystem";
            var originalUri = new UriBuilder(uriString);

            // Act
            var dataLakeUriBuilder = new DataLakeUriBuilder(originalUri.Uri);
            Uri newUri = dataLakeUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", dataLakeUriBuilder.Scheme);
            Assert.AreEqual("account.dfs.core.windows.net", dataLakeUriBuilder.Host);
            Assert.AreEqual("account", dataLakeUriBuilder.AccountName);
            Assert.AreEqual(443, dataLakeUriBuilder.Port);
            Assert.AreEqual("fileSystem", dataLakeUriBuilder.FileSystemName);
            Assert.AreEqual(string.Empty, dataLakeUriBuilder.LastDirectoryOrFileName);
            Assert.AreEqual(string.Empty, dataLakeUriBuilder.DirectoryOrFilePath);
            Assert.AreEqual("", dataLakeUriBuilder.Snapshot);
            Assert.IsNull(dataLakeUriBuilder.Sas);
            Assert.AreEqual("resource=filesystem", dataLakeUriBuilder.Query);
            Assert.AreEqual(originalUri, newUri);
        }

        [Test]
        public void DataLakeUriBuilder_RegularUrl_CNAME()
        {
            var dataLakeUriBuilder = new DataLakeUriBuilder(new Uri("http://www.contoso.com"));
            Assert.AreEqual(string.Empty, dataLakeUriBuilder.AccountName);
        }

        [Test]
        public void DataLakeUriBuilder_MalformedSubdomain()
        {
            // core and file swapped
            var datalakeUriBuilder1 = new DataLakeUriBuilder(new Uri("https://account.core.blob.windows.net/share/dir"));

            // account and file swapped
            var datalakeUriBuilder2 = new DataLakeUriBuilder(new Uri("https://blob.account.core.windows.net/share/dir"));

            // wrong service
            var datalakeUriBuilder3 = new DataLakeUriBuilder(new Uri("https://account.queue.core.windows.net/share/dir"));

            // empty service
            var datalakeUriBuilder4 = new DataLakeUriBuilder(new Uri("https://account./share/dir"));

            Assert.AreEqual(string.Empty, datalakeUriBuilder1.AccountName);
            Assert.AreEqual(string.Empty, datalakeUriBuilder2.AccountName);
            Assert.AreEqual(string.Empty, datalakeUriBuilder3.AccountName);
            Assert.AreEqual(string.Empty, datalakeUriBuilder4.AccountName);
        }
    }
}
