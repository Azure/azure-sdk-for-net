// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PlatformValidation
{
    public partial class ValidationTestCategoryCollection
    {
        /// <summary>
        /// Get a validation test category catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories/{validationTestCategoryName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestCategoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestCategoryName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ValidationTestCategoryResource>> GetAsync(string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestCategoryName, nameof(validationTestCategoryName));

            using DiagnosticScope scope = _validationTestCategoriesClientDiagnostics.CreateScope("ValidationTestCategoryCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestCategoriesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestCategoryName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ValidationTestCategoryData> response = Response.FromValue(ValidationTestCategoryData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestCategoryResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a validation test category catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories/{validationTestCategoryName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestCategoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestCategoryName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ValidationTestCategoryResource> Get(string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestCategoryName, nameof(validationTestCategoryName));

            using DiagnosticScope scope = _validationTestCategoriesClientDiagnostics.CreateScope("ValidationTestCategoryCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestCategoriesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestCategoryName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ValidationTestCategoryData> response = Response.FromValue(ValidationTestCategoryData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestCategoryResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List validation test category catalog entries for a subscription
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_ListBySubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter expression used to constrain the returned items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ValidationTestCategoryResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ValidationTestCategoryResource> GetAllAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ValidationTestCategoryData, ValidationTestCategoryResource>(new ValidationTestCategoryDataAsyncCollectionResultOfT(_validationTestCategoriesRestClient, Guid.Parse(Id.SubscriptionId), filter, context, "ValidationTestCategoryCollection.GetAll"), data => new ValidationTestCategoryResource(Client, data, Id.SubscriptionId));
        }

        /// <summary>
        /// List validation test category catalog entries for a subscription
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_ListBySubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter expression used to constrain the returned items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ValidationTestCategoryResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ValidationTestCategoryResource> GetAll(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ValidationTestCategoryData, ValidationTestCategoryResource>(new ValidationTestCategoryDataCollectionResultOfT(_validationTestCategoriesRestClient, Guid.Parse(Id.SubscriptionId), filter, context, "ValidationTestCategoryCollection.GetAll"), data => new ValidationTestCategoryResource(Client, data, Id.SubscriptionId));
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories/{validationTestCategoryName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestCategoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestCategoryName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<ValidationTestCategoryResource>> GetIfExistsAsync(string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestCategoryName, nameof(validationTestCategoryName));

            using DiagnosticScope scope = _validationTestCategoriesClientDiagnostics.CreateScope("ValidationTestCategoryCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestCategoriesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestCategoryName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ValidationTestCategoryData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ValidationTestCategoryData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ValidationTestCategoryData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ValidationTestCategoryResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestCategoryResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories/{validationTestCategoryName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestCategoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestCategoryName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ValidationTestCategoryResource> GetIfExists(string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestCategoryName, nameof(validationTestCategoryName));

            using DiagnosticScope scope = _validationTestCategoriesClientDiagnostics.CreateScope("ValidationTestCategoryCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestCategoriesRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestCategoryName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ValidationTestCategoryData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ValidationTestCategoryData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ValidationTestCategoryData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ValidationTestCategoryResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestCategoryResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
