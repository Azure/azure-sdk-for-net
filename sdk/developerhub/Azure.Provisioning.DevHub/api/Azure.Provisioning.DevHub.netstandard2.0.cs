namespace Azure.Provisioning.DevHub
{
    public partial class AdoOAuthResponse : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal AdoOAuthResponse() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> AdoOAuthUsername { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DevHub.AdoOAuthResponse FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class AdoProviderProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdoProviderProfile() { }
        public Azure.Provisioning.BicepValue<string> ArmServiceConnection { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.AdoRepository Repository { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AdoRepository : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AdoRepository() { }
        public Azure.Provisioning.BicepValue<string> AdoOrganization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BranchName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProjectName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryOwner { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzurePipelineProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AzurePipelineProfile() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Acr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ArmServiceConnection { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubAuthorizationStatus> AuthStatus { get { throw null; } }
        public Azure.Provisioning.DevHub.DevHubDockerBuildInfo Build { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ClusterId { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubDeploymentProperties Deployment { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubWorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DeveloperHubPullRequestContent PullRequest { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.AdoRepository Repository { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeveloperHubParameterContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeveloperHubParameterContent() { }
        public Azure.Provisioning.DevHub.DevHubTemplateParameterDefault Default { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsRequired { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubTemplateParameterKind> ParameterKind { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubTemplateParameterType> ParameterType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DeveloperHubPullRequestContent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DeveloperHubPullRequestContent() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubPullRequestStatus> PrStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PullNumber { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubArtifactGenerationProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubArtifactGenerationProperties() { }
        public Azure.Provisioning.BicepValue<string> AppName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BuilderVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubDockerfileGenerationMode> DockerfileGenerationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerfileOutputDirectory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubGenerationLanguage> GenerationLanguage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageTag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LanguageVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubManifestGenerationMode> ManifestGenerationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ManifestOutputDirectory { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubGenerationManifestType> ManifestType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Port { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubAuthorizationStatus
    {
        Authorized = 0,
        NotFound = 1,
        Error = 2,
    }
    public partial class DevHubContainerRegistryInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubContainerRegistryInfo() { }
        public Azure.Provisioning.BicepValue<string> AcrRegistryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcrRepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcrResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcrSubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubDeploymentProperties() { }
        public Azure.Provisioning.BicepValue<string> HelmChartPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> HelmValues { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> KubeManifestLocations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubManifestType> ManifestType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Overrides { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubDockerBuildInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubDockerBuildInfo() { }
        public Azure.Provisioning.BicepValue<string> DockerBuildContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Dockerfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubDockerfileGenerationMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public enum DevHubGenerationLanguage
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="clojure")]
        Clojure = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="csharp")]
        CSharp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="erlang")]
        Erlang = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="go")]
        Go = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="gomodule")]
        GoModule = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="gradle")]
        Gradle = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="java")]
        Java = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="javascript")]
        JavaScript = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="php")]
        Php = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="python")]
        Python = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ruby")]
        Ruby = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="rust")]
        Rust = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="swift")]
        Swift = 12,
    }
    public enum DevHubGenerationManifestType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="helm")]
        Helm = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kube")]
        Kube = 1,
    }
    public partial class DevHubIacTemplateDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubIacTemplateDetails() { }
        public Azure.Provisioning.BicepValue<int> Count { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NamingConvention { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProductName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubIacTemplateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubIacTemplateProperties() { }
        public Azure.Provisioning.BicepValue<string> InstanceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstanceStage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubQuickStartTemplateType> QuickStartTemplateType { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DevHub.DevHubIacTemplateDetails> TemplateDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TemplateName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubManifestGenerationMode
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="enabled")]
        Enabled = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="disabled")]
        Disabled = 1,
    }
    public enum DevHubManifestType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="helm")]
        Helm = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kube")]
        Kube = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kustomize")]
        Kustomize = 2,
    }
    public partial class DevHubOidcCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubOidcCredentials() { }
        public Azure.Provisioning.BicepValue<string> AzureClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureTenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubPullRequestStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="unknown")]
        Unknown = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="submitted")]
        Submitted = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="merged")]
        Merged = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="removed")]
        Removed = 3,
    }
    public enum DevHubQuickStartTemplateType
    {
        None = 0,
        HCI = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HCIAKS")]
        HciAks = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="HCIARCVM")]
        HciArcVm = 3,
    }
    public enum DevHubRepositoryProviderType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="github")]
        GitHub = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ado")]
        Ado = 1,
    }
    public partial class DevHubStageInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubStageInfo() { }
        public Azure.Provisioning.BicepList<string> Dependencies { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GitEnvironment { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StageName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubTemplate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal DevHubTemplate() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubTemplateProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DevHub.DevHubTemplate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class DevHubTemplateParameterDefault : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubTemplateParameterDefault() { }
        public Azure.Provisioning.BicepValue<string> ReferenceParameter { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubTemplateParameterKind
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureContainerRegistry")]
        AzureContainerRegistry = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureKeyvaultUri")]
        AzureKeyvaultUri = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureManagedCluster")]
        AzureManagedCluster = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureResourceGroup")]
        AzureResourceGroup = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureServiceConnection")]
        AzureServiceConnection = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="containerImageName")]
        ContainerImageName = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="containerImageVersion")]
        ContainerImageVersion = 6,
        [System.Runtime.Serialization.DataMemberAttribute(Name="clusterResourceType")]
        ClusterResourceType = 7,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dirPath")]
        DirPath = 8,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dockerFileName")]
        DockerFileName = 9,
        [System.Runtime.Serialization.DataMemberAttribute(Name="envVarMap")]
        EnvVarMap = 10,
        [System.Runtime.Serialization.DataMemberAttribute(Name="filePath")]
        FilePath = 11,
        [System.Runtime.Serialization.DataMemberAttribute(Name="flag")]
        Flag = 12,
        [System.Runtime.Serialization.DataMemberAttribute(Name="helmChartOverrides")]
        HelmChartOverrides = 13,
        [System.Runtime.Serialization.DataMemberAttribute(Name="imagePullPolicy")]
        ImagePullPolicy = 14,
        [System.Runtime.Serialization.DataMemberAttribute(Name="ingressHostName")]
        IngressHostName = 15,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesNamespace")]
        KubernetesNamespace = 16,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesProbeHttpPath")]
        KubernetesProbeHttpPath = 17,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesProbePeriod")]
        KubernetesProbePeriod = 18,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesProbeTimeout")]
        KubernetesProbeTimeout = 19,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesProbeThreshold")]
        KubernetesProbeThreshold = 20,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesProbeType")]
        KubernetesProbeType = 21,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesProbeDelay")]
        KubernetesProbeDelay = 22,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesResourceLimit")]
        KubernetesResourceLimit = 23,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesResourceName")]
        KubernetesResourceName = 24,
        [System.Runtime.Serialization.DataMemberAttribute(Name="kubernetesResourceRequest")]
        KubernetesResourceRequest = 25,
        [System.Runtime.Serialization.DataMemberAttribute(Name="label")]
        Label = 26,
        [System.Runtime.Serialization.DataMemberAttribute(Name="port")]
        Port = 27,
        [System.Runtime.Serialization.DataMemberAttribute(Name="repositoryBranch")]
        RepositoryBranch = 28,
        [System.Runtime.Serialization.DataMemberAttribute(Name="workflowName")]
        WorkflowName = 29,
        [System.Runtime.Serialization.DataMemberAttribute(Name="replicaCount")]
        ReplicaCount = 30,
        [System.Runtime.Serialization.DataMemberAttribute(Name="scalingResourceType")]
        ScalingResourceType = 31,
        [System.Runtime.Serialization.DataMemberAttribute(Name="scalingResourceUtilization")]
        ScalingResourceUtilization = 32,
        [System.Runtime.Serialization.DataMemberAttribute(Name="resourceLimit")]
        ResourceLimit = 33,
        [System.Runtime.Serialization.DataMemberAttribute(Name="workflowAuthType")]
        WorkflowAuthType = 34,
    }
    public enum DevHubTemplateParameterType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="string")]
        String = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="bool")]
        Bool = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="int")]
        Int = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="float")]
        Float = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="object")]
        Object = 4,
    }
    public partial class DevHubTemplateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubTemplateProperties() { }
        public Azure.Provisioning.BicepValue<string> DefaultVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> TemplateName { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubTemplateType> TemplateType { get { throw null; } }
        public Azure.Provisioning.BicepList<string> Versions { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubTemplateReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubTemplateReference() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Parameters { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> TemplateId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubTemplateType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="deployment")]
        Deployment = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="manifest")]
        Manifest = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="workflow")]
        Workflow = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="dockerfile")]
        Dockerfile = 3,
    }
    public partial class DevHubTemplateWorkflowProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubTemplateWorkflowProfile() { }
        public Azure.Provisioning.DevHub.AdoProviderProfile AdoProviderProfile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubAuthorizationStatus> AuthStatus { get { throw null; } }
        public Azure.Provisioning.DevHub.DevHubTemplateReference DeploymentTemplate { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubTemplateReference DockerfileTemplate { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.GitHubProviderProfile GitHubProviderProfile { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubWorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DevHub.DevHubTemplateReference> ManifestTemplates { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DeveloperHubPullRequestContent PullRequest { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubRepositoryProviderType> RepositoryProvider { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubTemplateReference WorkflowTemplate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubVersionedTemplate : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal DevHubVersionedTemplate() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubTemplate Parent { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubVersionedTemplateProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DevHub.DevHubVersionedTemplate FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class DevHubVersionedTemplateProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubVersionedTemplateProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DevHub.DeveloperHubParameterContent> Parameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubTemplateType> TemplateType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubWorkflow : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public DevHubWorkflow(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubWorkflowProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DevHub.DevHubWorkflow FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class DevHubWorkflowProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubWorkflowProperties() { }
        public Azure.Provisioning.DevHub.DevHubArtifactGenerationProperties ArtifactGenerationProperties { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.AzurePipelineProfile AzurePipelineProfile { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.GitHubWorkflowProfile GithubWorkflowProfile { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubTemplateWorkflowProfile TemplateWorkflowProfile { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DevHubWorkflowRun : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DevHubWorkflowRun() { }
        public Azure.Provisioning.BicepValue<bool> IsSucceeded { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> LastRunOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubWorkflowRunStatus> WorkflowRunStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> WorkflowRunUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DevHubWorkflowRunStatus
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="queued")]
        Queued = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="inprogress")]
        InProgress = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="completed")]
        Completed = 2,
    }
    public partial class GitHubOAuthResponse : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal GitHubOAuthResponse() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> GitHubOAuthUsername { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DevHub.GitHubOAuthResponse FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
    public partial class GitHubProviderProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubProviderProfile() { }
        public Azure.Provisioning.DevHub.DevHubOidcCredentials OidcCredentials { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.GitHubRepository Repository { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitHubRepository : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubRepository() { }
        public Azure.Provisioning.BicepValue<string> BranchName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryOwner { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitHubWorkflowProfile : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubWorkflowProfile() { }
        public Azure.Provisioning.DevHub.DevHubContainerRegistryInfo Acr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AksResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubAuthorizationStatus> AuthStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BranchName { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubDeploymentProperties DeploymentProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerBuildContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Dockerfile { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.DevHubWorkflowRun LastWorkflowRun { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.DevHub.GitHubWorkflowProfileOidcCredentials OidcCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubPullRequestStatus> PrStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PullNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryOwner { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GitHubWorkflowProfileOidcCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public GitHubWorkflowProfileOidcCredentials() { }
        public Azure.Provisioning.BicepValue<string> AzureClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AzureTenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class IacProfile : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public IacProfile(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubAuthorizationStatus> AuthStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> BranchName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.ETag> ETag { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.DevHub.DevHubPullRequestStatus> PrStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PullNumber { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> RepositoryMainBranch { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RepositoryOwner { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DevHub.DevHubStageInfo> Stages { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountSubscription { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageContainerName { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.DevHub.DevHubIacTemplateProperties> Templates { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.DevHub.IacProfile FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_03_01_PREVIEW;
        }
    }
}
