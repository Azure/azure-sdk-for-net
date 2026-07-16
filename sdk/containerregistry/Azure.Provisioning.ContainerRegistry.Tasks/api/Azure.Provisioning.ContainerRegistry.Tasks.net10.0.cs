namespace Azure.Provisioning.ContainerRegistry.Tasks
{
    public partial class ContainerRegistryAgentPool : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryAgentPool(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskOS> OS { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> VirtualNetworkSubnetResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryAgentPool FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class ContainerRegistryRun : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryRun(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> CustomRegistries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> FinishOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskImageUpdateTrigger ImageUpdateTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchiveEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastUpdatedOn { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskImageDescriptor LogArtifact { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskImageDescriptor> OutputImages { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskProvisioningState> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RunErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RunId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskRunType> RunType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceRegistryAuth { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceTriggerDescriptor SourceTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> StartOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskRunStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Task { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTimerTriggerDescriptor TimerTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateTriggerToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryRun FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class ContainerRegistryTask : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryTask(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsSystemTask { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogTemplate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.TaskStepProperties Step { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTriggerProperties Trigger { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTask FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public enum ContainerRegistryTaskArchitecture
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="amd64")]
        Amd64 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="x86")]
        X86 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="386")]
        X386 = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="arm")]
        Arm = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="arm64")]
        Arm64 = 4,
    }
    public partial class ContainerRegistryTaskArgument : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskArgument() { }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskAuthInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskAuthInfo() { }
        public Azure.Provisioning.BicepValue<int> ExpiresInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Scope { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Token { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTokenType> TokenType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskBaseImageDependency : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskBaseImageDependency() { }
        public Azure.Provisioning.BicepValue<string> Digest { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Registry { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Repository { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskBaseImageDependencyType> Type { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskBaseImageDependencyType
    {
        BuildTime = 0,
        RunTime = 1,
    }
    public partial class ContainerRegistryTaskBaseImageTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskBaseImageTrigger() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskBaseImageTriggerType> BaseImageTriggerType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTriggerStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateTriggerEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskUpdateTriggerPayloadType> UpdateTriggerPayloadType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskBaseImageTriggerType
    {
        All = 0,
        Runtime = 1,
    }
    public partial class ContainerRegistryTaskCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskCredentials() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskCustomRegistryCredentials> CustomRegistries { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceRegistryCredentials SourceRegistry { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskCustomRegistryCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskCustomRegistryCredentials() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSecretObject Password { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSecretObject UserName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskIdentityProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskIdentityProperties() { }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TenantId { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskResourceIdentityType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskUserIdentityProperties> UserAssignedIdentities { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskImageDescriptor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskImageDescriptor() { }
        public Azure.Provisioning.BicepValue<string> Digest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Registry { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Repository { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Tag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskImageUpdateTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskImageUpdateTrigger() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskImageDescriptor> Images { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OccurredOn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskOS
    {
        Windows = 0,
        Linux = 1,
    }
    public partial class ContainerRegistryTaskOverrideStepProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskOverrideStepProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskArgument> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContextPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> File { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UpdateTriggerToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSetValue> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskPlatformProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskPlatformProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskArchitecture> Architecture { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskOS> OS { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskVariant> Variant { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskProvisioningState
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public enum ContainerRegistryTaskResourceIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="SystemAssigned, UserAssigned")]
        SystemAssignedUserAssigned = 2,
        None = 3,
    }
    public partial class ContainerRegistryTaskRun : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public ContainerRegistryTaskRun(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> ForceUpdateTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskIdentityProperties Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.ContainerRegistry.Tasks.RunContent RunRequest { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryRun RunResult { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskRun FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AZPROVISION001")]
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public enum ContainerRegistryTaskRunStatus
    {
        Queued = 0,
        Started = 1,
        Running = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
        Error = 6,
        Timeout = 7,
    }
    public enum ContainerRegistryTaskRunType
    {
        QuickBuild = 0,
        QuickRun = 1,
        AutoBuild = 2,
        AutoRun = 3,
    }
    public partial class ContainerRegistryTaskSecretObject : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskSecretObject() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSecretObjectType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskSecretObjectType
    {
        Opaque = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Vaultsecret")]
        VaultSecret = 1,
    }
    public partial class ContainerRegistryTaskSetValue : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskSetValue() { }
        public Azure.Provisioning.BicepValue<bool> IsSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskSourceControlType
    {
        Github = 0,
        VisualStudioTeamService = 1,
    }
    public partial class ContainerRegistryTaskSourceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskSourceProperties() { }
        public Azure.Provisioning.BicepValue<string> Branch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepositoryUri { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskAuthInfo SourceControlAuthProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceControlType> SourceControlType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskSourceRegistryCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskSourceRegistryCredentials() { }
        public Azure.Provisioning.BicepValue<string> Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceRegistryLoginMode> LoginMode { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskSourceRegistryLoginMode
    {
        None = 0,
        Default = 1,
    }
    public partial class ContainerRegistryTaskSourceTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskSourceTrigger() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceProperties SourceRepository { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceTriggerEvent> SourceTriggerEvents { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTriggerStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskSourceTriggerDescriptor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskSourceTriggerDescriptor() { }
        public Azure.Provisioning.BicepValue<string> BranchName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CommitId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EventType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProviderType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PullRequestId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> RepositoryUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskSourceTriggerEvent
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="commit")]
        Commit = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="pullrequest")]
        PullRequest = 1,
    }
    public enum ContainerRegistryTaskStatus
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class ContainerRegistryTaskTimerTrigger : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskTimerTrigger() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTriggerStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ContainerRegistryTaskTimerTriggerDescriptor : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskTimerTriggerDescriptor() { }
        public Azure.Provisioning.BicepValue<string> ScheduleOccurrence { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimerTriggerName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskTokenType
    {
        PAT = 0,
        OAuth = 1,
    }
    public partial class ContainerRegistryTaskTriggerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskTriggerProperties() { }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskBaseImageTrigger BaseImageTrigger { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSourceTrigger> SourceTriggers { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskTimerTrigger> TimerTriggers { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskTriggerStatus
    {
        Disabled = 0,
        Enabled = 1,
    }
    public enum ContainerRegistryTaskUpdateTriggerPayloadType
    {
        Default = 0,
        Token = 1,
    }
    public partial class ContainerRegistryTaskUserIdentityProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerRegistryTaskUserIdentityProperties() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrincipalId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContainerRegistryTaskVariant
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="v6")]
        V6 = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="v7")]
        V7 = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="v8")]
        V8 = 2,
    }
    public partial class DockerBuildContent : Azure.Provisioning.ContainerRegistry.Tasks.RunContent
    {
        public DockerBuildContent() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskArgument> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ImageNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCacheDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPushEnabled { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DockerBuildStep : Azure.Provisioning.ContainerRegistry.Tasks.TaskStepProperties
    {
        public DockerBuildStep() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskArgument> Arguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ImageNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsCacheDisabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsPushEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncodedTaskRunContent : Azure.Provisioning.ContainerRegistry.Tasks.RunContent
    {
        public EncodedTaskRunContent() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedTaskContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedValuesContent { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSetValue> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class EncodedTaskStep : Azure.Provisioning.ContainerRegistry.Tasks.TaskStepProperties
    {
        public EncodedTaskStep() { }
        public Azure.Provisioning.BicepValue<string> EncodedTaskContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EncodedValuesContent { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSetValue> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileTaskRunContent : Azure.Provisioning.ContainerRegistry.Tasks.RunContent
    {
        public FileTaskRunContent() { }
        public Azure.Provisioning.BicepValue<int> AgentCpu { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskPlatformProperties Platform { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SourceLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TaskFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TimeoutInSeconds { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSetValue> Values { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValuesFilePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FileTaskStep : Azure.Provisioning.ContainerRegistry.Tasks.TaskStepProperties
    {
        public FileTaskStep() { }
        public Azure.Provisioning.BicepValue<string> TaskFilePath { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskSetValue> Values { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValuesFilePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RunContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RunContent() { }
        public Azure.Provisioning.BicepValue<string> AgentPoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchiveEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LogTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TaskRunContent : Azure.Provisioning.ContainerRegistry.Tasks.RunContent
    {
        public TaskRunContent() { }
        public Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskOverrideStepProperties OverrideTaskStepProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TaskId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TaskStepProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TaskStepProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.ContainerRegistry.Tasks.ContainerRegistryTaskBaseImageDependency> BaseImageDependencies { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ContextAccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContextPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
}
