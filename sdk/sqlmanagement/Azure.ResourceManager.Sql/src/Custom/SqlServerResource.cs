// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A Class representing a SqlServer along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SqlServerResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSqlServerResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetSqlServer method.
    /// </summary>
    public partial class SqlServerResource : ArmResource
    {
        /// <summary>
        /// Gets a recoverable database, which is a resource representing a database's geo backup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<RecoverableDatabaseResource>> GetRecoverableDatabaseAsync(string databaseName, CancellationToken cancellationToken)
            => await GetRecoverableDatabaseAsync(databaseName, null, null, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Gets a recoverable database, which is a resource representing a database's geo backup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/recoverableDatabases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RecoverableDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RecoverableDatabaseResource> GetRecoverableDatabase(string databaseName, CancellationToken cancellationToken)
            => GetRecoverableDatabase(databaseName, null, null, cancellationToken);

        /// <summary>
        /// Gets a restorable dropped database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RestorableDroppedDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="restorableDroppedDatabaseId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="restorableDroppedDatabaseId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="restorableDroppedDatabaseId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<RestorableDroppedDatabaseResource>> GetRestorableDroppedDatabaseAsync(string restorableDroppedDatabaseId, CancellationToken cancellationToken = default)
        {
            return await GetRestorableDroppedDatabases().GetAsync(restorableDroppedDatabaseId, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a restorable dropped database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/restorableDroppedDatabases/{restorableDroppedDatabaseId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>RestorableDroppedDatabases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="restorableDroppedDatabaseId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="restorableDroppedDatabaseId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="restorableDroppedDatabaseId"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<RestorableDroppedDatabaseResource> GetRestorableDroppedDatabase(string restorableDroppedDatabaseId, CancellationToken cancellationToken)
        {
            return GetRestorableDroppedDatabases().Get(restorableDroppedDatabaseId, null, null, cancellationToken);
        }

        /// <summary>
        /// Gets a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SqlDatabaseResource>> GetSqlDatabaseAsync(string databaseName, CancellationToken cancellationToken)
        {
            return await GetSqlDatabases().GetAsync(databaseName, null, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a database.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Databases_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SqlDatabaseResource> GetSqlDatabase(string databaseName, CancellationToken cancellationToken)
        {
            return GetSqlDatabases().Get(databaseName, null, null, cancellationToken);
        }

        /// <summary> Gets a collection of ServiceObjectiveResources in the SqlServer. </summary>
        /// <returns> An object representing collection of ServiceObjectiveResources and their operations over a ServiceObjectiveResource. </returns>
        public virtual ServiceObjectiveCollection GetServiceObjectives()
        {
            return GetCachedClient(client => new ServiceObjectiveCollection(client, Id));
        }

        /// <summary>
        /// Gets a database service objective.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives/{serviceObjectiveName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServiceObjectives_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceObjectiveResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ServiceObjectiveResource>> GetServiceObjectiveAsync(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            return await GetServiceObjectives().GetAsync(serviceObjectiveName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a database service objective.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/serviceObjectives/{serviceObjectiveName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServiceObjectives_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ServiceObjectiveResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="serviceObjectiveName"> The name of the service objective to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serviceObjectiveName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="serviceObjectiveName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ServiceObjectiveResource> GetServiceObjective(string serviceObjectiveName, CancellationToken cancellationToken = default)
        {
            return GetServiceObjectives().Get(serviceObjectiveName, cancellationToken);
        }

        /// <summary> Gets a collection of SqlServerCommunicationLinkResources in the SqlServer. </summary>
        /// <returns> An object representing collection of SqlServerCommunicationLinkResources and their operations over a SqlServerCommunicationLinkResource. </returns>
        public virtual SqlServerCommunicationLinkCollection GetSqlServerCommunicationLinks()
        {
            return GetCachedClient(client => new SqlServerCommunicationLinkCollection(client, Id));
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
        /// <description>2023-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SqlServerCommunicationLinkResource>> GetSqlServerCommunicationLinkAsync(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            return await GetSqlServerCommunicationLinks().GetAsync(communicationLinkName, cancellationToken).ConfigureAwait(false);
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
        /// <description>2023-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="SqlServerCommunicationLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="communicationLinkName"> The name of the server communication link. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="communicationLinkName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="communicationLinkName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<SqlServerCommunicationLinkResource> GetSqlServerCommunicationLink(string communicationLinkName, CancellationToken cancellationToken = default)
        {
            return GetSqlServerCommunicationLinks().Get(communicationLinkName, cancellationToken);
        }
    }
}
