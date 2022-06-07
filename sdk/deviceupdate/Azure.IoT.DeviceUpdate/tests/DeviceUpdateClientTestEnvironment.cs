// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    public class DeviceUpdateClientTestEnvironment: TestEnvironment
    {
        public string AccountEndPoint => GetVariable("DEVICEUPDATE_ACCOUNT_ENDPOINT");

        public string InstanceId => GetVariable("DEVICEUPDATE_INSTANCE_ID");

        public string UpdateProvider => "fabrikam";

        public string UpdateName => "vacuum";

        public string UpdateVersion => "2022.401.504.6";

        public string DeviceGroup => "dpokluda-test";
    }
}
