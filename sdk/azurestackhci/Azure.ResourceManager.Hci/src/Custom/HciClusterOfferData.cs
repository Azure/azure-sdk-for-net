// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("HciClusterOfferData")]
    [CodeGenSuppress("Content")]
    [CodeGenSuppress("ContentVersion")]
    [CodeGenSuppress("PublisherId")]
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
