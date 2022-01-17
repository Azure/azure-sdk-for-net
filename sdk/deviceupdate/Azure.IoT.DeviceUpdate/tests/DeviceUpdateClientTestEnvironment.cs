// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    public class DeviceUpdateClientTestEnvironment: TestEnvironment
    {
        public DeviceUpdateClientTestEnvironment()
        {
        }
        public Uri AccountEndPoint => new(GetRecordedVariable("DEVICEUPDATE_ACCOUNT_ENDPOINT"));

        public string InstanceId => GetRecordedVariable("DEVICEUPDATE_INSTANCE_ID");
    }
}
