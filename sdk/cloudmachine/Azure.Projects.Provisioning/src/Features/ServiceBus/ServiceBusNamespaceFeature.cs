// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.Core;
using Azure.Provisioning.ServiceBus;

namespace Azure.Projects;

/// <summary>
/// Represents a provisioning feature that emits an Azure Service Bus namespace resource.
/// </summary>
public class ServiceBusNamespaceFeature : AzureProjectFeature
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceBusNamespaceFeature"/> class.
    /// </summary>
    /// <param name="namespaceName">The name of the Service Bus namespace.</param>
    public ServiceBusNamespaceFeature(string namespaceName)
    {
        Name = namespaceName;
        Sku = ServiceBusSkuName.Standard;
        Tier = ServiceBusSkuTier.Standard;
    }

    /// <summary>
    /// Gets the name of the Service Bus namespace.
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// Gets the SKU name for the Service Bus namespace.
    /// </summary>
    public ServiceBusSkuName Sku { get; }
    /// <summary>
    /// Gets the SKU tier for the Service Bus namespace.
    /// </summary>
    public ServiceBusSkuTier Tier { get; }

    /// <summary>
    /// Emits the provisioning constructs for the Service Bus namespace into the specified infrastructure.
    /// </summary>
    /// <param name="infrastructure">The project infrastructure to emit constructs into.</param>
    protected internal override void EmitConstructs(ProjectInfrastructure infrastructure)
    {
        var sb = new ServiceBusNamespace("cm_servicebus", ServiceBusNamespace.ResourceVersions.V2024_01_01)
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
            new ServiceBusNamespaceAuthorizationRule("cm_servicebus_auth_rule", ServiceBusNamespaceAuthorizationRule.ResourceVersions.V2021_11_01)
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
