
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// </summary>
    public partial interface IStorSimple8000SeriesManagementClient : System.IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        Newtonsoft.Json.JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        Newtonsoft.Json.JsonSerializerSettings DeserializationSettings { get; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// The api version
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// The subscription id
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running
        /// Operations. Default value is 30.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated
        /// and included in each request. Default is true.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }


        /// <summary>
        /// Gets the IOperations.
        /// </summary>
        IOperations Operations { get; }

        /// <summary>
        /// Gets the IManagersOperations.
        /// </summary>
        IManagersOperations Managers { get; }

        /// <summary>
        /// Gets the IAccessControlRecordsOperations.
        /// </summary>
        IAccessControlRecordsOperations AccessControlRecords { get; }

        /// <summary>
        /// Gets the IAlertsOperations.
        /// </summary>
        IAlertsOperations Alerts { get; }

        /// <summary>
        /// Gets the IBandwidthSettingsOperations.
        /// </summary>
        IBandwidthSettingsOperations BandwidthSettings { get; }

        /// <summary>
        /// Gets the ICloudAppliancesOperations.
        /// </summary>
        ICloudAppliancesOperations CloudAppliances { get; }

        /// <summary>
        /// Gets the IDevicesOperations.
        /// </summary>
        IDevicesOperations Devices { get; }

        /// <summary>
        /// Gets the IDeviceSettingsOperations.
        /// </summary>
        IDeviceSettingsOperations DeviceSettings { get; }

        /// <summary>
        /// Gets the IBackupPoliciesOperations.
        /// </summary>
        IBackupPoliciesOperations BackupPolicies { get; }

        /// <summary>
        /// Gets the IBackupSchedulesOperations.
        /// </summary>
        IBackupSchedulesOperations BackupSchedules { get; }

        /// <summary>
        /// Gets the IBackupsOperations.
        /// </summary>
        IBackupsOperations Backups { get; }

        /// <summary>
        /// Gets the IHardwareComponentGroupsOperations.
        /// </summary>
        IHardwareComponentGroupsOperations HardwareComponentGroups { get; }

        /// <summary>
        /// Gets the IJobsOperations.
        /// </summary>
        IJobsOperations Jobs { get; }

        /// <summary>
        /// Gets the IVolumeContainersOperations.
        /// </summary>
        IVolumeContainersOperations VolumeContainers { get; }

        /// <summary>
        /// Gets the IVolumesOperations.
        /// </summary>
        IVolumesOperations Volumes { get; }

        /// <summary>
        /// Gets the IStorageAccountCredentialsOperations.
        /// </summary>
        IStorageAccountCredentialsOperations StorageAccountCredentials { get; }

    }
}

