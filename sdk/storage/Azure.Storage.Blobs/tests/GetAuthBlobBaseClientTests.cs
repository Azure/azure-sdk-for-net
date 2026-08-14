// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class GetAuthBlobBaseClientTests
    {
        private const string AccountName = "account";
        private const string ContainerName = "container";
        private const string BlobName = "blob";
        private static readonly Uri BlobUri = new Uri($"https://{AccountName}.blob.core.windows.net/{ContainerName}/{BlobName}");
        private const string SasWithoutQuestionMark = "sv=2020-08-04&ss=b&srt=o&sig=abc";
        private const string SasWithQuestionMark = "?" + SasWithoutQuestionMark;

        /// <summary>
        /// Helper to access the protected static <see cref="BlobBaseClient.GetUriWithSas"/> method.
        /// </summary>
        private class TestBlobBaseClient : BlobBaseClient
        {
            public static Uri CallGetUriWithSas(BlobBaseClient client) => GetUriWithSas(client);
        }

        [Test]
        public void GetUriWithSas_NoSasCredential_ReturnsOriginalUri()
        {
            // Arrange
            BlobBaseClient client = new BlobBaseClient(BlobUri);

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

            // Assert
            Assert.AreEqual(BlobUri, result);
        }

        [Test]
        public void GetUriWithSas_SasWithLeadingQuestionMark_StripsQuestionMark()
        {
            // Arrange
            BlobBaseClient client = new BlobBaseClient(BlobUri, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

            // Assert - SAS appended correctly, no double '?'
            StringAssert.Contains("sv=2020-08-04", result.Query);
            StringAssert.Contains("sig=abc", result.Query);
            StringAssert.DoesNotContain("??", result.AbsoluteUri);
        }

        [Test]
        public void GetUriWithSas_SasWithoutLeadingQuestionMark_AppendsSas()
        {
            // Arrange
            BlobBaseClient client = new BlobBaseClient(BlobUri, new AzureSasCredential(SasWithoutQuestionMark));

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

            // Assert
            StringAssert.Contains("sv=2020-08-04", result.Query);
            StringAssert.Contains("sig=abc", result.Query);
        }

        [Test]
        public void GetUriWithSas_SasWithLeadingQuestionMark_UriWithSnapshot_PreservesSnapshotAndAppendsSas()
        {
            // Arrange
            string snapshot = "snap1";
            Uri snapshotUri = new Uri($"{BlobUri}?snapshot={snapshot}");
            BlobBaseClient client = new BlobBaseClient(snapshotUri, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

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
            Uri versionUri = new Uri($"{BlobUri}?versionid={versionId}");
            BlobBaseClient client = new BlobBaseClient(versionUri, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

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
            Uri uriWithQuery = new Uri($"{BlobUri}?comp=list");
            BlobBaseClient client = new BlobBaseClient(uriWithQuery, new AzureSasCredential(SasWithQuestionMark));

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

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
            Uri uriWithSas = new Uri($"{BlobUri}?{existingSas}");
            // Create client without AzureSasCredential (URI-embedded SAS)
            BlobBaseClient client = new BlobBaseClient(uriWithSas);

            // Act
            Uri result = TestBlobBaseClient.CallGetUriWithSas(client);

            // Assert - no SasCredential, returns original URI
            Assert.AreEqual(uriWithSas, result);
        }
    }
}
