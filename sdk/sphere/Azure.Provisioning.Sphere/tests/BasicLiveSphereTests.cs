// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Sphere.Tests;

public class BasicLiveSphereTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateCatalog()
    {
        await using Trycep test = BasicSphereTests.CreateCatalogTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
