// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.Projects.EventGrid;

internal class EventGridSystemTopicFeature(string topicName, AzureProjectFeature source, string topicType) : AzureProjectFeature
{
    internal const string EventGridTopicVersion = "2022-06-15";

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        StorageAccount storage = infrastructure.GetConstruct<StorageAccount>(source.Id);

        var topic = new SystemTopic("cm_eventgrid_topic", EventGridTopicVersion)
        {
            TopicType = topicType,
            Source = storage.Id,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            Name = topicName
        };

        infrastructure.AddConstruct(Id, topic);
    }
}
