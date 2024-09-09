// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.EdgeOrder.Models;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    /// <summary>
    /// Device Configuration
    /// </summary>
    public class DeviceConfiguration
    {
        /// <summary>
        /// Network Configuration
        /// </summary>
        public NetworkConfiguration Network { get; set; }

        /// <summary>
        /// Host Name
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Web Proxy Configuration
        /// </summary>
        public WebProxyConfiguration WebProxy { get; set; }

        /// <summary>
        /// Time Configuration
        /// </summary>
        public TimeConfiguration Time { get; set; }

        /// <summary>
        /// to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(Network)}={Network}, {nameof(HostName)}={HostName}, {nameof(WebProxy)}={WebProxy}, {nameof(Time)}={Time}}}";
        }
    }
}
