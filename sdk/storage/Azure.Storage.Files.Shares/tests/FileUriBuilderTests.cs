// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using Azure.Core.TestFramework;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class FileUriBuilderTests : FileTestBase
    {
        public FileUriBuilderTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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
            Assert.AreEqual("account", fileUriBuilder.AccountName);
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
            var uriString = "https://account.file.core.windows.net/share?restype=share";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual("account", fileUriBuilder.AccountName);
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
            Assert.AreEqual("account", fileUriBuilder.AccountName);
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
            var uriString = "https://account.file.core.windows.net/share?sharesnapshot=2011-03-09T01:42:34.9360000Z";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.AreEqual("https", fileUriBuilder.Scheme);
            Assert.AreEqual("account.file.core.windows.net", fileUriBuilder.Host);
            Assert.AreEqual("account", fileUriBuilder.AccountName);
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
            Assert.AreEqual("account", fileUriBuilder.AccountName);
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

        [Test]
        public void FileUriBuilder_RegularUrl_CNAME()
        {
            var shareUriBuilder = new ShareUriBuilder(new Uri("http://www.contoso.com"));
            Assert.AreEqual(string.Empty, shareUriBuilder.AccountName);
        }

        [Test]
        public void FileUriBuilder_MalformedSubdomain()
        {
            // core and file swapped
            var shareUriBuilder1 = new ShareUriBuilder(new Uri("https://account.core.file.windows.net/share/dir"));

            // account and file swapped
            var shareUriBuilder2 = new ShareUriBuilder(new Uri("https://file.account.core.windows.net/share/dir"));

            // wrong service
            var shareUriBuilder3 = new ShareUriBuilder(new Uri("https://account.blob.core.windows.net/share/dir"));

            // empty service
            var shareUriBuilder4 = new ShareUriBuilder(new Uri("https://account./share/dir"));

            Assert.AreEqual(string.Empty, shareUriBuilder1.AccountName);
            Assert.AreEqual(string.Empty, shareUriBuilder2.AccountName);
            Assert.AreEqual(string.Empty, shareUriBuilder3.AccountName);
            Assert.AreEqual(string.Empty, shareUriBuilder4.AccountName);
        }

        [Test]
        public void FileUriBuilder_SpecialCharacters()
        {
            // Unencoded.  We want to encode the special characters.
            string path = "!'();/[]@&%=+$/,#äÄö/ÖüÜß;";
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(new Uri("https://account.file.core.windows.net/share"))
            {
                DirectoryOrFilePath = path
            };
            Uri uri = shareUriBuilder.ToUri();

            Assert.AreEqual(
                new Uri("https://account.file.core.windows.net/share/%21%27%28%29%3B/%5B%5D%40%26%25%3D%2B%24/%2C%23äÄö/ÖüÜß%3B"),
                uri);

            // Encoded.  We want to encode again, because this is the literal path the customer wants.
            path = "%21%27%28%29%3B/%5B%5D%40%26%25%3D%2B%24/%2C%23äÄö/ÖüÜß%3B";
            shareUriBuilder = new ShareUriBuilder(new Uri("https://account.file.core.windows.net/share"))
            {
                DirectoryOrFilePath = path
            };
            uri = shareUriBuilder.ToUri();

            Assert.AreEqual(
                new Uri("https://account.file.core.windows.net/share/%2521%2527%2528%2529%253B/%255B%255D%2540%2526%2525%253D%252B%2524/%252C%2523äÄö/ÖüÜß%253B"),
                uri);
        }

        [Test]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void FileUriBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.file.core.windows.net/share/directory/file?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(initialUri);

            // Act
            Uri resultUri = shareUriBuilder.ToUri();

            // Assert
            Assert.AreEqual(initialUri, resultUri);
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"));
            Assert.IsTrue(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"));
        }

        [Test]
        public void FileUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.file.core.windows.net/share/directory/file?sv=2020-04-08&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=jQetX8odiJoZ7Yo0X8vWgh%2FMqRv9WE3GU%2Fr%2BLNMK3GU%3D");

            // Act
            try
            {
                new ShareUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.IsTrue(e.Message.Contains("was not recognized as a valid DateTime."));
            }
        }
    }
}
