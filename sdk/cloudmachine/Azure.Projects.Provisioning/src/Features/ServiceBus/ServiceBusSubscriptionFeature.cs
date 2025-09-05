// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects;

internal class ServiceBusSubscriptionFeature : AzureProjectFeature
{
    private string _namespaceName;
    private string _topicName;

    public ServiceBusSubscriptionFeature(string namespaceName, string topicName, string name)
    {
        Name = name;
        _namespaceName = namespaceName;
        _topicName = topicName;
    }

    public string Name { get; }

    protected internal override void EmitFeatures(ProjectInfrastructure infrastructure)
    {
        FeatureCollection features = infrastructure.Features;

        string topidId = ServiceBusTopicFeature.CreateId(_namespaceName, _topicName);
        if (!features.TryGet(topidId, out ServiceBusTopicFeature? topic))
        {
            topic = new ServiceBusTopicFeature(_namespaceName, _topicName);
            features.Append(topic);
        }

        features.Append(this);
    }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        string topidId = ServiceBusTopicFeature.CreateId(_namespaceName, _topicName);
        ServiceBusTopic serviceBusTopic = infrastructure.GetConstruct<ServiceBusTopic>(topidId);

        var subscription = new ServiceBusSubscription(Name, ServiceBusSubscription.ResourceVersions.V2021_11_01)
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

        EmitConnection(infrastructure, Name, $"{_topicName}/{Name}");
    }
}
