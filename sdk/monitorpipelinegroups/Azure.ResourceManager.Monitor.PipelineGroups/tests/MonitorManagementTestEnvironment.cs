// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Monitor.PipelineGroups.Tests
{
    public class MonitorManagementTestEnvironment : TestEnvironment
    {
        public string CustomLocationId => GetRecordedVariable("CUSTOM_LOCATION_ID");
        public string DataCollectionEndpointUri => GetRecordedVariable("DATA_COLLECTION_ENDPOINT_URI");
        public string DataCollectionStream => GetRecordedVariable("DATA_COLLECTION_STREAM");
        public string DataCollectionRule => GetRecordedVariable("DATA_COLLECTION_RULE");
    }
}
