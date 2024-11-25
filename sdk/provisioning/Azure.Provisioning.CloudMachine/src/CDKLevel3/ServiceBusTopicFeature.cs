// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;

namespace Azure.CloudMachine;

public class ServiceBusTopicFeature(string name, ServiceBusNamespaceFeature parent) : CloudMachineFeature
{
    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure infrastructure)
    {
        var topic = new ServiceBusTopic(name, "2021-11-01")
        {
            Name = name,
            Parent = ValidateIsOfType<ServiceBusNamespace>(parent),
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };

        infrastructure.AddResource(topic);
        Emitted = topic;
        return topic;
    }
}
