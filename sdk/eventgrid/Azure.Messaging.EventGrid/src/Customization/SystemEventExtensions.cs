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
            { SystemEventMappings.AppConfigurationKeyValueDeletedEventName, AppConfigurationKeyValueDeletedEventData.DeserializeAppConfigurationKeyValueDeletedEventData },
            { SystemEventMappings.AppConfigurationKeyValueModifiedEventName, AppConfigurationKeyValueModifiedEventData.DeserializeAppConfigurationKeyValueModifiedEventData },

            // Communication events
            { SystemEventMappings.ACSChatMemberAddedToThreadWithUserEventName, ACSChatMemberAddedToThreadWithUserEventData.DeserializeACSChatMemberAddedToThreadWithUserEventData },
            { SystemEventMappings.ACSChatMemberRemovedFromThreadWithUserEventName, ACSChatMemberRemovedFromThreadWithUserEventData.DeserializeACSChatMemberRemovedFromThreadWithUserEventData },
            { SystemEventMappings.ACSChatMessageDeletedEventName, ACSChatMessageDeletedEventData.DeserializeACSChatMessageDeletedEventData },
            { SystemEventMappings.ACSChatMessageEditedEventName, ACSChatMessageEditedEventData.DeserializeACSChatMessageEditedEventData },
            { SystemEventMappings.ACSChatMessageReceivedEventName, ACSChatMessageReceivedEventData.DeserializeACSChatMessageReceivedEventData },
            { SystemEventMappings.ACSChatThreadCreatedWithUserEventName,  ACSChatThreadCreatedWithUserEventData.DeserializeACSChatThreadCreatedWithUserEventData },
            { SystemEventMappings.ACSChatThreadPropertiesUpdatedPerUserEventName, ACSChatThreadPropertiesUpdatedPerUserEventData.DeserializeACSChatThreadPropertiesUpdatedPerUserEventData },
            { SystemEventMappings.ACSChatThreadWithUserDeletedEventName, ACSChatThreadWithUserDeletedEventData.DeserializeACSChatThreadWithUserDeletedEventData },
            { SystemEventMappings.ACSSMSDeliveryReportReceivedEventName, AcsSmsDeliveryReportReceivedEventData.DeserializeAcsSmsDeliveryReportReceivedEventData },
            { SystemEventMappings.ACSSMSReceivedEventName, AcsSmsReceivedEventData.DeserializeAcsSmsReceivedEventData },

            // ContainerRegistry events
            { SystemEventMappings.ContainerRegistryImagePushedEventName, ContainerRegistryImagePushedEventData.DeserializeContainerRegistryImagePushedEventData },
            { SystemEventMappings.ContainerRegistryImageDeletedEventName, ContainerRegistryImageDeletedEventData.DeserializeContainerRegistryImageDeletedEventData },
            { SystemEventMappings.ContainerRegistryChartDeletedEventName, ContainerRegistryChartDeletedEventData.DeserializeContainerRegistryChartDeletedEventData },
            { SystemEventMappings.ContainerRegistryChartPushedEventName, ContainerRegistryChartPushedEventData.DeserializeContainerRegistryChartPushedEventData },

            // IoTHub Device events
            { SystemEventMappings.IoTHubDeviceCreatedEventName, IotHubDeviceCreatedEventData.DeserializeIotHubDeviceCreatedEventData },
            { SystemEventMappings.IoTHubDeviceDeletedEventName, IotHubDeviceDeletedEventData.DeserializeIotHubDeviceDeletedEventData },
            { SystemEventMappings.IoTHubDeviceConnectedEventName, IotHubDeviceConnectedEventData.DeserializeIotHubDeviceConnectedEventData },
            { SystemEventMappings.IoTHubDeviceDisconnectedEventName, IotHubDeviceDisconnectedEventData.DeserializeIotHubDeviceDisconnectedEventData },
            { SystemEventMappings.IotHubDeviceTelemetryEventName, IotHubDeviceTelemetryEventData.DeserializeIotHubDeviceTelemetryEventData },

            // EventGrid events
            { SystemEventMappings.EventGridSubscriptionValidationEventName, SubscriptionValidationEventData.DeserializeSubscriptionValidationEventData },
            { SystemEventMappings.EventGridSubscriptionDeletedEventName, SubscriptionDeletedEventData.DeserializeSubscriptionDeletedEventData },

            // Event Hub events
            { SystemEventMappings.EventHubCaptureFileCreatedEventName, EventHubCaptureFileCreatedEventData.DeserializeEventHubCaptureFileCreatedEventData },

            // Key Vault events
            { SystemEventMappings.KeyVaultCertificateNewVersionCreatedEventName, KeyVaultCertificateNewVersionCreatedEventData.DeserializeKeyVaultCertificateNewVersionCreatedEventData },
            { SystemEventMappings.KeyVaultCertificateNearExpiryEventName, KeyVaultCertificateNearExpiryEventData.DeserializeKeyVaultCertificateNearExpiryEventData },
            { SystemEventMappings.KeyVaultCertificateExpiredEventName, KeyVaultCertificateExpiredEventData.DeserializeKeyVaultCertificateExpiredEventData },
            { SystemEventMappings.KeyVaultKeyNearExpiryEventName, KeyVaultKeyNearExpiryEventData.DeserializeKeyVaultKeyNearExpiryEventData },
            { SystemEventMappings.KeyVaultKeyNewVersionCreatedEventName, KeyVaultKeyNewVersionCreatedEventData.DeserializeKeyVaultKeyNewVersionCreatedEventData },
            { SystemEventMappings.KeyVaultKeyExpiredEventName, KeyVaultKeyExpiredEventData.DeserializeKeyVaultKeyExpiredEventData },
            { SystemEventMappings.KeyVaultSecretNewVersionCreatedEventName, KeyVaultSecretNewVersionCreatedEventData.DeserializeKeyVaultSecretNewVersionCreatedEventData },
            { SystemEventMappings.KeyVaultSecretNearExpiryEventName, KeyVaultSecretNearExpiryEventData.DeserializeKeyVaultSecretNearExpiryEventData },
            { SystemEventMappings.KeyVaultSecretExpiredEventName, KeyVaultSecretExpiredEventData.DeserializeKeyVaultSecretExpiredEventData },
            { SystemEventMappings.KeyVaultAccessPolicyChangedEventName, KeyVaultAccessPolicyChangedEventData.DeserializeKeyVaultAccessPolicyChangedEventData },

            // MachineLearningServices events
            { SystemEventMappings.MachineLearningServicesDatasetDriftDetectedEventName, MachineLearningServicesDatasetDriftDetectedEventData.DeserializeMachineLearningServicesDatasetDriftDetectedEventData },
            { SystemEventMappings.MachineLearningServicesModelDeployedEventName, MachineLearningServicesModelDeployedEventData.DeserializeMachineLearningServicesModelDeployedEventData },
            { SystemEventMappings.MachineLearningServicesModelRegisteredEventName, MachineLearningServicesModelRegisteredEventData.DeserializeMachineLearningServicesModelRegisteredEventData },
            { SystemEventMappings.MachineLearningServicesRunCompletedEventName, MachineLearningServicesRunCompletedEventData.DeserializeMachineLearningServicesRunCompletedEventData },
            { SystemEventMappings.MachineLearningServicesRunStatusChangedEventName, MachineLearningServicesRunStatusChangedEventData.DeserializeMachineLearningServicesRunStatusChangedEventData },

            // Maps events
            { SystemEventMappings.MapsGeofenceEnteredEventName, MapsGeofenceEnteredEventData.DeserializeMapsGeofenceEnteredEventData },
            { SystemEventMappings.MapsGeofenceExitedEventName, MapsGeofenceExitedEventData.DeserializeMapsGeofenceExitedEventData },
            { SystemEventMappings.MapsGeofenceResultEventName, MapsGeofenceResultEventData.DeserializeMapsGeofenceResultEventData },

            // Media Services events
            { SystemEventMappings.MediaJobStateChangeEventName, MediaJobStateChangeEventData.DeserializeMediaJobStateChangeEventData },
            { SystemEventMappings.MediaJobOutputStateChangeEventName, MediaJobOutputStateChangeEventData.DeserializeMediaJobOutputStateChangeEventData },
            { SystemEventMappings.MediaJobScheduledEventName, MediaJobScheduledEventData.DeserializeMediaJobScheduledEventData },
            { SystemEventMappings.MediaJobProcessingEventName, MediaJobProcessingEventData.DeserializeMediaJobProcessingEventData },
            { SystemEventMappings.MediaJobCancelingEventName, MediaJobCancelingEventData.DeserializeMediaJobCancelingEventData },
            { SystemEventMappings.MediaJobFinishedEventName, MediaJobFinishedEventData.DeserializeMediaJobFinishedEventData },
            { SystemEventMappings.MediaJobCanceledEventName, MediaJobCanceledEventData.DeserializeMediaJobCanceledEventData },
            { SystemEventMappings.MediaJobErroredEventName, MediaJobErroredEventData.DeserializeMediaJobErroredEventData },
            { SystemEventMappings.MediaJobOutputCanceledEventName, MediaJobOutputCanceledEventData.DeserializeMediaJobOutputCanceledEventData },
            { SystemEventMappings.MediaJobOutputCancelingEventName, MediaJobOutputCancelingEventData.DeserializeMediaJobOutputCancelingEventData },
            { SystemEventMappings.MediaJobOutputErroredEventName, MediaJobOutputErroredEventData.DeserializeMediaJobOutputErroredEventData },
            { SystemEventMappings.MediaJobOutputFinishedEventName, MediaJobOutputFinishedEventData.DeserializeMediaJobOutputFinishedEventData },
            { SystemEventMappings.MediaJobOutputProcessingEventName, MediaJobOutputProcessingEventData.DeserializeMediaJobOutputProcessingEventData },
            { SystemEventMappings.MediaJobOutputScheduledEventName, MediaJobOutputScheduledEventData.DeserializeMediaJobOutputScheduledEventData },
            { SystemEventMappings.MediaJobOutputProgressEventName, MediaJobOutputProgressEventData.DeserializeMediaJobOutputProgressEventData },
            { SystemEventMappings.MediaLiveEventEncoderConnectedEventName, MediaLiveEventEncoderConnectedEventData.DeserializeMediaLiveEventEncoderConnectedEventData },
            { SystemEventMappings.MediaLiveEventConnectionRejectedEventName, MediaLiveEventConnectionRejectedEventData.DeserializeMediaLiveEventConnectionRejectedEventData },
            { SystemEventMappings.MediaLiveEventEncoderDisconnectedEventName, MediaLiveEventEncoderDisconnectedEventData.DeserializeMediaLiveEventEncoderDisconnectedEventData },
            { SystemEventMappings.MediaLiveEventIncomingStreamReceivedEventName, MediaLiveEventIncomingStreamReceivedEventData.DeserializeMediaLiveEventIncomingStreamReceivedEventData },
            { SystemEventMappings.MediaLiveEventIncomingStreamsOutOfSyncEventName, MediaLiveEventIncomingStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingStreamsOutOfSyncEventData },
            { SystemEventMappings.MediaLiveEventIncomingVideoStreamsOutOfSyncEventName, MediaLiveEventIncomingVideoStreamsOutOfSyncEventData.DeserializeMediaLiveEventIncomingVideoStreamsOutOfSyncEventData },
            { SystemEventMappings.MediaLiveEventIncomingDataChunkDroppedEventName, MediaLiveEventIncomingDataChunkDroppedEventData.DeserializeMediaLiveEventIncomingDataChunkDroppedEventData },
            { SystemEventMappings.MediaLiveEventIngestHeartbeatEventName, MediaLiveEventIngestHeartbeatEventData.DeserializeMediaLiveEventIngestHeartbeatEventData },
            { SystemEventMappings.MediaLiveEventTrackDiscontinuityDetectedEventName, MediaLiveEventTrackDiscontinuityDetectedEventData.DeserializeMediaLiveEventTrackDiscontinuityDetectedEventData },

            // Resource Manager (Azure Subscription/Resource Group) events
            { SystemEventMappings.ResourceWriteSuccessEventName, ResourceWriteSuccessData.DeserializeResourceWriteSuccessData },
            { SystemEventMappings.ResourceWriteFailureEventName, ResourceWriteFailureData.DeserializeResourceWriteFailureData },
            { SystemEventMappings.ResourceWriteCancelEventName, ResourceWriteCancelData.DeserializeResourceWriteCancelData },
            { SystemEventMappings.ResourceDeleteSuccessEventName, ResourceDeleteSuccessData.DeserializeResourceDeleteSuccessData },
            { SystemEventMappings.ResourceDeleteFailureEventName, ResourceDeleteFailureData.DeserializeResourceDeleteFailureData },
            { SystemEventMappings.ResourceDeleteCancelEventName, ResourceDeleteCancelData.DeserializeResourceDeleteCancelData },
            { SystemEventMappings.ResourceActionSuccessEventName, ResourceActionSuccessData.DeserializeResourceActionSuccessData },
            { SystemEventMappings.ResourceActionFailureEventName, ResourceActionFailureData.DeserializeResourceActionFailureData },
            { SystemEventMappings.ResourceActionCancelEventName, ResourceActionCancelData.DeserializeResourceActionCancelData },

            // ServiceBus events
            { SystemEventMappings.ServiceBusActiveMessagesAvailableWithNoListenersEventName, ServiceBusActiveMessagesAvailableWithNoListenersEventData.DeserializeServiceBusActiveMessagesAvailableWithNoListenersEventData },
            { SystemEventMappings.ServiceBusDeadletterMessagesAvailableWithNoListenerEventName, ServiceBusDeadletterMessagesAvailableWithNoListenersEventData.DeserializeServiceBusDeadletterMessagesAvailableWithNoListenersEventData },

            // Storage events
            { SystemEventMappings.StorageBlobCreatedEventName, StorageBlobCreatedEventData.DeserializeStorageBlobCreatedEventData },
            { SystemEventMappings.StorageBlobDeletedEventName, StorageBlobDeletedEventData.DeserializeStorageBlobDeletedEventData },
            { SystemEventMappings.StorageBlobRenamedEventName, StorageBlobRenamedEventData.DeserializeStorageBlobRenamedEventData },
            { SystemEventMappings.StorageDirectoryCreatedEventName, StorageDirectoryCreatedEventData.DeserializeStorageDirectoryCreatedEventData },
            { SystemEventMappings.StorageDirectoryDeletedEventName, StorageDirectoryDeletedEventData.DeserializeStorageDirectoryDeletedEventData },
            { SystemEventMappings.StorageDirectoryRenamedEventName, StorageDirectoryRenamedEventData.DeserializeStorageDirectoryRenamedEventData },
            { SystemEventMappings.StorageLifecyclePolicyCompletedEventName, StorageLifecyclePolicyCompletedEventData.DeserializeStorageLifecyclePolicyCompletedEventData },

            // App Service
            { SystemEventMappings.WebAppUpdatedEventName, WebAppUpdatedEventData.DeserializeWebAppUpdatedEventData },
            { SystemEventMappings.WebBackupOperationStartedEventName, WebBackupOperationStartedEventData.DeserializeWebBackupOperationStartedEventData },
            { SystemEventMappings.WebBackupOperationCompletedEventName, WebBackupOperationCompletedEventData.DeserializeWebBackupOperationCompletedEventData },
            { SystemEventMappings.WebBackupOperationFailedEventName, WebBackupOperationFailedEventData.DeserializeWebBackupOperationFailedEventData },
            { SystemEventMappings.WebRestoreOperationStartedEventName, WebRestoreOperationStartedEventData.DeserializeWebRestoreOperationStartedEventData },
            { SystemEventMappings.WebRestoreOperationCompletedEventName, WebRestoreOperationCompletedEventData.DeserializeWebRestoreOperationCompletedEventData },
            { SystemEventMappings.WebRestoreOperationFailedEventName, WebRestoreOperationFailedEventData.DeserializeWebRestoreOperationFailedEventData },
            { SystemEventMappings.WebSlotSwapStartedEventName, WebSlotSwapStartedEventData.DeserializeWebSlotSwapStartedEventData },
            { SystemEventMappings.WebSlotSwapCompletedEventName, WebSlotSwapCompletedEventData.DeserializeWebSlotSwapCompletedEventData },
            { SystemEventMappings.WebSlotSwapFailedEventName, WebSlotSwapFailedEventData.DeserializeWebSlotSwapFailedEventData },
            { SystemEventMappings.WebSlotSwapWithPreviewStartedEventName, WebSlotSwapWithPreviewStartedEventData.DeserializeWebSlotSwapWithPreviewStartedEventData },
            { SystemEventMappings.WebSlotSwapWithPreviewCancelledEventName, WebSlotSwapWithPreviewCancelledEventData.DeserializeWebSlotSwapWithPreviewCancelledEventData },
            { SystemEventMappings.WebAppServicePlanUpdatedEventName, WebAppServicePlanUpdatedEventData.DeserializeWebAppServicePlanUpdatedEventData }
        };
    }
}
