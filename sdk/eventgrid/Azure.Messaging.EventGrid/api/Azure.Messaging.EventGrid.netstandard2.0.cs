namespace Azure.Messaging.EventGrid
{
    public partial class EventGridEvent
    {
        public EventGridEvent(string subject, string eventType, string dataVersion, System.BinaryData data) { }
        public EventGridEvent(string subject, string eventType, string dataVersion, object data, System.Type dataSerializationType = null) { }
        public System.BinaryData Data { get { throw null; } set { } }
        public string DataVersion { get { throw null; } set { } }
        public System.DateTimeOffset EventTime { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
        public static Azure.Messaging.EventGrid.EventGridEvent Parse(System.BinaryData jsonEvent) { throw null; }
        public static Azure.Messaging.EventGrid.EventGridEvent[] ParseEvents(string requestContent) { throw null; }
        public bool TryGetSystemEventData(out object eventData) { throw null; }
    }
    public static partial class EventGridExtensions
    {
        public static bool TryGetSystemEventData(this Azure.Messaging.CloudEvent cloudEvent, out object eventData) { throw null; }
    }
    public partial class EventGridPublisherClient
    {
        protected EventGridPublisherClient() { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options) { }
        public EventGridPublisherClient(System.Uri endpoint, Azure.AzureSasCredential credential, Azure.Messaging.EventGrid.EventGridPublisherClientOptions options = null) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response SendEncodedCloudEvents(System.ReadOnlyMemory<byte> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEncodedCloudEventsAsync(System.ReadOnlyMemory<byte> cloudEvents, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.EventGridEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SendEvents(System.Collections.Generic.IEnumerable<System.BinaryData> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.EventGridEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SendEventsAsync(System.Collections.Generic.IEnumerable<System.BinaryData> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridPublisherClientOptions : Azure.Core.ClientOptions
    {
        public EventGridPublisherClientOptions(Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion.V2018_01_01) { }
        public enum ServiceVersion
        {
            V2018_01_01 = 1,
        }
    }
    public partial class EventGridSasBuilder
    {
        public EventGridSasBuilder(System.Uri endpoint, System.DateTimeOffset expiresOn) { }
        public Azure.Messaging.EventGrid.EventGridPublisherClientOptions.ServiceVersion ApiVersion { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.DateTimeOffset ExpiresOn { get { throw null; } set { } }
        public string GenerateSas(Azure.AzureKeyCredential key) { throw null; }
    }
    public static partial class SystemEventNames
    {
        public const string AcsChatMessageDeleted = "Microsoft.Communication.ChatMessageDeleted";
        public const string AcsChatMessageDeletedInThread = "Microsoft.Communication.ChatMessageDeletedInThread";
        public const string AcsChatMessageEdited = "Microsoft.Communication.ChatMessageEdited";
        public const string AcsChatMessageEditedInThread = "Microsoft.Communication.ChatMessageEditedInThread";
        public const string AcsChatMessageReceived = "Microsoft.Communication.ChatMessageReceived";
        public const string AcsChatMessageReceivedInThread = "Microsoft.Communication.ChatMessageReceivedInThread";
        public const string AcsChatParticipantAddedToThread = "Microsoft.Communication.ChatParticipantAddedToThread";
        public const string AcsChatParticipantAddedToThreadWithUser = "Microsoft.Communication.ChatParticipantAddedToThreadWithUser";
        public const string AcsChatParticipantRemovedFromThread = "Microsoft.Communication.ChatParticipantRemovedFromThread";
        public const string AcsChatParticipantRemovedFromThreadWithUser = "Microsoft.Communication.ChatParticipantRemovedFromThreadWithUser";
        public const string AcsChatThreadCreated = "Microsoft.Communication.ChatThreadCreated";
        public const string AcsChatThreadCreatedWithUser = "Microsoft.Communication.ChatThreadCreatedWithUser";
        public const string AcsChatThreadDeleted = "Microsoft.Communication.ChatThreadDeleted";
        public const string AcsChatThreadPropertiesUpdated = "Microsoft.Communication.ChatThreadPropertiesUpdated";
        public const string AcsChatThreadPropertiesUpdatedPerUser = "Microsoft.Communication.ChatThreadPropertiesUpdatedPerUser";
        public const string AcsChatThreadWithUserDeleted = "Microsoft.Communication.ChatThreadWithUserDeleted";
        public const string AcsSmsDeliveryReportReceived = "Microsoft.Communication.SMSDeliveryReportReceived";
        public const string ACSSMSReceived = "Microsoft.Communication.SMSReceived";
        public const string AppConfigurationKeyValueDeleted = "Microsoft.AppConfiguration.KeyValueDeleted";
        public const string AppConfigurationKeyValueModified = "Microsoft.AppConfiguration.KeyValueModified";
        public const string ContainerRegistryChartDeleted = "Microsoft.ContainerRegistry.ChartDeleted";
        public const string ContainerRegistryChartPushed = "Microsoft.ContainerRegistry.ChartPushed";
        public const string ContainerRegistryImageDeleted = "Microsoft.ContainerRegistry.ImageDeleted";
        public const string ContainerRegistryImagePushed = "Microsoft.ContainerRegistry.ImagePushed";
        public const string EventGridSubscriptionDeleted = "Microsoft.EventGrid.SubscriptionDeletedEvent";
        public const string EventGridSubscriptionValidation = "Microsoft.EventGrid.SubscriptionValidationEvent";
        public const string EventHubCaptureFileCreated = "Microsoft.EventHub.CaptureFileCreated";
        public const string IoTHubDeviceConnected = "Microsoft.Devices.DeviceConnected";
        public const string IoTHubDeviceCreated = "Microsoft.Devices.DeviceCreated";
        public const string IoTHubDeviceDeleted = "Microsoft.Devices.DeviceDeleted";
        public const string IoTHubDeviceDisconnected = "Microsoft.Devices.DeviceDisconnected";
        public const string IotHubDeviceTelemetry = "Microsoft.Devices.DeviceTelemetry";
        public const string KeyVaultAccessPolicyChanged = "Microsoft.KeyVault.VaultAccessPolicyChanged";
        public const string KeyVaultCertificateExpired = "Microsoft.KeyVault.CertificateExpired";
        public const string KeyVaultCertificateNearExpiry = "Microsoft.KeyVault.CertificateNearExpiry";
        public const string KeyVaultCertificateNewVersionCreated = "Microsoft.KeyVault.CertificateNewVersionCreated";
        public const string KeyVaultKeyExpired = "Microsoft.KeyVault.KeyExpired";
        public const string KeyVaultKeyNearExpiry = "Microsoft.KeyVault.KeyNearExpiry";
        public const string KeyVaultKeyNewVersionCreated = "Microsoft.KeyVault.KeyNewVersionCreated";
        public const string KeyVaultSecretExpired = "Microsoft.KeyVault.SecretExpired";
        public const string KeyVaultSecretNearExpiry = "Microsoft.KeyVault.SecretNearExpiry";
        public const string KeyVaultSecretNewVersionCreated = "Microsoft.KeyVault.SecretNewVersionCreated";
        public const string MachineLearningServicesDatasetDriftDetected = "Microsoft.MachineLearningServices.DatasetDriftDetected";
        public const string MachineLearningServicesModelDeployed = "Microsoft.MachineLearningServices.ModelDeployed";
        public const string MachineLearningServicesModelRegistered = "Microsoft.MachineLearningServices.ModelRegistered";
        public const string MachineLearningServicesRunCompleted = "Microsoft.MachineLearningServices.RunCompleted";
        public const string MachineLearningServicesRunStatusChanged = "Microsoft.MachineLearningServices.RunStatusChanged";
        public const string MapsGeofenceEntered = "Microsoft.Maps.GeofenceEntered";
        public const string MapsGeofenceExited = "Microsoft.Maps.GeofenceExited";
        public const string MapsGeofenceResult = "Microsoft.Maps.GeofenceResult";
        public const string MediaJobCanceled = "Microsoft.Media.JobCanceled";
        public const string MediaJobCanceling = "Microsoft.Media.JobCanceling";
        public const string MediaJobErrored = "Microsoft.Media.JobErrored";
        public const string MediaJobFinished = "Microsoft.Media.JobFinished";
        public const string MediaJobOutputCanceled = "Microsoft.Media.JobOutputCanceled";
        public const string MediaJobOutputCanceling = "Microsoft.Media.JobOutputCanceling";
        public const string MediaJobOutputErrored = "Microsoft.Media.JobOutputErrored";
        public const string MediaJobOutputFinished = "Microsoft.Media.JobOutputFinished";
        public const string MediaJobOutputProcessing = "Microsoft.Media.JobOutputProcessing";
        public const string MediaJobOutputProgress = "Microsoft.Media.JobOutputProgress";
        public const string MediaJobOutputScheduled = "Microsoft.Media.JobOutputScheduled";
        public const string MediaJobOutputStateChange = "Microsoft.Media.JobOutputStateChange";
        public const string MediaJobProcessing = "Microsoft.Media.JobProcessing";
        public const string MediaJobScheduled = "Microsoft.Media.JobScheduled";
        public const string MediaJobStateChange = "Microsoft.Media.JobStateChange";
        public const string MediaLiveEventConnectionRejected = "Microsoft.Media.LiveEventConnectionRejected";
        public const string MediaLiveEventEncoderConnected = "Microsoft.Media.LiveEventEncoderConnected";
        public const string MediaLiveEventEncoderDisconnected = "Microsoft.Media.LiveEventEncoderDisconnected";
        public const string MediaLiveEventIncomingDataChunkDropped = "Microsoft.Media.LiveEventIncomingDataChunkDropped";
        public const string MediaLiveEventIncomingStreamReceived = "Microsoft.Media.LiveEventIncomingStreamReceived";
        public const string MediaLiveEventIncomingStreamsOutOfSync = "Microsoft.Media.LiveEventIncomingStreamsOutOfSync";
        public const string MediaLiveEventIncomingVideoStreamsOutOfSync = "Microsoft.Media.LiveEventIncomingVideoStreamsOutOfSync";
        public const string MediaLiveEventIngestHeartbeat = "Microsoft.Media.LiveEventIngestHeartbeat";
        public const string MediaLiveEventTrackDiscontinuityDetected = "Microsoft.Media.LiveEventTrackDiscontinuityDetected";
        public const string ResourceActionCancel = "Microsoft.Resources.ResourceActionCancel";
        public const string ResourceActionFailure = "Microsoft.Resources.ResourceActionFailure";
        public const string ResourceActionSuccess = "Microsoft.Resources.ResourceActionSuccess";
        public const string ResourceDeleteCancel = "Microsoft.Resources.ResourceDeleteCancel";
        public const string ResourceDeleteFailure = "Microsoft.Resources.ResourceDeleteFailure";
        public const string ResourceDeleteSuccess = "Microsoft.Resources.ResourceDeleteSuccess";
        public const string ResourceWriteCancel = "Microsoft.Resources.ResourceWriteCancel";
        public const string ResourceWriteFailure = "Microsoft.Resources.ResourceWriteFailure";
        public const string ResourceWriteSuccess = "Microsoft.Resources.ResourceWriteSuccess";
        public const string ServiceBusActiveMessagesAvailablePeriodicNotifications = "Microsoft.ServiceBus.ActiveMessagesAvailablePeriodicNotifications";
        public const string ServiceBusActiveMessagesAvailableWithNoListeners = "Microsoft.ServiceBus.ActiveMessagesAvailableWithNoListeners";
        public const string ServiceBusDeadletterMessagesAvailablePeriodicNotifications = "Microsoft.ServiceBus.DeadletterMessagesAvailablePeriodicNotifications";
        public const string ServiceBusDeadletterMessagesAvailableWithNoListener = "Microsoft.ServiceBus.DeadletterMessagesAvailableWithNoListener";
        public const string StorageBlobCreated = "Microsoft.Storage.BlobCreated";
        public const string StorageBlobDeleted = "Microsoft.Storage.BlobDeleted";
        public const string StorageBlobRenamed = "Microsoft.Storage.BlobRenamed";
        public const string StorageDirectoryCreated = "Microsoft.Storage.DirectoryCreated";
        public const string StorageDirectoryDeleted = "Microsoft.Storage.DirectoryDeleted";
        public const string StorageDirectoryRenamed = "Microsoft.Storage.DirectoryRenamed";
        public const string StorageLifecyclePolicyCompleted = "Microsoft.Storage.LifecyclePolicyCompleted";
        public const string WebAppServicePlanUpdated = "Microsoft.Web.AppServicePlanUpdated";
        public const string WebAppUpdated = "Microsoft.Web.AppUpdated";
        public const string WebBackupOperationCompleted = "Microsoft.Web.BackupOperationCompleted";
        public const string WebBackupOperationFailed = "Microsoft.Web.BackupOperationFailed";
        public const string WebBackupOperationStarted = "Microsoft.Web.BackupOperationStarted";
        public const string WebRestoreOperationCompleted = "Microsoft.Web.RestoreOperationCompleted";
        public const string WebRestoreOperationFailed = "Microsoft.Web.RestoreOperationFailed";
        public const string WebRestoreOperationStarted = "Microsoft.Web.RestoreOperationStarted";
        public const string WebSlotSwapCompleted = "Microsoft.Web.SlotSwapCompleted";
        public const string WebSlotSwapFailed = "Microsoft.Web.SlotSwapFailed";
        public const string WebSlotSwapStarted = "Microsoft.Web.SlotSwapStarted";
        public const string WebSlotSwapWithPreviewCancelled = "Microsoft.Web.SlotSwapWithPreviewCancelled";
        public const string WebSlotSwapWithPreviewStarted = "Microsoft.Web.SlotSwapWithPreviewStarted";
    }
}
namespace Azure.Messaging.EventGrid.SystemEvents
{
    public partial class AcsChatEventBaseProperties
    {
        internal AcsChatEventBaseProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel RecipientCommunicationIdentifier { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public string TransactionId { get { throw null; } }
    }
    public partial class AcsChatEventInThreadBaseProperties
    {
        internal AcsChatEventInThreadBaseProperties() { }
        public string ThreadId { get { throw null; } }
    }
    public partial class AcsChatMessageDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties
    {
        internal AcsChatMessageDeletedEventData() { }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
    }
    public partial class AcsChatMessageDeletedInThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties
    {
        internal AcsChatMessageDeletedInThreadEventData() { }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
    }
    public partial class AcsChatMessageEditedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties
    {
        internal AcsChatMessageEditedEventData() { }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public string MessageBody { get { throw null; } }
    }
    public partial class AcsChatMessageEditedInThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties
    {
        internal AcsChatMessageEditedInThreadEventData() { }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public string MessageBody { get { throw null; } }
    }
    public partial class AcsChatMessageEventBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties
    {
        internal AcsChatMessageEventBaseProperties() { }
        public System.DateTimeOffset? ComposeTime { get { throw null; } }
        public string MessageId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel SenderCommunicationIdentifier { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string Type { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class AcsChatMessageEventInThreadBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties
    {
        internal AcsChatMessageEventInThreadBaseProperties() { }
        public System.DateTimeOffset? ComposeTime { get { throw null; } }
        public string MessageId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel SenderCommunicationIdentifier { get { throw null; } }
        public string SenderDisplayName { get { throw null; } }
        public string Type { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class AcsChatMessageReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventBaseProperties
    {
        internal AcsChatMessageReceivedEventData() { }
        public string MessageBody { get { throw null; } }
    }
    public partial class AcsChatMessageReceivedInThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatMessageEventInThreadBaseProperties
    {
        internal AcsChatMessageReceivedInThreadEventData() { }
        public string MessageBody { get { throw null; } }
    }
    public partial class AcsChatParticipantAddedToThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties
    {
        internal AcsChatParticipantAddedToThreadEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel AddedByCommunicationIdentifier { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantAdded { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class AcsChatParticipantAddedToThreadWithUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties
    {
        internal AcsChatParticipantAddedToThreadWithUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel AddedByCommunicationIdentifier { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantAdded { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class AcsChatParticipantRemovedFromThreadEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties
    {
        internal AcsChatParticipantRemovedFromThreadEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantRemoved { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel RemovedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class AcsChatParticipantRemovedFromThreadWithUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties
    {
        internal AcsChatParticipantRemovedFromThreadWithUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties ParticipantRemoved { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel RemovedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } }
    }
    public partial class AcsChatThreadCreatedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties
    {
        internal AcsChatThreadCreatedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel CreatedByCommunicationIdentifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> Participants { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class AcsChatThreadCreatedWithUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties
    {
        internal AcsChatThreadCreatedWithUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel CreatedByCommunicationIdentifier { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadParticipantProperties> Participants { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class AcsChatThreadDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties
    {
        internal AcsChatThreadDeletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel DeletedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
    }
    public partial class AcsChatThreadEventBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventBaseProperties
    {
        internal AcsChatThreadEventBaseProperties() { }
        public System.DateTimeOffset? CreateTime { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class AcsChatThreadEventInThreadBaseProperties : Azure.Messaging.EventGrid.SystemEvents.AcsChatEventInThreadBaseProperties
    {
        internal AcsChatThreadEventInThreadBaseProperties() { }
        public System.DateTimeOffset? CreateTime { get { throw null; } }
        public long? Version { get { throw null; } }
    }
    public partial class AcsChatThreadParticipantProperties
    {
        internal AcsChatThreadParticipantProperties() { }
        public string DisplayName { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel ParticipantCommunicationIdentifier { get { throw null; } }
    }
    public partial class AcsChatThreadPropertiesUpdatedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventInThreadBaseProperties
    {
        internal AcsChatThreadPropertiesUpdatedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel EditedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class AcsChatThreadPropertiesUpdatedPerUserEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties
    {
        internal AcsChatThreadPropertiesUpdatedPerUserEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel EditedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? EditTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object> Properties { get { throw null; } }
    }
    public partial class AcsChatThreadWithUserDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsChatThreadEventBaseProperties
    {
        internal AcsChatThreadWithUserDeletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationIdentifierModel DeletedByCommunicationIdentifier { get { throw null; } }
        public System.DateTimeOffset? DeleteTime { get { throw null; } }
    }
    public partial class AcsSmsDeliveryAttemptProperties
    {
        internal AcsSmsDeliveryAttemptProperties() { }
        public int? SegmentsFailed { get { throw null; } }
        public int? SegmentsSucceeded { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class AcsSmsDeliveryReportReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties
    {
        internal AcsSmsDeliveryReportReceivedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.AcsSmsDeliveryAttemptProperties> DeliveryAttempts { get { throw null; } }
        public string DeliveryStatus { get { throw null; } }
        public string DeliveryStatusDetails { get { throw null; } }
        public System.DateTimeOffset? ReceivedTimestamp { get { throw null; } }
    }
    public partial class AcsSmsEventBaseProperties
    {
        internal AcsSmsEventBaseProperties() { }
        public string From { get { throw null; } }
        public string MessageId { get { throw null; } }
        public string To { get { throw null; } }
    }
    public partial class AcsSmsReceivedEventData : Azure.Messaging.EventGrid.SystemEvents.AcsSmsEventBaseProperties
    {
        internal AcsSmsReceivedEventData() { }
        public string Message { get { throw null; } }
        public System.DateTimeOffset? ReceivedTimestamp { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppAction : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AppAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppAction(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction ChangedAppSettings { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Restarted { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Started { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AppAction Stopped { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AppAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AppAction left, Azure.Messaging.EventGrid.SystemEvents.AppAction right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AppAction (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AppAction left, Azure.Messaging.EventGrid.SystemEvents.AppAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppConfigurationKeyValueDeletedEventData
    {
        internal AppConfigurationKeyValueDeletedEventData() { }
        public string Etag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public string SyncToken { get { throw null; } }
    }
    public partial class AppConfigurationKeyValueModifiedEventData
    {
        internal AppConfigurationKeyValueModifiedEventData() { }
        public string Etag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
        public string SyncToken { get { throw null; } }
    }
    public partial class AppEventTypeDetail
    {
        internal AppEventTypeDetail() { }
        public Azure.Messaging.EventGrid.SystemEvents.AppAction? Action { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppServicePlanAction : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppServicePlanAction(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction Updated { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction left, Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction left, Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppServicePlanEventTypeDetail
    {
        internal AppServicePlanEventTypeDetail() { }
        public Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction? Action { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StampKind? StampKind { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AsyncStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AsyncStatus : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.AsyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AsyncStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.AsyncStatus Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AsyncStatus Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.AsyncStatus Started { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus left, Azure.Messaging.EventGrid.SystemEvents.AsyncStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.AsyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.AsyncStatus left, Azure.Messaging.EventGrid.SystemEvents.AsyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CommunicationCloudEnvironmentModel : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CommunicationCloudEnvironmentModel(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel Dod { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel Gcch { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel Public { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel left, Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel left, Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CommunicationIdentifierModel
    {
        internal CommunicationIdentifierModel() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationUserIdentifierModel CommunicationUser { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MicrosoftTeamsUserIdentifierModel MicrosoftTeamsUser { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.PhoneNumberIdentifierModel PhoneNumber { get { throw null; } }
        public string RawId { get { throw null; } }
    }
    public partial class CommunicationUserIdentifierModel
    {
        internal CommunicationUserIdentifierModel() { }
        public string Id { get { throw null; } }
    }
    public partial class ContainerRegistryArtifactEventData
    {
        internal ContainerRegistryArtifactEventData() { }
        public string Action { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventTarget Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ContainerRegistryArtifactEventTarget
    {
        internal ContainerRegistryArtifactEventTarget() { }
        public string Digest { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Name { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class ContainerRegistryChartDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData
    {
        internal ContainerRegistryChartDeletedEventData() { }
    }
    public partial class ContainerRegistryChartPushedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryArtifactEventData
    {
        internal ContainerRegistryChartPushedEventData() { }
    }
    public partial class ContainerRegistryEventActor
    {
        internal ContainerRegistryEventActor() { }
        public string Name { get { throw null; } }
    }
    public partial class ContainerRegistryEventData
    {
        internal ContainerRegistryEventData() { }
        public string Action { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventActor Actor { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventRequest Request { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventSource Source { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventTarget Target { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ContainerRegistryEventRequest
    {
        internal ContainerRegistryEventRequest() { }
        public string Addr { get { throw null; } }
        public string Host { get { throw null; } }
        public string Id { get { throw null; } }
        public string Method { get { throw null; } }
        public string Useragent { get { throw null; } }
    }
    public partial class ContainerRegistryEventSource
    {
        internal ContainerRegistryEventSource() { }
        public string Addr { get { throw null; } }
        public string InstanceID { get { throw null; } }
    }
    public partial class ContainerRegistryEventTarget
    {
        internal ContainerRegistryEventTarget() { }
        public string Digest { get { throw null; } }
        public long? Length { get { throw null; } }
        public string MediaType { get { throw null; } }
        public string Repository { get { throw null; } }
        public long? Size { get { throw null; } }
        public string Tag { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class ContainerRegistryImageDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData
    {
        internal ContainerRegistryImageDeletedEventData() { }
    }
    public partial class ContainerRegistryImagePushedEventData : Azure.Messaging.EventGrid.SystemEvents.ContainerRegistryEventData
    {
        internal ContainerRegistryImagePushedEventData() { }
    }
    public partial class DeviceConnectionStateEventInfo
    {
        internal DeviceConnectionStateEventInfo() { }
        public string SequenceNumber { get { throw null; } }
    }
    public partial class DeviceConnectionStateEventProperties
    {
        internal DeviceConnectionStateEventProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventInfo DeviceConnectionStateEventInfo { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string HubName { get { throw null; } }
        public string ModuleId { get { throw null; } }
    }
    public partial class DeviceLifeCycleEventProperties
    {
        internal DeviceLifeCycleEventProperties() { }
        public string DeviceId { get { throw null; } }
        public string HubName { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfo Twin { get { throw null; } }
    }
    public partial class DeviceTelemetryEventProperties
    {
        internal DeviceTelemetryEventProperties() { }
        public object Body { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SystemProperties { get { throw null; } }
    }
    public partial class DeviceTwinInfo
    {
        internal DeviceTwinInfo() { }
        public string AuthenticationType { get { throw null; } }
        public float? CloudToDeviceMessageCount { get { throw null; } }
        public string ConnectionState { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string Etag { get { throw null; } }
        public string LastActivityTime { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoProperties Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusUpdateTime { get { throw null; } }
        public float? Version { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinInfoX509Thumbprint X509Thumbprint { get { throw null; } }
    }
    public partial class DeviceTwinInfoProperties
    {
        internal DeviceTwinInfoProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties Desired { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinProperties Reported { get { throw null; } }
    }
    public partial class DeviceTwinInfoX509Thumbprint
    {
        internal DeviceTwinInfoX509Thumbprint() { }
        public string PrimaryThumbprint { get { throw null; } }
        public string SecondaryThumbprint { get { throw null; } }
    }
    public partial class DeviceTwinMetadata
    {
        internal DeviceTwinMetadata() { }
        public string LastUpdated { get { throw null; } }
    }
    public partial class DeviceTwinProperties
    {
        internal DeviceTwinProperties() { }
        public Azure.Messaging.EventGrid.SystemEvents.DeviceTwinMetadata Metadata { get { throw null; } }
        public float? Version { get { throw null; } }
    }
    public partial class EventHubCaptureFileCreatedEventData
    {
        internal EventHubCaptureFileCreatedEventData() { }
        public int? EventCount { get { throw null; } }
        public string FileType { get { throw null; } }
        public string Fileurl { get { throw null; } }
        public System.DateTimeOffset? FirstEnqueueTime { get { throw null; } }
        public int? FirstSequenceNumber { get { throw null; } }
        public System.DateTimeOffset? LastEnqueueTime { get { throw null; } }
        public int? LastSequenceNumber { get { throw null; } }
        public string PartitionId { get { throw null; } }
        public int? SizeInBytes { get { throw null; } }
    }
    public partial class IotHubDeviceConnectedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties
    {
        internal IotHubDeviceConnectedEventData() { }
    }
    public partial class IotHubDeviceCreatedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties
    {
        internal IotHubDeviceCreatedEventData() { }
    }
    public partial class IotHubDeviceDeletedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceLifeCycleEventProperties
    {
        internal IotHubDeviceDeletedEventData() { }
    }
    public partial class IotHubDeviceDisconnectedEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceConnectionStateEventProperties
    {
        internal IotHubDeviceDisconnectedEventData() { }
    }
    public partial class IotHubDeviceTelemetryEventData : Azure.Messaging.EventGrid.SystemEvents.DeviceTelemetryEventProperties
    {
        internal IotHubDeviceTelemetryEventData() { }
    }
    public partial class KeyVaultAccessPolicyChangedEventData
    {
        internal KeyVaultAccessPolicyChangedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultCertificateExpiredEventData
    {
        internal KeyVaultCertificateExpiredEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultCertificateNearExpiryEventData
    {
        internal KeyVaultCertificateNearExpiryEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultCertificateNewVersionCreatedEventData
    {
        internal KeyVaultCertificateNewVersionCreatedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultKeyExpiredEventData
    {
        internal KeyVaultKeyExpiredEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultKeyNearExpiryEventData
    {
        internal KeyVaultKeyNearExpiryEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultKeyNewVersionCreatedEventData
    {
        internal KeyVaultKeyNewVersionCreatedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultSecretExpiredEventData
    {
        internal KeyVaultSecretExpiredEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultSecretNearExpiryEventData
    {
        internal KeyVaultSecretNearExpiryEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class KeyVaultSecretNewVersionCreatedEventData
    {
        internal KeyVaultSecretNewVersionCreatedEventData() { }
        public float? Exp { get { throw null; } }
        public string Id { get { throw null; } }
        public float? Nbf { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public string ObjectType { get { throw null; } }
        public string VaultName { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public partial class MachineLearningServicesDatasetDriftDetectedEventData
    {
        internal MachineLearningServicesDatasetDriftDetectedEventData() { }
        public string BaseDatasetId { get { throw null; } }
        public string DataDriftId { get { throw null; } }
        public string DataDriftName { get { throw null; } }
        public double? DriftCoefficient { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string RunId { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public string TargetDatasetId { get { throw null; } }
    }
    public partial class MachineLearningServicesModelDeployedEventData
    {
        internal MachineLearningServicesModelDeployedEventData() { }
        public string ModelIds { get { throw null; } }
        public string ServiceComputeType { get { throw null; } }
        public string ServiceName { get { throw null; } }
        public object ServiceProperties { get { throw null; } }
        public object ServiceTags { get { throw null; } }
    }
    public partial class MachineLearningServicesModelRegisteredEventData
    {
        internal MachineLearningServicesModelRegisteredEventData() { }
        public string ModelName { get { throw null; } }
        public object ModelProperties { get { throw null; } }
        public object ModelTags { get { throw null; } }
        public string ModelVersion { get { throw null; } }
    }
    public partial class MachineLearningServicesRunCompletedEventData
    {
        internal MachineLearningServicesRunCompletedEventData() { }
        public string ExperimentId { get { throw null; } }
        public string ExperimentName { get { throw null; } }
        public string RunId { get { throw null; } }
        public object RunProperties { get { throw null; } }
        public object RunTags { get { throw null; } }
        public string RunType { get { throw null; } }
    }
    public partial class MachineLearningServicesRunStatusChangedEventData
    {
        internal MachineLearningServicesRunStatusChangedEventData() { }
        public string ExperimentId { get { throw null; } }
        public string ExperimentName { get { throw null; } }
        public string RunId { get { throw null; } }
        public object RunProperties { get { throw null; } }
        public string RunStatus { get { throw null; } }
        public object RunTags { get { throw null; } }
        public string RunType { get { throw null; } }
    }
    public partial class MapsGeofenceEnteredEventData : Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties
    {
        internal MapsGeofenceEnteredEventData() { }
    }
    public partial class MapsGeofenceEventProperties
    {
        internal MapsGeofenceEventProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ExpiredGeofenceGeometryId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceGeometry> Geometries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InvalidPeriodGeofenceGeometryId { get { throw null; } }
        public bool? IsEventPublished { get { throw null; } }
    }
    public partial class MapsGeofenceExitedEventData : Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties
    {
        internal MapsGeofenceExitedEventData() { }
    }
    public partial class MapsGeofenceGeometry
    {
        internal MapsGeofenceGeometry() { }
        public string DeviceId { get { throw null; } }
        public float? Distance { get { throw null; } }
        public string GeometryId { get { throw null; } }
        public float? NearestLat { get { throw null; } }
        public float? NearestLon { get { throw null; } }
        public string UdId { get { throw null; } }
    }
    public partial class MapsGeofenceResultEventData : Azure.Messaging.EventGrid.SystemEvents.MapsGeofenceEventProperties
    {
        internal MapsGeofenceResultEventData() { }
    }
    public partial class MediaJobCanceledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobCanceledEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
    }
    public partial class MediaJobCancelingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobCancelingEventData() { }
    }
    public partial class MediaJobError
    {
        internal MediaJobError() { }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCategory? Category { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCode? Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobRetry? Retry { get { throw null; } }
    }
    public enum MediaJobErrorCategory
    {
        Service = 0,
        Download = 1,
        Upload = 2,
        Configuration = 3,
        Content = 4,
    }
    public enum MediaJobErrorCode
    {
        ServiceError = 0,
        ServiceTransientError = 1,
        DownloadNotAccessible = 2,
        DownloadTransientError = 3,
        UploadNotAccessible = 4,
        UploadTransientError = 5,
        ConfigurationUnsupported = 6,
        ContentMalformed = 7,
        ContentUnsupported = 8,
    }
    public partial class MediaJobErrorDetail
    {
        internal MediaJobErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class MediaJobErroredEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobErroredEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
    }
    public partial class MediaJobFinishedEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobFinishedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
    }
    public partial class MediaJobOutput
    {
        internal MediaJobOutput() { }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobError Error { get { throw null; } }
        public string Label { get { throw null; } }
        public long Progress { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState State { get { throw null; } }
    }
    public partial class MediaJobOutputAsset : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput
    {
        internal MediaJobOutputAsset() { }
        public string AssetName { get { throw null; } }
    }
    public partial class MediaJobOutputCanceledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputCanceledEventData() { }
    }
    public partial class MediaJobOutputCancelingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputCancelingEventData() { }
    }
    public partial class MediaJobOutputErroredEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputErroredEventData() { }
    }
    public partial class MediaJobOutputFinishedEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputFinishedEventData() { }
    }
    public partial class MediaJobOutputProcessingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputProcessingEventData() { }
    }
    public partial class MediaJobOutputProgressEventData
    {
        internal MediaJobOutputProgressEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobCorrelationData { get { throw null; } }
        public string Label { get { throw null; } }
        public long? Progress { get { throw null; } }
    }
    public partial class MediaJobOutputScheduledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputScheduledEventData() { }
    }
    public partial class MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputStateChangeEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobCorrelationData { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobOutput Output { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? PreviousState { get { throw null; } }
    }
    public partial class MediaJobProcessingEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobProcessingEventData() { }
    }
    public enum MediaJobRetry
    {
        DoNotRetry = 0,
        MayRetry = 1,
    }
    public partial class MediaJobScheduledEventData : Azure.Messaging.EventGrid.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobScheduledEventData() { }
    }
    public enum MediaJobState
    {
        Canceled = 0,
        Canceling = 1,
        Error = 2,
        Finished = 3,
        Processing = 4,
        Queued = 5,
        Scheduled = 6,
    }
    public partial class MediaJobStateChangeEventData
    {
        internal MediaJobStateChangeEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> CorrelationData { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? PreviousState { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? State { get { throw null; } }
    }
    public partial class MediaLiveEventConnectionRejectedEventData
    {
        internal MediaLiveEventConnectionRejectedEventData() { }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string ResultCode { get { throw null; } }
        public string StreamId { get { throw null; } }
    }
    public partial class MediaLiveEventEncoderConnectedEventData
    {
        internal MediaLiveEventEncoderConnectedEventData() { }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string StreamId { get { throw null; } }
    }
    public partial class MediaLiveEventEncoderDisconnectedEventData
    {
        internal MediaLiveEventEncoderDisconnectedEventData() { }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string ResultCode { get { throw null; } }
        public string StreamId { get { throw null; } }
    }
    public partial class MediaLiveEventIncomingDataChunkDroppedEventData
    {
        internal MediaLiveEventIncomingDataChunkDroppedEventData() { }
        public long? Bitrate { get { throw null; } }
        public string ResultCode { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
    }
    public partial class MediaLiveEventIncomingStreamReceivedEventData
    {
        internal MediaLiveEventIncomingStreamReceivedEventData() { }
        public long? Bitrate { get { throw null; } }
        public string Duration { get { throw null; } }
        public string EncoderIp { get { throw null; } }
        public string EncoderPort { get { throw null; } }
        public string IngestUrl { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string Timestamp { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
    }
    public partial class MediaLiveEventIncomingStreamsOutOfSyncEventData
    {
        internal MediaLiveEventIncomingStreamsOutOfSyncEventData() { }
        public string MaxLastTimestamp { get { throw null; } }
        public string MinLastTimestamp { get { throw null; } }
        public string TimescaleOfMaxLastTimestamp { get { throw null; } }
        public string TimescaleOfMinLastTimestamp { get { throw null; } }
        public string TypeOfStreamWithMaxLastTimestamp { get { throw null; } }
        public string TypeOfStreamWithMinLastTimestamp { get { throw null; } }
    }
    public partial class MediaLiveEventIncomingVideoStreamsOutOfSyncEventData
    {
        internal MediaLiveEventIncomingVideoStreamsOutOfSyncEventData() { }
        public string FirstDuration { get { throw null; } }
        public string FirstTimestamp { get { throw null; } }
        public string SecondDuration { get { throw null; } }
        public string SecondTimestamp { get { throw null; } }
        public string Timescale { get { throw null; } }
    }
    public partial class MediaLiveEventIngestHeartbeatEventData
    {
        internal MediaLiveEventIngestHeartbeatEventData() { }
        public long? Bitrate { get { throw null; } }
        public long? DiscontinuityCount { get { throw null; } }
        public bool? Healthy { get { throw null; } }
        public long? IncomingBitrate { get { throw null; } }
        public string LastTimestamp { get { throw null; } }
        public long? NonincreasingCount { get { throw null; } }
        public long? OverlapCount { get { throw null; } }
        public string State { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
        public bool? UnexpectedBitrate { get { throw null; } }
    }
    public partial class MediaLiveEventTrackDiscontinuityDetectedEventData
    {
        internal MediaLiveEventTrackDiscontinuityDetectedEventData() { }
        public long? Bitrate { get { throw null; } }
        public string DiscontinuityGap { get { throw null; } }
        public string NewTimestamp { get { throw null; } }
        public string PreviousTimestamp { get { throw null; } }
        public string Timescale { get { throw null; } }
        public string TrackName { get { throw null; } }
        public string TrackType { get { throw null; } }
    }
    public partial class MicrosoftTeamsUserIdentifierModel
    {
        internal MicrosoftTeamsUserIdentifierModel() { }
        public Azure.Messaging.EventGrid.SystemEvents.CommunicationCloudEnvironmentModel? Cloud { get { throw null; } }
        public bool? IsAnonymous { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public partial class PhoneNumberIdentifierModel
    {
        internal PhoneNumberIdentifierModel() { }
        public string Value { get { throw null; } }
    }
    public partial class RedisExportRDBCompletedEventData
    {
        internal RedisExportRDBCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class RedisImportRDBCompletedEventData
    {
        internal RedisImportRDBCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class RedisPatchingCompletedEventData
    {
        internal RedisPatchingCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class RedisScalingCompletedEventData
    {
        internal RedisScalingCompletedEventData() { }
        public string Name { get { throw null; } }
        public string Status { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
    }
    public partial class ResourceActionCancelEventData
    {
        internal ResourceActionCancelEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceActionFailureEventData
    {
        internal ResourceActionFailureEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceActionSuccessEventData
    {
        internal ResourceActionSuccessEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceDeleteCancelEventData
    {
        internal ResourceDeleteCancelEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceDeleteFailureEventData
    {
        internal ResourceDeleteFailureEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceDeleteSuccessEventData
    {
        internal ResourceDeleteSuccessEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceWriteCancelEventData
    {
        internal ResourceWriteCancelEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceWriteFailureEventData
    {
        internal ResourceWriteFailureEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ResourceWriteSuccessEventData
    {
        internal ResourceWriteSuccessEventData() { }
        public string Authorization { get { throw null; } }
        public string Claims { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public string HttpRequest { get { throw null; } }
        public string OperationName { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceProvider { get { throw null; } }
        public string ResourceUri { get { throw null; } }
        public string Status { get { throw null; } }
        public string SubscriptionId { get { throw null; } }
        public string TenantId { get { throw null; } }
    }
    public partial class ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData
    {
        internal ServiceBusActiveMessagesAvailablePeriodicNotificationsEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
    }
    public partial class ServiceBusActiveMessagesAvailableWithNoListenersEventData
    {
        internal ServiceBusActiveMessagesAvailableWithNoListenersEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
    }
    public partial class ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData
    {
        internal ServiceBusDeadletterMessagesAvailablePeriodicNotificationsEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
    }
    public partial class ServiceBusDeadletterMessagesAvailableWithNoListenersEventData
    {
        internal ServiceBusDeadletterMessagesAvailableWithNoListenersEventData() { }
        public string EntityType { get { throw null; } }
        public string NamespaceName { get { throw null; } }
        public string QueueName { get { throw null; } }
        public string RequestUri { get { throw null; } }
        public string SubscriptionName { get { throw null; } }
        public string TopicName { get { throw null; } }
    }
    public partial class SignalRServiceClientConnectionConnectedEventData
    {
        internal SignalRServiceClientConnectionConnectedEventData() { }
        public string ConnectionId { get { throw null; } }
        public string HubName { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    public partial class SignalRServiceClientConnectionDisconnectedEventData
    {
        internal SignalRServiceClientConnectionDisconnectedEventData() { }
        public string ConnectionId { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string HubName { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public string UserId { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StampKind : System.IEquatable<Azure.Messaging.EventGrid.SystemEvents.StampKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StampKind(string value) { throw null; }
        public static Azure.Messaging.EventGrid.SystemEvents.StampKind AseV1 { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.StampKind AseV2 { get { throw null; } }
        public static Azure.Messaging.EventGrid.SystemEvents.StampKind Public { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.SystemEvents.StampKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.SystemEvents.StampKind left, Azure.Messaging.EventGrid.SystemEvents.StampKind right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.SystemEvents.StampKind (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.SystemEvents.StampKind left, Azure.Messaging.EventGrid.SystemEvents.StampKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class StorageBlobCreatedEventData
    {
        internal StorageBlobCreatedEventData() { }
        public string Api { get { throw null; } }
        public string BlobType { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public long? ContentLength { get { throw null; } }
        public long? ContentOffset { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class StorageBlobDeletedEventData
    {
        internal StorageBlobDeletedEventData() { }
        public string Api { get { throw null; } }
        public string BlobType { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string ContentType { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class StorageBlobRenamedEventData
    {
        internal StorageBlobRenamedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string DestinationUrl { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public string SourceUrl { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
    }
    public partial class StorageDirectoryCreatedEventData
    {
        internal StorageDirectoryCreatedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class StorageDirectoryDeletedEventData
    {
        internal StorageDirectoryDeletedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string Identity { get { throw null; } }
        public bool? Recursive { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class StorageDirectoryRenamedEventData
    {
        internal StorageDirectoryRenamedEventData() { }
        public string Api { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string DestinationUrl { get { throw null; } }
        public string Identity { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Sequencer { get { throw null; } }
        public string SourceUrl { get { throw null; } }
        public object StorageDiagnostics { get { throw null; } }
    }
    public partial class StorageLifecyclePolicyActionSummaryDetail
    {
        internal StorageLifecyclePolicyActionSummaryDetail() { }
        public string ErrorList { get { throw null; } }
        public long? SuccessCount { get { throw null; } }
        public long? TotalObjectsCount { get { throw null; } }
    }
    public partial class StorageLifecyclePolicyCompletedEventData
    {
        internal StorageLifecyclePolicyCompletedEventData() { }
        public Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail DeleteSummary { get { throw null; } }
        public string ScheduleTime { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail TierToArchiveSummary { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StorageLifecyclePolicyActionSummaryDetail TierToCoolSummary { get { throw null; } }
    }
    public partial class SubscriptionDeletedEventData
    {
        internal SubscriptionDeletedEventData() { }
        public string EventSubscriptionId { get { throw null; } }
    }
    public partial class SubscriptionValidationEventData
    {
        internal SubscriptionValidationEventData() { }
        public string ValidationCode { get { throw null; } }
        public string ValidationUrl { get { throw null; } }
    }
    public partial class SubscriptionValidationResponse
    {
        internal SubscriptionValidationResponse() { }
        public string ValidationResponse { get { throw null; } }
    }
    public partial class WebAppServicePlanUpdatedEventData
    {
        internal WebAppServicePlanUpdatedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppServicePlanEventTypeDetail AppServicePlanEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.WebAppServicePlanUpdatedEventDataSku Sku { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebAppServicePlanUpdatedEventDataSku
    {
        internal WebAppServicePlanUpdatedEventDataSku() { }
        public string Capacity { get { throw null; } }
        public string Family { get { throw null; } }
        public string Name { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
    }
    public partial class WebAppUpdatedEventData
    {
        internal WebAppUpdatedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebBackupOperationCompletedEventData
    {
        internal WebBackupOperationCompletedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebBackupOperationFailedEventData
    {
        internal WebBackupOperationFailedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebBackupOperationStartedEventData
    {
        internal WebBackupOperationStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebRestoreOperationCompletedEventData
    {
        internal WebRestoreOperationCompletedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebRestoreOperationFailedEventData
    {
        internal WebRestoreOperationFailedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebRestoreOperationStartedEventData
    {
        internal WebRestoreOperationStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebSlotSwapCompletedEventData
    {
        internal WebSlotSwapCompletedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebSlotSwapFailedEventData
    {
        internal WebSlotSwapFailedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebSlotSwapStartedEventData
    {
        internal WebSlotSwapStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebSlotSwapWithPreviewCancelledEventData
    {
        internal WebSlotSwapWithPreviewCancelledEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
    public partial class WebSlotSwapWithPreviewStartedEventData
    {
        internal WebSlotSwapWithPreviewStartedEventData() { }
        public string Address { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class EventGridPublisherClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureSasCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.Messaging.EventGrid.EventGridPublisherClient, Azure.Messaging.EventGrid.EventGridPublisherClientOptions> AddEventGridPublisherClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
