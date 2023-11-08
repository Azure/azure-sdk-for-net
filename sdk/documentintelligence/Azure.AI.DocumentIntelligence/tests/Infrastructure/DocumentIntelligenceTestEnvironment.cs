// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.DocumentIntelligence.Tests
{
    public class DocumentIntelligenceTestEnvironment : TestEnvironment
    {
        private const string SanitizedSasUrl = "https://sanitized.blob.core.windows.net";

        public string Endpoint => GetRecordedVariable("ENDPOINT");

        public string ApiKey => GetRecordedVariable("API_KEY", options => options.IsSecret());

        public string ResourceId => GetRecordedVariable("RESOURCE_ID");

        public string ResourceRegion => GetRecordedVariable("RESOURCE_REGION");

        public string BlobContainerSasUrl => GetRecordedVariable("SINGLEPAGE_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));

        public string ClassifierTrainingSasUrl => GetRecordedVariable("CLASSIFIER_BLOB_CONTAINER_SAS_URL", options => options.IsSecret(SanitizedSasUrl));
    }
}
