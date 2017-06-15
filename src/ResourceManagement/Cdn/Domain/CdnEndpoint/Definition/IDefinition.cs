// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition
{
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The final stage of the Premium Verizon endpoint definition, at which it can be attached to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile definition to return to after attaching this definition.</typeparam>
    public interface IAttachablePremium<ParentT> 
    {
        /// <summary>
        /// Attaches the defined endpoint to the parent CDN profile.
        /// </summary>
        /// <return>The stage of the parent CDN profile definition to return to after attaching this definition.</return>
        ParentT Attach();
    }

    /// <summary>
    /// The first stage of a CDN profile endpoint definition.
    /// </summary>
    public interface IBlank 
    {
    }

    /// <summary>
    /// The final stage of the CDN profile Premium Verizon endpoint definition.
    /// At this stage, any remaining optional settings can be specified, or the CDN profile endpoint
    /// definition can be attached to the parent CDN profile definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile definition to return to after attaching this definition.</typeparam>
    public interface IWithPremiumAttach<ParentT>  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IAttachablePremium<ParentT>
    {
        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithHttpPort(int httpPort);

        /// <summary>
        /// Adds a new CDN custom domain for the endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithCustomDomain(string hostName);

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithHttpsPort(int httpsPort);

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true, then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithOriginPath(string originPath);

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithPremiumAttach<ParentT> WithHostHeader(string hostHeader);
    }

    /// <summary>
    /// The final stage of a Standard endpoint definition, at which it can be attached to the parent.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile definition to return to after attaching this definition.</typeparam>
    public interface IAttachableStandard<ParentT> 
    {
        /// <summary>
        /// Attaches the defined endpoint to the parent CDN profile.
        /// </summary>
        /// <return>The stage of the parent CDN profile definition to return to after attaching this definition.</return>
        ParentT Attach();
    }

    /// <summary>
    /// The final stage of the CDN profile Standard Akamai or Standard Verizon endpoint definition.
    /// At this stage, any remaining optional settings can be specified, or the CDN profile endpoint
    /// definition can be attached to the parent CDN profile definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent CDN profile definition to return to after attaching this definition.</typeparam>
    public interface IWithStandardAttach<ParentT>  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IAttachableStandard<ParentT>
    {
        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">Content types to compress to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithContentTypesToCompress(ISet<string> contentTypesToCompress);

        /// <summary>
        /// Selects the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior);

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">HTTPS port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithHttpsPort(int httpsPort);

        /// <summary>
        /// Adds a single entry to the geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">A geo filter action.</param>
        /// <param name="countryCode">An ISO 2 letter country code.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode);

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode> countryCodes);

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithOriginPath(string originPath);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithHttpPort(int httpPort);

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithCustomDomain(string hostName);

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If true then compression will be enabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithCompressionEnabled(bool compressionEnabled);

        /// <summary>
        /// Specifies the geo filters to use.
        /// </summary>
        /// <param name="geoFilters">Geo filters.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithGeoFilters(IList<Microsoft.Azure.Management.Cdn.Fluent.Models.GeoFilter> geoFilters);

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A content type to compress to add to the list.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.IWithStandardAttach<ParentT> WithHostHeader(string hostHeader);
    }
}