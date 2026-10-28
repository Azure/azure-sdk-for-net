// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.PlatformValidation
{
    public partial class ValidationTestVersionResource
    {
        private readonly string _catalogSubscriptionId;

        private string CatalogSubscriptionId => _catalogSubscriptionId ?? Id.SubscriptionId
            ?? throw new InvalidOperationException("This catalog resource has no subscription context. Retrieve it through a subscription's catalog collection or use a subscription-scoped resource identifier.");

        // Catalog response IDs are provider-global; retain the subscription used to request them.
        internal ValidationTestVersionResource(ArmClient client, ValidationTestVersionData data, string subscriptionId)
            : this(client, data)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            _catalogSubscriptionId = subscriptionId;
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ValidationTestVersionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ValidationTestVersionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _validationTestVersionsClientDiagnostics.CreateScope("ValidationTestVersionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestVersionsRestClient.CreateGetRequest(Guid.Parse(CatalogSubscriptionId), Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ValidationTestVersionData> response = Response.FromValue(ValidationTestVersionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestVersionResource(Client, response.Value, CatalogSubscriptionId), response.GetRawResponse());
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
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ValidationTestVersionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ValidationTestVersionResource> Get(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _validationTestVersionsClientDiagnostics.CreateScope("ValidationTestVersionResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _validationTestVersionsRestClient.CreateGetRequest(Guid.Parse(CatalogSubscriptionId), Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ValidationTestVersionData> response = Response.FromValue(ValidationTestVersionData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ValidationTestVersionResource(Client, response.Value, CatalogSubscriptionId), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
