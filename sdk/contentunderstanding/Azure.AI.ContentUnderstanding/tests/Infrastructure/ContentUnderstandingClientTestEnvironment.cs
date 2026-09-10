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
        /// In Playback mode, a sanitized placeholder endpoint is used: https://sanitized.services.ai.azure.com/
        /// The endpoint is sanitized in recordings via URI sanitizers to prevent exposing real service endpoints.
        /// </remarks>
        public string Endpoint => GetRecordedVariable(
            "CONTENTUNDERSTANDING_ENDPOINT",
            options => options.IsSecret("https://sanitized.services.ai.azure.com/"));

        /// <summary>
        /// Gets the API key for authenticating with the Content Understanding service.
        /// </summary>
        /// <remarks>
        /// The API key is sanitized in recordings to prevent exposing secrets.
        /// </remarks>
        public string ApiKey => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_KEY", options => options.IsSecret());

        /// <summary>
        /// Gets the completion model name (optional).
        /// </summary>
        public string CompletionModel => GetRecordedOptionalVariable("CU_COMPLETION_MODEL") ?? "gpt-5.2";

        /// <summary>
        /// Gets the completion model deployment name (optional).
        /// </summary>
        public string? CompletionModelDeployment => GetRecordedOptionalVariable("CU_COMPLETION_MODEL_DEPLOYMENT");

        /// <summary>
        /// Gets the mini completion model deployment name (optional).
        /// </summary>
        public string? CompletionMiniDeployment => GetRecordedOptionalVariable("CU_COMPLETION_MINI_DEPLOYMENT");

        /// <summary>
        /// Gets the embedding model deployment name (optional).
        /// </summary>
        public string? EmbeddingDeployment => GetRecordedOptionalVariable("CU_EMBEDDING_DEPLOYMENT");

        internal ContentUnderstandingModelProfile GetModelProfile(ContentUnderstandingClientOptions.ServiceVersion serviceVersion)
        {
            // Prefer env/recorded variables; fall back to values used in current V2025_11_01 SessionRecords
            // so playback matches today and future re-records can override via env.
            return serviceVersion switch
            {
                ContentUnderstandingClientOptions.ServiceVersion.V2025_11_01 => new ContentUnderstandingModelProfile(
                    GetRecordedOptionalVariable("CU_COMPLETION_MODEL") ?? "gpt-4.1", // completion model name
                    GetRecordedOptionalVariable("GPT_4_1_DEPLOYMENT") ?? CompletionModelDeployment ?? "gpt-4.1", // completion deployment name
                    "gpt-4.1-mini", // mini completion model name
                    GetRecordedOptionalVariable("GPT_4_1_MINI_DEPLOYMENT") ?? CompletionMiniDeployment ?? "foundrythreiscae/gpt-4.1-mini", // mini completion deployment name
                    "text-embedding-3-large", // embedding model name
                    GetRecordedOptionalVariable("TEXT_EMBEDDING_3_LARGE_DEPLOYMENT") ?? EmbeddingDeployment ?? "text-embedding-3-large", // embedding deployment name
                    includesPrebuiltAliases: false),
                ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview => new ContentUnderstandingModelProfile(
                    CompletionModel, // completion model name
                    CompletionModelDeployment, // completion deployment name
                    "gpt-5.2", // mini completion model name
                    CompletionMiniDeployment, // mini completion deployment name
                    "text-embedding-3-large", // embedding model name
                    EmbeddingDeployment, // embedding deployment name
                    includesPrebuiltAliases: true),
                _ => throw new ArgumentOutOfRangeException(nameof(serviceVersion), serviceVersion, "Unsupported service version.")
            };
        }

        /// <summary>
        /// Gets the source resource ID for cross-resource copying (optional).
        /// </summary>
        public string? SourceResourceId => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID", options => options.IsSecret());

        /// <summary>
        /// Gets the source region for cross-resource copying (optional).
        /// </summary>
        public string? SourceRegion => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION", options => options.IsSecret());

        /// <summary>
        /// Gets the target endpoint for cross-resource copying (optional).
        /// </summary>
        public string TargetEndpoint => GetRecordedVariable(
            "CONTENTUNDERSTANDING_TARGET_ENDPOINT",
            options => options.IsSecret("https://sanitized.services.ai.azure.com/"));

        /// <summary>
        /// Gets the target resource ID for cross-resource copying (optional).
        /// </summary>
        public string? TargetResourceId => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID", options => options.IsSecret());

        /// <summary>
        /// Gets the target region for cross-resource copying (optional).
        /// </summary>
        public string? TargetRegion => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION", options => options.IsSecret());

        /// <summary>
        /// Gets the target API key for cross-resource copying (optional).
        /// </summary>
        public string? TargetKey => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_TARGET_KEY", options => options.IsSecret());

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

        protected override TokenCredential CreateDeveloperCredential()
        {
            // The base developer credential (Azure.Core.TestFramework, PR #57407) leads with an
            // interactive broker credential that hangs in headless hosts (e.g. Linux dotnet test)
            // and targets the Azure SDK test tenant. Use AzureCliCredential for local developer runs.
            return new AzureCliCredential();
        }

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            var endpoint = new Uri(Endpoint);
            var client = new ContentUnderstandingClient(endpoint, Credential);

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
