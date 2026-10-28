// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PlatformValidation
{
    public partial class ValidationTestResource
    {
        private readonly string _catalogSubscriptionId;

        private string CatalogSubscriptionId => _catalogSubscriptionId ?? Id.SubscriptionId
            ?? throw new InvalidOperationException("This catalog resource has no subscription context. Retrieve it through a subscription's catalog collection or use a subscription-scoped resource identifier.");

        // Catalog response IDs are provider-global; retain the subscription used to request them.
        internal ValidationTestResource(ArmClient client, ValidationTestData data, string subscriptionId)
            : this(client, data)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            _catalogSubscriptionId = subscriptionId;
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ValidationTestResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ValidationTestResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _validationTestsClientDiagnostics.CreateScope("ValidationTestResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestsRestClient.CreateGetRequest(Guid.Parse(CatalogSubscriptionId), Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ValidationTestData> response = Response.FromValue(ValidationTestData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestResource(Client, response.Value, CatalogSubscriptionId), response.GetRawResponse());
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ValidationTestResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ValidationTestResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _validationTestsClientDiagnostics.CreateScope("ValidationTestResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestsRestClient.CreateGetRequest(Guid.Parse(CatalogSubscriptionId), Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ValidationTestData> response = Response.FromValue(ValidationTestData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestResource(Client, response.Value, CatalogSubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a collection of ValidationTestVersions in the <see cref="ValidationTestResource"/>. </summary>
        /// <returns> An object representing collection of ValidationTestVersions and their operations over a ValidationTestVersionResource. </returns>
        public virtual ValidationTestVersionCollection GetValidationTestVersions()
        {
            return GetCachedClient(client => new ValidationTestVersionCollection(client, CreateResourceIdentifier(CatalogSubscriptionId, Id.Name)));
        }
    }
}
