// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ApiCenter.Tests;

public class BasicApiCenterTests
{
    internal static Trycep CreateApiCenterServiceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ApiCenterBasic
                Infrastructure infra = new();

                ApiCenterService service =
                    new(nameof(service), ApiCenterService.ResourceVersions.V2024_06_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(service);

                ApiCenterWorkspace workspace =
                    new(nameof(workspace), ApiCenterWorkspace.ResourceVersions.V2024_06_01_PREVIEW)
                    {
                        Parent = service,
                    };
                infra.Add(workspace);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateApiCenterService()
    {
        await using Trycep test = CreateApiCenterServiceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource service 'Microsoft.ApiCenter/services@2024-06-01-preview' = {
              name: take('service-${uniqueString(resourceGroup().id)}', 90)
              location: location
              tags: {
                environment: 'test'
              }
            }

            resource workspace 'Microsoft.ApiCenter/services/workspaces@2024-06-01-preview' = {
              name: take('workspace-${uniqueString(resourceGroup().id)}', 90)
              parent: service
            }
            """);
    }
}
