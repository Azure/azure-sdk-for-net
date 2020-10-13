// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Iot.Hub.Service.Tests
{
    // This class contains the configurations required to be set to run tests against the CI pipeline.
    public class IotHubServiceTestEnvironment : TestEnvironment
    {
        public IotHubServiceTestEnvironment()
            : base(TestSettings.IotHubEnvironmentVariablesPrefix.ToLower())
        {
        }

        public string IotHubConnectionString => GetRecordedVariable(TestSettings.IotHubConnectionString);
    }
}
