// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Synapse.Tests;

public class BasicSynapseTests
{
    internal static Trycep CreateSynapseWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SynapseWorkspaceBasic
                Infrastructure infra = new();

                ProvisioningParameter sqlAdministratorLoginPassword =
                    new(nameof(sqlAdministratorLoginPassword), typeof(string))
                    {
                        Description = "The administrator password for the Synapse workspace.",
                        IsSecure = true
                    };
                infra.Add(sqlAdministratorLoginPassword);

                SynapseWorkspace workspace =
                    new(nameof(workspace), SynapseWorkspace.ResourceVersions.V2021_06_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                        DefaultDataLakeStorage = new DataLakeStorageAccountDetails
                        {
                            AccountUri = "https://examplestorage.dfs.core.windows.net",
                            Filesystem = "synapse"
                        },
                        SqlAdministratorLogin = "synapseadmin",
                        SqlAdministratorLoginPassword = sqlAdministratorLoginPassword
                    };
                infra.Add(workspace);

                infra.Add(new ProvisioningOutput("workspaceName", typeof(string)) { Value = workspace.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = workspace.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateSynapseWorkspace()
    {
        await using Trycep test = CreateSynapseWorkspaceTest();
        test.Compare(
            """
            @secure()
            @description('The administrator password for the Synapse workspace.')
            param sqlAdministratorLoginPassword string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.Synapse/workspaces@2021-06-01-preview' = {
              name: take('workspace${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                defaultDataLakeStorage: {
                  accountUrl: 'https://examplestorage.dfs.core.windows.net'
                  filesystem: 'synapse'
                }
                sqlAdministratorLoginPassword: sqlAdministratorLoginPassword
                sqlAdministratorLogin: 'synapseadmin'
              }
            }

            output workspaceName string = workspace.name

            output resourceId string = workspace.id
            """);
    }
}
