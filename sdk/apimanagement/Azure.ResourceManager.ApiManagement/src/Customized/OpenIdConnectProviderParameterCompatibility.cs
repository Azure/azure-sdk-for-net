// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    [CodeGenSuppress("CreateOrUpdateAsync", typeof(WaitUntil), typeof(string), typeof(ApiManagementOpenIdConnectProviderData), typeof(ETag?), typeof(CancellationToken))]
    [CodeGenSuppress("CreateOrUpdate", typeof(WaitUntil), typeof(string), typeof(ApiManagementOpenIdConnectProviderData), typeof(ETag?), typeof(CancellationToken))]
    [CodeGenSuppress("GetAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Exists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(string), typeof(CancellationToken))]
    public partial class ApiManagementOpenIdConnectProviderCollection
    {
        /// <summary> Creates or updates the specified OpenID Connect Provider. </summary>
        public virtual async Task<ArmOperation<ApiManagementOpenIdConnectProviderResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string openId, ApiManagementOpenIdConnectProviderData data, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, ApiManagementOpenIdConnectProviderData.ToRequestContent(data), ifMatch, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ApiManagementOpenIdConnectProviderData> response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                ApiManagementArmOperation<ApiManagementOpenIdConnectProviderResource> operation = new ApiManagementArmOperation<ApiManagementOpenIdConnectProviderResource>(Response.FromValue(new ApiManagementOpenIdConnectProviderResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates or updates the specified OpenID Connect Provider. </summary>
        public virtual ArmOperation<ApiManagementOpenIdConnectProviderResource> CreateOrUpdate(WaitUntil waitUntil, string openId, ApiManagementOpenIdConnectProviderData data, ETag? ifMatch = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, ApiManagementOpenIdConnectProviderData.ToRequestContent(data), ifMatch, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ApiManagementOpenIdConnectProviderData> response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                ApiManagementArmOperation<ApiManagementOpenIdConnectProviderResource> operation = new ApiManagementArmOperation<ApiManagementOpenIdConnectProviderResource>(Response.FromValue(new ApiManagementOpenIdConnectProviderResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified OpenID Connect Provider. </summary>
        public virtual async Task<Response<ApiManagementOpenIdConnectProviderResource>> GetAsync(string openId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ApiManagementOpenIdConnectProviderData> response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ApiManagementOpenIdConnectProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the specified OpenID Connect Provider. </summary>
        public virtual Response<ApiManagementOpenIdConnectProviderResource> Get(string openId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ApiManagementOpenIdConnectProviderData> response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ApiManagementOpenIdConnectProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the specified OpenID Connect Provider exists in Azure. </summary>
        public virtual async Task<Response<bool>> ExistsAsync(string openId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ApiManagementOpenIdConnectProviderData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ApiManagementOpenIdConnectProviderData)null, result);
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

        /// <summary> Checks to see if the specified OpenID Connect Provider exists in Azure. </summary>
        public virtual Response<bool> Exists(string openId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ApiManagementOpenIdConnectProviderData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ApiManagementOpenIdConnectProviderData)null, result);
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

        /// <summary> Tries to get the specified OpenID Connect Provider, returning null if it does not exist. </summary>
        public virtual async Task<NullableResponse<ApiManagementOpenIdConnectProviderResource>> GetIfExistsAsync(string openId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ApiManagementOpenIdConnectProviderData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ApiManagementOpenIdConnectProviderData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ApiManagementOpenIdConnectProviderResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ApiManagementOpenIdConnectProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get the specified OpenID Connect Provider, returning null if it does not exist. </summary>
        public virtual NullableResponse<ApiManagementOpenIdConnectProviderResource> GetIfExists(string openId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(openId, nameof(openId));

            using DiagnosticScope scope = _openIdConnectProviderClientDiagnostics.CreateScope("ApiManagementOpenIdConnectProviderCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _openIdConnectProviderRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, openId, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ApiManagementOpenIdConnectProviderData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ApiManagementOpenIdConnectProviderData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ApiManagementOpenIdConnectProviderData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ApiManagementOpenIdConnectProviderResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ApiManagementOpenIdConnectProviderResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }

    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class ApiManagementOpenIdConnectProviderResource
    {
        /// <summary> Generate the resource identifier for this resource. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="serviceName"> The serviceName. </param>
        /// <param name="openId"> The openId. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serviceName, string openId)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/openidConnectProviders/{openId}";
            return new ResourceIdentifier(resourceId);
        }
    }

    [CodeGenSuppress("GetApiManagementOpenIdConnectProviderAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetApiManagementOpenIdConnectProvider", typeof(string), typeof(CancellationToken))]
    public partial class ApiManagementServiceResource
    {
        /// <summary> Gets the API Management OpenID Connect Provider. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<ApiManagementOpenIdConnectProviderResource>> GetApiManagementOpenIdConnectProviderAsync(string openId, CancellationToken cancellationToken = default)
            => await GetApiManagementOpenIdConnectProviders().GetAsync(openId, cancellationToken).ConfigureAwait(false);

        /// <summary> Gets the API Management OpenID Connect Provider. </summary>
        [ForwardsClientCalls]
        public virtual Response<ApiManagementOpenIdConnectProviderResource> GetApiManagementOpenIdConnectProvider(string openId, CancellationToken cancellationToken = default)
            => GetApiManagementOpenIdConnectProviders().Get(openId, cancellationToken);
    }
}
