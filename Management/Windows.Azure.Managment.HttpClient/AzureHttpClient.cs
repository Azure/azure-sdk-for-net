using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Windows.Azure.Management.v1_7
{
    public class AzureHttpClient : IDisposable
    {
        public AzureHttpClient(Guid subscriptionId, X509Certificate2 managementCertificate)
            : this(DefaultBaseAddress, subscriptionId, managementCertificate)
        {
        }

        //100 seconds is the default timeout...
        public AzureHttpClient(Uri baseUrl, Guid subscriptionId, X509Certificate2 managementCertificate, Int32 timeout = 100000)
        {
            this.SubscriptionId = subscriptionId;
            WebRequestHandler handler = new WebRequestHandler();
            handler.ClientCertificates.Add(managementCertificate);

            this._wrappedClient = new HttpClient(handler);
            this._wrappedClient.BaseAddress = baseUrl;
            this._wrappedClient.Timeout = new TimeSpan(0,0,0,0,timeout);

            this._formatter = new XmlMediaTypeFormatter { UseXmlSerializer = false };
            this._disposeLock = new object();
            this._disposed = false;
        }

        #region IDisposable Pattern
        private object _disposeLock;
        private bool _disposed;
        //no finalizer because no unmanaged resources

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(Boolean disposing)
        {
            lock (_disposeLock)
            {
                if (!_disposed)
                {
                    _disposed = true;

                    if (disposing)
                    {
                        this._wrappedClient.Dispose();
                        this._wrappedClient = null;
                        this._formatter = null;
                    }
                }
                else
                {
                    throw new ObjectDisposedException(this.GetType().ToString());
                }
            }
        }
        #endregion


        public static readonly Uri DefaultBaseAddress = new Uri(AzureConstants.AzureDefaultEndpoint);

        public Guid SubscriptionId { get; private set; }

        //Several methods have the label, description, location, and\or affinityGroup parameters
        //the XML may specify them in different orders, but for easy of use here,
        //we will always have them in the same order.
        //there is a name of some sort first,
        //then label, description, location, affinityGroup.

        #region Hosted Service Operations
        public Task<CloudServiceCollection> ListCloudServicesAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.HostedServices));

            return StartGetTask<CloudServiceCollection>(message, token);
        }

        public Task<String> CreateCloudServiceAsync(String name, String label, String description, String location, String affinityGroup, IDictionary<String, String> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            CreateCloudServiceInfo createInfo = CreateCloudServiceInfo.Create(name, label, description, location, affinityGroup, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.HostedServices), createInfo);

            return StartSendTask(message, token);
        }

        public Task<String> UpdateCloudServiceAsync(String serviceName, String label, String description, String location, String affinityGroup, IDictionary<String, String> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "name");

            //this validates the other args
            UpdateCloudServiceInfo updateInfo = UpdateCloudServiceInfo.Create(label, description, location, affinityGroup, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Put, CreateTargetUri(UriFormatStrings.HostedServicesAndService, serviceName), updateInfo);

            return StartSendTask(message, token);
        }

        public Task<String> DeleteCloudServiceAsync(String name, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(name, "name");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.HostedServicesAndService, name));

            return StartSendTask(message, token);
        }

        public Task<CloudService> GetCloudServicePropertiesAsync(String cloudServiceName, Boolean embedDetail = false, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            HttpRequestMessage message;
            if (embedDetail)
            {
                message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.GetHostedServicePropertiesEmbedDetail, cloudServiceName));
            }
            else
            {
                message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.HostedServicesAndService, cloudServiceName));
            }

            return StartGetTask<CloudService>(message, token);
        }


        public Task<String> CreateDeploymentAsync(String cloudServiceName, DeploymentSlot slot, String name, Uri packageUrl, String label, 
                                                  String configFilePath, Boolean startDeployment = false, 
                                                  Boolean treatWarningsAsError = false, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            //this validates the other parameters...
            CreateDeploymentInfo info = CreateDeploymentInfo.Create(name, packageUrl, label, configFilePath, startDeployment, treatWarningsAsError);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlot, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);

        }

        public Task<Deployment> GetDeploymentAsync(String cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.DeploymentSlot, cloudServiceName, slot.ToString()));

            return StartGetTask<Deployment>(message, token);
        }

        //the purpose of a VipSwap is to promote a "staging" deployment to production. So, the production slot
        //may be empty, but the staging slot may not. You cannot vip swap production to staging, without replacing
        //the production slot with something, but you can vip swap staging to a previously empty production
        public Task<String> VipSwapAsync(String cloudServiceName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            return GetCloudServicePropertiesAsync(cloudServiceName, true, token)
                   .ContinueWith<String>((propTask) =>
                       {
                           CloudService service = propTask.Result;
                           if (service.StagingDeployment == null)
                           {
                               throw new InvalidOperationException(Resources.StagingIsEmptyForVipSwap);
                           }

                           VipSwapInfo info = VipSwapInfo.Create(service.ProductionDeployment == null ? null : service.ProductionDeployment.Name, service.StagingDeployment.Name);

                           HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.HostedServicesAndService, cloudServiceName), info);

                           var res = StartSendTask(message, token);

                           return res.Result;
                       }, token);
        }

        public Task<String> DeleteDeploymentAsync(String cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.DeploymentSlot, cloudServiceName, slot.ToString()));

            return StartSendTask(message, token);
        }

        public Task<String> ChangeDeploymentConfigurationAsync(String cloudServiceName, DeploymentSlot slot, String configFilePath, Boolean treatWarningsAsError = false, UpgradeType mode = UpgradeType.Auto, IDictionary<String, String> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            //this validates the other parameters...
            ChangeDeploymentConfigurationInfo info = ChangeDeploymentConfigurationInfo.Create(configFilePath, treatWarningsAsError, mode, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotChangeConfig, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        public Task<String> StartDeploymentAsync(String cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            UpdateDeploymentStatusInfo info = UpdateDeploymentStatusInfo.Create(true);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotUpdateStatus, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        public Task<String> StopDeploymentAsync(String cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            UpdateDeploymentStatusInfo info = UpdateDeploymentStatusInfo.Create(false);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotUpdateStatus, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        public Task<String> UpgradeDeploymentAsync(String cloudServiceName, DeploymentSlot slot, UpgradeType mode, Uri packageUrl, String configFilePath, String label, CancellationToken token = default(CancellationToken), String roleToUpgrade = null, Boolean treatWarningsAsError = false, Boolean force = false, IDictionary<String, String> extendedProperties = null)
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            //this validates the other parameters...
            UpgradeDeploymentInfo info = UpgradeDeploymentInfo.Create(mode, packageUrl, configFilePath, label, roleToUpgrade, treatWarningsAsError, force, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotUpgrade, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        public Task<String> WalkUpgradeDomainAsync(String cloudServiceName, DeploymentSlot slot, Int32 upgradeDomain, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            WalkUpgradeDomainInfo info = WalkUpgradeDomainInfo.Create(upgradeDomain);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotWalkUpgradeDomain, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        //TODO: Reboot Role Instance
        //TODO: Reimage Role Instance
        //TODO: Rollback Update or Upgrade
        #endregion

        #region Storage Account Methods
        //still need RegenerateStorageAccountKeys, UpdateStorageAccount
        public Task<StorageAccountPropertiesCollection> ListStorageAccountsAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.StorageServices));

            return StartGetTask<StorageAccountPropertiesCollection>(message, token);
        }

        public Task<StorageAccountProperties> GetStorageAccountPropertiesAsync(String storageAccountName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.StorageServicesAndAccount, storageAccountName));

            return StartGetTask<StorageAccountProperties>(message, token);

        }

        public Task<StorageAccountKeys> GetStorageAccountKeysAsync(String storageAccountName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.GetStorageAccountKeys, storageAccountName));

            return StartGetTask<StorageAccountKeys>(message, token);

        }

        public Task<String> CreateStorageAccountAsync(String storageAccountName, String label, String description, String location, String affinityGroup, Boolean geoReplicationEnabled = false, IDictionary<String, String> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            CreateStorageAccountInfo info = CreateStorageAccountInfo.Create(storageAccountName, description, label, affinityGroup, location, geoReplicationEnabled, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.StorageServices), info);

            return StartSendTask(message, token);
        }

        public Task<String> DeleteStorageAccountAsync(String storageAccountName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.StorageServicesAndAccount, storageAccountName));

            return StartSendTask(message, token);
        }

        //TODO: Regenerate Storage Account Keys
        //TODO: Update Storage Account
        #endregion

        #region Tracking Methods
        public Task<OperationStatusInfo> GetOperationStatusAsync(String requestId, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(requestId, "requestId");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.GetOperationStatus, requestId));

            return StartGetTask<OperationStatusInfo>(message, token);
        }
        #endregion

        #region Location Operations
        public Task<LocationCollection> ListLocationsAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.Locations));

            return StartGetTask<LocationCollection>(message, token);
        }
        #endregion

        #region Affinity Group Operations
        public Task<AffinityGroupCollection> ListAffinityGroupsAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.AffinityGroups));

            return StartGetTask<AffinityGroupCollection>(message, token);
        }

        public Task<String> CreateAffinityGroupAsync(String name, String label, String description, String location, CancellationToken token = default(CancellationToken))
        {
            CreateAffinityGroupInfo info = CreateAffinityGroupInfo.Create(name, label, description, location);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.AffinityGroups), info);

            return StartSendTask(message, token);
        }

        public Task<String> DeleteAffinityGroupAsync(String affinityGroupName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(affinityGroupName, "affinityGroupName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.AffinityGroupsAndAffinityGroup, affinityGroupName));

            return StartSendTask(message, token);
        }

        public Task<AffinityGroup> GetAffinityGroupAsync(String affinityGroupName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(affinityGroupName, "affinityGroupName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.AffinityGroupsAndAffinityGroup, affinityGroupName));

            return StartGetTask<AffinityGroup>(message, token);
        }
        #endregion

        #region Certificate Operations
        #region Service Certificates
        public Task<ServiceCertificateCollection> ListServiceCertificatesAsync(String serviceName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ServiceCertificates, serviceName));

            return StartGetTask<ServiceCertificateCollection>(message, token);
        }

        public Task<X509Certificate2> GetServiceCertificateAsync(String serviceName, String thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ServiceCertificatesAndCertificate, serviceName, _sha1thumbprintAlgorithm, thumbprint));

            return StartGetTask<ServiceCertificateData>(message, token)
                       .ContinueWith<X509Certificate2>((certDataTask) =>
                       {
                           return certDataTask.Result.Certificate;
                       }, token, options, TaskScheduler.Current);

        }

        public Task<String> AddServiceCertificateAsync(String serviceName, X509Certificate2 certificate, String password, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");

            //other params validated here
            AddServiceCertificateInfo info = AddServiceCertificateInfo.Create(certificate, password);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.ServiceCertificates, serviceName), info);

            return StartSendTask(message, token);
        }

        public Task<String> DeleteServiceCertificate(String serviceName, String thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "serviceName");
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.ServiceCertificatesAndCertificate, serviceName, _sha1thumbprintAlgorithm, thumbprint));

            return StartSendTask(message, token);
        }
        #endregion

        #region ManagementCertificates
        public Task<String> AddManagementCertificateAsync(X509Certificate2 certificate, CancellationToken token = default(CancellationToken))
        {
            ManagementCertificateInfo info = ManagementCertificateInfo.Create(certificate);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.ManagementCertificates), info);

            return StartSendTask(message, token);
        }

        public Task<ManagementCertificateInfo> GetManagementCertificateAsync(String thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ManagementCertificatesAndCertificate, thumbprint));

            return StartGetTask<ManagementCertificateInfo>(message, token);
        }

        public Task<ManagementCertificateCollection> ListManagementCertificatesAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.ManagementCertificates));

            return StartGetTask<ManagementCertificateCollection>(message, token);
        }

        public Task<String> DeleteManagementCertificateAsync(String thumbprint, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(thumbprint, "thumbprint");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.ManagementCertificatesAndCertificate, thumbprint));

            return StartSendTask(message, token);
        }
        #endregion
        #endregion

        #region Helper Methods
        HttpRequestMessage CreateBaseMessage(HttpMethod method, Uri uri, object content = null)
        {
            HttpRequestMessage message = new HttpRequestMessage(method, uri);

            message.Headers.Add(UriFragments.VersionHeader, UriFragments.VersionTarget_1_7);

            if (content != null)
            {
                //message.CreateContent(content.GetType(), content, new List<MediaTypeFormatter> { this._formatter }, new FormatterSelector());
                message.Content = new ObjectContent(content.GetType(), content, this._formatter);
            }

            return message;
        }

        //use this one for calls that don't return any content. We return the request id
        //this can be ignored for calls that complete right away.
        Task<String> StartSendTask(HttpRequestMessage message, CancellationToken token)
        {
            return StartSendTask<String>(message, token, (returnTask) =>
                {
                    returnTask.Result.EnsureSuccessStatusCodeEx();
                    token.ThrowIfCancellationRequested();

                    return returnTask.Result.Headers.GetValues(UriFragments.RequestIdHeader).First();
                });
        }

        //use this one for calls that return specific content, GET operations in general
        Task<T> StartGetTask<T>(HttpRequestMessage message, CancellationToken token)
        {
            return StartSendTask<T>(message, token, (returnTask) =>
                {
                    returnTask.Result.EnsureSuccessStatusCodeEx();
                    token.ThrowIfCancellationRequested();

                    return returnTask.Result.Content.ReadAsSync<T>(this._formatter);
                });
        }

        //currently only option is execute synchronously, so we don't spawn another thread
        //the result will be read by the time we get there...
        private const TaskContinuationOptions options = TaskContinuationOptions.ExecuteSynchronously;

        Task<T> StartSendTask<T>(HttpRequestMessage message, CancellationToken token, Func<Task<HttpResponseMessage>,T> continuation)
        {
            return this._wrappedClient.SendAsync(message, token)
                       .ContinueWith<T>(continuation, token, options, TaskScheduler.Current);
        }

        Uri CreateTargetUri(string uriformat, params string[] additionalFragments)
        {
            if (additionalFragments == null) throw new ArgumentNullException("additionalFragments");

            string[] formatArgs = new string[additionalFragments.Length + 1];
            formatArgs[0] = this.SubscriptionId.ToString();

            if (additionalFragments.Length > 0)
            {
                additionalFragments.CopyTo(formatArgs, 1);
            }

            string formattedUri = string.Format(uriformat, formatArgs);
            Uri retUri = new Uri(this._wrappedClient.BaseAddress, formattedUri);

            return retUri;
        }
        #endregion

        private HttpClient _wrappedClient;
        private XmlMediaTypeFormatter _formatter;

        //this is the only supported algorithm
        private const string _sha1thumbprintAlgorithm = "sha1";

    }
}
