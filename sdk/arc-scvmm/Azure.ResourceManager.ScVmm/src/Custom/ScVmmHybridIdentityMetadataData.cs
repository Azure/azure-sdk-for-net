// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.ScVmm.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ScVmm
{
    [CodeGenSuppress("ScVmmHybridIdentityMetadataData")]
    [CodeGenSuppress("Properties")]
    [CodeGenSuppress("PublicKey")]
    [CodeGenSuppress("ResourceUid")]
    public partial class ScVmmHybridIdentityMetadataData
    {
        // Hybrid identity metadata is read-only in TypeSpec, so generation made the data model
        // output-only. AutoRest shipped it as public-constructible with settable flattened
        // properties; keep that public model shape for ApiCompat.
        /// <summary> Initializes a new instance of <see cref="ScVmmHybridIdentityMetadataData"/>. </summary>
        public ScVmmHybridIdentityMetadataData()
        {
            Properties = new VmInstanceHybridIdentityMetadataProperties();
        }

        internal VmInstanceHybridIdentityMetadataProperties Properties { get; set; }

        /// <summary> The unique identifier for the resource. </summary>
        public string ResourceUid
        {
            get => Properties is null ? default : Properties.ResourceUid;
            set
            {
                Properties ??= new VmInstanceHybridIdentityMetadataProperties();
                Properties.ResourceUid = value;
            }
        }

        /// <summary> Gets or sets the Public Key. </summary>
        public string PublicKey
        {
            get => Properties is null ? default : Properties.PublicKey;
            set
            {
                Properties ??= new VmInstanceHybridIdentityMetadataProperties();
                Properties.PublicKey = value;
            }
        }
    }
}
