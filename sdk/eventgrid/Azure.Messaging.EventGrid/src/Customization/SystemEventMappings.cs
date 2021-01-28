// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventGrid.SystemEvents;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    ///  Represents the names of the various event types for the system events published to
    ///  Azure Event Grid.
    /// </summary>
    public static class SystemEventMappings
    {
        // Keep this sorted by the name of the service publishing the events.

        #region AppConfiguration events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AppConfigurationKeyValueDeletedEventData"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueDeletedEventName = "Microsoft.AppConfiguration.KeyValueDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AppConfigurationKeyValueModifiedEventData"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueModifiedEventName = "Microsoft.AppConfiguration.KeyValueModified";
        #endregion

        #region Communication events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMemberAddedToThreadWithUserEventData"/> system event.
        /// </summary>
        public const string ACSChatMemberAddedToThreadWithUserEventName = "Microsoft.Communication.ChatMemberAddedToThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMemberRemovedFromThreadWithUserEventData"/> system event.
        /// </summary>
        public const string ACSChatMemberRemovedFromThreadWithUserEventName = "Microsoft.Communication.ChatMemberRemovedFromThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageDeletedEventData"/> system event.
        /// </summary>
        public const string ACSChatMessageDeletedEventName = "Microsoft.Communication.ChatMessageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageEditedEventData"/> system event.
        /// </summary>
        public const string ACSChatMessageEditedEventName = "Microsoft.Communication.ChatMessageEdited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageReceivedEventData"/> system event.
        /// </summary>
        public const string ACSChatMessageReceivedEventName = "Microsoft.Communication.ChatMessageReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadCreatedWithUserEventData"/> system event.
        /// </summary>
        public const string ACSChatThreadCreatedWithUserEventName = "Microsoft.Communication.ChatThreadCreatedWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadPropertiesUpdatedPerUserEventData"/> system event.
        /// </summary>
        public const string ACSChatThreadPropertiesUpdatedPerUserEventName = "Microsoft.Communication.ChatThreadPropertiesUpdatedPerUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadWithUserDeletedEventData"/> system event.
        /// </summary>
        public const string ACSChatThreadWithUserDeletedEventName = "Microsoft.Communication.ChatThreadWithUserDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsSmsDeliveryReportReceivedEventData"/> system event.
        /// </summary>
        public const string ACSSMSDeliveryReportReceivedEventName = "Microsoft.Communication.SMSDeliveryReportReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsSmsReceivedEventData"/> system event.
        /// </summary>
        public const string ACSSMSReceivedEventName = "Microsoft.Communication.SMSReceived";
        #endregion

        #region ContainerRegistry events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImagePushedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryImagePushedEventName = "Microsoft.ContainerRegistry.ImagePushed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImageDeletedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryImageDeletedEventName = "Microsoft.ContainerRegistry.ImageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartDeletedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryChartDeletedEventName = "Microsoft.ContainerRegistry.ChartDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartPushedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryChartPushedEventName = "Microsoft.ContainerRegistry.ChartPushed";
        #endregion

        #region Device events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceCreatedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceCreatedEventName = "Microsoft.Devices.DeviceCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceDeletedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceDeletedEventName = "Microsoft.Devices.DeviceDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceConnectedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceConnectedEventName = "Microsoft.Devices.DeviceConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceDisconnectedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceDisconnectedEventName = "Microsoft.Devices.DeviceDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceTelemetryEventData"/> system event.
        /// </summary>
        public const string IotHubDeviceTelemetryEventName = "Microsoft.Devices.DeviceTelemetry";
        #endregion

        #region EventGrid events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="SubscriptionValidationEventData"/> system event.
        /// </summary>
        public const string EventGridSubscriptionValidationEventName = "Microsoft.EventGrid.SubscriptionValidationEvent";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="SubscriptionDeletedEventData"/> system event.
        /// </summary>
        public const string EventGridSubscriptionDeletedEventName = "Microsoft.EventGrid.SubscriptionDeletedEvent";

        // Event Hub Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="EventHubCaptureFileCreatedEventData"/> system event.
        /// </summary>
        public const string EventHubCaptureFileCreatedEventName = "Microsoft.EventHub.CaptureFileCreated";
        #endregion

        #region Key Vault Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNewVersionCreatedEventName = "Microsoft.KeyVault.CertificateNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNearExpiryEventName = "Microsoft.KeyVault.CertificateNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateExpiredEventName = "Microsoft.KeyVault.CertificateExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyNewVersionCreatedEventName = "Microsoft.KeyVault.KeyNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyNearExpiryEventName = "Microsoft.KeyVault.KeyNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyExpiredEventName = "Microsoft.KeyVault.KeyExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretNewVersionCreatedEventName = "Microsoft.KeyVault.SecretNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretNearExpiryEventName = "Microsoft.KeyVault.SecretNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretExpiredEventName = "Microsoft.KeyVault.SecretExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultAccessPolicyChangedEventData"/> system event.
        /// </summary>
        public const string KeyVaultAccessPolicyChangedEventName = "Microsoft.KeyVault.VaultAccessPolicyChanged";
        #endregion

        #region MachineLearningServices events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesDatasetDriftDetectedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesDatasetDriftDetectedEventName = "Microsoft.MachineLearningServices.DatasetDriftDetected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelDeployedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelDeployedEventName = "Microsoft.MachineLearningServices.ModelDeployed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelRegisteredEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelRegisteredEventName = "Microsoft.MachineLearningServices.ModelRegistered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunCompletedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunCompletedEventName = "Microsoft.MachineLearningServices.RunCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunStatusChangedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunStatusChangedEventName = "Microsoft.MachineLearningServices.RunStatusChanged";
        #endregion

        #region Maps events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceEnteredEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceEnteredEventName = "Microsoft.Maps.GeofenceEntered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceExitedEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceExitedEventName = "Microsoft.Maps.GeofenceExited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceResultEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceResultEventName = "Microsoft.Maps.GeofenceResult";
        #endregion

        #region Media Services events

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobStateChangeEventData"/> system event.
        /// </summary>
        public const string MediaJobStateChangeEventName= "Microsoft.Media.JobStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputStateChangeEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputStateChangeEventName = "Microsoft.Media.JobOutputStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobScheduledEventData"/> system event.
        /// </summary>
        public const string MediaJobScheduledEventName = "Microsoft.Media.JobScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobProcessingEventData"/> system event.
        /// </summary>
        public const string MediaJobProcessingEventName = "Microsoft.Media.JobProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCancelingEventData"/> system event.
        /// </summary>
        public const string MediaJobCancelingEventName = "Microsoft.Media.JobCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobFinishedEventData"/> system event.
        /// </summary>
        public const string MediaJobFinishedEventName = "Microsoft.Media.JobFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCanceledEventData"/> system event.
        /// </summary>
        public const string MediaJobCanceledEventName = "Microsoft.Media.JobCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobErroredEventData"/> system event.
        /// </summary>
        public const string MediaJobErroredEventName = "Microsoft.Media.JobErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCanceledEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputCanceledEventName = "Microsoft.Media.JobOutputCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCancelingEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputCancelingEventName = "Microsoft.Media.JobOutputCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// MediaJobOutputErroredEvent system event.
        /// </summary>
        public const string MediaJobOutputErroredEventName = "Microsoft.Media.JobOutputErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputFinishedEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputFinishedEventName = "Microsoft.Media.JobOutputFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProcessingEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputProcessingEventName = "Microsoft.Media.JobOutputProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputScheduledEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputScheduledEventName = "Microsoft.Media.JobOutputScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProgressEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputProgressEventName = "Microsoft.Media.JobOutputProgress";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderConnectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderConnectedEventName = "Microsoft.Media.LiveEventEncoderConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventConnectionRejectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventConnectionRejectedEventName = "Microsoft.Media.LiveEventConnectionRejected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderDisconnectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderDisconnectedEventName = "Microsoft.Media.LiveEventEncoderDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamReceivedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamReceivedEventName = "Microsoft.Media.LiveEventIncomingStreamReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamsOutOfSyncEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamsOutOfSyncEventName = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingVideoStreamsOutOfSyncEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingVideoStreamsOutOfSyncEventName = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingDataChunkDroppedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingDataChunkDroppedEventName = "Microsoft.Media.LiveEventIncomingDataChunkDropped";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIngestHeartbeatEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIngestHeartbeatEventName = "Microsoft.Media.LiveEventIngestHeartbeat";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventTrackDiscontinuityDetectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventTrackDiscontinuityDetectedEventName = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";
        #endregion

        #region Resource Manager (Azure Subscription/Resource Group) events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteSuccessData"/> system event.
        /// </summary>
        public const string ResourceWriteSuccessEventName = "Microsoft.Resources.ResourceWriteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteFailureData"/> system event.
        /// </summary>
        public const string ResourceWriteFailureEventName = "Microsoft.Resources.ResourceWriteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteCancelData"/> system event.
        /// </summary>
        public const string ResourceWriteCancelEventName = "Microsoft.Resources.ResourceWriteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteSuccessData"/> system event.
        /// </summary>
        public const string ResourceDeleteSuccessEventName = "Microsoft.Resources.ResourceDeleteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteFailureData"/> system event.
        /// </summary>
        public const string ResourceDeleteFailureEventName = "Microsoft.Resources.ResourceDeleteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteCancelData"/> system event.
        /// </summary>
        public const string ResourceDeleteCancelEventName = "Microsoft.Resources.ResourceDeleteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionSuccessData"/> system event.
        /// </summary>
        public const string ResourceActionSuccessEventName = "Microsoft.Resources.ResourceActionSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionFailureData"/> system event.
        /// </summary>
        public const string ResourceActionFailureEventName = "Microsoft.Resources.ResourceActionFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionCancelData"/> system event.
        /// </summary>
        public const string ResourceActionCancelEventName = "Microsoft.Resources.ResourceActionCancel";
        #endregion

        #region ServiceBus events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusActiveMessagesAvailableWithNoListenersEventData"/> system event.
        /// </summary>
        public const string ServiceBusActiveMessagesAvailableWithNoListenersEventName = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusDeadletterMessagesAvailableWithNoListenersEventData"/> system event.
        /// </summary>
        public const string ServiceBusDeadletterMessagesAvailableWithNoListenerEventName = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener";
        #endregion

        #region Storage events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobCreatedEventData"/> system event.
        /// </summary>
        public const string StorageBlobCreatedEventName = "Microsoft.Storage.BlobCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobDeletedEventData"/> system event.
        /// </summary>
        public const string StorageBlobDeletedEventName = "Microsoft.Storage.BlobDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobRenamedEventData"/> system event.
        /// </summary>
        public const string StorageBlobRenamedEventName = "Microsoft.Storage.BlobRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryCreatedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryCreatedEventName = "Microsoft.Storage.DirectoryCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryDeletedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryDeletedEventName = "Microsoft.Storage.DirectoryDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryRenamedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryRenamedEventName = "Microsoft.Storage.DirectoryRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageLifecyclePolicyCompletedEventData"/> system event.
        /// </summary>
        public const string StorageLifecyclePolicyCompletedEventName = "Microsoft.Storage.LifecyclePolicyCompleted";
        #endregion

        #region App Service
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebAppUpdatedEventData"/> system event.
        /// </summary>
        public const string WebAppUpdatedEventName = "Microsoft.Web.AppUpdated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationStartedEventData"/> system event.
        /// </summary>
        public const string WebBackupOperationStartedEventName = "Microsoft.Web.BackupOperationStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationCompletedEventData"/> system event.
        /// </summary>
        public const string WebBackupOperationCompletedEventName = "Microsoft.Web.BackupOperationCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationFailedEventData"/> system event.
        /// </summary>
        public const string WebBackupOperationFailedEventName = "Microsoft.Web.BackupOperationFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationStartedEventData"/> system event.
        /// </summary>
        public const string WebRestoreOperationStartedEventName = "Microsoft.Web.RestoreOperationStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationCompletedEventData"/> system event.
        /// </summary>
        public const string WebRestoreOperationCompletedEventName = "Microsoft.Web.RestoreOperationCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationFailedEventData"/> system event.
        /// </summary>
        public const string WebRestoreOperationFailedEventName = "Microsoft.Web.RestoreOperationFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapStartedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapStartedEventName = "Microsoft.Web.SlotSwapStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapCompletedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapCompletedEventName = "Microsoft.Web.SlotSwapCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapFailedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapFailedEventName = "Microsoft.Web.SlotSwapFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapWithPreviewStartedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapWithPreviewStartedEventName = "Microsoft.Web.SlotSwapWithPreviewStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapWithPreviewCancelledEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapWithPreviewCancelledEventName = "Microsoft.Web.SlotSwapWithPreviewCancelled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebAppServicePlanUpdatedEventData"/> system event.
        /// </summary>
        public const string WebAppServicePlanUpdatedEventName = "Microsoft.Web.AppServicePlanUpdated";
        #endregion
    }
}
