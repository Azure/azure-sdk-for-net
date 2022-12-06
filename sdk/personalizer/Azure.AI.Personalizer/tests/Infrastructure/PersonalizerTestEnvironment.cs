// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Personalizer.Tests
{
    public class PersonalizerTestEnvironment: TestEnvironment
    {
        /// <summary>The name of the environment variable from which Personalizer resource's endpoint will be extracted for the live tests.</summary>
        internal const string MultiSlotEndpointEnvironmentVariableName = "PERSONALIZER_ENDPOINT_MULTI_SLOT";

        /// <summary>The name of the environment variable from which the Personalizer resource's API key will be extracted for the live tests.</summary>
        internal const string MultiSlotApiKeyEnvironmentVariableName = "PERSONALIZER_API_KEY_MULTI_SLOT";

        /// <summary>The name of the environment variable from which Personalizer resource's endpoint will be extracted for the live tests.</summary>
        internal const string SingleSlotEndpointEnvironmentVariableName = "PERSONALIZER_ENDPOINT_SINGLE_SLOT";

        /// <summary>The name of the environment variable from which the Personalizer resource's API key will be extracted for the live tests.</summary>
        internal const string SingleSlotApiKeyEnvironmentVariableName = "PERSONALIZER_API_KEY_SINGLE_SLOT";

        public string SingleSlotApiKey => GetRecordedVariable(SingleSlotApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string SingleSlotEndpoint => GetRecordedVariable(SingleSlotEndpointEnvironmentVariableName);

        public string MultiSlotApiKey => GetRecordedVariable(MultiSlotApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string MultiSlotEndpoint => GetRecordedVariable(MultiSlotEndpointEnvironmentVariableName);
    }
}
