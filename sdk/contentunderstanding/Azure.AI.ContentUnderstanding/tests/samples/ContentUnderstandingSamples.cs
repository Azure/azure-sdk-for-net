// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.AI.ContentUnderstanding.Samples
{
    [AsyncOnly] // Ensure that each sample will only run once.
    public partial class ContentUnderstandingSamples : RecordedTestBase<ContentUnderstandingClientTestEnvironment>
    {
        public ContentUnderstandingSamples(bool isAsync) : base(isAsync)
        {
            // Disable diagnostic validation for samples (they're for documentation, not full test coverage)
            TestDiagnostics = false;

            // Sanitize endpoint URLs in request/response URIs
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                regex: @"https://[a-zA-Z0-9\-]+\.services\.ai\.azure\.com"
            )
            {
                Value = "https://sanitized.services.ai.azure.com"
            });

            // Sanitize endpoint URLs in headers (e.g., Operation-Location header)
            // This uses regex to match and replace the endpoint URL in header values
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Operation-Location")
            {
                Regex = @"https://[a-zA-Z0-9\-]+\.services\.ai\.azure\.com",
                Value = "https://sanitized.services.ai.azure.com"
            });

            // Sanitize resource IDs and regions in request bodies (for GrantCopyAuthorization and CopyAnalyzer)
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                regex: @"""targetAzureResourceId""\s*:\s*""[^""]*"""
            )
            {
                Value = @"""targetAzureResourceId"":""Sanitized"""
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                regex: @"""targetRegion""\s*:\s*""[^""]*"""
            )
            {
                Value = @"""targetRegion"":""Sanitized"""
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                regex: @"""sourceAzureResourceId""\s*:\s*""[^""]*"""
            )
            {
                Value = @"""sourceAzureResourceId"":""Sanitized"""
            });

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                regex: @"""sourceRegion""\s*:\s*""[^""]*"""
            )
            {
                Value = @"""sourceRegion"":""Sanitized"""
            });
        }
    }
}
