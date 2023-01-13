// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityInsights.Models;

[assembly: CodeGenSuppressType("SecurityInsightsIncidentResource")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A Class representing a SecurityInsightsIncident along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SecurityInsightsIncidentResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSecurityInsightsIncidentResource method.
    /// Otherwise you can get one from its parent resource <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" /> using the GetSecurityInsightsIncident method.
    /// </summary>
    public partial class SecurityInsightsIncidentResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SecurityInsightsIncidentResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string incidentId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _securityInsightsIncidentIncidentsClientDiagnostics;
        private readonly IncidentsRestOperations _securityInsightsIncidentIncidentsRestClient;
        private readonly SecurityInsightsIncidentData _data;

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsIncidentResource"/> class for mocking. </summary>
        protected SecurityInsightsIncidentResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SecurityInsightsIncidentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SecurityInsightsIncidentResource(ArmClient client, SecurityInsightsIncidentData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsIncidentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SecurityInsightsIncidentResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityInsightsIncidentIncidentsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string securityInsightsIncidentIncidentsApiVersion);
            _securityInsightsIncidentIncidentsRestClient = new IncidentsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityInsightsIncidentIncidentsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.SecurityInsights/incidents";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual SecurityInsightsIncidentData Data
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

        /// <summary> Gets a collection of SecurityInsightsIncidentCommentResources in the SecurityInsightsIncident. </summary>
        /// <returns> An object representing collection of SecurityInsightsIncidentCommentResources and their operations over a SecurityInsightsIncidentCommentResource. </returns>
        public virtual SecurityInsightsIncidentCommentCollection GetSecurityInsightsIncidentComments()
        {
            return GetCachedClient(Client => new SecurityInsightsIncidentCommentCollection(Client, Id));
        }

        /// <summary>
        /// Gets a comment for a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/comments/{incidentCommentId}
        /// Operation Id: IncidentComments_Get
        /// </summary>
        /// <param name="incidentCommentId"> Incident comment ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="incidentCommentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="incidentCommentId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsIncidentCommentResource>> GetSecurityInsightsIncidentCommentAsync(string incidentCommentId, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsIncidentComments().GetAsync(incidentCommentId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a comment for a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/comments/{incidentCommentId}
        /// Operation Id: IncidentComments_Get
        /// </summary>
        /// <param name="incidentCommentId"> Incident comment ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="incidentCommentId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="incidentCommentId"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsIncidentCommentResource> GetSecurityInsightsIncidentComment(string incidentCommentId, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsIncidentComments().Get(incidentCommentId, cancellationToken);
        }

        /// <summary> Gets a collection of SecurityInsightsIncidentRelationResources in the SecurityInsightsIncident. </summary>
        /// <returns> An object representing collection of SecurityInsightsIncidentRelationResources and their operations over a SecurityInsightsIncidentRelationResource. </returns>
        public virtual SecurityInsightsIncidentRelationCollection GetSecurityInsightsIncidentRelations()
        {
            return GetCachedClient(Client => new SecurityInsightsIncidentRelationCollection(Client, Id));
        }

        /// <summary>
        /// Gets a relation for a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/relations/{relationName}
        /// Operation Id: IncidentRelations_Get
        /// </summary>
        /// <param name="relationName"> Relation Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="relationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="relationName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<SecurityInsightsIncidentRelationResource>> GetSecurityInsightsIncidentRelationAsync(string relationName, CancellationToken cancellationToken = default)
        {
            return await GetSecurityInsightsIncidentRelations().GetAsync(relationName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a relation for a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/relations/{relationName}
        /// Operation Id: IncidentRelations_Get
        /// </summary>
        /// <param name="relationName"> Relation Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="relationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="relationName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<SecurityInsightsIncidentRelationResource> GetSecurityInsightsIncidentRelation(string relationName, CancellationToken cancellationToken = default)
        {
            return GetSecurityInsightsIncidentRelations().Get(relationName, cancellationToken);
        }

        /// <summary>
        /// Gets a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityInsightsIncidentResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.Get");
            scope.Start();
            try
            {
                var response = await _securityInsightsIncidentIncidentsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsIncidentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityInsightsIncidentResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.Get");
            scope.Start();
            try
            {
                var response = _securityInsightsIncidentIncidentsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsIncidentResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.Delete");
            scope.Start();
            try
            {
                var response = await _securityInsightsIncidentIncidentsRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation(response);
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
        /// Deletes a given incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_Delete
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.Delete");
            scope.Start();
            try
            {
                var response = _securityInsightsIncidentIncidentsRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SecurityInsightsArmOperation(response);
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
        /// Creates or updates an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The incident. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityInsightsIncidentResource>> UpdateAsync(WaitUntil waitUntil, SecurityInsightsIncidentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.Update");
            scope.Start();
            try
            {
                var response = await _securityInsightsIncidentIncidentsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsIncidentResource>(Response.FromValue(new SecurityInsightsIncidentResource(Client, response), response.GetRawResponse()));
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
        /// Creates or updates an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}
        /// Operation Id: Incidents_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The incident. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityInsightsIncidentResource> Update(WaitUntil waitUntil, SecurityInsightsIncidentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.Update");
            scope.Start();
            try
            {
                var response = _securityInsightsIncidentIncidentsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsIncidentResource>(Response.FromValue(new SecurityInsightsIncidentResource(Client, response), response.GetRawResponse()));
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
        /// Gets all alerts for an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/alerts
        /// Operation Id: Incidents_ListAlerts
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityInsightsAlert" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsAlert> GetAlertsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityInsightsAlert>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.GetAlerts");
                scope.Start();
                try
                {
                    var response = await _securityInsightsIncidentIncidentsRestClient.ListAlertsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets all alerts for an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/alerts
        /// Operation Id: Incidents_ListAlerts
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityInsightsAlert" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsAlert> GetAlerts(CancellationToken cancellationToken = default)
        {
            Page<SecurityInsightsAlert> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.GetAlerts");
                scope.Start();
                try
                {
                    var response = _securityInsightsIncidentIncidentsRestClient.ListAlerts(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets all bookmarks for an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/bookmarks
        /// Operation Id: Incidents_ListBookmarks
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityInsightsHuntingBookmark" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsHuntingBookmark> GetBookmarksAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityInsightsHuntingBookmark>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.GetBookmarks");
                scope.Start();
                try
                {
                    var response = await _securityInsightsIncidentIncidentsRestClient.ListBookmarksAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets all bookmarks for an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/bookmarks
        /// Operation Id: Incidents_ListBookmarks
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityInsightsHuntingBookmark" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsHuntingBookmark> GetBookmarks(CancellationToken cancellationToken = default)
        {
            Page<SecurityInsightsHuntingBookmark> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.GetBookmarks");
                scope.Start();
                try
                {
                    var response = _securityInsightsIncidentIncidentsRestClient.ListBookmarks(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets all entities for an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/entities
        /// Operation Id: Incidents_ListEntities
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityInsightsIncidentEntitiesResult>> GetEntitiesResultAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.GetEntitiesResult");
            scope.Start();
            try
            {
                var response = await _securityInsightsIncidentIncidentsRestClient.ListEntitiesAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all entities for an incident.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/incidents/{incidentId}/entities
        /// Operation Id: Incidents_ListEntities
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityInsightsIncidentEntitiesResult> GetEntitiesResult(CancellationToken cancellationToken = default)
        {
            using var scope = _securityInsightsIncidentIncidentsClientDiagnostics.CreateScope("SecurityInsightsIncidentResource.GetEntitiesResult");
            scope.Start();
            try
            {
                var response = _securityInsightsIncidentIncidentsRestClient.ListEntities(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
