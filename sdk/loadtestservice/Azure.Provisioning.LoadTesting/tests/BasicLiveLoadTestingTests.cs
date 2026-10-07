// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.LoadTesting.Tests;

public class BasicLiveLoadTestingTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://learn.microsoft.com/azure/load-testing/quickstart-create-and-run-load-test-with-bicep")]
    [LiveOnly]
    public async Task CreateLoadTestingResource()
    {
        await using Trycep test = BasicLoadTestingTests.CreateLoadTestingResourceTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
