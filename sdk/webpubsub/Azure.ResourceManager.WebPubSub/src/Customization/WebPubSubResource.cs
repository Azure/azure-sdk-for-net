// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

using Microsoft.TypeSpec.Generator.Customizations;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.WebPubSub
{
    [CodeGenSuppress("GetWebPubSubSharedPrivateLinkResources")]
    [CodeGenSuppress("GetWebPubSubSharedPrivateLinkResourceAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetWebPubSubSharedPrivateLinkResource", typeof(string), typeof(CancellationToken))]
    public partial class WebPubSubResource : ArmResource
    {
        /// <summary> Gets a collection of WebPubSubSharedPrivateLinkResources in the WebPubSub. </summary>
        /// <returns> An object representing collection of WebPubSubSharedPrivateLinkResources and their operations over a WebPubSubSharedPrivateLinkResource. </returns>
        public virtual WebPubSubSharedPrivateLinkCollection GetWebPubSubSharedPrivateLinks()
        {
            return GetCachedClient(client => new WebPubSubSharedPrivateLinkCollection(client, Id));
        }

        /// <summary> Get the specified shared private link resource. </summary>
        /// <param name="sharedPrivateLinkResourceName"> The name of the shared private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sharedPrivateLinkResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sharedPrivateLinkResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<WebPubSubSharedPrivateLinkResource>> GetWebPubSubSharedPrivateLinkAsync(string sharedPrivateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sharedPrivateLinkResourceName, nameof(sharedPrivateLinkResourceName));

            return await GetWebPubSubSharedPrivateLinks().GetAsync(sharedPrivateLinkResourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get the specified shared private link resource. </summary>
        /// <param name="sharedPrivateLinkResourceName"> The name of the shared private link resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="sharedPrivateLinkResourceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="sharedPrivateLinkResourceName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<WebPubSubSharedPrivateLinkResource> GetWebPubSubSharedPrivateLink(string sharedPrivateLinkResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(sharedPrivateLinkResourceName, nameof(sharedPrivateLinkResourceName));

            return GetWebPubSubSharedPrivateLinks().Get(sharedPrivateLinkResourceName, cancellationToken);
        }
    }
}
