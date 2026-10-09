// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Quota.Tests;

public class BasicLiveQuotaTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.quota/groupquotas")]
    [LiveOnly]
    public async Task CreateGroupQuota()
    {
        await using Trycep test = BasicQuotaTests.CreateGroupQuotaTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
