// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core.TestFramework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class ContentUnderstandingClientTestEnvironment : TestEnvironment
    {
        private const string AssetsFolderName = "samples/SampleFiles";

        // We are using assets from the Content Understanding test samples directory.
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/tests/{0}/{1}";

        private static readonly string s_currentWorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Gets the endpoint URL for the Content Understanding service.
        /// </summary>
        /// <remarks>
        /// This value is read from the environment variable: CONTENTUNDERSTANDING_ENDPOINT
        /// In Playback mode, a fake endpoint is used: https://fake_contentunderstanding_endpoint.services.ai.azure.com/
        /// The endpoint is sanitized in recordings to prevent exposing real service endpoints.
        /// </remarks>
        public string Endpoint => GetRecordedVariable("CONTENTUNDERSTANDING_ENDPOINT", options => options.IsSecret("https://sanitized.services.ai.azure.com/"));

        /// <summary>
        /// Gets the API key for authenticating with the Content Understanding service.
        /// </summary>
        /// <remarks>
        /// The API key is sanitized in recordings to prevent exposing secrets.
        /// </remarks>
        public string ApiKey => GetRecordedOptionalVariable("AZURE_CONTENT_UNDERSTANDING_KEY", options => options.IsSecret());

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
        /// <param name="filename">The name of the test asset file.</param>
        /// <returns>A URI pointing to the test asset file.</returns>
        public static Uri CreateUri(string filename)
        {
            var uriString = string.Format(FileUriFormat, AssetsFolderName, filename);
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
