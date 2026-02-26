// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward compatibility: The PackageDependencies property was previously an IList<> with a
// public setter. The new generated code changed it to a read-only list. This restores the
// settable IList<MsixPackageDependencies> property so existing callers are not broken.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DesktopVirtualization.Models
{
    public partial class AppAttachPackageInfoProperties
    {
        /// <summary> List of package dependencies. </summary>
        [WirePath("packageDependencies")]
        public IList<MsixPackageDependencies> PackageDependencies { get; set; }
    }
}
