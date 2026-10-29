// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Quantum.Tests;

public class BasicQuantumTests
{
    internal static Trycep CreateQuantumWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:QuantumWorkspaceBasic
                Infrastructure infra = new();

                QuantumWorkspace workspace =
                    new(nameof(workspace), QuantumWorkspace.ResourceVersions.V2026_06_15_PREVIEW)
                    {
                        Name = "quantum-workspace",
                        Identity = new ManagedServiceIdentity
                        {
                            ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned,
                        },
                        Properties = new QuantumWorkspaceProperties
                        {
                            WorkspaceKind = QuantumWorkspaceKind.V2,
                            IsApiKeyEnabled = false,
                        },
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(workspace);

                infra.Add(new ProvisioningOutput("workspaceId", typeof(string)) { Value = workspace.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateQuantumWorkspace()
    {
        await using Trycep test = CreateQuantumWorkspaceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.Quantum/workspaces@2026-06-15-preview' = {
              name: 'quantum-workspace'
              location: location
              identity: {
                type: 'SystemAssigned'
              }
              properties: {
                apiKeyEnabled: false
                workspaceKind: 'V2'
              }
              tags: {
                environment: 'test'
              }
            }

            output workspaceId string = workspace.id
            """);
    }
}
