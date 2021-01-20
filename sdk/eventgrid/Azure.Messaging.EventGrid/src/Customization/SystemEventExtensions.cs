// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Messaging.EventGrid.SystemEvents;

namespace Azure.Messaging.EventGrid
{
    internal class SystemEventExtensions
    {
        public static object AsSystemEventData(string eventType, JsonElement data)
        {
            if (SystemEventDeserializers.TryGetValue(eventType, out Func<JsonElement, object> systemDeserializationFunction))
            {
                return systemDeserializationFunction(data);
            }
            else
            {
                return null;
            }
        }

        public static readonly IReadOnlyDictionary<string, Func<JsonElement, object>> SystemEventDeserializers = new Dictionary<string, Func<JsonElement, object>>(StringComparer.OrdinalIgnoreCase)
        {
            // KEEP THIS SORTED BY THE NAME OF THE PUBLISHING SERVICE
            // Add handling for additional event types here.

            // AppConfiguration events
            { SystemEventMappings.AppConfigurationKeyValueDeletedEvent, AppConfigurationKeyValueDeletedEventData.DeserializeAppConfigurationKeyValueDeletedEventData },
            { SystemEventMappings.AppConfigurationKeyValueModifiedEvent, AppConfigurationKeyValueModifiedEventData.DeserializeAppConfigurationKeyValueModifiedEventData },

            // Communication events
            { SystemEventMappings.ACSChatMemberAddedToThreadWithUserEvent, ACSChatMemberAddedToThreadWithUserEventData.DeserializeACSChatMemberAddedToThreadWithUserEventData },
            { SystemEventMappings.ACSChatMemberRemovedFromThreadWithUserEvent, ACSChatMemberRemovedFromThreadWithUserEventData.DeserializeACSChatMemberRemovedFromThreadWithUserEventData },
            { SystemEventMappings.ACSChatMessageDeletedEvent, ACSChatMessageDeletedEventData.DeserializeACSChatMessageDeletedEventData },
            { SystemEventMappings.ACSChatMessageEditedEvent, ACSChatMessageEditedEventData.DeserializeACSChatMessageEditedEventData },
            { SystemEventMappings.ACSChatMessageReceivedEvent, ACSChatMessageReceivedEventData.DeserializeACSChatMessageReceivedEventData },
            { SystemEventMappings.ACSChatThreadCreatedWithUserEvent,  ACSChatThreadCreatedWithUserEventData.DeserializeACSChatThreadCreatedWithUserEventData },
            { SystemEventMappings.ACSChatThreadPropertiesUpdatedPerUserEvent, ACSChatThreadPropertiesUpdatedPerUserEventData.DeserializeACSChatThreadPropertiesUpdatedPerUserEventData },
            { SystemEventMappings.ACSChatThreadWithUserDeletedEvent, ACSChatThreadWithUserDeletedEventData.DeserializeACSChatThreadWithUserDeletedEventData },
            { SystemEventMappings.ACSSMSDeliveryReportReceivedEvent, AcsSmsDeliveryReportReceivedEventData.DeserializeAcsSmsDeliveryReportReceivedEventData },
            { SystemEventMappings.ACSSMSReceivedEvent, AcsSmsReceivedEventData.DeserializeAcsSmsReceivedEventData },

            // ContainerRegistry events
            { SystemEventMappings.ContainerRegistryImagePushedEvent, ContainerRegistryImagePushedEventData.DeserializeContainerRegistryImagePushedEventData },
            { SystemEventMappings.ContainerRegistryImageDeletedEvent, ContainerRegistryImageDeletedEventData.DeserializeContainerRegistryImageDeletedEventData },
            { SystemEventMappings.ContainerRegistryChartDeletedEvent, ContainerRegistryChartDeletedEventData.DeserializeContainerRegistryChartDeletedEventData },
            { SystemEventMappings.ContainerRegistryChartPushedEvent, ContainerRegistryChartPushedEventData.DeserializeContainerRegistryChartPushedEventData },

            // IoTHub Device events
            { SystemEventMappings.IoTHubDeviceCreatedEvent, IotHubDeviceCreatedEventData.DeserializeIotHubDeviceCreatedEventData },
            { SystemEventMappings.IoTHubDeviceDeletedEvent, IotHubDeviceDeletedEventData.DeserializeIotHubDeviceDeletedEventData },
            { SystemEventMappings.IoTHubDeviceConnectedEvent, IotHubDeviceConnectedEventData.DeserializeIotHubDeviceConnectedEventData },
            { SystemEventMappings.IoTHubDeviceDisconnectedEvent, IotHubDeviceDisconnectedEventData.DeserializeIotHubDeviceDisconnectedEventData },
            { SystemEventMappings.IotHubDeviceTelemetryEvent, IotHubDeviceTelemetryEventData.DeserializeIotHubDeviceTelemetryEventData },

            // EventGrid events
            { SystemEventMappings.EventGridSubscriptionValidationEvent, SubscriptionValidationEventData.DeserializeSubscriptionValidationEventData },
            { SystemEventMappings.EventGridSubscriptionDeletedEvent, SubscriptionDeletedEventData.DeserializeSubscriptionDeletedEventData },

            // Event Hub events
            { SystemEventMappings.EventHubCaptureFileCreatedEvent, EventHubCaptureFileCreatedEventData.DeserializeEventHubCaptureFileCreatedEventData },

            // Key Vault events
            { SystemEventMappings.KeyVaultCertificateNewVersionCreatedEvent, KeyVaultCertificateNewVersionCreatedEventData.DeserializeKeyVaultCertificateNewVersionCreatedEventData },
            { SystemEventMappings.KeyVaultCertificateNearExpiryEvent, KeyVaultCertificateNearExpiryEventData.DeserializeKeyVaultCertificateNearExpiryEventData },
            { SystemEventMappings.KeyVaultCertificateExpiredEvent, KeyVaultCertificateExpiredEventData.DeserializeKeyVaultCertificateExpiredEventData },
            { SystemEventMappings.KeyVaultKeyNearExpiryEvent, KeyVaultKeyNearExpiryEventData.DeserializeKeyVaultKeyNearExpiryEventData },
            { SystemEventMappings.KeyVaultKeyNewVersionCreatedEvent, KeyVaultKeyNewVersionCreatedEventData.DeserializeKeyVaultKeyNewVersionCreatedEventData },
            { SystemEventMappings.KeyVaultKeyExpiredEvent, KeyVaultKeyExpiredEventData.DeserializeKeyVaultKeyExpiredEventData },
            { SystemEventMappings.KeyVaultSecretNewVersionCreatedEvent, KeyVaultSecretNewVersionCreatedEventData.DeserializeKeyVaultSecretNewVersionCreatedEventData },
            { SystemEventMappings.KeyVaultSecretNearExpiryEvent, KeyVaultSecretNearExpiryEventData.DeserializeKeyVaultSecretNearExpiryEventData },
            { SystemEventMappings.KeyVaultSecretExpiredEvent, KeyVaultSecretExpiredEventData.DeserializeKeyVaultSecretExpiredEventData },
            { SystemEventMappings.KeyVaultVaultAccessPolicyChangedEvent, KeyVaultAccessPolicyChangedEventData.DeserializeKeyVaultAccessPolicyChangedEventData },

            // MachineLearningServices events
            { SystemEventMappings.MachineLearningServicesDatasetDriftDetectedEvent, MachineLearningServicesDatasetDriftDetectedEventData.DeserializeMachineLearningServicesDatasetDriftDetectedEventData },
            { SystemEventMappings.MachineLearningServicesModelDeployedEvent, MachineLearningServicesModelDeployedEventData.DeserializeMachineLearningServicesModelDeployedEventData },
            { SystemEventMappings.MachineLearningServicesModelRegisteredEvent, MachineLearningServicesModelRegisteredEventData.DeserializeMachineLearningServicesModelRegisteredEventData },
            { SystemEventMappings.MachineLearningServicesRunCompletedEvent, MachineLearningServicesRunCompletedEventData.DeserializeMachineLearningServicesRunCompletedEventData },
            { SystemEventMappings.MachineLearningServicesRunStatusChangedEvent, MachineLearningServicesRunStatusChangedEventData.DeserializeMachineLearningServicesRunStatusChangedEventData },

            // Maps events
            { SystemEventMappings.MapsGeofenceEnteredEvent, MapsGeofenceEnteredEventData.DeserializeMapsGeofenceEnteredEventData },
            { SystemEventMappings.MapsGeofenceExitedEvent, MapsGeofenceExitedEventData.DeserializeMapsGeofenceExitedEventData },
            { SystemEventMappings.MapsGeofenceResultEvent, MapsGeofenceResultEventData.DeserializeMapsGeofenceResultEventData },

            // Media Services events
            { SystemEventMappings.MediaJobStateChangeEvent, MediaJobStateChangeEventData.DeserializeMediaJobStateChangeEventData },
            { SystemEventMappings.MediaJobOutputStateChangeEvent, MediaJobOutputStateChangeEventData.DeserializeMediaJobOutputStateChangeEventData },
            { SystemEventMappings.MediaJobScheduledEvent, MediaJobScheduledEventData.DeserializeMediaJobScheduledEventData },
            { SystemEventMappings.MediaJobProcessingEvent, MediaJobProcessingEventData.DeserializeMediaJobProcessingEventData },
            { SystemEventMappings.MediaJobCancelingEvent, MediaJobCancelingEventData.DeserializeMediaJobCancelingEventData },
            { SystemEventMappings.MediaJobFinishedEvent, MediaJobFinishedEventData.DeserializeMediaJobFinishedEventData },
            { SystemEventMappings.MediaJobCanceledEvent, MediaJobCanceledEventData.DeserializeMediaJobCanceledEventData },
            { SystemEventMappings.MediaJobErroredEvent, MediaJobErroredEventData.DeserializeMediaJobErroredEventData },
            { SystemEventMappings.MediaJobOutputCanceledEvent, MediaJobOutputCanceledEventData.DeserializeMediaJobOutputCanceledEventData },
            { SystemEventMappings.MediaJobOutputCancelingEvent, MediaJobOutputCancelingEventData.DeserializeMediaJobOutputCancelingEventData },
            { SystemEventMappings.MediaJobOutputErroredEvent, MediaJobOutputErroredEventData.DeserializeMediaJobOutputErroredEventData },
            { SystemEventMappings.MediaJobOutputFinishedEvent, MediaJobOutputFinishedEventData.DeserializeMediaJobOutputFinishedEventData },
            { SystemEventMappings.MediaJobOutputProcessingEvent, MediaJobOutputProcessingEventData.DeserializeMediaJobOutputProcessingEventData },
            { SystemEventMappings.MediaJobOutputScheduledEvent, MediaJobOutputScheduledEventData.DeserializeMediaJobOutputScheduledEventData },
            { SystemEventMappings.MediaJobOutputProgressEvent, MediaJobOutputProgressEventData.DeserializeMediaJobOutputProgressEventData },
            { SystemEventMappings.MediaLiveEventEncoderConnectedEvent, MediaLiveEventEncoderConnectedEventData.DeserializeMediaLiveEventEncoderConnectedEventData },
            { SystemEventMappings.MediaLiveEventConnectionRejectedEvent, MediaLiveEventConnectionRejectedEventData.DeserializeMediaLiveEventConnectionRejectedEventData },
            { SystemEventMappings.MediaLiveEventEncoderDisconnectedEvent, MediaLiveEventEncoderDisconnectedEventData.DeserializeMediaLiveEventEncoderDisconnectedEventData },
            { SystemEventMappings.MediaLiveEventIncomingStreamReceivedEvent, MediaLiveEventIncomingStreamReceivedEventData.DeserializeMediaLiveEventIncomingStreamReceivedEventData },
            { SystemEventMappings.MediaLiveEventIncomingStreamsOutOfSyncEvent, MediaLiveEventIncomingStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData },
            { SystemEventMappings.MediaLiveEventIncomingVideoStreamsOutOfSyncEvent, MediaLiveEventIncomingVideoStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData },
            { SystemEventMappings.MediaLiveEventIncomingChunkDroppedEvent, MediaLiveEventIncomingDataChunkDroppedEventData.DeserializeMediaLiveEventIncomingDataChunkDroppedEventData },
            { SystemEventMappings.MediaLiveEventIngestHeartbeatEvent, MediaLiveEventIngestHeartbeatEventData.DeserializeMediaLiveEventIngestHeartbeatEventData },
            { SystemEventMappings.MediaLiveEventTrackDiscontinuityDetectedEvent, MediaLiveEventTrackDiscontinuityDetectedEventData.DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData },

            // Resource Manager (Azure Subscription/Resource Group) events
            { SystemEventMappings.ResourceWriteSuccessEvent, ResourceWriteSuccessData.DeserializeResourceWriteSuccessData },
            { SystemEventMappings.ResourceWriteFailureEvent, ResourceWriteFailureData.DeserializeResourceWriteFailureData },
            { SystemEventMappings.ResourceWriteCancelEvent, ResourceWriteCancelData.DeserializeResourceWriteCancelData },
            { SystemEventMappings.ResourceDeleteSuccessEvent, ResourceDeleteSuccessData.DeserializeResourceDeleteSuccessData },
            { SystemEventMappings.ResourceDeleteFailureEvent, ResourceDeleteFailureData.DeserializeResourceDeleteFailureData },
            { SystemEventMappings.ResourceDeleteCancelEvent, ResourceDeleteCancelData.DeserializeResourceDeleteCancelData },
            { SystemEventMappings.ResourceActionSuccessEvent, ResourceActionSuccessData.DeserializeResourceActionSuccessData },
            { SystemEventMappings.ResourceActionFailureEvent, ResourceActionFailureData.DeserializeResourceActionFailureData },
            { SystemEventMappings.ResourceActionCancelEvent, ResourceActionCancelData.DeserializeResourceActionCancelData },

            // ServiceBus events
            { SystemEventMappings.ServiceBusActiveMessagesAvailableWithNoListenersEvent, ServiceBusActiveMessagesAvailableWithNoListenersEventData.DeserializeServiceBusActiveMessagesAvailableWithNoListenersEventData },
            { SystemEventMappings.ServiceBusDeadletterMessagesAvailableWithNoListenerEvent, ServiceBusDeadletterMessagesAvailableWithNoListenersEventData.DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData },

            // Storage events
            { SystemEventMappings.StorageBlobCreatedEvent, StorageBlobCreatedEventData.DeserializeStorageBlobCreatedEventData },
            { SystemEventMappings.StorageBlobDeletedEvent, StorageBlobDeletedEventData.DeserializeStorageBlobDeletedEventData },
            { SystemEventMappings.StorageBlobRenamedEvent, StorageBlobRenamedEventData.DeserializeStorageBlobRenamedEventData },
            { SystemEventMappings.StorageDirectoryCreatedEvent, StorageDirectoryCreatedEventData.DeserializeStorageDirectoryCreatedEventData },
            { SystemEventMappings.StorageDirectoryDeletedEvent, StorageDirectoryDeletedEventData.DeserializeStorageDirectoryDeletedEventData },
            { SystemEventMappings.StorageDirectoryRenamedEvent, StorageDirectoryRenamedEventData.DeserializeStorageDirectoryRenamedEventData },
            { SystemEventMappings.StorageLifecyclePolicyCompletedEvent, StorageLifecyclePolicyCompletedEventData.DeserializeStorageLifecyclePolicyCompletedEventData },

            // App Service
            { SystemEventMappings.WebAppUpdated, WebAppUpdatedEventData.DeserializeWebAppUpdatedEventData },
            { SystemEventMappings.WebBackupOperationStarted, WebBackupOperationStartedEventData.DeserializeWebBackupOperationStartedEventData },
            { SystemEventMappings.WebBackupOperationCompleted, WebBackupOperationCompletedEventData.DeserializeWebBackupOperationCompletedEventData },
            { SystemEventMappings.WebBackupOperationFailed, WebBackupOperationFailedEventData.DeserializeWebBackupOperationFailedEventData },
            { SystemEventMappings.WebRestoreOperationStarted, WebRestoreOperationStartedEventData.DeserializeWebRestoreOperationStartedEventData },
            { SystemEventMappings.WebRestoreOperationCompleted, WebRestoreOperationCompletedEventData.DeserializeWebRestoreOperationCompletedEventData },
            { SystemEventMappings.WebRestoreOperationFailed, WebRestoreOperationFailedEventData.DeserializeWebRestoreOperationFailedEventData },
            { SystemEventMappings.WebSlotSwapStarted, WebSlotSwapStartedEventData.DeserializeWebSlotSwapStartedEventData },
            { SystemEventMappings.WebSlotSwapCompleted, WebSlotSwapCompletedEventData.DeserializeWebSlotSwapCompletedEventData },
            { SystemEventMappings.WebSlotSwapFailed, WebSlotSwapFailedEventData.DeserializeWebSlotSwapFailedEventData },
            { SystemEventMappings.WebSlotSwapWithPreviewStarted, WebSlotSwapWithPreviewStartedEventData.DeserializeWebSlotSwapWithPreviewStartedEventData },
            { SystemEventMappings.WebSlotSwapWithPreviewCancelled, WebSlotSwapWithPreviewCancelledEventData.DeserializeWebSlotSwapWithPreviewCancelledEventData },
            { SystemEventMappings.WebAppServicePlanUpdated, WebAppServicePlanUpdatedEventData.DeserializeWebAppServicePlanUpdatedEventData }
        };
    }
}
