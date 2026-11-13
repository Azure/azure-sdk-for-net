// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    /// <summary>
    /// A class representing a collection of <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> and their operations.
    /// Each <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> in the collection will belong to the same instance of <see cref="PostgreSqlFlexibleServerResource"/>.
    /// To get a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection"/> instance call the GetPostgreSqlFlexibleServerActiveDirectoryAdministrators method from an instance of <see cref="PostgreSqlFlexibleServerResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is deprecated. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.")]
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection : ArmCollection, IEnumerable<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>, IAsyncEnumerable<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>
    {
        /// <summary> Initializes a new instance of the <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection"/> class for mocking. </summary>
        protected PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Creates a new server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="content"> The required parameters for adding an active directory administrator for a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> or <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string objectId, PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Creates a new server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Create</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="content"> The required parameters for adding an active directory administrator for a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> or <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> CreateOrUpdate(WaitUntil waitUntil, string objectId, PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Gets information about a server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public virtual async Task<Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetAsync(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Gets information about a server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public virtual Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Get(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// List all the AAD administrators for a given server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_ListByServer</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// List all the AAD administrators for a given server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_ListByServer</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetAll(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public virtual Response<bool> Exists(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public virtual async Task<NullableResponse<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetIfExistsAsync(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectId"> Guid of the objectId for the administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        public virtual NullableResponse<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetIfExists(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorCollection' class instead.");
        }

        IEnumerator<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> IEnumerable<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> IAsyncEnumerable<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
