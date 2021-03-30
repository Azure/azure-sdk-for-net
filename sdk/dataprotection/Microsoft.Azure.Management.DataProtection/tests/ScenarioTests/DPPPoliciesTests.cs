using Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.ScenarioTests
{
    public class DPPPoliciesTests : TestBase, IDisposable
    {
        private const string PoliciesTestVault = "mayankVault";
        private const string PoliciesTestVaultRg = "mayaggarDiskRG";

        [Fact]
        public void CreatePolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            using (TestHelper testHelper = new TestHelper())
            {
                testHelper.Initialize(context);
            }
        }
        public void Dispose()
        {
        }
    }
}
