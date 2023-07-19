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

            // AppConfiguration events
            { EventTypes.AppConfigurationKeyValueDeletedEvent, typeof(AppConfigurationKeyValueDeletedEventData) },
            { EventTypes.AppConfigurationKeyValueModifiedEvent, typeof(AppConfigurationKeyValueModifiedEventData) },

            // ContainerRegistry events
            { EventTypes.ContainerRegistryImagePushedEvent, typeof(ContainerRegistryImagePushedEventData) },
            { EventTypes.ContainerRegistryImageDeletedEvent, typeof(ContainerRegistryImageDeletedEventData) },
            { EventTypes.ContainerRegistryChartDeletedEvent, typeof(ContainerRegistryChartDeletedEventData) },
            { EventTypes.ContainerRegistryChartPushedEvent, typeof(ContainerRegistryChartPushedEventData) },

            // IoTHub Device events
            { EventTypes.IoTHubDeviceCreatedEvent, typeof(IotHubDeviceCreatedEventData) },
            { EventTypes.IoTHubDeviceDeletedEvent, typeof(IotHubDeviceDeletedEventData) },
            { EventTypes.IoTHubDeviceConnectedEvent, typeof(IotHubDeviceConnectedEventData) },
            { EventTypes.IoTHubDeviceDisconnectedEvent, typeof(IotHubDeviceDisconnectedEventData) },
            { EventTypes.IotHubDeviceTelemetryEvent, typeof(IotHubDeviceTelemetryEventData) },

            // EventGrid events
            { EventTypes.EventGridSubscriptionValidationEvent, typeof(SubscriptionValidationEventData) },
            { EventTypes.EventGridSubscriptionDeletedEvent, typeof(SubscriptionDeletedEventData) },

            // Event Hub events
            { EventTypes.EventHubCaptureFileCreatedEvent, typeof(EventHubCaptureFileCreatedEventData) },

            // MachineLearningServices events
            { EventTypes.MachineLearningServicesDatasetDriftDetectedEvent, typeof(MachineLearningServicesDatasetDriftDetectedEventData) },
            { EventTypes.MachineLearningServicesModelDeployedEvent, typeof(MachineLearningServicesModelDeployedEventData) },
            { EventTypes.MachineLearningServicesModelRegisteredEvent, typeof(MachineLearningServicesModelRegisteredEventData) },
            { EventTypes.MachineLearningServicesRunCompletedEvent, typeof(MachineLearningServicesRunCompletedEventData) },
            { EventTypes.MachineLearningServicesRunStatusChangedEvent, typeof(MachineLearningServicesRunStatusChangedEventData) },

            // Maps events
            { EventTypes.MapsGeofenceEnteredEvent, typeof(MapsGeofenceEnteredEventData) },
            { EventTypes.MapsGeofenceExitedEvent, typeof(MapsGeofenceExitedEventData) },
            { EventTypes.MapsGeofenceResultEvent, typeof(MapsGeofenceResultEventData) },

            // Media Services events
            { EventTypes.MediaJobStateChangeEvent, typeof(MediaJobStateChangeEventData) },
            { EventTypes.MediaJobOutputStateChangeEvent, typeof(MediaJobOutputStateChangeEventData) },
            { EventTypes.MediaJobScheduledEvent, typeof(MediaJobScheduledEventData) },
            { EventTypes.MediaJobProcessingEvent, typeof(MediaJobProcessingEventData) },
            { EventTypes.MediaJobCancelingEvent, typeof(MediaJobCancelingEventData) },
            { EventTypes.MediaJobFinishedEvent, typeof(MediaJobFinishedEventData) },
            { EventTypes.MediaJobCanceledEvent, typeof(MediaJobCanceledEventData) },
            { EventTypes.MediaJobErroredEvent, typeof(MediaJobErroredEventData) },
            { EventTypes.MediaJobOutputCanceledEvent, typeof(MediaJobOutputCanceledEventData) },
            { EventTypes.MediaJobOutputCancelingEvent, typeof(MediaJobOutputCancelingEventData) },
            { EventTypes.MediaJobOutputErroredEvent, typeof(MediaJobOutputErroredEventData) },
            { EventTypes.MediaJobOutputFinishedEvent, typeof(MediaJobOutputFinishedEventData) },
            { EventTypes.MediaJobOutputProcessingEvent, typeof(MediaJobOutputProcessingEventData) },
            { EventTypes.MediaJobOutputScheduledEvent, typeof(MediaJobOutputScheduledEventData) },
            { EventTypes.MediaJobOutputProgressEvent, typeof(MediaJobOutputProgressEventData) },
            { EventTypes.MediaLiveEventEncoderConnectedEvent, typeof(MediaLiveEventEncoderConnectedEventData) },
            { EventTypes.MediaLiveEventConnectionRejectedEvent, typeof(MediaLiveEventConnectionRejectedEventData) },
            { EventTypes.MediaLiveEventEncoderDisconnectedEvent, typeof(MediaLiveEventEncoderDisconnectedEventData) },
            { EventTypes.MediaLiveEventIncomingStreamReceivedEvent, typeof(MediaLiveEventIncomingStreamReceivedEventData) },
            { EventTypes.MediaLiveEventIncomingStreamsOutOfSyncEvent, typeof(MediaLiveEventIncomingStreamsOutOfSyncEventData) },
            { EventTypes.MediaLiveEventIncomingVideoStreamsOutOfSyncEvent, typeof(MediaLiveEventIncomingVideoStreamsOutOfSyncEventData) },
            { EventTypes.MediaLiveEventIncomingChunkDroppedEvent, typeof(MediaLiveEventIncomingDataChunkDroppedEventData) },
            { EventTypes.MediaLiveEventIngestHeartbeatEvent, typeof(MediaLiveEventIngestHeartbeatEventData) },
            { EventTypes.MediaLiveEventTrackDiscontinuityDetectedEvent, typeof(MediaLiveEventTrackDiscontinuityDetectedEventData) },

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
            { EventTypes.StorageBlobRenamedEvent, typeof(StorageBlobRenamedEventData) },
            { EventTypes.StorageDirectoryCreatedEvent, typeof(StorageDirectoryCreatedEventData) },
            { EventTypes.StorageDirectoryDeletedEvent, typeof(StorageDirectoryDeletedEventData) },
            { EventTypes.StorageDirectoryRenamedEvent, typeof(StorageDirectoryRenamedEventData) },

            // App Service
            { EventTypes.WebAppUpdated, typeof(WebAppUpdatedEventData) },
            { EventTypes.WebBackupOperationStarted, typeof(WebBackupOperationStartedEventData) },
            { EventTypes.WebBackupOperationCompleted, typeof(WebBackupOperationCompletedEventData) },
            { EventTypes.WebBackupOperationFailed, typeof(WebBackupOperationFailedEventData) },
            { EventTypes.WebRestoreOperationStarted, typeof(WebRestoreOperationStartedEventData) },
            { EventTypes.WebRestoreOperationCompleted, typeof(WebRestoreOperationCompletedEventData) },
            { EventTypes.WebRestoreOperationFailed, typeof(WebRestoreOperationFailedEventData) },
            { EventTypes.WebSlotSwapStarted, typeof(WebSlotSwapStartedEventData) },
            { EventTypes.WebSlotSwapCompleted, typeof(WebSlotSwapCompletedEventData) },
            { EventTypes.WebSlotSwapFailed, typeof(WebSlotSwapFailedEventData) },
            { EventTypes.WebSlotSwapWithPreviewStarted, typeof(WebSlotSwapWithPreviewStartedEventData) },
            { EventTypes.WebSlotSwapWithPreviewCancelled, typeof(WebSlotSwapWithPreviewCancelledEventData) },
            { EventTypes.WebAppServicePlanUpdated, typeof(WebAppServicePlanUpdatedEventData) }
        };
    }
}
