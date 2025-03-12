// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects.ServiceBus;

namespace Azure.Projects;

public static class FeatureExtensions
{
    public static void AddServiceBus(this ProjectInfrastructure infrastructure)
    {
        ServiceBusTopicFeature topic = new(infrastructure.ProjectId, "cm_servicebus_default_topic");
        infrastructure.AddFeature(topic);
        infrastructure.AddFeature(new ServiceBusSubscriptionFeature("cm_servicebus_subscription_default", topic));
    }
}
