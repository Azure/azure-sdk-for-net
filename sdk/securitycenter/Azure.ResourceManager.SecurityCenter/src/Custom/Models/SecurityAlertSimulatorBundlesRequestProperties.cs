// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityAlertSimulatorBundlesRequestProperties : SecurityAlertSimulatorRequestProperties
    {
        public SecurityAlertSimulatorBundlesRequestProperties() : base(default(SecurityCenterKind)) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public System.Collections.Generic.IList<Azure.ResourceManager.SecurityCenter.Models.SecurityAlertSimulatorBundleType> Bundles { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
