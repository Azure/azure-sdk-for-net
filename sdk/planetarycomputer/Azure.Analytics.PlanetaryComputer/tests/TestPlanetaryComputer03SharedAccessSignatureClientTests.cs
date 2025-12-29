// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for Shared Access Signature (SAS) operations.
    /// Based on Python test: test_planetary_computer_03_shared_access_signature.py
    /// </summary>
    [AsyncOnly]
    public class TestPlanetaryComputer03SharedAccessSignatureClientTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer03SharedAccessSignatureClientTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test generating a SAS token with default duration.
        /// Python equivalent: test_01_get_token_with_default_duration
        /// C# method: GetToken(collectionId, durationInMinutes=null)
        /// </summary>
        [Test]
        [Category("SAS")]
        [Category("SharedAccessSignature")]
        public async Task Test03_01_GetTokenWithDefaultDuration()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetToken with collection: {collectionId}");
            TestContext.WriteLine("\n=== Making Request ===");
            TestContext.WriteLine($"POST /sas/token?collection={collectionId}");

            // Act
            Response<SharedAccessSignatureToken> response = await sasClient.GetTokenAsync(collectionId);

            // Log raw response
            TestContext.WriteLine("\n=== Raw Response ===");
            TestContext.WriteLine($"Status: {response.GetRawResponse().Status} {response.GetRawResponse().ReasonPhrase}");
            TestContext.WriteLine($"Content-Type: {response.GetRawResponse().Headers.ContentType}");

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetToken");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            SharedAccessSignatureToken token = response.Value;

            TestContext.WriteLine("\n=== Analyzing Response Properties ===");
            TestContext.WriteLine($"Token value: {token.Token?.Substring(0, Math.Min(20, token.Token?.Length ?? 0))}... (length: {token.Token?.Length})");
            TestContext.WriteLine($"Expires On: {token.ExpiresOn}");

            // Verify token field exists
            ValidateNotNullOrEmpty(token.Token, "token");

            // Verify token format (should contain SAS parameters: st, se, sp, sv, sr, sig)
            // In playback mode, token may be sanitized, so only validate in live mode
            if (Mode == RecordedTestMode.Live)
            {
                var sasPattern = new Regex(@"st=[^&]+&se=[^&]+&sp=[^&]+&sv=[^&]+&sr=[^&]+&.*sig=[^&]+");
                Assert.IsTrue(sasPattern.IsMatch(token.Token), "Token should match SAS token format (st, se, sp, sv, sr, sig)");
            }

            // Verify expires_on field exists
            DateTimeOffset expiresOn = token.ExpiresOn;

            // Verify expiry is in the future (only in live mode)
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Greater(expiresOn, DateTimeOffset.UtcNow, "Token expiry should be in the future");

                // Verify default duration is approximately 24 hours (allow 5 minute tolerance)
                TimeSpan expectedDuration = TimeSpan.FromHours(24);
                TimeSpan actualDuration = expiresOn - DateTimeOffset.UtcNow;
                TimeSpan tolerance = TimeSpan.FromMinutes(5);

                Assert.That(Math.Abs((actualDuration - expectedDuration).TotalSeconds), Is.LessThan(tolerance.TotalSeconds),
                    $"Expiry should be ~24 hours from now. Actual: {actualDuration.TotalHours:F2} hours");
            }

            TestContext.WriteLine($"Successfully retrieved SAS token. Status: {response.GetRawResponse().Status}");
            TestContext.WriteLine($"Token expires: {expiresOn:yyyy-MM-dd HH:mm:ss} UTC");
        }

        /// <summary>
        /// Test generating a SAS token with custom duration (60 minutes).
        /// Python equivalent: test_02_get_token_with_custom_duration
        /// C# method: GetToken(collectionId, durationInMinutes=60)
        /// </summary>
        [Test]
        [Category("SAS")]
        [Category("SharedAccessSignature")]
        public async Task Test03_02_GetTokenWithCustomDuration()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            string collectionId = TestEnvironment.CollectionId;
            int customDuration = 60; // 60 minutes

            TestContext.WriteLine($"Requesting SAS token with custom duration: {customDuration} minutes");

            // Act
            Response<SharedAccessSignatureToken> response = await sasClient.GetTokenAsync(collectionId, durationInMinutes: customDuration);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetToken");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            SharedAccessSignatureToken token = response.Value;

            // Verify token field
            ValidateNotNullOrEmpty(token.Token, "token");

            // Verify expires_on field
            DateTimeOffset expiresOn = token.ExpiresOn;

            // Verify custom duration (only in live mode)
            if (Mode == RecordedTestMode.Live)
            {
                Assert.Greater(expiresOn, DateTimeOffset.UtcNow, "Token expiry should be in the future");

                // Verify duration is approximately 60 minutes (allow 2 minute tolerance)
                TimeSpan expectedDuration = TimeSpan.FromMinutes(customDuration);
                TimeSpan actualDuration = expiresOn - DateTimeOffset.UtcNow;
                TimeSpan tolerance = TimeSpan.FromMinutes(2);

                Assert.That(Math.Abs((actualDuration - expectedDuration).TotalSeconds), Is.LessThan(tolerance.TotalSeconds),
                    $"Expiry should be ~{customDuration} minutes from now. Actual: {actualDuration.TotalMinutes:F2} minutes");
            }

            TestContext.WriteLine($"Successfully retrieved SAS token with custom duration. Status: {response.GetRawResponse().Status}");
            TestContext.WriteLine($"Token expires: {expiresOn:yyyy-MM-dd HH:mm:ss} UTC");
        }

        /// <summary>
        /// Test signing an asset HREF using collection thumbnail.
        /// Python equivalent: test_03_get_sign_with_collection_thumbnail
        /// C# method: GetSign(href, durationInMinutes=null)
        /// </summary>
        [Test]
        [Category("SAS")]
        [Category("SharedAccessSignature")]
        public async Task Test03_03_GetSignWithCollectionThumbnail()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetSign with collection: {collectionId}");

            // Get collection to retrieve thumbnail asset
            TestContext.WriteLine("Getting collection...");
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;

            Assert.IsNotNull(collection, "Collection should not be null");
            Assert.IsNotNull(collection.Assets, "Collection should have assets");
            Assert.IsTrue(collection.Assets.ContainsKey("thumbnail"), "Collection should have thumbnail asset");

            StacAsset thumbnailAsset = collection.Assets["thumbnail"];
            string originalHrefString = thumbnailAsset.Href;
            Uri originalHref = new Uri(originalHrefString);
            TestContext.WriteLine($"Original HREF: {originalHref}");
            Assert.IsNotNull(originalHref, "Thumbnail HREF should not be null");

            // Act - Sign the HREF
            TestContext.WriteLine($"Calling GetSign(href={originalHref})");
            Response<SharedAccessSignatureSignedLink> signResponse = await sasClient.GetSignAsync(originalHref);

            // Assert
            ValidateResponse(signResponse.GetRawResponse(), "GetSign");
            Assert.AreEqual(200, signResponse.GetRawResponse().Status, "Expected successful response");

            SharedAccessSignatureSignedLink signedLink = signResponse.Value;
            Uri signedHref = signedLink.Href;

            TestContext.WriteLine($"Signed HREF: {signedHref}");
            TestContext.WriteLine($"HREF changed: {signedHref != originalHref}");
            TestContext.WriteLine($"Has query params: {signedHref.Query.Length > 0}");
            TestContext.WriteLine($"Has sig param: {signedHref.Query.Contains("sig=")}");

            // Verify signed HREF is different from original
            Assert.AreNotEqual(originalHref, signedHref, "Signed HREF should differ from original HREF");

            // Verify SAS parameters in HREF (only in live mode)
            if (Mode == RecordedTestMode.Live)
            {
                var sasHrefPattern = new Regex(@"\?.*st=[^&]+&se=[^&]+&sp=[^&]+&sv=[^&]+&sr=[^&]+&.*sig=[^&]+");
                Assert.IsTrue(sasHrefPattern.IsMatch(signedHref.ToString()),
                    "Signed HREF should contain SAS parameters (st, se, sp, sv, sr, sig)");
            }
            else
            {
                // In playback mode, just verify basic SAS structure exists
                Assert.IsTrue(signedHref.Query.Length > 0, "Signed HREF should have query parameters");
                Assert.IsTrue(signedHref.Query.ToLower().Contains("sig="), "Signed HREF should contain signature parameter");
            }

            // Verify expires_on is present and valid
            if (signedLink.ExpiresOn.HasValue)
            {
                TestContext.WriteLine($"Expires On: {signedLink.ExpiresOn.Value:yyyy-MM-dd HH:mm:ss} UTC");

                if (Mode == RecordedTestMode.Live)
                {
                    Assert.Greater(signedLink.ExpiresOn.Value, DateTimeOffset.UtcNow,
                        "Token expiry should be in the future");
                }
            }

            // Verify the signed HREF has the same base URL as original
            string originalBase = originalHref.GetLeftPart(UriPartial.Path);
            string signedBase = signedHref.GetLeftPart(UriPartial.Path);
            Assert.AreEqual(originalBase, signedBase, "Signed HREF should have the same base URL as original");

            TestContext.WriteLine("Successfully signed HREF");
        }

        /// <summary>
        /// Test that a signed HREF can be used to download an asset.
        /// Python equivalent: test_04_signed_href_can_download_asset
        /// C# method: GetSign(href) followed by HTTP download
        /// </summary>
        [Test]
        [Category("SAS")]
        [Category("SharedAccessSignature")]
        public async Task Test03_04_SignedHrefCanDownloadAsset()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing signed HREF download with collection: {collectionId}");

            // Get collection thumbnail
            TestContext.WriteLine("Getting collection...");
            Response<StacCollectionResource> collectionResponse = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = collectionResponse.Value;
            string thumbnailHrefString = collection.Assets["thumbnail"].Href;
            Uri thumbnailHref = new Uri(thumbnailHrefString);
            TestContext.WriteLine($"Thumbnail HREF: {thumbnailHref}");

            // Get signed HREF
            TestContext.WriteLine($"Calling GetSign(href={thumbnailHref})");
            Response<SharedAccessSignatureSignedLink> signResponse = await sasClient.GetSignAsync(thumbnailHref);
            Uri signedHref = signResponse.Value.Href;
            TestContext.WriteLine($"Signed HREF: {signedHref}");

            // Only attempt download in live mode
            if (Mode == RecordedTestMode.Live)
            {
                TestContext.WriteLine("Attempting to download asset (live mode)...");

                using (var httpClient = new HttpClient())
                {
                    HttpResponseMessage downloadResponse = await httpClient.GetAsync(signedHref);

                    TestContext.WriteLine($"Download status code: {(int)downloadResponse.StatusCode} {downloadResponse.StatusCode}");
                    TestContext.WriteLine($"Content-Type: {downloadResponse.Content.Headers.ContentType}");

                    // Verify successful download
                    Assert.AreEqual(System.Net.HttpStatusCode.OK, downloadResponse.StatusCode,
                        $"Expected 200 OK, got {(int)downloadResponse.StatusCode}");

                    byte[] content = await downloadResponse.Content.ReadAsByteArrayAsync();
                    TestContext.WriteLine($"Content length: {content.Length} bytes");

                    Assert.Greater(content.Length, 0, "Downloaded content should not be empty");
                    Assert.Greater(content.Length, 1000, "Downloaded file should be larger than 1KB");

                    // Verify it's actually binary image data by checking PNG magic bytes
                    Assert.AreEqual(0x89, content[0], "First byte should be 0x89 (PNG magic)");
                    Assert.AreEqual((byte)'P', content[1], "Second byte should be 'P'");
                    Assert.AreEqual((byte)'N', content[2], "Third byte should be 'N'");
                    Assert.AreEqual((byte)'G', content[3], "Fourth byte should be 'G'");

                    TestContext.WriteLine("Successfully downloaded and verified PNG image");
                }
            }
            else
            {
                TestContext.WriteLine("Skipping download test (playback mode)");
            }

            TestContext.WriteLine("Test completed");
        }

        /// <summary>
        /// Test revoking a SAS token.
        /// Python equivalent: test_05_revoke_token
        /// C# method: RevokeToken()
        /// Note: This test runs LAST to avoid breaking other tests.
        /// </summary>
        [Test]
        [Category("SAS")]
        [Category("SharedAccessSignature")]
        [Order(100)] // Run this test last
        public async Task Test03_05_RevokeToken()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing RevokeToken for collection: {collectionId}");

            // Step 1: Generate a SAS token first
            TestContext.WriteLine("Step 1: Generating SAS token...");
            Response<SharedAccessSignatureToken> tokenResponse = await sasClient.GetTokenAsync(
                collectionId,
                durationInMinutes: 60);

            Assert.IsNotNull(tokenResponse, "Token response should not be null");
            Assert.IsNotNull(tokenResponse.Value, "Token value should not be null");

            string tokenPreview = tokenResponse.Value.Token.Length > 50
                ? tokenResponse.Value.Token.Substring(0, 50) + "..."
                : tokenResponse.Value.Token;
            TestContext.WriteLine($"Token generated: {tokenPreview}");

            // Step 2: Revoke the token
            TestContext.WriteLine("Step 2: Revoking token...");
            Response revokeResponse = await sasClient.RevokeTokenAsync();

            // Assert
            ValidateResponse(revokeResponse, "RevokeToken");
            TestContext.WriteLine($"Token revoked successfully. Status: {revokeResponse.Status}");
            TestContext.WriteLine("No exception thrown - revocation successful");
        }
    }
}
