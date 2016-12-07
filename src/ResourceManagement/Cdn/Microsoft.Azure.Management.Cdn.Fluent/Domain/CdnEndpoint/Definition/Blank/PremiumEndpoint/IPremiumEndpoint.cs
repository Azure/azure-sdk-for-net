// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint
{
    /// <summary>
    /// The stage of the CDN profile endpoint definition allowing to specify the origin
    /// for CDN Profile with Premium Verizon sku.
    /// </summary>
    /// <typeparam name="Parent">The return type of AttachablePremium.attach().</typeparam>
    public interface IPremiumEndpoint<ParentT> 
    {
        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originName">Name of the origin.</param>
        /// <param name="originHostName">Origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithPremiumOrigin(string originName, string originHostName);

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originHostName">Origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithPremiumOrigin(string originHostName);
    }
}