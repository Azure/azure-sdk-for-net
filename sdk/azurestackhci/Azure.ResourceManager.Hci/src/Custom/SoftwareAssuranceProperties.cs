// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [CodeGenSuppress("SoftwareAssuranceStatus")]
    public partial class SoftwareAssuranceProperties
    {
        /// <summary> Status of the Software Assurance for the cluster. </summary>
        [WirePath("softwareAssuranceStatus")]
        public SoftwareAssuranceStatus? SoftwareAssuranceStatus { get; set; }
    }
}
