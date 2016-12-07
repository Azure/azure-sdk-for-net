// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition
{
    using Microsoft.Azure.Management.Cdn.Fluent;
    using System.Collections.Generic;
    using Models;
    using Resource.Fluent.Core;

    /// <summary>
    /// The final stage of the CDN profile Standard Akamai or Standard Verizon endpoint definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the CDN profile endpoint
    /// definition can be attached to the parent CDN profile definition using CdnEndpoint.DefinitionStages.AttachableStandard.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of CdnEndpoint.DefinitionStages.AttachableStandard.attach().</typeparam>
    public interface IWithStandardAttach<ParentT>  :
        IAttachableStandard<ParentT>
    {
        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">The list of content types to compress to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithContentTypesToCompress(IList<string> contentTypesToCompress);

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior);

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithHttpsPort(int httpsPort);

        /// <summary>
        /// Adds a single entry to the Geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCode">The ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode);

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithGeoFilter(string relativePath, GeoFilterActions action, IList<CountryISOCode> countryCodes);

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithOriginPath(string originPath);

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithHttpPort(int httpPort);

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithCustomDomain(string hostName);

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If set to true compression will be enabled. If set to false compression will be disabled.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithCompressionEnabled(bool compressionEnabled);

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <param name="geoFilters">The Geo filters list to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithGeoFilters(IList<GeoFilter> geoFilters);

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to compress to add to the list.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithContentTypeToCompress(string contentTypeToCompress);

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithStandardAttach<ParentT> WithHostHeader(string hostHeader);
    }

    /// <summary>
    /// The first stage of a CDN profile endpoint definition.
    /// </summary>
    public interface IBlank 
    {
    }

    /// <summary>
    /// The final stage of the Standard endpoint object definition, at which it can be attached to the parent, using AttachableStandard.attach().
    /// </summary>
    /// <typeparam name="Parent">The parent definition AttachableStandard.attach() returns to.</typeparam>
    public interface IAttachableStandard<ParentT> 
    {
        ParentT Attach { get; }
    }

    /// <summary>
    /// The final stage of the CDN profile Premium Verizon endpoint definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the CDN profile endpoint
    /// definition can be attached to the parent CDN profile definition using CdnEndpoint.DefinitionStages.AttachablePremium.attach().
    /// </summary>
    /// <typeparam name="Parent">The return type of CdnEndpoint.DefinitionStages.AttachablePremium.attach().</typeparam>
    public interface IWithPremiumAttach<ParentT>  :
        IAttachablePremium<ParentT>
    {
        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithHttpsAllowed(bool httpsAllowed);

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithHttpPort(int httpPort);

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithCustomDomain(string hostName);

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithHttpsPort(int httpsPort);

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithHttpAllowed(bool httpAllowed);

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithOriginPath(string originPath);

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint definition.</return>
        IWithPremiumAttach<ParentT> WithHostHeader(string hostHeader);
    }

    /// <summary>
    /// The final stage of the Premium Verizon endpoint object definition, at which it can be attached to the parent, using AttachableStandard.attach().
    /// </summary>
    /// <typeparam name="Parent">The parent definition AttachableStandard.attach() returns to.</typeparam>
    public interface IAttachablePremium<ParentT> 
    {
        ParentT Attach { get; }
    }
}