// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class FormRecognizerTestEnvironment: TestEnvironment
    {
        public FormRecognizerTestEnvironment()
        {
        }

        /// <summary>The name of the environment variable from which the Form Recognizer resource's endpoint will be extracted for the live tests.</summary>
        internal const string EndpointEnvironmentVariableName = "FORM_RECOGNIZER_ENDPOINT";

        /// <summary>The name of the environment variable from which the Form Recognizer resource's API key will be extracted for the live tests.</summary>
        internal const string ApiKeyEnvironmentVariableName = "FORM_RECOGNIZER_API_KEY";

        /// <summary>The name of the environment variable for the Blob Container SAS URL to use for storing documents used for live tests.</summary>
        internal const string BlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the multipage Blob Container SAS URL to use for storing documents used for live tests.</summary>
        internal const string MultipageBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_MULTIPAGE_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the Blob Container SAS URL to use for storing documents that have selection marks used for live tests.</summary>
        internal const string SelectionMarkBlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_SELECTION_MARK_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the target resource identifier to use for copying custom models live tests.</summary>
        internal const string TargetResourceIdEnvironmentVariableName = "FORM_RECOGNIZER_TARGET_RESOURCE_ID";

        /// <summary>The name of the environment variable for the target resource region to use for copying custom models live tests.</summary>
        internal const string TargetResourceRegionEnvironmentVariableName = "FORM_RECOGNIZER_TARGET_RESOURCE_REGION";

        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string BlobContainerSasUrl => GetRecordedVariable(BlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret("https://sanitized.blob.core.windows.net"));
        public string SelectionMarkBlobContainerSasUrl => GetRecordedVariable(SelectionMarkBlobContainerSasUrlEnvironmentVariableName, options => options.IsSecret("https://sanitized.blob.core.windows.net"));
        public string MultipageBlobContainerSasUrl => GetRecordedVariable(MultipageBlobContainerSasUrlEnvironmentVariableName);
        public string TargetResourceId => GetRecordedVariable(TargetResourceIdEnvironmentVariableName);
        public string TargetResourceRegion => GetRecordedVariable(TargetResourceRegionEnvironmentVariableName);

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
