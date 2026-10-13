// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ProviderHub.Models;

namespace Azure.ResourceManager.ProviderHub
{
    // Backward-compat: 1.2.x exposed both the long-running Delete(WaitUntil, ...) overload and a
    // synchronous Delete(CancellationToken) overload. The current generator emits only the former,
    // so these restore the synchronous pair by awaiting the long-running overload to completion.
    public partial class ProviderRegistrationResource
    {
        /// <summary> Deletes the provider registration and waits for the operation to complete. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response Delete(CancellationToken cancellationToken = default)
        {
            return Delete(WaitUntil.Completed, cancellationToken).GetRawResponse();
        }

        /// <summary> Deletes the provider registration and waits for the operation to complete. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteAsync(CancellationToken cancellationToken = default)
        {
            ArmOperation operation = await DeleteAsync(WaitUntil.Completed, cancellationToken).ConfigureAwait(false);
            return operation.GetRawResponse();
        }

        private Operations _legacyOperations;
        private RegistrationNewRegionFrontloadReleases _legacyFrontloadReleases;

        // Removed operations retain the released API version rather than using the new default.
        private Operations LegacyOperations => _legacyOperations ??= new Operations(
            new ClientDiagnostics("Azure.ResourceManager.ProviderHub", ResourceType.Namespace, Diagnostics),
            Pipeline, Diagnostics.ApplicationId, Endpoint, "2024-09-01");

        private RegistrationNewRegionFrontloadReleases LegacyFrontloadReleases => _legacyFrontloadReleases ??= new RegistrationNewRegionFrontloadReleases(
            new ClientDiagnostics("Azure.ResourceManager.ProviderHub", ResourceType.Namespace, Diagnostics),
            Pipeline, Diagnostics.ApplicationId, Endpoint, "2024-09-01");

        /// <summary>
        /// Creates or updates the operation supported by the given provider.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OperationsPutContents_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ProviderRegistrationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The operations content properties supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<OperationsPutContent>> CreateOrUpdateAsync(OperationsPutContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = LegacyOperations.ClientDiagnostics.CreateScope("ProviderRegistrationResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = LegacyOperations.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.Name, OperationsPutContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<OperationsPutContent> response = Response.FromValue(OperationsPutContent.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates the operation supported by the given provider.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OperationsPutContents_CreateOrUpdate. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ProviderRegistrationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The operations content properties supplied to the CreateOrUpdate operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<OperationsPutContent> CreateOrUpdate(OperationsPutContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = LegacyOperations.ClientDiagnostics.CreateScope("ProviderRegistrationResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = LegacyOperations.CreateCreateOrUpdateRequest(Guid.Parse(Id.SubscriptionId), Id.Name, OperationsPutContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<OperationsPutContent> response = Response.FromValue(OperationsPutContent.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the operations supported by the given provider.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OperationsPutContents_ListByProviderRegistration. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ProviderRegistrationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OperationsDefinition"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OperationsDefinition> GetByProviderRegistrationAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new MicrosoftProviderHubOperationsPutContentsListByProviderRegistrationAsyncCollectionResultOfT(LegacyOperations, Guid.Parse(Id.SubscriptionId), Id.Name, context, "ProviderRegistrationResource.GetByProviderRegistration");
        }

        /// <summary>
        /// Gets the operations supported by the given provider.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/operations/default. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> OperationsPutContents_ListByProviderRegistration. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ProviderRegistrationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OperationsDefinition"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OperationsDefinition> GetByProviderRegistration(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new MicrosoftProviderHubOperationsPutContentsListByProviderRegistrationCollectionResultOfT(LegacyOperations, Guid.Parse(Id.SubscriptionId), Id.Name, context, "ProviderRegistrationResource.GetByProviderRegistration");
        }

        /// <summary>
        /// Generates the new region frontload manifest.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/generateNewRegionFrontloadManifest. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProviderRegistrations_NewRegionFrontloadReleaseGenerateManifest. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ProviderRegistrationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual async Task<Response<ResourceProviderManifest>> GenerateManifestNewRegionFrontloadReleaseAsync(ProviderFrontloadPayload properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            using DiagnosticScope scope = LegacyFrontloadReleases.ClientDiagnostics.CreateScope("ProviderRegistrationResource.GenerateManifestNewRegionFrontloadRelease");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = LegacyFrontloadReleases.CreateGenerateManifestNewRegionFrontloadReleaseRequest(Guid.Parse(Id.SubscriptionId), Id.Name, ProviderFrontloadPayload.ToRequestContent(properties), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<ResourceProviderManifest> response = Response.FromValue(ResourceProviderManifest.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Generates the new region frontload manifest.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.ProviderHub/providerRegistrations/{providerNamespace}/generateNewRegionFrontloadManifest. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ProviderRegistrations_NewRegionFrontloadReleaseGenerateManifest. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-09-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="ProviderRegistrationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public virtual Response<ResourceProviderManifest> GenerateManifestNewRegionFrontloadRelease(ProviderFrontloadPayload properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            using DiagnosticScope scope = LegacyFrontloadReleases.ClientDiagnostics.CreateScope("ProviderRegistrationResource.GenerateManifestNewRegionFrontloadRelease");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = LegacyFrontloadReleases.CreateGenerateManifestNewRegionFrontloadReleaseRequest(Guid.Parse(Id.SubscriptionId), Id.Name, ProviderFrontloadPayload.ToRequestContent(properties), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<ResourceProviderManifest> response = Response.FromValue(ResourceProviderManifest.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a collection of RegistrationNewRegionFrontloadReleases in the <see cref="ProviderRegistrationResource"/>. </summary>
        /// <returns> An object representing collection of RegistrationNewRegionFrontloadReleases and their operations over a RegistrationNewRegionFrontloadReleaseResource. </returns>
        public virtual RegistrationNewRegionFrontloadReleaseCollection GetRegistrationNewRegionFrontloadReleases()
        {
            return GetCachedClient(client => new RegistrationNewRegionFrontloadReleaseCollection(client, Id));
        }

        /// <summary> Gets a new region frontload release. </summary>
        /// <param name="releaseName"> The name of the release. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="releaseName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="releaseName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<RegistrationNewRegionFrontloadReleaseResource>> GetRegistrationNewRegionFrontloadReleaseAsync(string releaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(releaseName, nameof(releaseName));

            return await GetRegistrationNewRegionFrontloadReleases().GetAsync(releaseName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a new region frontload release. </summary>
        /// <param name="releaseName"> The name of the release. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="releaseName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="releaseName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<RegistrationNewRegionFrontloadReleaseResource> GetRegistrationNewRegionFrontloadRelease(string releaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(releaseName, nameof(releaseName));

            return GetRegistrationNewRegionFrontloadReleases().Get(releaseName, cancellationToken);
        }
    }
}
