// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    public partial class DataMaskingPolicyResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="DataMaskingPolicyResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="serverName"> The serverName. </param>
        /// <param name="databaseName"> The databaseName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataMaskingPolicies/Default";
            return new ResourceIdentifier(resourceId);
        }

        /// <summary>
        /// Creates or updates a database data masking policy
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataMaskingPolicies/{dataMaskingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataMaskingPolicies_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataMaskingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters for creating or updating a data masking policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DataMaskingPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, DataMaskingPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _dataMaskingPolicyClientDiagnostics.CreateScope("DataMaskingPolicyResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _dataMaskingPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, DataMaskingPolicyName.Default, data, cancellationToken).ConfigureAwait(false);
                var uri = _dataMaskingPolicyRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, DataMaskingPolicyName.Default, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new SqlArmOperation<DataMaskingPolicyResource>(Response.FromValue(new DataMaskingPolicyResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
        /// Creates or updates a database data masking policy
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataMaskingPolicies/{dataMaskingPolicyName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DataMaskingPolicies_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataMaskingPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters for creating or updating a data masking policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DataMaskingPolicyResource> CreateOrUpdate(WaitUntil waitUntil, DataMaskingPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _dataMaskingPolicyClientDiagnostics.CreateScope("DataMaskingPolicyResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _dataMaskingPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, DataMaskingPolicyName.Default, data, cancellationToken);
                var uri = _dataMaskingPolicyRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, DataMaskingPolicyName.Default, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new SqlArmOperation<DataMaskingPolicyResource>(Response.FromValue(new DataMaskingPolicyResource(Client, response), response.GetRawResponse()), rehydrationToken);
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
