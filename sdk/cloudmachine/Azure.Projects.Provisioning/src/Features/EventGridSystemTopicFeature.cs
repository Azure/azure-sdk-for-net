// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.Projects;

internal class EventGridSystemTopicFeature : AzureProjectFeature
{
    internal static string EventGridTopicVersion =>
        SystemTopic.ResourceVersions.V2022_06_15;

    public EventGridSystemTopicFeature(string topicName, StorageAccountFeature source, string topicType)
    {
        TopicName = topicName;
        TopicType = topicType;
        Source = source;
    }

    public string TopicName { get;  }
    public string TopicType { get; }
    public StorageAccountFeature Source { get; }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        StorageAccount storage = infrastructure.GetConstruct<StorageAccount>(Source.Id);

        var topic = new SystemTopic("cm_eventgrid_topic", EventGridTopicVersion)
        {
            TopicType = TopicType,
            Source = storage.Id,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            Name = TopicName
        };

        infrastructure.AddConstruct(Id, topic);
    }
}
