// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Backward-compatibility customization for the Swagger-to-TypeSpec migration.
    //
    // Background: why the generated Collection only takes 1 parameter
    //
    // In the old Swagger SDK (v1.1.3), MaintenanceApplyUpdateCollection.Get/Exists/GetIfExists
    // took 4 explicit parameters: (providerName, resourceType, resourceName, applyUpdateName).
    // This was because the Swagger generator exposed every URL path segment as a method parameter.
    //
    // REST API path (ApplyUpdates_Get — without parent, 5-segment scope):
    //   GET /subscriptions/{sub}/resourceGroups/{rg}/providers/{providerName}/{resourceType}/{resourceName}
    //       /providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
    //
    // In the TypeSpec migration, ApplyUpdate.tsp defines the resource using
    // Legacy.ExtensionOperations with OverrideResourceName="MaintenanceApplyUpdate". The TypeSpec MPG
    // generator encodes (providerName, resourceType, resourceName) into the parent ResourceIdentifier
    // rather than exposing them as method parameters. So the generated Collection methods only take
    // (applyUpdateName), deriving the other segments from Id.Parent.ResourceType.Namespace, etc.
    //
    // However, the 7-segment by-parent path variant (ApplyUpdates_GetParent) is what the generated
    // MaintenanceApplyUpdateResource/Collection actually binds to:
    //   GET /subscriptions/{sub}/resourceGroups/{rg}/providers/{providerName}/{resourceParentType}/{resourceParentName}
    //       /{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
    //
    // What this custom code does:
    //
    // 1. [CodeGenType("ApplyUpdateCollection")] — renames the generated "ApplyUpdateCollection" class
    //    to "MaintenanceApplyUpdateCollection", matching the old Swagger SDK naming convention.
    //    Without this, the generated class name would not have the "Maintenance" prefix.
    //
    // 2. Provides backward-compatible 4-parameter overloads for Get, Exists, and GetIfExists
    //    (both sync and async), preserving the old v1.1.3 public API surface. These overloads
    //    bypass the generated code and call the REST client directly with explicit path parameters,
    //    because the generated methods have scope segments encoded in the ResourceIdentifier,
    //    not as separate method parameters.
    //
    // 3. The custom methods call _maintenanceApplyUpdateRestClient.CreateGetRequest (the 5-segment,
    //    without-parent REST endpoint — ApplyUpdateOperationGroup_Get) instead of
    //    CreateGetApplyUpdatesByParentRequest (the 7-segment by-parent endpoint), because the old
    //    v1.1.3 API used the without-parent path and only had (providerName, resourceType,
    //    resourceName, applyUpdateName) — no resourceParentType/resourceParentName.
    //
    // Relationship to ApplyUpdate.tsp:
    //
    // ApplyUpdate.tsp defines two @armResourceOperations interfaces:
    //   - ApplyUpdateOps (7-param by-parent) → MaintenanceApplyUpdate* classes (with parent segments)
    //   - ApplyUpdateOperationGroupOps (5-param) → MaintenanceApplyUpdateOperationGroup* classes (without parent)
    //
    // back-compatible.tsp moves ApplyUpdateOperationGroup ops via @@clientLocation to the ApplyUpdates
    // interface, so they appear on the same client. But the generated Resource/Collection types remain
    // split. The custom 4-param overloads here allow existing callers who had:
    //     collection.Get(providerName, resourceType, resourceName, applyUpdateName)
    // to keep working, even though internally this now calls the 5-segment path through the REST client.
    [CodeGenType("ApplyUpdateCollection")]
    public partial class MaintenanceApplyUpdateCollection
    {
        /// <summary> Track maintenance updates to resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<MaintenanceApplyUpdateResource>> GetAsync(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = _maintenanceApplyUpdateClientDiagnostics.CreateScope("MaintenanceApplyUpdateCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _maintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<MaintenanceApplyUpdateResource> Get(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = _maintenanceApplyUpdateClientDiagnostics.CreateScope("MaintenanceApplyUpdateCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _maintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceApplyUpdateData> response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = _maintenanceApplyUpdateClientDiagnostics.CreateScope("MaintenanceApplyUpdateCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _maintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<MaintenanceApplyUpdateData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceApplyUpdateData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = _maintenanceApplyUpdateClientDiagnostics.CreateScope("MaintenanceApplyUpdateCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _maintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<MaintenanceApplyUpdateData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceApplyUpdateData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<MaintenanceApplyUpdateResource>> GetIfExistsAsync(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = _maintenanceApplyUpdateClientDiagnostics.CreateScope("MaintenanceApplyUpdateCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _maintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<MaintenanceApplyUpdateData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceApplyUpdateData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<MaintenanceApplyUpdateResource>(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> The name of the ApplyUpdate. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<MaintenanceApplyUpdateResource> GetIfExists(string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            using DiagnosticScope scope = _maintenanceApplyUpdateClientDiagnostics.CreateScope("MaintenanceApplyUpdateCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _maintenanceApplyUpdateRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, providerName, resourceType, resourceName, applyUpdateName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<MaintenanceApplyUpdateData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceApplyUpdateData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceApplyUpdateData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<MaintenanceApplyUpdateResource>(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenanceApplyUpdateResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
