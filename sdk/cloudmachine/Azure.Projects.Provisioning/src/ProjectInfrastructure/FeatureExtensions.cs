// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.ServiceBus;

namespace Azure.Projects;

public static class FeatureExtensions
{
    public static ServiceBusNamespaceFeature AddServiceBus(this ProjectInfrastructure infrastructure)
    {
        var sb = infrastructure.AddServiceBusNamespace();
        // Add core features
        var sbTopicDefault = infrastructure.AddFeature(new ServiceBusTopicFeature("cm_servicebus_default_topic", sb));
        infrastructure.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", sbTopicDefault));
        return sb;
    }

    // TDOO: get rid of this.
    public static ServiceBusNamespaceFeature AddServiceBusNamespace(this ProjectInfrastructure infrastructure)
    {
        if (!infrastructure.Features.TryGet(out ServiceBusNamespaceFeature? serviceBusNamespace))
        {
            serviceBusNamespace = new ServiceBusNamespaceFeature(infrastructure.ProjectId);
            infrastructure.AddFeature(serviceBusNamespace);
        }
        return serviceBusNamespace!;
    }
}
