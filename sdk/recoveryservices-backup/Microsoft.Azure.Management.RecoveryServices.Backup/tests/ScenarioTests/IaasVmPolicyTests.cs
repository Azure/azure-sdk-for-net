// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class IaasVmPolicyTests: TestBase, IDisposable
    {
        private const string PoliciesTestVault = "DefaultPolicyTestVault";
        private const string PoliciesTestVaultRg = "DefaultPolicyTestVaultRg";

        [Fact]
        public void ListDefaultPolicy()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            using (var testHelper = new TestHelper() { VaultName = PoliciesTestVault, ResourceGroup = PoliciesTestVaultRg})
            {
                testHelper.Initialize(context);
                List<ProtectionPolicyResource> policies = testHelper.ListAllPoliciesWithRetries();
                Assert.Contains(policies, policy => policy.Name.ToLower().Equals("defaultpolicy"));

                ProtectionPolicyResource defaultPolicy = testHelper.GetPolicyWithRetries("defaultpolicy");

                Assert.NotNull(defaultPolicy);
                Assert.Equal("defaultpolicy", defaultPolicy.Name.ToLower());
            }
        }

        public void Dispose()
        {
        }
    }
}

