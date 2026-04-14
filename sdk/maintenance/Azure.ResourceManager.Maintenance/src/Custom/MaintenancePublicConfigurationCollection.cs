// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Maintenance
{
    // A backward-compatibility wrapper representing a collection of public maintenance configuration resources.
    // In the old (autorest-generated) SDK, this was a separate collection type for subscription-level
    // read-only access to public maintenance configurations. In the new TypeSpec SDK, these operations
    // are merged into <see cref="MaintenanceConfigurationCollection"/>.
    public partial class MaintenancePublicConfigurationCollection : ArmCollection, IAsyncEnumerable<MaintenancePublicConfigurationResource>, IEnumerable<MaintenancePublicConfigurationResource>
    {
        private readonly ClientDiagnostics _publicMaintenanceConfigurationsClientDiagnostics;
        private readonly PublicMaintenanceConfigurations _publicMaintenanceConfigurationsRestClient;

        /// <summary> Initializes a new instance of MaintenancePublicConfigurationCollection for mocking. </summary>
        protected MaintenancePublicConfigurationCollection()
        {
        }

        internal MaintenancePublicConfigurationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _publicMaintenanceConfigurationsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Maintenance", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _publicMaintenanceConfigurationsRestClient = new PublicMaintenanceConfigurations(_publicMaintenanceConfigurationsClientDiagnostics, Pipeline, Endpoint, "2023-10-01-preview");
        }

        /// <summary> Gets the public maintenance configuration with the specified name. </summary>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<MaintenancePublicConfigurationResource>> GetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), resourceName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationData> response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenancePublicConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the public maintenance configuration with the specified name. </summary>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<MaintenancePublicConfigurationResource> Get(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), resourceName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationData> response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenancePublicConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets all public maintenance configurations in the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<MaintenancePublicConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            AsyncPageable<MaintenanceConfigurationData> source = new PublicMaintenanceConfigurationsGetAllAsyncCollectionResultOfT(
                _publicMaintenanceConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                context,
                "MaintenancePublicConfigurationCollection.GetAll");
            return new AsyncPageableWrapper<MaintenanceConfigurationData, MaintenancePublicConfigurationResource>(
                source,
                data => new MaintenancePublicConfigurationResource(Client, data));
        }

        /// <summary> Gets all public maintenance configurations in the subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<MaintenancePublicConfigurationResource> GetAll(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            Pageable<MaintenanceConfigurationData> source = new PublicMaintenanceConfigurationsGetAllCollectionResultOfT(
                _publicMaintenanceConfigurationsRestClient,
                Guid.Parse(Id.SubscriptionId),
                context,
                "MaintenancePublicConfigurationCollection.GetAll");
            return new PageableWrapper<MaintenanceConfigurationData, MaintenancePublicConfigurationResource>(
                source,
                data => new MaintenancePublicConfigurationResource(Client, data));
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), resourceName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<MaintenanceConfigurationData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceConfigurationData)null, result);
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
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<bool> Exists(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), resourceName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<MaintenanceConfigurationData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceConfigurationData)null, result);
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
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<MaintenancePublicConfigurationResource>> GetIfExistsAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), resourceName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<MaintenanceConfigurationData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceConfigurationData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<MaintenancePublicConfigurationResource>(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenancePublicConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<MaintenancePublicConfigurationResource> GetIfExists(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using DiagnosticScope scope = _publicMaintenanceConfigurationsClientDiagnostics.CreateScope("MaintenancePublicConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _publicMaintenanceConfigurationsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), resourceName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<MaintenanceConfigurationData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((MaintenanceConfigurationData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<MaintenancePublicConfigurationResource>(response.GetRawResponse());
                }
                return Response.FromValue(new MaintenancePublicConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IAsyncEnumerator<MaintenancePublicConfigurationResource> IAsyncEnumerable<MaintenancePublicConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken).GetAsyncEnumerator(cancellationToken);
        }

        IEnumerator<MaintenancePublicConfigurationResource> IEnumerable<MaintenancePublicConfigurationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }
    }
}
