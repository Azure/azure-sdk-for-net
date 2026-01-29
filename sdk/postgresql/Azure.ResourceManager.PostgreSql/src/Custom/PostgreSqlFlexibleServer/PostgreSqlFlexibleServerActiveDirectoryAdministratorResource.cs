// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    /// <summary>
    /// A Class representing a PostgreSqlFlexibleServerActiveDirectoryAdministrator along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetPostgreSqlFlexibleServerActiveDirectoryAdministratorResource method.
    /// Otherwise you can get one from its parent resource <see cref="PostgreSqlFlexibleServerResource"/> using the GetPostgreSqlFlexibleServerActiveDirectoryAdministrator method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is deprecated. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.")]
    public partial class PostgreSqlFlexibleServerActiveDirectoryAdministratorResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="serverName"> The serverName. </param>
        /// <param name="objectId"> The objectId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string objectId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _postgreSqlFlexibleServerActiveDirectoryAdministratorAdministratorsClientDiagnostics;
        private readonly AdministratorsMicrosoftEntraRestOperations _postgreSqlFlexibleServerActiveDirectoryAdministratorAdministratorsRestClient;
        private readonly PostgreSqlFlexibleServerActiveDirectoryAdministratorData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DBforPostgreSQL/flexibleServers/administrators";

        /// <summary> Initializes a new instance of the <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> class for mocking. </summary>
        protected PostgreSqlFlexibleServerActiveDirectoryAdministratorResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal PostgreSqlFlexibleServerActiveDirectoryAdministratorResource(ArmClient client, PostgreSqlFlexibleServerActiveDirectoryAdministratorData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="PostgreSqlFlexibleServerActiveDirectoryAdministratorResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal PostgreSqlFlexibleServerActiveDirectoryAdministratorResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _postgreSqlFlexibleServerActiveDirectoryAdministratorAdministratorsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PostgreSql.FlexibleServers", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string postgreSqlFlexibleServerActiveDirectoryAdministratorAdministratorsApiVersion);
            _postgreSqlFlexibleServerActiveDirectoryAdministratorAdministratorsRestClient = new AdministratorsMicrosoftEntraRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, postgreSqlFlexibleServerActiveDirectoryAdministratorAdministratorsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual PostgreSqlFlexibleServerActiveDirectoryAdministratorData Data
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.");
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Get(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.");
        }

        /// <summary>
        /// Deletes an Active Directory Administrator associated with the server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Delete</description>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.");
        }

        /// <summary>
        /// Deletes an Active Directory Administrator associated with the server.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforPostgreSQL/flexibleServers/{serverName}/administrators/{objectId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Administrators_Delete</description>
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
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.");
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
        /// <param name="content"> The required parameters for adding an active directory administrator for a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<ArmOperation<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource>> UpdateAsync(WaitUntil waitUntil, PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.");
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
        /// <param name="content"> The required parameters for adding an active directory administrator for a server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual ArmOperation<PostgreSqlFlexibleServerActiveDirectoryAdministratorResource> Update(WaitUntil waitUntil, PostgreSqlFlexibleServerActiveDirectoryAdministratorCreateOrUpdateContent content, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PostgreSqlFlexibleServerActiveDirectoryAdministratorResource is not supported any more. Please use the new 'PostgreSqlFlexibleServerMicrosoftEntraAdministratorResource' class instead.");
        }
    }
}
