
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    public partial class StorSimple8000SeriesManagementClient : ServiceClient<StorSimple8000SeriesManagementClient>, IStorSimple8000SeriesManagementClient, IAzureClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public Newtonsoft.Json.JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public Newtonsoft.Json.JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        /// Credentials needed for the client to connect to Azure.
        /// </summary>
        public ServiceClientCredentials Credentials { get; private set; }

        /// <summary>
        /// The api version
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// The subscription id
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running Operations.
        /// Default value is 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated and
        /// included in each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets the IOperations.
        /// </summary>
        public virtual IOperations Operations { get; private set; }

        /// <summary>
        /// Gets the IManagersOperations.
        /// </summary>
        public virtual IManagersOperations Managers { get; private set; }

        /// <summary>
        /// Gets the IAccessControlRecordsOperations.
        /// </summary>
        public virtual IAccessControlRecordsOperations AccessControlRecords { get; private set; }

        /// <summary>
        /// Gets the IAlertsOperations.
        /// </summary>
        public virtual IAlertsOperations Alerts { get; private set; }

        /// <summary>
        /// Gets the IBandwidthSettingsOperations.
        /// </summary>
        public virtual IBandwidthSettingsOperations BandwidthSettings { get; private set; }

        /// <summary>
        /// Gets the ICloudAppliancesOperations.
        /// </summary>
        public virtual ICloudAppliancesOperations CloudAppliances { get; private set; }

        /// <summary>
        /// Gets the IDevicesOperations.
        /// </summary>
        public virtual IDevicesOperations Devices { get; private set; }

        /// <summary>
        /// Gets the IDeviceSettingsOperations.
        /// </summary>
        public virtual IDeviceSettingsOperations DeviceSettings { get; private set; }

        /// <summary>
        /// Gets the IBackupPoliciesOperations.
        /// </summary>
        public virtual IBackupPoliciesOperations BackupPolicies { get; private set; }

        /// <summary>
        /// Gets the IBackupSchedulesOperations.
        /// </summary>
        public virtual IBackupSchedulesOperations BackupSchedules { get; private set; }

        /// <summary>
        /// Gets the IBackupsOperations.
        /// </summary>
        public virtual IBackupsOperations Backups { get; private set; }

        /// <summary>
        /// Gets the IHardwareComponentGroupsOperations.
        /// </summary>
        public virtual IHardwareComponentGroupsOperations HardwareComponentGroups { get; private set; }

        /// <summary>
        /// Gets the IJobsOperations.
        /// </summary>
        public virtual IJobsOperations Jobs { get; private set; }

        /// <summary>
        /// Gets the IVolumeContainersOperations.
        /// </summary>
        public virtual IVolumeContainersOperations VolumeContainers { get; private set; }

        /// <summary>
        /// Gets the IVolumesOperations.
        /// </summary>
        public virtual IVolumesOperations Volumes { get; private set; }

        /// <summary>
        /// Gets the IStorageAccountCredentialsOperations.
        /// </summary>
        public virtual IStorageAccountCredentialsOperations StorageAccountCredentials { get; private set; }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        protected StorSimple8000SeriesManagementClient(params System.Net.Http.DelegatingHandler[] handlers) : base(handlers)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        protected StorSimple8000SeriesManagementClient(System.Net.Http.HttpClientHandler rootHandler, params System.Net.Http.DelegatingHandler[] handlers) : base(rootHandler, handlers)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        protected StorSimple8000SeriesManagementClient(System.Uri baseUri, params System.Net.Http.DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException("baseUri");
            }
            BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        protected StorSimple8000SeriesManagementClient(System.Uri baseUri, System.Net.Http.HttpClientHandler rootHandler, params System.Net.Http.DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException("baseUri");
            }
            BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public StorSimple8000SeriesManagementClient(ServiceClientCredentials credentials, params System.Net.Http.DelegatingHandler[] handlers) : this(handlers)
        {
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }
            Credentials = credentials;
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public StorSimple8000SeriesManagementClient(ServiceClientCredentials credentials, System.Net.Http.HttpClientHandler rootHandler, params System.Net.Http.DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }
            Credentials = credentials;
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public StorSimple8000SeriesManagementClient(System.Uri baseUri, ServiceClientCredentials credentials, params System.Net.Http.DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }
            BaseUri = baseUri;
            Credentials = credentials;
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the StorSimple8000SeriesManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Credentials needed for the client to connect to Azure.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public StorSimple8000SeriesManagementClient(System.Uri baseUri, ServiceClientCredentials credentials, System.Net.Http.HttpClientHandler rootHandler, params System.Net.Http.DelegatingHandler[] handlers) : this(rootHandler, handlers)
        {
            if (baseUri == null)
            {
                throw new System.ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new System.ArgumentNullException("credentials");
            }
            BaseUri = baseUri;
            Credentials = credentials;
            if (Credentials != null)
            {
                Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// An optional partial-method to perform custom initialization.
        /// </summary>
        partial void CustomInitialize();
        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            Operations = new Operations(this);
            Managers = new ManagersOperations(this);
            AccessControlRecords = new AccessControlRecordsOperations(this);
            Alerts = new AlertsOperations(this);
            BandwidthSettings = new BandwidthSettingsOperations(this);
            CloudAppliances = new CloudAppliancesOperations(this);
            Devices = new DevicesOperations(this);
            DeviceSettings = new DeviceSettingsOperations(this);
            BackupPolicies = new BackupPoliciesOperations(this);
            BackupSchedules = new BackupSchedulesOperations(this);
            Backups = new BackupsOperations(this);
            HardwareComponentGroups = new HardwareComponentGroupsOperations(this);
            Jobs = new JobsOperations(this);
            VolumeContainers = new VolumeContainersOperations(this);
            Volumes = new VolumesOperations(this);
            StorageAccountCredentials = new StorageAccountCredentialsOperations(this);
            BaseUri = new System.Uri("https://management.azure.com");
            ApiVersion = "2017-06-01";
            AcceptLanguage = "en-US";
            LongRunningOperationRetryTimeout = 30;
            GenerateClientRequestId = true;
            SerializationSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new System.Collections.Generic.List<Newtonsoft.Json.JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            SerializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new System.Collections.Generic.List<Newtonsoft.Json.JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            CustomInitialize();
            DeserializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter());
        }
    }
}

