// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint
{
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update;

    /// <summary>
    /// The stage of an CDN profile endpoint update allowing to specify endpoint properties.
    /// </summary>
    public interface IUpdatePremiumEndpoint  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update.IUpdate
    {
        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithCustomDomain(string hostName);

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithOriginPath(string originPath);

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithoutCustomDomain(string hostName);

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithHttpsPort(int httpsPort);

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithHostHeader(string hostHeader);

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithHttpPort(int httpPort);

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint WithHttpsAllowed(bool httpsAllowed);
    }
}