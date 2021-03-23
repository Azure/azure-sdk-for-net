// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeUriBuilderTests : DataLakeTestBase
    {
        private readonly Uri _customUri = new Uri("https://www.customstorageurl.com");
        private readonly Uri _shortHostUri = new Uri("https://account.core.windows.net");
        private readonly Uri _ipStyleUri = new Uri("https://0.0.0.0/account");
        private readonly Uri _invalidServiceUri = new Uri("https://account.file.core.windows.net");
        private readonly Uri _blobUri = new Uri("https://account.blob.core.windows.net");
        private readonly Uri _dfsUri = new Uri("https://account.dfs.core.windows.net");
        private readonly Uri _blobPeriodUri = new Uri("https://account.z.blob.core.windows.net");
        private readonly Uri _dfsPeriodUri = new Uri("https://account.z.dfs.core.windows.net");
        private readonly Uri _rootDirectoryUri = new Uri("https://account.dfs.core.windows.net/filesystem/");

        public DataLakeUriBuilderTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        //TODO address the flakiness of this test.
        [RecordedTest]
        public void DataLakeUriBuilder_RoundTrip()
        {
            DataLakeServiceClient serviceUri = GetServiceClient_AccountSas();
            var dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri.Uri);

            Uri dataLakeUri = dataLakeUriBuilder.ToUri();

            var expectedUri = WebUtility.UrlDecode(serviceUri.Uri.AbsoluteUri);
            var actualUri = WebUtility.UrlDecode(dataLakeUri.AbsoluteUri);

            Assert.AreEqual(expectedUri, actualUri, "Flaky test -- potential signature generation issue not properly encoding space and + in the output");
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public void DataLakeUriBuilder_RegularUrl_CNAME()
        {
            var dataLakeUriBuilder = new DataLakeUriBuilder(new Uri("http://www.contoso.com"));
            Assert.AreEqual(string.Empty, dataLakeUriBuilder.AccountName);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_AccountNamePeriod()
        {
            var datalakeUriBuilder = new DataLakeUriBuilder(new Uri("https://account.z.blob.core.windows.net/share/dir"));

            Assert.AreEqual("account", datalakeUriBuilder.AccountName);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_AccountNameError()
        {
            var datalakeUriBuilder = new DataLakeUriBuilder(new Uri("http://notaurl"));

            Assert.IsEmpty(datalakeUriBuilder.AccountName);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_MalformedSubdomain()
        {
            // account and file swapped
            var datalakeUriBuilder1 = new DataLakeUriBuilder(new Uri("https://blob.account.core.windows.net/share/dir"));

            // wrong service
            var datalakeUriBuilder2 = new DataLakeUriBuilder(new Uri("https://account.queue.core.windows.net/share/dir"));

            // empty service
            var datalakeUriBuilder3 = new DataLakeUriBuilder(new Uri("https://account./share/dir"));

            Assert.AreEqual(string.Empty, datalakeUriBuilder1.AccountName);
            Assert.AreEqual(string.Empty, datalakeUriBuilder2.AccountName);
            Assert.AreEqual(string.Empty, datalakeUriBuilder3.AccountName);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_CustomUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_customUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_customUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_ShortHost()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_shortHostUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_shortHostUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_IpStyleUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_ipStyleUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_ipStyleUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_InvalidServiceUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_invalidServiceUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_invalidServiceUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_BlobUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_blobUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_DfsUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_blobUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobPeriodUri_BlobPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobPeriodUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_blobPeriodUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobPeriodUri_DfsPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsPeriodUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(_blobPeriodUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_CustomUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_customUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_customUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_ShortHost()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_shortHostUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_shortHostUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_IpStyleUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_ipStyleUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_ipStyleUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_InvalidServiceUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_invalidServiceUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_invalidServiceUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_DfsUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_dfsUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_BlobUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_dfsUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsPeriodUri_DfsPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsPeriodUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_dfsPeriodUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsPeriodUri_BlobPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobPeriodUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_dfsPeriodUri, result);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToUri_RootDirectory()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_rootDirectoryUri);

            // Act
            Uri uri = uriBuilder.ToUri();

            // Assert
            Assert.AreEqual(_rootDirectoryUri, uri);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_RootDirectory()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_rootDirectoryUri);

            // Act
            Uri uri = uriBuilder.ToDfsUri();

            // Assert
            Assert.AreEqual(_rootDirectoryUri, uri);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_RootDirectory()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_rootDirectoryUri);

            // Act
            Uri uri = uriBuilder.ToBlobUri();

            // Assert
            Assert.AreEqual(new Uri("https://account.blob.core.windows.net/filesystem/"), uri);
        }

        [Test]
        [LiveOnly] // Test recording paths are too long.
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void DataLakeUriBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.dfs.core.windows.net/filesystem/directory/file?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(initialUri);

            // Act
            Uri resultUri = dataLakeUriBuilder.ToUri();

            // Assert
            Assert.AreEqual(initialUri, resultUri);
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.dfs.core.windows.net/filesystem/directory/file?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");

            // Act
            try
            {
                new DataLakeUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.IsTrue(e.Message.Contains("was not recognized as a valid DateTime."));
            }
        }
    }
}
