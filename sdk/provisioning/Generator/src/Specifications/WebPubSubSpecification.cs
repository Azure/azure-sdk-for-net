// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.ContainerRegistry;
using Azure.ResourceManager.WebPubSub;
using Azure.ResourceManager.WebPubSub.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class WebPubSubSpecification() :
    Specification("WebPubSub", typeof(WebPubSubExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<WebPubSubPrivateEndpointConnectionData>("ResourceType");
        RemoveProperty<WebPubSubSharedPrivateLinkData>("ResourceType");
        
        // Patch models
        CustomizeResource<WebPubSubResource>(r => r.Name = "WebPubSubService");
        CustomizeProperty<LiveTraceConfiguration>("IsEnabled", p => { p.Path = ["enabled"]; p.PropertyType = TypeRegistry.Get<string>(); });
        CustomizeProperty<LiveTraceConfiguration>("Categories", p => p.Path = ["categories"]);
        CustomizeProperty<LiveTraceCategory>("IsEnabled", p => { p.Path = ["enabled"]; p.PropertyType = TypeRegistry.Get<string>(); });
        CustomizeProperty<WebPubSubKeys>("PrimaryKey", p => p.IsSecure = true);
        CustomizeProperty<WebPubSubKeys>("SecondaryKey", p => p.IsSecure = true);
        CustomizeProperty<WebPubSubKeys>("PrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<WebPubSubKeys>("SecondaryConnectionString", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<WebPubSubResource>(min: 3, max: 63, lower: true, upper: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("WebPubSubServiceReader", "bfb1c7d2-fb1a-466b-b2ba-aee63b92deaf", "Read-only access to Azure Web PubSub Service REST APIs"));
        Roles.Add(new Role("WebPubSubServiceOwner", "12cf5a90-567b-43ae-8102-96cf46c7d9b4", "Full access to Azure Web PubSub Service REST APIs"));
        Roles.Add(new Role("WebPubSubContributor", "8cf5e20a-e4b2-4e9d-b3a1-5ceb692c2761", "Create, Read, Update, and Delete Web PubSub service resources"));

        // Assign Roles
        CustomizeResource<WebPubSubResource>(r => r.GenerateRoleAssignment = true);
    }
}
