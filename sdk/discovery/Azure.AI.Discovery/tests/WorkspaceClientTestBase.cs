// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Base class for Azure.AI.Discovery Workspace tests.
    /// Provides WorkspaceClient creation and common test utilities.
    /// </summary>
    public class WorkspaceClientTestBase : RecordedTestBase<DiscoveryTestEnvironment>
    {
        public WorkspaceClientTestBase(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;

            // Sanitize headers
            SanitizedHeaders.Add("x-ms-request-id");
            SanitizedHeaders.Add("x-ms-correlation-request-id");
            SanitizedHeaders.Add("mise-correlation-id");

            // Sanitize workspace endpoint URLs
            UriRegexSanitizers.Add(new Core.TestFramework.Models.UriRegexSanitizer(
                @"https://[a-zA-Z0-9-]+\.workspace[-a-z]*\.discovery\.azure\.com")
                { Value = "https://Sanitized.workspace.discovery.azure.com" });

            BodyRegexSanitizers.Add(new Core.TestFramework.Models.BodyRegexSanitizer(
                @"https://[a-zA-Z0-9-]+\.workspace[-a-z]*\.discovery\.azure\.com")
                { Value = "https://Sanitized.workspace.discovery.azure.com" });

            // Sanitize investigation names in URIs
            UriRegexSanitizers.Add(new Core.TestFramework.Models.UriRegexSanitizer(
                @"/investigations/[a-zA-Z0-9-]+")
                { Value = "/investigations/Sanitized" });

            BodyRegexSanitizers.Add(new Core.TestFramework.Models.BodyRegexSanitizer(
                @"""projectName"":\s*""[^""]+""")
                { Value = @"""projectName"": ""Sanitized""" });

            BodyRegexSanitizers.Add(new Core.TestFramework.Models.BodyRegexSanitizer(
                @"""createdBy"":\s*""[^""]+""")
                { Value = @"""createdBy"": ""Sanitized""" });

            BodyRegexSanitizers.Add(new Core.TestFramework.Models.BodyRegexSanitizer(
                @"""lastModifiedBy"":\s*""[^""]+""")
                { Value = @"""lastModifiedBy"": ""Sanitized""" });

            // Sanitize workspace endpoint in operation-location response header
            // so LRO polling URLs match sanitized recording entries during playback.
            HeaderRegexSanitizers.Add(new Core.TestFramework.Models.HeaderRegexSanitizer("operation-location")
            {
                Regex = @"https://[a-zA-Z0-9-]+\.workspace[-a-z]*\.discovery\.azure\.com",
                Value = "https://Sanitized.workspace.discovery.azure.com"
            });
        }

        /// <summary>
        /// Creates a WorkspaceClient configured for testing.
        /// </summary>
        protected WorkspaceClient CreateWorkspaceClient(WorkspaceClientOptions options = null)
        {
            options ??= new WorkspaceClientOptions();

            var endpoint = new Uri(TestEnvironment.WorkspaceEndpoint);
            var credential = TestEnvironment.Credential;

            var client = new WorkspaceClient(endpoint, credential, InstrumentClientOptions(options));
            return InstrumentClient(client);
        }

        /// <summary>
        /// Creates a WorkspaceClient with API key authentication.
        /// </summary>
        protected WorkspaceClient CreateWorkspaceClientWithKey(WorkspaceClientOptions options = null)
        {
            options ??= new WorkspaceClientOptions();

            var endpoint = new Uri(TestEnvironment.WorkspaceEndpoint);
            var credential = TestEnvironment.Credential;

            var client = new WorkspaceClient(endpoint, credential, InstrumentClientOptions(options));
            return InstrumentClient(client);
        }

        /// <summary>
        /// Validates that a response is not null.
        /// </summary>
        protected static void ValidateResponse<T>(T response, string responseName = null) where T : class
        {
            Assert.That(response, Is.Not.Null, $"{responseName ?? typeof(T).Name} response should not be null");
        }

        /// <summary>
        /// Validates that a string is not null or empty.
        /// </summary>
        protected static void ValidateNotNullOrEmpty(string value, string propertyName)
        {
            Assert.That(value, Is.Not.Null.And.Not.Empty, $"{propertyName} should not be null or empty");
        }
    }
}
