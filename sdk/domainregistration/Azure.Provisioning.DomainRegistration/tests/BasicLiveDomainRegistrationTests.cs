// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DomainRegistration.Tests;

public class BasicLiveDomainRegistrationTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [LiveOnly]
    public async Task CreateAppServiceDomain()
    {
        await using Trycep test = BasicDomainRegistrationTests.CreateAppServiceDomainTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
