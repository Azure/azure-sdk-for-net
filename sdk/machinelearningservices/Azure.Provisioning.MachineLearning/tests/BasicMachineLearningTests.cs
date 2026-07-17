// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.MachineLearning.Tests;

public class BasicMachineLearningTests
{
    internal static Trycep CreateWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:MachineLearningWorkspaceBasic
                Infrastructure infra = new();

                MachineLearningWorkspace workspace =
                    new(nameof(workspace), MachineLearningWorkspace.ResourceVersions.V2026_05_01)
                    {
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned
                        },
                        PublicNetworkAccess = PublicNetworkAccess.Enabled,
                        Tags = { ["environment"] = "test" },
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

            resource workspace 'Microsoft.MachineLearningServices/workspaces@2026-05-01' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 24)
              properties: {
                publicNetworkAccess: 'Enabled'
              }
              identity: {
                type: 'SystemAssigned'
              }
              location: location
              tags: {
                environment: 'test'
              }
            }
            """);
    }
}
