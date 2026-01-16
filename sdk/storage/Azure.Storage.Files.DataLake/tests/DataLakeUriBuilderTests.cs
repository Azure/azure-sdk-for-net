// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
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
        private readonly Uri _prefixBlobAccountUri = new Uri("https://blobaccount.blob.core.windows.net");
        private readonly Uri _prefixBlobAccountDfsUri = new Uri("https://blobaccount.dfs.core.windows.net");
        private readonly Uri _prefixDfsAccountUri = new Uri("https://dfsacount.dfs.core.windows.net");
        private readonly Uri _prefixDfsAccountBlobUri = new Uri("https://dfsacount.blob.core.windows.net");
        private readonly Uri _suffixBlobAccountUri = new Uri("https://accountblob.blob.core.windows.net");
        private readonly Uri _suffixBlobAccountDfsUri = new Uri("https://accountblob.dfs.core.windows.net");
        private readonly Uri _suffixDfsAccountUri = new Uri("https://accountdfs.dfs.core.windows.net");
        private readonly Uri _suffixDfsAccountBlobUri = new Uri("https://accountdfs.blob.core.windows.net");
        private readonly Uri _accountBlobNameUri = new Uri("https://accountblobname.blob.core.windows.net");
        private readonly Uri _accountBlobNameDfsUri = new Uri("https://accountblobname.dfs.core.windows.net");
        private readonly Uri _accountDfsNameUri = new Uri("https://accountdfsname.dfs.core.windows.net");
        private readonly Uri _accountDfsNameBlobUri = new Uri("https://accountdfsname.blob.core.windows.net");

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

            Assert.That(actualUri, Is.EqualTo(expectedUri), "Flaky test -- potential signature generation issue not properly encoding space and + in the output");
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
            Assert.That(dataLakeUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(dataLakeUriBuilder.Host, Is.EqualTo("account.blob.core.windows.net"));
            Assert.That(dataLakeUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(dataLakeUriBuilder.Port, Is.EqualTo(443));
            Assert.That(dataLakeUriBuilder.FileSystemName, Is.EqualTo("fileSystem"));
            Assert.That(dataLakeUriBuilder.LastDirectoryOrFileName, Is.EqualTo("path"));
            Assert.That(dataLakeUriBuilder.DirectoryOrFilePath, Is.EqualTo("path"));
            Assert.That(dataLakeUriBuilder.Snapshot, Is.Empty);
            Assert.That(dataLakeUriBuilder.Sas, Is.Null);
            Assert.That(newUri, Is.EqualTo(originalUri));
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
            Assert.That(dataLakeUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(dataLakeUriBuilder.Host, Is.EqualTo("account.dfs.core.windows.net"));
            Assert.That(dataLakeUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(dataLakeUriBuilder.Port, Is.EqualTo(443));
            Assert.That(dataLakeUriBuilder.FileSystemName, Is.EqualTo("fileSystem"));
            Assert.That(dataLakeUriBuilder.LastDirectoryOrFileName, Is.Empty);
            Assert.That(dataLakeUriBuilder.DirectoryOrFilePath, Is.Empty);
            Assert.That(dataLakeUriBuilder.Snapshot, Is.Empty);
            Assert.That(dataLakeUriBuilder.Sas, Is.Null);
            Assert.That(dataLakeUriBuilder.Query, Is.EqualTo("resource=filesystem"));
            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_RegularUrl_CNAME()
        {
            var dataLakeUriBuilder = new DataLakeUriBuilder(new Uri("http://www.contoso.com"));
            Assert.That(dataLakeUriBuilder.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_AccountNamePeriod()
        {
            var datalakeUriBuilder = new DataLakeUriBuilder(new Uri("https://account.z.blob.core.windows.net/share/dir"));

            Assert.That(datalakeUriBuilder.AccountName, Is.EqualTo("account"));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_AccountNameError()
        {
            var datalakeUriBuilder = new DataLakeUriBuilder(new Uri("http://notaurl"));

            Assert.That(datalakeUriBuilder.AccountName, Is.Empty);
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

            Assert.That(datalakeUriBuilder1.AccountName, Is.Empty);
            Assert.That(datalakeUriBuilder2.AccountName, Is.Empty);
            Assert.That(datalakeUriBuilder3.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_CustomUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_customUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_customUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_ShortHost()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_shortHostUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_shortHostUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_IpStyleUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_ipStyleUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_ipStyleUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_InvalidServiceUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_invalidServiceUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_invalidServiceUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_BlobUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_blobUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_DfsUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_blobUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobPeriodUri_BlobPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobPeriodUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_blobPeriodUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobPeriodUri_DfsPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsPeriodUri);

            // Act
            Uri result = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(result, Is.EqualTo(_blobPeriodUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_CustomUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_customUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_customUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_ShortHost()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_shortHostUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_shortHostUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_IpStyleUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_ipStyleUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_ipStyleUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_InvalidServiceUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_invalidServiceUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_invalidServiceUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_DfsUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_dfsUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_BlobUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_dfsUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsPeriodUri_DfsPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_dfsPeriodUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_dfsPeriodUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsPeriodUri_BlobPeriodUri()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_blobPeriodUri);

            // Act
            Uri result = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(result, Is.EqualTo(_dfsPeriodUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToUri_RootDirectory()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_rootDirectoryUri);

            // Act
            Uri uri = uriBuilder.ToUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_rootDirectoryUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_RootDirectory()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_rootDirectoryUri);

            // Act
            Uri uri = uriBuilder.ToDfsUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_rootDirectoryUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_RootDirectory()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_rootDirectoryUri);

            // Act
            Uri uri = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(uri, Is.EqualTo(new Uri("https://account.blob.core.windows.net/filesystem/")));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_PrefixBlobAccountName()
        {
            // Arrange
            DataLakeUriBuilder blobAccountNameUriBuilder = new DataLakeUriBuilder(_prefixBlobAccountUri);

            // Act
            Uri uri = blobAccountNameUriBuilder.ToDfsUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_prefixBlobAccountDfsUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_PrefixDfsAccountName()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_prefixDfsAccountUri);

            // Act
            Uri uri = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_prefixDfsAccountBlobUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_SuffixBlobAccountName()
        {
            // Arrange
            DataLakeUriBuilder blobAccountNameUriBuilder = new DataLakeUriBuilder(_suffixBlobAccountUri);

            // Act
            Uri uri = blobAccountNameUriBuilder.ToDfsUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_suffixBlobAccountDfsUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_SuffixDfsAccountName()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_suffixDfsAccountUri);

            // Act
            Uri uri = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_suffixDfsAccountBlobUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToDfsUri_AccountBlobName()
        {
            // Arrange
            DataLakeUriBuilder blobAccountNameUriBuilder = new DataLakeUriBuilder(_accountBlobNameUri);

            // Act
            Uri uri = blobAccountNameUriBuilder.ToDfsUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_accountBlobNameDfsUri));
        }

        [RecordedTest]
        public void DataLakeUriBuilder_ToBlobUri_AccountDfsName()
        {
            // Arrange
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(_accountDfsNameUri);

            // Act
            Uri uri = uriBuilder.ToBlobUri();

            // Assert
            Assert.That(uri, Is.EqualTo(_accountDfsNameBlobUri));
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
            Uri initialUri = new Uri($"https://account.dfs.core.windows.net/filesystem/directory/file?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(initialUri);

            // Act
            Uri resultUri = dataLakeUriBuilder.ToUri();

            // Assert
            Assert.That(resultUri, Is.EqualTo(initialUri));
            Assert.That(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"), Is.True);
            Assert.That(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"), Is.True);
        }

        [RecordedTest]
        public void DataLakeUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.dfs.core.windows.net/filesystem/directory/file?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");

            // Act
            try
            {
                new DataLakeUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.That(e.Message.Contains("was not recognized as a valid DateTime."), Is.True);
            }
        }
    }
}
