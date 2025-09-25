// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Autorest.CSharp.Core;
using Azure.Core;

namespace Azure.ResourceManager.DevCenter
{
    // Due to the breaking change that caused a change in the return type, the method name has been renamed and the required method for the API has been added back.
    public partial class DevCenterResource
    {
        /// <summary>
        /// Lists images for a devcenter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_ListByDevCenter</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DevCenterImageResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevCenterImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevCenterImageResource> GetImagesAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _imagesRestClient.CreateListByDevCenterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _imagesRestClient.CreateListByDevCenterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DevCenterImageResource(Client, DevCenterImageData.DeserializeDevCenterImageData(e)), _imagesClientDiagnostics, Pipeline, "DevCenterResource.GetImages", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists images for a devcenter.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevCenter/devcenters/{devCenterName}/images</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Images_ListByDevCenter</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DevCenterImageResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: '$top=10'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevCenterImageResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevCenterImageResource> GetImages(int? top = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _imagesRestClient.CreateListByDevCenterRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _imagesRestClient.CreateListByDevCenterNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, top);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DevCenterImageResource(Client, DevCenterImageData.DeserializeDevCenterImageData(e)), _imagesClientDiagnostics, Pipeline, "DevCenterResource.GetImages", "value", "nextLink", cancellationToken);
        }
    }
}
