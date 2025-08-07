// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Fabric.Tests
{
    public class FabricManagementTestEnvironment : TestEnvironment
    {
        public string CapacityName => GetRecordedVariable("FABRIC_CAPACITY_NAME");

        public string CapacityId => GetRecordedVariable("FABRIC_CAPACITY_ID");

        public string CapacityLocation => GetRecordedVariable("FABRIC_LOCATION");
    }
}
