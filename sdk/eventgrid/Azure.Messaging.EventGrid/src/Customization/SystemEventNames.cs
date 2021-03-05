// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventGrid.SystemEvents;

namespace Azure.Messaging.EventGrid
{
    /// <summary>
    ///  Represents the names of the various event types for the system events published to
    ///  Azure Event Grid.
    /// </summary>
    public static class SystemEventNames
    {
        // Keep this sorted by the name of the service publishing the events.

        #region AppConfiguration events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AppConfigurationKeyValueDeletedEventData"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueDeleted = "Microsoft.AppConfiguration.KeyValueDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AppConfigurationKeyValueModifiedEventData"/> system event.
        /// </summary>
        public const string AppConfigurationKeyValueModified = "Microsoft.AppConfiguration.KeyValueModified";
        #endregion

        #region Communication events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatParticipantAddedToThreadEventData"/> system event.
        /// </summary>
        public const string AcsChatParticipantAddedToThread = "Microsoft.Communication.ChatParticipantAddedToThread";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatParticipantAddedToThreadWithUserEventData"/> system event.
        /// </summary>
        public const string AcsChatParticipantAddedToThreadWithUser = "Microsoft.Communication.ChatParticipantAddedToThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatParticipantRemovedFromThreadEventData"/> system event.
        /// </summary>
        public const string AcsChatParticipantRemovedFromThread = "Microsoft.Communication.ChatParticipantRemovedFromThread";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatParticipantRemovedFromThreadWithUserEventData"/> system event.
        /// </summary>
        public const string AcsChatParticipantRemovedFromThreadWithUser = "Microsoft.Communication.ChatParticipantRemovedFromThreadWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatMessageDeletedEventData"/> system event.
        /// </summary>
        public const string AcsChatMessageDeleted = "Microsoft.Communication.ChatMessageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatMessageDeletedInThreadEventData"/> system event.
        /// </summary>
        public const string AcsChatMessageDeletedInThread = "Microsoft.Communication.ChatMessageDeletedInThread";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatMessageEditedEventData"/> system event.
        /// </summary>
        public const string AcsChatMessageEdited = "Microsoft.Communication.ChatMessageEdited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatMessageEditedInThreadEventData"/> system event.
        /// </summary>
        public const string AcsChatMessageEditedInThread = "Microsoft.Communication.ChatMessageEditedInThread";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatMessageReceivedEventData"/> system event.
        /// </summary>
        public const string AcsChatMessageReceived = "Microsoft.Communication.ChatMessageReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatMessageReceivedInThreadEventData"/> system event.
        /// </summary>
        public const string AcsChatMessageReceivedInThread = "Microsoft.Communication.ChatMessageReceivedInThread";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatThreadCreatedEventData"/> system event.
        /// </summary>
        public const string AcsChatThreadCreated = "Microsoft.Communication.ChatThreadCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatThreadCreatedWithUserEventData"/> system event.
        /// </summary>
        public const string AcsChatThreadCreatedWithUser = "Microsoft.Communication.ChatThreadCreatedWithUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatThreadPropertiesUpdatedEventData"/> system event.
        /// </summary>
        public const string AcsChatThreadPropertiesUpdated = "Microsoft.Communication.ChatThreadPropertiesUpdated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatThreadPropertiesUpdatedPerUserEventData"/> system event.
        /// </summary>
        public const string AcsChatThreadPropertiesUpdatedPerUser = "Microsoft.Communication.ChatThreadPropertiesUpdatedPerUser";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatThreadDeletedEventData"/> system event.
        /// </summary>
        public const string AcsChatThreadDeleted = "Microsoft.Communication.ChatThreadDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsChatThreadWithUserDeletedEventData"/> system event.
        /// </summary>
        public const string AcsChatThreadWithUserDeleted = "Microsoft.Communication.ChatThreadWithUserDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsSmsDeliveryReportReceivedEventData"/> system event.
        /// </summary>
        public const string AcsSmsDeliveryReportReceived = "Microsoft.Communication.SMSDeliveryReportReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="AcsSmsReceivedEventData"/> system event.
        /// </summary>
        public const string ACSSMSReceived = "Microsoft.Communication.SMSReceived";
        #endregion

