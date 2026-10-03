// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Monitor.Workspaces.Tests;

public class BasicMonitorWorkspacesTests
{
    internal static Trycep CreateMonitorWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:MonitorWorkspaceBasic
                Infrastructure infra = new();

                MonitorWorkspace workspace =
                    new(nameof(workspace), MonitorWorkspace.ResourceVersions.V2025_10_03)
                    {
                        Properties = new MonitorWorkspaceProperties
                        {
                            PublicNetworkAccess = MonitorWorkspacePublicNetworkAccess.Enabled,
                        },
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/tree/master/quickstarts/microsoft.monitor")]
    public async Task CreateMonitorWorkspace()
    {
        await using Trycep test = CreateMonitorWorkspaceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.Monitor/accounts@2025-10-03' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 24)
              location: location
              properties: {
                publicNetworkAccess: 'Enabled'
              }
            }
            """);
    }
}
