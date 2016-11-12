// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace TestFramework.Tests.TestEnvironment
{
    using Xunit;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using Microsoft.Azure.Test.HttpRecorder;

    public class TestEnvironmentTests
    {
        [Fact]
        public void EmptyTestEnvironment()
        {
            TestEnvironment env = new TestEnvironment();
            Assert.Equal<int>(4, env.EnvEndpoints.Count);
        }

        [Fact]
        public void DefaultTenantInTestEnvironment()
        {
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=2c224e7e-57b-e71f4662e3a6;ServicePrincipal=4c9b80e8e4-7c2233383b4e;ServicePrincipalSecret=kzSj3+tSXIdRsX8mxuQe7yZY=;Environment=Prod");
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey];
            Assert.False(string.IsNullOrEmpty(tenantId));
            Assert.Equal<string>("72f988bf-86f1-41af-91ab-2d7cd011db47", tenantId);
        }

    }
}
