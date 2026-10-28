// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PlatformValidation
{
    public partial class ValidationTestVersionCollection
    {
        /// <summary>
        /// Get a validation test version catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}/versions/{version}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestVersions_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="version"> The name of the ValidationTestVersion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ValidationTestVersionResource>> GetAsync(string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _validationTestVersionsClientDiagnostics.CreateScope("ValidationTestVersionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, version, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ValidationTestVersionData> response = Response.FromValue(ValidationTestVersionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestVersionResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a validation test version catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}/versions/{version}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestVersions_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="version"> The name of the ValidationTestVersion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ValidationTestVersionResource> Get(string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _validationTestVersionsClientDiagnostics.CreateScope("ValidationTestVersionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, version, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ValidationTestVersionData> response = Response.FromValue(ValidationTestVersionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestVersionResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List validation test version catalog entries
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}/versions. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestVersions_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter expression used to constrain the returned items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ValidationTestVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ValidationTestVersionResource> GetAllAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ValidationTestVersionData, ValidationTestVersionResource>(new ValidationTestVersionDataAsyncCollectionResultOfT(
                _validationTestVersionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.Name,
                filter,
                context,
                "ValidationTestVersionCollection.GetAll"), data => new ValidationTestVersionResource(Client, data, Id.SubscriptionId));
        }

        /// <summary>
        /// List validation test version catalog entries
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}/versions. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestVersions_List. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter expression used to constrain the returned items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ValidationTestVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ValidationTestVersionResource> GetAll(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ValidationTestVersionData, ValidationTestVersionResource>(new ValidationTestVersionDataCollectionResultOfT(
                _validationTestVersionsRestClient,
                Guid.Parse(Id.SubscriptionId),
                Id.Name,
                filter,
                context,
                "ValidationTestVersionCollection.GetAll"), data => new ValidationTestVersionResource(Client, data, Id.SubscriptionId));
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}/versions/{version}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestVersions_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="version"> The name of the ValidationTestVersion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<ValidationTestVersionResource>> GetIfExistsAsync(string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _validationTestVersionsClientDiagnostics.CreateScope("ValidationTestVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, version, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ValidationTestVersionData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ValidationTestVersionData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ValidationTestVersionData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ValidationTestVersionResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestVersionResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
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
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}/versions/{version}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestVersions_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="version"> The name of the ValidationTestVersion. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="version"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="version"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ValidationTestVersionResource> GetIfExists(string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _validationTestVersionsClientDiagnostics.CreateScope("ValidationTestVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestVersionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, version, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ValidationTestVersionData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ValidationTestVersionData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ValidationTestVersionData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ValidationTestVersionResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestVersionResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
