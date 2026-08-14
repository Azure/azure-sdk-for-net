// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerResource : ArmResource
    {
        /// <summary> Gets a collection of PostgreSqlFlexibleServerActiveDirectoryAdministratorResources in the PostgreSqlFlexibleServer. </summary>
        /// <returns> An object representing collection of PostgreSqlFlexibleServerActiveDirectoryAdministratorResources and their operations over a PostgreSqlFlexibleServerActiveDirectoryAdministratorResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrators' instead.")]
        public virtual PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection GetPostgreSqlFlexibleServerActiveDirectoryAdministrators()
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorCollection is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrators' instead.");
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
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrator' instead.")]
        [ForwardsClientCalls]
        public virtual Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> GetPostgreSqlFlexibleServerActiveDirectoryAdministrator(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministrator' instead.");
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
        /// <exception cref="ArgumentNullException"> <paramref name="objectId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="objectId"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is deprecated. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorAsync' instead.")]
        [ForwardsClientCalls]
        public virtual async Task<Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetPostgreSqlFlexibleServerActiveDirectoryAdministratorAsync(string objectId, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'GetPostgreSqlFlexibleServerMicrosoftEntraAdministratorAsync' instead.");
        }
    }
}
