namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class HardwareProfile
    {
        /// <summary>
        /// The virtual machine size name. Possible values for this property
        /// include: 'Basic_A0', 'Basic_A1', 'Basic_A2', 'Basic_A3',
        /// 'Basic_A4', 'Standard_A0', 'Standard_A1', 'Standard_A2',
        /// 'Standard_A3', 'Standard_A4', 'Standard_A5', 'Standard_A6',
        /// 'Standard_A7', 'Standard_A8', 'Standard_A9', 'Standard_G1',
        /// 'Standard_G2', 'Standard_G3', 'Standard_G4', 'Standard_G5'
        /// </summary>
        [JsonProperty(PropertyName = "vmSize")]
        public VirtualMachineSizeTypes? VmSize { get; set; }

    }
}
