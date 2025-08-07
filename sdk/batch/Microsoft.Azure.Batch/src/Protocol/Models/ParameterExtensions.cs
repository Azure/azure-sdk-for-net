namespace Microsoft.Azure.Batch.Protocol.Models
{
    public partial class AccountListSupportedImagesOptions : ITimeoutOptions, IODataFilter { }
    public partial class AccountListSupportedImagesNextOptions : IOptions { }
    public partial class AccountListPoolNodeCountsOptions : ITimeoutOptions, IODataFilter { }
    public partial class AccountListPoolNodeCountsNextOptions : IOptions { }
    public partial class ApplicationGetOptions : ITimeoutOptions { }
    public partial class ApplicationListOptions : ITimeoutOptions { }
    public partial class ApplicationListNextOptions : IOptions { }
    public partial class CertificateAddOptions : ITimeoutOptions { }
    public partial class CertificateCancelDeletionOptions : ITimeoutOptions { }
    public partial class CertificateDeleteOptions : ITimeoutOptions { }
    public partial class CertificateGetOptions : ITimeoutOptions, IODataSelect { }
    public partial class CertificateListOptions : ITimeoutOptions, IODataSelect, IODataFilter { }
    public partial class CertificateListNextOptions : IOptions { }
    public partial class ComputeNodeDeallocateOptions : ITimeoutOptions { }
    public partial class ComputeNodeAddUserOptions : ITimeoutOptions { }
    public partial class ComputeNodeDeleteUserOptions : ITimeoutOptions { }
    public partial class ComputeNodeGetOptions : ITimeoutOptions, IODataSelect { }
    public partial class ComputeNodeGetRemoteLoginSettingsOptions : ITimeoutOptions { }
    public partial class ComputeNodeListOptions : ITimeoutOptions, IODataSelect, IODataFilter { }
    public partial class ComputeNodeListNextOptions : IOptions { }
    public partial class ComputeNodeRebootOptions : ITimeoutOptions { }
    public partial class ComputeNodeReimageOptions : ITimeoutOptions { }
    public partial class ComputeNodeStartOptions : ITimeoutOptions { }
    public partial class ComputeNodeExtensionGetOptions : ITimeoutOptions, IODataSelect { }
    public partial class ComputeNodeExtensionListOptions : ITimeoutOptions, IODataSelect { }
    public partial class ComputeNodeExtensionListNextOptions : IOptions { }
    public partial class PoolRemoveNodesOptions : ITimeoutOptions { }
    public partial class ComputeNodeUpdateUserOptions : ITimeoutOptions { }
    public partial class ComputeNodeUploadBatchServiceLogsOptions : ITimeoutOptions { }
    public partial class FileDeleteFromComputeNodeOptions : ITimeoutOptions { }
    public partial class FileDeleteFromTaskOptions : ITimeoutOptions { }
    public partial class FileGetFromComputeNodeOptions : ITimeoutOptions { }
    public partial class FileGetFromTaskOptions : ITimeoutOptions { }
    public partial class FileGetPropertiesFromComputeNodeOptions : ITimeoutOptions { }
    public partial class FileGetPropertiesFromTaskOptions : ITimeoutOptions { }
    public partial class FileListFromComputeNodeOptions : ITimeoutOptions, IODataFilter { }
    public partial class FileListFromComputeNodeNextOptions : IOptions { }
    public partial class FileListFromTaskOptions : ITimeoutOptions, IODataFilter { }
    public partial class FileListFromTaskNextOptions : IOptions { }
    public partial class JobAddOptions : ITimeoutOptions { }
    public partial class JobDeleteOptions : ITimeoutOptions { }
    public partial class JobDisableOptions : ITimeoutOptions { }
    public partial class JobEnableOptions : ITimeoutOptions { }
    public partial class JobGetOptions : ITimeoutOptions, IODataSelect, IODataExpand { }
    public partial class JobGetTaskCountsOptions : ITimeoutOptions { }
    public partial class JobListFromJobScheduleOptions : ITimeoutOptions, IODataSelect, IODataFilter, IODataExpand { }
    public partial class JobListFromJobScheduleNextOptions : IOptions { }
    public partial class JobListOptions : ITimeoutOptions, IODataSelect, IODataFilter, IODataExpand { }
    public partial class JobListNextOptions : IOptions { }
    public partial class JobListPreparationAndReleaseTaskStatusOptions : ITimeoutOptions, IODataFilter, IODataSelect { }
    public partial class JobListPreparationAndReleaseTaskStatusNextOptions : IOptions { }
    public partial class JobPatchOptions : ITimeoutOptions { }
    public partial class JobScheduleAddOptions : ITimeoutOptions { }
    public partial class JobScheduleDeleteOptions : ITimeoutOptions { }
    public partial class JobScheduleDisableOptions : ITimeoutOptions { }
    public partial class JobScheduleEnableOptions : ITimeoutOptions { }
    public partial class JobScheduleExistsOptions : ITimeoutOptions { }
    public partial class JobScheduleGetOptions : ITimeoutOptions, IODataSelect, IODataExpand { }
    public partial class JobScheduleListOptions : ITimeoutOptions, IODataSelect, IODataFilter, IODataExpand { }
    public partial class JobScheduleListNextOptions : IOptions { }
    public partial class JobSchedulePatchOptions : ITimeoutOptions { }
    public partial class JobScheduleTerminateOptions : ITimeoutOptions { }
    public partial class JobScheduleUpdateOptions : ITimeoutOptions { }
    public partial class JobTerminateOptions : ITimeoutOptions { }
    public partial class JobUpdateOptions : ITimeoutOptions { }
    public partial class PoolAddOptions : ITimeoutOptions { }
    public partial class PoolDeleteOptions : ITimeoutOptions { }
    public partial class PoolDisableAutoScaleOptions : ITimeoutOptions { }
    public partial class PoolEnableAutoScaleOptions : ITimeoutOptions { }
    public partial class PoolEvaluateAutoScaleOptions : ITimeoutOptions { }
    public partial class PoolExistsOptions : ITimeoutOptions { }
    public partial class PoolGetOptions : ITimeoutOptions, IODataSelect, IODataExpand { }
    public partial class PoolListOptions : ITimeoutOptions, IODataSelect, IODataFilter, IODataExpand { }
    public partial class PoolListNextOptions : IOptions { }
    public partial class PoolListUsageMetricsOptions : ITimeoutOptions, IODataFilter { }
    public partial class PoolListUsageMetricsNextOptions : IOptions { }
    public partial class PoolPatchOptions : ITimeoutOptions { }
    public partial class PoolResizeOptions : ITimeoutOptions { }
    public partial class PoolStopResizeOptions : ITimeoutOptions { }
    public partial class PoolUpdatePropertiesOptions : ITimeoutOptions { }
    public partial class TaskAddOptions : ITimeoutOptions { }
    public partial class TaskAddCollectionOptions : ITimeoutOptions { }
    public partial class TaskDeleteOptions : ITimeoutOptions { }
    public partial class TaskGetOptions : ITimeoutOptions, IODataSelect, IODataExpand { }
    public partial class TaskListOptions : ITimeoutOptions, IODataSelect, IODataFilter, IODataExpand { }
    public partial class TaskListNextOptions : IOptions { }
    public partial class TaskReactivateOptions : ITimeoutOptions { }
    public partial class TaskTerminateOptions : ITimeoutOptions { }
    public partial class TaskUpdateOptions : ITimeoutOptions { }
    public partial class TaskListSubtasksOptions : ITimeoutOptions, IODataSelect { }
    public partial class ComputeNodeEnableSchedulingOptions : ITimeoutOptions { }
    public partial class ComputeNodeDisableSchedulingOptions : ITimeoutOptions { }
}
