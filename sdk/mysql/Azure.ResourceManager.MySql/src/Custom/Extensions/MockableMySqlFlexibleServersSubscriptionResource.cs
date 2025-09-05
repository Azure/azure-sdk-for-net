// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.MySql.FlexibleServers.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers.Mocking
{
    /// <summary> A class to add extension methods to SubscriptionResource. </summary>
    public partial class MockableMySqlFlexibleServersSubscriptionResource : ArmResource
    {
        /// <summary>
        /// Get the operation result for a long running operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/operationResults/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OperationResults_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="operationId"> The operation Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<Response<OperationStatusExtendedResult>> GetOperationResultAsync(AzureLocation locationName, string operationId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Get the operation result for a long running operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/operationResults/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OperationResults_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="locationName"> The name of the location. </param>
        /// <param name="operationId"> The operation Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        public virtual Response<OperationStatusExtendedResult> GetOperationResult(AzureLocation locationName, string operationId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }
    }
}
