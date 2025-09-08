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
    /// A Class representing a MySqlServerAdministrator along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier"/> you can construct a <see cref="MySqlServerAdministratorResource"/>
    /// from an instance of <see cref="ArmClient"/> using the GetMySqlServerAdministratorResource method.
    /// Otherwise you can get one from its parent resource <see cref="MySqlServerResource"/> using the GetMySqlServerAdministrator method.
    /// </summary>
    public partial class MySqlServerAdministratorResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MySqlServerAdministratorResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="serverName"> The serverName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _mySqlServerAdministratorServerAdministratorsClientDiagnostics;
        private readonly ServerAdministratorsRestOperations _mySqlServerAdministratorServerAdministratorsRestClient;
        private readonly MySqlServerAdministratorData _data;

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.DBforMySQL/servers/administrators";

        /// <summary> Initializes a new instance of the <see cref="MySqlServerAdministratorResource"/> class for mocking. </summary>
        protected MySqlServerAdministratorResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MySqlServerAdministratorResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal MySqlServerAdministratorResource(ArmClient client, MySqlServerAdministratorData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="MySqlServerAdministratorResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MySqlServerAdministratorResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _mySqlServerAdministratorServerAdministratorsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MySql", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string mySqlServerAdministratorServerAdministratorsApiVersion);
            _mySqlServerAdministratorServerAdministratorsRestClient = new ServerAdministratorsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, mySqlServerAdministratorServerAdministratorsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual MySqlServerAdministratorData Data
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
        /// Gets information about a AAD server administrator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerAdministrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MySqlServerAdministratorResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _mySqlServerAdministratorServerAdministratorsClientDiagnostics.CreateScope("MySqlServerAdministratorResource.Get");
            scope.Start();
            try
            {
                var response = await _mySqlServerAdministratorServerAdministratorsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MySqlServerAdministratorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets information about a AAD server administrator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerAdministrators_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MySqlServerAdministratorResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _mySqlServerAdministratorServerAdministratorsClientDiagnostics.CreateScope("MySqlServerAdministratorResource.Get");
            scope.Start();
            try
            {
                var response = _mySqlServerAdministratorServerAdministratorsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MySqlServerAdministratorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes server active directory administrator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerAdministrators_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _mySqlServerAdministratorServerAdministratorsClientDiagnostics.CreateScope("MySqlServerAdministratorResource.Delete");
            scope.Start();
            try
            {
                var response = await _mySqlServerAdministratorServerAdministratorsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken).ConfigureAwait(false);
                var operation = new MySqlArmOperation(_mySqlServerAdministratorServerAdministratorsClientDiagnostics, Pipeline, _mySqlServerAdministratorServerAdministratorsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes server active directory administrator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerAdministrators_Delete</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _mySqlServerAdministratorServerAdministratorsClientDiagnostics.CreateScope("MySqlServerAdministratorResource.Delete");
            scope.Start();
            try
            {
                var response = _mySqlServerAdministratorServerAdministratorsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, cancellationToken);
                var operation = new MySqlArmOperation(_mySqlServerAdministratorServerAdministratorsClientDiagnostics, Pipeline, _mySqlServerAdministratorServerAdministratorsRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or update active directory administrator on an existing server. The update action will overwrite the existing administrator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerAdministrators_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The required parameters for creating or updating an AAD server administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MySqlServerAdministratorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, MySqlServerAdministratorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mySqlServerAdministratorServerAdministratorsClientDiagnostics.CreateScope("MySqlServerAdministratorResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _mySqlServerAdministratorServerAdministratorsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MySqlArmOperation<MySqlServerAdministratorResource>(new MySqlServerAdministratorOperationSource(Client), _mySqlServerAdministratorServerAdministratorsClientDiagnostics, Pipeline, _mySqlServerAdministratorServerAdministratorsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or update active directory administrator on an existing server. The update action will overwrite the existing administrator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBforMySQL/servers/{serverName}/administrators/activeDirectory</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ServerAdministrators_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2017-12-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MySqlServerAdministratorResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The required parameters for creating or updating an AAD server administrator. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MySqlServerAdministratorResource> CreateOrUpdate(WaitUntil waitUntil, MySqlServerAdministratorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _mySqlServerAdministratorServerAdministratorsClientDiagnostics.CreateScope("MySqlServerAdministratorResource.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _mySqlServerAdministratorServerAdministratorsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data, cancellationToken);
                var operation = new MySqlArmOperation<MySqlServerAdministratorResource>(new MySqlServerAdministratorOperationSource(Client), _mySqlServerAdministratorServerAdministratorsClientDiagnostics, Pipeline, _mySqlServerAdministratorServerAdministratorsRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, data).Request, response, OperationFinalStateVia.Location);
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