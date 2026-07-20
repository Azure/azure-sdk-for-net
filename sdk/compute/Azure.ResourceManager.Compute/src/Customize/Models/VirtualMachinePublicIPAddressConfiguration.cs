// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachinePublicIPAddressConfiguration
    {
        /// <summary> The Domain name label prefix of the PublicIPAddress resources that will be created. The generated name label is the concatenation of the domain name label and vm network profile unique ID. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DnsDomainNameLabel
        {
            get => DnsSettings is null ? default : DnsSettings.DomainNameLabel;
            set => DnsSettings = new VirtualMachinePublicIPAddressDnsSettingsConfiguration(value);
        }
    }
}
