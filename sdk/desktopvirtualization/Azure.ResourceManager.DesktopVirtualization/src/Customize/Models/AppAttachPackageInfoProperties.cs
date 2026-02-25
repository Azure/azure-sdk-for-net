// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
