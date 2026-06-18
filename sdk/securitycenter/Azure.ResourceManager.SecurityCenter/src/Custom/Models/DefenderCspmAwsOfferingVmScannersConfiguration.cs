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
    // Compatibility customization: the generated factory overload exposes an internal AzureResourceLink type after the
    // assessmentDefinitions property is hidden behind the public SubResource compatibility property below.
    // Suppress the invalid generated overload and preserve the previous public ModelFactory signature.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class DefenderCspmAwsOfferingVmScannersConfiguration
    {
        public DefenderCspmAwsOfferingVmScannersConfiguration() { }
        public string CloudRoleArn { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IDictionary<string, string> ExclusionTags { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public Azure.ResourceManager.SecurityCenter.Models.DefenderForServersScanningMode? ScanningMode { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } set { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
    }
}
