// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Redis.Tests;

public class BasicLiveRedisTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cache/redis-cache/main.bicep")]
    [LiveOnly]
    public async Task CreateRedisCache()
    {
        await using Trycep test = BasicRedisTests.CreateRedisCacheTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }
}
