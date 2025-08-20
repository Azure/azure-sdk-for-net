// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.OperationalInsights.Tests;

public class BasicOperationalInsightsTests(bool async)
    : ProvisioningTestBase(async/*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    public async Task CreateWorkspace()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();

                OperationalInsightsWorkspace workspace =
                    new(nameof(workspace))
                    {
                        Sku = new OperationalInsightsWorkspaceSku
                        {
                            Name = OperationalInsightsWorkspaceSkuName.PerGB2018
                        },
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                    };
                infra.Add(workspace);

                return infra;
            })
        .Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.OperationalInsights/workspaces@2023-09-01' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 63)
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                sku: {
                  name: 'PerGB2018'
                }
              }
            }
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
