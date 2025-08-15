// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.ClientModel;
using System.ClientModel.Primitives;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    /// <summary>
    /// Base test class that supports both Azure.Core and System.ClientModel recording scenarios.
    /// This class provides the foundation for testing Azure.AI.Projects with recording/playback capabilities.
    /// </summary>
    public class TestBase : RecordedProjectsTestBase<AIProjectsTestEnvironment>
    {
    public TestBase(bool isAsync) : base(isAsync)
    {
        TestDiagnostics = false;
        // Apply sanitizers to protect sensitive information in recordings
        ProjectsTestSanitizers.ApplySanitizers(this);
    }

        /// <summary>
        /// Creates a test client with proper configuration for recording/playback.
        /// This method handles both Azure.Core and System.ClientModel scenarios.
        /// </summary>
        internal virtual AIProjectClient GetTestClient(AIProjectClientOptions options = null)
        {
            options ??= new AIProjectClientOptions();

            // If we have access to System.ClientModel recording capabilities, configure them
            ConfigureClientOptionsForRecording(options);

            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var credential = new DefaultAzureCredential();

            return InstrumentClient(new AIProjectClient(new Uri(endpoint), credential, options));
        }

        /// <summary>
        /// Configures client options for recording/playback scenarios.
        /// This method configures System.ClientModel recording support by injecting the appropriate transport.
        /// </summary>
        protected virtual void ConfigureClientOptionsForRecording(AIProjectClientOptions options)
        {
            // Use the base class method to configure recording transport
            ConfigureClientOptionsForRecording<AIProjectClientOptions>(options);
        }

        // Test parameters for connections
        public static readonly Dictionary<string, object> TestConnectionsParams = new()
        {
            { "connection_name", "connection1" },
            { "connection_type", ConnectionType.AzureOpenAI }
        };

        // Test parameters for deployments
        public static readonly Dictionary<string, object> TestDeploymentsParams = new()
        {
            { "model_publisher", "Cohere" },
            { "model_name", "gpt-4o" },
            { "model_deployment_name", "DeepSeek-V3" }
        };

        // Test parameters for agents
        public static readonly Dictionary<string, object> TestAgentsParams = new()
        {
            { "model_deployment_name", "gpt-4o" },
            { "agent_name", "agent-for-csharp-projects-sdk-testing" }
        };

        // Test parameters for inference
        public static readonly Dictionary<string, object> TestInferenceParams = new()
        {
            { "connection_name", "connection1" },
            { "model_deployment_name", "gpt-4o" },
            { "aoai_api_version", "2024-10-21" }
        };

        // Test parameters for indexes
        public static readonly Dictionary<string, object> TestIndexesParams = new()
        {
            { "index_name", "test-index-name" },
            { "index_version", "1" },
            { "ai_search_connection_name", "my-ai-search-connection" },
            { "ai_search_index_name", "my-ai-search-index" }
        };

        // Test parameters for datasets
        private static readonly Random _random = new Random();
        public static readonly Dictionary<string, object> TestDatasetsParams = new()
        {
            { "dataset_name_1", $"test-dataset-name-{_random.Next(0, 99999):D5}" },
            { "dataset_name_2", $"test-dataset-name-{_random.Next(0, 99999):D5}" },
            { "dataset_name_3", $"test-dataset-name-{_random.Next(0, 99999):D5}" },
            { "dataset_name_4", $"test-dataset-name-{_random.Next(0, 99999):D5}" },
            { "dataset_version", 1 },
            { "connection_name", "balapvbyostoragecanary" }
        };

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
        /// Checks that a given dictionary has at least one non-empty (non-whitespace) string key-value pair.
        /// </summary>
        /// <param name="dictionary">The dictionary to validate.</param>
        /// <returns>True if the dictionary is valid; otherwise, false.</returns>
        public static bool IsValidDictionary(IDictionary<string, string> dictionary)
        {
            return dictionary != null &&
                   dictionary.Count > 0 &&
                   dictionary.All(kvp =>
                       !string.IsNullOrWhiteSpace(kvp.Key) &&
                       !string.IsNullOrWhiteSpace(kvp.Value));
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
            ConnectionProperties connection,
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

            if (includeCredentials && connection.Credentials is ApiKeyCredentials apiKeyCredentials)
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
            AssetDeployment deployment,
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
            SearchIndex index,
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
            DatasetVersion dataset,
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
    }
}
