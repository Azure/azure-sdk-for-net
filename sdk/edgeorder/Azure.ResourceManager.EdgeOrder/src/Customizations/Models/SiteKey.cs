// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    internal class SiteKey
    {
        /// <summary>
        /// resource id for boostrap resource
        /// </summary>
        internal string ResourceId;

        /// <summary>
        /// aadendpoint for authentication
        /// </summary>
        internal string AadEndpoint;

        /// <summary>
        /// tenant id of customer
        /// </summary>
        internal string TenantId;

        /// <summary>
        /// client id
        /// </summary>
        internal string ClientId;

        /// <summary>
        /// arm endpoint to identify cloud
        /// </summary>
        internal string ArmEndPoint;

        /// <summary>
        /// secret data
        /// </summary>
        internal string ClientSecret;
    }
}
