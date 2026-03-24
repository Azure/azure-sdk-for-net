// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Batch.Tests;

public class BasicBatchTests
{
    internal static Trycep CreateBatchAccountTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();

                BatchAccount account =
                    new(nameof(account), BatchAccount.ResourceVersions.V2025_06_01)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(account);

                BatchApplication app =
                    new(nameof(app), BatchApplication.ResourceVersions.V2025_06_01)
                    {
                        Parent = account,
                        DisplayName = "MyApp",
                        AllowUpdates = true,
                    };
                infra.Add(app);

                BatchAccountPool pool =
                    new(nameof(pool), BatchAccountPool.ResourceVersions.V2025_06_01)
                    {
                        Parent = account,
                        DisplayName = "MyPool",
                        VmSize = "Standard_D2s_v3",
                    };
                infra.Add(pool);

                infra.Add(new ProvisioningOutput("accountName", typeof(string)) { Value = account.Name });

                return infra;
            });
    }

    [Test]
    [Description("Verify basic Batch account, pool, and application provisioning")]
    public async Task CreateBatchAccountPoolAndApp()
    {
        await using Trycep test = CreateBatchAccountTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource account 'Microsoft.Batch/batchAccounts@2025-06-01' = {
              name: take('account${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
            }

            resource app 'Microsoft.Batch/batchAccounts/applications@2025-06-01' = {
              properties: {
                displayName: 'MyApp'
                allowUpdates: true
              }
              name: take('app-${uniqueString(resourceGroup().id)}', 64)
              parent: account
            }

            resource pool 'Microsoft.Batch/batchAccounts/pools@2025-06-01' = {
              properties: {
                displayName: 'MyPool'
                vmSize: 'Standard_D2s_v3'
              }
              name: take('pool-${uniqueString(resourceGroup().id)}', 64)
              parent: account
            }

            output accountName string = account.name
            """);
    }
}
