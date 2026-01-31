// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Nginx.Models;

namespace Azure.ResourceManager.Nginx
{
    /// <summary>
    /// A class representing a NginxConfiguration along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="NginxConfigurationResource"/> from an instance of <see cref="ArmClient"/> using the GetResource method.
    /// Otherwise you can get one from its parent resource <see cref="NginxDeploymentResource"/> using the GetNginxConfigurations method.
    /// </summary>
    public partial class NginxConfigurationResource : ArmResource
    {
        /// <summary>
        /// Create or update the NGINX configuration for given NGINX deployment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Configurations_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The NGINX configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NginxConfigurationResource>> UpdateAsync(WaitUntil waitUntil, NginxConfigurationData data, CancellationToken cancellationToken = default)
            => await UpdateAsync(waitUntil,
                        new NginxConfigurationCreateOrUpdateContent(data.Id, data.Name, data.ResourceType,
                                new NginxConfigurationCreateOrUpdateProperties(data.Properties.ProvisioningState, data.Properties.Files,
                                        data.Properties.ProtectedFiles?.Select(file => new NginxConfigurationContentProtectedFile(null, file.VirtualPath, file.ContentHash, null)).ToList(),
                                        data.Properties.Package, data.Properties.RootFile, null),
                                data.SystemData, null),
                        cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Create or update the NGINX configuration for given NGINX deployment
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Nginx.NginxPlus/nginxDeployments/{deploymentName}/configurations/{configurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Configurations_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The NGINX configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NginxConfigurationResource> Update(WaitUntil waitUntil, NginxConfigurationData data, CancellationToken cancellationToken = default)
            => Update(waitUntil,
                    new NginxConfigurationCreateOrUpdateContent(data.Id, data.Name, data.ResourceType,
                            new NginxConfigurationCreateOrUpdateProperties(data.Properties.ProvisioningState, data.Properties.Files,
                                    data.Properties.ProtectedFiles?.Select(file => new NginxConfigurationContentProtectedFile(null, file.VirtualPath, file.ContentHash, null)).ToList(),
                                    data.Properties.Package, data.Properties.RootFile, null),
                            data.SystemData, null),
                    cancellationToken);
    }
}
