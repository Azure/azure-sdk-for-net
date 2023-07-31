namespace Azure.Temp.Batch.Models
{
    public partial class AccountListPoolNodeCountsOptions
    {
        public AccountListPoolNodeCountsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class AccountListSupportedImagesOptions
    {
        public AccountListSupportedImagesOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class AffinityInformation
    {
        public AffinityInformation(string affinityId) { }
        public string AffinityId { get { throw null; } set { } }
    }
    public enum AllocationState
    {
        Steady = 0,
        Resizing = 1,
        Stopping = 2,
    }
    public partial class ApplicationGetOptions
    {
        public ApplicationGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ApplicationListOptions
    {
        public ApplicationListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ApplicationPackageReference
    {
        public ApplicationPackageReference(string applicationId) { }
        public string ApplicationId { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
    }
    public partial class ApplicationSummary
    {
        internal ApplicationSummary() { }
        public string DisplayName { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Versions { get { throw null; } }
    }
    public partial class AuthenticationTokenSettings
    {
        public AuthenticationTokenSettings() { }
        public System.Collections.Generic.IList<string> Access { get { throw null; } }
    }
    public partial class AutoPoolSpecification
    {
        public AutoPoolSpecification(Azure.Temp.Batch.Models.PoolLifetimeOption poolLifetimeOption) { }
        public string AutoPoolIdPrefix { get { throw null; } set { } }
        public bool? KeepAlive { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolSpecification Pool { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolLifetimeOption PoolLifetimeOption { get { throw null; } set { } }
    }
    public partial class AutoScaleRun
    {
        internal AutoScaleRun() { }
        public Azure.Temp.Batch.Models.AutoScaleRunError Error { get { throw null; } }
        public string Results { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
    }
    public partial class AutoScaleRunError
    {
        internal AutoScaleRunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.NameValuePair> Values { get { throw null; } }
    }
    public enum AutoUserScope
    {
        Task = 0,
        Pool = 1,
    }
    public partial class AutoUserSpecification
    {
        public AutoUserSpecification() { }
        public Azure.Temp.Batch.Models.ElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.AutoUserScope? Scope { get { throw null; } set { } }
    }
    public partial class AzureBlobFileSystemConfiguration
    {
        public AzureBlobFileSystemConfiguration(string accountName, string containerName, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string BlobfuseOptions { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ComputeNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string SasKey { get { throw null; } set { } }
    }
    public partial class AzureFileShareConfiguration
    {
        public AzureFileShareConfiguration(string accountName, string azureFileUrl, string accountKey, string relativeMountPath) { }
        public string AccountKey { get { throw null; } set { } }
        public string AccountName { get { throw null; } set { } }
        public string AzureFileUrl { get { throw null; } set { } }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
    }
    public partial class BatchError
    {
        internal BatchError() { }
        public string Code { get { throw null; } }
        public Azure.Temp.Batch.Models.ErrorMessage Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.BatchErrorDetail> Values { get { throw null; } }
    }
    public partial class BatchErrorDetail
    {
        internal BatchErrorDetail() { }
        public string Key { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class BatchPoolIdentity
    {
        internal BatchPoolIdentity() { }
        public Azure.Temp.Batch.Models.PoolIdentityType Type { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    public enum CachingType
    {
        None = 0,
        ReadOnly = 1,
        ReadWrite = 2,
    }
    public partial class Certificate
    {
        internal Certificate() { }
        public Azure.Temp.Batch.Models.DeleteCertificateError DeleteCertificateError { get { throw null; } }
        public Azure.Temp.Batch.Models.CertificateState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public string PublicData { get { throw null; } }
        public Azure.Temp.Batch.Models.CertificateState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public string Thumbprint { get { throw null; } }
        public string ThumbprintAlgorithm { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class CertificateAddOptions
    {
        public CertificateAddOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class CertificateAddParameter
    {
        public CertificateAddParameter(string thumbprint, string thumbprintAlgorithm, string data) { }
        public Azure.Temp.Batch.Models.CertificateFormat? CertificateFormat { get { throw null; } set { } }
        public string Data { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } }
        public string ThumbprintAlgorithm { get { throw null; } }
    }
    public partial class CertificateCancelDeletionOptions
    {
        public CertificateCancelDeletionOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class CertificateDeleteOptions
    {
        public CertificateDeleteOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum CertificateFormat
    {
        Pfx = 0,
        Cer = 1,
    }
    public partial class CertificateGetOptions
    {
        public CertificateGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class CertificateListOptions
    {
        public CertificateListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class CertificateReference
    {
        public CertificateReference(string thumbprint, string thumbprintAlgorithm) { }
        public Azure.Temp.Batch.Models.CertificateStoreLocation? StoreLocation { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        public string Thumbprint { get { throw null; } set { } }
        public string ThumbprintAlgorithm { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.CertificateVisibility> Visibility { get { throw null; } }
    }
    public enum CertificateState
    {
        Active = 0,
        Deleting = 1,
        DeleteFailed = 2,
    }
    public enum CertificateStoreLocation
    {
        CurrentUser = 0,
        LocalMachine = 1,
    }
    public enum CertificateVisibility
    {
        StartTask = 0,
        Task = 1,
        RemoteUser = 2,
    }
    public partial class CifsMountConfiguration
    {
        public CifsMountConfiguration(string username, string source, string relativeMountPath, string password) { }
        public string MountOptions { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
        public string Username { get { throw null; } set { } }
    }
    public partial class CloudJob
    {
        internal CloudJob() { }
        public bool? AllowTaskPreemption { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.EnvironmentSetting> CommonEnvironmentSettings { get { throw null; } }
        public Azure.Temp.Batch.Models.JobConstraints Constraints { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.Temp.Batch.Models.JobExecutionInformation ExecutionInfo { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Temp.Batch.Models.JobManagerTask JobManagerTask { get { throw null; } }
        public Azure.Temp.Batch.Models.JobPreparationTask JobPreparationTask { get { throw null; } }
        public Azure.Temp.Batch.Models.JobReleaseTask JobReleaseTask { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public int? MaxParallelTasks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.JobNetworkConfiguration NetworkConfiguration { get { throw null; } }
        public Azure.Temp.Batch.Models.OnAllTasksComplete? OnAllTasksComplete { get { throw null; } }
        public Azure.Temp.Batch.Models.OnTaskFailure? OnTaskFailure { get { throw null; } }
        public Azure.Temp.Batch.Models.PoolInformation PoolInfo { get { throw null; } }
        public Azure.Temp.Batch.Models.JobState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public int? Priority { get { throw null; } }
        public Azure.Temp.Batch.Models.JobState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Temp.Batch.Models.JobStatistics Stats { get { throw null; } }
        public string Url { get { throw null; } }
        public bool? UsesTaskDependencies { get { throw null; } }
    }
    public partial class CloudJobSchedule
    {
        internal CloudJobSchedule() { }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.Temp.Batch.Models.JobScheduleExecutionInformation ExecutionInfo { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Temp.Batch.Models.JobSpecification JobSpecification { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.JobScheduleState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public Azure.Temp.Batch.Models.Schedule Schedule { get { throw null; } }
        public Azure.Temp.Batch.Models.JobScheduleState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Temp.Batch.Models.JobScheduleStatistics Stats { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class CloudPool
    {
        internal CloudPool() { }
        public Azure.Temp.Batch.Models.AllocationState? AllocationState { get { throw null; } }
        public System.DateTimeOffset? AllocationStateTransitionTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ApplicationLicenses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } }
        public string AutoScaleFormula { get { throw null; } }
        public Azure.Temp.Batch.Models.AutoScaleRun AutoScaleRun { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.CertificateReference> CertificateReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.CloudServiceConfiguration CloudServiceConfiguration { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public int? CurrentDedicatedNodes { get { throw null; } }
        public int? CurrentLowPriorityNodes { get { throw null; } }
        public Azure.Temp.Batch.Models.NodeCommunicationMode? CurrentNodeCommunicationMode { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? EnableAutoScale { get { throw null; } }
        public bool? EnableInterNodeCommunication { get { throw null; } }
        public string ETag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.Temp.Batch.Models.BatchPoolIdentity Identity { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Temp.Batch.Models.NetworkConfiguration NetworkConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.ResizeError> ResizeErrors { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } }
        public Azure.Temp.Batch.Models.StartTask StartTask { get { throw null; } }
        public Azure.Temp.Batch.Models.PoolState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Temp.Batch.Models.PoolStatistics Stats { get { throw null; } }
        public int? TargetDedicatedNodes { get { throw null; } }
        public int? TargetLowPriorityNodes { get { throw null; } }
        public Azure.Temp.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } }
        public int? TaskSlotsPerNode { get { throw null; } }
        public string Url { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Temp.Batch.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class CloudServiceConfiguration
    {
        public CloudServiceConfiguration(string osFamily) { }
        public string OsFamily { get { throw null; } set { } }
        public string OsVersion { get { throw null; } set { } }
    }
    public partial class CloudTask
    {
        internal CloudTask() { }
        public Azure.Temp.Batch.Models.AffinityInformation AffinityInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.AuthenticationTokenSettings AuthenticationTokenSettings { get { throw null; } }
        public string CommandLine { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskConstraints Constraints { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskDependencies DependsOn { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string ETag { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskExecutionInformation ExecutionInfo { get { throw null; } }
        public Azure.Temp.Batch.Models.ExitConditions ExitConditions { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public Azure.Temp.Batch.Models.MultiInstanceSettings MultiInstanceSettings { get { throw null; } }
        public Azure.Temp.Batch.Models.ComputeNodeInformation NodeInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.OutputFile> OutputFiles { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public int? RequiredSlots { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskStatistics Stats { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.Temp.Batch.Models.UserIdentity UserIdentity { get { throw null; } }
    }
    public partial class CloudTaskListSubtasksResult
    {
        internal CloudTaskListSubtasksResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.SubtaskInformation> Value { get { throw null; } }
    }
    public partial class ComputeNode
    {
        internal ComputeNode() { }
        public string AffinityId { get { throw null; } }
        public System.DateTimeOffset? AllocationTime { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.CertificateReference> CertificateReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.ComputeNodeEndpointConfiguration EndpointConfiguration { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.ComputeNodeError> Errors { get { throw null; } }
        public string Id { get { throw null; } }
        public string IpAddress { get { throw null; } }
        public bool? IsDedicated { get { throw null; } }
        public System.DateTimeOffset? LastBootTime { get { throw null; } }
        public Azure.Temp.Batch.Models.NodeAgentInformation NodeAgentInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.TaskInformation> RecentTasks { get { throw null; } }
        public int? RunningTasksCount { get { throw null; } }
        public int? RunningTaskSlotsCount { get { throw null; } }
        public Azure.Temp.Batch.Models.SchedulingState? SchedulingState { get { throw null; } }
        public Azure.Temp.Batch.Models.StartTask StartTask { get { throw null; } }
        public Azure.Temp.Batch.Models.StartTaskInformation StartTaskInfo { get { throw null; } }
        public Azure.Temp.Batch.Models.ComputeNodeState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
        public int? TotalTasksRun { get { throw null; } }
        public int? TotalTasksSucceeded { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.Temp.Batch.Models.VirtualMachineInfo VirtualMachineInfo { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class ComputeNodeAddUserOptions
    {
        public ComputeNodeAddUserOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum ComputeNodeDeallocationOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public partial class ComputeNodeDeleteUserOptions
    {
        public ComputeNodeDeleteUserOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeDisableSchedulingOptions
    {
        public ComputeNodeDisableSchedulingOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeEnableSchedulingOptions
    {
        public ComputeNodeEnableSchedulingOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeEndpointConfiguration
    {
        internal ComputeNodeEndpointConfiguration() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.InboundEndpoint> InboundEndpoints { get { throw null; } }
    }
    public partial class ComputeNodeError
    {
        internal ComputeNodeError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.NameValuePair> ErrorDetails { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class ComputeNodeExtensionGetOptions
    {
        public ComputeNodeExtensionGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeExtensionListOptions
    {
        public ComputeNodeExtensionListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum ComputeNodeFillType
    {
        Spread = 0,
        Pack = 1,
    }
    public partial class ComputeNodeGetOptions
    {
        public ComputeNodeGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeGetRemoteDesktopOptions
    {
        public ComputeNodeGetRemoteDesktopOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeGetRemoteLoginSettingsOptions
    {
        public ComputeNodeGetRemoteLoginSettingsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeGetRemoteLoginSettingsResult
    {
        internal ComputeNodeGetRemoteLoginSettingsResult() { }
        public string RemoteLoginIPAddress { get { throw null; } }
        public int RemoteLoginPort { get { throw null; } }
    }
    public partial class ComputeNodeIdentityReference
    {
        public ComputeNodeIdentityReference() { }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class ComputeNodeInformation
    {
        internal ComputeNodeInformation() { }
        public string AffinityId { get { throw null; } }
        public string NodeId { get { throw null; } }
        public string NodeUrl { get { throw null; } }
        public string PoolId { get { throw null; } }
        public string TaskRootDirectory { get { throw null; } }
        public string TaskRootDirectoryUrl { get { throw null; } }
    }
    public partial class ComputeNodeListOptions
    {
        public ComputeNodeListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum ComputeNodeRebootOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public partial class ComputeNodeRebootOptions
    {
        public ComputeNodeRebootOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum ComputeNodeReimageOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
        RetainedData = 3,
    }
    public partial class ComputeNodeReimageOptions
    {
        public ComputeNodeReimageOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum ComputeNodeState
    {
        Idle = 0,
        Rebooting = 1,
        Reimaging = 2,
        Running = 3,
        Unusable = 4,
        Creating = 5,
        Starting = 6,
        WaitingForStartTask = 7,
        StartTaskFailed = 8,
        Unknown = 9,
        LeavingPool = 10,
        Offline = 11,
        Preempted = 12,
    }
    public partial class ComputeNodeUpdateUserOptions
    {
        public ComputeNodeUpdateUserOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeUploadBatchServiceLogsOptions
    {
        public ComputeNodeUploadBatchServiceLogsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class ComputeNodeUser
    {
        public ComputeNodeUser(string name) { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } set { } }
        public bool? IsAdmin { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string Password { get { throw null; } set { } }
        public string SshPublicKey { get { throw null; } set { } }
    }
    public partial class ContainerConfiguration
    {
        public ContainerConfiguration(Azure.Temp.Batch.Models.ContainerType type) { }
        public System.Collections.Generic.IList<string> ContainerImageNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ContainerRegistry> ContainerRegistries { get { throw null; } }
        public Azure.Temp.Batch.Models.ContainerType Type { get { throw null; } set { } }
    }
    public partial class ContainerRegistry
    {
        public ContainerRegistry() { }
        public Azure.Temp.Batch.Models.ComputeNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string RegistryServer { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ContainerType : System.IEquatable<Azure.Temp.Batch.Models.ContainerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ContainerType(string value) { throw null; }
        public static Azure.Temp.Batch.Models.ContainerType CriCompatible { get { throw null; } }
        public static Azure.Temp.Batch.Models.ContainerType DockerCompatible { get { throw null; } }
        public bool Equals(Azure.Temp.Batch.Models.ContainerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Temp.Batch.Models.ContainerType left, Azure.Temp.Batch.Models.ContainerType right) { throw null; }
        public static implicit operator Azure.Temp.Batch.Models.ContainerType (string value) { throw null; }
        public static bool operator !=(Azure.Temp.Batch.Models.ContainerType left, Azure.Temp.Batch.Models.ContainerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ContainerWorkingDirectory
    {
        TaskWorkingDirectory = 0,
        ContainerImageDefault = 1,
    }
    public partial class DataDisk
    {
        public DataDisk(int lun, int diskSizeGB) { }
        public Azure.Temp.Batch.Models.CachingType? Caching { get { throw null; } set { } }
        public int DiskSizeGB { get { throw null; } set { } }
        public int Lun { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.StorageAccountType? StorageAccountType { get { throw null; } set { } }
    }
    public partial class DeleteCertificateError
    {
        internal DeleteCertificateError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.NameValuePair> Values { get { throw null; } }
    }
    public enum DependencyAction
    {
        Satisfy = 0,
        Block = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiffDiskPlacement : System.IEquatable<Azure.Temp.Batch.Models.DiffDiskPlacement>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiffDiskPlacement(string value) { throw null; }
        public static Azure.Temp.Batch.Models.DiffDiskPlacement CacheDisk { get { throw null; } }
        public bool Equals(Azure.Temp.Batch.Models.DiffDiskPlacement other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.Temp.Batch.Models.DiffDiskPlacement left, Azure.Temp.Batch.Models.DiffDiskPlacement right) { throw null; }
        public static implicit operator Azure.Temp.Batch.Models.DiffDiskPlacement (string value) { throw null; }
        public static bool operator !=(Azure.Temp.Batch.Models.DiffDiskPlacement left, Azure.Temp.Batch.Models.DiffDiskPlacement right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiffDiskSettings
    {
        public DiffDiskSettings() { }
        public Azure.Temp.Batch.Models.DiffDiskPlacement? Placement { get { throw null; } set { } }
    }
    public enum DisableComputeNodeSchedulingOption
    {
        Requeue = 0,
        Terminate = 1,
        TaskCompletion = 2,
    }
    public enum DisableJobOption
    {
        Requeue = 0,
        Terminate = 1,
        Wait = 2,
    }
    public partial class DiskEncryptionConfiguration
    {
        public DiskEncryptionConfiguration() { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.DiskEncryptionTarget> Targets { get { throw null; } }
    }
    public enum DiskEncryptionTarget
    {
        OsDisk = 0,
        TemporaryDisk = 1,
    }
    public enum DynamicVNetAssignmentScope
    {
        None = 0,
        Job = 1,
    }
    public enum ElevationLevel
    {
        NonAdmin = 0,
        Admin = 1,
    }
    public partial class EnvironmentSetting
    {
        public EnvironmentSetting(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public enum ErrorCategory
    {
        UserError = 0,
        ServerError = 1,
    }
    public partial class ErrorMessage
    {
        internal ErrorMessage() { }
        public string Lang { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class ExitCodeMapping
    {
        public ExitCodeMapping(int code, Azure.Temp.Batch.Models.ExitOptions exitOptions) { }
        public int Code { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ExitOptions ExitOptions { get { throw null; } set { } }
    }
    public partial class ExitCodeRangeMapping
    {
        public ExitCodeRangeMapping(int start, int end, Azure.Temp.Batch.Models.ExitOptions exitOptions) { }
        public int End { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ExitOptions ExitOptions { get { throw null; } set { } }
        public int Start { get { throw null; } set { } }
    }
    public partial class ExitConditions
    {
        public ExitConditions() { }
        public Azure.Temp.Batch.Models.ExitOptions Default { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ExitCodeRangeMapping> ExitCodeRanges { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ExitCodeMapping> ExitCodes { get { throw null; } }
        public Azure.Temp.Batch.Models.ExitOptions FileUploadError { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ExitOptions PreProcessingError { get { throw null; } set { } }
    }
    public partial class ExitOptions
    {
        public ExitOptions() { }
        public Azure.Temp.Batch.Models.DependencyAction? DependencyAction { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobAction? JobAction { get { throw null; } set { } }
    }
    public partial class FileDeleteFromComputeNodeOptions
    {
        public FileDeleteFromComputeNodeOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileDeleteFromTaskOptions
    {
        public FileDeleteFromTaskOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileGetFromComputeNodeOptions
    {
        public FileGetFromComputeNodeOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public string OcpRange { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileGetFromTaskOptions
    {
        public FileGetFromTaskOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public string OcpRange { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileGetPropertiesFromComputeNodeOptions
    {
        public FileGetPropertiesFromComputeNodeOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileGetPropertiesFromTaskOptions
    {
        public FileGetPropertiesFromTaskOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileListFromComputeNodeOptions
    {
        public FileListFromComputeNodeOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileListFromTaskOptions
    {
        public FileListFromTaskOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class FileProperties
    {
        internal FileProperties() { }
        public long ContentLength { get { throw null; } }
        public string ContentType { get { throw null; } }
        public System.DateTimeOffset? CreationTime { get { throw null; } }
        public string FileMode { get { throw null; } }
        public System.DateTimeOffset LastModified { get { throw null; } }
    }
    public partial class HttpHeader
    {
        public HttpHeader(string name) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class ImageInformation
    {
        internal ImageInformation() { }
        public System.DateTimeOffset? BatchSupportEndOfLife { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Capabilities { get { throw null; } }
        public Azure.Temp.Batch.Models.ImageReference ImageReference { get { throw null; } }
        public string NodeAgentSKUId { get { throw null; } }
        public Azure.Temp.Batch.Models.OSType OsType { get { throw null; } }
        public Azure.Temp.Batch.Models.VerificationType VerificationType { get { throw null; } }
    }
    public partial class ImageReference
    {
        public ImageReference() { }
        public string ExactVersion { get { throw null; } }
        public string Offer { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        public string Sku { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        public string VirtualMachineImageId { get { throw null; } set { } }
    }
    public partial class InboundEndpoint
    {
        internal InboundEndpoint() { }
        public int BackendPort { get { throw null; } }
        public int FrontendPort { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Temp.Batch.Models.InboundEndpointProtocol Protocol { get { throw null; } }
        public string PublicFqdn { get { throw null; } }
        public string PublicIPAddress { get { throw null; } }
    }
    public enum InboundEndpointProtocol
    {
        Tcp = 0,
        Udp = 1,
    }
    public partial class InboundNATPool
    {
        public InboundNATPool(string name, Azure.Temp.Batch.Models.InboundEndpointProtocol protocol, int backendPort, int frontendPortRangeStart, int frontendPortRangeEnd) { }
        public int BackendPort { get { throw null; } set { } }
        public int FrontendPortRangeEnd { get { throw null; } set { } }
        public int FrontendPortRangeStart { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.NetworkSecurityGroupRule> NetworkSecurityGroupRules { get { throw null; } }
        public Azure.Temp.Batch.Models.InboundEndpointProtocol Protocol { get { throw null; } set { } }
    }
    public partial class InstanceViewStatus
    {
        internal InstanceViewStatus() { }
        public string Code { get { throw null; } }
        public string DisplayStatus { get { throw null; } }
        public Azure.Temp.Batch.Models.StatusLevelTypes? Level { get { throw null; } }
        public string Message { get { throw null; } }
        public string Time { get { throw null; } }
    }
    public enum IPAddressProvisioningType
    {
        BatchManaged = 0,
        UserManaged = 1,
        NoPublicIPAddresses = 2,
    }
    public enum JobAction
    {
        None = 0,
        Disable = 1,
        Terminate = 2,
    }
    public partial class JobAddOptions
    {
        public JobAddOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobAddParameter
    {
        public JobAddParameter(string id, Azure.Temp.Batch.Models.PoolInformation poolInfo) { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> CommonEnvironmentSettings { get { throw null; } }
        public Azure.Temp.Batch.Models.JobConstraints Constraints { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Temp.Batch.Models.JobManagerTask JobManagerTask { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobPreparationTask JobPreparationTask { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobReleaseTask JobReleaseTask { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.JobNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.OnAllTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.OnTaskFailure? OnTaskFailure { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolInformation PoolInfo { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
        public bool? UsesTaskDependencies { get { throw null; } set { } }
    }
    public partial class JobConstraints
    {
        public JobConstraints() { }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.TimeSpan? MaxWallClockTime { get { throw null; } set { } }
    }
    public partial class JobDeleteOptions
    {
        public JobDeleteOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobDisableOptions
    {
        public JobDisableOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobDisableParameter
    {
        public JobDisableParameter(Azure.Temp.Batch.Models.DisableJobOption disableTasks) { }
        public Azure.Temp.Batch.Models.DisableJobOption DisableTasks { get { throw null; } }
    }
    public partial class JobEnableOptions
    {
        public JobEnableOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobExecutionInformation
    {
        internal JobExecutionInformation() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public string PoolId { get { throw null; } }
        public Azure.Temp.Batch.Models.JobSchedulingError SchedulingError { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string TerminateReason { get { throw null; } }
    }
    public partial class JobGetOptions
    {
        public JobGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobGetTaskCountsOptions
    {
        public JobGetTaskCountsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobListFromJobScheduleOptions
    {
        public JobListFromJobScheduleOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobListOptions
    {
        public JobListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobListPreparationAndReleaseTaskStatusOptions
    {
        public JobListPreparationAndReleaseTaskStatusOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobManagerTask
    {
        public JobManagerTask(string id, string commandLine) { }
        public bool? AllowLowPriorityNode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.AuthenticationTokenSettings AuthenticationTokenSettings { get { throw null; } set { } }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? KillJobOnCompletion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.OutputFile> OutputFiles { get { throw null; } }
        public int? RequiredSlots { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public bool? RunExclusive { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.UserIdentity UserIdentity { get { throw null; } set { } }
    }
    public partial class JobNetworkConfiguration
    {
        public JobNetworkConfiguration(string subnetId) { }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class JobPatchOptions
    {
        public JobPatchOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobPatchParameter
    {
        public JobPatchParameter() { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobConstraints Constraints { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.OnAllTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolInformation PoolInfo { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
    }
    public partial class JobPreparationAndReleaseTaskExecutionInformation
    {
        internal JobPreparationAndReleaseTaskExecutionInformation() { }
        public Azure.Temp.Batch.Models.JobPreparationTaskExecutionInformation JobPreparationTaskExecutionInfo { get { throw null; } }
        public Azure.Temp.Batch.Models.JobReleaseTaskExecutionInformation JobReleaseTaskExecutionInfo { get { throw null; } }
        public string NodeId { get { throw null; } }
        public string NodeUrl { get { throw null; } }
        public string PoolId { get { throw null; } }
    }
    public partial class JobPreparationTask
    {
        public JobPreparationTask(string commandLine) { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public bool? RerunOnNodeRebootAfterSuccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Temp.Batch.Models.UserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
    }
    public partial class JobPreparationTaskExecutionInformation
    {
        internal JobPreparationTaskExecutionInformation() { }
        public Azure.Temp.Batch.Models.TaskContainerExecutionInformation ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskFailureInformation FailureInfo { get { throw null; } }
        public System.DateTimeOffset? LastRetryTime { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskExecutionResult? Result { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.Temp.Batch.Models.JobPreparationTaskState State { get { throw null; } }
        public string TaskRootDirectory { get { throw null; } }
        public string TaskRootDirectoryUrl { get { throw null; } }
    }
    public enum JobPreparationTaskState
    {
        Running = 0,
        Completed = 1,
    }
    public partial class JobReleaseTask
    {
        public JobReleaseTask(string commandLine) { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.TimeSpan? MaxWallClockTime { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public System.TimeSpan? RetentionTime { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.UserIdentity UserIdentity { get { throw null; } set { } }
    }
    public partial class JobReleaseTaskExecutionInformation
    {
        internal JobReleaseTaskExecutionInformation() { }
        public Azure.Temp.Batch.Models.TaskContainerExecutionInformation ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskFailureInformation FailureInfo { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskExecutionResult? Result { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.Temp.Batch.Models.JobReleaseTaskState State { get { throw null; } }
        public string TaskRootDirectory { get { throw null; } }
        public string TaskRootDirectoryUrl { get { throw null; } }
    }
    public enum JobReleaseTaskState
    {
        Running = 0,
        Completed = 1,
    }
    public partial class JobScheduleAddOptions
    {
        public JobScheduleAddOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleAddParameter
    {
        public JobScheduleAddParameter(string id, Azure.Temp.Batch.Models.Schedule schedule, Azure.Temp.Batch.Models.JobSpecification jobSpecification) { }
        public string DisplayName { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Temp.Batch.Models.JobSpecification JobSpecification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.Schedule Schedule { get { throw null; } }
    }
    public partial class JobScheduleDeleteOptions
    {
        public JobScheduleDeleteOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleDisableOptions
    {
        public JobScheduleDisableOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleEnableOptions
    {
        public JobScheduleEnableOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleExecutionInformation
    {
        internal JobScheduleExecutionInformation() { }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public System.DateTimeOffset? NextRunTime { get { throw null; } }
        public Azure.Temp.Batch.Models.RecentJob RecentJob { get { throw null; } }
    }
    public partial class JobScheduleExistsOptions
    {
        public JobScheduleExistsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleGetOptions
    {
        public JobScheduleGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleListOptions
    {
        public JobScheduleListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobSchedulePatchOptions
    {
        public JobSchedulePatchOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobSchedulePatchParameter
    {
        public JobSchedulePatchParameter() { }
        public Azure.Temp.Batch.Models.JobSpecification JobSpecification { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.Schedule Schedule { get { throw null; } set { } }
    }
    public enum JobScheduleState
    {
        Active = 0,
        Completed = 1,
        Disabled = 2,
        Terminating = 3,
        Deleting = 4,
    }
    public partial class JobScheduleStatistics
    {
        internal JobScheduleStatistics() { }
        public System.TimeSpan KernelCPUTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public long NumFailedTasks { get { throw null; } }
        public long NumSucceededTasks { get { throw null; } }
        public long NumTaskRetries { get { throw null; } }
        public double ReadIOGiB { get { throw null; } }
        public long ReadIOps { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public System.TimeSpan UserCPUTime { get { throw null; } }
        public System.TimeSpan WaitTime { get { throw null; } }
        public System.TimeSpan WallClockTime { get { throw null; } }
        public double WriteIOGiB { get { throw null; } }
        public long WriteIOps { get { throw null; } }
    }
    public partial class JobScheduleTerminateOptions
    {
        public JobScheduleTerminateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleUpdateOptions
    {
        public JobScheduleUpdateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobScheduleUpdateParameter
    {
        public JobScheduleUpdateParameter(Azure.Temp.Batch.Models.Schedule schedule, Azure.Temp.Batch.Models.JobSpecification jobSpecification) { }
        public Azure.Temp.Batch.Models.JobSpecification JobSpecification { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.Schedule Schedule { get { throw null; } }
    }
    public partial class JobSchedulingError
    {
        internal JobSchedulingError() { }
        public Azure.Temp.Batch.Models.ErrorCategory Category { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.NameValuePair> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class JobSpecification
    {
        public JobSpecification(Azure.Temp.Batch.Models.PoolInformation poolInfo) { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> CommonEnvironmentSettings { get { throw null; } }
        public Azure.Temp.Batch.Models.JobConstraints Constraints { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobManagerTask JobManagerTask { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobPreparationTask JobPreparationTask { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobReleaseTask JobReleaseTask { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.JobNetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.OnAllTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.OnTaskFailure? OnTaskFailure { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolInformation PoolInfo { get { throw null; } set { } }
        public int? Priority { get { throw null; } set { } }
        public bool? UsesTaskDependencies { get { throw null; } set { } }
    }
    public enum JobState
    {
        Active = 0,
        Disabling = 1,
        Disabled = 2,
        Enabling = 3,
        Terminating = 4,
        Completed = 5,
        Deleting = 6,
    }
    public partial class JobStatistics
    {
        internal JobStatistics() { }
        public System.TimeSpan KernelCPUTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public long NumFailedTasks { get { throw null; } }
        public long NumSucceededTasks { get { throw null; } }
        public long NumTaskRetries { get { throw null; } }
        public double ReadIOGiB { get { throw null; } }
        public long ReadIOps { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public System.TimeSpan UserCPUTime { get { throw null; } }
        public System.TimeSpan WaitTime { get { throw null; } }
        public System.TimeSpan WallClockTime { get { throw null; } }
        public double WriteIOGiB { get { throw null; } }
        public long WriteIOps { get { throw null; } }
    }
    public partial class JobTerminateOptions
    {
        public JobTerminateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobTerminateParameter
    {
        public JobTerminateParameter() { }
        public string TerminateReason { get { throw null; } set { } }
    }
    public partial class JobUpdateOptions
    {
        public JobUpdateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class JobUpdateParameter
    {
        public JobUpdateParameter(Azure.Temp.Batch.Models.PoolInformation poolInfo) { }
        public bool? AllowTaskPreemption { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.JobConstraints Constraints { get { throw null; } set { } }
        public int? MaxParallelTasks { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.OnAllTasksComplete? OnAllTasksComplete { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolInformation PoolInfo { get { throw null; } }
        public int? Priority { get { throw null; } set { } }
    }
    public partial class LinuxUserConfiguration
    {
        public LinuxUserConfiguration() { }
        public int? Gid { get { throw null; } set { } }
        public string SshPrivateKey { get { throw null; } set { } }
        public int? Uid { get { throw null; } set { } }
    }
    public enum LoginMode
    {
        Batch = 0,
        Interactive = 1,
    }
    public partial class MetadataItem
    {
        public MetadataItem(string name, string value) { }
        public string Name { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    public partial class MountConfiguration
    {
        public MountConfiguration() { }
        public Azure.Temp.Batch.Models.AzureBlobFileSystemConfiguration AzureBlobFileSystemConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.AzureFileShareConfiguration AzureFileShareConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.CifsMountConfiguration CifsMountConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.NFSMountConfiguration NfsMountConfiguration { get { throw null; } set { } }
    }
    public partial class MultiInstanceSettings
    {
        public MultiInstanceSettings(string coordinationCommandLine) { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ResourceFile> CommonResourceFiles { get { throw null; } }
        public string CoordinationCommandLine { get { throw null; } set { } }
        public int? NumberOfInstances { get { throw null; } set { } }
    }
    public partial class NameValuePair
    {
        internal NameValuePair() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
    }
    public partial class NetworkConfiguration
    {
        public NetworkConfiguration() { }
        public Azure.Temp.Batch.Models.DynamicVNetAssignmentScope? DynamicVNetAssignmentScope { get { throw null; } set { } }
        public bool? EnableAcceleratedNetworking { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PoolEndpointConfiguration EndpointConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.PublicIPAddressConfiguration PublicIPAddressConfiguration { get { throw null; } set { } }
        public string SubnetId { get { throw null; } set { } }
    }
    public partial class NetworkSecurityGroupRule
    {
        public NetworkSecurityGroupRule(int priority, Azure.Temp.Batch.Models.NetworkSecurityGroupRuleAccess access, string sourceAddressPrefix) { }
        public Azure.Temp.Batch.Models.NetworkSecurityGroupRuleAccess Access { get { throw null; } set { } }
        public int Priority { get { throw null; } set { } }
        public string SourceAddressPrefix { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SourcePortRanges { get { throw null; } }
    }
    public enum NetworkSecurityGroupRuleAccess
    {
        Allow = 0,
        Deny = 1,
    }
    public partial class NFSMountConfiguration
    {
        public NFSMountConfiguration(string source, string relativeMountPath) { }
        public string MountOptions { get { throw null; } set { } }
        public string RelativeMountPath { get { throw null; } set { } }
        public string Source { get { throw null; } set { } }
    }
    public partial class NodeAgentInformation
    {
        internal NodeAgentInformation() { }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public string Version { get { throw null; } }
    }
    public enum NodeCommunicationMode
    {
        Default = 0,
        Classic = 1,
        Simplified = 2,
    }
    public partial class NodeCounts
    {
        internal NodeCounts() { }
        public int Creating { get { throw null; } }
        public int Idle { get { throw null; } }
        public int LeavingPool { get { throw null; } }
        public int Offline { get { throw null; } }
        public int Preempted { get { throw null; } }
        public int Rebooting { get { throw null; } }
        public int Reimaging { get { throw null; } }
        public int Running { get { throw null; } }
        public int Starting { get { throw null; } }
        public int StartTaskFailed { get { throw null; } }
        public int Total { get { throw null; } }
        public int Unknown { get { throw null; } }
        public int Unusable { get { throw null; } }
        public int WaitingForStartTask { get { throw null; } }
    }
    public partial class NodeDisableSchedulingParameter
    {
        public NodeDisableSchedulingParameter() { }
        public Azure.Temp.Batch.Models.DisableComputeNodeSchedulingOption? NodeDisableSchedulingOption { get { throw null; } set { } }
    }
    public partial class NodeFile
    {
        internal NodeFile() { }
        public bool? IsDirectory { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.Temp.Batch.Models.FileProperties Properties { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class NodePlacementConfiguration
    {
        public NodePlacementConfiguration() { }
        public Azure.Temp.Batch.Models.NodePlacementPolicyType? Policy { get { throw null; } set { } }
    }
    public enum NodePlacementPolicyType
    {
        Regional = 0,
        Zonal = 1,
    }
    public partial class NodeRebootParameter
    {
        public NodeRebootParameter() { }
        public Azure.Temp.Batch.Models.ComputeNodeRebootOption? NodeRebootOption { get { throw null; } set { } }
    }
    public partial class NodeReimageParameter
    {
        public NodeReimageParameter() { }
        public Azure.Temp.Batch.Models.ComputeNodeReimageOption? NodeReimageOption { get { throw null; } set { } }
    }
    public partial class NodeRemoveParameter
    {
        public NodeRemoveParameter(System.Collections.Generic.IEnumerable<string> nodeList) { }
        public Azure.Temp.Batch.Models.ComputeNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> NodeList { get { throw null; } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
    }
    public partial class NodeUpdateUserParameter
    {
        public NodeUpdateUserParameter() { }
        public System.DateTimeOffset? ExpiryTime { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string SshPublicKey { get { throw null; } set { } }
    }
    public partial class NodeVMExtension
    {
        internal NodeVMExtension() { }
        public Azure.Temp.Batch.Models.VMExtensionInstanceView InstanceView { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Temp.Batch.Models.VMExtension VmExtension { get { throw null; } }
    }
    public enum OnAllTasksComplete
    {
        NoAction = 0,
        TerminateJob = 1,
    }
    public enum OnTaskFailure
    {
        NoAction = 0,
        PerformExitOptionsJobAction = 1,
    }
    public partial class OSDisk
    {
        public OSDisk() { }
        public Azure.Temp.Batch.Models.DiffDiskSettings EphemeralOSDiskSettings { get { throw null; } set { } }
    }
    public enum OSType
    {
        Linux = 0,
        Windows = 1,
    }
    public partial class OutputFile
    {
        public OutputFile(string filePattern, Azure.Temp.Batch.Models.OutputFileDestination destination, Azure.Temp.Batch.Models.OutputFileUploadOptions uploadOptions) { }
        public Azure.Temp.Batch.Models.OutputFileDestination Destination { get { throw null; } set { } }
        public string FilePattern { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.OutputFileUploadOptions UploadOptions { get { throw null; } set { } }
    }
    public partial class OutputFileBlobContainerDestination
    {
        public OutputFileBlobContainerDestination(string containerUrl) { }
        public string ContainerUrl { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ComputeNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.HttpHeader> UploadHeaders { get { throw null; } }
    }
    public partial class OutputFileDestination
    {
        public OutputFileDestination() { }
        public Azure.Temp.Batch.Models.OutputFileBlobContainerDestination Container { get { throw null; } set { } }
    }
    public enum OutputFileUploadCondition
    {
        TaskSuccess = 0,
        TaskFailure = 1,
        TaskCompletion = 2,
    }
    public partial class OutputFileUploadOptions
    {
        public OutputFileUploadOptions(Azure.Temp.Batch.Models.OutputFileUploadCondition uploadCondition) { }
        public Azure.Temp.Batch.Models.OutputFileUploadCondition UploadCondition { get { throw null; } set { } }
    }
    public partial class PoolAddOptions
    {
        public PoolAddOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolAddParameter
    {
        public PoolAddParameter(string id, string vmSize) { }
        public System.Collections.Generic.IList<string> ApplicationLicenses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } set { } }
        public string AutoScaleFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.CertificateReference> CertificateReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.CloudServiceConfiguration CloudServiceConfiguration { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? EnableAutoScale { get { throw null; } set { } }
        public bool? EnableInterNodeCommunication { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Temp.Batch.Models.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.StartTask StartTask { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Temp.Batch.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        public string VmSize { get { throw null; } }
    }
    public partial class PoolDeleteOptions
    {
        public PoolDeleteOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolDisableAutoScaleOptions
    {
        public PoolDisableAutoScaleOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolEnableAutoScaleOptions
    {
        public PoolEnableAutoScaleOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolEnableAutoScaleParameter
    {
        public PoolEnableAutoScaleParameter() { }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } set { } }
        public string AutoScaleFormula { get { throw null; } set { } }
    }
    public partial class PoolEndpointConfiguration
    {
        public PoolEndpointConfiguration(System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.InboundNATPool> inboundNATPools) { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.InboundNATPool> InboundNATPools { get { throw null; } }
    }
    public partial class PoolEvaluateAutoScaleOptions
    {
        public PoolEvaluateAutoScaleOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolEvaluateAutoScaleParameter
    {
        public PoolEvaluateAutoScaleParameter(string autoScaleFormula) { }
        public string AutoScaleFormula { get { throw null; } }
    }
    public partial class PoolExistsOptions
    {
        public PoolExistsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolGetOptions
    {
        public PoolGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public enum PoolIdentityType
    {
        UserAssigned = 0,
        None = 1,
    }
    public partial class PoolInformation
    {
        public PoolInformation() { }
        public Azure.Temp.Batch.Models.AutoPoolSpecification AutoPoolSpecification { get { throw null; } set { } }
        public string PoolId { get { throw null; } set { } }
    }
    public enum PoolLifetimeOption
    {
        JobSchedule = 0,
        Job = 1,
    }
    public partial class PoolListOptions
    {
        public PoolListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolListUsageMetricsOptions
    {
        public PoolListUsageMetricsOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? StartTime { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolNodeCounts
    {
        internal PoolNodeCounts() { }
        public Azure.Temp.Batch.Models.NodeCounts Dedicated { get { throw null; } }
        public Azure.Temp.Batch.Models.NodeCounts LowPriority { get { throw null; } }
        public string PoolId { get { throw null; } }
    }
    public partial class PoolPatchOptions
    {
        public PoolPatchOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolPatchParameter
    {
        public PoolPatchParameter() { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.CertificateReference> CertificateReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.StartTask StartTask { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
    }
    public partial class PoolRemoveNodesOptions
    {
        public PoolRemoveNodesOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolResizeOptions
    {
        public PoolResizeOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolResizeParameter
    {
        public PoolResizeParameter() { }
        public Azure.Temp.Batch.Models.ComputeNodeDeallocationOption? NodeDeallocationOption { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
    }
    public partial class PoolSpecification
    {
        public PoolSpecification(string vmSize) { }
        public System.Collections.Generic.IList<string> ApplicationLicenses { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.TimeSpan? AutoScaleEvaluationInterval { get { throw null; } set { } }
        public string AutoScaleFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.CertificateReference> CertificateReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.CloudServiceConfiguration CloudServiceConfiguration { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public bool? EnableAutoScale { get { throw null; } set { } }
        public bool? EnableInterNodeCommunication { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MountConfiguration> MountConfiguration { get { throw null; } }
        public Azure.Temp.Batch.Models.NetworkConfiguration NetworkConfiguration { get { throw null; } set { } }
        public System.TimeSpan? ResizeTimeout { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.StartTask StartTask { get { throw null; } set { } }
        public int? TargetDedicatedNodes { get { throw null; } set { } }
        public int? TargetLowPriorityNodes { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskSchedulingPolicy TaskSchedulingPolicy { get { throw null; } set { } }
        public int? TaskSlotsPerNode { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.UserAccount> UserAccounts { get { throw null; } }
        public Azure.Temp.Batch.Models.VirtualMachineConfiguration VirtualMachineConfiguration { get { throw null; } set { } }
        public string VmSize { get { throw null; } set { } }
    }
    public enum PoolState
    {
        Active = 0,
        Deleting = 1,
    }
    public partial class PoolStatistics
    {
        internal PoolStatistics() { }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public Azure.Temp.Batch.Models.ResourceStatistics ResourceStats { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public Azure.Temp.Batch.Models.UsageStatistics UsageStats { get { throw null; } }
    }
    public partial class PoolStopResizeOptions
    {
        public PoolStopResizeOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolUpdatePropertiesOptions
    {
        public PoolUpdatePropertiesOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class PoolUpdatePropertiesParameter
    {
        public PoolUpdatePropertiesParameter(System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.CertificateReference> certificateReferences, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.ApplicationPackageReference> applicationPackageReferences, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.MetadataItem> metadata) { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.CertificateReference> CertificateReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.MetadataItem> Metadata { get { throw null; } }
        public Azure.Temp.Batch.Models.StartTask StartTask { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.NodeCommunicationMode? TargetNodeCommunicationMode { get { throw null; } set { } }
    }
    public partial class PoolUsageMetrics
    {
        internal PoolUsageMetrics() { }
        public System.DateTimeOffset EndTime { get { throw null; } }
        public string PoolId { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public double TotalCoreHours { get { throw null; } }
        public string VmSize { get { throw null; } }
    }
    public partial class PublicIPAddressConfiguration
    {
        public PublicIPAddressConfiguration() { }
        public System.Collections.Generic.IList<string> IpAddressIds { get { throw null; } }
        public Azure.Temp.Batch.Models.IPAddressProvisioningType? Provision { get { throw null; } set { } }
    }
    public partial class RecentJob
    {
        internal RecentJob() { }
        public string Id { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class ResizeError
    {
        internal ResizeError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.NameValuePair> Values { get { throw null; } }
    }
    public partial class ResourceFile
    {
        public ResourceFile() { }
        public string AutoStorageContainerName { get { throw null; } set { } }
        public string BlobPrefix { get { throw null; } set { } }
        public string FileMode { get { throw null; } set { } }
        public string FilePath { get { throw null; } set { } }
        public string HttpUrl { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ComputeNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public string StorageContainerUrl { get { throw null; } set { } }
    }
    public partial class ResourceStatistics
    {
        internal ResourceStatistics() { }
        public double AvgCPUPercentage { get { throw null; } }
        public double AvgDiskGiB { get { throw null; } }
        public double AvgMemoryGiB { get { throw null; } }
        public double DiskReadGiB { get { throw null; } }
        public long DiskReadIOps { get { throw null; } }
        public double DiskWriteGiB { get { throw null; } }
        public long DiskWriteIOps { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public double NetworkReadGiB { get { throw null; } }
        public double NetworkWriteGiB { get { throw null; } }
        public double PeakDiskGiB { get { throw null; } }
        public double PeakMemoryGiB { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class Schedule
    {
        public Schedule() { }
        public System.DateTimeOffset? DoNotRunAfter { get { throw null; } set { } }
        public System.DateTimeOffset? DoNotRunUntil { get { throw null; } set { } }
        public System.TimeSpan? RecurrenceInterval { get { throw null; } set { } }
        public System.TimeSpan? StartWindow { get { throw null; } set { } }
    }
    public enum SchedulingState
    {
        Enabled = 0,
        Disabled = 1,
    }
    public partial class StartTask
    {
        public StartTask(string commandLine) { }
        public string CommandLine { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Temp.Batch.Models.UserIdentity UserIdentity { get { throw null; } set { } }
        public bool? WaitForSuccess { get { throw null; } set { } }
    }
    public partial class StartTaskInformation
    {
        internal StartTaskInformation() { }
        public Azure.Temp.Batch.Models.TaskContainerExecutionInformation ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskFailureInformation FailureInfo { get { throw null; } }
        public System.DateTimeOffset? LastRetryTime { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskExecutionResult? Result { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public Azure.Temp.Batch.Models.StartTaskState State { get { throw null; } }
    }
    public enum StartTaskState
    {
        Running = 0,
        Completed = 1,
    }
    public enum StatusLevelTypes
    {
        Error = 0,
        Info = 1,
        Warning = 2,
    }
    public enum StorageAccountType
    {
        StandardLRS = 0,
        PremiumLRS = 1,
    }
    public partial class SubtaskInformation
    {
        internal SubtaskInformation() { }
        public Azure.Temp.Batch.Models.TaskContainerExecutionInformation ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskFailureInformation FailureInfo { get { throw null; } }
        public int? Id { get { throw null; } }
        public Azure.Temp.Batch.Models.ComputeNodeInformation NodeInfo { get { throw null; } }
        public Azure.Temp.Batch.Models.SubtaskState? PreviousState { get { throw null; } }
        public System.DateTimeOffset? PreviousStateTransitionTime { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskExecutionResult? Result { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
        public Azure.Temp.Batch.Models.SubtaskState? State { get { throw null; } }
        public System.DateTimeOffset? StateTransitionTime { get { throw null; } }
    }
    public enum SubtaskState
    {
        Preparing = 0,
        Running = 1,
        Completed = 2,
    }
    public partial class TaskAddCollectionOptions
    {
        public TaskAddCollectionOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskAddCollectionParameter
    {
        public TaskAddCollectionParameter(System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.TaskAddParameter> value) { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.TaskAddParameter> Value { get { throw null; } }
    }
    public partial class TaskAddCollectionResult
    {
        internal TaskAddCollectionResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.TaskAddResult> Value { get { throw null; } }
    }
    public partial class TaskAddOptions
    {
        public TaskAddOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskAddParameter
    {
        public TaskAddParameter(string id, string commandLine) { }
        public Azure.Temp.Batch.Models.AffinityInformation AffinityInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ApplicationPackageReference> ApplicationPackageReferences { get { throw null; } }
        public Azure.Temp.Batch.Models.AuthenticationTokenSettings AuthenticationTokenSettings { get { throw null; } set { } }
        public string CommandLine { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskConstraints Constraints { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskContainerSettings ContainerSettings { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.TaskDependencies DependsOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.EnvironmentSetting> EnvironmentSettings { get { throw null; } }
        public Azure.Temp.Batch.Models.ExitConditions ExitConditions { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public Azure.Temp.Batch.Models.MultiInstanceSettings MultiInstanceSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.OutputFile> OutputFiles { get { throw null; } }
        public int? RequiredSlots { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.ResourceFile> ResourceFiles { get { throw null; } }
        public Azure.Temp.Batch.Models.UserIdentity UserIdentity { get { throw null; } set { } }
    }
    public partial class TaskAddResult
    {
        internal TaskAddResult() { }
        public Azure.Temp.Batch.Models.BatchError Error { get { throw null; } }
        public string ETag { get { throw null; } }
        public System.DateTimeOffset? LastModified { get { throw null; } }
        public string Location { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskAddStatus Status { get { throw null; } }
        public string TaskId { get { throw null; } }
    }
    public enum TaskAddStatus
    {
        Success = 0,
        ClientError = 1,
        ServerError = 2,
    }
    public partial class TaskConstraints
    {
        public TaskConstraints() { }
        public int? MaxTaskRetryCount { get { throw null; } set { } }
        public System.TimeSpan? MaxWallClockTime { get { throw null; } set { } }
        public System.TimeSpan? RetentionTime { get { throw null; } set { } }
    }
    public partial class TaskContainerExecutionInformation
    {
        internal TaskContainerExecutionInformation() { }
        public string ContainerId { get { throw null; } }
        public string Error { get { throw null; } }
        public string State { get { throw null; } }
    }
    public partial class TaskContainerSettings
    {
        public TaskContainerSettings(string imageName) { }
        public string ContainerRunOptions { get { throw null; } set { } }
        public string ImageName { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ContainerRegistry Registry { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ContainerWorkingDirectory? WorkingDirectory { get { throw null; } set { } }
    }
    public partial class TaskCounts
    {
        internal TaskCounts() { }
        public int Active { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int Running { get { throw null; } }
        public int Succeeded { get { throw null; } }
    }
    public partial class TaskCountsResult
    {
        internal TaskCountsResult() { }
        public Azure.Temp.Batch.Models.TaskCounts TaskCounts { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskSlotCounts TaskSlotCounts { get { throw null; } }
    }
    public partial class TaskDeleteOptions
    {
        public TaskDeleteOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskDependencies
    {
        public TaskDependencies() { }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.TaskIdRange> TaskIdRanges { get { throw null; } }
        public System.Collections.Generic.IList<string> TaskIds { get { throw null; } }
    }
    public partial class TaskExecutionInformation
    {
        internal TaskExecutionInformation() { }
        public Azure.Temp.Batch.Models.TaskContainerExecutionInformation ContainerInfo { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } }
        public int? ExitCode { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskFailureInformation FailureInfo { get { throw null; } }
        public System.DateTimeOffset? LastRequeueTime { get { throw null; } }
        public System.DateTimeOffset? LastRetryTime { get { throw null; } }
        public int RequeueCount { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskExecutionResult? Result { get { throw null; } }
        public int RetryCount { get { throw null; } }
        public System.DateTimeOffset? StartTime { get { throw null; } }
    }
    public enum TaskExecutionResult
    {
        Success = 0,
        Failure = 1,
    }
    public partial class TaskFailureInformation
    {
        internal TaskFailureInformation() { }
        public Azure.Temp.Batch.Models.ErrorCategory Category { get { throw null; } }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.NameValuePair> Details { get { throw null; } }
        public string Message { get { throw null; } }
    }
    public partial class TaskGetOptions
    {
        public TaskGetOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskIdRange
    {
        public TaskIdRange(int start, int end) { }
        public int End { get { throw null; } set { } }
        public int Start { get { throw null; } set { } }
    }
    public partial class TaskInformation
    {
        internal TaskInformation() { }
        public Azure.Temp.Batch.Models.TaskExecutionInformation ExecutionInfo { get { throw null; } }
        public string JobId { get { throw null; } }
        public int? SubtaskId { get { throw null; } }
        public string TaskId { get { throw null; } }
        public Azure.Temp.Batch.Models.TaskState TaskState { get { throw null; } }
        public string TaskUrl { get { throw null; } }
    }
    public partial class TaskListOptions
    {
        public TaskListOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string Expand { get { throw null; } set { } }
        public string Filter { get { throw null; } set { } }
        public int? MaxResults { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskListSubtasksOptions
    {
        public TaskListSubtasksOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public string Select { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskReactivateOptions
    {
        public TaskReactivateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskSchedulingPolicy
    {
        public TaskSchedulingPolicy(Azure.Temp.Batch.Models.ComputeNodeFillType nodeFillType) { }
        public Azure.Temp.Batch.Models.ComputeNodeFillType NodeFillType { get { throw null; } set { } }
    }
    public partial class TaskSlotCounts
    {
        internal TaskSlotCounts() { }
        public int Active { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int Running { get { throw null; } }
        public int Succeeded { get { throw null; } }
    }
    public enum TaskState
    {
        Active = 0,
        Preparing = 1,
        Running = 2,
        Completed = 3,
    }
    public partial class TaskStatistics
    {
        internal TaskStatistics() { }
        public System.TimeSpan KernelCPUTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public double ReadIOGiB { get { throw null; } }
        public long ReadIOps { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
        public string Url { get { throw null; } }
        public System.TimeSpan UserCPUTime { get { throw null; } }
        public System.TimeSpan WaitTime { get { throw null; } }
        public System.TimeSpan WallClockTime { get { throw null; } }
        public double WriteIOGiB { get { throw null; } }
        public long WriteIOps { get { throw null; } }
    }
    public partial class TaskTerminateOptions
    {
        public TaskTerminateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskUpdateOptions
    {
        public TaskUpdateOptions() { }
        public System.Guid? ClientRequestId { get { throw null; } set { } }
        public string IfMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfModifiedSince { get { throw null; } set { } }
        public string IfNoneMatch { get { throw null; } set { } }
        public System.DateTimeOffset? IfUnmodifiedSince { get { throw null; } set { } }
        public System.DateTimeOffset? OcpDate { get { throw null; } set { } }
        public bool? ReturnClientRequestId { get { throw null; } set { } }
        public int? Timeout { get { throw null; } set { } }
    }
    public partial class TaskUpdateParameter
    {
        public TaskUpdateParameter() { }
        public Azure.Temp.Batch.Models.TaskConstraints Constraints { get { throw null; } set { } }
    }
    public static partial class TempBatchModelFactory
    {
        public static Azure.Temp.Batch.Models.ApplicationSummary ApplicationSummary(string id = null, string displayName = null, System.Collections.Generic.IEnumerable<string> versions = null) { throw null; }
        public static Azure.Temp.Batch.Models.AutoScaleRun AutoScaleRun(System.DateTimeOffset timestamp = default(System.DateTimeOffset), string results = null, Azure.Temp.Batch.Models.AutoScaleRunError error = null) { throw null; }
        public static Azure.Temp.Batch.Models.AutoScaleRunError AutoScaleRunError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.NameValuePair> values = null) { throw null; }
        public static Azure.Temp.Batch.Models.BatchError BatchError(string code = null, Azure.Temp.Batch.Models.ErrorMessage message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.BatchErrorDetail> values = null) { throw null; }
        public static Azure.Temp.Batch.Models.BatchErrorDetail BatchErrorDetail(string key = null, string value = null) { throw null; }
        public static Azure.Temp.Batch.Models.BatchPoolIdentity BatchPoolIdentity(Azure.Temp.Batch.Models.PoolIdentityType type = Azure.Temp.Batch.Models.PoolIdentityType.UserAssigned, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.UserAssignedIdentity> userAssignedIdentities = null) { throw null; }
        public static Azure.Temp.Batch.Models.Certificate Certificate(string thumbprint = null, string thumbprintAlgorithm = null, string url = null, Azure.Temp.Batch.Models.CertificateState? state = default(Azure.Temp.Batch.Models.CertificateState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.CertificateState? previousState = default(Azure.Temp.Batch.Models.CertificateState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), string publicData = null, Azure.Temp.Batch.Models.DeleteCertificateError deleteCertificateError = null) { throw null; }
        public static Azure.Temp.Batch.Models.CloudJob CloudJob(string id = null, string displayName = null, bool? usesTaskDependencies = default(bool?), string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.JobState? state = default(Azure.Temp.Batch.Models.JobState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.JobState? previousState = default(Azure.Temp.Batch.Models.JobState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), int? priority = default(int?), bool? allowTaskPreemption = default(bool?), int? maxParallelTasks = default(int?), Azure.Temp.Batch.Models.JobConstraints constraints = null, Azure.Temp.Batch.Models.JobManagerTask jobManagerTask = null, Azure.Temp.Batch.Models.JobPreparationTask jobPreparationTask = null, Azure.Temp.Batch.Models.JobReleaseTask jobReleaseTask = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.EnvironmentSetting> commonEnvironmentSettings = null, Azure.Temp.Batch.Models.PoolInformation poolInfo = null, Azure.Temp.Batch.Models.OnAllTasksComplete? onAllTasksComplete = default(Azure.Temp.Batch.Models.OnAllTasksComplete?), Azure.Temp.Batch.Models.OnTaskFailure? onTaskFailure = default(Azure.Temp.Batch.Models.OnTaskFailure?), Azure.Temp.Batch.Models.JobNetworkConfiguration networkConfiguration = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.MetadataItem> metadata = null, Azure.Temp.Batch.Models.JobExecutionInformation executionInfo = null, Azure.Temp.Batch.Models.JobStatistics stats = null) { throw null; }
        public static Azure.Temp.Batch.Models.CloudJobSchedule CloudJobSchedule(string id = null, string displayName = null, string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.JobScheduleState? state = default(Azure.Temp.Batch.Models.JobScheduleState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.JobScheduleState? previousState = default(Azure.Temp.Batch.Models.JobScheduleState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.Schedule schedule = null, Azure.Temp.Batch.Models.JobSpecification jobSpecification = null, Azure.Temp.Batch.Models.JobScheduleExecutionInformation executionInfo = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.MetadataItem> metadata = null, Azure.Temp.Batch.Models.JobScheduleStatistics stats = null) { throw null; }
        public static Azure.Temp.Batch.Models.CloudPool CloudPool(string id = null, string displayName = null, string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.PoolState? state = default(Azure.Temp.Batch.Models.PoolState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.AllocationState? allocationState = default(Azure.Temp.Batch.Models.AllocationState?), System.DateTimeOffset? allocationStateTransitionTime = default(System.DateTimeOffset?), string vmSize = null, Azure.Temp.Batch.Models.CloudServiceConfiguration cloudServiceConfiguration = null, Azure.Temp.Batch.Models.VirtualMachineConfiguration virtualMachineConfiguration = null, System.TimeSpan? resizeTimeout = default(System.TimeSpan?), System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.ResizeError> resizeErrors = null, int? currentDedicatedNodes = default(int?), int? currentLowPriorityNodes = default(int?), int? targetDedicatedNodes = default(int?), int? targetLowPriorityNodes = default(int?), bool? enableAutoScale = default(bool?), string autoScaleFormula = null, System.TimeSpan? autoScaleEvaluationInterval = default(System.TimeSpan?), Azure.Temp.Batch.Models.AutoScaleRun autoScaleRun = null, bool? enableInterNodeCommunication = default(bool?), Azure.Temp.Batch.Models.NetworkConfiguration networkConfiguration = null, Azure.Temp.Batch.Models.StartTask startTask = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.CertificateReference> certificateReferences = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.ApplicationPackageReference> applicationPackageReferences = null, System.Collections.Generic.IEnumerable<string> applicationLicenses = null, int? taskSlotsPerNode = default(int?), Azure.Temp.Batch.Models.TaskSchedulingPolicy taskSchedulingPolicy = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.UserAccount> userAccounts = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.MetadataItem> metadata = null, Azure.Temp.Batch.Models.PoolStatistics stats = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.MountConfiguration> mountConfiguration = null, Azure.Temp.Batch.Models.BatchPoolIdentity identity = null, Azure.Temp.Batch.Models.NodeCommunicationMode? targetNodeCommunicationMode = default(Azure.Temp.Batch.Models.NodeCommunicationMode?), Azure.Temp.Batch.Models.NodeCommunicationMode? currentNodeCommunicationMode = default(Azure.Temp.Batch.Models.NodeCommunicationMode?)) { throw null; }
        public static Azure.Temp.Batch.Models.CloudTask CloudTask(string id = null, string displayName = null, string url = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.ExitConditions exitConditions = null, Azure.Temp.Batch.Models.TaskState? state = default(Azure.Temp.Batch.Models.TaskState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.TaskState? previousState = default(Azure.Temp.Batch.Models.TaskState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), string commandLine = null, Azure.Temp.Batch.Models.TaskContainerSettings containerSettings = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.ResourceFile> resourceFiles = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.OutputFile> outputFiles = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.EnvironmentSetting> environmentSettings = null, Azure.Temp.Batch.Models.AffinityInformation affinityInfo = null, Azure.Temp.Batch.Models.TaskConstraints constraints = null, int? requiredSlots = default(int?), Azure.Temp.Batch.Models.UserIdentity userIdentity = null, Azure.Temp.Batch.Models.TaskExecutionInformation executionInfo = null, Azure.Temp.Batch.Models.ComputeNodeInformation nodeInfo = null, Azure.Temp.Batch.Models.MultiInstanceSettings multiInstanceSettings = null, Azure.Temp.Batch.Models.TaskStatistics stats = null, Azure.Temp.Batch.Models.TaskDependencies dependsOn = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.ApplicationPackageReference> applicationPackageReferences = null, Azure.Temp.Batch.Models.AuthenticationTokenSettings authenticationTokenSettings = null) { throw null; }
        public static Azure.Temp.Batch.Models.CloudTaskListSubtasksResult CloudTaskListSubtasksResult(System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.SubtaskInformation> value = null) { throw null; }
        public static Azure.Temp.Batch.Models.ComputeNode ComputeNode(string id = null, string url = null, Azure.Temp.Batch.Models.ComputeNodeState? state = default(Azure.Temp.Batch.Models.ComputeNodeState?), Azure.Temp.Batch.Models.SchedulingState? schedulingState = default(Azure.Temp.Batch.Models.SchedulingState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), System.DateTimeOffset? lastBootTime = default(System.DateTimeOffset?), System.DateTimeOffset? allocationTime = default(System.DateTimeOffset?), string ipAddress = null, string affinityId = null, string vmSize = null, int? totalTasksRun = default(int?), int? runningTasksCount = default(int?), int? runningTaskSlotsCount = default(int?), int? totalTasksSucceeded = default(int?), System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.TaskInformation> recentTasks = null, Azure.Temp.Batch.Models.StartTask startTask = null, Azure.Temp.Batch.Models.StartTaskInformation startTaskInfo = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.CertificateReference> certificateReferences = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.ComputeNodeError> errors = null, bool? isDedicated = default(bool?), Azure.Temp.Batch.Models.ComputeNodeEndpointConfiguration endpointConfiguration = null, Azure.Temp.Batch.Models.NodeAgentInformation nodeAgentInfo = null, Azure.Temp.Batch.Models.VirtualMachineInfo virtualMachineInfo = null) { throw null; }
        public static Azure.Temp.Batch.Models.ComputeNodeEndpointConfiguration ComputeNodeEndpointConfiguration(System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.InboundEndpoint> inboundEndpoints = null) { throw null; }
        public static Azure.Temp.Batch.Models.ComputeNodeError ComputeNodeError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.NameValuePair> errorDetails = null) { throw null; }
        public static Azure.Temp.Batch.Models.ComputeNodeGetRemoteLoginSettingsResult ComputeNodeGetRemoteLoginSettingsResult(string remoteLoginIPAddress = null, int remoteLoginPort = 0) { throw null; }
        public static Azure.Temp.Batch.Models.ComputeNodeInformation ComputeNodeInformation(string affinityId = null, string nodeUrl = null, string poolId = null, string nodeId = null, string taskRootDirectory = null, string taskRootDirectoryUrl = null) { throw null; }
        public static Azure.Temp.Batch.Models.DeleteCertificateError DeleteCertificateError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.NameValuePair> values = null) { throw null; }
        public static Azure.Temp.Batch.Models.ErrorMessage ErrorMessage(string lang = null, string value = null) { throw null; }
        public static Azure.Temp.Batch.Models.FileProperties FileProperties(System.DateTimeOffset? creationTime = default(System.DateTimeOffset?), System.DateTimeOffset lastModified = default(System.DateTimeOffset), long contentLength = (long)0, string contentType = null, string fileMode = null) { throw null; }
        public static Azure.Temp.Batch.Models.ImageInformation ImageInformation(string nodeAgentSKUId = null, Azure.Temp.Batch.Models.ImageReference imageReference = null, Azure.Temp.Batch.Models.OSType osType = Azure.Temp.Batch.Models.OSType.Linux, System.Collections.Generic.IEnumerable<string> capabilities = null, System.DateTimeOffset? batchSupportEndOfLife = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.VerificationType verificationType = Azure.Temp.Batch.Models.VerificationType.Verified) { throw null; }
        public static Azure.Temp.Batch.Models.ImageReference ImageReference(string publisher = null, string offer = null, string sku = null, string version = null, string virtualMachineImageId = null, string exactVersion = null) { throw null; }
        public static Azure.Temp.Batch.Models.InboundEndpoint InboundEndpoint(string name = null, Azure.Temp.Batch.Models.InboundEndpointProtocol protocol = Azure.Temp.Batch.Models.InboundEndpointProtocol.Tcp, string publicIPAddress = null, string publicFqdn = null, int frontendPort = 0, int backendPort = 0) { throw null; }
        public static Azure.Temp.Batch.Models.InstanceViewStatus InstanceViewStatus(string code = null, string displayStatus = null, Azure.Temp.Batch.Models.StatusLevelTypes? level = default(Azure.Temp.Batch.Models.StatusLevelTypes?), string message = null, string time = null) { throw null; }
        public static Azure.Temp.Batch.Models.JobExecutionInformation JobExecutionInformation(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), string poolId = null, Azure.Temp.Batch.Models.JobSchedulingError schedulingError = null, string terminateReason = null) { throw null; }
        public static Azure.Temp.Batch.Models.JobPreparationAndReleaseTaskExecutionInformation JobPreparationAndReleaseTaskExecutionInformation(string poolId = null, string nodeId = null, string nodeUrl = null, Azure.Temp.Batch.Models.JobPreparationTaskExecutionInformation jobPreparationTaskExecutionInfo = null, Azure.Temp.Batch.Models.JobReleaseTaskExecutionInformation jobReleaseTaskExecutionInfo = null) { throw null; }
        public static Azure.Temp.Batch.Models.JobPreparationTaskExecutionInformation JobPreparationTaskExecutionInformation(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.JobPreparationTaskState state = Azure.Temp.Batch.Models.JobPreparationTaskState.Running, string taskRootDirectory = null, string taskRootDirectoryUrl = null, int? exitCode = default(int?), Azure.Temp.Batch.Models.TaskContainerExecutionInformation containerInfo = null, Azure.Temp.Batch.Models.TaskFailureInformation failureInfo = null, int retryCount = 0, System.DateTimeOffset? lastRetryTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.TaskExecutionResult? result = default(Azure.Temp.Batch.Models.TaskExecutionResult?)) { throw null; }
        public static Azure.Temp.Batch.Models.JobReleaseTaskExecutionInformation JobReleaseTaskExecutionInformation(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.JobReleaseTaskState state = Azure.Temp.Batch.Models.JobReleaseTaskState.Running, string taskRootDirectory = null, string taskRootDirectoryUrl = null, int? exitCode = default(int?), Azure.Temp.Batch.Models.TaskContainerExecutionInformation containerInfo = null, Azure.Temp.Batch.Models.TaskFailureInformation failureInfo = null, Azure.Temp.Batch.Models.TaskExecutionResult? result = default(Azure.Temp.Batch.Models.TaskExecutionResult?)) { throw null; }
        public static Azure.Temp.Batch.Models.JobScheduleExecutionInformation JobScheduleExecutionInformation(System.DateTimeOffset? nextRunTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.RecentJob recentJob = null, System.DateTimeOffset? endTime = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.Temp.Batch.Models.JobScheduleStatistics JobScheduleStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan userCPUTime = default(System.TimeSpan), System.TimeSpan kernelCPUTime = default(System.TimeSpan), System.TimeSpan wallClockTime = default(System.TimeSpan), long readIOps = (long)0, long writeIOps = (long)0, double readIOGiB = 0, double writeIOGiB = 0, long numSucceededTasks = (long)0, long numFailedTasks = (long)0, long numTaskRetries = (long)0, System.TimeSpan waitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Temp.Batch.Models.JobSchedulingError JobSchedulingError(Azure.Temp.Batch.Models.ErrorCategory category = Azure.Temp.Batch.Models.ErrorCategory.UserError, string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.NameValuePair> details = null) { throw null; }
        public static Azure.Temp.Batch.Models.JobStatistics JobStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan userCPUTime = default(System.TimeSpan), System.TimeSpan kernelCPUTime = default(System.TimeSpan), System.TimeSpan wallClockTime = default(System.TimeSpan), long readIOps = (long)0, long writeIOps = (long)0, double readIOGiB = 0, double writeIOGiB = 0, long numSucceededTasks = (long)0, long numFailedTasks = (long)0, long numTaskRetries = (long)0, System.TimeSpan waitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Temp.Batch.Models.NameValuePair NameValuePair(string name = null, string value = null) { throw null; }
        public static Azure.Temp.Batch.Models.NodeAgentInformation NodeAgentInformation(string version = null, System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset)) { throw null; }
        public static Azure.Temp.Batch.Models.NodeCounts NodeCounts(int creating = 0, int idle = 0, int offline = 0, int preempted = 0, int rebooting = 0, int reimaging = 0, int running = 0, int starting = 0, int startTaskFailed = 0, int leavingPool = 0, int unknown = 0, int unusable = 0, int waitingForStartTask = 0, int total = 0) { throw null; }
        public static Azure.Temp.Batch.Models.NodeFile NodeFile(string name = null, string url = null, bool? isDirectory = default(bool?), Azure.Temp.Batch.Models.FileProperties properties = null) { throw null; }
        public static Azure.Temp.Batch.Models.NodeVMExtension NodeVMExtension(string provisioningState = null, Azure.Temp.Batch.Models.VMExtension vmExtension = null, Azure.Temp.Batch.Models.VMExtensionInstanceView instanceView = null) { throw null; }
        public static Azure.Temp.Batch.Models.PoolNodeCounts PoolNodeCounts(string poolId = null, Azure.Temp.Batch.Models.NodeCounts dedicated = null, Azure.Temp.Batch.Models.NodeCounts lowPriority = null) { throw null; }
        public static Azure.Temp.Batch.Models.PoolStatistics PoolStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), Azure.Temp.Batch.Models.UsageStatistics usageStats = null, Azure.Temp.Batch.Models.ResourceStatistics resourceStats = null) { throw null; }
        public static Azure.Temp.Batch.Models.PoolUsageMetrics PoolUsageMetrics(string poolId = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset endTime = default(System.DateTimeOffset), string vmSize = null, double totalCoreHours = 0) { throw null; }
        public static Azure.Temp.Batch.Models.RecentJob RecentJob(string id = null, string url = null) { throw null; }
        public static Azure.Temp.Batch.Models.ResizeError ResizeError(string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.NameValuePair> values = null) { throw null; }
        public static Azure.Temp.Batch.Models.ResourceStatistics ResourceStatistics(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), double avgCPUPercentage = 0, double avgMemoryGiB = 0, double peakMemoryGiB = 0, double avgDiskGiB = 0, double peakDiskGiB = 0, long diskReadIOps = (long)0, long diskWriteIOps = (long)0, double diskReadGiB = 0, double diskWriteGiB = 0, double networkReadGiB = 0, double networkWriteGiB = 0) { throw null; }
        public static Azure.Temp.Batch.Models.StartTaskInformation StartTaskInformation(Azure.Temp.Batch.Models.StartTaskState state = Azure.Temp.Batch.Models.StartTaskState.Running, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), int? exitCode = default(int?), Azure.Temp.Batch.Models.TaskContainerExecutionInformation containerInfo = null, Azure.Temp.Batch.Models.TaskFailureInformation failureInfo = null, int retryCount = 0, System.DateTimeOffset? lastRetryTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.TaskExecutionResult? result = default(Azure.Temp.Batch.Models.TaskExecutionResult?)) { throw null; }
        public static Azure.Temp.Batch.Models.SubtaskInformation SubtaskInformation(int? id = default(int?), Azure.Temp.Batch.Models.ComputeNodeInformation nodeInfo = null, System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), int? exitCode = default(int?), Azure.Temp.Batch.Models.TaskContainerExecutionInformation containerInfo = null, Azure.Temp.Batch.Models.TaskFailureInformation failureInfo = null, Azure.Temp.Batch.Models.SubtaskState? state = default(Azure.Temp.Batch.Models.SubtaskState?), System.DateTimeOffset? stateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.SubtaskState? previousState = default(Azure.Temp.Batch.Models.SubtaskState?), System.DateTimeOffset? previousStateTransitionTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.TaskExecutionResult? result = default(Azure.Temp.Batch.Models.TaskExecutionResult?)) { throw null; }
        public static Azure.Temp.Batch.Models.TaskAddCollectionResult TaskAddCollectionResult(System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.TaskAddResult> value = null) { throw null; }
        public static Azure.Temp.Batch.Models.TaskAddResult TaskAddResult(Azure.Temp.Batch.Models.TaskAddStatus status = Azure.Temp.Batch.Models.TaskAddStatus.Success, string taskId = null, string eTag = null, System.DateTimeOffset? lastModified = default(System.DateTimeOffset?), string location = null, Azure.Temp.Batch.Models.BatchError error = null) { throw null; }
        public static Azure.Temp.Batch.Models.TaskContainerExecutionInformation TaskContainerExecutionInformation(string containerId = null, string state = null, string error = null) { throw null; }
        public static Azure.Temp.Batch.Models.TaskCounts TaskCounts(int active = 0, int running = 0, int completed = 0, int succeeded = 0, int failed = 0) { throw null; }
        public static Azure.Temp.Batch.Models.TaskCountsResult TaskCountsResult(Azure.Temp.Batch.Models.TaskCounts taskCounts = null, Azure.Temp.Batch.Models.TaskSlotCounts taskSlotCounts = null) { throw null; }
        public static Azure.Temp.Batch.Models.TaskExecutionInformation TaskExecutionInformation(System.DateTimeOffset? startTime = default(System.DateTimeOffset?), System.DateTimeOffset? endTime = default(System.DateTimeOffset?), int? exitCode = default(int?), Azure.Temp.Batch.Models.TaskContainerExecutionInformation containerInfo = null, Azure.Temp.Batch.Models.TaskFailureInformation failureInfo = null, int retryCount = 0, System.DateTimeOffset? lastRetryTime = default(System.DateTimeOffset?), int requeueCount = 0, System.DateTimeOffset? lastRequeueTime = default(System.DateTimeOffset?), Azure.Temp.Batch.Models.TaskExecutionResult? result = default(Azure.Temp.Batch.Models.TaskExecutionResult?)) { throw null; }
        public static Azure.Temp.Batch.Models.TaskFailureInformation TaskFailureInformation(Azure.Temp.Batch.Models.ErrorCategory category = Azure.Temp.Batch.Models.ErrorCategory.UserError, string code = null, string message = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.NameValuePair> details = null) { throw null; }
        public static Azure.Temp.Batch.Models.TaskInformation TaskInformation(string taskUrl = null, string jobId = null, string taskId = null, int? subtaskId = default(int?), Azure.Temp.Batch.Models.TaskState taskState = Azure.Temp.Batch.Models.TaskState.Active, Azure.Temp.Batch.Models.TaskExecutionInformation executionInfo = null) { throw null; }
        public static Azure.Temp.Batch.Models.TaskSlotCounts TaskSlotCounts(int active = 0, int running = 0, int completed = 0, int succeeded = 0, int failed = 0) { throw null; }
        public static Azure.Temp.Batch.Models.TaskStatistics TaskStatistics(string url = null, System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan userCPUTime = default(System.TimeSpan), System.TimeSpan kernelCPUTime = default(System.TimeSpan), System.TimeSpan wallClockTime = default(System.TimeSpan), long readIOps = (long)0, long writeIOps = (long)0, double readIOGiB = 0, double writeIOGiB = 0, System.TimeSpan waitTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Temp.Batch.Models.UploadBatchServiceLogsResult UploadBatchServiceLogsResult(string virtualDirectoryName = null, int numberOfFilesUploaded = 0) { throw null; }
        public static Azure.Temp.Batch.Models.UsageStatistics UsageStatistics(System.DateTimeOffset startTime = default(System.DateTimeOffset), System.DateTimeOffset lastUpdateTime = default(System.DateTimeOffset), System.TimeSpan dedicatedCoreTime = default(System.TimeSpan)) { throw null; }
        public static Azure.Temp.Batch.Models.UserAssignedIdentity UserAssignedIdentity(string resourceId = null, string clientId = null, string principalId = null) { throw null; }
        public static Azure.Temp.Batch.Models.VirtualMachineInfo VirtualMachineInfo(Azure.Temp.Batch.Models.ImageReference imageReference = null) { throw null; }
        public static Azure.Temp.Batch.Models.VMExtensionInstanceView VMExtensionInstanceView(string name = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.InstanceViewStatus> statuses = null, System.Collections.Generic.IEnumerable<Azure.Temp.Batch.Models.InstanceViewStatus> subStatuses = null) { throw null; }
    }
    public partial class UploadBatchServiceLogsConfiguration
    {
        public UploadBatchServiceLogsConfiguration(string containerUrl, System.DateTimeOffset startTime) { }
        public string ContainerUrl { get { throw null; } }
        public System.DateTimeOffset? EndTime { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.ComputeNodeIdentityReference IdentityReference { get { throw null; } set { } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class UploadBatchServiceLogsResult
    {
        internal UploadBatchServiceLogsResult() { }
        public int NumberOfFilesUploaded { get { throw null; } }
        public string VirtualDirectoryName { get { throw null; } }
    }
    public partial class UsageStatistics
    {
        internal UsageStatistics() { }
        public System.TimeSpan DedicatedCoreTime { get { throw null; } }
        public System.DateTimeOffset LastUpdateTime { get { throw null; } }
        public System.DateTimeOffset StartTime { get { throw null; } }
    }
    public partial class UserAccount
    {
        public UserAccount(string name, string password) { }
        public Azure.Temp.Batch.Models.ElevationLevel? ElevationLevel { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.LinuxUserConfiguration LinuxUserConfiguration { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.WindowsUserConfiguration WindowsUserConfiguration { get { throw null; } set { } }
    }
    public partial class UserAssignedIdentity
    {
        internal UserAssignedIdentity() { }
        public string ClientId { get { throw null; } }
        public string PrincipalId { get { throw null; } }
        public string ResourceId { get { throw null; } }
    }
    public partial class UserIdentity
    {
        public UserIdentity() { }
        public Azure.Temp.Batch.Models.AutoUserSpecification AutoUser { get { throw null; } set { } }
        public string UserName { get { throw null; } set { } }
    }
    public enum VerificationType
    {
        Verified = 0,
        Unverified = 1,
    }
    public partial class VirtualMachineConfiguration
    {
        public VirtualMachineConfiguration(Azure.Temp.Batch.Models.ImageReference imageReference, string nodeAgentSKUId) { }
        public Azure.Temp.Batch.Models.ContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.DataDisk> DataDisks { get { throw null; } }
        public Azure.Temp.Batch.Models.DiskEncryptionConfiguration DiskEncryptionConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Temp.Batch.Models.VMExtension> Extensions { get { throw null; } }
        public Azure.Temp.Batch.Models.ImageReference ImageReference { get { throw null; } set { } }
        public string LicenseType { get { throw null; } set { } }
        public string NodeAgentSKUId { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.NodePlacementConfiguration NodePlacementConfiguration { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.OSDisk OsDisk { get { throw null; } set { } }
        public Azure.Temp.Batch.Models.WindowsConfiguration WindowsConfiguration { get { throw null; } set { } }
    }
    public partial class VirtualMachineInfo
    {
        internal VirtualMachineInfo() { }
        public Azure.Temp.Batch.Models.ImageReference ImageReference { get { throw null; } }
    }
    public partial class VMExtension
    {
        public VMExtension(string name, string publisher, string type) { }
        public bool? AutoUpgradeMinorVersion { get { throw null; } set { } }
        public bool? EnableAutomaticUpgrade { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public object ProtectedSettings { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProvisionAfterExtensions { get { throw null; } }
        public string Publisher { get { throw null; } set { } }
        public object Settings { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        public string TypeHandlerVersion { get { throw null; } set { } }
    }
    public partial class VMExtensionInstanceView
    {
        internal VMExtensionInstanceView() { }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.InstanceViewStatus> Statuses { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Temp.Batch.Models.InstanceViewStatus> SubStatuses { get { throw null; } }
    }
    public partial class WindowsConfiguration
    {
        public WindowsConfiguration() { }
        public bool? EnableAutomaticUpdates { get { throw null; } set { } }
    }
    public partial class WindowsUserConfiguration
    {
        public WindowsUserConfiguration() { }
        public Azure.Temp.Batch.Models.LoginMode? LoginMode { get { throw null; } set { } }
    }
}
