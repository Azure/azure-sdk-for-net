namespace Azure.Provisioning.StandbyPool
{
    public partial class ContainerGroupInstanceCountSummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerGroupInstanceCountSummary() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.StandbyPool.PoolContainerGroupStateCount> StandbyContainerGroupInstanceCountsByState { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Zone { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PoolContainerGroupState
    {
        Running = 0,
        Creating = 1,
        Deleting = 2,
    }
    public partial class PoolContainerGroupStateCount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PoolContainerGroupStateCount() { }
        public Azure.Provisioning.BicepValue<long> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.PoolContainerGroupState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PoolVirtualMachineState
    {
        Running = 0,
        Creating = 1,
        Starting = 2,
        Deleting = 3,
        Deallocated = 4,
        Deallocating = 5,
        Hibernated = 6,
        Hibernating = 7,
    }
    public partial class PoolVirtualMachineStateCount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PoolVirtualMachineStateCount() { }
        public Azure.Provisioning.BicepValue<long> Count { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.PoolVirtualMachineState> State { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyContainerGroupPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StandbyContainerGroupPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupPoolProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.StandbyPool.StandbyContainerGroupPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_10_01;
        }
    }
    public partial class StandbyContainerGroupPoolElasticityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyContainerGroupPoolElasticityProfile() { }
        public Azure.Provisioning.BicepValue<bool> DynamicSizingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxReadyCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyRefillPolicy> RefillPolicy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyContainerGroupPoolPrediction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyContainerGroupPoolPrediction() { }
        public Azure.Provisioning.BicepValue<string> ForecastInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ForecastStartOn { get { throw null; } }
        public Azure.Provisioning.BicepList<long> ForecastValuesInstancesRequestedCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyContainerGroupPoolProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyContainerGroupPoolProperties() { }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupProperties ContainerGroupProperties { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupPoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Zones { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyContainerGroupPoolRuntimeView : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal StandbyContainerGroupPoolRuntimeView() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupPool Parent { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupPoolRuntimeViewProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.StandbyPool.StandbyContainerGroupPoolRuntimeView FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_10_01;
        }
    }
    public partial class StandbyContainerGroupPoolRuntimeViewProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyContainerGroupPoolRuntimeViewProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.StandbyPool.ContainerGroupInstanceCountSummary> InstanceCountSummary { get { throw null; } }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupPoolPrediction Prediction { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.StandbyPool.StandbyPoolStatus Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyContainerGroupProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyContainerGroupProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> Revision { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyContainerGroupProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyContainerGroupProperties() { }
        public Azure.Provisioning.StandbyPool.StandbyContainerGroupProfile ContainerGroupProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.Resources.WritableSubResource> SubnetIds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StandbyPoolHealthStateCode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="HealthState/healthy")]
        Healthy = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HealthState/degraded")]
        Degraded = 1,
    }
    public partial class StandbyPoolStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyPoolStatus() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyPoolHealthStateCode> Code { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Message { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StandbyProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Deleting = 3,
    }
    public enum StandbyRefillPolicy
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="always")]
        Always = 0,
    }
    public partial class StandbyVirtualMachine : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal StandbyVirtualMachine() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachinePool Parent { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachineProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.StandbyPool.StandbyVirtualMachine FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_10_01;
        }
    }
    public partial class StandbyVirtualMachineInstanceCountSummary : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyVirtualMachineInstanceCountSummary() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.StandbyPool.PoolVirtualMachineStateCount> StandbyVirtualMachineInstanceCountsByState { get { throw null; } }
        public Azure.Provisioning.BicepValue<long> Zone { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyVirtualMachinePool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public StandbyVirtualMachinePool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachinePoolProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.StandbyPool.StandbyVirtualMachinePool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_10_01;
        }
    }
    public partial class StandbyVirtualMachinePoolElasticityProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyVirtualMachinePoolElasticityProfile() { }
        public Azure.Provisioning.BicepValue<bool> DynamicSizingEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MaxReadyCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MinReadyCapacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PostProvisioningDelay { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyVirtualMachinePoolPrediction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyVirtualMachinePoolPrediction() { }
        public Azure.Provisioning.BicepValue<string> ForecastInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ForecastStartOn { get { throw null; } }
        public Azure.Provisioning.BicepList<long> ForecastValuesInstancesRequestedCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyVirtualMachinePoolProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyVirtualMachinePoolProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AttachedVirtualMachineScaleSetId { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachinePoolElasticityProfile ElasticityProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyVirtualMachineState> VirtualMachineState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyVirtualMachinePoolRuntimeView : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal StandbyVirtualMachinePoolRuntimeView() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachinePool Parent { get { throw null; } set { } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachinePoolRuntimeViewProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.StandbyPool.StandbyVirtualMachinePoolRuntimeView FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2024_03_01;
            public static readonly string V2025_03_01;
            public static readonly string V2025_10_01;
        }
    }
    public partial class StandbyVirtualMachinePoolRuntimeViewProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyVirtualMachinePoolRuntimeViewProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.StandbyPool.StandbyVirtualMachineInstanceCountSummary> InstanceCountSummary { get { throw null; } }
        public Azure.Provisioning.StandbyPool.StandbyVirtualMachinePoolPrediction Prediction { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.StandbyPool.StandbyPoolStatus Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StandbyVirtualMachineProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StandbyVirtualMachineProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.StandbyPool.StandbyProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualMachineResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StandbyVirtualMachineState
    {
        Running = 0,
        Deallocated = 1,
        Hibernated = 2,
    }
}
