// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition
{
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The first stage of a CDN profile endpoint definition.
    /// </summary>
    public interface IBlank 
    {
    }

    /// <summary>
    /// The final stage of the Standard endpoint object definition, at which it can be attached to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile update to return to after attaching this definition.</typeparam>
    public interface IAttachableStandard<ParentT> 
    {
        /// <summary>
        /// Attaches the endpoint definition to the parent CDN profile update.
        /// </summary>
        /// <return>The stage of the parent CDN profile update to return to after attaching this definition.</return>
        ParentT Attach();
    }

    /// <summary>
    /// The final stage of the CDN profile Standard Akamai or Standard Verizon endpoint definition.
    /// At this stage, any remaining optional settings can be specified, or the CDN profile endpoint
    /// definition can be attached to the parent CDN profile definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile update to return to after attaching this definition.</typeparam>
    public interface IWithStandardAttach<ParentT>  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IAttachableStandard<ParentT>
    {
        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithCustomDomain(string hostName);

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentTypesToCompress">The list of content types to compress to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithContentTypesToCompress(IList<string> contentTypesToCompress);

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithOriginPath(string originPath);

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithHttpsPort(int httpsPort);

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithHostHeader(string hostHeader);

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">A query string caching behavior.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior);

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If true then compression will be enabled, else disabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithCompressionEnabled(bool compressionEnabled);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithHttpPort(int httpPort);

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="geoFilters">The Geo filters list to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithGeoFilters(IList<Microsoft.Azure.Management.Cdn.Fluent.Models.GeoFilter> geoFilters);

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A single content type to compress to add to the list.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Adds a single entry to the geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action.</param>
        /// <param name="countryCode">An ISO 2 letter country code.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode);

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action.</param>
        /// <param name="countryCodes">A list of ISO 2 letter country codes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithStandardAttach<ParentT> WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode> countryCodes);
    }

    /// <summary>
    /// The final stage of the Premium Verizon endpoint object definition, at which it can be attached to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile update to return to after attaching this definition.</typeparam>
    public interface IAttachablePremium<ParentT> 
    {
        /// <summary>
        /// Attaches the endpoint definition to the parent CDN profile update.
        /// </summary>
        /// <return>The stage of the parent CDN profile update to return to after attaching this definition.</return>
        ParentT Attach();
    }

    /// <summary>
    /// The final stage of a CDN profile Premium Verizon endpoint definition.
    /// At this stage, any remaining optional settings can be specified, or the CDN profile endpoint
    /// definition can be attached to the parent CDN profile definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile update to return to after attaching this definition.</typeparam>
    public interface IWithPremiumAttach<ParentT>  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IAttachablePremium<ParentT>
    {
        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithCustomDomain(string hostName);

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithOriginPath(string originPath);

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithHttpsPort(int httpsPort);

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithHostHeader(string hostHeader);

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithHttpPort(int httpPort);

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.IWithPremiumAttach<ParentT> WithHttpsAllowed(bool httpsAllowed);
    }
}