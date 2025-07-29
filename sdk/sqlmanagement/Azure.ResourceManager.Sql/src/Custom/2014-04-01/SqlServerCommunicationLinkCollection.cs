// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="SqlServerCommunicationLinkResource"/> and their operations.
    /// Each <see cref="SqlServerCommunicationLinkResource"/> in the collection will belong to the same instance of <see cref="SqlServerResource"/>.
    /// To get a <see cref="SqlServerCommunicationLinkCollection"/> instance call the GetSqlServerCommunicationLinks method from an instance of <see cref="SqlServerResource"/>.
    /// </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class SqlServerCommunicationLinkCollection : ArmCollection, IEnumerable<SqlServerCommunicationLinkResource>, IAsyncEnumerable<SqlServerCommunicationLinkResource>
    {
        /// <summary>
        /// Creates a server communication link.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="data"> The required parameters for creating a server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> or <paramref name="data"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<SqlServerCommunicationLinkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string communicationLinkName, SqlServerCommunicationLinkData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates a server communication link.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="data"> The required parameters for creating a server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> or <paramref name="data"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<SqlServerCommunicationLinkResource> CreateOrUpdate(WaitUntil waitUntil, string communicationLinkName, SqlServerCommunicationLinkData data, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns a server communication link.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<SqlServerCommunicationLinkResource>> GetAsync(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns a server communication link.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlServerCommunicationLinkResource> Get(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a list of server communication links.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_ListByServer</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlServerCommunicationLinkResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<SqlServerCommunicationLinkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a list of server communication links.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_ListByServer</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlServerCommunicationLinkResource"/> that may take multiple service requests to iterate over. </returns>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<SqlServerCommunicationLinkResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<bool>> ExistsAsync(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<NullableResponse<SqlServerCommunicationLinkResource>> GetIfExistsAsync(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/communicationLinks/{communicationLinkName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerCommunicationLinks_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2014-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        [Obsolete("This method is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<SqlServerCommunicationLinkResource> GetIfExists(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException();
        }

        IEnumerator<SqlServerCommunicationLinkResource> IEnumerable<SqlServerCommunicationLinkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SqlServerCommunicationLinkResource> IAsyncEnumerable<SqlServerCommunicationLinkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
