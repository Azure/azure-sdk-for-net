// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint
{
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The stage of an CDN profile endpoint update allowing to specify endpoint properties.
    /// </summary>
    public interface IUpdateStandardEndpoint  :
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update.IUpdate
    {
        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">Content types to compress to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithContentTypesToCompress(ISet<string> contentTypesToCompress);

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithHttpsPort(int httpsPort);

        /// <summary>
        /// Clears entire geo filters list.
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithoutGeoFilters();

        /// <summary>
        /// Removes an entry from the geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithoutGeoFilter(string relativePath);

        /// <summary>
        /// Removes the content type to compress from the list.
        /// </summary>
        /// <param name="contentTypeToCompress">A single content type to remove from the list.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithoutContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Adds a single entry to the Geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action.</param>
        /// <param name="countryCode">An ISO 2 letter country code.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode);

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action.</param>
        /// <param name="countryCodes">A list of ISO 2 letter country codes.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode> countryCodes);

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithOriginPath(string originPath);

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithHttpPort(int httpPort);

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithoutCustomDomain(string hostName);

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithCustomDomain(string hostName);

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If true then compression will be enabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithCompressionEnabled(bool compressionEnabled);

        /// <summary>
        /// Specifies the geo filters to use.
        /// </summary>
        /// <param name="geoFilters">Geo filters.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithGeoFilters(IList<Microsoft.Azure.Management.Cdn.Fluent.Models.GeoFilter> geoFilters);

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A single content type to compress to add to the list.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithHostHeader(string hostHeader);

        /// <summary>
        /// Clears entire list of content types to compress.
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint WithoutContentTypesToCompress();
    }
}