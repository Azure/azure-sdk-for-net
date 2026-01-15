// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Azure.AI.Projects.OpenAI;
using Azure.AI.Projects.Tests.Utils;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    /// <summary>
    /// Test base class that provides recording capabilities for Azure.AI.Projects.
    /// This class now uses a hybrid approach - it extends the standard Azure.Core RecordedTestBase
    /// but provides manual transport configuration for System.ClientModel compatibility.
    /// </summary>
    public class ProjectsClientTestBase : RecordedTestBase<AIProjectsTestEnvironment>
    {
        #region Debug Method
        internal static PipelinePolicy GetDumpPolicy()
        {
            return new TestPipelinePolicy((message) =>
            {
                if (message.Request is not null && message.Response is null)
                {
                    Console.WriteLine($"--- New request ---");
                    IEnumerable<string> headerPairs = message?.Request?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                    string headers = string.Join(",", headerPairs);
                    Console.WriteLine($"Headers: {headers}");
                    Console.WriteLine($"{message?.Request?.Method} URI: {message?.Request?.Uri}");
                    if (message.Request?.Content != null)
                    {
                        string contentType = "Unknown Content Type";
                        if (message.Request.Headers?.TryGetValue("Content-Type", out contentType) == true
                            && contentType == "application/json")
                        {
                            using MemoryStream stream = new();
                            message.Request.Content.WriteTo(stream, default);
                            stream.Position = 0;
                            using StreamReader reader = new(stream);
                            string requestDump = reader.ReadToEnd();
                            stream.Position = 0;
                            requestDump = Regex.Replace(requestDump, @"""data"":[\\w\\r\\n]*""[^""]*""", @"""data"":""...""");
                            Console.WriteLine(requestDump);
                        }
                        else
                        {
                            string length = message.Request.Content.TryComputeLength(out long numberLength)
                                ? $"{numberLength} bytes"
                                : "unknown length";
                            Console.WriteLine($"<< Non-JSON content: {contentType} >> {length}");
                        }
                    }
                }
                if (message.Response != null)
                {
                    IEnumerable<string> headerPairs = message?.Response?.Headers?.Select(header => $"{header.Key}={(header.Key.ToLower().Contains("auth") ? "***" : header.Value)}");
                    string headers = string.Join(",", headerPairs);
                    Console.WriteLine($"Response headers: {headers}");
                    if (message.BufferResponse)
                    {
                        Console.WriteLine("--- Begin response content ---");
                        Console.WriteLine(message.Response.Content?.ToString());
                        Console.WriteLine("--- End of response content ---");
                    }
                    else
                    {
                        Console.WriteLine("--- Response (unbuffered, content not rendered) ---");
                    }
                }
            });
        }
        #endregion

        private static RecordedTestMode? GetRecordedTestMode(string variable = "AZURE_TEST_MODE") => Environment.GetEnvironmentVariable(variable) switch
        {
            "Playback" => RecordedTestMode.Playback,
            "Live" => RecordedTestMode.Live,
            "Record" => RecordedTestMode.Record,
            _ => null
        };

        public ProjectsClientTestBase(bool isAsync) : this(isAsync: isAsync, testMode: GetRecordedTestMode("CLIENTMODEL_TEST_MODE") ?? GetRecordedTestMode()) { }

        public ProjectsClientTestBase(bool isAsync, RecordedTestMode? testMode = null) : base(isAsync, testMode)
        {
            // Apply sanitizers to protect sensitive information in recordings
            ProjectsTestSanitizers.ApplySanitizers(this);
            // Icrease Test timeout because ComputerUse tool test can take a little
            // more then 10 sec (default).
            TestTimeoutInSeconds = 20;
        }

        protected AIProjectClientOptions CreateTestProjectClientOptions(bool instrument = true, Dictionary<string, string> headers = null)
        => GetConfiguredOptions(new AIProjectClientOptions(), instrument, headers);

        protected ProjectOpenAIClientOptions CreateTestProjectOpenAIClientOptions(Uri endpoint = null, string apiVersion = null, bool instrument = true)
        => GetConfiguredOptions(
            new ProjectOpenAIClientOptions()
            {
                Endpoint = endpoint,
                ApiVersion = apiVersion,
            },
            instrument);

        private T GetConfiguredOptions<T>(T options, bool instrument, Dictionary<string, string> headers = null)
            where T : ClientPipelineOptions
        {
            options.AddPolicy(GetDumpPolicy(), PipelinePosition.BeforeTransport);
            options.NetworkTimeout = TimeSpan.FromMinutes(5);
            if (headers is not null && headers.Count > 0)
            {
                options.AddPolicy(new HeaderTestPolicy(headers), PipelinePosition.PerCall);
            }
            options.AddPolicy(
                new TestPipelinePolicy(message =>
                {
                    if (Mode == RecordedTestMode.Playback)
                    {
                        // TODO: ...why!?
                        message.Request.Headers.Set("Authorization", "Sanitized");
                    }
                    else
                    {
                        message.NetworkTimeout = TimeSpan.FromMinutes(5);
                    }
                }),
                PipelinePosition.PerCall);

            return instrument ? InstrumentClientOptions(options) : options;
        }

        private AuthenticationTokenProvider GetTestTokenProvider()
        {
            // For local testing if you are using non default account
            // add USE_CLI_CREDENTIAL into the .runsettings and set it to true,
            // also provide the PATH variable.
            // This path should allow launching az command.
            if (Mode != RecordedTestMode.Playback && bool.TryParse(Environment.GetEnvironmentVariable("USE_CLI_CREDENTIAL"), out bool cliValue) && cliValue)
            {
                return new AzureCliCredential();
            }
            return TestEnvironment.Credential;
        }

        protected AIProjectClient GetTestProjectClient(Dictionary<string, string> headers = default)
        {
            AIProjectClientOptions projectClientOptions = CreateTestProjectClientOptions(headers: headers);
            return CreateProxyFromClient(new AIProjectClient(new(TestEnvironment.PROJECT_ENDPOINT), GetTestTokenProvider(), projectClientOptions));
        }

        protected AIProjectClient GetTestProjectClientForLegacyAgents(Dictionary<string, string> headers = default)
        {
            AIProjectClientOptions projectClientOptions = CreateTestProjectClientOptions(headers: headers);
            return CreateProxyFromClient(new AIProjectClient(new(TestEnvironment.PROJECT_ENDPOINT), GetTestTokenProvider(), projectClientOptions));
        }

        /// <summary>
        /// Creates a client in live mode, bypassing any proxy transport.
        /// Use this when you need to test against real services.
        /// </summary>
        protected AIProjectClient GetLiveClient(AIProjectClientOptions options = null)
        {
            options ??= new AIProjectClientOptions();

            var endpoint = TestEnvironment.PROJECT_ENDPOINT;
            var credential = TestEnvironment.Credential;

            var client = new AIProjectClient(new Uri(endpoint), credential, options);

            // Instrument the client for sync/async testing
            return CreateProxyFromClient(client);
        }

        /// <summary>
        /// Helper method to validate common properties in test responses.
        /// </summary>
        protected static void ValidateNotNullOrEmpty(string value, string propertyName)
        {
            Assert.That(value, Is.Not.Null, $"{propertyName} should not be null");
            Assert.That(value, Is.Not.Empty, $"{propertyName} should not be empty");
        }

        /// <summary>
        /// Helper method to validate that a response contains expected data.
        /// </summary>
        protected static void ValidateResponse<T>(T response, string responseName = null) where T : class
        {
            Assert.That(response, Is.Not.Null, $"{responseName ?? typeof(T).Name} response should not be null");
        }

        // Regular expression describing the pattern of an Application Insights connection string
        internal static readonly Regex RegexAppInsightsConnectionString = new(
            @"^InstrumentationKey=[0-9a-fA-F-]{36};IngestionEndpoint=https://.+\.applicationinsights\.azure\.com/;LiveEndpoint=https://.+\.monitor\.azure\.com/;ApplicationId=[0-9a-fA-F-]{36}$",
            RegexOptions.Compiled
        );

        /// <summary>
        /// Asserts that the actual value is not null, and optionally equals the expected value if provided.
        /// </summary>
        /// <typeparam name="T">The type of the values being compared.</typeparam>
        /// <param name="actual">The actual value to check.</param>
        /// <param name="expected">The expected value (optional).</param>
        public static void AssertEqualOrNotNull<T>(T actual, T expected = default)
        {
            Assert.That(actual, Is.Not.Null, "Actual value should not be null");
            if (expected != null && !EqualityComparer<T>.Default.Equals(expected, default))
            {
                Assert.That(actual, Is.EqualTo(expected), $"Expected {expected}, but got {actual}");
            }
        }

        /// <summary>
        /// Validates a connection object.
        /// </summary>
        /// <param name="connection">The connection to validate.</param>
        /// <param name="includeCredentials">Whether to include credential validation.</param>
        /// <param name="expectedConnectionType">Expected connection type (optional).</param>
        /// <param name="expectedConnectionName">Expected connection name (optional).</param>
        /// <param name="expectedAuthenticationType">Expected authentication type name (optional).</param>
        /// <param name="expectedIsDefault">Expected is default value (optional).</param>
        public static void ValidateConnection(
            AIProjectConnection connection,
            bool includeCredentials,
            ConnectionType? expectedConnectionType = null,
            string expectedConnectionName = null,
            string expectedAuthenticationType = null,
            bool? expectedIsDefault = null)
        {
            Assert.That(connection.Id, Is.Not.Null, "Connection ID should not be null");

            AssertEqualOrNotNull(connection.Name, expectedConnectionName);
            AssertEqualOrNotNull(connection.Type, expectedConnectionType);

            if (connection.Credentials != null && !string.IsNullOrEmpty(expectedAuthenticationType))
            {
                // Check the actual credential type by name
                var credentialType = connection.Credentials.GetType().Name.Replace("Credentials", "");
                AssertEqualOrNotNull(credentialType, expectedAuthenticationType);
            }

            if (expectedIsDefault.HasValue)
            {
                Assert.That(connection.IsDefault, Is.EqualTo(expectedIsDefault.Value),
                    $"Expected IsDefault to be {expectedIsDefault.Value}");
            }

            if (includeCredentials && connection.Credentials is AIProjectConnectionApiKeyCredential apiKeyCredentials)
            {
                Assert.That(apiKeyCredentials.ApiKey, Is.Not.Null, "API key should not be null");
            }
        }

        /// <summary>
        /// Validates a deployment object.
        /// </summary>
        /// <param name="deployment">The deployment to validate.</param>
        /// <param name="expectedModelName">Expected model name (optional).</param>
        /// <param name="expectedModelDeploymentName">Expected model deployment name (optional).</param>
        /// <param name="expectedModelPublisher">Expected model publisher (optional).</param>
        public static void ValidateDeployment(
            AIProjectDeployment deployment,
            string expectedModelName = null,
            string expectedModelDeploymentName = null,
            string expectedModelPublisher = null)
        {
            Assert.That(deployment, Is.TypeOf<ModelDeployment>(), "Deployment should be of type ModelDeployment");

            var modelDeployment = deployment as ModelDeployment;
            Assert.That(modelDeployment.ModelVersion, Is.Not.Null, "Model version should not be null");

            // Check if the deployment has a valid SKU (non-empty)
            Assert.That(modelDeployment.Sku, Is.Not.Null, "SKU should not be null");

            AssertEqualOrNotNull(modelDeployment.ModelName, expectedModelName);
            AssertEqualOrNotNull(modelDeployment.Name, expectedModelDeploymentName);
            AssertEqualOrNotNull(modelDeployment.ModelPublisher, expectedModelPublisher);
        }

        /// <summary>
        /// Validates an index object.
        /// </summary>
        /// <param name="index">The index to validate.</param>
        /// <param name="expectedIndexType">Expected index type (optional).</param>
        /// <param name="expectedIndexName">Expected index name (optional).</param>
        /// <param name="expectedIndexVersion">Expected index version (optional).</param>
        /// <param name="expectedAiSearchConnectionName">Expected AI Search connection name (optional).</param>
        /// <param name="expectedAiSearchIndexName">Expected AI Search index name (optional).</param>
        public static void ValidateIndex(
            AIProjectIndex index,
            string expectedIndexType = null,
            string expectedIndexName = null,
            string expectedIndexVersion = null,
            string expectedAiSearchConnectionName = null,
            string expectedAiSearchIndexName = null)
        {
            AssertEqualOrNotNull(index.Name, expectedIndexName);
            AssertEqualOrNotNull(index.Version, expectedIndexVersion);

            if (expectedIndexType == "AzureSearch")
            {
                Assert.That(index, Is.TypeOf<AzureAISearchIndex>(), "Index should be of type AzureAISearchIndex");

                var azureSearchIndex = index as AzureAISearchIndex;
                AssertEqualOrNotNull(azureSearchIndex.ConnectionName, expectedAiSearchConnectionName);
                AssertEqualOrNotNull(azureSearchIndex.IndexName, expectedAiSearchIndexName);
            }
        }

        /// <summary>
        /// Validates a dataset object.
        /// </summary>
        /// <param name="dataset">The dataset to validate.</param>
        /// <param name="expectedDatasetType">Expected dataset type (optional).</param>
        /// <param name="expectedDatasetName">Expected dataset name (optional).</param>
        /// <param name="expectedDatasetVersion">Expected dataset version (optional).</param>
        /// <param name="expectedConnectionName">Expected connection name (optional).</param>
        public static void ValidateDataset(
            AIProjectDataset dataset,
            string expectedDatasetType = null,
            string expectedDatasetName = null,
            string expectedDatasetVersion = null,
            string expectedConnectionName = null)
        {
            Assert.That(dataset.DataUri, Is.Not.Null, "Dataset data URI should not be null");

            // Note: Dataset.Type is internal, so we skip type validation for now
            // If expectedDatasetType is provided, we could add custom validation logic here

            AssertEqualOrNotNull(dataset.Name, expectedDatasetName);
            AssertEqualOrNotNull(dataset.Version, expectedDatasetVersion);

            if (!string.IsNullOrEmpty(expectedConnectionName))
            {
                AssertEqualOrNotNull(dataset.ConnectionName, expectedConnectionName);
            }
        }

        /// <summary>
        /// Validates an asset credential object.
        /// </summary>
        /// <param name="assetCredential">The asset credential to validate.</param>
        public static void ValidateAssetCredential(DatasetCredential assetCredential)
        {
            Assert.That(assetCredential.BlobReference, Is.Not.Null, "Blob reference should not be null");
            Assert.That(assetCredential.BlobReference.BlobUri, Is.Not.Null, "Blob URI should not be null");
            Assert.That(assetCredential.BlobReference.StorageAccountArmId, Is.Not.Null,
                "Storage account ARM ID should not be null");

            Assert.That(assetCredential.BlobReference.Credential, Is.Not.Null,
                "Blob reference credential should not be null");

            // Check credential type - note: using string comparison since the exact type structure may vary
            Assert.That(assetCredential.BlobReference.Credential.Type, Is.EqualTo("SAS"),
                "Credential type should be SAS");
            Assert.That(assetCredential.BlobReference.Credential.SasUri, Is.Not.Null,
                "SAS URI should not be null");
        }

        /// <summary>
        /// Validates an Application Insights connection string format.
        /// </summary>
        /// <param name="connectionString">The connection string to validate.</param>
        /// <returns>True if the connection string matches the expected format; otherwise, false.</returns>
        public static bool ValidateAppInsightsConnectionString(string connectionString)
        {
            return !string.IsNullOrEmpty(connectionString) &&
                   RegexAppInsightsConnectionString.IsMatch(connectionString);
        }

        protected static string GetTestFile(string fileName, [CallerFilePath] string pth = "")
        {
            var dirName = Path.GetDirectoryName(pth) ?? "";
            return Path.Combine([ dirName, "TestData", fileName ]);
        }
    }
}
