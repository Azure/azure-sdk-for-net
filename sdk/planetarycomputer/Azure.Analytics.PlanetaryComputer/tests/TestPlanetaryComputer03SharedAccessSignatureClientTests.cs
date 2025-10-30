// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
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
            PlanetaryComputerClient client = GetTestClient();
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
            PlanetaryComputerClient client = GetTestClient();
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
    }
}
