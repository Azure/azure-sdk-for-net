// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MySql.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    public partial class MockableMySqlResourceGroupResource : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="MockableMySqlResourceGroupResource"/> class for mocking. </summary>
        protected MockableMySqlResourceGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockableMySqlResourceGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableMySqlResourceGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of MySqlServerResources in the ResourceGroupResource. </summary>
        /// <returns> An object representing collection of MySqlServerResources and their operations over a MySqlServerResource. </returns>
        public virtual MySqlServerCollection GetMySqlServers()
        {
            return GetCachedClient(client => new MySqlServerCollection(client, Id));
        }

        /// <summary>
        /// Gets information about a server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Servers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serverName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="serverName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<MySqlServerResource>> GetMySqlServerAsync(string serverName, CancellationToken cancellationToken = default)
        {
            return await GetMySqlServers().GetAsync(serverName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets information about a server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Servers_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serverName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="serverName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<MySqlServerResource> GetMySqlServer(string serverName, CancellationToken cancellationToken = default)
        {
            return GetMySqlServers().Get(serverName, cancellationToken);
        }
    }
}