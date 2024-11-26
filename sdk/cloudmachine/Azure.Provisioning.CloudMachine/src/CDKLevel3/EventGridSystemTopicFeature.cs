// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.EventGrid;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Resources;
using Azure.Provisioning.Storage;

namespace Azure.CloudMachine;

public class EventGridSystemTopicFeature(string topicName, CloudMachineFeature source) : CloudMachineFeature
{
    protected override ProvisionableResource EmitCore(CloudMachineInfrastructure infrastructure)
    {
        var topic = new SystemTopic("cm_eventgrid_topic", "2022-06-15")
        {
            TopicType = "Microsoft.Storage.StorageAccounts",
            Source = EnsureEmits<StorageAccount>(source).Id,
            Identity = new()
            {
                ManagedServiceIdentityType = ManagedServiceIdentityType.UserAssigned,
                UserAssignedIdentities = { { BicepFunction.Interpolate($"{infrastructure.Identity.Id}").Compile().ToString(), new UserAssignedIdentityDetails() } }
            },
            Name = topicName
        };

        infrastructure.AddResource(topic);

        Emitted = topic;
        return topic;
    }
}
