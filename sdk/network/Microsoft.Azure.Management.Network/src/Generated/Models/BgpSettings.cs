// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// BGP settings details.
    /// </summary>
    public partial class BgpSettings
    {
        /// <summary>
        /// Initializes a new instance of the BgpSettings class.
        /// </summary>
        public BgpSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the BgpSettings class.
        /// </summary>
        /// <param name="asn">The BGP speaker's ASN.</param>
        /// <param name="bgpPeeringAddress">The BGP peering address and BGP
        /// identifier of this BGP speaker.</param>
        /// <param name="peerWeight">The weight added to routes learned from
        /// this BGP speaker.</param>
        /// <param name="bgpPeeringAddresses">BGP peering address with IP
        /// configuration ID for virtual network gateway.</param>
        public BgpSettings(long? asn = default(long?), string bgpPeeringAddress = default(string), int? peerWeight = default(int?), IList<IPConfigurationBgpPeeringAddress> bgpPeeringAddresses = default(IList<IPConfigurationBgpPeeringAddress>))
        {
            Asn = asn;
            BgpPeeringAddress = bgpPeeringAddress;
            PeerWeight = peerWeight;
            BgpPeeringAddresses = bgpPeeringAddresses;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the BGP speaker's ASN.
        /// </summary>
        [JsonProperty(PropertyName = "asn")]
        public long? Asn { get; set; }

        /// <summary>
        /// Gets or sets the BGP peering address and BGP identifier of this BGP
        /// speaker.
        /// </summary>
        [JsonProperty(PropertyName = "bgpPeeringAddress")]
        public string BgpPeeringAddress { get; set; }

        /// <summary>
        /// Gets or sets the weight added to routes learned from this BGP
        /// speaker.
        /// </summary>
        [JsonProperty(PropertyName = "peerWeight")]
        public int? PeerWeight { get; set; }

        /// <summary>
        /// Gets or sets BGP peering address with IP configuration ID for
        /// virtual network gateway.
        /// </summary>
        [JsonProperty(PropertyName = "bgpPeeringAddresses")]
        public IList<IPConfigurationBgpPeeringAddress> BgpPeeringAddresses { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Asn > 4294967295)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Asn", 4294967295);
            }
            if (Asn < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Asn", 0);
            }
        }
    }
}
