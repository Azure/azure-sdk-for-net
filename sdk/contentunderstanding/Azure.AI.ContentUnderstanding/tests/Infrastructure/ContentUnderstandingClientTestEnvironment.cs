// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class ContentUnderstandingClientTestEnvironment : TestEnvironment
    {
        private const string AssetsFolderName = "samples/SampleFiles";

        // We are using assets from the Azure-Samples repository.
        // Files are located at: https://github.com/Azure-Samples/azure-ai-content-understanding-dotnet/tree/main/ContentUnderstanding.Common/data
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/{0}";

        private static readonly string s_currentWorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;

        /// <summary>
        /// Gets the endpoint URL for the Content Understanding service.
        /// </summary>
        /// <remarks>
        /// This value is read from the environment variable: CONTENTUNDERSTANDING_ENDPOINT
        /// In Playback mode, a fake endpoint is used: https://fake_contentunderstanding_endpoint.services.ai.azure.com/
        /// The endpoint is sanitized in recordings via URI sanitizers to prevent exposing real service endpoints.
        /// </remarks>
        public string Endpoint => GetRecordedVariable("CONTENTUNDERSTANDING_ENDPOINT");

        /// <summary>
        /// Gets the API key for authenticating with the Content Understanding service.
        /// </summary>
        /// <remarks>
        /// The API key is sanitized in recordings to prevent exposing secrets.
        /// </remarks>
        public string ApiKey => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the gpt-4.1 deployment name (optional).
        /// </summary>
        public string? Gpt41Deployment => GetRecordedOptionalVariable("GPT_4_1_DEPLOYMENT");

        /// <summary>
        /// Gets the gpt-4.1-mini deployment name (optional).
        /// </summary>
        public string? Gpt41MiniDeployment => GetRecordedOptionalVariable("GPT_4_1_MINI_DEPLOYMENT");

        /// <summary>
        /// Gets the text-embedding-3-large deployment name (optional).
        /// </summary>
        public string? TextEmbedding3LargeDeployment => GetRecordedOptionalVariable("TEXT_EMBEDDING_3_LARGE_DEPLOYMENT");

        /// <summary>
        /// Gets the source resource ID for cross-resource copying (optional).
        /// </summary>
        public string? SourceResourceId => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_SOURCE_RESOURCE_ID", options => options.IsSecret());

        /// <summary>
        /// Gets the source region for cross-resource copying (optional).
        /// </summary>
        public string? SourceRegion => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_SOURCE_REGION", options => options.IsSecret());

        /// <summary>
        /// Gets the target endpoint for cross-resource copying (optional).
        /// </summary>
        public string TargetEndpoint => GetRecordedVariable("CONTENTUNDERSTANDING_TARGET_ENDPOINT");

        /// <summary>
        /// Gets the target resource ID for cross-resource copying (optional).
        /// </summary>
        public string? TargetResourceId => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TARGET_RESOURCE_ID", options => options.IsSecret());

        /// <summary>
        /// Gets the target region for cross-resource copying (optional).
        /// </summary>
        public string? TargetRegion => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TARGET_REGION", options => options.IsSecret());

        /// <summary>
        /// Gets the target API key for cross-resource copying (optional).
        /// </summary>
        public string? TargetKey => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TARGET_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the SAS URL for the Azure Blob container with labeled training data
        /// used by <c>Sample16_CreateAnalyzerWithLabels</c> (optional).
        /// </summary>
        /// <remarks>
        /// If unset, the sample creates an analyzer without labeled training data.
        /// The SAS URL is sanitized in recordings to prevent exposing secrets.
        /// </remarks>
        public string? TrainingDataSasUrl => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TRAINING_DATA_SAS_URL", options => options.IsSecret());

        /// <summary>
        /// Gets the optional path prefix within the training-data container
        /// (e.g., <c>"receipt_labels/"</c>) used by <c>Sample16_CreateAnalyzerWithLabels</c>.
        /// </summary>
        public string? TrainingDataPrefix => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TRAINING_DATA_PREFIX");

        /// <summary>
        /// Gets the storage account name for auto-uploading labeled training data
        /// (Option B in <c>Sample16_CreateAnalyzerWithLabels</c>). Optional.
        /// </summary>
        public string? TrainingDataStorageAccountName => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TRAINING_DATA_STORAGE_ACCOUNT");

        /// <summary>
        /// Gets the blob container name for auto-uploading labeled training data
        /// (Option B in <c>Sample16_CreateAnalyzerWithLabels</c>). Optional.
        /// </summary>
        public string? TrainingDataContainerName => GetRecordedOptionalVariable("CONTENTUNDERSTANDING_TRAINING_DATA_CONTAINER");

        /// <summary>
        /// Creates a file path for a test asset file.
        /// </summary>
        /// <param name="filename">The name of the test asset file.</param>
        /// <returns>The full path to the test asset file.</returns>
        public static string CreatePath(string filename)
        {
            return Path.Combine(s_currentWorkingDirectory, AssetsFolderName, filename);
        }

        /// <summary>
        /// Creates a URI for a test asset file hosted on GitHub.
        /// </summary>
        /// <param name="filename">The name of the test asset file in the Azure-Samples repository.</param>
        /// <returns>A URI pointing to the test asset file.</returns>
        public static Uri CreateUri(string filename)
        {
            var uriString = string.Format(FileUriFormat, filename);
            return new Uri(uriString);
        }

        /// <summary>
        /// Creates BinaryData from a test asset file.
        /// </summary>
        /// <param name="filename">The name of the test asset file.</param>
        /// <returns>BinaryData containing the file contents.</returns>
        public static BinaryData CreateBinaryData(string filename)
        {
            var path = CreatePath(filename);
            var bytes = File.ReadAllBytes(path);
            return BinaryData.FromBytes(bytes);
        }

        /// <summary>
        /// Returns a developer credential for local Record/Live runs.
        /// </summary>
        /// <remarks>
        /// The base implementation pins broker-based interactive auth to the Azure SDK test
        /// tenant, which is not suitable for Content Understanding because the service and
        /// associated training storage live in the user's home tenant. Prepend
        /// <see cref="AzureCliCredential"/> so that <c>az login</c> is honored on dev boxes
        /// (and in WSL) without requiring an interactive broker window. The base chain
        /// remains as a fallback for environments without the Azure CLI.
        /// </remarks>
        protected override TokenCredential CreateDeveloperCredential()
        {
            return new ChainedTokenCredential(
                new AzureCliCredential(),
                base.CreateDeveloperCredential());
        }

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            var endpoint = new Uri(Endpoint);
            var credential = Credential;
            var client = new ContentUnderstandingClient(endpoint, credential);

            try
            {
                await client.GetDefaultsAsync();
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }

            return true;
        }
    }
}
