// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class DocumentAnalysisTestEnvironment : TestEnvironment
    {
        private const string SanitizedSasUrl = "https://sanitized.blob.core.windows.net";

        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        private static readonly string s_currentWorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// The endpoint of the Form Recognizer resource used in live tests.
        /// </summary>
        public string Endpoint => GetRecordedVariable("ENDPOINT");

        /// <summary>
        /// The API key to access the Form Recognizer resource used in live tests.
        /// </summary>
        public string ApiKey => GetRecordedVariable("API_KEY", options => options.IsSecret());

        /// <summary>
        /// The ID of the Form Recognizer resource used in live tests.
        /// </summary>
        public string ResourceId => GetRecordedVariable("RESOURCE_ID");

        /// <summary>
        /// The region of the Form Recognizer resource used in live tests.
        /// </summary>
        public string ResourceRegion => GetRecordedVariable("RESOURCE_REGION");

        /// <summary>
        /// A Blob Container SAS URL used to build document models in live tests. Used when analyzing single-paged documents.
        /// </summary>
        public string BlobContainerSasUrl => GetRecordedVariable("SINGLEPAGE_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        /// <summary>
        /// A Blob Container SAS URL used to build document models in live tests. Used when analyzing multi-paged documents.
        /// </summary>
        public string MultipageBlobContainerSasUrl => GetRecordedVariable("MULTIPAGE_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        /// <summary>
        /// A Blob Container SAS URL used to build document models in live tests. Used when analyzing documents with selection marks.
        /// </summary>
        public string SelectionMarkBlobContainerSasUrl => GetRecordedVariable("SELECTION_MARK_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        /// <summary>
        /// A Blob Container SAS URL used to build document models in live tests. Used when analyzing documents with tables with dynamic rows.
        /// </summary>
        public string TableDynamicRowsContainerSasUrl => GetRecordedVariable("TABLE_DYNAMIC_ROWS_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        /// <summary>
        /// A Blob Container SAS URL used to build document models in live tests. Used when analyzing documents with tables with fixed rows.
        /// </summary>
        public string TableFixedRowsContainerSasUrl => GetRecordedVariable("TABLE_FIXED_ROWS_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        /// <summary>
        /// A Blob Container SAS URL used to build document classifiers in live tests.
        /// </summary>
        public string ClassifierTrainingSasUrl => GetRecordedVariable("CLASSIFIER_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            var endpoint = new Uri(Endpoint);
            var keyCredential = new AzureKeyCredential(ApiKey);
            var keyCredentialClient = new DocumentModelAdministrationClient(endpoint, keyCredential);
            var tokenCredentialClient = new DocumentModelAdministrationClient(endpoint, Credential);

            try
            {
                await keyCredentialClient.GetResourceDetailsAsync();
                await tokenCredentialClient.GetResourceDetailsAsync();
            }
            catch (RequestFailedException e) when (e.Status == 401)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates an absolute path to a file contained in the local test assets folder.
        /// </summary>
        /// <param name="filename">The name of the file to create a path to.</param>
        /// <returns>An absolute path to the specified file.</returns>
        public static string CreatePath(string filename) =>
            Path.Combine(s_currentWorkingDirectory, AssetsFolderName, filename);

        /// <summary>
        /// Creates a <see cref="FileStream"/> to read file contained in the local test assets folder.
        /// </summary>
        /// <param name="filename">The name of the file to read with the stream.</param>
        /// <returns>A <see cref="FileStream"/> to read the specified file.</returns>
        /// <remarks>
        /// The returned stream needs to be disposed of by the calling method.
        /// </remarks>
        public static FileStream CreateStream(string filename) =>
            new FileStream(CreatePath(filename), FileMode.Open);

        /// <summary>
        /// Creates a URI to a file contained in the test assets folder stored in the azure-sdk-for-net GitHub repo.
        /// </summary>
        /// <param name="filename">The name of the file to create a URI to.</param>
        /// <returns>A URI to the specified file.</returns>
        public static Uri CreateUri(string filename)
        {
            var uriString = string.Format(FileUriFormat, AssetsFolderName, filename);

            return new Uri(uriString);
        }
    }
}
