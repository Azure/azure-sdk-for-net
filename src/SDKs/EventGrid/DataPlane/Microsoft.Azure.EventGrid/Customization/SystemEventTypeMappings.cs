// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.EventGrid.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.EventGrid
{
    internal static class SystemEventTypeMappings
    {
        public static readonly IReadOnlyDictionary<String, Type> SystemEventMappings = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            // KEEP THIS SORTED BY THE NAME OF THE PUBLISHING SERVICE
            // Add handling for additional event types here.
            // NOTE: If any of the event data fields is polymorphic, remember to add an entry for the discriminator/BaseType
            // in EventGridSubscriber.GetJsonSerializerWithPolymorphicSupport()
            // Example: jsonSerializer.Converters.Add(new PolymorphicDeserializeJsonConverter<JobOutput>("@odata.type"));

            // ContainerRegistry events
            { EventTypes.ContainerRegistryImagePushedEvent, typeof(ContainerRegistryImagePushedEventData) },
            { EventTypes.ContainerRegistryImageDeletedEvent, typeof(ContainerRegistryImageDeletedEventData) },

            // IoTHub Device events
            { EventTypes.IoTHubDeviceCreatedEvent, typeof(IotHubDeviceCreatedEventData) },
            { EventTypes.IoTHubDeviceDeletedEvent, typeof(IotHubDeviceDeletedEventData) },
            { EventTypes.IoTHubDeviceConnectedEvent, typeof(IotHubDeviceConnectedEventData) },
            { EventTypes.IoTHubDeviceDisconnectedEvent, typeof(IotHubDeviceDisconnectedEventData) },

            // EventGrid events
            { EventTypes.EventGridSubscriptionValidationEvent, typeof(SubscriptionValidationEventData) },
            { EventTypes.EventGridSubscriptionDeletedEvent, typeof(SubscriptionDeletedEventData) },

            // Event Hub Events
            { EventTypes.EventHubCaptureFileCreatedEvent, typeof(EventHubCaptureFileCreatedEventData) },

            // Media Services events
            { EventTypes.MediaJobStateChangeEvent, typeof(MediaJobStateChangeEventData) },

            // Resource Manager (Azure Subscription/Resource Group) events
            { EventTypes.ResourceWriteSuccessEvent, typeof(ResourceWriteSuccessData) },
            { EventTypes.ResourceWriteFailureEvent, typeof(ResourceWriteFailureData) },
            { EventTypes.ResourceWriteCancelEvent, typeof(ResourceWriteCancelData) },
            { EventTypes.ResourceDeleteSuccessEvent, typeof(ResourceDeleteSuccessData) },
            { EventTypes.ResourceDeleteFailureEvent, typeof(ResourceDeleteFailureData) },
            { EventTypes.ResourceDeleteCancelEvent, typeof(ResourceDeleteCancelData) },
            { EventTypes.ResourceActionSuccessEvent, typeof(ResourceActionSuccessData) },
            { EventTypes.ResourceActionFailureEvent, typeof(ResourceActionFailureData) },
            { EventTypes.ResourceActionCancelEvent, typeof(ResourceActionCancelData) },

            // ServiceBus events
            { EventTypes.ServiceBusActiveMessagesAvailableWithNoListenersEvent, typeof(ServiceBusActiveMessagesAvailableWithNoListenersEventData) },
            { EventTypes.ServiceBusDeadletterMessagesAvailableWithNoListenerEvent, typeof(ServiceBusDeadletterMessagesAvailableWithNoListenersEventData) },

            // Storage events
            { EventTypes.StorageBlobCreatedEvent, typeof(StorageBlobCreatedEventData) },
            { EventTypes.StorageBlobDeletedEvent, typeof(StorageBlobDeletedEventData) },
        };
    }
}
