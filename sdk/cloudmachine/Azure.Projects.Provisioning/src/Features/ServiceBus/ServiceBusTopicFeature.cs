// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects.ServiceBus;

internal class ServiceBusTopicFeature : AzureProjectFeature
{
    /// <summary>
    /// The name of the topic.
    /// </summary>
    public string Name { get; }

    private ServiceBusNamespaceFeature _parent;

    public ServiceBusTopicFeature(string name, ServiceBusNamespaceFeature parent)
    {
        Name = name;
        _parent = parent;
    }

    protected internal override void EmitResources(ProjectInfrastructure infrastructure)
    {
        ServiceBusNamespace serviceBusNamespace = infrastructure.GetConstruct<ServiceBusNamespace>(_parent.Id);
        var topic = new ServiceBusTopic(Name, "2021-11-01")
        {
            Name = Name,
            Parent = serviceBusNamespace,
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };

        infrastructure.AddConstruct(Id, topic);

        EmitConnection(infrastructure, Name, Name);
    }
}
