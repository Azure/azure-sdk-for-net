// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class DocumentAnalysisTestEnvironment : TestEnvironment
    {
        private const string SanitizedSasUrl = "https://sanitized.blob.core.windows.net";

        public DocumentAnalysisTestEnvironment()
        {
        }

        /// <summary>The name of the environment variable from which the Form Recognizer resource's endpoint will be extracted for the live tests.</summary>
        internal const string EndpointEnvironmentVariableName = "FORM_RECOGNIZER_ENDPOINT";

        /// <summary>The name of the environment variable from which the Form Recognizer resource's API key will be extracted for the live tests.</summary>
        internal const string ApiKeyEnvironmentVariableName = "FORM_RECOGNIZER_API_KEY";

        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        /// <summary>The name of the environment variable for the Blob Container SAS URL to use for storing documents used for live tests.</summary>
        internal const string BlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the multipage Blob Container SAS URL to use for storing documents used for live tests.</summary>
        internal const string MultipageBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_MULTIPAGE_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the Blob Container SAS URL to use for storing documents that have selection marks used for live tests.</summary>
        internal const string SelectionMarkBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_SELECTION_MARK_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the Blob Container SAS URL to use for storing documents that have tables with dynamic rows used for live tests.</summary>
        internal const string TableDynamicRowsBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_TABLE_VARIABLE_ROWS_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the Blob Container SAS URL to use for storing documents that have tables with fixed rows used for live tests.</summary>
        internal const string TableFixedRowsBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_TABLE_FIXED_ROWS_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the Blob Container SAS URL containing data for training classifiers.</summary>
        internal const string ClassifierTrainingBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_CLASSIFIER_TRAINING_BLOB_CONTAINER_SAS_URL";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());

        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);

        public string BlobContainerSasUrl => GetRecordedVariable(BlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret(SanitizedSasUrl));

        public string SelectionMarkBlobContainerSasUrl => GetRecordedVariable(SelectionMarkBlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret(SanitizedSasUrl));

        public string MultipageBlobContainerSasUrl => GetRecordedVariable(MultipageBlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret(SanitizedSasUrl));

        public string TableDynamicRowsContainerSasUrl => GetRecordedVariable(TableDynamicRowsBlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret(SanitizedSasUrl));

        public string TableFixedRowsContainerSasUrl => GetRecordedVariable(TableFixedRowsBlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret(SanitizedSasUrl));

        public string ClassifierTrainingSasUrl => GetRecordedVariable(ClassifierTrainingBlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret(SanitizedSasUrl));

        /// <summary>
        /// The absolute path of the directory where the running assembly is located.
        /// </summary>
        /// <value>The absolute path of the current working directory.</value>
        private static string CurrentWorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// Creates an absolute path to a file contained in the local test assets folder.
        /// </summary>
        /// <param name="filename">The name of the file to create a path to.</param>
        /// <returns>An absolute path to the specified file.</returns>
        public static string CreatePath(string filename) =>
            Path.Combine(CurrentWorkingDirectory, AssetsFolderName, filename);

        /// <summary>
        /// Creates a URI string to a file contained in the test assets folder stored in
        /// the azure-sdk-for-net GitHub repo.
        /// </summary>
        /// <param name="filename">The name of the file to create a URI string to.</param>
        /// <returns>A URI string to the specified file.</returns>
        public static string CreateUriString(string filename) =>
            string.Format(FileUriFormat, AssetsFolderName, filename);

        /// <summary>
        /// Creates a <see cref="FileStream"/> to read file contained in the local test
        /// assets folder.
        /// </summary>
        /// <param name="filename">The name of the file to read with the stream.</param>
        /// <returns>A <see cref="FileStream"/> to read the specified file.</returns>
        /// <remarks>
        /// The returned stream needs to be disposed of by the calling method.
        /// </remarks>
        public static FileStream CreateStream(string filename) =>
            new FileStream(CreatePath(filename), FileMode.Open);

        /// <summary>
        /// Creates a URI to a file contained in the test assets folder stored in the
        /// azure-sdk-for-net GitHub repo.
        /// </summary>
        /// <param name="filename">The name of the file to create a URI to.</param>
        /// <returns>A URI to the specified file.</returns>
        public static Uri CreateUri(string filename) =>
            new Uri(CreateUriString(filename));
    }
}
