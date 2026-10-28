// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PlatformValidation
{
    public partial class ValidationTestCategoryResource
    {
        private readonly string _catalogSubscriptionId;

        private string CatalogSubscriptionId => _catalogSubscriptionId ?? Id.SubscriptionId
            ?? throw new InvalidOperationException("This catalog resource has no subscription context. Retrieve it through a subscription's catalog collection or use a subscription-scoped resource identifier.");

        // Catalog response IDs are provider-global; retain the subscription used to request them.
        internal ValidationTestCategoryResource(ArmClient client, ValidationTestCategoryData data, string subscriptionId)
            : this(client, data)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            _catalogSubscriptionId = subscriptionId;
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ValidationTestCategoryResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ValidationTestCategoryResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _validationTestCategoriesClientDiagnostics.CreateScope("ValidationTestCategoryResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestCategoriesRestClient.CreateGetRequest(Guid.Parse(CatalogSubscriptionId), Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ValidationTestCategoryData> response = Response.FromValue(ValidationTestCategoryData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestCategoryResource(Client, response.Value, CatalogSubscriptionId), response.GetRawResponse());
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ValidationTestCategoryResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ValidationTestCategoryResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _validationTestCategoriesClientDiagnostics.CreateScope("ValidationTestCategoryResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestCategoriesRestClient.CreateGetRequest(Guid.Parse(CatalogSubscriptionId), Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ValidationTestCategoryData> response = Response.FromValue(ValidationTestCategoryData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestCategoryResource(Client, response.Value, CatalogSubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
