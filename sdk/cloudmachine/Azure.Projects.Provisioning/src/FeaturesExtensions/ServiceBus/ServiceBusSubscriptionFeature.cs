// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects.ServiceBus;

internal class ServiceBusSubscriptionFeature(string name, ServiceBusTopicFeature parent) : AzureProjectFeature
{
    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
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

        infrastructure.AddConstruct(subscription);

        EmitConnection(infrastructure, name, $"{parent.Name}/{name}");
        return subscription;
    }
}
