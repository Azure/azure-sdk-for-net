// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects;

internal class ServiceBusTopicFeature : AzureProjectFeature
{
    /// <summary>
    /// The name of the topic.
    /// </summary>
    public string Name { get; }

    private string _namespaceName;

    private ServiceBusNamespaceFeature? _namespace;

    public ServiceBusTopicFeature(string namespaceName, string topicName)
        : base(CreateId(namespaceName, topicName))
    {
        Name = topicName;
        _namespaceName = namespaceName;
    }

    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;

        if (!features.TryGet(out _namespace))
        {
            _namespace = new ServiceBusNamespaceFeature(_namespaceName);
            features.Append(_namespace);
        }

        features.Append(this);
    }
    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        ServiceBusNamespace serviceBusNamespace = infrastructure.GetConstruct<ServiceBusNamespace>(_namespace!.Id);
        var topic = new ServiceBusTopic(Name, ServiceBusTopic.ResourceVersions.V2021_11_01)
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

    public override string ToString() => CreateId(_namespaceName, Name);
    public static string CreateId(string namespaceName, string topicName) => $"{nameof(ServiceBusTopicFeature)}{namespaceName}/{topicName}";
}
