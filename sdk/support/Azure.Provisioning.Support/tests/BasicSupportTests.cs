// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// cspell:ignore Trycep

using System.Threading.Tasks;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Support.Tests;

public class BasicSupportTests
{
    internal static Trycep CreateFileWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SupportFileWorkspaceBasic
                Infrastructure infra = new() { TargetScope = DeploymentScope.Subscription };

                FileWorkspaceDetail workspace = new(nameof(workspace), FileWorkspaceDetail.ResourceVersions.V2024_04_01)
                {
                    Name = "supportfiles",
                };
                infra.Add(workspace);

                infra.Add(new ProvisioningOutput("workspaceId", typeof(string)) { Value = workspace.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.support/2024-04-01/fileworkspaces")]
    public async Task CreateFileWorkspace()
    {
        await using Trycep test = CreateFileWorkspaceTest();
        test.Compare(
            """
            targetScope = 'subscription'

            resource workspace 'Microsoft.Support/fileWorkspaces@2024-04-01' = {
              name: 'supportfiles'
            }

            output workspaceId string = workspace.id
            """);
    }
}
