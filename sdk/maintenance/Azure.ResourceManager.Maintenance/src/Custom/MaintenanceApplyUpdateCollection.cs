// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Maintenance
{
    // Backward-compat overloads: old API had Get/Exists/GetIfExists with (providerName, resourceType,
    // resourceName, applyUpdateName) parameters. Generated code only has (applyUpdateName).
    // The @@clientName in spec handles the rename; no [CodeGenType] needed.
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
