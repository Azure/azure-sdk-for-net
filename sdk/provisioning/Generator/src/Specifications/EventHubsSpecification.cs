// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.EventHubs;
using Azure.ResourceManager.EventHubs.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class EventHubsSpecification() :
    Specification("EventHubs", typeof(EventHubsExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<EventHubResource>("MessageRetentionInDays");
        RemoveProperty<EventHubsDisasterRecoveryResource>("Alias");
        RemoveProperty<EventHubsPrivateEndpointConnectionData>("ResourceType");

        // Patch models
        CustomizeSimpleModel<EventHubsThrottlingPolicy>(m => { m.DiscriminatorName = "type"; m.DiscriminatorValue = "ThrottlingPolicy"; });
        CustomizeProperty<EventHubsAccessKeys>("PrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<EventHubsAccessKeys>("SecondaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<EventHubsAccessKeys>("AliasPrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<EventHubsAccessKeys>("AliasSecondaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<EventHubsAccessKeys>("PrimaryKey", p => p.IsSecure = true);
        CustomizeProperty<EventHubsAccessKeys>("SecondaryKey", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<EventHubsClusterResource>(min: 6, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<EventHubsNamespaceResource>(min: 6, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<EventHubsNamespaceAuthorizationRuleResource>(min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<EventHubsDisasterRecoveryResource>(min: 6, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<EventHubsNamespaceResource>(min: 1, max: 256, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<EventHubAuthorizationRuleResource>(min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<EventHubsConsumerGroupResource>(min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);

        // Roles
        Roles.Add(new Role("AzureEventHubsDataOwner", "f526a384-b230-433a-b45c-95f59c4a2dec", "Allows for full access to Azure Event Hubs resources."));
        Roles.Add(new Role("AzureEventHubsDataReceiver", "a638d3c7-ab3a-418d-83e6-5f17a39d4fde", "Allows receive access to Azure Event Hubs resources."));
        Roles.Add(new Role("AzureEventHubsDataSender", "2b629674-e913-4c01-ae53-ef4638d8f975", "Allows send access to Azure Event Hubs resources."));
        Roles.Add(new Role("SchemaRegistryContributor", "5dffeca3-4936-4216-b2bc-10343a5abb25", "Read, write, and delete Schema Registry groups and schemas."));
        Roles.Add(new Role("SchemaRegistryReader", "2c56ea50-c6b3-40a6-83c0-9d98858bc7d2", "Read and list Schema Registry groups and schemas."));

        // Assign Roles
        CustomizeResource<EventHubsClusterResource>(r => r.GenerateRoleAssignment = true);
        CustomizeResource<EventHubsNamespaceResource>(r => r.GenerateRoleAssignment = true);
    }
}
