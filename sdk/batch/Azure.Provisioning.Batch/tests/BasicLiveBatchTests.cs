// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Batch.Tests;

public class BasicLiveBatchTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true */)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.batch/batchaccount-with-storage/main.bicep")]
    [LiveOnly]
    public async Task CreateBatchAccountWithPool()
    {
        await using Trycep test = BasicBatchTests.CreateBatchAccountWithPoolTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
