// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects;

public class ServiceBusNamespaceFeature : AzureProjectFeature
{
    public ServiceBusNamespaceFeature(string namespaceName)
    {
        Name = namespaceName;
        Sku = ServiceBusSkuName.Standard;
        Tier = ServiceBusSkuTier.Standard;
    }

    public string Name { get; }
    public ServiceBusSkuName Sku { get; }
    public ServiceBusSkuTier Tier { get; }

    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        var sb = new ServiceBusNamespace("cm_servicebus")
        {
            Sku = new ServiceBusSku
            {
                Name = Sku,
                Tier = Tier
            },
            Name = Name,
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
