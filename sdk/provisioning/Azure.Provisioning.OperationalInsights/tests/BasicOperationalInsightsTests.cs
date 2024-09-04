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
    [RecordedTest]
    public async Task CreateWorkspace()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter location = BicepParameter.Create<string>(nameof(location), BicepFunction.GetResourceGroup().Location);
                location.Description = "The workspace location.";

                OperationalInsightsWorkspace workspace =
                    new(nameof(workspace))
                    {
                        Location = location,
                        Sku = new OperationalInsightsWorkspaceSku
                        {
                            Name = OperationalInsightsWorkspaceSkuName.PerGB2018
                        },
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                    };
            })
        .Compare(
            """
            @description('The workspace location.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.OperationalInsights/workspaces@2022-10-01' = {
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
