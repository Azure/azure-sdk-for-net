// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.HDInsight.Models;

namespace Microsoft.Azure.Management.HDInsight
{
    internal partial class ClusterOperations : IClusterOperations
    {
        /// <summary>
        /// Enables RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='rdpUsername'>
        /// Required. The RDP username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<OperationResource> EnableRdpAsync(string resourceGroupName,
            string clusterName, string rdpUsername, string rdpPassword,
            DateTime rdpExpiryDate, CancellationToken cancellationToken)
        {
            try
            {
                var rdpParams = GetRdpParametersForEnable(rdpUsername, rdpPassword, rdpExpiryDate);
                return await ConfigureRdpSettingsAsync(resourceGroupName, clusterName, rdpParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begins enabling RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='rdpUsername'>
        /// Required. The RDP username.
        /// </param>
        /// <param name='rdpPassword'>
        /// Required. The RDP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<HDInsightOperationResponse> BeginEnablingRdpAsync(string resourceGroupName, string clusterName,
            string rdpUsername, string rdpPassword,
            DateTime rdpExpiryDate, CancellationToken cancellationToken)
        {
            try
            {
                var rdpParams = GetRdpParametersForEnable(rdpUsername, rdpPassword, rdpExpiryDate);
                return
                    await BeginConfiguringRdpSettingsAsync(resourceGroupName, clusterName, rdpParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Disables RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<OperationResource> DisableRdpAsync(string resourceGroupName, string clusterName, CancellationToken cancellationToken)
        {
            try
            {
                var rdpParams = GetRdpParametersForDisable();
                return await ConfigureRdpSettingsAsync(resourceGroupName, clusterName, rdpParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begins disabling RDP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<HDInsightOperationResponse> BeginDisablingRdpAsync(string resourceGroupName, string clusterName, CancellationToken cancellationToken)
        {
            try
            {
                var rdpParams = GetRdpParametersForDisable();
                return
                    await BeginConfiguringRdpSettingsAsync(resourceGroupName, clusterName, rdpParams, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        private static RDPSettingsParameters GetRdpParametersForEnable(string rdpUsername, string rdpPassword,
            DateTime rdpExpiryDate)
        {
            return new RDPSettingsParameters
            {
                OsProfile = new OsProfile
                {
                    WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                    {
                        RdpSettings = new RdpSettings
                        {
                            UserName = rdpUsername,
                            Password = rdpPassword,
                            ExpiryDate = rdpExpiryDate
                        }
                    }
                }
            };
        }

        private static RDPSettingsParameters GetRdpParametersForDisable()
        {
            return new RDPSettingsParameters
            {
                OsProfile = new OsProfile
                {
                    WindowsOperatingSystemProfile = new WindowsOperatingSystemProfile
                    {
                        RdpSettings = null
                    }
                }
            };
        }
    }
}
