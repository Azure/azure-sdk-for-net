// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    public class DeviceUpdateClientTestEnvironment: TestEnvironment
    {
        public Uri AccountEndPoint => new Uri($"https://{GetRecordedVariable("DEVICEUPDATE_ACCOUNT_ENDPOINT")}");

        public string InstanceId => GetRecordedVariable("DEVICEUPDATE_INSTANCE_ID");

        public string UpdateProvider => "fabrikam";

        public string UpdateName => "vacuum";

        public string UpdateVersion => "2022.809.131.21";

        public string DeviceGroup => "dpokluda-test";
    }
}
