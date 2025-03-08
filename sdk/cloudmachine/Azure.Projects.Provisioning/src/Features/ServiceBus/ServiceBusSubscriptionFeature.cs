// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects.ServiceBus;

internal class ServiceBusSubscriptionFeature(string name, ServiceBusTopicFeature parent) : AzureProjectFeature
{
    protected internal override void EmitResources(ProjectInfrastructure infrastructure)
    {
        ServiceBusTopic serviceBusTopic = infrastructure.GetConstruct<ServiceBusTopic>(parent.Id);

        var subscription = new ServiceBusSubscription(name, "2021-11-01")
        {
            Name = name,
            Parent = serviceBusTopic,
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

        infrastructure.AddConstruct(Id, subscription);

        EmitConnection(infrastructure, name, $"{parent.Name}/{name}");
    }
}
