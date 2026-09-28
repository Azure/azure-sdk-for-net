// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ImageBuilder.Tests;

public class BasicLiveImageBuilderTests(bool async)
    : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateImageTemplate()
    {
        await using Trycep test = BasicImageBuilderTests.CreateImageTemplateTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
