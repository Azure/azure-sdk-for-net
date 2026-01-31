// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Nginx.Models;

namespace Azure.ResourceManager.Nginx
{
    /// <summary>
    /// A class representing a collection of <see cref="NginxConfigurationResource"/> and their operations.
    /// Each <see cref="NginxConfigurationResource"/> in the collection will belong to the same instance of <see cref="NginxDeploymentResource"/>.
    /// To get a <see cref="NginxConfigurationCollection"/> instance call the GetNginxConfigurations method from an instance of <see cref="NginxDeploymentResource"/>.
    /// </summary>
    public partial class NginxConfigurationCollection : ArmCollection, IEnumerable<NginxConfigurationResource>, IAsyncEnumerable<NginxConfigurationResource>
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
        /// <param name="configurationName"> The name of configuration, only 'default' is supported value due to the singleton of NGINX conf. </param>
        /// <param name="data"> The NGINX configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NginxConfigurationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string configurationName, NginxConfigurationData data, CancellationToken cancellationToken = default)
            => await CreateOrUpdateAsync(waitUntil, configurationName,
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
        /// <param name="configurationName"> The name of configuration, only 'default' is supported value due to the singleton of NGINX conf. </param>
        /// <param name="data"> The NGINX configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NginxConfigurationResource> CreateOrUpdate(WaitUntil waitUntil, string configurationName, NginxConfigurationData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, configurationName,
                    new NginxConfigurationCreateOrUpdateContent(data.Id, data.Name, data.ResourceType,
                            new NginxConfigurationCreateOrUpdateProperties(data.Properties.ProvisioningState, data.Properties.Files,
                                    data.Properties.ProtectedFiles?.Select(file => new NginxConfigurationContentProtectedFile(null, file.VirtualPath, file.ContentHash, null)).ToList(),
                                    data.Properties.Package, data.Properties.RootFile, null),
                            data.SystemData, null),
                    cancellationToken);
    }
}
