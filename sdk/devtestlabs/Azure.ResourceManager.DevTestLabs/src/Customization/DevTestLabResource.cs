// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DevTestLabs.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A Class representing a DevTestLab along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="DevTestLabResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetDevTestLabResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetDevTestLab method.
    /// </summary>
    public partial class DevTestLabResource : ArmResource
    {
        /// <summary>
        /// List gallery images in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/galleryimages
        /// Operation Id: GalleryImages_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=author)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabGalleryImage" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabGalleryImage> GetGalleryImagesAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabGalleryImage>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _galleryImagesClientDiagnostics.CreateScope("DevTestLabResource.GetGalleryImages");
                scope.Start();
                try
                {
                    var response = await _galleryImagesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabGalleryImage>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _galleryImagesClientDiagnostics.CreateScope("DevTestLabResource.GetGalleryImages");
                scope.Start();
                try
                {
                    var response = await _galleryImagesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List gallery images in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/galleryimages
        /// Operation Id: GalleryImages_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=author)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabGalleryImage" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabGalleryImage> GetGalleryImages(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabGalleryImage> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _galleryImagesClientDiagnostics.CreateScope("DevTestLabResource.GetGalleryImages");
                scope.Start();
                try
                {
                    var response = _galleryImagesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabGalleryImage> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _galleryImagesClientDiagnostics.CreateScope("DevTestLabResource.GetGalleryImages");
                scope.Start();
                try
                {
                    var response = _galleryImagesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
