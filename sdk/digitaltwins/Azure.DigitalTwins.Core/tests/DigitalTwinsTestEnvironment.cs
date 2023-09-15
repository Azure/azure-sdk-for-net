// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class DigitalTwinsTestEnvironment : TestEnvironment
    {
        internal const string FAKE_URL = "https://fakeHost.api.wus2.digitaltwins.azure.net";

        public string DigitalTwinHostname => GetRecordedVariable($"{TestSettings.AdtEnvironmentVariablesPrefix}_URL", options => options.IsSecret(FAKE_URL));

        public string StorageContainerEndpoint => GetRecordedVariable("STORAGE_CONTAINER_URI");

        public string InputBlobUri => GetRecordedVariable("INPUT_BLOB_URI");
    }
}
