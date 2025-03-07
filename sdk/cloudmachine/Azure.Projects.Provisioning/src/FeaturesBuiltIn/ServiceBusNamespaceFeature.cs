// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Projects.Core;
using Azure.Core;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.ServiceBus;
using System.ClientModel.Primitives;

namespace Azure.Projects.ServiceBus;

public class ServiceBusNamespaceFeature(string name, ServiceBusSkuName sku = ServiceBusSkuName.Standard, ServiceBusSkuTier tier = ServiceBusSkuTier.Standard) : AzureProjectFeature
{
    protected override ProvisionableResource EmitResources(ProjectInfrastructure infrastructure)
    {
        var _serviceBusNamespace = new ServiceBusNamespace("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = sku,
                Tier = tier
            },
            Name = name,
        };
        infrastructure.AddResource(_serviceBusNamespace);
        infrastructure.AddResource(
            new ServiceBusNamespaceAuthorizationRule("cm_servicebus_auth_rule", "2021-11-01")
            {
                Parent = _serviceBusNamespace,
                Rights = [ServiceBusAccessRight.Listen, ServiceBusAccessRight.Send, ServiceBusAccessRight.Manage]
            }
        );

        FeatureRole dataOwner = new(
            ServiceBusBuiltInRole.GetBuiltInRoleName(ServiceBusBuiltInRole.AzureServiceBusDataOwner),
            ServiceBusBuiltInRole.AzureServiceBusDataOwner.ToString()
        );
        RequiredSystemRoles.Add(_serviceBusNamespace, [dataOwner]);

        return _serviceBusNamespace;
    }

    protected internal override void EmitConnections(ICollection<ClientConnection> connections, string cmId)
        => connections.Add(ProjectConnections.CreateDefaultServiceBusConnection(cmId));
}
