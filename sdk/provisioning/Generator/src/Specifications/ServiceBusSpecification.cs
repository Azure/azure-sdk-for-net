// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ServiceBus;
using Azure.ResourceManager.ServiceBus.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class ServiceBusSpecification() :
    Specification("ServiceBus", typeof(ServiceBusExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<MigrationConfigurationResource>("ConfigName");
        RemoveProperty<ServiceBusDisasterRecoveryResource>("Alias");
        RemoveProperty<ServiceBusPrivateEndpointConnectionData>("ResourceType");

        // Patch models
        CustomizeProperty<ServiceBusAccessKeys>("PrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<ServiceBusAccessKeys>("SecondaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<ServiceBusAccessKeys>("AliasPrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<ServiceBusAccessKeys>("AliasSecondaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<ServiceBusAccessKeys>("PrimaryKey", p => p.IsSecure = true);
        CustomizeProperty<ServiceBusAccessKeys>("SecondaryKey", p => p.IsSecure = true);

        // Set durations
        CustomizePropertyIsoDuration<ServiceBusSubscriptionResource>("LockDuration");
        CustomizePropertyIsoDuration<ServiceBusSubscriptionResource>("DefaultMessageTimeToLive");
        CustomizePropertyIsoDuration<ServiceBusSubscriptionResource>("DuplicateDetectionHistoryTimeWindow");
        CustomizePropertyIsoDuration<ServiceBusSubscriptionResource>("AutoDeleteOnIdle");
        CustomizePropertyIsoDuration<ServiceBusQueueResource>("LockDuration");
        CustomizePropertyIsoDuration<ServiceBusQueueResource>("DefaultMessageTimeToLive");
        CustomizePropertyIsoDuration<ServiceBusQueueResource>("DuplicateDetectionHistoryTimeWindow");
        CustomizePropertyIsoDuration<ServiceBusQueueResource>("AutoDeleteOnIdle");
        CustomizePropertyIsoDuration<ServiceBusTopicResource>("DefaultMessageTimeToLive");
        CustomizePropertyIsoDuration<ServiceBusTopicResource>("DuplicateDetectionHistoryTimeWindow");
        CustomizePropertyIsoDuration<ServiceBusTopicResource>("AutoDeleteOnIdle");
        
        // Naming requirements
        AddNameRequirements<ServiceBusNamespaceResource>(min: 6, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<ServiceBusNamespaceAuthorizationRuleResource>(min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ServiceBusDisasterRecoveryResource>(min: 6, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        CustomizeProperty<MigrationConfigurationResource>("Name", p => { p.GenerateDefaultValue = true; p.HideAccessors = true; }); // must be `$default`
        AddNameRequirements<ServiceBusQueueResource>(min: 1, max: 260, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true); // TODO: Slash
        AddNameRequirements<ServiceBusQueueAuthorizationRuleResource>(min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ServiceBusTopicResource>(min: 1, max: 260, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true); // TODO: Slashes
        AddNameRequirements<ServiceBusTopicAuthorizationRuleResource>(min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);
        AddNameRequirements<ServiceBusSubscriptionResource> (min: 1, max: 50, lower: true, upper: true, digits: true, hyphen: true, underscore: true, period: true);

        // Roles
        Roles.Add(new Role("AzureServiceBusDataOwner", "090c5cfd-751d-490a-894a-3ce6f1109419", "Allows for full access to Azure Service Bus resources."));
        Roles.Add(new Role("AzureServiceBusDataReceiver", "4f6d3b9b-027b-4f4c-9142-0e5a2a2247e0", "Allows for receive access to Azure Service Bus resources."));
        Roles.Add(new Role("AzureServiceBusDataSender", "69a216fc-b8fb-44d8-bc22-1f3c2cd27a39", "Allows for send access to Azure Service Bus resources."));

        // Assign Roles
        CustomizeResource<ServiceBusNamespaceResource>(r => r.GenerateRoleAssignment = true);
    }
}
