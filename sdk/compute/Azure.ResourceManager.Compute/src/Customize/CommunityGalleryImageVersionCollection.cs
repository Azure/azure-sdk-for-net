// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// A class representing a collection of <see cref="CommunityGalleryImageVersionResource"/> and their operations.
    /// Each <see cref="CommunityGalleryImageVersionResource"/> in the collection will belong to the same instance of <see cref="CommunityGalleryImageResource"/>.
    /// To get a <see cref="CommunityGalleryImageVersionCollection"/> instance call the GetCommunityGalleryImageVersions method from an instance of <see cref="CommunityGalleryImageResource"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class CommunityGalleryImageVersionCollection : ArmCollection, IEnumerable<CommunityGalleryImageVersionResource>, IAsyncEnumerable<CommunityGalleryImageVersionResource>
    {
        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageVersionCollection"/> class for mocking. </summary>
        protected CommunityGalleryImageVersionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="CommunityGalleryImageVersionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal CommunityGalleryImageVersionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _communityGalleryImageVersionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", CommunityGalleryImageVersionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(CommunityGalleryImageVersionResource.ResourceType, out string communityGalleryImageVersionApiVersion);
            _communityGalleryImageVersionsRestClient = new CommunityGalleryImageVersions(_communityGalleryImageVersionsClientDiagnostics, Pipeline, Endpoint, communityGalleryImageVersionApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != CommunityGalleryImageResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, CommunityGalleryImageResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a community gallery image version.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        public virtual async Task<Response<CommunityGalleryImageVersionResource>> GetAsync(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageVersionName, nameof(galleryImageVersionName));

            using var scope = _communityGalleryImageVersionsClientDiagnostics.CreateScope("CommunityGalleryImageVersionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImageVersionsRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<CommunityGalleryImageVersionData> response = Response.FromValue(CommunityGalleryImageVersionData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CommunityGalleryImageVersionResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName);
                return Response.FromValue(new CommunityGalleryImageVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a community gallery image version.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        public virtual Response<CommunityGalleryImageVersionResource> Get(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageVersionName, nameof(galleryImageVersionName));

            using var scope = _communityGalleryImageVersionsClientDiagnostics.CreateScope("CommunityGalleryImageVersionCollection.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImageVersionsRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<CommunityGalleryImageVersionData> response = Response.FromValue(CommunityGalleryImageVersionData.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                response.Value.Id = CommunityGalleryImageVersionResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName);
                return Response.FromValue(new CommunityGalleryImageVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List community gallery image versions inside an image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CommunityGalleryImageVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CommunityGalleryImageVersionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _communityGalleryImageVersionsRestClient.CreateGetAllRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _communityGalleryImageVersionsRestClient.CreateNextGetAllRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, null);
            return GalleryPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new CommunityGalleryImageVersionResource(Client, DeserializeCommunityGalleryImageVersionData(e)), _communityGalleryImageVersionsClientDiagnostics, Pipeline, "CommunityGalleryImageVersionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// List community gallery image versions inside an image.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CommunityGalleryImageVersionResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CommunityGalleryImageVersionResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _communityGalleryImageVersionsRestClient.CreateGetAllRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, null);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _communityGalleryImageVersionsRestClient.CreateNextGetAllRequest(new Uri(nextLink), Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, null);
            return GalleryPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new CommunityGalleryImageVersionResource(Client, DeserializeCommunityGalleryImageVersionData(e)), _communityGalleryImageVersionsClientDiagnostics, Pipeline, "CommunityGalleryImageVersionCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        private CommunityGalleryImageVersionData DeserializeCommunityGalleryImageVersionData(JsonElement element)
        {
            var data = CommunityGalleryImageVersionData.DeserializeCommunityGalleryImageVersionData(element, ModelSerializationExtensions.WireOptions);
            data.Id = CommunityGalleryImageVersionResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, data.Name);
            return data;
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageVersionName, nameof(galleryImageVersionName));

            using var scope = _communityGalleryImageVersionsClientDiagnostics.CreateScope("CommunityGalleryImageVersionCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImageVersionsRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName, context);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(!message.Response.IsError, message.Response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        public virtual Response<bool> Exists(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageVersionName, nameof(galleryImageVersionName));

            using var scope = _communityGalleryImageVersionsClientDiagnostics.CreateScope("CommunityGalleryImageVersionCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImageVersionsRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName, context);
                Pipeline.Send(message, cancellationToken);
                return Response.FromValue(!message.Response.IsError, message.Response);
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
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        public virtual async Task<NullableResponse<CommunityGalleryImageVersionResource>> GetIfExistsAsync(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageVersionName, nameof(galleryImageVersionName));

            using var scope = _communityGalleryImageVersionsClientDiagnostics.CreateScope("CommunityGalleryImageVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImageVersionsRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName, context);
                await Pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
                if (message.Response.IsError)
                    return new NoValueResponse<CommunityGalleryImageVersionResource>(message.Response);
                Response<CommunityGalleryImageVersionData> response = Response.FromValue(CommunityGalleryImageVersionData.FromResponse(message.Response), message.Response);
                response.Value.Id = CommunityGalleryImageVersionResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName);
                return Response.FromValue(new CommunityGalleryImageVersionResource(Client, response.Value), response.GetRawResponse());
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
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/communityGalleries/{publicGalleryName}/images/{galleryImageName}/versions/{galleryImageVersionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CommunityGalleryImageVersions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-03</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="CommunityGalleryImageVersionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="galleryImageVersionName"> The name of the community gallery image version. Needs to follow semantic version name pattern: The allowed characters are digit and period. Digits must be within the range of a 32-bit integer. Format: &lt;MajorVersion&gt;.&lt;MinorVersion&gt;.&lt;Patch&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="galleryImageVersionName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="galleryImageVersionName"/> is null. </exception>
        public virtual NullableResponse<CommunityGalleryImageVersionResource> GetIfExists(string galleryImageVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(galleryImageVersionName, nameof(galleryImageVersionName));

            using var scope = _communityGalleryImageVersionsClientDiagnostics.CreateScope("CommunityGalleryImageVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _communityGalleryImageVersionsRestClient.CreateGetRequest(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName, context);
                Pipeline.Send(message, cancellationToken);
                if (message.Response.IsError)
                    return new NoValueResponse<CommunityGalleryImageVersionResource>(message.Response);
                Response<CommunityGalleryImageVersionData> response = Response.FromValue(CommunityGalleryImageVersionData.FromResponse(message.Response), message.Response);
                response.Value.Id = CommunityGalleryImageVersionResource.CreateResourceIdentifier(Id.SubscriptionId, new AzureLocation(Id.Parent.Parent.Name), Id.Parent.Name, Id.Name, galleryImageVersionName);
                return Response.FromValue(new CommunityGalleryImageVersionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<CommunityGalleryImageVersionResource> IEnumerable<CommunityGalleryImageVersionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<CommunityGalleryImageVersionResource> IAsyncEnumerable<CommunityGalleryImageVersionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}