// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Purview.Models
{
    // Old API exposed Properties as public getter/setter on PurviewAccountPatch.
    // The new generator makes it internal due to property flattening.
    public partial class PurviewAccountPatch
    {
        /// <summary> The account properties. </summary>
        [CodeGenMember("Properties")]
        public PurviewAccountProperties Properties { get; set; }
    }
}
