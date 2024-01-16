// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentIntelligenceTestEnvironment : TestEnvironment
    {
        private const string SanitizedSasUrl = "https://sanitized.blob.core.windows.net";

        private const string AssetsFolderName = "Assets";

        // We are using assets from the old Form Recognizer package while this package hasn't moved to the public repository.
        // Files are exactly the same, so this doesn't affect test behavior.
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/main/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        private static readonly string s_currentWorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public string Endpoint => GetRecordedVariable("ENDPOINT");

        public string ApiKey => GetRecordedVariable("API_KEY", options => options.IsSecret());

        public string ResourceId => GetRecordedVariable("RESOURCE_ID");

        public string ResourceRegion => GetRecordedVariable("RESOURCE_REGION");

        public string BlobContainerSasUrl => GetRecordedVariable("SINGLEPAGE_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        public string ClassifierTrainingSasUrl => GetRecordedVariable("CLASSIFIER_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        public static string CreatePath(string filename)
        {
            return Path.Combine(s_currentWorkingDirectory, AssetsFolderName, filename);
        }

        public static Uri CreateUri(string filename)
        {
            var uriString = string.Format(FileUriFormat, AssetsFolderName, filename);

            return new Uri(uriString);
        }

        public static BinaryData CreateBinaryData(string filename)
        {
            var path = CreatePath(filename);
            var bytes = File.ReadAllBytes(path);

            return BinaryData.FromBytes(bytes);
        }
    }
}
