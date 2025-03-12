// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects.ServiceBus;

internal class ServiceBusSubscriptionFeature : AzureProjectFeature
{
    public ServiceBusSubscriptionFeature(string name, ServiceBusTopicFeature parent)
    {
        Name = name;
        Parent = parent;
    }

    public string Name { get; }
    public ServiceBusTopicFeature Parent { get; }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        ServiceBusTopic serviceBusTopic = infrastructure.GetConstruct<ServiceBusTopic>(Parent.Id);

        var subscription = new ServiceBusSubscription(Name, "2021-11-01")
        {
            Name = Name,
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

        EmitConnections(infrastructure, Name, $"{Parent.Name}/{Name}");
    }
}
