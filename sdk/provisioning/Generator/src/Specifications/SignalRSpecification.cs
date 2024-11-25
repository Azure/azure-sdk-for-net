// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Generator.Model;
using Azure.ResourceManager.SignalR;
using Azure.ResourceManager.SignalR.Models;

namespace Azure.Provisioning.Generator.Specifications;

public class SignalRSpecification() :
    Specification("SignalR", typeof(SignalRExtensions))
{
    protected override void Customize()
    {
        // Remove misfires
        RemoveProperty<SignalRPrivateEndpointConnectionData>("ResourceType");
        RemoveProperty<SignalRSharedPrivateLinkResourceData>("ResourceType");

        // Patch models
        CustomizeModel<SignalRResource>(m => m.Name = "SignalRService");
        CustomizeProperty<SignalRKeys>("PrimaryKey", p => p.IsSecure = true);
        CustomizeProperty<SignalRKeys>("SecondaryKey", p => p.IsSecure = true);
        CustomizeProperty<SignalRKeys>("PrimaryConnectionString", p => p.IsSecure = true);
        CustomizeProperty<SignalRKeys>("SecondaryConnectionString", p => p.IsSecure = true);

        // Naming requirements
        AddNameRequirements<SignalRResource>(min: 3, max: 63, lower: true, upper: true, digits: true, hyphen: true);

        // Roles
        Roles.Add(new Role("SignalRAccessKeyReader", "04165923-9d83-45d5-8227-78b77b0a687e", "Read SignalR Service Access Keys"));
        Roles.Add(new Role("SignalRAppServer", "420fcaa2-552c-430f-98ca-3264be4806c7", "Lets your app server access SignalR Service with AAD auth options."));
        Roles.Add(new Role("SignalRRestApiOwner", "fd53cd77-2268-407a-8f46-7e7863d0f521", "Full access to Azure SignalR Service REST APIs"));
        Roles.Add(new Role("SignalRRestApiReader", "ddde6b66-c0df-4114-a159-3618637b3035", "Read-only access to Azure SignalR Service REST APIs"));
        Roles.Add(new Role("SignalRServiceOwner", "7e4f1700-ea5a-4f59-8f37-079cfe29dce3", "Full access to Azure SignalR Service REST APIs"));
        Roles.Add(new Role("SignalRContributor", "8cf5e20a-e4b2-4e9d-b3a1-5ceb692c2761", "Create, Read, Update, and Delete SignalR service resources"));

        // Assign Roles
        CustomizeResource<SignalRResource>(r => r.GenerateRoleAssignment = true);
    }
}
