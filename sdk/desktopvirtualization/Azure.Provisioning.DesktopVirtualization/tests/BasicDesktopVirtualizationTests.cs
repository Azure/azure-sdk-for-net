// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.DesktopVirtualization.Tests;

public class BasicDesktopVirtualizationTests
{
    internal static Trycep CreateVirtualWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DesktopVirtualizationBasic
                Infrastructure infra = new();

                VirtualWorkspace workspace =
                    new(nameof(workspace), VirtualWorkspace.ResourceVersions.V2026_04_01_PREVIEW)
                    {
                        Description = "Example virtual desktop workspace",
                        FriendlyName = "Example workspace",
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/azure/templates/microsoft.desktopvirtualization/workspaces")]
    public async Task CreateVirtualWorkspace()
    {
        await using Trycep test = CreateVirtualWorkspaceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.DesktopVirtualization/workspaces@2026-04-01-preview' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 64)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                description: 'Example virtual desktop workspace'
                friendlyName: 'Example workspace'
              }
            }
            """);
    }
}
