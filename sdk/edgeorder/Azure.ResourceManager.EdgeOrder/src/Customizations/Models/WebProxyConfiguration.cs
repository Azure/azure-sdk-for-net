// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    /// <summary>
    /// Web Proxy Configuration
    /// </summary>
    public class WebProxyConfiguration
    {
        /// <summary>
        /// Connection Uri
        /// </summary>
        public string ConnectionUri { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// By pass list
        /// </summary>
        public IList<string> BypassList { get; set; }

        /// <summary>
        /// tostring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{{{nameof(ConnectionUri)}={ConnectionUri}, {nameof(Port)}={Port}, {nameof(BypassList)}={BypassList.ToString()}}}";
        }
    }
}
