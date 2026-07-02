// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DurableTask.Tests;

public class BasicDurableTaskTests
{
    internal static Trycep CreateDurableTaskSchedulerTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DurableTaskSchedulerBasic
                Infrastructure infra = new();

                DurableTaskScheduler scheduler =
                    new(nameof(scheduler), DurableTaskScheduler.ResourceVersions.V2026_02_01)
                    {
                        Tags = { ["environment"] = "test" },
                        Properties = new DurableTaskSchedulerProperties
                        {
                            IPAllowlist = { "0.0.0.0/0" },
                            Sku = new DurableTaskSchedulerSku
                            {
                                Name = DurableTaskSchedulerSkuName.Dedicated,
                                Capacity = 1,
                            },
                            PublicNetworkAccess = DurableTaskPublicNetworkAccess.Enabled,
                        },
                    };
                infra.Add(scheduler);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateDurableTaskScheduler()
    {
        await using Trycep test = CreateDurableTaskSchedulerTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource scheduler 'Microsoft.DurableTask/schedulers@2026-02-01' = {
              name: take('scheduler-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                ipAllowlist: [
                  '0.0.0.0/0'
                ]
                sku: {
                  name: 'Dedicated'
                  capacity: 1
                }
                publicNetworkAccess: 'Enabled'
              }
            }
            """);
    }
}
