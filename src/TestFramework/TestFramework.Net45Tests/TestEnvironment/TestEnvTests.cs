
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Threading;
using Xunit;


namespace TestFramework.Net45Tests
{
    public class TestEnvTests
    {
        [Fact]
        public void InteractiveLogin()
        {
            //SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
            Environment.SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=2c224e7e-57b-e71f4662e3a6;Environment=Prod");
            HttpMockServer.Mode = HttpRecorderMode.Record;
            TestEnvironment env = TestEnvironmentFactory.GetTestEnvironment();
            string tenantId = env.ConnectionString.KeyValuePairs[ConnectionStringKeys.AADTenantKey];
            Assert.False(string.IsNullOrEmpty(tenantId));
            Assert.Equal<string>("72f988bf-86f1-41af-91ab-2d7cd011db47", tenantId);
        }
    }
}
