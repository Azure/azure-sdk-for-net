// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute
{
    // Backward compatibility: the previously shipped SDK exposed this data type in the root namespace.
    // The generated TypeSpec model is otherwise placed under Models; CodeGenType keeps the public API shape.
    // Suppress the generated parent resource-key helper because the Swagger payload has no parentName property
    // and the old SDK did not expose it.
    [CodeGenType("SharedGalleryImageData")]
    [CodeGenSuppress("ParentName")]
    public partial class SharedGalleryImageData
    {
        // we also must add back this property to avoid breaking changes, but its payload never have this property.
        /// <summary>
        /// The resource identifier.
        ///
        /// This property is depracated and will be removed in a future release.
        /// There is possibility that this property will be null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Id { get; internal set; }

        // Backward compatibility: the previously shipped SDK exposed ArtifactTags as IReadOnlyDictionary.
        // Suppress the generated IDictionary property and keep the read-only return type to avoid a binary break.
        /// <summary> The artifact tags of a shared gallery resource. </summary>
        public IReadOnlyDictionary<string, string> ArtifactTags
        {
            get
            {
                return Properties is null ? new ChangeTrackingDictionary<string, string>() : (IReadOnlyDictionary<string, string>)Properties.ArtifactTags;
            }
        }

        // Backward compatibility: the previously shipped SDK exposed Features as IReadOnlyList.
        // Suppress the generated IList property and keep the read-only return type to avoid a binary break.
        /// <summary> A list of gallery image features. </summary>
        public IReadOnlyList<GalleryImageFeature> Features
        {
            get
            {
                return Properties is null ? new ChangeTrackingList<GalleryImageFeature>() : (IReadOnlyList<GalleryImageFeature>)Properties.Features;
            }
        }
    }
}