        #region ContainerRegistry events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImagePushedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryImagePushed = "Microsoft.ContainerRegistry.ImagePushed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryImageDeletedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryImageDeleted = "Microsoft.ContainerRegistry.ImageDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartDeletedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryChartDeleted = "Microsoft.ContainerRegistry.ChartDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ContainerRegistryChartPushedEventData"/> system event.
        /// </summary>
        public const string ContainerRegistryChartPushed = "Microsoft.ContainerRegistry.ChartPushed";
        #endregion

        #region Device events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceCreatedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceCreated = "Microsoft.Devices.DeviceCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceDeletedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceDeleted = "Microsoft.Devices.DeviceDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceConnectedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceConnected = "Microsoft.Devices.DeviceConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceDisconnectedEventData"/> system event.
        /// </summary>
        public const string IoTHubDeviceDisconnected = "Microsoft.Devices.DeviceDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="IotHubDeviceTelemetryEventData"/> system event.
        /// </summary>
        public const string IotHubDeviceTelemetry = "Microsoft.Devices.DeviceTelemetry";
        #endregion

        #region EventGrid events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="SubscriptionValidationEventData"/> system event.
        /// </summary>
        public const string EventGridSubscriptionValidation = "Microsoft.EventGrid.SubscriptionValidationEvent";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="SubscriptionDeletedEventData"/> system event.
        /// </summary>
        public const string EventGridSubscriptionDeleted = "Microsoft.EventGrid.SubscriptionDeletedEvent";

        // Event Hub Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="EventHubCaptureFileCreatedEventData"/> system event.
        /// </summary>
        public const string EventHubCaptureFileCreated = "Microsoft.EventHub.CaptureFileCreated";
        #endregion

        #region Key Vault Events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNewVersionCreated = "Microsoft.KeyVault.CertificateNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateNearExpiry = "Microsoft.KeyVault.CertificateNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultCertificateExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultCertificateExpired = "Microsoft.KeyVault.CertificateExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyNewVersionCreated = "Microsoft.KeyVault.KeyNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyNearExpiry = "Microsoft.KeyVault.KeyNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultKeyExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultKeyExpired = "Microsoft.KeyVault.KeyExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNewVersionCreatedEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretNewVersionCreated = "Microsoft.KeyVault.SecretNewVersionCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretNearExpiryEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretNearExpiry = "Microsoft.KeyVault.SecretNearExpiry";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultSecretExpiredEventData"/> system event.
        /// </summary>
        public const string KeyVaultSecretExpired = "Microsoft.KeyVault.SecretExpired";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="KeyVaultAccessPolicyChangedEventData"/> system event.
        /// </summary>
        public const string KeyVaultAccessPolicyChanged = "Microsoft.KeyVault.VaultAccessPolicyChanged";
        #endregion

        #region MachineLearningServices events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesDatasetDriftDetectedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesDatasetDriftDetected = "Microsoft.MachineLearningServices.DatasetDriftDetected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelDeployedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelDeployed = "Microsoft.MachineLearningServices.ModelDeployed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesModelRegisteredEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesModelRegistered = "Microsoft.MachineLearningServices.ModelRegistered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunCompletedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunCompleted = "Microsoft.MachineLearningServices.RunCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MachineLearningServicesRunStatusChangedEventData"/> system event.
        /// </summary>
        public const string MachineLearningServicesRunStatusChanged = "Microsoft.MachineLearningServices.RunStatusChanged";
        #endregion

        #region Maps events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceEnteredEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceEntered = "Microsoft.Maps.GeofenceEntered";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceExitedEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceExited = "Microsoft.Maps.GeofenceExited";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MapsGeofenceResultEventData"/> system event.
        /// </summary>
        public const string MapsGeofenceResult = "Microsoft.Maps.GeofenceResult";
        #endregion

