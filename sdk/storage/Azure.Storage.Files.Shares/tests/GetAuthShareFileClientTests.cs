// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class GetAuthShareFileClientTests
    {
        private const string AccountName = "account";
        private const string ContainerName = "container";
        private const string FileName = "file";
        private static readonly Uri FileUri = new Uri($"https://{AccountName}.file.core.windows.net/{ContainerName}/{FileName}");
        private const string SasWithoutQuestionMark = "sv=2020-08-04&ss=b&srt=o&sig=abc";
        private const string SasWithQuestionMark = "?" + SasWithoutQuestionMark;

        /// <summary>
        /// Helper to access the protected static <see cref="ShareFileClient.GetUriWithSas"/> method.
        /// </summary>
        private class TestShareFileClient : ShareFileClient
        {
            public static Uri CallGetUriWithSas(ShareFileClient client) => GetUriWithSas(client);
        }

        [Test]
        public void GetUriWithSas_NoSasCredential_ReturnsOriginalUri()
        {
            // Arrange
            ShareFileClient client = new ShareFileClient(FileUri);

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert
            Assert.AreEqual(FileUri, result);
        }

        [Test]
        public void GetUriWithSas_SasWithLeadingQuestionMark_StripsQuestionMark()
        {
            // Arrange
            ShareFileClient client = new ShareFileClient(FileUri, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert - SAS appended correctly, no double '?'
            StringAssert.Contains("sv=2020-08-04", result.Query);
            StringAssert.Contains("sig=abc", result.Query);
            StringAssert.DoesNotContain("??", result.AbsoluteUri);
        }

        [Test]
        public void GetUriWithSas_SasWithoutLeadingQuestionMark_AppendsSas()
        {
            // Arrange
            ShareFileClient client = new ShareFileClient(FileUri, new AzureSasCredential(SasWithoutQuestionMark));

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert
            StringAssert.Contains("sv=2020-08-04", result.Query);
            StringAssert.Contains("sig=abc", result.Query);
        }

        [Test]
        public void GetUriWithSas_SasWithLeadingQuestionMark_UriWithSnapshot_PreservesSnapshotAndAppendsSas()
        {
            // Arrange
            string snapshot = "snap1";
            Uri snapshotUri = new Uri($"{FileUri}?snapshot={snapshot}");
            ShareFileClient client = new ShareFileClient(snapshotUri, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert - snapshot preserved, SAS appended, no malformed query
            string uriString = result.AbsoluteUri;
            StringAssert.Contains($"snapshot={snapshot}", uriString);
            StringAssert.Contains("sv=2020-08-04", uriString);
            StringAssert.Contains("sig=abc", uriString);
            StringAssert.DoesNotContain("??", uriString);
        }

        [Test]
        public void GetUriWithSas_SasWithLeadingQuestionMark_UriWithVersionId_PreservesVersionIdAndAppendsSas()
        {
            // Arrange
            string versionId = "ver1";
            Uri versionUri = new Uri($"{FileUri}?versionid={versionId}");
            ShareFileClient client = new ShareFileClient(versionUri, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert - versionid preserved, SAS appended, no malformed query
            string uriString = result.AbsoluteUri;
            StringAssert.Contains($"versionid={versionId}", uriString);
            StringAssert.Contains("sv=2020-08-04", uriString);
            StringAssert.Contains("sig=abc", uriString);
            StringAssert.DoesNotContain("??", uriString);
        }

        [Test]
        public void GetUriWithSas_SasWithLeadingQuestionMark_UriWithExistingQueryParams_AppendsSasWithAmpersand()
        {
            // Arrange - URI with a non-SAS query param exercises the else branch
            // where SAS is joined to the existing query with '&'
            Uri uriWithQuery = new Uri($"{FileUri}?comp=list");
            ShareFileClient client = new ShareFileClient(uriWithQuery, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert - existing query preserved, SAS joined with '&'
            string query = result.Query;
            StringAssert.Contains("comp=list", query);
            StringAssert.Contains("sv=2020-08-04", query);
            StringAssert.Contains("sig=abc", query);
            StringAssert.DoesNotContain("??", result.AbsoluteUri);
        }

        [Test]
        public void GetUriWithSas_UriAlreadyContainsSas_DoesNotAppendDuplicateSas()
        {
            // Arrange - URI already has SAS params, so uriBuilder.Sas != null
            // and the method should return the URI as-is without appending again.
            string existingSas = "sv=2020-08-04&ss=b&srt=o&sig=existing";
            Uri uriWithSas = new Uri($"{FileUri}?{existingSas}");
            // Create client without AzureSasCredential (URI-embedded SAS)
            ShareFileClient client = new ShareFileClient(uriWithSas);

            // Act
            Uri result = TestShareFileClient.CallGetUriWithSas(client);

            // Assert - no SasCredential, returns original URI
            Assert.AreEqual(uriWithSas, result);
        }
    }
}
