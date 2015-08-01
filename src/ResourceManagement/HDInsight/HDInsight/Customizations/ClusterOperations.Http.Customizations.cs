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
        /// Enables HTTP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='username'>
        /// Required. The HTTP username.
        /// </param>
        /// <param name='password'>
        /// Required. The HTTP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<HDInsightLongRunningOperationResponse> EnableHttpAsync(string resourceGroupName, string clusterName,
            string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                var settings = GetEnableParameters(username, password);
                return await ConfigureHttpSettingsAsync(resourceGroupName, clusterName, settings, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begin enabling HTTP on the specified cluster.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required. The name of the resource group.
        /// </param>
        /// <param name='clusterName'>
        /// Required. The name of the cluster.
        /// </param>
        /// <param name='username'>
        /// Required. The HTTP username.
        /// </param>
        /// <param name='password'>
        /// Required. The HTTP password.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The cluster long running operation response.
        /// </returns>
        public async Task<HDInsightOperationResponse> BeginEnablingHttpAsync(string resourceGroupName, string clusterName,
            string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                var settings = GetEnableParameters(username, password);
                return await BeginConfiguringHttpSettingsAsync(resourceGroupName, clusterName, settings, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Disables HTTP on the specified cluster.
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
        public async Task<HDInsightLongRunningOperationResponse> DisableHttpAsync(string resourceGroupName, string clusterName, CancellationToken cancellationToken)
        {
            try
            {
                var settings = GetDisableParameters();
                return await ConfigureHttpSettingsAsync(resourceGroupName, clusterName, settings, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        /// <summary>
        /// Begin disabling HTTP on the specified cluster.
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
        public async Task<HDInsightOperationResponse> BeginDisablingHttpAsync(string resourceGroupName, string clusterName, CancellationToken cancellationToken)
        {
            try
            {
                var settings = GetDisableParameters();
                return await BeginConfiguringHttpSettingsAsync(resourceGroupName, clusterName, settings, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new CloudException(ex.Message);
            }
        }

        private static HttpSettingsParameters GetDisableParameters()
        {
            return new HttpSettingsParameters {HttpUserEnabled = false};
        }

        private static HttpSettingsParameters GetEnableParameters(string username, string password)
        {
            return new HttpSettingsParameters
            {
                HttpUserEnabled = true,
                HttpUsername = username,
                HttpPassword = password
            };
        }
    }
}
