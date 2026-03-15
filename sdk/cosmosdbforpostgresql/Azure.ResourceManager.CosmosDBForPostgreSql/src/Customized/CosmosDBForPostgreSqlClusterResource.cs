// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    [CodeGenSuppress("GetConfigurations")]
    [CodeGenSuppress("GetConfigurationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetConfiguration", typeof(string), typeof(CancellationToken))]
    public partial class CosmosDBForPostgreSqlClusterResource
    {
        /// <summary> Gets a collection of Configurations in the <see cref="CosmosDBForPostgreSqlClusterResource"/>. </summary>
        /// <returns> An object representing collection of Configurations and their operations over a ConfigurationResource. </returns>
        public virtual ConfigurationCollection GetConfigurations()
        {
            return this.GetCachedClient(client => new ConfigurationCollection(client, Id));
        }

        /// <summary> Gets information of a configuration for coordinator/worker nodes. </summary>
        /// <param name="configurationName"> The name of the cluster configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<ConfigurationResource>> GetConfigurationAsync(string configurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationName, nameof(configurationName));
            return await this.GetConfigurations().GetAsync(configurationName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets information of a configuration for coordinator/worker nodes. </summary>
        /// <param name="configurationName"> The name of the cluster configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<ConfigurationResource> GetConfiguration(string configurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(configurationName, nameof(configurationName));
            return this.GetConfigurations().Get(configurationName, cancellationToken);
        }
    }
}
