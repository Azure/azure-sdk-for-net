// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceBus.Tests;

public class BasicServiceBusTests
{
    internal static Trycep CreateServiceBusQueueTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:ServiceBusBasic
                Infrastructure infra = new();

                ProvisioningParameter queueName =
                    new(nameof(queueName), typeof(string))
                    {
                        Value = "orders",
                        Description = "The name of the SB queue."
                    };
                infra.Add(queueName);

                ServiceBusNamespace sb =
                    new(nameof(sb), ServiceBusNamespace.ResourceVersions.V2021_11_01)
                    {
                        Sku = new ServiceBusSku { Name = ServiceBusSkuName.Standard },
                    };
                infra.Add(sb);

                ServiceBusQueue queue =
                    new(nameof(queue), ServiceBusNamespace.ResourceVersions.V2021_11_01)
                    {
                        Parent = sb,
                        Name = queueName,
                        LockDuration = TimeSpan.FromMinutes(5),
                        MaxSizeInMegabytes = 1024,
                        RequiresDuplicateDetection = false,
                        RequiresSession = false,
                        DefaultMessageTimeToLive = TimeSpan.MaxValue,
                        DeadLetteringOnMessageExpiration = false,
                        DuplicateDetectionHistoryTimeWindow = TimeSpan.FromMinutes(10),
                        MaxDeliveryCount = 10,
                        AutoDeleteOnIdle = TimeSpan.MaxValue,
                        EnablePartitioning = false,
                        EnableExpress = false
                    };
                infra.Add(queue);
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.servicebus/servicebus-create-queue/main.bicep")]
    public async Task CreateServiceBusQueue()
    {
        await using Trycep test = CreateServiceBusQueueTest();
        test.Compare(
            """
            @description('The name of the SB queue.')
            param queueName string = 'orders'

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource sb 'Microsoft.ServiceBus/namespaces@2021-11-01' = {
              name: take('sb-${uniqueString(resourceGroup().id)}', 50)
              location: location
              sku: {
                name: 'Standard'
              }
            }

            resource queue 'Microsoft.ServiceBus/namespaces/queues@2021-11-01' = {
              name: queueName
              properties: {
                autoDeleteOnIdle: 'P10675199DT2H48M5.4775807S'
                deadLetteringOnMessageExpiration: false
                defaultMessageTimeToLive: 'P10675199DT2H48M5.4775807S'
                duplicateDetectionHistoryTimeWindow: 'PT10M'
                enableExpress: false
                enablePartitioning: false
                lockDuration: 'PT5M'
                maxDeliveryCount: 10
                maxSizeInMegabytes: 1024
                requiresDuplicateDetection: false
                requiresSession: false
              }
              parent: sb
            }
            """);
    }
}
