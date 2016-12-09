// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint
{
    using Microsoft.Azure.Management.Cdn.Fluent;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Update;
    using Models;
    using Resource.Fluent.Core;

    /// <summary>
    /// The stage of an CDN profile endpoint update allowing to specify endpoint properties.
    /// </summary>
    public interface IUpdateStandardEndpoint  :
        IUpdate
    {
        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">The list of content types to compress to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithContentTypesToCompress(IList<string> contentTypesToCompress);

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior);

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithHttpsPort(int httpsPort);

        /// <summary>
        /// Clears entire geo filters list.
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithoutGeoFilters();

        /// <summary>
        /// Removes an entry from the geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path value.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithoutGeoFilter(string relativePath);

        /// <summary>
        /// Removes the content type  to compress value from the list.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to remove from the list.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithoutContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Adds a single entry to the Geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCode">The ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode);

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithGeoFilter(string relativePath, GeoFilterActions action, IList<CountryISOCode> countryCodes);

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithOriginPath(string originPath);

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithHttpPort(int httpPort);

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithoutCustomDomain(string hostName);

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithCustomDomain(string hostName);

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If set to true compression will be enabled. If set to false compression will be disabled.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithCompressionEnabled(bool compressionEnabled);

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <param name="geoFilters">The Geo filters list to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithGeoFilters(IList<GeoFilter> geoFilters);

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to compress to add to the list.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IUpdateStandardEndpoint WithContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithHostHeader(string hostHeader);

        /// <summary>
        /// Clears entire list of content types to compress .
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        IUpdateStandardEndpoint WithoutContentTypesToCompress();
    }
}