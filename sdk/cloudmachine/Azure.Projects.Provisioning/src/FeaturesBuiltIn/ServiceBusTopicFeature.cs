// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;
using System.ClientModel.Primitives;

namespace Azure.Projects.ServiceBus;

internal class ServiceBusTopicFeature : AzureProjectFeature
{
    public ServiceBusTopicFeature(string name, ServiceBusNamespaceFeature parent)
    {
        Name = name;
        _parent = parent;
    }

    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        var topic = new ServiceBusTopic(Name, "2021-11-01")
        {
            Name = Name,
            Parent = EnsureEmits<ServiceBusNamespace>(_parent),
            MaxMessageSizeInKilobytes = 256,
            DefaultMessageTimeToLive = TimeSpan.FromDays(14),
            RequiresDuplicateDetection = false,
            EnableBatchedOperations = true,
            SupportOrdering = true,
            Status = ServiceBusMessagingEntityStatus.Active
        };

        infrastructure.AddResource(topic);
        return topic;
    }

    protected internal override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
    {
        connections.Add(new ClientConnection(Name, Name));
    }

    /// <summary>
    /// The name of the topic.
    /// </summary>
    public string Name { get; }

    private ServiceBusNamespaceFeature _parent;
}
