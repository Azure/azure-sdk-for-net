// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.Authorization;
using Azure.ResourceManager.EventGrid;
using Azure.ResourceManager.EventGrid.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class EventGridSpecification() :
    Specification("EventGrid", typeof(EventGridExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<EventGridPrivateEndpointConnectionData>("ResourceType");

        // Patch models
        CustomizeModel<EventGridNamespaceClientResource>(m => m.Name = "EventGridNamespaceClientResource");
        CustomizePropertyIsoDuration<QueueInfo>("EventTimeToLive");
        CustomizeEnum<EventGridPublicNetworkAccess>(e => { e.Values.Add(new EnumValue(e, "SecuredByPerimeter", "SecuredByPerimeter") { Hidden = true }); });
        CustomizeEnum<PartnerNamespaceChannelProvisioningState>(e => { e.Values.Add(new EnumValue(e, "IdleDueToMirroredPartnerDestinationDeletion", "IdleDueToMirroredPartnerDestinationDeletion") { Hidden = true }); });
        CustomizeEnum<PartnerNamespaceChannelType>(e => { e.Values.Add(new EnumValue(e, "PartnerDestination", "PartnerDestination") { Hidden = true }); });

        // Naming requirements
        AddNameRequirements<EventGridDomainResource>(min: 3, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<DomainTopicResource>(min: 3, max: 50, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<EventSubscriptionResource>(min: 3, max: 64, lower: true, upper: true, digits: true, hyphen: true);
        AddNameRequirements<EventGridTopicResource>(min: 3, max: 50, lower: true, upper: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("EventGridContributor", "1e241071-0855-49ea-94dc-649edcd759de", "Lets you manage EventGrid operations."));
        Roles.Add(new Role("EventGridDataSender", "d5a91429-5739-47e2-a06b-3470a27159e7", "Allows send access to event grid events."));
        Roles.Add(new Role("EventGridEventSubscriptionContributor", "428e0ff0-5e57-4d9c-a221-2c70d0e0a443", "Lets you manage EventGrid event subscription operations."));
        Roles.Add(new Role("EventGridEventSubscriptionReader", "2414bbcf-6497-4faf-8c65-045460748405", "Lets you read EventGrid event subscriptions."));
    }
}
