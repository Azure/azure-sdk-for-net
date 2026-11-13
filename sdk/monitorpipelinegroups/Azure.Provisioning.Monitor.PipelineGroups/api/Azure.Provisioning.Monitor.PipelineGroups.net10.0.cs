namespace Azure.Provisioning.Monitor.PipelineGroups
{
    public partial class AzureMonitorWorkspaceLogsApiConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureMonitorWorkspaceLogsApiConfig() { }
        public Azure.Provisioning.BicepValue<string> DataCollectionEndpointUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataCollectionRuleId { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupSchemaMap Schema { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Stream { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureMonitorWorkspaceLogsExporter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzureMonitorWorkspaceLogsExporter() { }
        public Azure.Provisioning.Monitor.PipelineGroups.AzureMonitorWorkspaceLogsApiConfig Api { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.CacheConfiguration Cache { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.ConcurrencyConfiguration Concurrency { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CacheConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CacheConfiguration() { }
        public Azure.Provisioning.BicepValue<int> MaxStorageUsage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RetentionPeriod { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ConcurrencyConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ConcurrencyConfiguration() { }
        public Azure.Provisioning.BicepValue<int> BatchQueueSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WorkerCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ExternalNetworkingMode
    {
        LoadBalancerOnly = 0,
    }
    public partial class JsonArrayMapper : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JsonArrayMapper() { }
        public Azure.Provisioning.Monitor.PipelineGroups.JsonMapperDestinationField DestinationField { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FieldName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Keys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class JsonMapperDestinationField : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JsonMapperDestinationField() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.JsonMapperElement> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FieldName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JsonMapperElement
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="body")]
        Body = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="attributes")]
        Attributes = 1,
    }
    public enum MonitorPipelineGroupProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Deleting = 4,
    }
    public partial class NetworkingConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkingConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.ExternalNetworkingMode> ExternalNetworkingMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Host { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.NetworkingRoute> Routes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NetworkingRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NetworkingRoute() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Receiver { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Subdomain { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroup : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public PipelineGroup(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.Resources.ExtendedAzureLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.Monitor.PipelineGroups.PipelineGroup FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2024_10_01_PREVIEW;
        }
    }
    public partial class PipelineGroupBatchProcessor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupBatchProcessor() { }
        public Azure.Provisioning.BicepValue<int> BatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupExporter : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupExporter() { }
        public Azure.Provisioning.Monitor.PipelineGroups.AzureMonitorWorkspaceLogsExporter AzureMonitorWorkspaceLogs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TcpUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupExporterType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PipelineGroupExporterType
    {
        AzureMonitorWorkspaceLogs = 0,
        PipelineGroup = 1,
    }
    public partial class PipelineGroupPipeline : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupPipeline() { }
        public Azure.Provisioning.BicepList<string> Exporters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Processors { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Receivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupPipelineType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PipelineGroupPipelineType
    {
        Logs = 0,
    }
    public partial class PipelineGroupProcessor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupProcessor() { }
        public Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupBatchProcessor Batch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupProcessorType> Type { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PipelineGroupProcessorType
    {
        Batch = 0,
    }
    public partial class PipelineGroupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupExporter> Exporters { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.NetworkingConfiguration> NetworkingConfigurations { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupProcessor> Processors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.MonitorPipelineGroupProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupReceiver> Receivers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Replicas { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupService Service { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupReceiver() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OtlpEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupSyslogReceiver Syslog { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupReceiverType> Type { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.UdpReceiver Udp { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PipelineGroupReceiverType
    {
        Syslog = 0,
        Ama = 1,
        PipelineGroup = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="OTLP")]
        Otlp = 3,
        UDP = 4,
    }
    public partial class PipelineGroupRecordMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupRecordMap() { }
        public Azure.Provisioning.BicepValue<string> From { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupResourceMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupResourceMap() { }
        public Azure.Provisioning.BicepValue<string> From { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupSchemaMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupSchemaMap() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupRecordMap> RecordMap { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupResourceMap> ResourceMap { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupScopeMap> ScopeMap { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupScopeMap : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupScopeMap() { }
        public Azure.Provisioning.BicepValue<string> From { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> To { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupService() { }
        public Azure.Provisioning.BicepValue<string> PersistencePersistentVolumeName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Monitor.PipelineGroups.PipelineGroupPipeline> Pipelines { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PipelineGroupSyslogReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PipelineGroupSyslogReceiver() { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.SyslogProtocol> Protocol { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StreamEncodingType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="nop")]
        Nop = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="utf-8")]
        Utf8 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="utf-16le")]
        Utf16le = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="utf-16be")]
        Utf16be = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ascii")]
        Ascii = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="big5")]
        Big5 = 5,
    }
    public enum SyslogProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="rfc3164")]
        Rfc3164 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rfc5424")]
        Rfc5424 = 1,
    }
    public partial class UdpReceiver : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public UdpReceiver() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.Monitor.PipelineGroups.StreamEncodingType> Encoding { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.Monitor.PipelineGroups.JsonArrayMapper JsonArrayMapper { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ReadQueueLength { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
