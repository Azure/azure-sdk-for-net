// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Batch.Tests;

public class BasicBatchTests
{
    internal static Trycep CreateBatchAccountWithPoolTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:BatchAccountBasic
                Infrastructure infra = new();

                BatchAccount account =
                    new(nameof(account), BatchAccount.ResourceVersions.V2025_06_01)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(account);

                BatchAccountPool pool =
                    new(nameof(pool), BatchAccountPool.ResourceVersions.V2025_06_01)
                    {
                        Parent = account,
                        DisplayName = "MyPool",
                        VmSize = "Standard_D2s_v3",
                        ScaleSettings = new BatchAccountPoolScaleSettings
                        {
                            FixedScale = new BatchAccountFixedScaleSettings
                            {
                                TargetDedicatedNodes = 1,
                                TargetLowPriorityNodes = 0,
                            },
                        },
                    };
                infra.Add(pool);

                BatchApplication app =
                    new(nameof(app), BatchApplication.ResourceVersions.V2025_06_01)
                    {
                        Parent = account,
                        DisplayName = "MyApp",
                        AllowUpdates = true,
                    };
                infra.Add(app);

                infra.Add(new ProvisioningOutput("accountName", typeof(string)) { Value = account.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = account.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.batch/batchaccount-with-storage/main.bicep")]
    public async Task CreateBatchAccountWithPool()
    {
        await using Trycep test = CreateBatchAccountWithPoolTest();
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

            resource pool 'Microsoft.Batch/batchAccounts/pools@2025-06-01' = {
              name: take('pool-${uniqueString(resourceGroup().id)}', 64)
              properties: {
                displayName: 'MyPool'
                vmSize: 'Standard_D2s_v3'
                scaleSettings: {
                  fixedScale: {
                    targetDedicatedNodes: 1
                    targetLowPriorityNodes: 0
                  }
                }
              }
              parent: account
            }

            resource app 'Microsoft.Batch/batchAccounts/applications@2025-06-01' = {
              name: take('app-${uniqueString(resourceGroup().id)}', 64)
              properties: {
                displayName: 'MyApp'
                allowUpdates: true
              }
              parent: account
            }

            output accountName string = account.name

            output resourceId string = account.id
            """);
    }
}
