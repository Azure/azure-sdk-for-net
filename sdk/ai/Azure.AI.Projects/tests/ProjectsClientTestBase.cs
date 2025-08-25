// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    /// <summary>
    /// Test base class that provides recording capabilities for Azure.AI.Projects.
    /// This class now uses a hybrid approach - it extends the standard Azure.Core RecordedTestBase
    /// but provides manual transport configuration for System.ClientModel compatibility.
    /// </summary>
    public class ProjectsClientTestBase : RecordedTestBase<AIProjectsTestEnvironment>
    {
        public ProjectsClientTestBase(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
            // Apply sanitizers to protect sensitive information in recordings
            ProjectsTestSanitizers.ApplySanitizers(this);
        }

        /// <summary>
        /// Creates a test client with recording capabilities.
        /// We manually configure the transport for recording/playback since AIProjectClientOptions
        /// uses System.ClientModel.ClientPipelineOptions rather than Azure.Core.ClientOptions.
        /// </summary>
        protected AIProjectClient GetTestClient(AIProjectClientOptions options = null)
        {
            options ??= new AIProjectClientOptions();

            // Configure the options for recording if not in live mode
            if (Mode != RecordedTestMode.Live && Recording != null)
            {
                // Set up proxy transport for recording/playback
                options.Transport = new Utils.ProjectsProxyTransport(Recording);

                // Configure retry policy for faster playback
                if (Mode == RecordedTestMode.Playback)
                {
                    options.RetryPolicy = new TestClientRetryPolicy(TimeSpan.FromMilliseconds(10));
                }
            }

            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var credential = TestEnvironment.Credential;

            var client = new AIProjectClient(new Uri(endpoint), credential, options);

            // Instrument the client for sync/async testing
            return client;// InstrumentClient(client);
        }

        /// <summary>
        /// Creates a client in live mode, bypassing any proxy transport.
        /// Use this when you need to test against real services.
        /// </summary>
        protected AIProjectClient GetLiveClient(AIProjectClientOptions options = null)
        {
            options ??= new AIProjectClientOptions();

            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var credential = TestEnvironment.Credential;

            var client = new AIProjectClient(new Uri(endpoint), credential, options);

            // Instrument the client for sync/async testing
            return InstrumentClient(client);
        }

        /// <summary>
        /// Helper method to validate common properties in test responses.
        /// </summary>
        protected static void ValidateNotNullOrEmpty(string value, string propertyName)
        {
            Assert.IsNotNull(value, $"{propertyName} should not be null");
            Assert.IsNotEmpty(value, $"{propertyName} should not be empty");
        }

        /// <summary>
        /// Helper method to validate that a response contains expected data.
        /// </summary>
        protected static void ValidateResponse<T>(T response, string responseName = null) where T : class
        {
            Assert.IsNotNull(response, $"{responseName ?? typeof(T).Name} response should not be null");
        }
    }
}
