// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.ServiceBus.Tests;

public class BasicServiceBusTests(bool async)
    : ProvisioningTestBase(async /*, skipTools: true, skipLiveCalls: true /**/)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.servicebus/servicebus-create-queue/main.bicep")]
    public async Task CreateServiceBusQueue()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                BicepParameter queueName =
                    new(nameof(queueName), typeof(string))
                    {
                        Value = "orders",
                        Description = "The name of the SB queue."
                    };

                ServiceBusNamespace sb =
                    new(nameof(sb), ServiceBusNamespace.ResourceVersions.V2021_11_01)
                    {
                        Sku = new ServiceBusSku { Name = ServiceBusSkuName.Standard },
                    };

                ServiceBusQueue queue =
                    new(nameof(queue), ServiceBusNamespace.ResourceVersions.V2021_11_01)
                    {
                        Parent = sb,
                        Name = queueName,
                        // Hack around TimeSpan not serializing ISO durations
                        // correctly using a Bicep string literal expression.
                        // TODO: Change these to regular strings when patched.
                        LockDuration = new StringLiteral("PT5M"),
                        MaxSizeInMegabytes = 1024,
                        RequiresDuplicateDetection = false,
                        RequiresSession = false,
                        DefaultMessageTimeToLive = new StringLiteral("P10675199DT2H48M5.4775807S"),
                        DeadLetteringOnMessageExpiration = false,
                        DuplicateDetectionHistoryTimeWindow = new StringLiteral("PT10M"),
                        MaxDeliveryCount = 10,
                        AutoDeleteOnIdle = new StringLiteral("P10675199DT2H48M5.4775807S"),
                        EnablePartitioning = false,
                        EnableExpress = false
                    };
            })
        .Compare(
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
            """)
        .Lint()
        .ValidateAndDeployAsync();
    }
}
