// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscoverySap.Models
{
    // The TypeSpec generator emits the deserialization constructor as internal.
    // Restore the protected constructor shipped by the previous generator so external derived types remain supported.
    public abstract partial class PerformanceDetail
    {
        /// <summary> Initializes a new instance of <see cref="PerformanceDetail"/>. </summary>
        protected PerformanceDetail()
        {
        }
    }
}
