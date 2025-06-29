// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

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

namespace Azure.ResourceManager.OracleDatabase
{
    /// <summary>
    /// A class representing a collection of <see cref="AutonomousDatabaseBackupResource"/> and their operations.
    /// Each <see cref="AutonomousDatabaseBackupResource"/> in the collection will belong to the same instance of <see cref="AutonomousDatabaseResource"/>.
    /// To get an <see cref="AutonomousDatabaseBackupCollection"/> instance call the GetAutonomousDatabaseBackups method from an instance of <see cref="AutonomousDatabaseResource"/>.
    /// </summary>
    public partial class AutonomousDatabaseBackupCollection : ArmCollection, IEnumerable<AutonomousDatabaseBackupResource>, IAsyncEnumerable<AutonomousDatabaseBackupResource>
    {
        private readonly ClientDiagnostics _autonomousDatabaseBackupClientDiagnostics;
        private readonly AutonomousDatabaseBackupsRestOperations _autonomousDatabaseBackupRestClient;

        /// <summary> Initializes a new instance of the <see cref="AutonomousDatabaseBackupCollection"/> class for mocking. </summary>
        protected AutonomousDatabaseBackupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AutonomousDatabaseBackupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AutonomousDatabaseBackupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _autonomousDatabaseBackupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.OracleDatabase", AutonomousDatabaseBackupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AutonomousDatabaseBackupResource.ResourceType, out string autonomousDatabaseBackupApiVersion);
            _autonomousDatabaseBackupRestClient = new AutonomousDatabaseBackupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, autonomousDatabaseBackupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AutonomousDatabaseResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AutonomousDatabaseResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create a AutonomousDatabaseBackup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AutonomousDatabaseBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string adbbackupid, AutonomousDatabaseBackupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _autonomousDatabaseBackupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, data, cancellationToken).ConfigureAwait(false);
                var operation = new OracleDatabaseArmOperation<AutonomousDatabaseBackupResource>(new AutonomousDatabaseBackupOperationSource(Client), _autonomousDatabaseBackupClientDiagnostics, Pipeline, _autonomousDatabaseBackupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Create a AutonomousDatabaseBackup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="data"> Resource create parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AutonomousDatabaseBackupResource> CreateOrUpdate(WaitUntil waitUntil, string adbbackupid, AutonomousDatabaseBackupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _autonomousDatabaseBackupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, data, cancellationToken);
                var operation = new OracleDatabaseArmOperation<AutonomousDatabaseBackupResource>(new AutonomousDatabaseBackupOperationSource(Client), _autonomousDatabaseBackupClientDiagnostics, Pipeline, _autonomousDatabaseBackupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, data).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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

        /// <summary>
        /// Get a AutonomousDatabaseBackup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> is null. </exception>
        public virtual async Task<Response<AutonomousDatabaseBackupResource>> GetAsync(string adbbackupid, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.Get");
            scope.Start();
            try
            {
                var response = await _autonomousDatabaseBackupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AutonomousDatabaseBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a AutonomousDatabaseBackup
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> is null. </exception>
        public virtual Response<AutonomousDatabaseBackupResource> Get(string adbbackupid, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.Get");
            scope.Start();
            try
            {
                var response = _autonomousDatabaseBackupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new AutonomousDatabaseBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List AutonomousDatabaseBackup resources by AutonomousDatabase
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_ListByParent</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AutonomousDatabaseBackupResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AutonomousDatabaseBackupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _autonomousDatabaseBackupRestClient.CreateListByParentRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _autonomousDatabaseBackupRestClient.CreateListByParentNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new AutonomousDatabaseBackupResource(Client, AutonomousDatabaseBackupData.DeserializeAutonomousDatabaseBackupData(e)), _autonomousDatabaseBackupClientDiagnostics, Pipeline, "AutonomousDatabaseBackupCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List AutonomousDatabaseBackup resources by AutonomousDatabase
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_ListByParent</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AutonomousDatabaseBackupResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AutonomousDatabaseBackupResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _autonomousDatabaseBackupRestClient.CreateListByParentRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _autonomousDatabaseBackupRestClient.CreateListByParentNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new AutonomousDatabaseBackupResource(Client, AutonomousDatabaseBackupData.DeserializeAutonomousDatabaseBackupData(e)), _autonomousDatabaseBackupClientDiagnostics, Pipeline, "AutonomousDatabaseBackupCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string adbbackupid, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.Exists");
            scope.Start();
            try
            {
                var response = await _autonomousDatabaseBackupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> is null. </exception>
        public virtual Response<bool> Exists(string adbbackupid, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.Exists");
            scope.Start();
            try
            {
                var response = _autonomousDatabaseBackupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> is null. </exception>
        public virtual async Task<NullableResponse<AutonomousDatabaseBackupResource>> GetIfExistsAsync(string adbbackupid, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _autonomousDatabaseBackupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<AutonomousDatabaseBackupResource>(response.GetRawResponse());
                return Response.FromValue(new AutonomousDatabaseBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Oracle.Database/autonomousDatabases/{autonomousdatabasename}/autonomousDatabaseBackups/{adbbackupid}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AutonomousDatabaseBackup_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2025-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AutonomousDatabaseBackupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="adbbackupid"> AutonomousDatabaseBackup id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="adbbackupid"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="adbbackupid"/> is null. </exception>
        public virtual NullableResponse<AutonomousDatabaseBackupResource> GetIfExists(string adbbackupid, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(adbbackupid, nameof(adbbackupid));

            using var scope = _autonomousDatabaseBackupClientDiagnostics.CreateScope("AutonomousDatabaseBackupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _autonomousDatabaseBackupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, adbbackupid, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<AutonomousDatabaseBackupResource>(response.GetRawResponse());
                return Response.FromValue(new AutonomousDatabaseBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AutonomousDatabaseBackupResource> IEnumerable<AutonomousDatabaseBackupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AutonomousDatabaseBackupResource> IAsyncEnumerable<AutonomousDatabaseBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
