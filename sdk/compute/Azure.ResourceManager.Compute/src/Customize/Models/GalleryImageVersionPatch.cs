// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward compatibility: the previously shipped patch model exposed the soft-delete restore flag as Restore.
    // The shared TypeSpec property is renamed to IsRestoreEnabled for GalleryImageVersionData, so suppress the generated
    // patch accessor and keep the old patch name while delegating to the same wire property.
    [CodeGenSuppress("IsRestoreEnabled")]
    public partial class GalleryImageVersionPatch
    {
        /// <summary> Indicates if this is a soft-delete resource restoration request. </summary>
        public bool? Restore
        {
            get
            {
                return Properties is null ? default : Properties.IsRestoreEnabled;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new GalleryImageVersionProperties();
                }
                Properties.IsRestoreEnabled = value;
            }
        }
    }
}
