using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    internal class SiteKey
    {
        /// <summary>
        /// resource id for boostrap resource
        /// </summary>
        internal string resourceId;

        /// <summary>
        /// aadendpoint for authentication
        /// </summary>
        internal string aadEndpoint;

        /// <summary>
        /// tenant id of customer
        /// </summary>
        internal string tenantId;

        /// <summary>
        /// client id
        /// </summary>
        internal string clientId;

        /// <summary>
        /// secret data
        /// </summary>
        internal string clientSecret;
    }
}
