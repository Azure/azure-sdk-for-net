// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class ComputeSecurityPostureReference
    {
        /// <summary> List of virtual machine extension names to exclude when applying the security posture. Only applicable when the security posture reference is in the resource group. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> ExcludeExtensionNames => ExcludeExtensions.Select(e => e.Name).ToList();
    }
}
