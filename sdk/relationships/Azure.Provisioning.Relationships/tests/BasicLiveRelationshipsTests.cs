// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Relationships.Tests;

public class BasicLiveRelationshipsTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [LiveOnly]
    public async Task CreateDependencyRelationship()
    {
        await using Trycep test = BasicRelationshipsTests.CreateDependencyRelationshipTest();
        await test.SetupLiveCalls(this)
            .Lint()
            .ValidateAsync();
    }
}
