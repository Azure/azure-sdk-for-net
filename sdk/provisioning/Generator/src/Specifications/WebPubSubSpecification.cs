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
    }
}
