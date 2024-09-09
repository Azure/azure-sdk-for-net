// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    /// <summary>
    /// Address Range of IP
    /// </summary>
    public class IPAddressRange
    {
        /// <summary>
        /// Start IP
        /// </summary>
        public string StartIp { get; set; }

        /// <summary>
        /// End IP
        /// </summary>
        public string EndIp { get; set; }

        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(StartIp)}={StartIp}, {nameof(EndIp)}={EndIp}}}";
        }
    }
}
