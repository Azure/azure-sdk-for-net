namespace Azure.Messaging.EventGrid
{
    public partial class EventGridClient
    {
        protected EventGridClient() { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.Messaging.EventGrid.EventGridClientOptions options) { }
        public EventGridClient(System.Uri endpoint, Azure.Messaging.EventGrid.SharedAccessSignatureCredential credential) { }
        public EventGridClient(System.Uri endpoint, Azure.Messaging.EventGrid.SharedAccessSignatureCredential credential, Azure.Messaging.EventGrid.EventGridClientOptions options) { }
        public string BuildSharedAccessSignature(System.DateTimeOffset expirationUtc) { throw null; }
        public virtual Azure.Response PublishCloudEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCloudEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.CloudEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishCustomEvents(System.Collections.Generic.IEnumerable<object> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishCustomEventsAsync(System.Collections.Generic.IEnumerable<object> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response PublishEvents(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.EventGridEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> PublishEventsAsync(System.Collections.Generic.IEnumerable<Azure.Messaging.EventGrid.Models.EventGridEvent> events, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class EventGridClientOptions : Azure.Core.ClientOptions
    {
        public EventGridClientOptions(Azure.Messaging.EventGrid.EventGridClientOptions.ServiceVersion version = Azure.Messaging.EventGrid.EventGridClientOptions.ServiceVersion.V2018_01_01) { }
        public Azure.Core.ObjectSerializer Serializer { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2018_01_01 = 1,
        }
    }
    public partial class SharedAccessSignatureCredential
    {
        public SharedAccessSignatureCredential(string signature) { }
        public string Signature { get { throw null; } }
    }
}
namespace Azure.Messaging.EventGrid.Models
{
    public partial class CloudEvent : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.Generic.IDictionary<string, object>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, object>>, System.Collections.IEnumerable
    {
        public CloudEvent(string id, string source, string type, string specversion) { }
        public object Data { get { throw null; } set { } }
        public string DataBase64 { get { throw null; } set { } }
        public string Datacontenttype { get { throw null; } set { } }
        public string Dataschema { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public object this[string key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<string> Keys { get { throw null; } }
        public string Source { get { throw null; } set { } }
        public string Specversion { get { throw null; } set { } }
        public string Subject { get { throw null; } set { } }
        int System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Count { get { throw null; } }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.IsReadOnly { get { throw null; } }
        public System.DateTimeOffset? Time { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<object> Values { get { throw null; } }
        public void Add(string key, object value) { }
        public bool ContainsKey(string key) { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, object>> GetEnumerator() { throw null; }
        public bool Remove(string key) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Add(System.Collections.Generic.KeyValuePair<string, object> value) { }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Clear() { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Contains(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        void System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.CopyTo(System.Collections.Generic.KeyValuePair<string, object>[] destination, int offset) { }
        bool System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<System.String,System.Object>>.Remove(System.Collections.Generic.KeyValuePair<string, object> value) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(string key, out object value) { throw null; }
    }
    public partial class EventGridEvent
    {
        public EventGridEvent(string id, string subject, object data, string eventType, System.DateTimeOffset eventTime, string dataVersion) { }
        public object Data { get { throw null; } set { } }
        public string DataVersion { get { throw null; } set { } }
        public System.DateTimeOffset EventTime { get { throw null; } set { } }
        public string EventType { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string MetadataVersion { get { throw null; } }
        public string Subject { get { throw null; } set { } }
        public string Topic { get { throw null; } set { } }
    }
}
namespace Azure.Messaging.EventGrid.Models.SystemEvents
{
    public partial class AppConfigurationKeyValueDeletedEventData
    {
        internal AppConfigurationKeyValueDeletedEventData() { }
        public string Etag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class AppConfigurationKeyValueModifiedEventData
    {
        internal AppConfigurationKeyValueModifiedEventData() { }
        public string Etag { get { throw null; } }
        public string Key { get { throw null; } }
        public string Label { get { throw null; } }
    }
    public partial class AppEventTypeDetail
    {
        internal AppEventTypeDetail() { }
        public Azure.Messaging.EventGrid.SystemEvents.AppAction? Action { get { throw null; } }
    }
    public partial class AppServicePlanEventTypeDetail
    {
        internal AppServicePlanEventTypeDetail() { }
        public Azure.Messaging.EventGrid.SystemEvents.AppServicePlanAction? Action { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.StampKind? StampKind { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus? Status { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AsyncStatus : System.IEquatable<Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AsyncStatus(string value) { throw null; }
        public static Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus Completed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus Failed { get { throw null; } }
        public static Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus Started { get { throw null; } }
        public bool Equals(Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus left, Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus right) { throw null; }
        public static implicit operator Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus (string value) { throw null; }
        public static bool operator !=(Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus left, Azure.Messaging.EventGrid.Models.SystemEvents.AsyncStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ContainerRegistryArtifactEventData
    {
        internal ContainerRegistryArtifactEventData() { }
        public string Action { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryArtifactEventTarget Target { get { throw null; } }
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
    public partial class ContainerRegistryChartDeletedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryArtifactEventData
    {
        internal ContainerRegistryChartDeletedEventData() { }
    }
    public partial class ContainerRegistryChartPushedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryArtifactEventData
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryEventActor Actor { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryEventRequest Request { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryEventSource Source { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryEventTarget Target { get { throw null; } }
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
    public partial class ContainerRegistryImageDeletedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryEventData
    {
        internal ContainerRegistryImageDeletedEventData() { }
    }
    public partial class ContainerRegistryImagePushedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.ContainerRegistryEventData
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceConnectionStateEventInfo DeviceConnectionStateEventInfo { get { throw null; } }
        public string DeviceId { get { throw null; } }
        public string HubName { get { throw null; } }
        public string ModuleId { get { throw null; } }
    }
    public partial class DeviceLifeCycleEventProperties
    {
        internal DeviceLifeCycleEventProperties() { }
        public string DeviceId { get { throw null; } }
        public string HubName { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTwinInfo Twin { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTwinInfoProperties Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public string StatusUpdateTime { get { throw null; } }
        public float? Version { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTwinInfoX509Thumbprint X509Thumbprint { get { throw null; } }
    }
    public partial class DeviceTwinInfoProperties
    {
        internal DeviceTwinInfoProperties() { }
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTwinProperties Desired { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTwinProperties Reported { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTwinMetadata Metadata { get { throw null; } }
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
    public partial class IotHubDeviceConnectedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.DeviceConnectionStateEventProperties
    {
        internal IotHubDeviceConnectedEventData() { }
    }
    public partial class IotHubDeviceCreatedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.DeviceLifeCycleEventProperties
    {
        internal IotHubDeviceCreatedEventData() { }
    }
    public partial class IotHubDeviceDeletedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.DeviceLifeCycleEventProperties
    {
        internal IotHubDeviceDeletedEventData() { }
    }
    public partial class IotHubDeviceDisconnectedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.DeviceConnectionStateEventProperties
    {
        internal IotHubDeviceDisconnectedEventData() { }
    }
    public partial class IotHubDeviceTelemetryEventData : Azure.Messaging.EventGrid.Models.SystemEvents.DeviceTelemetryEventProperties
    {
        internal IotHubDeviceTelemetryEventData() { }
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
    public partial class MapsGeofenceEnteredEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MapsGeofenceEventProperties
    {
        internal MapsGeofenceEnteredEventData() { }
    }
    public partial class MapsGeofenceEventProperties
    {
        internal MapsGeofenceEventProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> ExpiredGeofenceGeometryId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Models.SystemEvents.MapsGeofenceGeometry> Geometries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InvalidPeriodGeofenceGeometryId { get { throw null; } }
        public bool? IsEventPublished { get { throw null; } }
    }
    public partial class MapsGeofenceExitedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MapsGeofenceEventProperties
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
    public partial class MapsGeofenceResultEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MapsGeofenceEventProperties
    {
        internal MapsGeofenceResultEventData() { }
    }
    public partial class MediaJobCanceledEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobCanceledEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
    }
    public partial class MediaJobCancelingEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobCancelingEventData() { }
    }
    public partial class MediaJobError
    {
        internal MediaJobError() { }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCategory? Category { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobErrorCode? Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobErrorDetail> Details { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobRetry? Retry { get { throw null; } }
    }
    public partial class MediaJobErrorDetail
    {
        internal MediaJobErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class MediaJobErroredEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobErroredEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
    }
    public partial class MediaJobFinishedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobFinishedEventData() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutput> Outputs { get { throw null; } }
    }
    public partial class MediaJobOutput
    {
        internal MediaJobOutput() { }
        public Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobError Error { get { throw null; } }
        public string Label { get { throw null; } }
        public long Progress { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState State { get { throw null; } }
    }
    public partial class MediaJobOutputAsset : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutput
    {
        internal MediaJobOutputAsset() { }
        public string AssetName { get { throw null; } }
    }
    public partial class MediaJobOutputCanceledEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputCanceledEventData() { }
    }
    public partial class MediaJobOutputCancelingEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputCancelingEventData() { }
    }
    public partial class MediaJobOutputErroredEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputErroredEventData() { }
    }
    public partial class MediaJobOutputFinishedEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputFinishedEventData() { }
    }
    public partial class MediaJobOutputProcessingEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutputStateChangeEventData
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
    public partial class MediaJobOutputScheduledEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputScheduledEventData() { }
    }
    public partial class MediaJobOutputStateChangeEventData
    {
        internal MediaJobOutputStateChangeEventData() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> JobCorrelationData { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobOutput Output { get { throw null; } }
        public Azure.Messaging.EventGrid.SystemEvents.MediaJobState? PreviousState { get { throw null; } }
    }
    public partial class MediaJobProcessingEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobProcessingEventData() { }
    }
    public partial class MediaJobScheduledEventData : Azure.Messaging.EventGrid.Models.SystemEvents.MediaJobStateChangeEventData
    {
        internal MediaJobScheduledEventData() { }
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
    public partial class ResourceActionCancelData
    {
        internal ResourceActionCancelData() { }
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
    public partial class ResourceActionFailureData
    {
        internal ResourceActionFailureData() { }
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
    public partial class ResourceActionSuccessData
    {
        internal ResourceActionSuccessData() { }
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
    public partial class ResourceDeleteCancelData
    {
        internal ResourceDeleteCancelData() { }
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
    public partial class ResourceDeleteFailureData
    {
        internal ResourceDeleteFailureData() { }
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
    public partial class ResourceDeleteSuccessData
    {
        internal ResourceDeleteSuccessData() { }
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
    public partial class ResourceWriteCancelData
    {
        internal ResourceWriteCancelData() { }
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
    public partial class ResourceWriteFailureData
    {
        internal ResourceWriteFailureData() { }
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
    public partial class ResourceWriteSuccessData
    {
        internal ResourceWriteSuccessData() { }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppServicePlanEventTypeDetail AppServicePlanEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public Azure.Messaging.EventGrid.Models.SystemEvents.WebAppServicePlanUpdatedEventDataSku Sku { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
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
        public Azure.Messaging.EventGrid.Models.SystemEvents.AppEventTypeDetail AppEventTypeDetail { get { throw null; } }
        public string ClientRequestId { get { throw null; } }
        public string CorrelationRequestId { get { throw null; } }
        public string Name { get { throw null; } }
        public string RequestId { get { throw null; } }
        public string Verb { get { throw null; } }
    }
}
namespace Azure.Messaging.EventGrid.SystemEvents
{
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
    public enum MediaJobRetry
    {
        DoNotRetry = 0,
        MayRetry = 1,
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
}
