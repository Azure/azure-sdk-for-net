// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class FormRecognizerTestEnvironment: TestEnvironment
    {
        public FormRecognizerTestEnvironment() : base("formrecognizer")
        {
        }

        /// <summary>The name of the environment variable from which the Form Recognizer resource's endpoint will be extracted for the live tests.</summary>
        internal const string EndpointEnvironmentVariableName = "FORM_RECOGNIZER_ENDPOINT";

        /// <summary>The name of the environment variable from which the Form Recognizer resource's API key will be extracted for the live tests.</summary>
        internal const string ApiKeyEnvironmentVariableName = "FORM_RECOGNIZER_API_KEY";

        /// <summary>The name of the environment variable for the Blob Container SAS Url use for storing documents used for live tests.</summary>
        internal const string BlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the environment variable for the target resource identifier use for copying custom models live tests.</summary>
        internal const string TargetResourceIdEnvironmentVariableName = "FORM_RECOGNIZER_TARGET_RESOURCE_ID";

        /// <summary>The name of the environment variable for the target resource region use for copying custom models live tests.</summary>
        internal const string TargetResourceRegionEnvironmentVariableName = "FORM_RECOGNIZER_TARGET_RESOURCE_REGION";

        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName);
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string BlobContainerSasUrl => GetRecordedVariable(BlobContainerSasUrlEnvironmentVariableName);
        public string TargetResourceId => GetRecordedVariable(TargetResourceIdEnvironmentVariableName);
        public string TargetResourceRegion => GetRecordedVariable(TargetResourceRegionEnvironmentVariableName);

        /// <summary>
        /// The name of the directory where the running assembly is located.
        /// </summary>
        /// <value>The name of the current working directory.</value>
        private static string CurrentWorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string CreatePath(string fileName, string assetFolder = default) =>
            Path.Combine(CurrentWorkingDirectory, assetFolder ?? AssetsFolderName, fileName);

        public static string CreateUri(string fileName, string assetFolder = default, string fileUriFormat = default) =>
            string.Format(fileUriFormat ?? FileUriFormat, assetFolder ?? AssetsFolderName, fileName);

        public static FileStream CreateStream(string filename) =>
            new FileStream(CreatePath(filename), FileMode.Open);

        public static Uri CreateUriInstance(string filename) =>
            new Uri(CreateUri(filename));
    }
}
