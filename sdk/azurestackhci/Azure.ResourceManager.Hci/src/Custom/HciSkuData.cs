// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("HciSkuData")]
    [CodeGenSuppress("Content")]
    [CodeGenSuppress("ContentVersion")]
    [CodeGenSuppress("OfferId")]
    [CodeGenSuppress("PublisherId")]
    public partial class HciSkuData
    {
        /// <summary> Initializes a new instance of <see cref="HciSkuData"/>. </summary>
        public HciSkuData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="HciSkuData"/> for backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected HciSkuData(ResourceIdentifier id) : this()
        {
        }

        /// <summary> JSON serialized catalog content of the sku offer. </summary>
        [WirePath("properties.content")]
        public string Content { get; set; }

        /// <summary> The API version of the catalog service used to serve the catalog content. </summary>
        [WirePath("properties.contentVersion")]
        public string ContentVersion { get; set; }

        /// <summary> Identifier of the Offer for the sku. </summary>
        [WirePath("properties.offerId")]
        public string OfferId { get; set; }

        /// <summary> Identifier of the Publisher for the offer. </summary>
        [WirePath("properties.publisherId")]
        public string PublisherId { get; set; }
    }
}
