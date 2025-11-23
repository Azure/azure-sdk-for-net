// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    /// <summary>
    /// Serves as a base class for tests related to the Content Understanding client, providing common setup,
    /// configuration, and utility methods for derived test classes.
    /// </summary>
    /// <remarks>This class extends <see cref="RecordedTestBase{T}"/> to enable integration testing with
    /// recorded sessions. It includes functionality for configuring sanitizers to redact sensitive information from
    /// logs and telemetry, enforcing custom test timeouts, and creating instrumented instances of the <see
    /// cref="ContentUnderstandingClient"/> for testing purposes.</remarks>
    public class ContentUnderstandingTestBase : RecordedTestBase<ContentUnderstandingClientTestEnvironment>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentUnderstandingTestBase"/> class.
        /// </summary>
        /// <param name="isAsync">A value indicating whether the test should be executed asynchronously. <see langword="true"/> to enable
        /// asynchronous execution; otherwise, <see langword="false"/>.</param>
        public ContentUnderstandingTestBase(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Performs teardown operations after each test execution, enforcing a custom timeout limit.
        /// </summary>
        /// <remarks>If the debugger is not attached, this method calculates the duration of the test
        /// execution  and throws a <see cref="TestTimeoutException"/> if the duration exceeds the predefined timeout
        /// limit of 1200 seconds.</remarks>
        /// <exception cref="TestTimeoutException">Thrown if the test execution duration exceeds the custom timeout limit of 1200 seconds.</exception>
        [TearDown]
        public override void GlobalTimeoutTearDown()
        {
            if (Debugger.IsAttached)
            {
                return;
            }

            var duration = DateTime.UtcNow - TestStartTime;
            var timeout = 1200;

            if (duration > TimeSpan.FromSeconds(timeout))
            {
                throw new TestTimeoutException($"Test exceeded custom time limit of {timeout} seconds. Duration: {duration}");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentUnderstandingTestBase"/> class.
        /// </summary>
        /// <param name="isAsync">Indicates whether the test should run in asynchronous mode.</param>
        /// <param name="mode">The optional <see cref="RecordedTestMode"/> to use for the test. If not specified, the default mode is used.</param>
        public ContentUnderstandingTestBase(bool isAsync, RecordedTestMode? mode = null)
            : base(isAsync, mode)
        {
            ConfigureSanitizers();
        }

        /// <summary>
        /// Configures sanitizers to redact sensitive information from URIs, request/response bodies, and headers in
        /// logs or telemetry data.
        /// </summary>
        /// <remarks>This method sets up a series of sanitizers to replace sensitive data with sanitized
        /// values: <list type="bullet"> <item> <description>Replaces service endpoint URIs with a generic sanitized
        /// URI.</description> </item> <item> <description>Redacts Blob Storage URLs to a sanitized
        /// format.</description> </item> <item> <description>Sanitizes specific fields in request/response bodies, such
        /// as <c>containerUrl</c> and <c>fileListPath</c>.</description> </item> <item> <description>Removes sensitive
        /// headers, including <c>Ocp-Apim-Subscription-Key</c> and <c>Authorization</c>.</description> </item> </list>
        /// This ensures that sensitive information is not exposed in logs or telemetry data.</remarks>
        private void ConfigureSanitizers()
        {
            // Key: Add URI sanitizer to replace real service endpoint with sanitized version
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                regex: @"https://[a-zA-Z0-9\-]+\.services\.ai\.azure\.com"
            )
            {
                Value = "https://sanitized.services.ai.azure.com"
            });

            // Sanitize Blob Storage URLs
            UriRegexSanitizers.Add(new UriRegexSanitizer(
                regex: @"https://[a-zA-Z0-9]+\.blob\.core\.windows\.net"
            )
            {
                Value = "https://sanitized.blob.core.windows.net"
            });

            // Sanitize containerUrl in request/response body
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                regex: @"""containerUrl""\s*:\s*""[^""]*"""
            )
            {
                Value = @"""containerUrl"":""https://sanitized.blob.core.windows.net/container"""
            });

            // Sanitize fileListPath in request/response body
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(
                regex: @"""fileListPath""\s*:\s*""[^""]*"""
            )
            {
                Value = @"""fileListPath"":""sanitized/path/files.txt"""
            });

            // Sanitize sensitive headers
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            SanitizedHeaders.Add("Authorization");
        }

        /// <summary>
        /// Creates and configures an instance of the <see cref="ContentUnderstandingClient"/> for interacting with the
        /// Content Understanding service.
        /// </summary>
        /// <remarks>This method initializes the client using the endpoint and credentials provided by the
        /// test environment. If an API key is available, it uses an <see cref="AzureKeyCredential"/> for
        /// authentication; otherwise, it falls back to the default credential.</remarks>
        /// <returns>A fully configured <see cref="ContentUnderstandingClient"/> instance ready for use.</returns>
        protected ContentUnderstandingClient CreateClient()
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());

            string apiKey = TestEnvironment.ApiKey;

            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                var keyCredential = new AzureKeyCredential(apiKey);
                return InstrumentClient(new ContentUnderstandingClient(endpoint, keyCredential, options));
            }
            else
            {
                var credential = TestEnvironment.Credential;
                return InstrumentClient(new ContentUnderstandingClient(endpoint, credential, options));
            }
        }
    }
}
