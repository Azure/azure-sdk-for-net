// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    /// <summary>
    /// Defines the parameters for delivery rule actions
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="UriRedirectActionProperties"/>, <see cref="UriSigningActionProperties"/>, <see cref="OriginGroupOverrideActionProperties"/>, <see cref="DeliveryRuleEdgeActionParameters"/>, <see cref="UriRewriteActionProperties"/>, <see cref="HeaderActionProperties"/>, <see cref="CacheExpirationActionProperties"/>, <see cref="CacheKeyQueryStringActionProperties"/>, and <see cref="RouteConfigurationOverrideActionProperties"/>.
    /// </summary>
    public abstract partial class DeliveryRuleActionProperties
    {
        /// <summary> Initializes a new instance of <see cref="DeliveryRuleActionProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected DeliveryRuleActionProperties()
        {
        }
    }
}
