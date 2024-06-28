// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary>
    /// A class representing a collection of <see cref="MySqlFlexibleServerResource"/> and their operations.
    /// Each <see cref="MySqlFlexibleServerResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="MySqlFlexibleServerCollection"/> instance call the GetMySqlFlexibleServers method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class MySqlFlexibleServerCollection : ArmCollection, IEnumerable<MySqlFlexibleServerResource>, IAsyncEnumerable<MySqlFlexibleServerResource>
    {
        /// <summary>
        /// Creates a new server or updates an existing server. The update action will overwrite the existing server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Servers_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlFlexibleServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="data"> The required parameters for creating or updating a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serverName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serverName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MySqlFlexibleServerResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string serverName, MySqlFlexibleServerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serverName, nameof(serverName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mySqlFlexibleServerServersClientDiagnostics.CreateScope("MySqlFlexibleServerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mySqlFlexibleServerServersRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, serverName, data, cancellationToken).ConfigureAwait(false);
                var operation = new FlexibleServersArmOperation2<MySqlFlexibleServerResource>(new MySqlFlexibleServerOperationSource(Client), _mySqlFlexibleServerServersClientDiagnostics, Pipeline, _mySqlFlexibleServerServersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, serverName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates a new server or updates an existing server. The update action will overwrite the existing server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/flexibleServers/{serverName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Servers_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-12-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlFlexibleServerResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="data"> The required parameters for creating or updating a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="serverName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="serverName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MySqlFlexibleServerResource> CreateOrUpdate(WaitUntil waitUntil, string serverName, MySqlFlexibleServerData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serverName, nameof(serverName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mySqlFlexibleServerServersClientDiagnostics.CreateScope("MySqlFlexibleServerCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mySqlFlexibleServerServersRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, serverName, data, cancellationToken);
                var operation = new FlexibleServersArmOperation2<MySqlFlexibleServerResource>(new MySqlFlexibleServerOperationSource(Client), _mySqlFlexibleServerServersClientDiagnostics, Pipeline, _mySqlFlexibleServerServersRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, serverName, data).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
