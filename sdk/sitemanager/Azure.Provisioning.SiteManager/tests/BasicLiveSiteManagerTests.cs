// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SiteManager.Tests;

public class BasicLiveSiteManagerTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateSite()
    {
        await using Trycep test = BasicSiteManagerTests.CreateSiteTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
