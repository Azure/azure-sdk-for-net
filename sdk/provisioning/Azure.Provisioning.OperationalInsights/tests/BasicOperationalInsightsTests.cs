// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.OperationalInsights.Tests;

public class BasicOperationalInsightsTests
{
    internal static Trycep CreateWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:OperationalInsightsWorkspaceBasic
                Infrastructure infra = new();

                OperationalInsightsWorkspace workspace =
                    new(nameof(workspace), OperationalInsightsWorkspace.ResourceVersions.V2023_09_01)
                    {
                        Sku = new OperationalInsightsWorkspaceSku
                        {
                            Name = OperationalInsightsWorkspaceSkuName.PerGB2018
                        },
                        Identity = new ManagedServiceIdentity { ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned },
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateWorkspace()
    {
        await using Trycep test = CreateWorkspaceTest();
        test.Compare(
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
            """);
    }
}