        #region Media Services events

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobStateChangeEventData"/> system event.
        /// </summary>
        public const string MediaJobStateChange= "Microsoft.Media.JobStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputStateChangeEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputStateChange = "Microsoft.Media.JobOutputStateChange";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobScheduledEventData"/> system event.
        /// </summary>
        public const string MediaJobScheduled = "Microsoft.Media.JobScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobProcessingEventData"/> system event.
        /// </summary>
        public const string MediaJobProcessing = "Microsoft.Media.JobProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCancelingEventData"/> system event.
        /// </summary>
        public const string MediaJobCanceling = "Microsoft.Media.JobCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobFinishedEventData"/> system event.
        /// </summary>
        public const string MediaJobFinished = "Microsoft.Media.JobFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobCanceledEventData"/> system event.
        /// </summary>
        public const string MediaJobCanceled = "Microsoft.Media.JobCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobErroredEventData"/> system event.
        /// </summary>
        public const string MediaJobErrored = "Microsoft.Media.JobErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCanceledEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputCanceled = "Microsoft.Media.JobOutputCanceled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputCancelingEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputCanceling = "Microsoft.Media.JobOutputCanceling";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// MediaJobOutputErroredEvent system event.
        /// </summary>
        public const string MediaJobOutputErrored = "Microsoft.Media.JobOutputErrored";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputFinishedEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputFinished = "Microsoft.Media.JobOutputFinished";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProcessingEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputProcessing = "Microsoft.Media.JobOutputProcessing";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputScheduledEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputScheduled = "Microsoft.Media.JobOutputScheduled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaJobOutputProgressEventData"/> system event.
        /// </summary>
        public const string MediaJobOutputProgress = "Microsoft.Media.JobOutputProgress";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderConnectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderConnected = "Microsoft.Media.LiveEventEncoderConnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventConnectionRejectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventConnectionRejected = "Microsoft.Media.LiveEventConnectionRejected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventEncoderDisconnectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventEncoderDisconnected = "Microsoft.Media.LiveEventEncoderDisconnected";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamReceivedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamReceived = "Microsoft.Media.LiveEventIncomingStreamReceived";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingStreamsOutOfSyncEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingStreamsOutOfSync = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingVideoStreamsOutOfSyncEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingVideoStreamsOutOfSync = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIncomingDataChunkDroppedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIncomingDataChunkDropped = "Microsoft.Media.LiveEventIncomingDataChunkDropped";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventIngestHeartbeatEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventIngestHeartbeat = "Microsoft.Media.LiveEventIngestHeartbeat";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="MediaLiveEventTrackDiscontinuityDetectedEventData"/> system event.
        /// </summary>
        public const string MediaLiveEventTrackDiscontinuityDetected = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";
        #endregion

        #region Resource Manager (Azure Subscription/Resource Group) events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteSuccessEventData"/> system event.
        /// </summary>
        public const string ResourceWriteSuccess = "Microsoft.Resources.ResourceWriteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteFailureEventData"/> system event.
        /// </summary>
        public const string ResourceWriteFailure = "Microsoft.Resources.ResourceWriteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceWriteCancelEventData"/> system event.
        /// </summary>
        public const string ResourceWriteCancel = "Microsoft.Resources.ResourceWriteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteSuccessEventData"/> system event.
        /// </summary>
        public const string ResourceDeleteSuccess = "Microsoft.Resources.ResourceDeleteSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteFailureEventData"/> system event.
        /// </summary>
        public const string ResourceDeleteFailure = "Microsoft.Resources.ResourceDeleteFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceDeleteCancelEventData"/> system event.
        /// </summary>
        public const string ResourceDeleteCancel = "Microsoft.Resources.ResourceDeleteCancel";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionSuccessEventData"/> system event.
        /// </summary>
        public const string ResourceActionSuccess = "Microsoft.Resources.ResourceActionSuccess";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionFailureEventData"/> system event.
        /// </summary>
        public const string ResourceActionFailure = "Microsoft.Resources.ResourceActionFailure";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ResourceActionCancelEventData"/> system event.
        /// </summary>
        public const string ResourceActionCancel = "Microsoft.Resources.ResourceActionCancel";
        #endregion

