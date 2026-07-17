namespace Azure.Provisioning.MachineLearning
{
    public partial class AadAuthTypeWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public AadAuthTypeWorkspaceConnectionProperties() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AccessKeyAuthTypeWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public AccessKeyAuthTypeWorkspaceConnectionProperties() { }
        public Azure.Provisioning.MachineLearning.WorkspaceConnectionAccessKey Credentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AccountKeyAuthTypeWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public AccountKeyAuthTypeWorkspaceConnectionProperties() { }
        public Azure.Provisioning.BicepValue<string> CredentialsKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmlCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public AmlCompute() { }
        public Azure.Provisioning.MachineLearning.AmlComputeProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmlComputeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AmlComputeProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningAllocationState> AllocationState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> AllocationStateTransitionOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> CurrentNodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableNodePublicIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningError> Errors { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsolatedNetwork { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningNodeStateCounts NodeStateCounts { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOSType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> PropertyBag { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningRemoteLoginPortPublicAccess> RemoteLoginPortPublicAccess { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.AmlComputeScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetNodeCount { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningUserAccountCredentials UserAccountCredentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineImageId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningVmPriority> VmPriority { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmlComputeScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AmlComputeScaleSettings() { }
        public Azure.Provisioning.BicepValue<int> MaxNodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinNodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> NodeIdleTimeBeforeScaleDown { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmlToken : Azure.Provisioning.MachineLearning.MachineLearningIdentityConfiguration
    {
        public AmlToken() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AmlTokenComputeIdentity : Azure.Provisioning.MachineLearning.MonitorComputeIdentityBase
    {
        public AmlTokenComputeIdentity() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ApiKeyAuthWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public ApiKeyAuthWorkspaceConnectionProperties() { }
        public Azure.Provisioning.BicepValue<string> CredentialsKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoForecastHorizon : Azure.Provisioning.MachineLearning.ForecastHorizon
    {
        public AutoForecastHorizon() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoMLJob : Azure.Provisioning.MachineLearning.MachineLearningJobProperties
    {
        public AutoMLJob() { }
        public Azure.Provisioning.BicepValue<string> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.JobTier> QueueJobTier { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningJobResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.AutoMLVertical TaskDetails { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoMLVertical : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public AutoMLVertical() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningLogVerbosity> LogVerbosity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetColumnName { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput TrainingData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoMLVerticalRegression : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public AutoMLVerticalRegression() { }
        public Azure.Provisioning.BicepList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.AutoMLVerticalRegressionPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput TestData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> TestDataSize { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.RegressionTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WeightColumnName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoMLVerticalRegressionModel
    {
        ElasticNet = 0,
        GradientBoosting = 1,
        DecisionTree = 2,
        KNN = 3,
        LassoLars = 4,
        SGD = 5,
        RandomForest = 6,
        ExtremeRandomTrees = 7,
        LightGBM = 8,
        XGBoostRegressor = 9,
    }
    public enum AutoMLVerticalRegressionPrimaryMetric
    {
        SpearmanCorrelation = 0,
        NormalizedRootMeanSquaredError = 1,
        R2Score = 2,
        NormalizedMeanAbsoluteError = 3,
    }
    public partial class AutoNCrossValidations : Azure.Provisioning.MachineLearning.NCrossValidations
    {
        public AutoNCrossValidations() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum AutoRebuildSetting
    {
        Disabled = 0,
        OnBaseImageUpdate = 1,
    }
    public partial class AutoSeasonality : Azure.Provisioning.MachineLearning.ForecastingSeasonality
    {
        public AutoSeasonality() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoTargetLags : Azure.Provisioning.MachineLearning.TargetLags
    {
        public AutoTargetLags() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AutoTargetRollingWindowSize : Azure.Provisioning.MachineLearning.TargetRollingWindowSize
    {
        public AutoTargetRollingWindowSize() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class AzureDevOpsWebhook : Azure.Provisioning.MachineLearning.MachineLearningWebhook
    {
        public AzureDevOpsWebhook() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BanditPolicy : Azure.Provisioning.MachineLearning.MachineLearningEarlyTerminationPolicy
    {
        public BanditPolicy() { }
        public Azure.Provisioning.BicepValue<float> SlackAmount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> SlackFactor { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchDeploymentConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public BatchDeploymentConfiguration() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BatchPipelineComponentDeploymentConfiguration : Azure.Provisioning.MachineLearning.BatchDeploymentConfiguration
    {
        public BatchPipelineComponentDeploymentConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AssetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class BayesianSamplingAlgorithm : Azure.Provisioning.MachineLearning.SamplingAlgorithm
    {
        public BayesianSamplingAlgorithm() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum BlockedTransformer
    {
        TextTargetEncoder = 0,
        OneHotEncoder = 1,
        CatTargetEncoder = 2,
        TfIdf = 3,
        WoETargetEncoder = 4,
        LabelEncoder = 5,
        WordEmbedding = 6,
        NaiveBayes = 7,
        CountVectorizer = 8,
        HashOneHotEncoder = 9,
    }
    public partial class CapabilityHost : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public CapabilityHost(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.CapabilityHostProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.CapabilityHost FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum CapabilityHostKind
    {
        Agents = 0,
    }
    public partial class CapabilityHostProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CapabilityHostProperties() { }
        public Azure.Provisioning.BicepList<string> AcaEnvironmentConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AiServicesConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.CapabilityHostKind> CapabilityHostKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CustomerSubnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Messages { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.CapabilityHostProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepList<string> StorageConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> ThreadStorageConnections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> VectorStoreConnections { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CapabilityHostProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public enum CategoricalDataDriftMetric
    {
        JensenShannonDistance = 0,
        PopulationStabilityIndex = 1,
        PearsonsChiSquaredTest = 2,
    }
    public partial class CategoricalDataDriftMetricThreshold : Azure.Provisioning.MachineLearning.DataDriftMetricThresholdBase
    {
        public CategoricalDataDriftMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.CategoricalDataDriftMetric> Metric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CategoricalDataQualityMetric
    {
        NullValueRate = 0,
        DataTypeErrorRate = 1,
        OutOfBoundsRate = 2,
    }
    public partial class CategoricalDataQualityMetricThreshold : Azure.Provisioning.MachineLearning.DataQualityMetricThresholdBase
    {
        public CategoricalDataQualityMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.CategoricalDataQualityMetric> Metric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum CategoricalPredictionDriftMetric
    {
        JensenShannonDistance = 0,
        PopulationStabilityIndex = 1,
        PearsonsChiSquaredTest = 2,
    }
    public partial class CategoricalPredictionDriftMetricThreshold : Azure.Provisioning.MachineLearning.PredictionDriftMetricThresholdBase
    {
        public CategoricalPredictionDriftMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.CategoricalPredictionDriftMetric> Metric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ClassificationModel
    {
        LogisticRegression = 0,
        SGD = 1,
        MultinomialNaiveBayes = 2,
        BernoulliNaiveBayes = 3,
        SVM = 4,
        LinearSVM = 5,
        KNN = 6,
        DecisionTree = 7,
        RandomForest = 8,
        ExtremeRandomTrees = 9,
        LightGBM = 10,
        GradientBoosting = 11,
        XGBoostClassifier = 12,
    }
    public enum ClassificationMultilabelPrimaryMetric
    {
        AUCWeighted = 0,
        Accuracy = 1,
        NormMacroRecall = 2,
        AveragePrecisionScoreWeighted = 3,
        PrecisionScoreWeighted = 4,
        IOU = 5,
    }
    public enum ClassificationPrimaryMetric
    {
        AUCWeighted = 0,
        Accuracy = 1,
        NormMacroRecall = 2,
        AveragePrecisionScoreWeighted = 3,
        PrecisionScoreWeighted = 4,
    }
    public partial class ClassificationTask : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public ClassificationTask() { }
        public Azure.Provisioning.BicepList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PositiveLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ClassificationPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput TestData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> TestDataSize { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ClassificationTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WeightColumnName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ClassificationTrainingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ClassificationTrainingSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ClassificationModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ClassificationModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDnnTraining { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableModelExplainability { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnnxCompatibleModels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStackEnsemble { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableVoteEnsemble { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EnsembleModelDownloadTimeout { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningStackEnsembleSettings StackEnsembleSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ColumnTransformer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ColumnTransformer() { }
        public Azure.Provisioning.BicepList<string> Fields { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeStartStopCronSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeStartStopCronSchedule() { }
        public Azure.Provisioning.BicepValue<string> Expression { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeStartStopRecurrenceSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeStartStopRecurrenceSchedule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningComputeRecurrenceFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeRecurrenceSchedule Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ComputeStartStopSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ComputeStartStopSchedule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningComputePowerAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ComputeStartStopCronSchedule Cron { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningComputeProvisioningStatus> ProvisioningStatus { get { throw null; } }
        public Azure.Provisioning.MachineLearning.ComputeStartStopRecurrenceSchedule Recurrence { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningScheduleBase Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningScheduleStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ComputeTriggerType> TriggerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ComputeTriggerType
    {
        Recurrence = 0,
        Cron = 1,
    }
    public enum ContainerCommunicationProtocol
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="tcp")]
        Tcp = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="udp")]
        Udp = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="http")]
        Http = 2,
    }
    public partial class ContainerEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ContainerEndpoint() { }
        public Azure.Provisioning.BicepValue<string> HostIp { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ContainerCommunicationProtocol> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Published { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Target { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ContentSafetyStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class CreateMonitorAction : Azure.Provisioning.MachineLearning.MachineLearningScheduleAction
    {
        public CreateMonitorAction() { }
        public Azure.Provisioning.MachineLearning.MonitorDefinition MonitorDefinition { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CronTrigger : Azure.Provisioning.MachineLearning.MachineLearningTriggerBase
    {
        public CronTrigger() { }
        public Azure.Provisioning.BicepValue<string> Expression { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomForecastHorizon : Azure.Provisioning.MachineLearning.ForecastHorizon
    {
        public CustomForecastHorizon() { }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomKeysWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public CustomKeysWorkspaceConnectionProperties() { }
        public Azure.Provisioning.BicepDictionary<string> CredentialsKeys { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomMetricThreshold : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomMetricThreshold() { }
        public Azure.Provisioning.BicepValue<string> Metric { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ThresholdValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomMonitoringSignal : Azure.Provisioning.MachineLearning.MonitoringSignalBase
    {
        public CustomMonitoringSignal() { }
        public Azure.Provisioning.BicepValue<string> ComponentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MonitoringInputDataBase> InputAssets { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.CustomMetricThreshold> MetricThresholds { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomNCrossValidations : Azure.Provisioning.MachineLearning.NCrossValidations
    {
        public CustomNCrossValidations() { }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomSeasonality : Azure.Provisioning.MachineLearning.ForecastingSeasonality
    {
        public CustomSeasonality() { }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public CustomService() { }
        public Azure.Provisioning.BicepValue<bool> DockerPrivileged { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ContainerEndpoint> Endpoints { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.EnvironmentVariable> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageSetting Image { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.JupyterKernelConfig Kernel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.VolumeDefinition> Volumes { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomTargetLags : Azure.Provisioning.MachineLearning.TargetLags
    {
        public CustomTargetLags() { }
        public Azure.Provisioning.BicepList<int> Values { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class CustomTargetRollingWindowSize : Azure.Provisioning.MachineLearning.TargetRollingWindowSize
    {
        public CustomTargetRollingWindowSize() { }
        public Azure.Provisioning.BicepValue<int> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataCollectionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollectionConfiguration() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.DataCollectionMode> DataCollectionMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> SamplingRate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum DataCollectionMode
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class DataCollector : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataCollector() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.DataCollectionConfiguration> Collections { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> RequestLoggingCaptureHeaders { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RollingRateType> RollingRate { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataDriftMetricThresholdBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataDriftMetricThresholdBase() { }
        public Azure.Provisioning.BicepValue<double> ThresholdValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataDriftMonitoringSignal : Azure.Provisioning.MachineLearning.MonitoringSignalBase
    {
        public DataDriftMonitoringSignal() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MonitoringFeatureDataType> FeatureDataTypeOverride { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.FeatureImportanceSettings FeatureImportanceSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringFeatureFilterBase Features { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.DataDriftMetricThresholdBase> MetricThresholds { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ProductionData { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ReferenceData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataQualityMetricThresholdBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DataQualityMetricThresholdBase() { }
        public Azure.Provisioning.BicepValue<double> ThresholdValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DataQualityMonitoringSignal : Azure.Provisioning.MachineLearning.MonitoringSignalBase
    {
        public DataQualityMonitoringSignal() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MonitoringFeatureDataType> FeatureDataTypeOverride { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.FeatureImportanceSettings FeatureImportanceSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringFeatureFilterBase Features { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.DataQualityMetricThresholdBase> MetricThresholds { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ProductionData { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ReferenceData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class DatasetReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public DatasetReference() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EmailNotificationEnableType
    {
        JobCompleted = 0,
        JobFailed = 1,
        JobCancelled = 2,
    }
    public partial class EncryptionProperty : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EncryptionProperty() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CosmosDbResourceId { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SearchAccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEncryptionStatus> Status { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> StorageAccountResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> UserAssignedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EndpointServiceConnectionStatus
    {
        Approved = 0,
        Pending = 1,
        Rejected = 2,
        Disconnected = 3,
        Timeout = 4,
    }
    public partial class EnvironmentVariable : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public EnvironmentVariable() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.EnvironmentVariableType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum EnvironmentVariableType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="local")]
        Local = 0,
    }
    public partial class FeatureAttributionDriftMonitoringSignal : Azure.Provisioning.MachineLearning.MonitoringSignalBase
    {
        public FeatureAttributionDriftMonitoringSignal() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MonitoringFeatureDataType> FeatureDataTypeOverride { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.FeatureImportanceSettings FeatureImportanceSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.FeatureAttributionMetricThreshold MetricThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MonitoringInputDataBase> ProductionData { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ReferenceData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FeatureAttributionMetric
    {
        NormalizedDiscountedCumulativeGain = 0,
    }
    public partial class FeatureAttributionMetricThreshold : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FeatureAttributionMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.FeatureAttributionMetric> Metric { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ThresholdValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FeatureDataType
    {
        String = 0,
        Integer = 1,
        Long = 2,
        Float = 3,
        Double = 4,
        Binary = 5,
        Datetime = 6,
        Boolean = 7,
    }
    public enum FeatureImportanceMode
    {
        Disabled = 0,
        Enabled = 1,
    }
    public partial class FeatureImportanceSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FeatureImportanceSettings() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.FeatureImportanceMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TargetColumn { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FeatureStoreSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public FeatureStoreSettings() { }
        public Azure.Provisioning.BicepValue<string> OfflineStoreConnectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OnlineStoreConnectionName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SparkRuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FeatureSubset : Azure.Provisioning.MachineLearning.MonitoringFeatureFilterBase
    {
        public FeatureSubset() { }
        public Azure.Provisioning.BicepList<string> Features { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum FirewallSku
    {
        Standard = 0,
        Basic = 1,
    }
    public partial class FixedInputData : Azure.Provisioning.MachineLearning.MonitoringInputDataBase
    {
        public FixedInputData() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ForecastHorizon : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ForecastHorizon() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ForecastingModel
    {
        AutoArima = 0,
        Prophet = 1,
        Naive = 2,
        SeasonalNaive = 3,
        Average = 4,
        SeasonalAverage = 5,
        ExponentialSmoothing = 6,
        Arimax = 7,
        TCNForecaster = 8,
        ElasticNet = 9,
        GradientBoosting = 10,
        DecisionTree = 11,
        KNN = 12,
        LassoLars = 13,
        SGD = 14,
        RandomForest = 15,
        ExtremeRandomTrees = 16,
        LightGBM = 17,
        XGBoostRegressor = 18,
    }
    public enum ForecastingPrimaryMetric
    {
        SpearmanCorrelation = 0,
        NormalizedRootMeanSquaredError = 1,
        R2Score = 2,
        NormalizedMeanAbsoluteError = 3,
    }
    public partial class ForecastingSeasonality : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ForecastingSeasonality() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ForecastingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ForecastingSettings() { }
        public Azure.Provisioning.BicepValue<string> CountryOrRegionForHolidays { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CvStepSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningFeatureLag> FeatureLags { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ForecastHorizon ForecastHorizon { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ForecastingSeasonality Seasonality { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningShortSeriesHandlingConfiguration> ShortSeriesHandlingConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.TargetAggregationFunction> TargetAggregateFunction { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TargetLags TargetLags { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TargetRollingWindowSize TargetRollingWindowSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> TimeSeriesIdColumnNames { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningUseStl> UseStl { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ForecastingTrainingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ForecastingTrainingSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ForecastingModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ForecastingModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDnnTraining { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableModelExplainability { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnnxCompatibleModels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStackEnsemble { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableVoteEnsemble { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EnsembleModelDownloadTimeout { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningStackEnsembleSettings StackEnsembleSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class FqdnOutboundRule : Azure.Provisioning.MachineLearning.MachineLearningOutboundRule
    {
        public FqdnOutboundRule() { }
        public Azure.Provisioning.BicepValue<string> Destination { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class GridSamplingAlgorithm : Azure.Provisioning.MachineLearning.SamplingAlgorithm
    {
        public GridSamplingAlgorithm() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageClassification : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public ImageClassification() { }
        public Azure.Provisioning.MachineLearning.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ClassificationPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageClassificationMultilabel : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public ImageClassificationMultilabel() { }
        public Azure.Provisioning.MachineLearning.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageModelSettingsClassification ModelSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ClassificationMultilabelPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ImageModelDistributionSettingsClassification> SearchSpace { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageInstanceSegmentation : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public ImageInstanceSegmentation() { }
        public Azure.Provisioning.MachineLearning.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.InstanceSegmentationPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageLimitSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageLimitSettings() { }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageMetadata : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageMetadata() { }
        public Azure.Provisioning.BicepValue<string> CurrentImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsLatestOsImageVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LatestImageVersion { get { throw null; } }
        public Azure.Provisioning.MachineLearning.OsPatchingStatus OsPatchingStatus { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageModelDistributionSettingsClassification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageModelDistributionSettingsClassification() { }
        public Azure.Provisioning.BicepValue<string> AmsGradient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Augmentations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Beta1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Beta2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Distributed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarlyStopping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarlyStoppingDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarlyStoppingPatience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnableOnnxNormalization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GradientAccumulationStep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LayersToFreeze { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LearningRate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LearningRateScheduler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Momentum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Nesterov { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Optimizer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RandomSeed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StepLRGamma { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StepLRStepSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrainingBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrainingCropSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationCropSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationResizeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WarmupCosineLRCycles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WarmupCosineLRWarmupEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WeightDecay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WeightedLoss { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageModelDistributionSettingsObjectDetection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageModelDistributionSettingsObjectDetection() { }
        public Azure.Provisioning.BicepValue<string> AmsGradient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Augmentations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Beta1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Beta2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BoxDetectionsPerImage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> BoxScoreThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Distributed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarlyStopping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarlyStoppingDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EarlyStoppingPatience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnableOnnxNormalization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> GradientAccumulationStep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LayersToFreeze { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LearningRate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LearningRateScheduler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MaxSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MinSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Momentum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> MultiScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Nesterov { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NmsIouThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Optimizer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RandomSeed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StepLRGamma { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StepLRStepSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TileGridSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TileOverlapRatio { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TilePredictionsNmsThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TrainingBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationIouThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ValidationMetricType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WarmupCosineLRCycles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WarmupCosineLRWarmupEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WeightDecay { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageModelSettingsClassification : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageModelSettingsClassification() { }
        public Azure.Provisioning.BicepValue<string> AdvancedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AmsGradient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Augmentations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Beta1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Beta2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CheckpointFrequency { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFlowModelJobInput CheckpointModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CheckpointRunId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Distributed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EarlyStopping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EarlyStoppingDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EarlyStoppingPatience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnnxNormalization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> GradientAccumulationStep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LayersToFreeze { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> LearningRate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.LearningRateScheduler> LearningRateScheduler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Momentum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Nesterov { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.StochasticOptimizer> Optimizer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RandomSeed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> StepLRGamma { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StepLRStepSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrainingBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrainingCropSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ValidationBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ValidationCropSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ValidationResizeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> WarmupCosineLRCycles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WarmupCosineLRWarmupEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> WeightDecay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WeightedLoss { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageModelSettingsObjectDetection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageModelSettingsObjectDetection() { }
        public Azure.Provisioning.BicepValue<string> AdvancedSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> AmsGradient { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Augmentations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Beta1 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Beta2 { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> BoxDetectionsPerImage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> BoxScoreThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> CheckpointFrequency { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFlowModelJobInput CheckpointModel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CheckpointRunId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Distributed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EarlyStopping { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EarlyStoppingDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EarlyStoppingPatience { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnnxNormalization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EvaluationFrequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> GradientAccumulationStep { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ImageSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> LayersToFreeze { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> LearningRate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.LearningRateScheduler> LearningRateScheduler { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningModelSize> ModelSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> Momentum { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> MultiScale { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Nesterov { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> NmsIouThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NumberOfWorkers { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.StochasticOptimizer> Optimizer { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> RandomSeed { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> StepLRGamma { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> StepLRStepSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TileGridSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> TileOverlapRatio { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> TilePredictionsNmsThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TrainingBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ValidationBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> ValidationIouThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ValidationMetricType> ValidationMetricType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> WarmupCosineLRCycles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WarmupCosineLRWarmupEpochs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<float> WeightDecay { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageObjectDetection : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public ImageObjectDetection() { }
        public Azure.Provisioning.MachineLearning.ImageLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageModelSettingsObjectDetection ModelSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ObjectDetectionPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ImageModelDistributionSettingsObjectDetection> SearchSpace { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ImageSweepSettings SweepSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageSetting() { }
        public Azure.Provisioning.BicepValue<string> Reference { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ImageType> Type { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ImageSweepSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ImageSweepSettings() { }
        public Azure.Provisioning.MachineLearning.MachineLearningEarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.SamplingAlgorithmType> SamplingAlgorithm { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ImageType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="docker")]
        Docker = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="azureml")]
        Azureml = 1,
    }
    public partial class IndexColumn : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public IndexColumn() { }
        public Azure.Provisioning.BicepValue<string> ColumnName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.FeatureDataType> DataType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum InstanceSegmentationPrimaryMetric
    {
        MeanAveragePrecision = 0,
    }
    public enum IsolationMode
    {
        Disabled = 0,
        AllowInternetOutbound = 1,
        AllowOnlyApprovedOutbound = 2,
    }
    public partial class JobAllNodes : Azure.Provisioning.MachineLearning.JobNodes
    {
        public JobAllNodes() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobInputType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="literal")]
        Literal = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uri_file")]
        UriFile = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uri_folder")]
        UriFolder = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mltable")]
        Mltable = 3,
        [System.Runtime.Serialization.DataMemberAttribute(Name="custom_model")]
        CustomModel = 4,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mlflow_model")]
        MlflowModel = 5,
        [System.Runtime.Serialization.DataMemberAttribute(Name="triton_model")]
        TritonModel = 6,
    }
    public partial class JobNodes : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JobNodes() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum JobTier
    {
        Null = 0,
        Spot = 1,
        Basic = 2,
        Standard = 3,
        Premium = 4,
    }
    public partial class JupyterKernelConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public JupyterKernelConfig() { }
        public Azure.Provisioning.BicepList<string> Argv { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Language { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class KeyVaultProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public KeyVaultProperties() { }
        public Azure.Provisioning.BicepValue<string> IdentityClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyIdentifier { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> KeyVaultArmId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum LearningRateScheduler
    {
        None = 0,
        WarmupCosine = 1,
        Step = 2,
    }
    public partial class MachineLearningAccountKeyDatastoreCredentials : Azure.Provisioning.MachineLearning.MachineLearningDatastoreCredentials
    {
        public MachineLearningAccountKeyDatastoreCredentials() { }
        public Azure.Provisioning.BicepValue<string> SecretsKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAksCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningAksCompute() { }
        public Azure.Provisioning.MachineLearning.MachineLearningAksComputeProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAksComputeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningAksComputeProperties() { }
        public Azure.Provisioning.BicepValue<int> AgentCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AgentVmSize { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningAksNetworkingConfiguration AksNetworkingConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClusterFqdn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningClusterPurpose> ClusterPurpose { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LoadBalancerSubnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningLoadBalancerType> LoadBalancerType { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSslConfiguration SslConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningComputeSystemService> SystemServices { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAksNetworkingConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningAksNetworkingConfiguration() { }
        public Azure.Provisioning.BicepValue<string> DnsServiceIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerBridgeCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceCidr { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAllFeatures : Azure.Provisioning.MachineLearning.MonitoringFeatureFilterBase
    {
        public MachineLearningAllFeatures() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningAllocationState
    {
        Steady = 0,
        Resizing = 1,
    }
    public enum MachineLearningApplicationSharingPolicy
    {
        Personal = 0,
        Shared = 1,
    }
    public partial class MachineLearningAssetReferenceBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningAssetReferenceBase() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAutoPauseProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningAutoPauseProperties() { }
        public Azure.Provisioning.BicepValue<int> DelayInMinutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAutoScaleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningAutoScaleProperties() { }
        public Azure.Provisioning.BicepValue<bool> Enabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxNodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinNodeCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAzureBlobDatastore : Azure.Provisioning.MachineLearning.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureBlobDatastore() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningServiceDataAccessAuthIdentity> ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAzureDataLakeGen1Datastore : Azure.Provisioning.MachineLearning.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureDataLakeGen1Datastore() { }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningServiceDataAccessAuthIdentity> ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StoreName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAzureDataLakeGen2Datastore : Azure.Provisioning.MachineLearning.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureDataLakeGen2Datastore() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Filesystem { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningServiceDataAccessAuthIdentity> ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningAzureFileDatastore : Azure.Provisioning.MachineLearning.MachineLearningDatastoreProperties
    {
        public MachineLearningAzureFileDatastore() { }
        public Azure.Provisioning.BicepValue<string> AccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FileShareName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningServiceDataAccessAuthIdentity> ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningBatchDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningBatchDeployment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningBatchEndpoint Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningBatchDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningBatchDeployment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningBatchDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningBatchDeploymentProperties() { }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Compute { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.BatchDeploymentConfiguration DeploymentConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ErrorThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningBatchLoggingLevel> LoggingLevel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrencyPerInstance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<long> MiniBatchSize { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningAssetReferenceBase Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningBatchOutputAction> OutputAction { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OutputFileName { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningDeploymentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningDeploymentResourceConfiguration Resources { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningBatchRetrySettings RetrySettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningBatchEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningBatchEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningBatchEndpointProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningBatchEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningBatchEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningBatchEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEndpointAuthMode> AuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultsDeploymentName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEndpointAuthKeys Keys { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEndpointProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> ScoringUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> SwaggerUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningBatchLoggingLevel
    {
        Info = 0,
        Warning = 1,
        Debug = 2,
    }
    public enum MachineLearningBatchOutputAction
    {
        SummaryOnly = 0,
        AppendRow = 1,
    }
    public partial class MachineLearningBatchRetrySettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningBatchRetrySettings() { }
        public Azure.Provisioning.BicepValue<int> MaxRetries { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningBuildContext : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningBuildContext() { }
        public Azure.Provisioning.BicepValue<System.Uri> ContextUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DockerfilePath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningCachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class MachineLearningCertificateDatastoreCredentials : Azure.Provisioning.MachineLearning.MachineLearningDatastoreCredentials
    {
        public MachineLearningCertificateDatastoreCredentials() { }
        public Azure.Provisioning.BicepValue<System.Uri> AuthorityUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretsCertificate { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Thumbprint { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningClusterPurpose
    {
        FastProd = 0,
        DenseProd = 1,
        DevTest = 2,
    }
    public partial class MachineLearningCodeConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningCodeConfiguration() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CodeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScoringScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCodeContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningCodeContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningCodeContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningCodeContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningCodeContainerProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCodeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningCodeVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningCodeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningCodeVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningCodeVersionProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> CodeUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCommandJob : Azure.Provisioning.MachineLearning.MachineLearningJobProperties
    {
        public MachineLearningCommandJob() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CodeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDistributionConfiguration Distribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> LimitsTimeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Parameters { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.JobTier> QueueJobTier { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningJobResourceConfiguration Resources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCommandJobLimits : Azure.Provisioning.MachineLearning.MachineLearningJobLimits
    {
        public MachineLearningCommandJobLimits() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComponentContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningComponentContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComponentContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningComponentContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningComponentContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComponentContainerProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComponentVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningComponentVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComponentContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComponentVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningComponentVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningComponentVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComponentVersionProperties() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> ComponentSpec { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCompute : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningCompute(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningCompute FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningComputeInstance : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningComputeInstance() { }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceApplication : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceApplication() { }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> EndpointUri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceAssignedUser : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceAssignedUser() { }
        public Azure.Provisioning.BicepValue<string> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningComputeInstanceAuthorizationType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="personal")]
        Personal = 0,
    }
    public enum MachineLearningComputeInstanceAutosave
    {
        None = 0,
        Local = 1,
        Remote = 2,
    }
    public partial class MachineLearningComputeInstanceConnectivityEndpoints : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceConnectivityEndpoints() { }
        public Azure.Provisioning.BicepValue<string> PrivateIpAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublicIpAddress { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceContainer : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceContainer() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceAutosave> Autosave { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceEnvironmentInfo Environment { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Gpu { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningNetwork> Network { get { throw null; } }
        public Azure.Provisioning.BicepList<System.BinaryData> Services { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceCreatedBy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceCreatedBy() { }
        public Azure.Provisioning.BicepValue<string> UserId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> UserOrgId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceDataDisk : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceDataDisk() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningCachingType> Caching { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> DiskSizeGB { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> Lun { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningStorageAccountType> StorageAccountType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceDataMount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceDataMount() { }
        public Azure.Provisioning.BicepValue<string> CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Error { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningMountAction> MountAction { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> MountedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MountMode> MountMode { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MountName { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MountPath { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningMountState> MountState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningSourceType> SourceType { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceEnvironmentInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceEnvironmentInfo() { }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceLastOperation : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceLastOperation() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOperationName> OperationName { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> OperationOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOperationStatus> OperationStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOperationTrigger> OperationTrigger { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceApplication> Applications { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningApplicationSharingPolicy> ApplicationSharingPolicy { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceAuthorizationType> ComputeInstanceAuthorizationType { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceConnectivityEndpoints ConnectivityEndpoints { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceContainer> Containers { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceCreatedBy CreatedBy { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.CustomService> CustomServices { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceDataDisk> DataDisks { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceDataMount> DataMounts { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> EnableNodePublicIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableSSO { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningError> Errors { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> IdleTimeBeforeShutdown { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceLastOperation LastOperation { get { throw null; } }
        public Azure.Provisioning.MachineLearning.ImageMetadata OSImageMetadata { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceAssignedUser PersonalComputeInstanceAssignedUser { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ComputeStartStopSchedule> SchedulesComputeStartStop { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningScriptsToExecute Scripts { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceSshSettings SshSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningComputeInstanceState> State { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VersionsRuntime { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> VmSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeInstanceSshSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeInstanceSshSettings() { }
        public Azure.Provisioning.BicepValue<string> AdminPublicKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdminUserName { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> SshPort { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningSshPublicAccess> SshPublicAccess { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningComputeInstanceState
    {
        Creating = 0,
        CreateFailed = 1,
        Deleting = 2,
        Running = 3,
        Restarting = 4,
        Resizing = 5,
        JobRunning = 6,
        SettingUp = 7,
        SetupFailed = 8,
        Starting = 9,
        Stopped = 10,
        Stopping = 11,
        UserSettingUp = 12,
        UserSetupFailed = 13,
        Unknown = 14,
        Unusable = 15,
    }
    public enum MachineLearningComputePowerAction
    {
        Start = 0,
        Stop = 1,
    }
    public partial class MachineLearningComputeProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeProperties() { }
        public Azure.Provisioning.BicepValue<string> ComputeLocation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> CreatedOn { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> DisableLocalAuth { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAttachedCompute { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ModifiedOn { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningError> ProvisioningErrors { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningComputeProvisioningStatus
    {
        Completed = 0,
        Provisioning = 1,
        Failed = 2,
    }
    public enum MachineLearningComputeRecurrenceFrequency
    {
        Minute = 0,
        Hour = 1,
        Day = 2,
        Week = 3,
        Month = 4,
    }
    public partial class MachineLearningComputeRecurrenceSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeRecurrenceSchedule() { }
        public Azure.Provisioning.BicepList<int> Hours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Minutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> MonthDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningComputeWeekDay> WeekDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningComputeSystemService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningComputeSystemService() { }
        public Azure.Provisioning.BicepValue<string> PublicIpAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SystemServiceType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Version { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningComputeWeekDay
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public enum MachineLearningConnectionCategory
    {
        PythonFeed = 0,
        ContainerRegistry = 1,
        Git = 2,
        S3 = 3,
        Snowflake = 4,
        AzureKeyVault = 5,
        AzureSqlDb = 6,
        AzureSynapseAnalytics = 7,
        AzureMySqlDb = 8,
        AzurePostgresDb = 9,
        ADLSGen2 = 10,
        AzureContainerAppEnvironment = 11,
        Redis = 12,
        ApiKey = 13,
        AzureOpenAI = 14,
        AIServices = 15,
        CognitiveSearch = 16,
        CognitiveService = 17,
        CustomKeys = 18,
        AzureBlob = 19,
        AzureStorageAccount = 20,
        AzureOneLake = 21,
        CosmosDb = 22,
        CosmosDbMongoDbApi = 23,
        AzureDataExplorer = 24,
        AzureMariaDb = 25,
        AzureDatabricksDeltaLake = 26,
        AzureSqlMi = 27,
        AzureTableStorage = 28,
        AmazonRdsForOracle = 29,
        AmazonRdsForSqlServer = 30,
        AmazonRedshift = 31,
        Db2 = 32,
        Drill = 33,
        GoogleBigQuery = 34,
        Greenplum = 35,
        Hbase = 36,
        Hive = 37,
        Impala = 38,
        Informix = 39,
        MariaDb = 40,
        MicrosoftAccess = 41,
        MySql = 42,
        Netezza = 43,
        Oracle = 44,
        Phoenix = 45,
        PostgreSql = 46,
        Presto = 47,
        SapOpenHub = 48,
        SapBw = 49,
        SapHana = 50,
        SapTable = 51,
        Spark = 52,
        SqlServer = 53,
        Sybase = 54,
        Teradata = 55,
        Vertica = 56,
        Pinecone = 57,
        Databricks = 58,
        Cassandra = 59,
        Couchbase = 60,
        MongoDbV2 = 61,
        MongoDbAtlas = 62,
        AmazonS3Compatible = 63,
        FileServer = 64,
        FtpServer = 65,
        GoogleCloudStorage = 66,
        Hdfs = 67,
        OracleCloudStorage = 68,
        Sftp = 69,
        GenericHttp = 70,
        ODataRest = 71,
        Odbc = 72,
        GenericRest = 73,
        RemoteTool = 74,
        AmazonMws = 75,
        Concur = 76,
        Dynamics = 77,
        DynamicsAx = 78,
        DynamicsCrm = 79,
        GoogleAdWords = 80,
        Hubspot = 81,
        Jira = 82,
        Magento = 83,
        Marketo = 84,
        Office365 = 85,
        Eloqua = 86,
        Responsys = 87,
        OracleServiceCloud = 88,
        PayPal = 89,
        QuickBooks = 90,
        Salesforce = 91,
        SalesforceServiceCloud = 92,
        SalesforceMarketingCloud = 93,
        SapCloudForCustomer = 94,
        SapEcc = 95,
        ServiceNow = 96,
        SharePointOnlineList = 97,
        Shopify = 98,
        Square = 99,
        WebTable = 100,
        Xero = 101,
        Zoho = 102,
        GenericContainerRegistry = 103,
        Elasticsearch = 104,
        AppInsights = 105,
        AppConfig = 106,
        OpenAI = 107,
        Serp = 108,
        BingLLMSearch = 109,
        Serverless = 110,
        ManagedOnlineEndpoint = 111,
        ApiManagement = 112,
        ModelGateway = 113,
        GroundingWithBingSearch = 114,
        GroundingWithCustomSearch = 115,
        Sharepoint = 116,
        MicrosoftFabric = 117,
        PowerPlatformEnvironment = 118,
        RemoteA2A = 119,
    }
    public partial class MachineLearningContainerResourceRequirements : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningContainerResourceRequirements() { }
        public Azure.Provisioning.MachineLearning.MachineLearningContainerResourceSettings ContainerResourceLimits { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningContainerResourceSettings ContainerResourceRequests { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningContainerResourceSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningContainerResourceSettings() { }
        public Azure.Provisioning.BicepValue<string> Cpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Gpu { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Memory { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCustomModelJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningCustomModelJobInput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningInputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningCustomModelJobOutput : Azure.Provisioning.MachineLearning.MachineLearningJobOutput
    {
        public MachineLearningCustomModelJobOutput() { }
        public Azure.Provisioning.BicepValue<string> AssetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOutputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDatabricksCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningDatabricksCompute() { }
        public Azure.Provisioning.MachineLearning.MachineLearningDatabricksProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDatabricksProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDatabricksProperties() { }
        public Azure.Provisioning.BicepValue<string> DatabricksAccessToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> WorkspaceUri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDataContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningDataContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDataContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningDataContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningDataContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDataContainerProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningDataType> DataType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDataFactoryCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningDataFactoryCompute() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDataLakeAnalytics : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningDataLakeAnalytics() { }
        public Azure.Provisioning.BicepValue<string> DataLakeStoreAccountName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDataPathAssetReference : Azure.Provisioning.MachineLearning.MachineLearningAssetReferenceBase
    {
        public MachineLearningDataPathAssetReference() { }
        public Azure.Provisioning.BicepValue<string> DatastoreId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDatastore : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningDatastore(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDatastoreProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningDatastore FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningDatastoreCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDatastoreCredentials() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDatastoreProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDatastoreProperties() { }
        public Azure.Provisioning.MachineLearning.MachineLearningDatastoreCredentials Credentials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsDefault { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningDataType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="uri_file")]
        UriFile = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="uri_folder")]
        UriFolder = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="mltable")]
        Mltable = 2,
    }
    public partial class MachineLearningDataVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningDataVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDataContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDataVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningDataVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningDataVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDataVersionProperties() { }
        public Azure.Provisioning.BicepValue<System.Uri> DataUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningDayOfWeek
    {
        Monday = 0,
        Tuesday = 1,
        Wednesday = 2,
        Thursday = 3,
        Friday = 4,
        Saturday = 5,
        Sunday = 6,
    }
    public partial class MachineLearningDefaultScaleSettings : Azure.Provisioning.MachineLearning.MachineLearningOnlineScaleSettings
    {
        public MachineLearningDefaultScaleSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningDeploymentProvisioningState
    {
        Creating = 0,
        Deleting = 1,
        Scaling = 2,
        Updating = 3,
        Succeeded = 4,
        Failed = 5,
        Canceled = 6,
    }
    public partial class MachineLearningDeploymentResourceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDeploymentResourceConfiguration() { }
        public Azure.Provisioning.BicepValue<int> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstanceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningDistributionConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningDistributionConfiguration() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningEarlyTerminationPolicy : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningEarlyTerminationPolicy() { }
        public Azure.Provisioning.BicepValue<int> DelayEvaluation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> EvaluationInterval { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningEgressPublicNetworkAccessType
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum MachineLearningEncryptionStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class MachineLearningEndpointAuthKeys : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningEndpointAuthKeys() { }
        public Azure.Provisioning.BicepValue<string> PrimaryKey { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecondaryKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningEndpointAuthMode
    {
        AMLToken = 0,
        Key = 1,
        AADToken = 2,
    }
    public enum MachineLearningEndpointProvisioningState
    {
        Creating = 0,
        Deleting = 1,
        Succeeded = 2,
        Failed = 3,
        Updating = 4,
        Canceled = 5,
    }
    public partial class MachineLearningEndpointScheduleAction : Azure.Provisioning.MachineLearning.MachineLearningScheduleAction
    {
        public MachineLearningEndpointScheduleAction() { }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> EndpointInvocationDefinition { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningEnvironmentContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningEnvironmentContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEnvironmentContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningEnvironmentContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningEnvironmentContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningEnvironmentContainerProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningEnvironmentType
    {
        Curated = 0,
        UserCreated = 1,
    }
    public partial class MachineLearningEnvironmentVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningEnvironmentVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEnvironmentContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEnvironmentVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningEnvironmentVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningEnvironmentVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningEnvironmentVersionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.AutoRebuildSetting> AutoRebuild { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningBuildContext Build { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> CondaFile { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEnvironmentType> EnvironmentType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Image { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningInferenceContainerProperties InferenceConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOperatingSystemType> OSType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Stage { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningError() { }
        public Azure.Provisioning.BicepValue<Azure.ResponseError> Error { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFeature : Azure.Provisioning.Primitives.ProvisionableResource
    {
        internal MachineLearningFeature() : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureSetVersion Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureProperties Properties { get { throw null; } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningFeature FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum MachineLearningFeatureLag
    {
        None = 0,
        Auto = 1,
    }
    public partial class MachineLearningFeatureProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningFeatureProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.FeatureDataType> DataType { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> FeatureName { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFeatureSetContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningFeatureSetContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureSetContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningFeatureSetContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningFeatureSetContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningFeatureSetContainerProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFeatureSetVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningFeatureSetVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureSetContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureSetVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningFeatureSetVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningFeatureSetVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningFeatureSetVersionProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Entities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MaterializationSettings MaterializationSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SpecificationPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Stage { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFeatureStoreEntityContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningFeatureStoreEntityContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureStoreEntityContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningFeatureStoreEntityContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningFeatureStoreEntityContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningFeatureStoreEntityContainerProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFeaturestoreEntityVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningFeaturestoreEntityVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureStoreEntityContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningFeatureStoreEntityVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningFeaturestoreEntityVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningFeatureStoreEntityVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningFeatureStoreEntityVersionProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.IndexColumn> IndexColumns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Stage { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningFeaturizationMode
    {
        Auto = 0,
        Custom = 1,
        Off = 2,
    }
    public partial class MachineLearningFlavorData : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningFlavorData() { }
        public Azure.Provisioning.BicepDictionary<string> Data { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFlowModelJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningFlowModelJobInput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningInputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningFlowModelJobOutput : Azure.Provisioning.MachineLearning.MachineLearningJobOutput
    {
        public MachineLearningFlowModelJobOutput() { }
        public Azure.Provisioning.BicepValue<string> AssetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOutputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningForecasting : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public MachineLearningForecasting() { }
        public Azure.Provisioning.BicepList<string> CvSplitColumnNames { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TableVerticalFeaturizationSettings FeaturizationSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ForecastingSettings ForecastingSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.TableVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NCrossValidations NCrossValidations { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ForecastingPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput TestData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> TestDataSize { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ForecastingTrainingSettings TrainingSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ValidationDataSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WeightColumnName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningGoal
    {
        Minimize = 0,
        Maximize = 1,
    }
    public partial class MachineLearningHDInsightCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningHDInsightCompute() { }
        public Azure.Provisioning.MachineLearning.MachineLearningHDInsightProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningHDInsightProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningHDInsightProperties() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> Address { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningVmSshCredentials AdministratorAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SshPort { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningIdAssetReference : Azure.Provisioning.MachineLearning.MachineLearningAssetReferenceBase
    {
        public MachineLearningIdAssetReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> AssetId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningIdentityConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningIdentityConfiguration() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningInferenceContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningInferenceContainerProperties() { }
        public Azure.Provisioning.MachineLearning.MachineLearningInferenceContainerRoute LivenessRoute { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningInferenceContainerRoute ReadinessRoute { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningInferenceContainerRoute ScoringRoute { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningInferenceContainerRoute StartupRoute { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningInferenceContainerRoute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningInferenceContainerRoute() { }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningInputDeliveryMode
    {
        ReadOnlyMount = 0,
        ReadWriteMount = 1,
        Download = 2,
        Direct = 3,
        EvalMount = 4,
        EvalDownload = 5,
    }
    public partial class MachineLearningInstanceTypeSchema : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningInstanceTypeSchema() { }
        public Azure.Provisioning.BicepDictionary<string> NodeSelector { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningInstanceTypeSchemaResources Resources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningInstanceTypeSchemaResources : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningInstanceTypeSchemaResources() { }
        public Azure.Provisioning.BicepDictionary<string> Limits { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Requests { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJob : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningJob(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningJobProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningJob FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningJobInput : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningJobInput() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJobLimits : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningJobLimits() { }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJobOutput : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningJobOutput() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJobProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningJobProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ComponentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ComputeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExperimentName { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningIdentityConfiguration Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NotificationSetting NotificationSetting { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobService> Services { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningJobStatus> Status { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJobResourceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningJobResourceConfiguration() { }
        public Azure.Provisioning.BicepValue<string> DockerArgs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> DockerArgsList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> InstanceCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstanceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ShmSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJobScheduleAction : Azure.Provisioning.MachineLearning.MachineLearningScheduleAction
    {
        public MachineLearningJobScheduleAction() { }
        public Azure.Provisioning.MachineLearning.MachineLearningJobProperties JobDefinition { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningJobService : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningJobService() { }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> JobServiceType { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.JobNodes Nodes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Port { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Status { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningJobStatus
    {
        NotStarted = 0,
        Starting = 1,
        Provisioning = 2,
        Preparing = 3,
        Queued = 4,
        Running = 5,
        Finalizing = 6,
        CancelRequested = 7,
        Completed = 8,
        Failed = 9,
        Canceled = 10,
        NotResponding = 11,
        Paused = 12,
        Unknown = 13,
    }
    public partial class MachineLearningKubernetesCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningKubernetesCompute() { }
        public Azure.Provisioning.MachineLearning.MachineLearningKubernetesProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningKubernetesOnlineDeployment : Azure.Provisioning.MachineLearning.MachineLearningOnlineDeploymentProperties
    {
        public MachineLearningKubernetesOnlineDeployment() { }
        public Azure.Provisioning.MachineLearning.MachineLearningContainerResourceRequirements ContainerResourceRequirements { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningKubernetesProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningKubernetesProperties() { }
        public Azure.Provisioning.BicepValue<string> DefaultInstanceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionInstanceReleaseTrain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ExtensionPrincipalId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningInstanceTypeSchema> InstanceTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Namespace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RelayConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceBusConnectionString { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VcName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningLiteralJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningLiteralJobInput() { }
        public Azure.Provisioning.BicepValue<string> Value { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningLoadBalancerType
    {
        PublicIp = 0,
        InternalLoadBalancer = 1,
    }
    public enum MachineLearningLogVerbosity
    {
        NotSet = 0,
        Debug = 1,
        Info = 2,
        Warning = 3,
        Error = 4,
        Critical = 5,
    }
    public partial class MachineLearningManagedIdentity : Azure.Provisioning.MachineLearning.MachineLearningIdentityConfiguration
    {
        public MachineLearningManagedIdentity() { }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ObjectId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningManagedIdentityAuthTypeWorkspaceConnection : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningManagedIdentityAuthTypeWorkspaceConnection() { }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionManagedIdentity Credentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningManagedOnlineDeployment : Azure.Provisioning.MachineLearning.MachineLearningOnlineDeploymentProperties
    {
        public MachineLearningManagedOnlineDeployment() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningMarketplacePlan : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningMarketplacePlan() { }
        public Azure.Provisioning.BicepValue<string> OfferId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PlanId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PublisherId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningMarketplaceSubscription : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningMarketplaceSubscription(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningMarketplaceSubscriptionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningMarketplaceSubscription FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningMarketplaceSubscriptionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningMarketplaceSubscriptionProperties() { }
        public Azure.Provisioning.MachineLearning.MachineLearningMarketplacePlan MarketplacePlan { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MarketplaceSubscriptionStatus> MarketplaceSubscriptionStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ModelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MarketplaceSubscriptionProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningModelContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningModelContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningModelContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningModelContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningModelContainerProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningModelContainerProperties() { }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LatestVersion { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> NextVersion { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningModelSize
    {
        None = 0,
        Small = 1,
        Medium = 2,
        Large = 3,
        ExtraLarge = 4,
    }
    public partial class MachineLearningModelVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningModelVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningModelContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningModelVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningModelVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningModelVersionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningModelVersionProperties() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.DatasetReference> Datasets { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningFlavorData> Flavors { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsAnonymous { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsArchived { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> JobName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ModelUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RegistryAssetProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Stage { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningMountAction
    {
        Mount = 0,
        Unmount = 1,
    }
    public enum MachineLearningMountState
    {
        MountRequested = 0,
        Mounted = 1,
        MountFailed = 2,
        UnmountRequested = 3,
        UnmountFailed = 4,
        Unmounted = 5,
    }
    public enum MachineLearningNetwork
    {
        Bridge = 0,
        Host = 1,
    }
    public partial class MachineLearningNodeStateCounts : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningNodeStateCounts() { }
        public Azure.Provisioning.BicepValue<int> IdleNodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> LeavingNodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PreemptedNodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PreparingNodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> RunningNodeCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> UnusableNodeCount { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningNoneAuthTypeWorkspaceConnection : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningNoneAuthTypeWorkspaceConnection() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningNoneDatastoreCredentials : Azure.Provisioning.MachineLearning.MachineLearningDatastoreCredentials
    {
        public MachineLearningNoneDatastoreCredentials() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningNotebookPreparationError : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningNotebookPreparationError() { }
        public Azure.Provisioning.BicepValue<string> ErrorMessage { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> StatusCode { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningNotebookResourceInfo : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningNotebookResourceInfo() { }
        public Azure.Provisioning.BicepValue<string> Fqdn { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsPrivateLinkEnabled { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningNotebookPreparationError NotebookPreparationError { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ResourceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningObjective : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningObjective() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningGoal> Goal { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrimaryMetric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningOnlineDeployment : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningOnlineDeployment(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningOnlineEndpoint Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningOnlineDeploymentProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningOnlineDeployment FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningOnlineDeploymentProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningOnlineDeploymentProperties() { }
        public Azure.Provisioning.BicepValue<bool> AppInsightsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.DataCollector DataCollector { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEgressPublicNetworkAccessType> EgressPublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstanceType { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningProbeSettings LivenessProbe { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Model { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelMountPath { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningDeploymentProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningProbeSettings ReadinessProbe { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningOnlineRequestSettings RequestSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningOnlineScaleSettings ScaleSettings { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningProbeSettings StartupProbe { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningOnlineEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningOnlineEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningOnlineEndpointProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningOnlineEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningOnlineEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningOnlineEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEndpointAuthMode> AuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Compute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEndpointAuthKeys Keys { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<int> MirrorTraffic { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEndpointProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.PublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ScoringUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> SwaggerUri { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<int> Traffic { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningOnlineRequestSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningOnlineRequestSettings() { }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentRequestsPerInstance { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> MaxQueueWait { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> RequestTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningOnlineScaleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningOnlineScaleSettings() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningOperatingSystemType
    {
        Linux = 0,
        Windows = 1,
    }
    public enum MachineLearningOperationName
    {
        Create = 0,
        Start = 1,
        Stop = 2,
        Restart = 3,
        Resize = 4,
        Reimage = 5,
        Delete = 6,
    }
    public enum MachineLearningOperationStatus
    {
        InProgress = 0,
        Succeeded = 1,
        CreateFailed = 2,
        StartFailed = 3,
        StopFailed = 4,
        RestartFailed = 5,
        ResizeFailed = 6,
        ReimageFailed = 7,
        DeleteFailed = 8,
    }
    public enum MachineLearningOperationTrigger
    {
        User = 0,
        Schedule = 1,
        IdleShutdown = 2,
    }
    public enum MachineLearningOSType
    {
        Linux = 0,
        Windows = 1,
    }
    public partial class MachineLearningOutboundRule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningOutboundRule() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.OutboundRuleCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ErrorInformation { get { throw null; } }
        public Azure.Provisioning.BicepList<string> ParentRuleNames { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.OutboundRuleStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningOutboundRuleBasic : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningOutboundRuleBasic(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningOutboundRule Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningOutboundRuleBasic FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum MachineLearningOutputDeliveryMode
    {
        ReadWriteMount = 0,
        Upload = 1,
        Direct = 2,
    }
    public partial class MachineLearningOutputPathAssetReference : Azure.Provisioning.MachineLearning.MachineLearningAssetReferenceBase
    {
        public MachineLearningOutputPathAssetReference() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> JobId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Path { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningPatAuthTypeWorkspaceConnection : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningPatAuthTypeWorkspaceConnection() { }
        public Azure.Provisioning.BicepValue<string> CredentialsPat { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningPipelineJob : Azure.Provisioning.MachineLearning.MachineLearningJobProperties
    {
        public MachineLearningPipelineJob() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<System.BinaryData> Jobs { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> Settings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SourceJobId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningPrivateEndpointConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.WorkspacePrivateEndpointResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningPrivateEndpointConnectionProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningPrivateEndpointConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum MachineLearningPrivateEndpointConnectionProvisioningState
    {
        Succeeded = 0,
        Creating = 1,
        Deleting = 2,
        Failed = 3,
    }
    public partial class MachineLearningPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.EndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningProbeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningProbeSettings() { }
        public Azure.Provisioning.BicepValue<int> FailureThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> InitialDelay { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Period { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SuccessThreshold { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningProvisioningState
    {
        Unknown = 0,
        Updating = 1,
        Creating = 2,
        Deleting = 3,
        Succeeded = 4,
        Failed = 5,
        Canceled = 6,
    }
    public enum MachineLearningRecurrenceFrequency
    {
        Minute = 0,
        Hour = 1,
        Day = 2,
        Week = 3,
        Month = 4,
    }
    public partial class MachineLearningRecurrenceSchedule : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningRecurrenceSchedule() { }
        public Azure.Provisioning.BicepList<int> Hours { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> Minutes { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<int> MonthDays { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningDayOfWeek> WeekDays { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningRecurrenceTrigger : Azure.Provisioning.MachineLearning.MachineLearningTriggerBase
    {
        public MachineLearningRecurrenceTrigger() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningRecurrenceFrequency> Frequency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Interval { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRecurrenceSchedule Schedule { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningRegistry : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistry(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<System.Uri> DiscoveryUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> IntellectualPropertyPublisher { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ManagedResourceGroupAssignedIdentities> ManagedResourceGroupAssignedIdentities { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ManagedResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> MlFlowRegistryUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.RegistryRegionArmDetails> RegionDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.RegistryPrivateEndpointConnection> RegistryPrivateEndpointConnections { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistry FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryCodeContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryCodeContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistry Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryCodeContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryCodeVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryCodeVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistryCodeContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningCodeVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryCodeVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryComponentContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryComponentContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistry Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComponentContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryComponentContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryComponentVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryComponentVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistryComponentContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningComponentVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryComponentVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryDataContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryDataContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistry Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDataContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryDataContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryDataVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryDataVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistryDataContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDataVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryDataVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryEnvironmentContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryEnvironmentContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistry Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEnvironmentContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryEnvironmentContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryEnvironmentVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryEnvironmentVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistryEnvironmentContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningEnvironmentVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryEnvironmentVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryModelContainer : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryModelContainer(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistry Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningModelContainerProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryModelContainer FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningRegistryModelVersion : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningRegistryModelVersion(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRegistryModelContainer Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningModelVersionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningRegistryModelVersion FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum MachineLearningRemoteLoginPortPublicAccess
    {
        Enabled = 0,
        Disabled = 1,
        NotSpecified = 2,
    }
    public partial class MachineLearningSasAuthTypeWorkspaceConnection : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningSasAuthTypeWorkspaceConnection() { }
        public Azure.Provisioning.BicepValue<string> CredentialsSas { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningSasDatastoreCredentials : Azure.Provisioning.MachineLearning.MachineLearningDatastoreCredentials
    {
        public MachineLearningSasDatastoreCredentials() { }
        public Azure.Provisioning.BicepValue<string> SecretsSasToken { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningSchedule : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningSchedule(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningScheduleProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningSchedule FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningScheduleAction : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningScheduleAction() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningScheduleBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningScheduleBase() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningScheduleProvisioningState> ProvisioningStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningScheduleStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningScheduleProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningScheduleProperties() { }
        public Azure.Provisioning.MachineLearning.MachineLearningScheduleAction Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DisplayName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningScheduleProvisioningStatus> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTriggerBase Trigger { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningScheduleProvisioningState
    {
        Completed = 0,
        Provisioning = 1,
        Failed = 2,
    }
    public enum MachineLearningScheduleProvisioningStatus
    {
        Creating = 0,
        Updating = 1,
        Deleting = 2,
        Succeeded = 3,
        Failed = 4,
        Canceled = 5,
    }
    public enum MachineLearningScheduleStatus
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class MachineLearningScriptReference : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningScriptReference() { }
        public Azure.Provisioning.BicepValue<string> ScriptArguments { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ScriptSource { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningScriptsToExecute : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningScriptsToExecute() { }
        public Azure.Provisioning.MachineLearning.MachineLearningScriptReference CreationScript { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningScriptReference StartupScript { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningServerlessEndpoint : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningServerlessEndpoint(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ServerlessEndpointProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningServerlessEndpoint FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public enum MachineLearningServiceDataAccessAuthIdentity
    {
        None = 0,
        WorkspaceSystemAssignedIdentity = 1,
        WorkspaceUserAssignedIdentity = 2,
    }
    public partial class MachineLearningServicePrincipalDatastoreCredentials : Azure.Provisioning.MachineLearning.MachineLearningDatastoreCredentials
    {
        public MachineLearningServicePrincipalDatastoreCredentials() { }
        public Azure.Provisioning.BicepValue<System.Uri> AuthorityUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> ResourceUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningSharedPrivateLinkResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningSharedPrivateLinkResource() { }
        public Azure.Provisioning.BicepValue<string> GroupId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> PrivateLinkResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RequestMessage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.EndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningShortSeriesHandlingConfiguration
    {
        None = 0,
        Auto = 1,
        Pad = 2,
        Drop = 3,
    }
    public partial class MachineLearningSku : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningSku() { }
        public Azure.Provisioning.BicepValue<int> Capacity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Family { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Size { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningSkuTier> Tier { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningSkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
    public enum MachineLearningSourceType
    {
        Dataset = 0,
        Datastore = 1,
        URI = 2,
    }
    public enum MachineLearningSshPublicAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public enum MachineLearningSslConfigStatus
    {
        Disabled = 0,
        Enabled = 1,
        Auto = 2,
    }
    public partial class MachineLearningSslConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningSslConfiguration() { }
        public Azure.Provisioning.BicepValue<string> Cert { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Cname { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Key { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> LeafDomainLabel { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> OverwriteExistingDomain { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningSslConfigStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningStackEnsembleSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningStackEnsembleSettings() { }
        public Azure.Provisioning.BicepValue<System.BinaryData> StackMetaLearnerKWargs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> StackMetaLearnerTrainPercentage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningStackMetaLearnerType> StackMetaLearnerType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningStackMetaLearnerType
    {
        None = 0,
        LogisticRegression = 1,
        LogisticRegressionCV = 2,
        LightGBMClassifier = 3,
        ElasticNet = 4,
        ElasticNetCV = 5,
        LightGBMRegressor = 6,
        LinearRegression = 7,
    }
    public enum MachineLearningStorageAccountType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="Standard_LRS")]
        StandardLRS = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="Premium_LRS")]
        PremiumLRS = 1,
    }
    public partial class MachineLearningSweepJob : Azure.Provisioning.MachineLearning.MachineLearningJobProperties
    {
        public MachineLearningSweepJob() { }
        public Azure.Provisioning.MachineLearning.MachineLearningEarlyTerminationPolicy EarlyTermination { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSweepJobLimits Limits { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningObjective Objective { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.JobTier> QueueJobTier { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.SamplingAlgorithm SamplingAlgorithm { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.BinaryData> SearchSpace { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTrialComponent Trial { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningSweepJobLimits : Azure.Provisioning.MachineLearning.MachineLearningJobLimits
    {
        public MachineLearningSweepJobLimits() { }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxTotalTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TrialTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningSynapseSpark : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningSynapseSpark() { }
        public Azure.Provisioning.MachineLearning.MachineLearningSynapseSparkProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningSynapseSparkProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningSynapseSparkProperties() { }
        public Azure.Provisioning.MachineLearning.MachineLearningAutoPauseProperties AutoPauseProperties { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningAutoScaleProperties AutoScaleProperties { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NodeCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NodeSizeFamily { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PoolName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceGroup { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SparkVersion { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubscriptionId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTable : Azure.Provisioning.MachineLearning.MachineLearningDataVersionProperties
    {
        public MachineLearningTable() { }
        public Azure.Provisioning.BicepList<string> ReferencedUris { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTableJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningTableJobInput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningInputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTableJobOutput : Azure.Provisioning.MachineLearning.MachineLearningJobOutput
    {
        public MachineLearningTableJobOutput() { }
        public Azure.Provisioning.BicepValue<string> AssetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOutputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTargetUtilizationScaleSettings : Azure.Provisioning.MachineLearning.MachineLearningOnlineScaleSettings
    {
        public MachineLearningTargetUtilizationScaleSettings() { }
        public Azure.Provisioning.BicepValue<int> MaxInstances { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MinInstances { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> PollingInterval { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TargetUtilizationPercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTrialComponent : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningTrialComponent() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CodeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Command { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningDistributionConfiguration Distribution { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningJobResourceConfiguration Resources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTriggerBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningTriggerBase() { }
        public Azure.Provisioning.BicepValue<string> EndTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StartTime { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> TimeZone { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningTriggerType
    {
        Recurrence = 0,
        Cron = 1,
    }
    public partial class MachineLearningTritonModelJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningTritonModelJobInput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningInputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningTritonModelJobOutput : Azure.Provisioning.MachineLearning.MachineLearningJobOutput
    {
        public MachineLearningTritonModelJobOutput() { }
        public Azure.Provisioning.BicepValue<string> AssetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOutputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUriFileDataVersion : Azure.Provisioning.MachineLearning.MachineLearningDataVersionProperties
    {
        public MachineLearningUriFileDataVersion() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUriFileJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningUriFileJobInput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningInputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUriFileJobOutput : Azure.Provisioning.MachineLearning.MachineLearningJobOutput
    {
        public MachineLearningUriFileJobOutput() { }
        public Azure.Provisioning.BicepValue<string> AssetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOutputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUriFolderDataVersion : Azure.Provisioning.MachineLearning.MachineLearningDataVersionProperties
    {
        public MachineLearningUriFolderDataVersion() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUriFolderJobInput : Azure.Provisioning.MachineLearning.MachineLearningJobInput
    {
        public MachineLearningUriFolderJobInput() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningInputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUriFolderJobOutput : Azure.Provisioning.MachineLearning.MachineLearningJobOutput
    {
        public MachineLearningUriFolderJobOutput() { }
        public Azure.Provisioning.BicepValue<string> AssetName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningOutputDeliveryMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUserAccountCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningUserAccountCredentials() { }
        public Azure.Provisioning.BicepValue<string> AdminUserName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdminUserPassword { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AdminUserSshPublicKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUserIdentity : Azure.Provisioning.MachineLearning.MachineLearningIdentityConfiguration
    {
        public MachineLearningUserIdentity() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningUsernamePasswordAuthTypeWorkspaceConnection : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public MachineLearningUsernamePasswordAuthTypeWorkspaceConnection() { }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionUsernamePassword Credentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningUseStl
    {
        None = 0,
        Season = 1,
        SeasonTrend = 2,
    }
    public partial class MachineLearningVirtualMachineCompute : Azure.Provisioning.MachineLearning.MachineLearningComputeProperties
    {
        public MachineLearningVirtualMachineCompute() { }
        public Azure.Provisioning.MachineLearning.MachineLearningVirtualMachineProperties Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningVirtualMachineProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningVirtualMachineProperties() { }
        public Azure.Provisioning.BicepValue<System.Net.IPAddress> Address { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningVmSshCredentials AdministratorAccount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsNotebookInstanceCompute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> NotebookServerPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> SshPort { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> VirtualMachineSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MachineLearningVmPriority
    {
        Dedicated = 0,
        LowPriority = 1,
    }
    public partial class MachineLearningVmSshCredentials : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningVmSshCredentials() { }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PrivateKeyData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PublicKeyData { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningWebhook : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningWebhook() { }
        public Azure.Provisioning.BicepValue<string> EventType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningWorkspace : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningWorkspace(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<bool> AllowPublicAccessWhenBehindVnet { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ApplicationInsights { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AssociatedWorkspaces { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ContainerRegistry { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> DiscoveryUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDataIsolation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableServiceSideCMKEncryption { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.EncryptionProperty Encryption { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.FeatureStoreSettings FeatureStoreSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FriendlyName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> HubResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ImageBuildCompute { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsHbiWorkspace { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsProvisionNetworkNow { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> IsStorageHnsEnabled { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsV1LegacyMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> KeyVault { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Kind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ManagedNetworkSettings ManagedNetwork { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> MlFlowTrackingUri { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningNotebookResourceInfo NotebookInfo { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> PrimaryUserAssignedIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningPrivateEndpointConnection> PrivateEndpointConnections { get { throw null; } }
        public Azure.Provisioning.BicepValue<int> PrivateLinkCount { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningProvisioningState> ProvisioningState { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.PublicNetworkAccess> PublicNetworkAccess { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ServerlessComputeSettings ServerlessComputeSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> ServiceManagedResourcesCosmosDbCollectionsThroughput { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceProvisionedResourceGroup { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningSharedPrivateLinkResource> SharedPrivateLinkResources { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningSku Sku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccount { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.SystemDatastoresAuthMode> SystemDatastoresAuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Tags { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } }
        public Azure.Provisioning.MachineLearning.WorkspaceHubConfig WorkspaceHubConfig { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> WorkspaceId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningWorkspace FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningWorkspaceConnection : Azure.Provisioning.Primitives.ProvisionableResource
    {
        public MachineLearningWorkspaceConnection(string bicepIdentifier, string resourceVersion = null) : base (default(string), default(Azure.Core.ResourceType), default(string)) { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Name { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspace Parent { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties Properties { get { throw null; } set { } }
        public Azure.Provisioning.Resources.SystemData SystemData { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
        public static Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnection FromExisting(string bicepIdentifier, string resourceVersion = null) { throw null; }
        public override Azure.Provisioning.Primitives.ResourceNameRequirements GetResourceNameRequirements() { throw null; }
        public static partial class ResourceVersions
        {
            public static readonly string V2025_12_01;
            public static readonly string V2026_03_01;
            public static readonly string V2026_05_01;
        }
    }
    public partial class MachineLearningWorkspaceConnectionManagedIdentity : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningWorkspaceConnectionManagedIdentity() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningWorkspaceConnectionProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningWorkspaceConnectionProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningConnectionCategory> Category { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CreatedByWorkspaceArmId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> Error { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> ExpiryOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.WorkspaceConnectionGroup> Group { get { throw null; } }
        public Azure.Provisioning.BicepValue<bool> IsSharedToAll { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Metadata { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ManagedPERequirement> PeRequirement { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ManagedPEStatus> PeStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> SharedUserList { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> UseWorkspaceManagedIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MachineLearningWorkspaceConnectionUsernamePassword : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MachineLearningWorkspaceConnectionUsernamePassword() { }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecurityToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedComputeIdentity : Azure.Provisioning.MachineLearning.MonitorComputeIdentityBase
    {
        public ManagedComputeIdentity() { }
        public Azure.Provisioning.Resources.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedNetworkKind
    {
        V1 = 0,
        V2 = 1,
    }
    public partial class ManagedNetworkProvisionStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedNetworkProvisionStatus() { }
        public Azure.Provisioning.BicepValue<bool> SparkReady { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ManagedNetworkStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ManagedNetworkSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedNetworkSettings() { }
        public Azure.Provisioning.BicepValue<bool> EnableNetworkMonitor { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> FirewallPublicIpAddress { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.FirewallSku> FirewallSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.IsolationMode> IsolationMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ManagedNetworkKind> ManagedNetworkKind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> NetworkId { get { throw null; } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningOutboundRule> OutboundRules { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.ManagedNetworkProvisionStatus Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ManagedNetworkStatus
    {
        Inactive = 0,
        Active = 1,
    }
    public enum ManagedPERequirement
    {
        Required = 0,
        NotRequired = 1,
        NotApplicable = 2,
    }
    public enum ManagedPEStatus
    {
        Inactive = 0,
        Active = 1,
        NotApplicable = 2,
    }
    public partial class ManagedResourceGroupAssignedIdentities : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ManagedResourceGroupAssignedIdentities() { }
        public Azure.Provisioning.BicepValue<System.Guid> PrincipalId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MarketplaceSubscriptionProvisioningState
    {
        Creating = 0,
        Deleting = 1,
        Succeeded = 2,
        Failed = 3,
        Updating = 4,
        Canceled = 5,
    }
    public enum MarketplaceSubscriptionStatus
    {
        Subscribed = 0,
        Suspended = 1,
        Unsubscribed = 2,
    }
    public partial class MaterializationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MaterializationSettings() { }
        public Azure.Provisioning.MachineLearning.NotificationSetting Notification { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ResourceInstanceType { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningRecurrenceTrigger Schedule { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> SparkConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MaterializationStoreType> StoreType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MaterializationStoreType
    {
        None = 0,
        Online = 1,
        Offline = 2,
        OnlineAndOffline = 3,
    }
    public partial class MedianStoppingPolicy : Azure.Provisioning.MachineLearning.MachineLearningEarlyTerminationPolicy
    {
        public MedianStoppingPolicy() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ModelTaskType
    {
        Classification = 0,
        Regression = 1,
    }
    public partial class MonitorComputeConfigurationBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorComputeConfigurationBase() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorComputeIdentityBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorComputeIdentityBase() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitorDefinition() { }
        public Azure.Provisioning.BicepList<string> AlertNotificationEmails { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitorComputeConfigurationBase ComputeConfiguration { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringTarget MonitoringTarget { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MonitoringSignalBase> Signals { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitoringFeatureDataType
    {
        Numerical = 0,
        Categorical = 1,
    }
    public partial class MonitoringFeatureFilterBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitoringFeatureFilterBase() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitoringInputDataBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitoringInputDataBase() { }
        public Azure.Provisioning.BicepDictionary<string> Columns { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DataContext { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.JobInputType> JobInputType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MonitoringNotificationType
    {
        AmlNotification = 0,
    }
    public partial class MonitoringSignalBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitoringSignalBase() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MonitoringNotificationType> NotificationTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Properties { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitoringTarget : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MonitoringTarget() { }
        public Azure.Provisioning.BicepValue<string> DeploymentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ModelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ModelTaskType> TaskType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MonitorServerlessSparkCompute : Azure.Provisioning.MachineLearning.MonitorComputeConfigurationBase
    {
        public MonitorServerlessSparkCompute() { }
        public Azure.Provisioning.MachineLearning.MonitorComputeIdentityBase ComputeIdentity { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> InstanceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class MountBindOptions : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public MountBindOptions() { }
        public Azure.Provisioning.BicepValue<string> Propagation { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Selinux { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ShouldCreateHostPath { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum MountMode
    {
        ReadOnly = 0,
        ReadWrite = 1,
    }
    public partial class MpiDistributionConfiguration : Azure.Provisioning.MachineLearning.MachineLearningDistributionConfiguration
    {
        public MpiDistributionConfiguration() { }
        public Azure.Provisioning.BicepValue<int> ProcessCountPerInstance { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NCrossValidations : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NCrossValidations() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NetworkingRuleAction
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class NlpVerticalLimitSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NlpVerticalLimitSettings() { }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class NotificationSetting : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public NotificationSetting() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.EmailNotificationEnableType> EmailOn { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Emails { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningWebhook> Webhooks { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NumericalDataDriftMetric
    {
        JensenShannonDistance = 0,
        PopulationStabilityIndex = 1,
        NormalizedWassersteinDistance = 2,
        TwoSampleKolmogorovSmirnovTest = 3,
    }
    public partial class NumericalDataDriftMetricThreshold : Azure.Provisioning.MachineLearning.DataDriftMetricThresholdBase
    {
        public NumericalDataDriftMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.NumericalDataDriftMetric> Metric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NumericalDataQualityMetric
    {
        NullValueRate = 0,
        DataTypeErrorRate = 1,
        OutOfBoundsRate = 2,
    }
    public partial class NumericalDataQualityMetricThreshold : Azure.Provisioning.MachineLearning.DataQualityMetricThresholdBase
    {
        public NumericalDataQualityMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.NumericalDataQualityMetric> Metric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum NumericalPredictionDriftMetric
    {
        JensenShannonDistance = 0,
        PopulationStabilityIndex = 1,
        NormalizedWassersteinDistance = 2,
        TwoSampleKolmogorovSmirnovTest = 3,
    }
    public partial class NumericalPredictionDriftMetricThreshold : Azure.Provisioning.MachineLearning.PredictionDriftMetricThresholdBase
    {
        public NumericalPredictionDriftMetricThreshold() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.NumericalPredictionDriftMetric> Metric { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OAuth2AuthTypeWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public OAuth2AuthTypeWorkspaceConnectionProperties() { }
        public Azure.Provisioning.MachineLearning.WorkspaceConnectionOAuth2 Credentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ObjectDetectionPrimaryMetric
    {
        MeanAveragePrecision = 0,
    }
    public partial class OneLakeDatastore : Azure.Provisioning.MachineLearning.MachineLearningDatastoreProperties
    {
        public OneLakeDatastore() { }
        public Azure.Provisioning.BicepValue<string> ArtifactName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Endpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> OneLakeWorkspaceName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningServiceDataAccessAuthIdentity> ServiceDataAccessAuthIdentity { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class OsPatchingStatus : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public OsPatchingStatus() { }
        public Azure.Provisioning.BicepValue<bool> IsRebootPending { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> LatestPatchTime { get { throw null; } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.MachineLearningError> OsPatchingErrors { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.PatchStatus> PatchStatus { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ScheduledRebootTime { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum OutboundRuleCategory
    {
        Required = 0,
        Recommended = 1,
        UserDefined = 2,
        Dependency = 3,
    }
    public enum OutboundRuleStatus
    {
        Inactive = 0,
        Active = 1,
        Provisioning = 2,
        Deleting = 3,
        Failed = 4,
    }
    public enum PatchStatus
    {
        CompletedWithWarnings = 0,
        Failed = 1,
        InProgress = 2,
        Succeeded = 3,
        Unknown = 4,
    }
    public partial class PredictionDriftMetricThresholdBase : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PredictionDriftMetricThresholdBase() { }
        public Azure.Provisioning.BicepValue<double> ThresholdValue { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PredictionDriftMonitoringSignal : Azure.Provisioning.MachineLearning.MonitoringSignalBase
    {
        public PredictionDriftMonitoringSignal() { }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MonitoringFeatureDataType> FeatureDataTypeOverride { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.PredictionDriftMetricThresholdBase> MetricThresholds { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ProductionData { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MonitoringInputDataBase ReferenceData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateEndpointDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public PrivateEndpointDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServiceResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> SparkEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.OutboundRuleStatus> SparkStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SubresourceTarget { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class PrivateEndpointOutboundRule : Azure.Provisioning.MachineLearning.MachineLearningOutboundRule
    {
        public PrivateEndpointOutboundRule() { }
        public Azure.Provisioning.MachineLearning.PrivateEndpointDestination Destination { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Fqdns { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum PublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class PyTorchDistributionConfiguration : Azure.Provisioning.MachineLearning.MachineLearningDistributionConfiguration
    {
        public PyTorchDistributionConfiguration() { }
        public Azure.Provisioning.BicepValue<int> ProcessCountPerInstance { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RandomSamplingAlgorithm : Azure.Provisioning.MachineLearning.SamplingAlgorithm
    {
        public RandomSamplingAlgorithm() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.RandomSamplingAlgorithmRule> Rule { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> Seed { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RandomSamplingAlgorithmRule
    {
        Random = 0,
        Sobol = 1,
    }
    public partial class RegistryAcrDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistryAcrDetails() { }
        public Azure.Provisioning.MachineLearning.SystemCreatedAcrAccount SystemCreatedAcrAccount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RegistryAssetProvisioningState
    {
        Succeeded = 0,
        Failed = 1,
        Canceled = 2,
        Creating = 3,
        Updating = 4,
        Deleting = 5,
    }
    public partial class RegistryPrivateEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistryPrivateEndpoint() { }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> SubnetArmId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegistryPrivateEndpointConnection : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistryPrivateEndpointConnection() { }
        public Azure.Provisioning.BicepList<string> GroupIds { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> Id { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.RegistryPrivateEndpoint PrivateEndpoint { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ProvisioningState { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.RegistryPrivateLinkServiceConnectionState RegistryPrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegistryPrivateLinkServiceConnectionState : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistryPrivateLinkServiceConnectionState() { }
        public Azure.Provisioning.BicepValue<string> ActionsRequired { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Description { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.EndpointServiceConnectionStatus> Status { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegistryRegionArmDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegistryRegionArmDetails() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.RegistryAcrDetails> AcrDetails { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.AzureLocation> Location { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.StorageAccountDetails> StorageAccountDetails { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RegressionTrainingSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public RegressionTrainingSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.AutoMLVerticalRegressionModel> AllowedTrainingAlgorithms { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.AutoMLVerticalRegressionModel> BlockedTrainingAlgorithms { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDnnTraining { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableModelExplainability { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableOnnxCompatibleModels { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableStackEnsemble { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableVoteEnsemble { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> EnsembleModelDownloadTimeout { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningStackEnsembleSettings StackEnsembleSettings { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class RollingInputData : Azure.Provisioning.MachineLearning.MonitoringInputDataBase
    {
        public RollingInputData() { }
        public Azure.Provisioning.BicepValue<string> PreprocessingComponentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowOffset { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> WindowSize { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum RollingRateType
    {
        Year = 0,
        Month = 1,
        Day = 2,
        Hour = 3,
        Minute = 4,
    }
    public partial class SamplingAlgorithm : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SamplingAlgorithm() { }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SamplingAlgorithmType
    {
        Grid = 0,
        Random = 1,
        Bayesian = 2,
    }
    public partial class ServerlessComputeSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerlessComputeSettings() { }
        public Azure.Provisioning.BicepValue<bool> HasNoPublicIP { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ServerlessComputeCustomSubnet { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServerlessEndpointProperties : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerlessEndpointProperties() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ServerlessInferenceEndpointAuthMode> AuthMode { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ContentSafetyStatus> ContentSafetyStatus { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ServerlessEndpointState> EndpointState { get { throw null; } }
        public Azure.Provisioning.MachineLearning.ServerlessInferenceEndpoint InferenceEndpoint { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> MarketplaceSubscriptionId { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> ModelId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningEndpointProvisioningState> ProvisioningState { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServerlessEndpointState
    {
        Unknown = 0,
        Creating = 1,
        Deleting = 2,
        Suspending = 3,
        Reinstating = 4,
        Online = 5,
        Suspended = 6,
        CreationFailed = 7,
        DeletionFailed = 8,
    }
    public partial class ServerlessInferenceEndpoint : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServerlessInferenceEndpoint() { }
        public Azure.Provisioning.BicepDictionary<string> Headers { get { throw null; } }
        public Azure.Provisioning.BicepValue<System.Uri> Uri { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ServerlessInferenceEndpointAuthMode
    {
        Key = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="AAD")]
        Aad = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="KeyAndAAD")]
        KeyAndAad = 2,
    }
    public partial class ServicePrincipalAuthTypeWorkspaceConnectionProperties : Azure.Provisioning.MachineLearning.MachineLearningWorkspaceConnectionProperties
    {
        public ServicePrincipalAuthTypeWorkspaceConnectionProperties() { }
        public Azure.Provisioning.MachineLearning.WorkspaceConnectionServicePrincipal Credentials { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceTagDestination : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public ServiceTagDestination() { }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.NetworkingRuleAction> Action { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> AddressPrefixes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> PortRanges { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Protocol { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ServiceTag { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class ServiceTagOutboundRule : Azure.Provisioning.MachineLearning.MachineLearningOutboundRule
    {
        public ServiceTagOutboundRule() { }
        public Azure.Provisioning.MachineLearning.ServiceTagDestination Destination { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkJob : Azure.Provisioning.MachineLearning.MachineLearningJobProperties
    {
        public SparkJob() { }
        public Azure.Provisioning.BicepList<string> Archives { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Args { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> CodeId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> Conf { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.SparkJobEntry Entry { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> EnvironmentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> EnvironmentVariables { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Files { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobInput> Inputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> Jars { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.MachineLearning.MachineLearningJobOutput> Outputs { get { throw null; } set { } }
        public Azure.Provisioning.BicepList<string> PyFiles { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.JobTier> QueueJobTier { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.SparkResourceConfiguration Resources { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkJobEntry : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SparkJobEntry() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkJobPythonEntry : Azure.Provisioning.MachineLearning.SparkJobEntry
    {
        public SparkJobPythonEntry() { }
        public Azure.Provisioning.BicepValue<string> File { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkJobScalaEntry : Azure.Provisioning.MachineLearning.SparkJobEntry
    {
        public SparkJobScalaEntry() { }
        public Azure.Provisioning.BicepValue<string> ClassName { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SparkResourceConfiguration : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SparkResourceConfiguration() { }
        public Azure.Provisioning.BicepValue<string> InstanceType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RuntimeVersion { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class StaticInputData : Azure.Provisioning.MachineLearning.MonitoringInputDataBase
    {
        public StaticInputData() { }
        public Azure.Provisioning.BicepValue<string> PreprocessingComponentId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> WindowEnd { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.DateTimeOffset> WindowStart { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum StochasticOptimizer
    {
        None = 0,
        Sgd = 1,
        Adam = 2,
        Adamw = 3,
    }
    public partial class StorageAccountDetails : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public StorageAccountDetails() { }
        public Azure.Provisioning.MachineLearning.SystemCreatedStorageAccount SystemCreatedStorageAccount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SystemCreatedAcrAccount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SystemCreatedAcrAccount() { }
        public Azure.Provisioning.BicepValue<string> AcrAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> AcrAccountSku { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ArmResourceId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class SystemCreatedStorageAccount : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public SystemCreatedStorageAccount() { }
        public Azure.Provisioning.BicepValue<bool> AllowBlobPublicAccess { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Core.ResourceIdentifier> ArmResourceId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> StorageAccountHnsEnabled { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountName { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> StorageAccountType { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum SystemDatastoresAuthMode
    {
        AccessKey = 0,
        Identity = 1,
        UserDelegationSAS = 2,
    }
    public partial class TableVerticalFeaturizationSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TableVerticalFeaturizationSettings() { }
        public Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.BlockedTransformer> BlockedTransformers { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<string> ColumnNameAndTypes { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DatasetLanguage { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> EnableDnnFeaturization { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.MachineLearningFeaturizationMode> Mode { get { throw null; } set { } }
        public Azure.Provisioning.BicepDictionary<Azure.Provisioning.BicepList<Azure.Provisioning.MachineLearning.ColumnTransformer>> TransformerParams { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TableVerticalLimitSettings : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TableVerticalLimitSettings() { }
        public Azure.Provisioning.BicepValue<bool> EnableEarlyTermination { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<double> ExitScore { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxConcurrentTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxCoresPerTrial { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> MaxTrials { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> Timeout { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.TimeSpan> TrialTimeout { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum TargetAggregationFunction
    {
        None = 0,
        Sum = 1,
        Max = 2,
        Min = 3,
        Mean = 4,
    }
    public partial class TargetLags : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetLags() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TargetRollingWindowSize : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public TargetRollingWindowSize() { }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TensorFlowDistributionConfiguration : Azure.Provisioning.MachineLearning.MachineLearningDistributionConfiguration
    {
        public TensorFlowDistributionConfiguration() { }
        public Azure.Provisioning.BicepValue<int> ParameterServerCount { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> WorkerCount { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TextClassification : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public TextClassification() { }
        public Azure.Provisioning.BicepValue<string> FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ClassificationPrimaryMetric> PrimaryMetric { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TextClassificationMultilabel : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public TextClassificationMultilabel() { }
        public Azure.Provisioning.BicepValue<string> FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ClassificationMultilabelPrimaryMetric> PrimaryMetric { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TextNer : Azure.Provisioning.MachineLearning.AutoMLVertical
    {
        public TextNer() { }
        public Azure.Provisioning.BicepValue<string> FeaturizationDatasetLanguage { get { throw null; } set { } }
        public Azure.Provisioning.MachineLearning.NlpVerticalLimitSettings LimitSettings { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.ClassificationPrimaryMetric> PrimaryMetric { get { throw null; } }
        public Azure.Provisioning.MachineLearning.MachineLearningTableJobInput ValidationData { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TopNFeaturesByAttribution : Azure.Provisioning.MachineLearning.MonitoringFeatureFilterBase
    {
        public TopNFeaturesByAttribution() { }
        public Azure.Provisioning.BicepValue<int> Top { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class TruncationSelectionPolicy : Azure.Provisioning.MachineLearning.MachineLearningEarlyTerminationPolicy
    {
        public TruncationSelectionPolicy() { }
        public Azure.Provisioning.BicepValue<int> TruncationPercentage { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum ValidationMetricType
    {
        None = 0,
        Coco = 1,
        Voc = 2,
        CocoVoc = 3,
    }
    public partial class VolumeDefinition : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public VolumeDefinition() { }
        public Azure.Provisioning.MachineLearning.MountBindOptions Bind { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Consistency { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<Azure.Provisioning.MachineLearning.VolumeDefinitionType> DefinitionType { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> ReadOnly { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Source { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Target { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<int> TmpfsSize { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<bool> VolumeNocopy { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum VolumeDefinitionType
    {
        [System.Runtime.Serialization.DataMemberAttribute(Name="bind")]
        Bind = 0,
        [System.Runtime.Serialization.DataMemberAttribute(Name="volume")]
        Volume = 1,
        [System.Runtime.Serialization.DataMemberAttribute(Name="tmpfs")]
        Tmpfs = 2,
        [System.Runtime.Serialization.DataMemberAttribute(Name="npipe")]
        Npipe = 3,
    }
    public partial class WorkspaceConnectionAccessKey : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceConnectionAccessKey() { }
        public Azure.Provisioning.BicepValue<string> AccessKeyId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> SecretAccessKey { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public enum WorkspaceConnectionGroup
    {
        Azure = 0,
        AzureAI = 1,
        Database = 2,
        NoSQL = 3,
        File = 4,
        GenericProtocol = 5,
        ServicesAndApps = 6,
    }
    public partial class WorkspaceConnectionOAuth2 : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceConnectionOAuth2() { }
        public Azure.Provisioning.BicepValue<System.Uri> AuthUri { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DeveloperToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Password { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> RefreshToken { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> Username { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceConnectionServicePrincipal : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceConnectionServicePrincipal() { }
        public Azure.Provisioning.BicepValue<string> ClientId { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> ClientSecret { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<System.Guid> TenantId { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspaceHubConfig : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspaceHubConfig() { }
        public Azure.Provisioning.BicepList<string> AdditionalWorkspaceStorageAccounts { get { throw null; } set { } }
        public Azure.Provisioning.BicepValue<string> DefaultWorkspaceResourceGroup { get { throw null; } set { } }
        protected override void DefineProvisionableProperties() { }
    }
    public partial class WorkspacePrivateEndpointResource : Azure.Provisioning.Primitives.ProvisionableConstruct
    {
        public WorkspacePrivateEndpointResource() { }
        public Azure.Provisioning.BicepValue<string> Id { get { throw null; } }
        public Azure.Provisioning.BicepValue<string> SubnetArmId { get { throw null; } }
        protected override void DefineProvisionableProperties() { }
    }
}
