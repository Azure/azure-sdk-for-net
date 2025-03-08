// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq.Expressions;
using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects.ServiceBus;

public class ServiceBusNamespaceFeature(string name, ServiceBusSkuName sku = ServiceBusSkuName.Standard, ServiceBusSkuTier tier = ServiceBusSkuTier.Standard) : AzureProjectFeature
{
    protected internal override void EmitResources(ProjectInfrastructure infrastructure)
    {
        var sb = new ServiceBusNamespace("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = sku,
                Tier = tier
            },
            Name = name,
        };
        infrastructure.AddConstruct(Id, sb);

        infrastructure.AddConstruct(Id + "_rule",
            new ServiceBusNamespaceAuthorizationRule("cm_servicebus_auth_rule", "2021-11-01")
            {
                Parent = sb,
                Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
            }
        );

        infrastructure.AddSystemRole(
            sb,
            ServiceBusBuiltInRole.GetBuiltInRoleName(ServiceBusBuiltInRole.AzureServiceBusDataOwner),
            ServiceBusBuiltInRole.AzureServiceBusDataOwner.ToString()
        );

        EmitConnection(infrastructure,
            "Azure.Messaging.ServiceBus.ServiceBusClient",
            $"https://{infrastructure.ProjectId}.servicebus.windows.net/"
        );
    }
}
