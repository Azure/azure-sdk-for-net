// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maps.Models
{
    // Backward compat: TypeSpec spec defines storageUnits as required (int32), but the
    // previous GA SDK (1.1.0) exposed it as nullable (int?). This preserves the nullable
    // type to avoid a breaking change for existing callers.
    [CodeGenSuppress("StorageUnits", typeof(int))]
    public partial class MapsCreatorPatch
    {
        /// <summary> The storage units to be allocated. Integer values from 1 to 100, inclusive. </summary>
        public int? StorageUnits
        {
            get => Properties?.StorageUnits;
            set
            {
                if (Properties is null)
                {
                    Properties = new MapsCreatorProperties();
                }
                Properties.StorageUnits = value ?? default;
            }
        }
    }
}
