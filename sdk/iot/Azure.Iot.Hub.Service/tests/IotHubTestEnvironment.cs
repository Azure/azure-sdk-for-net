// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    public class IotHubTestEnvironment : TestEnvironment
    {
        public IotHubTestEnvironment()
            : base(TestSettings.IotHubEnvironmentVariablesPrefix)
        {
        }
    }
}
