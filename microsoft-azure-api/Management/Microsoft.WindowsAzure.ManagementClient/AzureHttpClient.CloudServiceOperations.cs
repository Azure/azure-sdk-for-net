//-----------------------------------------------------------------------
// <copyright file="AzureHttpClient.CloudServiceOperations.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CloudService operations of AzureHttpClient class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    public partial class AzureHttpClient
    {
        /// <summary>
        /// Begins an asychronous operation to list the cloud services in the subscription.
        /// </summary>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="CloudServiceCollection"/></returns>
        public Task<CloudServiceCollection> ListCloudServicesAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.HostedServices));

            return StartGetTask<CloudServiceCollection>(message, token);
        }

        /// <summary>
        /// Begins and asynchronous operation to create a <see cref="CloudService"/>.
        /// </summary>
        /// <param name="name">A name for the hosted service that is unique within Windows Azure. This name is the DNS prefix name and can be used to access the cloud service. For example: http://ServiceName.cloudapp.net/ Required.</param>
        /// <param name="label">The label for the service, may be up to 100 characters in length. Required.</param>
        /// <param name="description">A description for the service. May be up to 1024 characters in length. Optional, may be null.</param>
        /// <param name="location">A location for the service. Valid values are returned from <see cref="AzureHttpClient.ListLocationsAsync"/>. Either location or affinity group is required, but not both.</param>
        /// <param name="affinityGroup">The name of an existing affinity group associated with this subscription. Valid values are returned from <see cref="ListAffinityGroupsAsync"/>. Either location or affinity group is required, but not both.</param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the service.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing CreateCloudServiceAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> CreateCloudServiceAsync(string name, string label, string description, string location, string affinityGroup, IDictionary<string, string> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            CreateCloudServiceInfo createInfo = CreateCloudServiceInfo.Create(name, label, description, location, affinityGroup, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.HostedServices), createInfo);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to update the properties of a cloud service.
        /// </summary>
        /// <param name="serviceName">The name of the service to be updated. Required.</param>
        /// <param name="label">The label for the service, may be up to 100 characters in length. Optional, may be null.</param>
        /// <param name="description">A description for the service. May be up to 1024 characters in length. Optional, may be null.</param>
        /// <param name="location">A location for the service. Valid values are returned from <see cref="AzureHttpClient.ListLocationsAsync"/>. Either location or affinity group may be set, but not both.</param>
        /// <param name="affinityGroup">The name of an existing affinity group associated with this subscription. Valid values are returned from <see cref="ListAffinityGroupsAsync"/>. Either location or affinity group may be set, but not both.</param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the service.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing UpdateCloudServiceAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// While all parameters except the <paramref name="serviceName"/> are optional, at least one must be set to perform an update.
        /// </remarks>
        public Task<string> UpdateCloudServiceAsync(string serviceName, string label, string description, string location, string affinityGroup, IDictionary<string, string> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(serviceName, "name");

            //this validates the other args
            UpdateCloudServiceInfo updateInfo = UpdateCloudServiceInfo.Create(label, description, location, affinityGroup, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Put, CreateTargetUri(UriFormatStrings.HostedServicesAndService, serviceName), updateInfo);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to delete a cloud service.
        /// </summary>
        /// <param name="name">The name of the service to be deleted. Required.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing DeleteCloudServiceAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> DeleteCloudServiceAsync(string name, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(name, "name");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.HostedServicesAndService, name));

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to get cloud service properties.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service whose properties are to be retrieved.</param>
        /// <param name="includeDeployments">Set to true to include deployment information. Default value is false.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="CloudService"/></returns>
        public Task<CloudService> GetCloudServicePropertiesAsync(string cloudServiceName, bool includeDeployments = false, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            HttpRequestMessage message;
            if (includeDeployments)
            {
                message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.GetHostedServicePropertiesEmbedDetail, cloudServiceName));
            }
            else
            {
                message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.HostedServicesAndService, cloudServiceName));
            }

            return StartGetTask<CloudService>(message, token);
        }


        /// <summary>
        /// Begins an asychronous operation to create a deployment within a <see cref="CloudService"/>.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service in which this deployment will be created. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> in which this deployment will be created.</param>
        /// <param name="name">The name of the deployment. The deployment name must be unique among other deployments for the hosted service. Required.</param>
        /// <param name="packageUrl">The <see cref="Uri"/> representing the location of the azure deployment package (.cspkg) to be deployed.
        /// The service package can be located either in a storage account beneath the same subscription or a Shared Access Signature (SAS) URI from any storage account. 
        /// For more info about Shared Access Signatures, see <see href="http://msdn.microsoft.com/en-us/library/windowsazure/ee395415">Using a Shared Access Signature (REST API)</see>. Required.
        /// </param>
        /// <param name="label">The label for the deployment, may be up to 100 characters in length. Required.</param>
        /// <param name="configFilePath">The local file path to the Azure deployment configuration file (.cscfg) defining the deployment. Required.</param>
        /// <param name="startDeployment">Set to true to automatically start the deployment. Default is false. If false, once deployment is complete, 
        /// the deployment will remain in <see cref="DeploymentStatus.Suspended" /> state until you call <see cref="StartDeploymentAsync"/>. </param>
        /// <param name="treatWarningsAsError">Set to true to treat package validation warnings as errors and fail the deployment. Default is false.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the service.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>CreateDeploymentAsync is a long-running asynchronous operation. When the Task representing CreateDeploymentAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the CreateDeploymentAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> CreateDeploymentAsync(string cloudServiceName, DeploymentSlot slot, string name, Uri packageUrl, string label,
                                                  string configFilePath, bool startDeployment = false,
                                                  bool treatWarningsAsError = false, IDictionary<string, string> extendedProperties = null,
                                                  CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            //this validates the other parameters...
            CreateDeploymentInfo info = CreateDeploymentInfo.Create(name, packageUrl, label, configFilePath, startDeployment, treatWarningsAsError, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlot, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);

        }

        /// <summary>
        /// Begins an asychronous operation to get properties for a deployment.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="Deployment"/>.</returns>
        public Task<Deployment> GetDeploymentAsync(string cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.DeploymentSlot, cloudServiceName, slot.ToString()));

            return StartGetTask<Deployment>(message, token);
        }

        //the purpose of a VipSwap is to promote a "staging" deployment to production. So, the production slot
        //may be empty, but the staging slot may not. You cannot vip swap production to staging, without replacing
        //the production slot with something, but you can vip swap staging to a previously empty production
        /// <summary>
        /// Begins an asychronous operation to do a Virtual IP (Vip) swap within a cloud service.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service within which to perform the vip swap.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <remarks>The purpose of a vip swap is to promote a deployment in the <see cref="DeploymentSlot.Staging"/> slot to the
        /// <see cref="DeploymentSlot.Production"/> slot. Therefore the Staging slot of the deployment must not be empty or the operation will
        /// fail. At the end of the long-running operation, what started in the Staging slot will be in the Production slot. If the Production
        /// slot had a deployment, it will be moved to the Staging slot.</remarks>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>VipSwapAsync is a long-running asynchronous operation. When the Task representing VipSwapAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the VipSwapAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> VipSwapAsync(string cloudServiceName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            return GetCloudServicePropertiesAsync(cloudServiceName, true, token)
                   .ContinueWith<string>((propTask) =>
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

        /// <summary>
        /// Begins an asychronous operation to delete a deployment.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment to be deleted. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment to be deleted.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>DeleteDeploymentAsync is a long-running asynchronous operation. When the Task representing DeleteDeploymentAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the DeleteDeploymentAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> DeleteDeploymentAsync(string cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.DeploymentSlot, cloudServiceName, slot.ToString()));

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to change the configuration of a deployment.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment with the configuration to be changed. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment with the configuration to be changed.</param>
        /// <param name="configFilePath">The local file path to the Azure deployment configuration file (.cscfg) defining the deployment. Required.</param>
        /// <param name="treatWarningsAsError">Set to true to treat configuation warnings as errors and fail the configuration change. Default is false.</param>
        /// <param name="mode">The <see cref="UpgradeType"/> value indicating whether the configuation change should happen automatically (<see cref="UpgradeType.Auto"/> or
        /// manually (<see cref="UpgradeType.Manual"/>. If set to <see cref="UpgradeType.Manual"/>, you must subsequently call <see cref="WalkUpgradeDomainAsync"/> to
        /// control the configuration change across the deployment.</param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the deployment.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>ChangeDeploymentConfigurationAsync is a long-running asynchronous operation. When the Task representing ChangeDeploymentConfigurationAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the ChangeDeploymentConfigurationAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> ChangeDeploymentConfigurationAsync(string cloudServiceName, DeploymentSlot slot, string configFilePath, bool treatWarningsAsError = false, UpgradeType mode = UpgradeType.Auto, IDictionary<string, string> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            //this validates the other parameters...
            ChangeDeploymentConfigurationInfo info = ChangeDeploymentConfigurationInfo.Create(configFilePath, treatWarningsAsError, mode, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotChangeConfig, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to start a suspended deployment.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment to be started. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment to be started.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>StartDeploymentAsync is a long-running asynchronous operation. When the Task representing StartDeploymentAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the StartDeploymentAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> StartDeploymentAsync(string cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            UpdateDeploymentStatusInfo info = UpdateDeploymentStatusInfo.Create(true);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotUpdateStatus, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to stop a running deployment.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment to be stopped. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment to be stopped.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>StopDeploymentAsync is a long-running asynchronous operation. When the Task representing StopDeploymentAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the StopDeploymentAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> StopDeploymentAsync(string cloudServiceName, DeploymentSlot slot, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            UpdateDeploymentStatusInfo info = UpdateDeploymentStatusInfo.Create(false);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotUpdateStatus, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to upgrade a deployment.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment to be upgraded. Required.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment to be upgraded.</param>
        /// <param name="mode">The <see cref="UpgradeType"/> value indicating whether the ugrade should happen automatically (<see cref="UpgradeType.Auto"/> or
        /// manually (<see cref="UpgradeType.Manual"/>. If set to <see cref="UpgradeType.Manual"/>, you must subsequently call <see cref="WalkUpgradeDomainAsync"/> to
        /// control the upgrade across the deployment.</param>
        /// <param name="packageUrl">The <see cref="Uri"/> representing the location of the azure deployment package (.cspkg) to be deployed.
        /// The service package can be located either in a storage account beneath the same subscription or a Shared Access Signature (SAS) URI from any storage account. 
        /// For more info about Shared Access Signatures, see <see href="http://msdn.microsoft.com/en-us/library/windowsazure/ee395415">Using a Shared Access Signature (REST API)</see>. Required.
        /// </param>
        /// <param name="configFilePath">The local file path to the Azure deployment configuration file (.cscfg) defining the deployment. Required.</param>
        /// <param name="label">The label for the deployment, may be up to 100 characters in length. Required.</param>
        /// <param name="roleToUpgrade">The name of a specific role to upgrade. Optional.</param>
        /// <param name="treatWarningsAsError">Specifies whether to treat package validation warnings as errors and fail the upgrade. Default is false.</param>
        /// <param name="force">Specifies whether the upgrade should proceed even when it will cause local data to be lost from some role instances. Default is false.</param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the service.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>UpgradeDeploymentAsync is a long-running asynchronous operation. When the Task representing UpgradeDeploymentAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the UpgradeDeploymentAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> UpgradeDeploymentAsync(string cloudServiceName, DeploymentSlot slot, UpgradeType mode, Uri packageUrl, string configFilePath, string label, string roleToUpgrade = null, bool treatWarningsAsError = false, bool force = false, IDictionary<string, string> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            //this validates the other parameters...
            UpgradeDeploymentInfo info = UpgradeDeploymentInfo.Create(mode, packageUrl, configFilePath, label, roleToUpgrade, treatWarningsAsError, force, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotUpgrade, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to upgrade a particular domain in a manual deployment upgrade or configuration change.
        /// </summary>
        /// <param name="cloudServiceName">The name of the cloud service which contains the deployment to upgrade.</param>
        /// <param name="slot">The <see cref="DeploymentSlot"/> which contains the deployment to upgrade.</param>
        /// <param name="upgradeDomain">In integer representing the particular upgrade domain to upgrade.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>WalkUpgradeDomainAsync is a long-running asynchronous operation. When the Task representing WalkUpgradeDomainAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the WalkUpgradeDomainAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> WalkUpgradeDomainAsync(string cloudServiceName, DeploymentSlot slot, int upgradeDomain, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStringArg(cloudServiceName, "cloudServiceName");

            WalkUpgradeDomainInfo info = WalkUpgradeDomainInfo.Create(upgradeDomain);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.DeploymentSlotWalkUpgradeDomain, cloudServiceName, slot.ToString()), info);

            return StartSendTask(message, token);
        }

        //TODO: Reboot Role Instance
        //TODO: Reimage Role Instance
        //TODO: Rollback Update or Upgrade
    }
}
