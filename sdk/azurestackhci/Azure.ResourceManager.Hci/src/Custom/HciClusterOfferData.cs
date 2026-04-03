// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: Offer is a read-only resource (no PUT/PATCH), so the generator only
    // produces an internal constructor and does not flatten Content, ContentVersion, PublisherId.
    // The old SDK exposed these as public read-write properties with a public constructor.
    public partial class HciClusterOfferData
    {
        /// <summary> Initializes a new instance of <see cref="HciClusterOfferData"/>. </summary>
        public HciClusterOfferData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HciClusterOfferData"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciClusterOfferData(ResourceIdentifier id) : this()
        {
        }

        /// <summary> JSON serialized catalog content of the offer. </summary>
        [WirePath("properties.content")]
        public string Content { get; set; }

        /// <summary> The API version of the catalog service used to serve the catalog content. </summary>
        [WirePath("properties.contentVersion")]
        public string ContentVersion { get; set; }

        /// <summary> Identifier of the Publisher for the offer. </summary>
        [WirePath("properties.publisherId")]
        public string PublisherId { get; set; }
    }
}
