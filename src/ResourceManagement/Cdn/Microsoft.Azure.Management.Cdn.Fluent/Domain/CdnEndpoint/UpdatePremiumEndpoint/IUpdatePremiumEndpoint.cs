// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint
{
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update;

    /// <summary>
    /// The stage of an CDN profile endpoint update allowing to specify endpoint properties.
    /// </summary>
    public interface IUpdatePremiumEndpoint  :
        IUpdate
    {
        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithHttpPort(int httpPort);

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithoutCustomDomain(string hostName);

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithCustomDomain(string hostName);

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithHttpsPort(int httpsPort);

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithOriginPath(string originPath);

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdatePremiumEndpoint WithHostHeader(string hostHeader);
    }
}