        #region ServiceBus events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusActiveMessagesAvailableWithNoListenersEventData"/> system event.
        /// </summary>
        public const string ServiceBusActiveMessagesAvailableWithNoListeners = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusDeadletterMessagesAvailableWithNoListenersEventData"/> system event.
        /// </summary>
        public const string ServiceBusDeadletterMessagesAvailableWithNoListener = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData"/> system event.
        /// </summary>
        public const string ServiceBusActiveMessagesAvailablePeriodicNotifications = "Microsoft.ServiceBus.ActiveMessagesAvailablePeriodicNotifications";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData"/> system event.
        /// </summary>
        public const string ServiceBusDeadletterMessagesAvailablePeriodicNotifications = "Microsoft.ServiceBus.DeadletterMessagesAvailablePeriodicNotifications";
        #endregion

        #region Storage events
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobCreatedEventData"/> system event.
        /// </summary>
        public const string StorageBlobCreated = "Microsoft.Storage.BlobCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobDeletedEventData"/> system event.
        /// </summary>
        public const string StorageBlobDeleted = "Microsoft.Storage.BlobDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageBlobRenamedEventData"/> system event.
        /// </summary>
        public const string StorageBlobRenamed = "Microsoft.Storage.BlobRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryCreatedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryCreated = "Microsoft.Storage.DirectoryCreated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryDeletedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryDeleted = "Microsoft.Storage.DirectoryDeleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageDirectoryRenamedEventData"/> system event.
        /// </summary>
        public const string StorageDirectoryRenamed = "Microsoft.Storage.DirectoryRenamed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="StorageLifecyclePolicyCompletedEventData"/> system event.
        /// </summary>
        public const string StorageLifecyclePolicyCompleted = "Microsoft.Storage.LifecyclePolicyCompleted";
        #endregion

        #region App Service
        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebAppUpdatedEventData"/> system event.
        /// </summary>
        public const string WebAppUpdated = "Microsoft.Web.AppUpdated";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationStartedEventData"/> system event.
        /// </summary>
        public const string WebBackupOperationStarted = "Microsoft.Web.BackupOperationStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationCompletedEventData"/> system event.
        /// </summary>
        public const string WebBackupOperationCompleted = "Microsoft.Web.BackupOperationCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebBackupOperationFailedEventData"/> system event.
        /// </summary>
        public const string WebBackupOperationFailed = "Microsoft.Web.BackupOperationFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationStartedEventData"/> system event.
        /// </summary>
        public const string WebRestoreOperationStarted = "Microsoft.Web.RestoreOperationStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationCompletedEventData"/> system event.
        /// </summary>
        public const string WebRestoreOperationCompleted = "Microsoft.Web.RestoreOperationCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebRestoreOperationFailedEventData"/> system event.
        /// </summary>
        public const string WebRestoreOperationFailed = "Microsoft.Web.RestoreOperationFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapStartedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapStarted = "Microsoft.Web.SlotSwapStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapCompletedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapCompleted = "Microsoft.Web.SlotSwapCompleted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapFailedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapFailed = "Microsoft.Web.SlotSwapFailed";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapWithPreviewStartedEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapWithPreviewStarted = "Microsoft.Web.SlotSwapWithPreviewStarted";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebSlotSwapWithPreviewCancelledEventData"/> system event.
        /// </summary>
        public const string WebSlotSwapWithPreviewCancelled = "Microsoft.Web.SlotSwapWithPreviewCancelled";

        /// <summary>
        /// The value of the Event Type stored in <see cref="EventGridEvent.EventType"/> and <see cref="CloudEvent.Type"/> for the
        /// <see cref="WebAppServicePlanUpdatedEventData"/> system event.
        /// </summary>
        public const string WebAppServicePlanUpdated = "Microsoft.Web.AppServicePlanUpdated";
        #endregion
    }
}
