using Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.ScenarioTests
{
    public class DPPPoliciesTests : TestBase, IDisposable
    {
        private const string PoliciesTestVault = "DefaultPolicyTestVault";
        private const string PoliciesTestVaultRg = "DefaultPolicyTestVaultRg";

        [Fact]
        public void CreatePolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            using (TestHelper testHelper = new TestHelper() { VaultName = PoliciesTestVault, ResourceGroup = PoliciesTestVaultRg })
            {
                testHelper.Initialize(context);
                testHelper.CreatePolicy("MyPolicy");
            }
        }
        public void Dispose()
        {
        }
    }
}
