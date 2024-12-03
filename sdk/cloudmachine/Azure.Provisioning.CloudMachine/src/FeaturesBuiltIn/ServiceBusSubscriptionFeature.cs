// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.CloudMachine.Core;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;

namespace Azure.CloudMachine.ServiceBus;

internal class ServiceBusSubscriptionFeature(string name, ServiceBusTopicFeature parent) : CloudMachineFeature
{
    protected override ProvisionableResource EmitResources(CloudMachineInfrastructure infrastructure)
    {
        var subscription = new ServiceBusSubscription(name, "2021-11-01")
        {
            Name = name,
            Parent = EnsureEmits<ServiceBusTopic>(parent),
            IsClientAffine = false,
            LockDuration = TimeSpan.FromSeconds(30),
            RequiresSession = false,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            DeadLetteringOnFilterEvaluationExceptions = true,
            DeadLetteringOnMessageExpiration = true,
            MaxDeliveryCount = 10,
            EnableBatchedOperations = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };

        infrastructure.AddResource(subscription);
        return subscription;
    }

    protected internal override void EmitConnections(ConnectionCollection connections, string cmId)
    {
        ClientConnection connection = new(
            $"{name}",
            $"{parent.Name}/{name}"
        );
        connections.Add(connection);
    }
}
