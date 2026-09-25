// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.HealthcareApis.Tests;

public class BasicHealthcareApisTests
{
    internal static Trycep CreateWorkspaceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:HealthcareApisBasic
                Infrastructure infra = new();

                HealthcareApisWorkspace workspace =
                    new(nameof(workspace), HealthcareApisWorkspace.ResourceVersions.V2025_04_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.healthcareapis/workspaces/create-workspace-with-child-services/main.bicep")]
    public async Task CreateWorkspace()
    {
        await using Trycep test = CreateWorkspaceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource workspace 'Microsoft.HealthcareApis/workspaces@2025-04-01-preview' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 24)
              location: location
              tags: {
                environment: 'test'
              }
            }
            """);
    }
}
