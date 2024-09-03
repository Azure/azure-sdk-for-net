// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.MachineLearning.Models;

namespace Azure.ResourceManager.MachineLearning
{
    /// <summary>
    /// A Class representing a MachineLearningDatastore along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MachineLearningDatastoreResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetMachineLearningDatastoreResource method.
    /// Otherwise you can get one from its parent resource <see cref="MachineLearningWorkspaceResource"/> using the GetMachineLearningDatastore method.
    /// </summary>
    public partial class MachineLearningDatastoreResource : ArmResource
    {
        /// <summary>
        /// Get datastore secrets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/datastores/{name}/listSecrets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Datastores_ListSecrets</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MachineLearningDatastoreResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MachineLearningDatastoreSecrets>> GetSecretsAsync(CancellationToken cancellationToken = default)
        {
            var response = await GetSecretsAsync(null, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Get datastore secrets.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MachineLearningServices/workspaces/{workspaceName}/datastores/{name}/listSecrets</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Datastores_ListSecrets</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-07-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MachineLearningDatastoreResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MachineLearningDatastoreSecrets> GetSecrets(CancellationToken cancellationToken = default) => GetSecrets(null, cancellationToken);
    }
}
