// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file adds a parameterless constructor to the DeliveryRuleActionProperties abstract base class for backward API compatibility with the previous SDK.
    // Reason: The TypeSpec generator produces a protected constructor with a discriminator parameter (typeName) for polymorphic base classes,
    // but the old SDK provided a parameterless protected constructor. Derived classes (such as various Action Parameters) may depend on the parameterless constructor,
    // so it is preserved here and marked as EditorBrowsable.Never.

    /// <summary>
    /// Defines the parameters for delivery rule actions
    /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="UriRedirectActionProperties"/>, <see cref="UriSigningActionProperties"/>, <see cref="OriginGroupOverrideActionProperties"/>, <see cref="DeliveryRuleEdgeActionProperties"/>, <see cref="UriRewriteActionProperties"/>, <see cref="HeaderActionProperties"/>, <see cref="CacheExpirationActionProperties"/>, <see cref="CacheKeyQueryStringActionProperties"/>, and <see cref="RouteConfigurationOverrideActionProperties"/>.
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
