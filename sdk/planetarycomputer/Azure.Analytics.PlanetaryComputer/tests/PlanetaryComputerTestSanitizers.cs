// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Provides sanitization configuration for Azure.Analytics.PlanetaryComputer test recordings.
    /// This class centralizes all sanitization patterns and replacement values to match Python test patterns.
    /// </summary>
    public static class PlanetaryComputerTestSanitizers
    {
        // UUID pattern for various IDs
        private const string UUID_PATTERN = @"[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}";

        // Replacement values - matching Python SDK patterns
        private const string SANITIZED_ZERO_UUID = "00000000-0000-0000-0000-000000000000";
        private const string SANITIZED_ZERO_UUID_32 = "00000000000000000000000000000000"; // 32 chars without hyphens
        private const string SANITIZED_HOST = "SANITIZED";
        private const string REDACTED = "REDACTED";
        private const string SANITIZED_DATE = "Mon, 01 Jan 2024 00:00:00 GMT";
        private const string SANITIZED_TRACEPARENT = "00-00000000000000000000000000000000-0000000000000000-00";
        private const string SANITIZED_COOKIE = "cookie;";
        private const string SANITIZED_SET_COOKIE = "[set-cookie;]";
        private const string SANITIZED_SERVER_TIMING = "total;dur=0.0";
        private const string SANITIZED_ACCESS_TOKEN = "access_token";

        public static void ApplySanitizers(PlanetaryComputerTestBase testBase)
        {
            // Remove default AZSDK sanitizers that are too aggressive for public data
            // These sanitizers remove "name" and "id" fields which are public collection/item identifiers
            testBase.SanitizersToRemove.Add("AZSDK3493"); // Removes "name" fields
            testBase.SanitizersToRemove.Add("AZSDK3430"); // Removes "id" fields
            testBase.SanitizersToRemove.Add("AZSDK2003"); // Default hostname sanitizer that reduces URLs to "Sanitized.com"
            testBase.SanitizersToRemove.Add("AZSDK4001"); // Replaces entire host name in URL - we use custom hostname sanitizer
            testBase.SanitizersToRemove.Add("AZSDK3447"); // Don't sanitize path segments - collection IDs are public

            // Credential sanitizers using JSONPath - these values should always be sanitized
            testBase.JsonPathSanitizers.Add("$..access_token");
            testBase.JsonPathSanitizers.Add("$..refresh_token");
            testBase.JsonPathSanitizers.Add("$..subscription_id");
            testBase.JsonPathSanitizers.Add("$..tenant_id");
            testBase.JsonPathSanitizers.Add("$..client_id");
            testBase.JsonPathSanitizers.Add("$..client_secret");

            // Header sanitizers - matching Python SDK patterns exactly
            // Note: Don't specify Regex property - default behavior replaces entire header value
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Set-Cookie") { Value = SANITIZED_SET_COOKIE });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Cookie") { Value = SANITIZED_COOKIE });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("X-Request-ID") { Value = SANITIZED_ZERO_UUID_32 });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Date") { Value = SANITIZED_DATE });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Server-Timing") { Value = SANITIZED_SERVER_TIMING });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("traceparent") { Value = SANITIZED_TRACEPARENT });

            // Additional header sanitizers for Azure-specific headers
            testBase.SanitizedHeaders.Add("operation-location");
            testBase.SanitizedHeaders.Add("Location");
            testBase.SanitizedHeaders.Add("mise-correlation-id");

            // UUID-based headers (for Azure-specific headers with UUIDs)
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("apim-request-id")
            {
                Regex = UUID_PATTERN,
                Value = SANITIZED_ZERO_UUID
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("x-ms-client-request-id")
            {
                Regex = UUID_PATTERN,
                Value = SANITIZED_ZERO_UUID
            });
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Authorization")
            {
                Regex = @"Bearer\s+.+",
                Value = $"Bearer {REDACTED}"
            });

            // Sanitize operation-location header for LRO polling
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("operation-location")
            {
                Regex = @"/operations/[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}",
                Value = $"/operations/{SANITIZED_ZERO_UUID}"
            });

            // Sanitize Location header for ingestion sources
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = @"/ingestion-sources/[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}",
                Value = $"/ingestion-sources/{SANITIZED_ZERO_UUID}"
            });

            // Sanitize Location header for ingestions
            testBase.HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Location")
            {
                Regex = @"/ingestions/[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}",
                Value = $"/ingestions/{SANITIZED_ZERO_UUID}"
            });

            // Endpoint sanitizer for geocatalog endpoints - sanitize the full subdomain before .geocatalog
            // Pattern: test-accessibility.h5d5a9crhnc8deaz.uksouth.geocatalog.spatio.azure.com
            // Becomes: Sanitized.sanitized_label.sanitized_location.geocatalog.spatio.azure.com
            // Match Python pattern with capital 'S' in Sanitized
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=https://)[^.]+\.[^.]+\.[^.]+(?=\.geocatalog\.spatio\.azure\.com)")
            {
                Value = "Sanitized.sanitized_label.sanitized_location"
            });

            // Also sanitize geocatalog endpoints in response body JSON
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"https://[^.]+\.[^.]+\.[^.]+\.geocatalog\.spatio\.azure\.com")
            {
                Value = "https://Sanitized.sanitized_label.sanitized_location.geocatalog.spatio.azure.com"
            });

            // Storage account sanitizer for Azure blob storage URLs
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=https://)([^.]+)(?=\.blob\.core\.windows\.net)")
            {
                Value = SANITIZED_HOST
            });

            // Sanitize blob storage URLs in response body (for asset hrefs)
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"https://[a-z0-9]+\.blob\.core\.windows\.net")
            {
                Value = $"https://{SANITIZED_HOST}.blob.core.windows.net"
            });

            // Sanitize URL-encoded blob storage URLs (e.g., in query parameters)
            // Matches: https%3A%2F%2Fcontosdatasa.blob.core.windows.net → https%3A%2F%2FSANITIZED.blob.core.windows.net
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"https%3A%2F%2F[a-z0-9]+\.blob\.core\.windows\.net")
            {
                Value = $"https%3A%2F%2F{SANITIZED_HOST}.blob.core.windows.net"
            });

            // Sanitize operation IDs (UUIDs) in URL paths
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/operations/)[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize ingestion source IDs (UUIDs) in URL paths
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/ingestion-sources/)[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize ingestion IDs (UUIDs) in URL paths
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/ingestions/)[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize run IDs (UUIDs) in URL paths
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/runs/)[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize UUIDs in JSON "id" fields (but not public collection/item IDs which are strings, not UUIDs)
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"""id""\s*:\s*""[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}""")
            {
                Value = $@"""id"": ""{SANITIZED_ZERO_UUID}"""
            });

            // Sanitize subscription_id in URLs
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=/subscriptions/)([0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12})")
            {
                Value = SANITIZED_ZERO_UUID
            });
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=subscription_id=)([0-9a-f-]+)")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize tenant_id in query parameters
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=tenant_id=)([0-9a-f-]+)")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize client_id in query parameters
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=client_id=)([0-9a-f-]+)")
            {
                Value = SANITIZED_ZERO_UUID
            });

            // Sanitize client_secret in query parameters
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=client_secret=)([^&]+)")
            {
                Value = REDACTED
            });

            // Sanitize access_token in query parameters
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=access_token=)([^&]+)")
            {
                Value = REDACTED
            });

            // Sanitize refresh_token in query parameters
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"(?<=refresh_token=)([^&]+)")
            {
                Value = REDACTED
            });

            // Sanitize UUIDs in JSON bodies - containerUrl and containerUri
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"(?<=""containerUrl"":"")[^""]+")
            {
                Value = $"https://{SANITIZED_HOST}.blob.core.windows.net/{SANITIZED_HOST}"
            });
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"(?<=""containerUri"":"")[^""]+")
            {
                Value = $"https://{SANITIZED_HOST}.blob.core.windows.net/{SANITIZED_HOST}"
            });

            // Sanitize access_token in response bodies - matching Python pattern
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"""access_token""\s*:\s*""[^""]+""")
            {
                Value = $@"""access_token"": ""{SANITIZED_ACCESS_TOKEN}"""
            });

            // Sanitize SAS tokens in request/response bodies
            // SAS tokens contain sensitive signature data that must not be recorded
            // Pattern matches full SAS token query string format: sv=2021-01-01&st=...&sig=...
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"""sasToken""\s*:\s*""[^""]+""")
            {
                Value = @"""sasToken"": ""sv=2021-01-01&st=2020-01-01T00:00:00Z&se=2099-12-31T23:59:59Z&sr=c&sp=rl&sig=Sanitized"""
            });

            // Collection ID sanitizers
            // Python pattern: r"(?P<collection_id>[a-z0-9]+-[a-z]+-[a-z0-9]+)-[0-9a-f]{8}"
            // This matches collection IDs like "naip-atl-20231201-a1b2c3d4" where the hash suffix needs sanitization
            // Example: "naip-atl-20231201-a1b2c3d4" becomes "naip-atl-20231201-00000000"

            // Sanitize in URLs (query params, path segments)
            testBase.UriRegexSanitizers.Add(new UriRegexSanitizer(@"([a-z0-9]+-[a-z]+-[a-z0-9]+)-[0-9a-f]{8}")
            {
                Value = "$1-00000000"
            });

            // Sanitize in JSON bodies
            testBase.BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"""([a-z0-9]+-[a-z]+-[a-z0-9]+)-[0-9a-f]{8}""")
            {
                Value = @"""$1-00000000"""
            });

            // DO NOT sanitize collection names in URL paths - they are public identifiers
            // This ensures that test collection names like "test-collection-lifecycle" are preserved
            // in recordings for proper playback matching
            testBase.SanitizersToRemove.Add("AZSDK3447"); // Don't sanitize path segments
        }
    }
}
