// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AgriculturePlatform.Tests;

public class BasicAgriculturePlatformTests
{
    internal static Trycep CreateAgricultureServiceTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AgriculturePlatformBasic
                Infrastructure infra = new();

                AgricultureService service =
                    new(nameof(service), AgricultureService.ResourceVersions.V2024_06_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(service);

                infra.Add(new ProvisioningOutput("serviceName", typeof(string)) { Value = service.Name });
                infra.Add(new ProvisioningOutput("serviceId", typeof(string)) { Value = service.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateAgricultureService()
    {
        await using Trycep test = CreateAgricultureServiceTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource service 'Microsoft.AgriculturePlatform/agriServices@2024-06-01-preview' = {
              name: take('service-${uniqueString(resourceGroup().id)}', 24)
              location: location
              tags: {
                environment: 'test'
              }
            }

            output serviceName string = service.name

            output serviceId string = service.id
            """);
    }

    [Test]
    public async Task ReferenceExistingAgricultureService()
    {
        await using Trycep test = new Trycep().Define(
            ctx =>
            {
                Infrastructure infra = new();
                AgricultureService service = AgricultureService.FromExisting(nameof(service));
                service.Name = "existing-agri-service";
                infra.Add(service);
                infra.Add(new ProvisioningOutput("serviceId", typeof(string)) { Value = service.Id });
                return infra;
            });
        test.Compare(
            """
            resource service 'Microsoft.AgriculturePlatform/agriServices@2024-06-01-preview' existing = {
              name: 'existing-agri-service'
            }

            output serviceId string = service.id
            """);
    }
}
