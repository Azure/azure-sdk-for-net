// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RedisEnterprise.Tests;

public class BasicLiveRedisEnterpriseTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cache/redis-enterprise-vectordb/main.bicep")]
    [LiveOnly]
    public async Task CreateRedisEnterpriseVectorDB()
    {
        await using Trycep test = BasicRedisEnterpriseTests.CreateRedisEnterpriseVectorDBTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .DeployAsync();
    }
}
