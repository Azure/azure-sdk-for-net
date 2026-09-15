// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Billing.Tests;

public class BasicLiveBillingTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/rest/api/billing/policies/put?view=rest-billing-2024-04-01")]
    [LiveOnly]
    public async Task CreateBillingAccountPolicy()
    {
        await using Trycep test = BasicBillingTests.CreateBillingAccountPolicyTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
