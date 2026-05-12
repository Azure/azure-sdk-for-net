// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.HybridCompute
{
    public partial class HybridComputePrivateLinkResourceData
    {
        // In the AutoRest GA SDK (1.0.0), this class had a public parameterless constructor and
        // a public setter on the Properties property. In the TypeSpec-generated code, the
        // constructor is internal and Properties is read-only.
        //
        // These cannot be restored via customization because:
        //   - A partial class cannot define a constructor with the same signature (no parameters)
        //     as an existing internal constructor in the generated partial class; doing so causes
        //     CS0111 (duplicate member).
        //   - Adding a Properties setter for a get-only property is also not supported in partial
        //     class customization.
        //
        // Both breaking changes are tracked in eng/apicompatbaselines/Azure.ResourceManager.HybridCompute.txt.
    }
}
