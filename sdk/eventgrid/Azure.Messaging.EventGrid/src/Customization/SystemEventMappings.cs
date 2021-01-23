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
        public const string AppConfigurationKeyValueDeletedEvent = "Microsoft.AppConfiguration.KeyValueDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AppConfigurationKeyValueModifiedEventData"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueModifiedEvent = "Microsoft.AppConfiguration.KeyValueModified";
        #endregion

        #region Communication events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMemberAddedToThreadWithUserEventData"/> system event.
        /// </summary>
        public const string ACSChatMemberAddedToThreadWithUserEvent = "Microsoft.Communication.ChatMemberAddedToThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMemberRemovedFromThreadWithUserEventData"/> system event.
        /// </summary>
        public const string ACSChatMemberRemovedFromThreadWithUserEvent = "Microsoft.Communication.ChatMemberRemovedFromThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageDeletedEventData"/> system event.
        /// </summary>
        public const string ACSChatMessageDeletedEvent = "Microsoft.Communication.ChatMessageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageEditedEventData"/> system event.
        /// </summary>
        public const string ACSChatMessageEditedEvent = "Microsoft.Communication.ChatMessageEdited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatMessageReceivedEventData"/> system event.
        /// </summary>
        public const string ACSChatMessageReceivedEvent = "Microsoft.Communication.ChatMessageReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadCreatedWithUserEventData"/> system event.
        /// </summary>
        public const string ACSChatThreadCreatedWithUserEvent = "Microsoft.Communication.ChatThreadCreatedWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadPropertiesUpdatedPerUserEventData"/> system event.
        /// </summary>
        public const string ACSChatThreadPropertiesUpdatedPerUserEvent = "Microsoft.Communication.ChatThreadPropertiesUpdatedPerUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ACSChatThreadWithUserDeletedEventData"/> system event.
        /// </summary>
        public const string ACSChatThreadWithUserDeletedEvent = "Microsoft.Communication.ChatThreadWithUserDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsSmsDeliveryReportReceivedEventData"/> system event.
        /// </summary>
        public const string ACSSMSDeliveryReportReceivedEvent = "Microsoft.Communication.SMSDeliveryReportReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsSmsReceivedEventData"/> system event.
        /// </summary>
        public const string ACSSMSReceivedEvent= "Microsoft.Communication.SMSReceived";
        #endregion

        #region ContainerRegistry events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImagePushedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryImagePushedEvent = "Microsoft.ContainerRegistry.ImagePushed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImageDeletedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryImageDeletedEvent = "Microsoft.ContainerRegistry.ImageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartDeletedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryChartDeletedEvent = "Microsoft.ContainerRegistry.ChartDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartPushedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryChartPushedEvent = "Microsoft.ContainerRegistry.ChartPushed";
        #endregion

        #region Device events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceCreatedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceCreatedEvent = "Microsoft.Devices.DeviceCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceDeletedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceDeletedEvent = "Microsoft.Devices.DeviceDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceConnectedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceConnectedEvent = "Microsoft.Devices.DeviceConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceDisconnectedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceDisconnectedEvent = "Microsoft.Devices.DeviceDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceTelemetryEventData"/> system event.
        /// </summary>
        public const string IotHubDeviceTelemetryEvent = "Microsoft.Devices.DeviceTelemetry";
        #endregion

        #region EventGrid events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="SubscriptionValidationEventData"/> system event.
        /// </summary>
        public const string EventGridSubscriptionValidationEvent = "Microsoft.EventGrid.SubscriptionValidationEvent";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="SubscriptionDeletedEventData"/> system event.
        /// </summary>
        public const string EventGridSubscriptionDeletedEvent = "Microsoft.EventGrid.SubscriptionDeletedEvent";

        // Event Hub Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="EventHubCaptureFileCreatedEventData"/> system event.
        /// </summary>
        public const string EventHubCaptureFileCreatedEvent = "Microsoft.EventHub.CaptureFileCreated";
        #endregion

        #region Key Vault Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNewVersionCreatedEvent = "Microsoft.KeyVault.CertificateNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNearExpiryEvent = "Microsoft.KeyVault.CertificateNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateExpiredEvent = "Microsoft.KeyVault.CertificateExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyNewVersionCreatedEvent = "Microsoft.KeyVault.KeyNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyNearExpiryEvent = "Microsoft.KeyVault.KeyNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyExpiredEvent = "Microsoft.KeyVault.KeyExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretNewVersionCreatedEvent = "Microsoft.KeyVault.SecretNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretNearExpiryEvent = "Microsoft.KeyVault.SecretNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretExpiredEvent = "Microsoft.KeyVault.SecretExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultAccessPolicyChangedEventData"/> system event.
        /// </summary>
        public const string KeyVaultAccessPolicyChangedEvent = "Microsoft.KeyVault.VaultAccessPolicyChanged";
        #endregion

        #region MachineLearningServices events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesDatasetDriftDetectedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesDatasetDriftDetectedEvent = "Microsoft.MachineLearningServices.DatasetDriftDetected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelDeployedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelDeployedEvent = "Microsoft.MachineLearningServices.ModelDeployed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelRegisteredEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelRegisteredEvent = "Microsoft.MachineLearningServices.ModelRegistered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunCompletedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunCompletedEvent = "Microsoft.MachineLearningServices.RunCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunStatusChangedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunStatusChangedEvent = "Microsoft.MachineLearningServices.RunStatusChanged";
        #endregion

        #region Maps events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceEnteredEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceEnteredEvent = "Microsoft.Maps.GeofenceEntered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceExitedEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceExitedEvent = "Microsoft.Maps.GeofenceExited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceResultEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceResultEvent = "Microsoft.Maps.GeofenceResult";
        #endregion

        #region Media Services events

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobStateChangeEventData"/> system event.
        /// </summary>
        public const string MediaJobStateChangeEvent = "Microsoft.Media.JobStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputStateChangeEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputStateChangeEvent = "Microsoft.Media.JobOutputStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobScheduledEventData"/> system event.
        /// </summary>
        public const string MediaJobScheduledEvent = "Microsoft.Media.JobScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobProcessingEventData"/> system event.
        /// </summary>
        public const string MediaJobProcessingEvent = "Microsoft.Media.JobProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCancelingEventData"/> system event.
        /// </summary>
        public const string MediaJobCancelingEvent = "Microsoft.Media.JobCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobFinishedEventData"/> system event.
        /// </summary>
        public const string MediaJobFinishedEvent = "Microsoft.Media.JobFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCanceledEventData"/> system event.
        /// </summary>
        public const string MediaJobCanceledEvent = "Microsoft.Media.JobCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobErroredEventData"/> system event.
        /// </summary>
        public const string MediaJobErroredEvent = "Microsoft.Media.JobErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCanceledEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputCanceledEvent = "Microsoft.Media.JobOutputCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCancelingEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputCancelingEvent = "Microsoft.Media.JobOutputCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// MediaJobOutputErroredEvent system event.
        /// </summary>
        public const string MediaJobOutputErroredEvent = "Microsoft.Media.JobOutputErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputFinishedEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputFinishedEvent = "Microsoft.Media.JobOutputFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProcessingEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputProcessingEvent = "Microsoft.Media.JobOutputProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputScheduledEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputScheduledEvent = "Microsoft.Media.JobOutputScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProgressEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputProgressEvent = "Microsoft.Media.JobOutputProgress";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderConnectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderConnectedEvent = "Microsoft.Media.LiveEventEncoderConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventConnectionRejectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventConnectionRejectedEvent = "Microsoft.Media.LiveEventConnectionRejected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderDisconnectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderDisconnectedEvent = "Microsoft.Media.LiveEventEncoderDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamReceivedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamReceivedEvent = "Microsoft.Media.LiveEventIncomingStreamReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamsOutOfSyncEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamsOutOfSyncEvent = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingVideoStreamsOutOfSyncEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingVideoStreamsOutOfSyncEvent = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingDataChunkDroppedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingDataChunkDroppedEventName = "Microsoft.Media.LiveEventIncomingDataChunkDropped";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIngestHeartbeatEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIngestHeartbeatEvent = "Microsoft.Media.LiveEventIngestHeartbeat";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventTrackDiscontinuityDetectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventTrackDiscontinuityDetectedEvent = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";
        #endregion

        #region Resource Manager (Azure Subscription/Resource Group) events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteSuccessEventData"/> system event.
        /// </summary>
        public const string ResourceWriteSuccessEvent = "Microsoft.Resources.ResourceWriteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteFailureEventData"/> system event.
        /// </summary>
        public const string ResourceWriteFailureEvent = "Microsoft.Resources.ResourceWriteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteCancelEventData"/> system event.
        /// </summary>
        public const string ResourceWriteCancelEvent = "Microsoft.Resources.ResourceWriteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteSuccessEventData"/> system event.
        /// </summary>
        public const string ResourceDeleteSuccessEvent = "Microsoft.Resources.ResourceDeleteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteFailureEventData"/> system event.
        /// </summary>
        public const string ResourceDeleteFailureEvent = "Microsoft.Resources.ResourceDeleteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteCancelEventData"/> system event.
        /// </summary>
        public const string ResourceDeleteCancelEvent = "Microsoft.Resources.ResourceDeleteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionSuccessData"/> system event.
        /// </summary>
        public const string ResourceActionSuccessEvent = "Microsoft.Resources.ResourceActionSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionFailureData"/> system event.
        /// </summary>
        public const string ResourceActionFailureEvent = "Microsoft.Resources.ResourceActionFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionCancelData"/> system event.
        /// </summary>
        public const string ResourceActionCancelEvent = "Microsoft.Resources.ResourceActionCancel";
        #endregion

        #region ServiceBus events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusActiveMessagesAvailableWithNoListenersEventData"/> system event.
        /// </summary>
        public const string ServiceBusActiveMessagesAvailableWithNoListenersEvent = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusDeadletterMessagesAvailableWithNoListenerEventData"/> system event.
        /// </summary>
        public const string ServiceBusDeadletterMessagesAvailableWithNoListenerEvent = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener";
        #endregion

        #region Storage events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobCreatedEventData"/> system event.
        /// </summary>
        public const string StorageBlobCreatedEvent = "Microsoft.Storage.BlobCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobDeletedEventData"/> system event.
        /// </summary>
        public const string StorageBlobDeletedEvent = "Microsoft.Storage.BlobDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobRenamedEventData"/> system event.
        /// </summary>
        public const string StorageBlobRenamedEvent = "Microsoft.Storage.BlobRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryCreatedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryCreatedEvent = "Microsoft.Storage.DirectoryCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryDeletedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryDeletedEvent = "Microsoft.Storage.DirectoryDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryRenamedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryRenamedEvent = "Microsoft.Storage.DirectoryRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageLifecyclePolicyCompletedEventData"/> system event.
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
