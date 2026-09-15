// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.IotHub.Tests;

public class BasicIotHubTests
{
    internal static Trycep CreateIotHubTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:IotHubBasic
                Infrastructure infra = new();

                IotHubDescription hub =
                    new(nameof(hub), IotHubDescription.ResourceVersions.V2026_03_01_PREVIEW)
                    {
                        Tags = { ["environment"] = "test" },
                        Sku = new IotHubSkuInfo
                        {
                            Name = IotHubSku.S1,
                            Capacity = 1,
                        },
                    };
                infra.Add(hub);

                infra.Add(new ProvisioningOutput("iotHubName", typeof(string)) { Value = hub.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = hub.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description(
        "Azure Quickstart Template: https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.devices/iothub-device-provisioning/main.bicep; " +
        "Microsoft Learn: https://learn.microsoft.com/azure/iot-hub/create-hub")]
    public async Task CreateIotHub()
    {
        await using Trycep test = CreateIotHubTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource hub 'Microsoft.Devices/IotHubs@2026-03-01-preview' = {
              name: take('hub${uniqueString(resourceGroup().id)}', 24)
              location: location
              sku: {
                capacity: 1
                name: 'S1'
              }
              tags: {
                environment: 'test'
              }
            }

            output iotHubName string = hub.name

            output resourceId string = hub.id
            """);
    }
}
