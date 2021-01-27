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
            { EventTypes.AppConfigurationKeyValueDeletedEvent, AppConfigurationKeyValueDeletedEventData.DeserializeAppConfigurationKeyValueDeletedEventData },
            { EventTypes.AppConfigurationKeyValueModifiedEvent, AppConfigurationKeyValueModifiedEventData.DeserializeAppConfigurationKeyValueModifiedEventData },

            // Communication events
            { EventTypes.ACSChatMemberAddedToThreadWithUserEvent, ACSChatMemberAddedToThreadWithUserEventData.DeserializeACSChatMemberAddedToThreadWithUserEventData },
            { EventTypes.ACSChatMemberRemovedFromThreadWithUserEvent, ACSChatMemberRemovedFromThreadWithUserEventData.DeserializeACSChatMemberRemovedFromThreadWithUserEventData },
            { EventTypes.ACSChatMessageDeletedEvent, ACSChatMessageDeletedEventData.DeserializeACSChatMessageDeletedEventData },
            { EventTypes.ACSChatMessageEditedEvent, ACSChatMessageEditedEventData.DeserializeACSChatMessageEditedEventData },
            { EventTypes.ACSChatMessageReceivedEvent, ACSChatMessageReceivedEventData.DeserializeACSChatMessageReceivedEventData },
            { EventTypes.ACSChatThreadCreatedWithUserEvent,  ACSChatThreadCreatedWithUserEventData.DeserializeACSChatThreadCreatedWithUserEventData },
            { EventTypes.ACSChatThreadPropertiesUpdatedPerUserEvent, ACSChatThreadPropertiesUpdatedPerUserEventData.DeserializeACSChatThreadPropertiesUpdatedPerUserEventData },
            { EventTypes.ACSChatThreadWithUserDeletedEvent, ACSChatThreadWithUserDeletedEventData.DeserializeACSChatThreadWithUserDeletedEventData },
            { EventTypes.ACSSMSDeliveryReportReceivedEvent, AcsSmsDeliveryReportReceivedEventData.DeserializeAcsSmsDeliveryReportReceivedEventData },
            { EventTypes.ACSSMSReceivedEvent, AcsSmsReceivedEventData.DeserializeAcsSmsReceivedEventData },

            // ContainerRegistry events
            { EventTypes.ContainerRegistryImagePushedEvent, ContainerRegistryImagePushedEventData.DeserializeContainerRegistryImagePushedEventData },
            { EventTypes.ContainerRegistryImageDeletedEvent, ContainerRegistryImageDeletedEventData.DeserializeContainerRegistryImageDeletedEventData },
            { EventTypes.ContainerRegistryChartDeletedEvent, ContainerRegistryChartDeletedEventData.DeserializeContainerRegistryChartDeletedEventData },
            { EventTypes.ContainerRegistryChartPushedEvent, ContainerRegistryChartPushedEventData.DeserializeContainerRegistryChartPushedEventData },

            // IoTHub Device events
            { EventTypes.IoTHubDeviceCreatedEvent, IotHubDeviceCreatedEventData.DeserializeIotHubDeviceCreatedEventData },
            { EventTypes.IoTHubDeviceDeletedEvent, IotHubDeviceDeletedEventData.DeserializeIotHubDeviceDeletedEventData },
            { EventTypes.IoTHubDeviceConnectedEvent, IotHubDeviceConnectedEventData.DeserializeIotHubDeviceConnectedEventData },
            { EventTypes.IoTHubDeviceDisconnectedEvent, IotHubDeviceDisconnectedEventData.DeserializeIotHubDeviceDisconnectedEventData },
            { EventTypes.IotHubDeviceTelemetryEvent, IotHubDeviceTelemetryEventData.DeserializeIotHubDeviceTelemetryEventData },

            // EventGrid events
            { EventTypes.EventGridSubscriptionValidationEvent, SubscriptionValidationEventData.DeserializeSubscriptionValidationEventData },
            { EventTypes.EventGridSubscriptionDeletedEvent, SubscriptionDeletedEventData.DeserializeSubscriptionDeletedEventData },

            // Event Hub events
            { EventTypes.EventHubCaptureFileCreatedEvent, EventHubCaptureFileCreatedEventData.DeserializeEventHubCaptureFileCreatedEventData },

            // Key Vault events
            { EventTypes.KeyVaultCertificateNewVersionCreatedEvent, KeyVaultCertificateNewVersionCreatedEventData.DeserializeKeyVaultCertificateNewVersionCreatedEventData },
            { EventTypes.KeyVaultCertificateNearExpiryEvent, KeyVaultCertificateNearExpiryEventData.DeserializeKeyVaultCertificateNearExpiryEventData },
            { EventTypes.KeyVaultCertificateExpiredEvent, KeyVaultCertificateExpiredEventData.DeserializeKeyVaultCertificateExpiredEventData },
            { EventTypes.KeyVaultKeyNearExpiryEvent, KeyVaultKeyNearExpiryEventData.DeserializeKeyVaultKeyNearExpiryEventData },
            { EventTypes.KeyVaultKeyNewVersionCreatedEvent, KeyVaultKeyNewVersionCreatedEventData.DeserializeKeyVaultKeyNewVersionCreatedEventData },
            { EventTypes.KeyVaultKeyExpiredEvent, KeyVaultKeyExpiredEventData.DeserializeKeyVaultKeyExpiredEventData },
            { EventTypes.KeyVaultSecretNewVersionCreatedEvent, KeyVaultSecretNewVersionCreatedEventData.DeserializeKeyVaultSecretNewVersionCreatedEventData },
            { EventTypes.KeyVaultSecretNearExpiryEvent, KeyVaultSecretNearExpiryEventData.DeserializeKeyVaultSecretNearExpiryEventData },
            { EventTypes.KeyVaultSecretExpiredEvent, KeyVaultSecretExpiredEventData.DeserializeKeyVaultSecretExpiredEventData },
            { EventTypes.KeyVaultVaultAccessPolicyChangedEvent, KeyVaultAccessPolicyChangedEventData.DeserializeKeyVaultAccessPolicyChangedEventData },

            // MachineLearningServices events
            { EventTypes.MachineLearningServicesDatasetDriftDetectedEvent, MachineLearningServicesDatasetDriftDetectedEventData.DeserializeMachineLearningServicesDatasetDriftDetectedEventData },
            { EventTypes.MachineLearningServicesModelDeployedEvent, MachineLearningServicesModelDeployedEventData.DeserializeMachineLearningServicesModelDeployedEventData },
            { EventTypes.MachineLearningServicesModelRegisteredEvent, MachineLearningServicesModelRegisteredEventData.DeserializeMachineLearningServicesModelRegisteredEventData },
            { EventTypes.MachineLearningServicesRunCompletedEvent, MachineLearningServicesRunCompletedEventData.DeserializeMachineLearningServicesRunCompletedEventData },
            { EventTypes.MachineLearningServicesRunStatusChangedEvent, MachineLearningServicesRunStatusChangedEventData.DeserializeMachineLearningServicesRunStatusChangedEventData },

            // Maps events
            { EventTypes.MapsGeofenceEnteredEvent, MapsGeofenceEnteredEventData.DeserializeMapsGeofenceEnteredEventData },
            { EventTypes.MapsGeofenceExitedEvent, MapsGeofenceExitedEventData.DeserializeMapsGeofenceExitedEventData },
            { EventTypes.MapsGeofenceResultEvent, MapsGeofenceResultEventData.DeserializeMapsGeofenceResultEventData },

            // Media Services events
            { EventTypes.MediaJobStateChangeEvent, MediaJobStateChangeEventData.DeserializeMediaJobStateChangeEventData },
            { EventTypes.MediaJobOutputStateChangeEvent, MediaJobOutputStateChangeEventData.DeserializeMediaJobOutputStateChangeEventData },
            { EventTypes.MediaJobScheduledEvent, MediaJobScheduledEventData.DeserializeMediaJobScheduledEventData },
            { EventTypes.MediaJobProcessingEvent, MediaJobProcessingEventData.DeserializeMediaJobProcessingEventData },
            { EventTypes.MediaJobCancelingEvent, MediaJobCancelingEventData.DeserializeMediaJobCancelingEventData },
            { EventTypes.MediaJobFinishedEvent, MediaJobFinishedEventData.DeserializeMediaJobFinishedEventData },
            { EventTypes.MediaJobCanceledEvent, MediaJobCanceledEventData.DeserializeMediaJobCanceledEventData },
            { EventTypes.MediaJobErroredEvent, MediaJobErroredEventData.DeserializeMediaJobErroredEventData },
            { EventTypes.MediaJobOutputCanceledEvent, MediaJobOutputCanceledEventData.DeserializeMediaJobOutputCanceledEventData },
            { EventTypes.MediaJobOutputCancelingEvent, MediaJobOutputCancelingEventData.DeserializeMediaJobOutputCancelingEventData },
            { EventTypes.MediaJobOutputErroredEvent, MediaJobOutputErroredEventData.DeserializeMediaJobOutputErroredEventData },
            { EventTypes.MediaJobOutputFinishedEvent, MediaJobOutputFinishedEventData.DeserializeMediaJobOutputFinishedEventData },
            { EventTypes.MediaJobOutputProcessingEvent, MediaJobOutputProcessingEventData.DeserializeMediaJobOutputProcessingEventData },
            { EventTypes.MediaJobOutputScheduledEvent, MediaJobOutputScheduledEventData.DeserializeMediaJobOutputScheduledEventData },
            { EventTypes.MediaJobOutputProgressEvent, MediaJobOutputProgressEventData.DeserializeMediaJobOutputProgressEventData },
            { EventTypes.MediaLiveEventEncoderConnectedEvent, MediaLiveEventEncoderConnectedEventData.DeserializeMediaLiveEventEncoderConnectedEventData },
            { EventTypes.MediaLiveEventConnectionRejectedEvent, MediaLiveEventConnectionRejectedEventData.DeserializeMediaLiveEventConnectionRejectedEventData },
            { EventTypes.MediaLiveEventEncoderDisconnectedEvent, MediaLiveEventEncoderDisconnectedEventData.DeserializeMediaLiveEventEncoderDisconnectedEventData },
            { EventTypes.MediaLiveEventIncomingStreamReceivedEvent, MediaLiveEventIncomingStreamReceivedEventData.DeserializeMediaLiveEventIncomingStreamReceivedEventData },
            { EventTypes.MediaLiveEventIncomingStreamsOutOfSyncEvent, MediaLiveEventIncomingStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData },
            { EventTypes.MediaLiveEventIncomingVideoStreamsOutOfSyncEvent, MediaLiveEventIncomingVideoStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData },
            { EventTypes.MediaLiveEventIncomingChunkDroppedEvent, MediaLiveEventIncomingDataChunkDroppedEventData.DeserializeMediaLiveEventIncomingDataChunkDroppedEventData },
            { EventTypes.MediaLiveEventIngestHeartbeatEvent, MediaLiveEventIngestHeartbeatEventData.DeserializeMediaLiveEventIngestHeartbeatEventData },
            { EventTypes.MediaLiveEventTrackDiscontinuityDetectedEvent, MediaLiveEventTrackDiscontinuityDetectedEventData.DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData },

            // Resource Manager (Azure Subscription/Resource Group) events
            { EventTypes.ResourceWriteSuccessEvent, ResourceWriteSuccessData.DeserializeResourceWriteSuccessData },
            { EventTypes.ResourceWriteFailureEvent, ResourceWriteFailureData.DeserializeResourceWriteFailureData },
            { EventTypes.ResourceWriteCancelEvent, ResourceWriteCancelData.DeserializeResourceWriteCancelData },
            { EventTypes.ResourceDeleteSuccessEvent, ResourceDeleteSuccessData.DeserializeResourceDeleteSuccessData },
            { EventTypes.ResourceDeleteFailureEvent, ResourceDeleteFailureData.DeserializeResourceDeleteFailureData },
            { EventTypes.ResourceDeleteCancelEvent, ResourceDeleteCancelData.DeserializeResourceDeleteCancelData },
            { EventTypes.ResourceActionSuccessEvent, ResourceActionSuccessData.DeserializeResourceActionSuccessData },
            { EventTypes.ResourceActionFailureEvent, ResourceActionFailureData.DeserializeResourceActionFailureData },
            { EventTypes.ResourceActionCancelEvent, ResourceActionCancelData.DeserializeResourceActionCancelData },

            // ServiceBus events
            { EventTypes.ServiceBusActiveMessagesAvailableWithNoListenersEvent, ServiceBusActiveMessagesAvailableWithNoListenersEventData.DeserializeServiceBusActiveMessagesAvailableWithNoListenersEventData },
            { EventTypes.ServiceBusDeadletterMessagesAvailableWithNoListenerEvent, ServiceBusDeadletterMessagesAvailableWithNoListenersEventData.DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData },

            // Storage events
            { EventTypes.StorageBlobCreatedEvent, StorageBlobCreatedEventData.DeserializeStorageBlobCreatedEventData },
            { EventTypes.StorageBlobDeletedEvent, StorageBlobDeletedEventData.DeserializeStorageBlobDeletedEventData },
            { EventTypes.StorageBlobRenamedEvent, StorageBlobRenamedEventData.DeserializeStorageBlobRenamedEventData },
            { EventTypes.StorageDirectoryCreatedEvent, StorageDirectoryCreatedEventData.DeserializeStorageDirectoryCreatedEventData },
            { EventTypes.StorageDirectoryDeletedEvent, StorageDirectoryDeletedEventData.DeserializeStorageDirectoryDeletedEventData },
            { EventTypes.StorageDirectoryRenamedEvent, StorageDirectoryRenamedEventData.DeserializeStorageDirectoryRenamedEventData },
            { EventTypes.StorageLifecyclePolicyCompletedEvent, StorageLifecyclePolicyCompletedEventData.DeserializeStorageLifecyclePolicyCompletedEventData },

            // App Service
            { EventTypes.WebAppUpdated, WebAppUpdatedEventData.DeserializeWebAppUpdatedEventData },
            { EventTypes.WebBackupOperationStarted, WebBackupOperationStartedEventData.DeserializeWebBackupOperationStartedEventData },
            { EventTypes.WebBackupOperationCompleted, WebBackupOperationCompletedEventData.DeserializeWebBackupOperationCompletedEventData },
            { EventTypes.WebBackupOperationFailed, WebBackupOperationFailedEventData.DeserializeWebBackupOperationFailedEventData },
            { EventTypes.WebRestoreOperationStarted, WebRestoreOperationStartedEventData.DeserializeWebRestoreOperationStartedEventData },
            { EventTypes.WebRestoreOperationCompleted, WebRestoreOperationCompletedEventData.DeserializeWebRestoreOperationCompletedEventData },
            { EventTypes.WebRestoreOperationFailed, WebRestoreOperationFailedEventData.DeserializeWebRestoreOperationFailedEventData },
            { EventTypes.WebSlotSwapStarted, WebSlotSwapStartedEventData.DeserializeWebSlotSwapStartedEventData },
            { EventTypes.WebSlotSwapCompleted, WebSlotSwapCompletedEventData.DeserializeWebSlotSwapCompletedEventData },
            { EventTypes.WebSlotSwapFailed, WebSlotSwapFailedEventData.DeserializeWebSlotSwapFailedEventData },
            { EventTypes.WebSlotSwapWithPreviewStarted, WebSlotSwapWithPreviewStartedEventData.DeserializeWebSlotSwapWithPreviewStartedEventData },
            { EventTypes.WebSlotSwapWithPreviewCancelled, WebSlotSwapWithPreviewCancelledEventData.DeserializeWebSlotSwapWithPreviewCancelledEventData },
            { EventTypes.WebAppServicePlanUpdated, WebAppServicePlanUpdatedEventData.DeserializeWebAppServicePlanUpdatedEventData }
        };
    }
}
