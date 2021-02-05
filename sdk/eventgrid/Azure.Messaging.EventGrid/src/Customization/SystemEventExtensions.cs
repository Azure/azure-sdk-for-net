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
            { SystemEventNames.AppConfigurationKeyValueDeleted, AppConfigurationKeyValueDeletedEventData.DeserializeAppConfigurationKeyValueDeletedEventData },
            { SystemEventNames.AppConfigurationKeyValueModified, AppConfigurationKeyValueModifiedEventData.DeserializeAppConfigurationKeyValueModifiedEventData },

            // Communication events
            { SystemEventNames.ACSChatMemberAddedToThreadWithUser, ACSChatMemberAddedToThreadWithUserEventData.DeserializeACSChatMemberAddedToThreadWithUserEventData },
            { SystemEventNames.ACSChatMemberRemovedFromThreadWithUser, ACSChatMemberRemovedFromThreadWithUserEventData.DeserializeACSChatMemberRemovedFromThreadWithUserEventData },
            { SystemEventNames.ACSChatMessageDeleted, ACSChatMessageDeletedEventData.DeserializeACSChatMessageDeletedEventData },
            { SystemEventNames.ACSChatMessageEdited, ACSChatMessageEditedEventData.DeserializeACSChatMessageEditedEventData },
            { SystemEventNames.ACSChatMessageReceived, ACSChatMessageReceivedEventData.DeserializeACSChatMessageReceivedEventData },
            { SystemEventNames.ACSChatThreadCreatedWithUser,  ACSChatThreadCreatedWithUserEventData.DeserializeACSChatThreadCreatedWithUserEventData },
            { SystemEventNames.ACSChatThreadPropertiesUpdatedPerUser, ACSChatThreadPropertiesUpdatedPerUserEventData.DeserializeACSChatThreadPropertiesUpdatedPerUserEventData },
            { SystemEventNames.ACSChatThreadWithUserDeleted, ACSChatThreadWithUserDeletedEventData.DeserializeACSChatThreadWithUserDeletedEventData },
            { SystemEventNames.ACSSMSDeliveryReportReceived, AcsSmsDeliveryReportReceivedEventData.DeserializeAcsSmsDeliveryReportReceivedEventData },
            { SystemEventNames.ACSSMSReceived, AcsSmsReceivedEventData.DeserializeAcsSmsReceivedEventData },

            // ContainerRegistry events
            { SystemEventNames.ContainerRegistryImagePushed, ContainerRegistryImagePushedEventData.DeserializeContainerRegistryImagePushedEventData },
            { SystemEventNames.ContainerRegistryImageDeleted, ContainerRegistryImageDeletedEventData.DeserializeContainerRegistryImageDeletedEventData },
            { SystemEventNames.ContainerRegistryChartDeleted, ContainerRegistryChartDeletedEventData.DeserializeContainerRegistryChartDeletedEventData },
            { SystemEventNames.ContainerRegistryChartPushed, ContainerRegistryChartPushedEventData.DeserializeContainerRegistryChartPushedEventData },

            // IoTHub Device events
            { SystemEventNames.IoTHubDeviceCreated, IotHubDeviceCreatedEventData.DeserializeIotHubDeviceCreatedEventData },
            { SystemEventNames.IoTHubDeviceDeleted, IotHubDeviceDeletedEventData.DeserializeIotHubDeviceDeletedEventData },
            { SystemEventNames.IoTHubDeviceConnected, IotHubDeviceConnectedEventData.DeserializeIotHubDeviceConnectedEventData },
            { SystemEventNames.IoTHubDeviceDisconnected, IotHubDeviceDisconnectedEventData.DeserializeIotHubDeviceDisconnectedEventData },
            { SystemEventNames.IotHubDeviceTelemetry, IotHubDeviceTelemetryEventData.DeserializeIotHubDeviceTelemetryEventData },

            // EventGrid events
            { SystemEventNames.EventGridSubscriptionValidation, SubscriptionValidationEventData.DeserializeSubscriptionValidationEventData },
            { SystemEventNames.EventGridSubscriptionDeleted, SubscriptionDeletedEventData.DeserializeSubscriptionDeletedEventData },

            // Event Hub events
            { SystemEventNames.EventHubCaptureFileCreated, EventHubCaptureFileCreatedEventData.DeserializeEventHubCaptureFileCreatedEventData },

            // Key Vault events
            { SystemEventNames.KeyVaultCertificateNewVersionCreated, KeyVaultCertificateNewVersionCreatedEventData.DeserializeKeyVaultCertificateNewVersionCreatedEventData },
            { SystemEventNames.KeyVaultCertificateNearExpiry, KeyVaultCertificateNearExpiryEventData.DeserializeKeyVaultCertificateNearExpiryEventData },
            { SystemEventNames.KeyVaultCertificateExpired, KeyVaultCertificateExpiredEventData.DeserializeKeyVaultCertificateExpiredEventData },
            { SystemEventNames.KeyVaultKeyNearExpiry, KeyVaultKeyNearExpiryEventData.DeserializeKeyVaultKeyNearExpiryEventData },
            { SystemEventNames.KeyVaultKeyNewVersionCreated, KeyVaultKeyNewVersionCreatedEventData.DeserializeKeyVaultKeyNewVersionCreatedEventData },
            { SystemEventNames.KeyVaultKeyExpired, KeyVaultKeyExpiredEventData.DeserializeKeyVaultKeyExpiredEventData },
            { SystemEventNames.KeyVaultSecretNewVersionCreated, KeyVaultSecretNewVersionCreatedEventData.DeserializeKeyVaultSecretNewVersionCreatedEventData },
            { SystemEventNames.KeyVaultSecretNearExpiry, KeyVaultSecretNearExpiryEventData.DeserializeKeyVaultSecretNearExpiryEventData },
            { SystemEventNames.KeyVaultSecretExpired, KeyVaultSecretExpiredEventData.DeserializeKeyVaultSecretExpiredEventData },
            { SystemEventNames.KeyVaultAccessPolicyChanged, KeyVaultAccessPolicyChangedEventData.DeserializeKeyVaultAccessPolicyChangedEventData },

            // MachineLearningServices events
            { SystemEventNames.MachineLearningServicesDatasetDriftDetected, MachineLearningServicesDatasetDriftDetectedEventData.DeserializeMachineLearningServicesDatasetDriftDetectedEventData },
            { SystemEventNames.MachineLearningServicesModelDeployed, MachineLearningServicesModelDeployedEventData.DeserializeMachineLearningServicesModelDeployedEventData },
            { SystemEventNames.MachineLearningServicesModelRegistered, MachineLearningServicesModelRegisteredEventData.DeserializeMachineLearningServicesModelRegisteredEventData },
            { SystemEventNames.MachineLearningServicesRunCompleted, MachineLearningServicesRunCompletedEventData.DeserializeMachineLearningServicesRunCompletedEventData },
            { SystemEventNames.MachineLearningServicesRunStatusChanged, MachineLearningServicesRunStatusChangedEventData.DeserializeMachineLearningServicesRunStatusChangedEventData },

            // Maps events
            { SystemEventNames.MapsGeofenceEntered, MapsGeofenceEnteredEventData.DeserializeMapsGeofenceEnteredEventData },
            { SystemEventNames.MapsGeofenceExited, MapsGeofenceExitedEventData.DeserializeMapsGeofenceExitedEventData },
            { SystemEventNames.MapsGeofenceResult, MapsGeofenceResultEventData.DeserializeMapsGeofenceResultEventData },

            // Media Services events
            { SystemEventNames.MediaJobStateChange, MediaJobStateChangeEventData.DeserializeMediaJobStateChangeEventData },
            { SystemEventNames.MediaJobOutputStateChange, MediaJobOutputStateChangeEventData.DeserializeMediaJobOutputStateChangeEventData },
            { SystemEventNames.MediaJobScheduled, MediaJobScheduledEventData.DeserializeMediaJobScheduledEventData },
            { SystemEventNames.MediaJobProcessing, MediaJobProcessingEventData.DeserializeMediaJobProcessingEventData },
            { SystemEventNames.MediaJobCanceling, MediaJobCancelingEventData.DeserializeMediaJobCancelingEventData },
            { SystemEventNames.MediaJobFinished, MediaJobFinishedEventData.DeserializeMediaJobFinishedEventData },
            { SystemEventNames.MediaJobCanceled, MediaJobCanceledEventData.DeserializeMediaJobCanceledEventData },
            { SystemEventNames.MediaJobErrored, MediaJobErroredEventData.DeserializeMediaJobErroredEventData },
            { SystemEventNames.MediaJobOutputCanceled, MediaJobOutputCanceledEventData.DeserializeMediaJobOutputCanceledEventData },
            { SystemEventNames.MediaJobOutputCanceling, MediaJobOutputCancelingEventData.DeserializeMediaJobOutputCancelingEventData },
            { SystemEventNames.MediaJobOutputErrored, MediaJobOutputErroredEventData.DeserializeMediaJobOutputErroredEventData },
            { SystemEventNames.MediaJobOutputFinished, MediaJobOutputFinishedEventData.DeserializeMediaJobOutputFinishedEventData },
            { SystemEventNames.MediaJobOutputProcessing, MediaJobOutputProcessingEventData.DeserializeMediaJobOutputProcessingEventData },
            { SystemEventNames.MediaJobOutputScheduled, MediaJobOutputScheduledEventData.DeserializeMediaJobOutputScheduledEventData },
            { SystemEventNames.MediaJobOutputProgress, MediaJobOutputProgressEventData.DeserializeMediaJobOutputProgressEventData },
            { SystemEventNames.MediaLiveEventEncoderConnected, MediaLiveEventEncoderConnectedEventData.DeserializeMediaLiveEventEncoderConnectedEventData },
            { SystemEventNames.MediaLiveEventConnectionRejected, MediaLiveEventConnectionRejectedEventData.DeserializeMediaLiveEventConnectionRejectedEventData },
            { SystemEventNames.MediaLiveEventEncoderDisconnected, MediaLiveEventEncoderDisconnectedEventData.DeserializeMediaLiveEventEncoderDisconnectedEventData },
            { SystemEventNames.MediaLiveEventIncomingStreamReceived, MediaLiveEventIncomingStreamReceivedEventData.DeserializeMediaLiveEventIncomingStreamReceivedEventData },
            { SystemEventNames.MediaLiveEventIncomingStreamsOutOfSync, MediaLiveEventIncomingStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData },
            { SystemEventNames.MediaLiveEventIncomingVideoStreamsOutOfSync, MediaLiveEventIncomingVideoStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData },
            { SystemEventNames.MediaLiveEventIncomingDataChunkDropped, MediaLiveEventIncomingDataChunkDroppedEventData.DeserializeMediaLiveEventIncomingDataChunkDroppedEventData },
            { SystemEventNames.MediaLiveEventIngestHeartbeat, MediaLiveEventIngestHeartbeatEventData.DeserializeMediaLiveEventIngestHeartbeatEventData },
            { SystemEventNames.MediaLiveEventTrackDiscontinuityDetected, MediaLiveEventTrackDiscontinuityDetectedEventData.DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData },

            // Resource Manager (Azure Subscription/Resource Group) events
            { SystemEventNames.ResourceWriteSuccess, ResourceWriteSuccessData.DeserializeResourceWriteSuccessData },
            { SystemEventNames.ResourceWriteFailure, ResourceWriteFailureData.DeserializeResourceWriteFailureData },
            { SystemEventNames.ResourceWriteCancel, ResourceWriteCancelData.DeserializeResourceWriteCancelData },
            { SystemEventNames.ResourceDeleteSuccess, ResourceDeleteSuccessData.DeserializeResourceDeleteSuccessData },
            { SystemEventNames.ResourceDeleteFailure, ResourceDeleteFailureData.DeserializeResourceDeleteFailureData },
            { SystemEventNames.ResourceDeleteCancel, ResourceDeleteCancelData.DeserializeResourceDeleteCancelData },
            { SystemEventNames.ResourceActionSuccess, ResourceActionSuccessData.DeserializeResourceActionSuccessData },
            { SystemEventNames.ResourceActionFailure, ResourceActionFailureData.DeserializeResourceActionFailureData },
            { SystemEventNames.ResourceActionCancel, ResourceActionCancelData.DeserializeResourceActionCancelData },

            // ServiceBus events
            { SystemEventNames.ServiceBusActiveMessagesAvailableWithNoListeners, ServiceBusActiveMessagesAvailableWithNoListenersEventData.DeserializeServiceBusActiveMessagesAvailableWithNoListenersEventData },
            { SystemEventNames.ServiceBusDeadletterMessagesAvailableWithNoListener, ServiceBusDeadletterMessagesAvailableWithNoListenersEventData.DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData },

            // Storage events
            { SystemEventNames.StorageBlobCreated, StorageBlobCreatedEventData.DeserializeStorageBlobCreatedEventData },
            { SystemEventNames.StorageBlobDeleted, StorageBlobDeletedEventData.DeserializeStorageBlobDeletedEventData },
            { SystemEventNames.StorageBlobRenamed, StorageBlobRenamedEventData.DeserializeStorageBlobRenamedEventData },
            { SystemEventNames.StorageDirectoryCreated, StorageDirectoryCreatedEventData.DeserializeStorageDirectoryCreatedEventData },
            { SystemEventNames.StorageDirectoryDeleted, StorageDirectoryDeletedEventData.DeserializeStorageDirectoryDeletedEventData },
            { SystemEventNames.StorageDirectoryRenamed, StorageDirectoryRenamedEventData.DeserializeStorageDirectoryRenamedEventData },
            { SystemEventNames.StorageLifecyclePolicyCompleted, StorageLifecyclePolicyCompletedEventData.DeserializeStorageLifecyclePolicyCompletedEventData },

            // App Service
            { SystemEventNames.WebAppUpdated, WebAppUpdatedEventData.DeserializeWebAppUpdatedEventData },
            { SystemEventNames.WebBackupOperationStarted, WebBackupOperationStartedEventData.DeserializeWebBackupOperationStartedEventData },
            { SystemEventNames.WebBackupOperationCompleted, WebBackupOperationCompletedEventData.DeserializeWebBackupOperationCompletedEventData },
            { SystemEventNames.WebBackupOperationFailed, WebBackupOperationFailedEventData.DeserializeWebBackupOperationFailedEventData },
            { SystemEventNames.WebRestoreOperationStarted, WebRestoreOperationStartedEventData.DeserializeWebRestoreOperationStartedEventData },
            { SystemEventNames.WebRestoreOperationCompleted, WebRestoreOperationCompletedEventData.DeserializeWebRestoreOperationCompletedEventData },
            { SystemEventNames.WebRestoreOperationFailed, WebRestoreOperationFailedEventData.DeserializeWebRestoreOperationFailedEventData },
            { SystemEventNames.WebSlotSwapStarted, WebSlotSwapStartedEventData.DeserializeWebSlotSwapStartedEventData },
            { SystemEventNames.WebSlotSwapCompleted, WebSlotSwapCompletedEventData.DeserializeWebSlotSwapCompletedEventData },
            { SystemEventNames.WebSlotSwapFailed, WebSlotSwapFailedEventData.DeserializeWebSlotSwapFailedEventData },
            { SystemEventNames.WebSlotSwapWithPreviewStarted, WebSlotSwapWithPreviewStartedEventData.DeserializeWebSlotSwapWithPreviewStartedEventData },
            { SystemEventNames.WebSlotSwapWithPreviewCancelled, WebSlotSwapWithPreviewCancelledEventData.DeserializeWebSlotSwapWithPreviewCancelledEventData },
            { SystemEventNames.WebAppServicePlanUpdated, WebAppServicePlanUpdatedEventData.DeserializeWebAppServicePlanUpdatedEventData }
        };
    }
}
