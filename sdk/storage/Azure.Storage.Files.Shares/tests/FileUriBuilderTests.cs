// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        [RecordedTest]
        public void FileUriBuilder_RoundTrip()
        {
            ShareServiceClient serviceUri = GetServiceClient_AccountSas();
            var blobUriBuilder = new ShareUriBuilder(serviceUri.Uri);

            Uri blobUri = blobUriBuilder.ToUri();

            var expectedUri = WebUtility.UrlDecode(serviceUri.Uri.AbsoluteUri);
            var actualUri = WebUtility.UrlDecode(blobUri.AbsoluteUri);

            Assert.That(actualUri, Is.EqualTo(expectedUri), "Flaky test -- potential signature generation issue not properly encoding space and + in the output");
        }

        [RecordedTest]
        public void FileUriBuilder_AccountTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/?comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.That(fileUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(fileUriBuilder.Host, Is.EqualTo("account.file.core.windows.net"));
            Assert.That(fileUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(fileUriBuilder.Port, Is.EqualTo(443));
            Assert.That(fileUriBuilder.ShareName, Is.Empty);
            Assert.That(fileUriBuilder.DirectoryOrFilePath, Is.Empty);
            Assert.That(fileUriBuilder.Snapshot, Is.Empty);
            Assert.That(fileUriBuilder.Sas, Is.Null);
            Assert.That(fileUriBuilder.Query, Is.EqualTo("comp=list"));
            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void FileUriBuilder_ShareTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share?restype=share";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.That(fileUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(fileUriBuilder.Host, Is.EqualTo("account.file.core.windows.net"));
            Assert.That(fileUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(fileUriBuilder.Port, Is.EqualTo(443));
            Assert.That(fileUriBuilder.ShareName, Is.EqualTo("share"));
            Assert.That(fileUriBuilder.DirectoryOrFilePath, Is.Empty);
            Assert.That(fileUriBuilder.Snapshot, Is.Empty);
            Assert.That(fileUriBuilder.Sas, Is.Null);
            Assert.That(fileUriBuilder.Query, Is.EqualTo("restype=share"));
            Assert.That(newUri, Is.EqualTo(originalUri));
            Assert.That(fileUriBuilder.LastDirectoryOrFileName, Is.Empty);
        }

        [RecordedTest]
        public void FileUriBuilder_PathTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share/path?restype=directory&comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.That(fileUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(fileUriBuilder.Host, Is.EqualTo("account.file.core.windows.net"));
            Assert.That(fileUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(fileUriBuilder.Port, Is.EqualTo(443));
            Assert.That(fileUriBuilder.ShareName, Is.EqualTo("share"));
            Assert.That(fileUriBuilder.DirectoryOrFilePath, Is.EqualTo("path"));
            Assert.That(fileUriBuilder.LastDirectoryOrFileName, Is.EqualTo("path"));
            Assert.That(fileUriBuilder.Snapshot, Is.Empty);
            Assert.That(fileUriBuilder.Sas, Is.Null);
            Assert.That(fileUriBuilder.Query, Is.EqualTo("restype=directory&comp=list"));
            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void FileUriBuilder_PathTrailingSlash()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share/path/?restype=directory&comp=list";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Assert.That(fileUriBuilder.DirectoryOrFilePath, Is.EqualTo("path"));
            Assert.That(fileUriBuilder.LastDirectoryOrFileName, Is.EqualTo("path"));
        }

        [RecordedTest]
        public void FileUriBuilder_SnapshotTest()
        {
            // Arrange
            IList<string> snapshotUris = new List<string>()
            {
                "https://account.file.core.windows.net/share?sharesnapshot=2011-03-09T01:42:34.9360000Z",
                "https://account.file.core.windows.net/share?ShareSnapshot=2011-03-09T01:42:34.9360000Z",
                "https://account.file.core.windows.net/share?shareSnapshot=2011-03-09T01:42:34.9360000Z",
                "https://account.file.core.windows.net/share?SHARESNAPSHOT=2011-03-09T01:42:34.9360000Z",
            };

            foreach (var uriString in snapshotUris)
            {
                var originalUri = new UriBuilder(uriString);

                // Act
                var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
                Uri newUri = fileUriBuilder.ToUri();

                // Assert
                Assert.That(fileUriBuilder.Scheme, Is.EqualTo("https"));
                Assert.That(fileUriBuilder.Host, Is.EqualTo("account.file.core.windows.net"));
                Assert.That(fileUriBuilder.AccountName, Is.EqualTo("account"));
                Assert.That(fileUriBuilder.Port, Is.EqualTo(443));
                Assert.That(fileUriBuilder.ShareName, Is.EqualTo("share"));
                Assert.That(fileUriBuilder.DirectoryOrFilePath, Is.Empty);
                Assert.That(fileUriBuilder.Snapshot, Is.EqualTo("2011-03-09T01:42:34.9360000Z"));
                Assert.That(fileUriBuilder.Sas, Is.Null);
                Assert.That(fileUriBuilder.Query, Is.Empty);
                Assert.That(string.Equals(originalUri.Uri.AbsoluteUri, newUri.AbsoluteUri, StringComparison.OrdinalIgnoreCase), Is.True);
            }
        }

        [RecordedTest]
        public void FileUriBuilder_SasTest()
        {
            // Arrange
            var uriString = "https://account.file.core.windows.net/share?comp=list&sv=2015-04-05&spr=https&st=2015-04-29T22%3A18%3A26Z&se=2015-04-30T02%3A23%3A26Z&sip=168.1.5.60-168.1.5.70&sr=b&sp=rw&sig=Z%2FRHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk%3D";
            var originalUri = new UriBuilder(uriString);

            // Act
            var fileUriBuilder = new ShareUriBuilder(originalUri.Uri);
            Uri newUri = fileUriBuilder.ToUri();

            // Assert
            Assert.That(fileUriBuilder.Scheme, Is.EqualTo("https"));
            Assert.That(fileUriBuilder.Host, Is.EqualTo("account.file.core.windows.net"));
            Assert.That(fileUriBuilder.AccountName, Is.EqualTo("account"));
            Assert.That(fileUriBuilder.Port, Is.EqualTo(443));
            Assert.That(fileUriBuilder.ShareName, Is.EqualTo("share"));
            Assert.That(fileUriBuilder.DirectoryOrFilePath, Is.Empty);
            Assert.That(fileUriBuilder.Snapshot, Is.Empty);

            Assert.That(fileUriBuilder.Sas.ExpiresOn, Is.EqualTo(new DateTimeOffset(2015, 4, 30, 2, 23, 26, TimeSpan.Zero)));
            Assert.That(fileUriBuilder.Sas.Identifier, Is.Empty);
            Assert.That(fileUriBuilder.Sas.IPRange, Is.EqualTo(SasIPRange.Parse("168.1.5.60-168.1.5.70")));
            Assert.That(fileUriBuilder.Sas.Permissions, Is.EqualTo("rw"));
            Assert.That(fileUriBuilder.Sas.Protocol, Is.EqualTo(SasProtocol.Https));
            Assert.That(fileUriBuilder.Sas.Resource, Is.EqualTo("b"));
            Assert.That(fileUriBuilder.Sas.ResourceTypes, Is.Null);
            Assert.That(fileUriBuilder.Sas.Services, Is.Null);
            Assert.That(fileUriBuilder.Sas.Signature, Is.EqualTo("Z/RHIX5Xcg0Mq2rqI3OlWTjEg2tYkboXr1P9ZUXDtkk="));
            Assert.That(fileUriBuilder.Sas.StartsOn, Is.EqualTo(new DateTimeOffset(2015, 4, 29, 22, 18, 26, TimeSpan.Zero)));
            Assert.That(fileUriBuilder.Sas.Version, Is.EqualTo("2015-04-05"));

            Assert.That(fileUriBuilder.Query, Is.EqualTo("comp=list"));

            Assert.That(newUri, Is.EqualTo(originalUri));
        }

        [RecordedTest]
        public void FileUriBuilder_RegularUrl_CNAME()
        {
            var shareUriBuilder = new ShareUriBuilder(new Uri("http://www.contoso.com"));
            Assert.That(shareUriBuilder.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void FileUriBuilder_AccountNamePeriod()
        {
            var fileUriBuilder = new ShareUriBuilder(new Uri("https://account.z.file.core.windows.net/share/dir"));

            Assert.That(fileUriBuilder.AccountName, Is.EqualTo("account"));
        }

        [RecordedTest]
        public void FileUriBuilder_AccountNameError()
        {
            var fileUriBuilder = new ShareUriBuilder(new Uri("http://notaurl"));

            Assert.That(fileUriBuilder.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void FileUriBuilder_MalformedSubdomain()
        {
            // account and file swapped
            var shareUriBuilder1 = new ShareUriBuilder(new Uri("https://file.account.core.windows.net/share/dir"));

            // wrong service
            var shareUriBuilder2 = new ShareUriBuilder(new Uri("https://account.blob.core.windows.net/share/dir"));

            // empty service
            var shareUriBuilder3 = new ShareUriBuilder(new Uri("https://account./share/dir"));

            Assert.That(shareUriBuilder1.AccountName, Is.Empty);
            Assert.That(shareUriBuilder2.AccountName, Is.Empty);
            Assert.That(shareUriBuilder3.AccountName, Is.Empty);
        }

        [RecordedTest]
        public void FileUriBuilder_SpecialCharacters()
        {
            // Unencoded.  We want to encode the special characters.
            string path = "!'();/[]@&%=+$/,#äÄö/ÖüÜß;";
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(new Uri("https://account.file.core.windows.net/share"))
            {
                DirectoryOrFilePath = path
            };
            Uri uri = shareUriBuilder.ToUri();

            Assert.That(
                uri,
                Is.EqualTo(new Uri("https://account.file.core.windows.net/share/%21%27%28%29%3B/%5B%5D%40%26%25%3D%2B%24/%2C%23äÄö/ÖüÜß%3B")));

            // Encoded.  We want to encode again, because this is the literal path the customer wants.
            path = "%21%27%28%29%3B/%5B%5D%40%26%25%3D%2B%24/%2C%23äÄö/ÖüÜß%3B";
            shareUriBuilder = new ShareUriBuilder(new Uri("https://account.file.core.windows.net/share"))
            {
                DirectoryOrFilePath = path
            };
            uri = shareUriBuilder.ToUri();

            Assert.That(
                uri,
                Is.EqualTo(new Uri("https://account.file.core.windows.net/share/%2521%2527%2528%2529%253B/%255B%255D%2540%2526%2525%253D%252B%2524/%252C%2523äÄö/ÖüÜß%253B")));
        }

        [RecordedTest]
        [TestCase("2020-10-27", "2020-10-28")]
        [TestCase("2020-10-27T12:10Z", "2020-10-28T13:20Z")]
        [TestCase("2020-10-27T12:10:11Z", "2020-10-28T13:20:14Z")]
        [TestCase("2020-10-27T12:10:11.1234567Z", "2020-10-28T13:20:14.7654321Z")]
        public void FileUriBuilder_SasStartExpiryTimeFormats(string startTime, string expiryTime)
        {
            // Arrange
            Uri initialUri = new Uri($"https://account.file.core.windows.net/share/directory/file?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");
            ShareUriBuilder shareUriBuilder = new ShareUriBuilder(initialUri);

            // Act
            Uri resultUri = shareUriBuilder.ToUri();

            // Assert
            Assert.That(resultUri, Is.EqualTo(initialUri));
            Assert.That(resultUri.PathAndQuery.Contains($"st={WebUtility.UrlEncode(startTime)}"), Is.True);
            Assert.That(resultUri.PathAndQuery.Contains($"se={WebUtility.UrlEncode(expiryTime)}"), Is.True);
        }

        [RecordedTest]
        public void FileUriBuilder_SasInvalidStartExpiryTimeFormat()
        {
            // Arrange
            string startTime = "2020-10-27T12Z";
            string expiryTime = "2020-10-28T13Z";
            Uri initialUri = new Uri($"https://account.file.core.windows.net/share/directory/file?sv=2020-06-12&st={WebUtility.UrlEncode(startTime)}&se={WebUtility.UrlEncode(expiryTime)}&sr=b&sp=racwd&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D");

            // Act
            try
            {
                new ShareUriBuilder(initialUri);
            }
            catch (FormatException e)
            {
                Assert.That(e.Message.Contains("was not recognized as a valid DateTime."), Is.True);
            }
        }
    }
}
