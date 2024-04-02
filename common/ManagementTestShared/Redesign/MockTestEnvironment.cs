// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using System;

#nullable disable

namespace Azure.ResourceManager.TestFramework
{
    public class MockTestEnvironment : TestEnvironment
    {
        public MockTestEnvironment() : base()
        {
            Environment.SetEnvironmentVariable("SUBSCRIPTION_ID", "00000000-0000-0000-0000-000000000000");
            Environment.SetEnvironmentVariable("RESOURCE_MANAGER_URL", MockEndPoint);
        }

        public static string MockEndPoint = $"https://localhost:8443";

        private TokenCredential _mockCredential;

        public override TokenCredential Credential => _mockCredential ??= new MockCredential();
    }
}
