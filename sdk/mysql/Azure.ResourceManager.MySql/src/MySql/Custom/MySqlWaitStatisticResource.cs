// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.MySql
{
    /// <summary>
    /// A Class representing a MySqlWaitStatistic along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MySqlWaitStatisticResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetMySqlWaitStatisticResource method.
    /// Otherwise you can get one from its parent resource <see cref="MySqlServerResource"/> using the GetMySqlWaitStatistic method.
    /// </summary>
    public partial class MySqlWaitStatisticResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MySqlWaitStatisticResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="serverName"> The serverName. </param>
        /// <param name="waitStatisticsId"> The waitStatisticsId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string waitStatisticsId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/waitStatistics/{waitStatisticsId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _mySqlWaitStatisticWaitStatisticsClientDiagnostics;
        private readonly WaitStatisticsRestOperations _mySqlWaitStatisticWaitStatisticsRestClient;
        private readonly MySqlWaitStatisticData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DBforMySQL/servers/waitStatistics";

        /// <summary> Initializes a new instance of the <see cref="MySqlWaitStatisticResource"/> class for mocking. </summary>
        protected MySqlWaitStatisticResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MySqlWaitStatisticResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal MySqlWaitStatisticResource(ArmClient client, MySqlWaitStatisticData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="MySqlWaitStatisticResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MySqlWaitStatisticResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mySqlWaitStatisticWaitStatisticsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MySql", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string mySqlWaitStatisticWaitStatisticsApiVersion);
            _mySqlWaitStatisticWaitStatisticsRestClient = new WaitStatisticsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mySqlWaitStatisticWaitStatisticsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual MySqlWaitStatisticData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Retrieve wait statistics for specified identifier.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/waitStatistics/{waitStatisticsId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WaitStatistics_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlWaitStatisticResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MySqlWaitStatisticResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _mySqlWaitStatisticWaitStatisticsClientDiagnostics.CreateScope("MySqlWaitStatisticResource.Get");
            scope.Start();
            try
            {
                var response = await _mySqlWaitStatisticWaitStatisticsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MySqlWaitStatisticResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieve wait statistics for specified identifier.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/waitStatistics/{waitStatisticsId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>WaitStatistics_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlWaitStatisticResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MySqlWaitStatisticResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _mySqlWaitStatisticWaitStatisticsClientDiagnostics.CreateScope("MySqlWaitStatisticResource.Get");
            scope.Start();
            try
            {
                var response = _mySqlWaitStatisticWaitStatisticsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MySqlWaitStatisticResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}