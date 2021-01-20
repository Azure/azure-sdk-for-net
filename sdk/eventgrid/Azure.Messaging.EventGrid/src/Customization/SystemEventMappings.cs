// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <see cref="AppConfigurationKeyValueDeletedEvent"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueDeletedEvent = "Microsoft.AppConfiguration.KeyValueDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AppConfigurationKeyValueModifiedEvent"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueModifiedEvent = "Microsoft.AppConfiguration.KeyValueModified";
        #endregion

        #region Communication events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMemberAddedToThreadWithUserEvent"/> system event.
        /// </summary>
        public const string ACSChatMemberAddedToThreadWithUserEvent = "Microsoft.Communication.ChatMemberAddedToThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMemberRemovedFromThreadWithUserEvent"/> system event.
        /// </summary>
        public const string ACSChatMemberRemovedFromThreadWithUserEvent = "Microsoft.Communication.ChatMemberRemovedFromThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageDeletedEvent"/> system event.
        /// </summary>
        public const string ACSChatMessageDeletedEvent = "Microsoft.Communication.ChatMessageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageEditedEvent"/> system event.
        /// </summary>
        public const string ACSChatMessageEditedEvent = "Microsoft.Communication.ChatMessageEdited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageReceivedEvent"/> system event.
        /// </summary>
        public const string ACSChatMessageReceivedEvent = "Microsoft.Communication.ChatMessageReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadCreatedWithUserEvent"/> system event.
        /// </summary>
        public const string ACSChatThreadCreatedWithUserEvent = "Microsoft.Communication.ChatThreadCreatedWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadPropertiesUpdatedPerUserEvent"/> system event.
        /// </summary>
        public const string ACSChatThreadPropertiesUpdatedPerUserEvent = "Microsoft.Communication.ChatThreadPropertiesUpdatedPerUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadWithUserDeletedEvent"/> system event.
        /// </summary>
        public const string ACSChatThreadWithUserDeletedEvent = "Microsoft.Communication.ChatThreadWithUserDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSSMSDeliveryReportReceivedEvent"/> system event.
        /// </summary>
        public const string ACSSMSDeliveryReportReceivedEvent = "Microsoft.Communication.SMSDeliveryReportReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSSMSReceivedEvent"/> system event.
        /// </summary>
        public const string ACSSMSReceivedEvent= "Microsoft.Communication.SMSReceived";
        #endregion

        #region ContainerRegistry events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImagePushedEvent"/> system event.
        /// </summary>
        public const string ContainerRegistryImagePushedEvent = "Microsoft.ContainerRegistry.ImagePushed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImageDeletedEvent"/> system event.
        /// </summary>
        public const string ContainerRegistryImageDeletedEvent = "Microsoft.ContainerRegistry.ImageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartDeletedEvent"/> system event.
        /// </summary>
        public const string ContainerRegistryChartDeletedEvent = "Microsoft.ContainerRegistry.ChartDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartPushedEvent"/> system event.
        /// </summary>
        public const string ContainerRegistryChartPushedEvent = "Microsoft.ContainerRegistry.ChartPushed";
        #endregion

        #region Device events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IoTHubDeviceCreatedEvent"/> system event.
        /// </summary>
        public const string IoTHubDeviceCreatedEvent = "Microsoft.Devices.DeviceCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IoTHubDeviceDeletedEvent"/> system event.
        /// </summary>
        public const string IoTHubDeviceDeletedEvent = "Microsoft.Devices.DeviceDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IoTHubDeviceConnectedEvent"/> system event.
        /// </summary>
        public const string IoTHubDeviceConnectedEvent = "Microsoft.Devices.DeviceConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IoTHubDeviceDisconnectedEvent"/> system event.
        /// </summary>
        public const string IoTHubDeviceDisconnectedEvent = "Microsoft.Devices.DeviceDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceTelemetryEvent"/> system event.
        /// </summary>
        public const string IotHubDeviceTelemetryEvent = "Microsoft.Devices.DeviceTelemetry";
        #endregion

        #region EventGrid events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="EventGridSubscriptionValidationEvent"/> system event.
        /// </summary>
        public const string EventGridSubscriptionValidationEvent = "Microsoft.EventGrid.SubscriptionValidationEvent";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="EventGridSubscriptionDeletedEvent"/> system event.
        /// </summary>
        public const string EventGridSubscriptionDeletedEvent = "Microsoft.EventGrid.SubscriptionDeletedEvent";

        // Event Hub Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="EventHubCaptureFileCreatedEvent"/> system event.
        /// </summary>
        public const string EventHubCaptureFileCreatedEvent = "Microsoft.EventHub.CaptureFileCreated";
        #endregion

        #region Key Vault Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNewVersionCreatedEvent"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNewVersionCreatedEvent = "Microsoft.KeyVault.CertificateNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNearExpiryEvent"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNearExpiryEvent = "Microsoft.KeyVault.CertificateNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateExpiredEvent"/> system event.
        /// </summary>
        public const string KeyVaultCertificateExpiredEvent = "Microsoft.KeyVault.CertificateExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNewVersionCreatedEvent"/> system event.
        /// </summary>
        public const string KeyVaultKeyNewVersionCreatedEvent = "Microsoft.KeyVault.KeyNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNearExpiryEvent"/> system event.
        /// </summary>
        public const string KeyVaultKeyNearExpiryEvent = "Microsoft.KeyVault.KeyNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyExpiredEvent"/> system event.
        /// </summary>
        public const string KeyVaultKeyExpiredEvent = "Microsoft.KeyVault.KeyExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNewVersionCreatedEvent"/> system event.
        /// </summary>
        public const string KeyVaultSecretNewVersionCreatedEvent = "Microsoft.KeyVault.SecretNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNearExpiryEvent"/> system event.
        /// </summary>
        public const string KeyVaultSecretNearExpiryEvent = "Microsoft.KeyVault.SecretNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretExpiredEvent"/> system event.
        /// </summary>
        public const string KeyVaultSecretExpiredEvent = "Microsoft.KeyVault.SecretExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultVaultAccessPolicyChangedEvent"/> system event.
        /// </summary>
        public const string KeyVaultVaultAccessPolicyChangedEvent = "Microsoft.KeyVault.VaultAccessPolicyChanged";
        #endregion

        #region MachineLearningServices events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesDatasetDriftDetectedEvent"/> system event.
        /// </summary>
        public const string MachineLearningServicesDatasetDriftDetectedEvent = "Microsoft.MachineLearningServices.DatasetDriftDetected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelDeployedEvent"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelDeployedEvent = "Microsoft.MachineLearningServices.ModelDeployed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelRegisteredEvent"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelRegisteredEvent = "Microsoft.MachineLearningServices.ModelRegistered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunCompletedEvent"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunCompletedEvent = "Microsoft.MachineLearningServices.RunCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunStatusChangedEvent"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunStatusChangedEvent = "Microsoft.MachineLearningServices.RunStatusChanged";
        #endregion

        #region Maps events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceEnteredEvent"/> system event.
        /// </summary>
        public const string MapsGeofenceEnteredEvent = "Microsoft.Maps.GeofenceEntered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceExitedEvent"/> system event.
        /// </summary>
        public const string MapsGeofenceExitedEvent = "Microsoft.Maps.GeofenceExited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceResultEvent"/> system event.
        /// </summary>
        public const string MapsGeofenceResultEvent = "Microsoft.Maps.GeofenceResult";
        #endregion

        #region Media Services events

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobStateChangeEvent"/> system event.
        /// </summary>
        public const string MediaJobStateChangeEvent = "Microsoft.Media.JobStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputStateChangeEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputStateChangeEvent = "Microsoft.Media.JobOutputStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobScheduledEvent"/> system event.
        /// </summary>
        public const string MediaJobScheduledEvent = "Microsoft.Media.JobScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobProcessingEvent"/> system event.
        /// </summary>
        public const string MediaJobProcessingEvent = "Microsoft.Media.JobProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCancelingEvent"/> system event.
        /// </summary>
        public const string MediaJobCancelingEvent = "Microsoft.Media.JobCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobFinishedEvent"/> system event.
        /// </summary>
        public const string MediaJobFinishedEvent = "Microsoft.Media.JobFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCanceledEvent"/> system event.
        /// </summary>
        public const string MediaJobCanceledEvent = "Microsoft.Media.JobCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobErroredEvent"/> system event.
        /// </summary>
        public const string MediaJobErroredEvent = "Microsoft.Media.JobErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCanceledEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputCanceledEvent = "Microsoft.Media.JobOutputCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCancelingEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputCancelingEvent = "Microsoft.Media.JobOutputCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// MediaJobOutputErroredEvent system event.
        /// </summary>
        public const string MediaJobOutputErroredEvent = "Microsoft.Media.JobOutputErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputFinishedEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputFinishedEvent = "Microsoft.Media.JobOutputFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProcessingEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputProcessingEvent = "Microsoft.Media.JobOutputProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputScheduledEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputScheduledEvent = "Microsoft.Media.JobOutputScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProgressEvent"/> system event.
        /// </summary>
        public const string MediaJobOutputProgressEvent = "Microsoft.Media.JobOutputProgress";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderConnectedEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderConnectedEvent = "Microsoft.Media.LiveEventEncoderConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventConnectionRejectedEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventConnectionRejectedEvent = "Microsoft.Media.LiveEventConnectionRejected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderDisconnectedEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderDisconnectedEvent = "Microsoft.Media.LiveEventEncoderDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamReceivedEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamReceivedEvent = "Microsoft.Media.LiveEventIncomingStreamReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamsOutOfSyncEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamsOutOfSyncEvent = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingVideoStreamsOutOfSyncEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingVideoStreamsOutOfSyncEvent = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingChunkDroppedEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingChunkDroppedEvent = "Microsoft.Media.LiveEventIncomingDataChunkDropped";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIngestHeartbeatEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventIngestHeartbeatEvent = "Microsoft.Media.LiveEventIngestHeartbeat";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventTrackDiscontinuityDetectedEvent"/> system event.
        /// </summary>
        public const string MediaLiveEventTrackDiscontinuityDetectedEvent = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";
        #endregion

        #region Resource Manager (Azure Subscription/Resource Group) events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteSuccessEvent"/> system event.
        /// </summary>
        public const string ResourceWriteSuccessEvent = "Microsoft.Resources.ResourceWriteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteFailureEvent"/> system event.
        /// </summary>
        public const string ResourceWriteFailureEvent = "Microsoft.Resources.ResourceWriteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteCancelEvent"/> system event.
        /// </summary>
        public const string ResourceWriteCancelEvent = "Microsoft.Resources.ResourceWriteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteSuccessEvent"/> system event.
        /// </summary>
        public const string ResourceDeleteSuccessEvent = "Microsoft.Resources.ResourceDeleteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteFailureEvent"/> system event.
        /// </summary>
        public const string ResourceDeleteFailureEvent = "Microsoft.Resources.ResourceDeleteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteCancelEvent"/> system event.
        /// </summary>
        public const string ResourceDeleteCancelEvent = "Microsoft.Resources.ResourceDeleteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionSuccessEvent"/> system event.
        /// </summary>
        public const string ResourceActionSuccessEvent = "Microsoft.Resources.ResourceActionSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionFailureEvent"/> system event.
        /// </summary>
        public const string ResourceActionFailureEvent = "Microsoft.Resources.ResourceActionFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionCancelEvent"/> system event.
        /// </summary>
        public const string ResourceActionCancelEvent = "Microsoft.Resources.ResourceActionCancel";
        #endregion

        #region ServiceBus events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusActiveMessagesAvailableWithNoListenersEvent"/> system event.
        /// </summary>
        public const string ServiceBusActiveMessagesAvailableWithNoListenersEvent = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusDeadletterMessagesAvailableWithNoListenerEvent"/> system event.
        /// </summary>
        public const string ServiceBusDeadletterMessagesAvailableWithNoListenerEvent = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener";
        #endregion

        #region Storage events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobCreatedEvent"/> system event.
        /// </summary>
        public const string StorageBlobCreatedEvent = "Microsoft.Storage.BlobCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobDeletedEvent"/> system event.
        /// </summary>
        public const string StorageBlobDeletedEvent = "Microsoft.Storage.BlobDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobRenamedEvent"/> system event.
        /// </summary>
        public const string StorageBlobRenamedEvent = "Microsoft.Storage.BlobRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryCreatedEvent"/> system event.
        /// </summary>
        public const string StorageDirectoryCreatedEvent = "Microsoft.Storage.DirectoryCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryDeletedEvent"/> system event.
        /// </summary>
        public const string StorageDirectoryDeletedEvent = "Microsoft.Storage.DirectoryDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryRenamedEvent"/> system event.
        /// </summary>
        public const string StorageDirectoryRenamedEvent = "Microsoft.Storage.DirectoryRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageLifecyclePolicyCompletedEvent"/> system event.
        /// </summary>
        public const string StorageLifecyclePolicyCompletedEvent = "Microsoft.Storage.LifecyclePolicyCompleted";
        #endregion

        #region App Service
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebAppUpdated"/> system event.
        /// </summary>
        public const string WebAppUpdated = "Microsoft.Web.AppUpdated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationStarted"/> system event.
        /// </summary>
        public const string WebBackupOperationStarted = "Microsoft.Web.BackupOperationStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationCompleted"/> system event.
        /// </summary>
        public const string WebBackupOperationCompleted = "Microsoft.Web.BackupOperationCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationFailed"/> system event.
        /// </summary>
        public const string WebBackupOperationFailed = "Microsoft.Web.BackupOperationFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationStarted"/> system event.
        /// </summary>
        public const string WebRestoreOperationStarted = "Microsoft.Web.RestoreOperationStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationCompleted"/> system event.
        /// </summary>
        public const string WebRestoreOperationCompleted = "Microsoft.Web.RestoreOperationCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationFailed"/> system event.
        /// </summary>
        public const string WebRestoreOperationFailed = "Microsoft.Web.RestoreOperationFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapStarted"/> system event.
        /// </summary>
        public const string WebSlotSwapStarted = "Microsoft.Web.SlotSwapStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapCompleted"/> system event.
        /// </summary>
        public const string WebSlotSwapCompleted = "Microsoft.Web.SlotSwapCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapFailed"/> system event.
        /// </summary>
        public const string WebSlotSwapFailed = "Microsoft.Web.SlotSwapFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapWithPreviewStarted"/> system event.
        /// </summary>
        public const string WebSlotSwapWithPreviewStarted = "Microsoft.Web.SlotSwapWithPreviewStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapWithPreviewCancelled"/> system event.
        /// </summary>
        public const string WebSlotSwapWithPreviewCancelled = "Microsoft.Web.SlotSwapWithPreviewCancelled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebAppServicePlanUpdated"/> system event.
        /// </summary>
        public const string WebAppServicePlanUpdated = "Microsoft.Web.AppServicePlanUpdated";
        #endregion
    }
}
