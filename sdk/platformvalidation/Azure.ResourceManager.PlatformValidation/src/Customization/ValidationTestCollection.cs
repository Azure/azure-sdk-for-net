// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PlatformValidation
{
    public partial class ValidationTestCollection
    {
        /// <summary>
        /// Get a validation test catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ValidationTestResource>> GetAsync(string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestName, nameof(validationTestName));

            using DiagnosticScope scope = _validationTestsClientDiagnostics.CreateScope("ValidationTestCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ValidationTestData> response = Response.FromValue(ValidationTestData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a validation test catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ValidationTestResource> Get(string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestName, nameof(validationTestName));

            using DiagnosticScope scope = _validationTestsClientDiagnostics.CreateScope("ValidationTestCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ValidationTestData> response = Response.FromValue(ValidationTestData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List validation test catalog entries for a subscription
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_ListBySubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter expression used to constrain the returned items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ValidationTestResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ValidationTestResource> GetAllAsync(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<ValidationTestData, ValidationTestResource>(new ValidationTestDataAsyncCollectionResultOfT(_validationTestsRestClient, Guid.Parse(Id.SubscriptionId), filter, context, "ValidationTestCollection.GetAll"), data => new ValidationTestResource(Client, data, Id.SubscriptionId));
        }

        /// <summary>
        /// List validation test catalog entries for a subscription
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_ListBySubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> Filter expression used to constrain the returned items. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ValidationTestResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ValidationTestResource> GetAll(string filter = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<ValidationTestData, ValidationTestResource>(new ValidationTestDataCollectionResultOfT(_validationTestsRestClient, Guid.Parse(Id.SubscriptionId), filter, context, "ValidationTestCollection.GetAll"), data => new ValidationTestResource(Client, data, Id.SubscriptionId));
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<NullableResponse<ValidationTestResource>> GetIfExistsAsync(string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestName, nameof(validationTestName));

            using DiagnosticScope scope = _validationTestsClientDiagnostics.CreateScope("ValidationTestCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestName, context);
                await Pipeline.SendAsync(message, context.CancellationToken).ConfigureAwait(false);
                Response result = message.Response;
                Response<ValidationTestData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ValidationTestData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ValidationTestData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ValidationTestResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
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
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestName"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual NullableResponse<ValidationTestResource> GetIfExists(string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestName, nameof(validationTestName));

            using DiagnosticScope scope = _validationTestsClientDiagnostics.CreateScope("ValidationTestCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), validationTestName, context);
                Pipeline.Send(message, context.CancellationToken);
                Response result = message.Response;
                Response<ValidationTestData> response = default;
                switch (result.Status)
                {
                    case 200:
                        response = Response.FromValue(ValidationTestData.FromResponse(result), result);
                        break;
                    case 404:
                        response = Response.FromValue((ValidationTestData)null, result);
                        break;
                    default:
                        throw new RequestFailedException(result);
                }
                if (response.Value == null)
                {
                    return new NoValueResponse<ValidationTestResource>(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestResource(Client, response.Value, Id.SubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
