// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.EventGrid
{
    /// <summary>
    ///  Represents the names of the various event types for the system events published to
    ///  Azure Event Grid.
    /// </summary>
    public class EventTypes
    {
        // Keep this sorted by the name of the service publishing the events.

        // AppConfiguration events
        public const string AppConfigurationKeyValueDeletedEvent = "Microsoft.AppConfiguration.KeyValueDeleted";
        public const string AppConfigurationKeyValueModifiedEvent = "Microsoft.AppConfiguration.KeyValueModified";

        // ContainerRegistry events
        public const string ContainerRegistryImagePushedEvent = "Microsoft.ContainerRegistry.ImagePushed";
        public const string ContainerRegistryImageDeletedEvent = "Microsoft.ContainerRegistry.ImageDeleted";
        public const string ContainerRegistryChartDeletedEvent = "Microsoft.ContainerRegistry.ChartDeleted";
        public const string ContainerRegistryChartPushedEvent = "Microsoft.ContainerRegistry.ChartPushed";

        // Device events
        public const string IoTHubDeviceCreatedEvent = "Microsoft.Devices.DeviceCreated";
        public const string IoTHubDeviceDeletedEvent = "Microsoft.Devices.DeviceDeleted";
        public const string IoTHubDeviceConnectedEvent = "Microsoft.Devices.DeviceConnected";
        public const string IoTHubDeviceDisconnectedEvent = "Microsoft.Devices.DeviceDisconnected";
        public const string IotHubDeviceTelemetryEvent = "Microsoft.Devices.DeviceTelemetry";

        // EventGrid events
        public const string EventGridSubscriptionValidationEvent = "Microsoft.EventGrid.SubscriptionValidationEvent";
        public const string EventGridSubscriptionDeletedEvent = "Microsoft.EventGrid.SubscriptionDeletedEvent";

        // Event Hub Events
        public const string EventHubCaptureFileCreatedEvent = "Microsoft.EventHub.CaptureFileCreated";

        // MachineLearningServices events
        public const string MachineLearningServicesDatasetDriftDetectedEvent = "Microsoft.MachineLearningServices.DatasetDriftDetected";
        public const string MachineLearningServicesModelDeployedEvent = "Microsoft.MachineLearningServices.ModelDeployed";
        public const string MachineLearningServicesModelRegisteredEvent = "Microsoft.MachineLearningServices.ModelRegistered";
        public const string MachineLearningServicesRunCompletedEvent = "Microsoft.MachineLearningServices.RunCompleted";
        public const string MachineLearningServicesRunStatusChangedEvent = "Microsoft.MachineLearningServices.RunStatusChanged";

        // Maps events
        public const string MapsGeofenceEnteredEvent = "Microsoft.Maps.GeofenceEntered";
        public const string MapsGeofenceExitedEvent = "Microsoft.Maps.GeofenceExited";
        public const string MapsGeofenceResultEvent = "Microsoft.Maps.GeofenceResult";

        // Media Services events
        public const string MediaJobStateChangeEvent = "Microsoft.Media.JobStateChange";
        public const string MediaJobOutputStateChangeEvent = "Microsoft.Media.JobOutputStateChange";
        public const string MediaJobScheduledEvent = "Microsoft.Media.JobScheduled";
        public const string MediaJobProcessingEvent = "Microsoft.Media.JobProcessing";
        public const string MediaJobCancelingEvent = "Microsoft.Media.JobCanceling";
        public const string MediaJobFinishedEvent = "Microsoft.Media.JobFinished";
        public const string MediaJobCanceledEvent = "Microsoft.Media.JobCanceled";
        public const string MediaJobErroredEvent = "Microsoft.Media.JobErrored";
        public const string MediaJobOutputCanceledEvent = "Microsoft.Media.JobOutputCanceled";
        public const string MediaJobOutputCancelingEvent = "Microsoft.Media.JobOutputCanceling";
        public const string MediaJobOutputErroredEvent = "Microsoft.Media.JobOutputErrored";
        public const string MediaJobOutputFinishedEvent = "Microsoft.Media.JobOutputFinished";
        public const string MediaJobOutputProcessingEvent = "Microsoft.Media.JobOutputProcessing";
        public const string MediaJobOutputScheduledEvent = "Microsoft.Media.JobOutputScheduled";
        public const string MediaJobOutputProgressEvent = "Microsoft.Media.JobOutputProgress";
        public const string MediaLiveEventEncoderConnectedEvent = "Microsoft.Media.LiveEventEncoderConnected";
        public const string MediaLiveEventConnectionRejectedEvent = "Microsoft.Media.LiveEventConnectionRejected";
        public const string MediaLiveEventEncoderDisconnectedEvent = "Microsoft.Media.LiveEventEncoderDisconnected";
        public const string MediaLiveEventIncomingStreamReceivedEvent = "Microsoft.Media.LiveEventIncomingStreamReceived";
        public const string MediaLiveEventIncomingStreamsOutOfSyncEvent = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";
        public const string MediaLiveEventIncomingVideoStreamsOutOfSyncEvent = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";
        public const string MediaLiveEventIncomingChunkDroppedEvent = "Microsoft.Media.LiveEventIncomingDataChunkDropped";
        public const string MediaLiveEventIngestHeartbeatEvent = "Microsoft.Media.LiveEventIngestHeartbeat";
        public const string MediaLiveEventTrackDiscontinuityDetectedEvent = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";

        // Resource Manager (Azure Subscription/Resource Group) events
        public const string ResourceWriteSuccessEvent = "Microsoft.Resources.ResourceWriteSuccess";
        public const string ResourceWriteFailureEvent = "Microsoft.Resources.ResourceWriteFailure";
        public const string ResourceWriteCancelEvent = "Microsoft.Resources.ResourceWriteCancel";
        public const string ResourceDeleteSuccessEvent = "Microsoft.Resources.ResourceDeleteSuccess";
        public const string ResourceDeleteFailureEvent = "Microsoft.Resources.ResourceDeleteFailure";
        public const string ResourceDeleteCancelEvent = "Microsoft.Resources.ResourceDeleteCancel";
        public const string ResourceActionSuccessEvent = "Microsoft.Resources.ResourceActionSuccess";
        public const string ResourceActionFailureEvent = "Microsoft.Resources.ResourceActionFailure";
        public const string ResourceActionCancelEvent = "Microsoft.Resources.ResourceActionCancel";

        // ServiceBus events
        public const string ServiceBusActiveMessagesAvailableWithNoListenersEvent = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";
        public const string ServiceBusDeadletterMessagesAvailableWithNoListenerEvent = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener";

        // Storage events
        public const string StorageBlobCreatedEvent = "Microsoft.Storage.BlobCreated";
        public const string StorageBlobDeletedEvent = "Microsoft.Storage.BlobDeleted";
        public const string StorageBlobRenamedEvent = "Microsoft.Storage.BlobRenamed";
        public const string StorageDirectoryCreatedEvent = "Microsoft.Storage.DirectoryCreated";
        public const string StorageDirectoryDeletedEvent = "Microsoft.Storage.DirectoryDeleted";
        public const string StorageDirectoryRenamedEvent = "Microsoft.Storage.DirectoryRenamed";

        // App Service
        public const string WebAppUpdated = "Microsoft.Web.AppUpdated";
        public const string WebBackupOperationStarted = "Microsoft.Web.BackupOperationStarted";
        public const string WebBackupOperationCompleted = "Microsoft.Web.BackupOperationCompleted";
        public const string WebBackupOperationFailed = "Microsoft.Web.BackupOperationFailed";
        public const string WebRestoreOperationStarted = "Microsoft.Web.RestoreOperationStarted";
        public const string WebRestoreOperationCompleted = "Microsoft.Web.RestoreOperationCompleted";
        public const string WebRestoreOperationFailed = "Microsoft.Web.RestoreOperationFailed";
        public const string WebSlotSwapStarted = "Microsoft.Web.SlotSwapStarted";
        public const string WebSlotSwapCompleted = "Microsoft.Web.SlotSwapCompleted";
        public const string WebSlotSwapFailed = "Microsoft.Web.SlotSwapFailed";
        public const string WebSlotSwapWithPreviewStarted = "Microsoft.Web.SlotSwapWithPreviewStarted";
        public const string WebSlotSwapWithPreviewCancelled = "Microsoft.Web.SlotSwapWithPreviewCancelled";
        public const string WebAppServicePlanUpdated = "Microsoft.Web.AppServicePlanUpdated";
    }
}
