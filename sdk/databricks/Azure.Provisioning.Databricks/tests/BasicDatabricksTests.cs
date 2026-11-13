// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.Databricks.Tests;

public class BasicDatabricksTests
{
    internal static Trycep CreateDatabricksWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:DatabricksWorkspaceBasic
                Infrastructure infra = new();

                DatabricksWorkspace workspace =
                    new(nameof(workspace), DatabricksWorkspace.ResourceVersions.V2026_01_01)
                    {
                        Location = new AzureLocation("eastus"),
                        Sku = new DatabricksSku { Name = "premium" },
                        ComputeMode = DatabricksComputeMode.Serverless,
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateDatabricksWorkspace()
    {
        await using Trycep test = CreateDatabricksWorkspaceTest();
        test.Compare(
            """
            resource workspace 'Microsoft.Databricks/workspaces@2026-01-01' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 64)
              location: 'eastus'
              properties: {
                computeMode: 'Serverless'
              }
              sku: {
                name: 'premium'
              }
            }
            """);
    }
}
