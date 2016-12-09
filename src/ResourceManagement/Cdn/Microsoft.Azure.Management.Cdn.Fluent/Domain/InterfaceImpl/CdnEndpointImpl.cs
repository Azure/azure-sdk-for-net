// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading.Tasks;
    using CdnEndpoint.Definition.Blank.StandardEndpoint;
    using System.Collections.Generic;
    using System.Threading;
    using CdnEndpoint.UpdatePremiumEndpoint;
    using CdnProfile.Definition;
    using CdnEndpoint.Definition;
    using CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint;
    using CdnProfile.Update;
    using CdnEndpoint.Definition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint;
    using CdnEndpoint.UpdateStandardEndpoint;
    using CdnEndpoint.UpdateDefinition;
    using Models;

    internal partial class CdnEndpointImpl 
    {
        IUpdate CdnEndpoint.UpdateDefinition.IAttachablePremium<CdnProfile.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        IWithPremiumVerizonCreate CdnEndpoint.Definition.IAttachablePremium<IWithPremiumVerizonCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originName">Name of the origin.</param>
        /// <param name="originHostName">Origin host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate>.WithPremiumOrigin(string originName, string originHostName)
        {
            return this.WithPremiumOrigin(originName, originHostName) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originHostName">Origin host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate>.WithPremiumOrigin(string originHostName)
        {
            return this.WithPremiumOrigin(originHostName) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originName">Name of the origin.</param>
        /// <param name="originHostName">Origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithPremiumOrigin(string originName, string originHostName)
        {
            return this.WithPremiumOrigin(originName, originHostName) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originHostName">Origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithPremiumOrigin(string originHostName)
        {
            return this.WithPremiumOrigin(originHostName) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Forcibly purges current CDN endpoint content.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be purged. Can describe a file path or a wild card directory.</param>
        void ICdnEndpoint.PurgeContent(IList<string> contentPaths)
        {
 
            this.PurgeContent(contentPaths);
        }

        /// <return>Endpoint host name.</return>
        string ICdnEndpoint.HostName
        {
            get
            {
                return this.HostName;
            }
        }

        /// <return>Http port value.</return>
        int ICdnEndpoint.HttpPort
        {
            get
            {
                return this.HttpPort;
            }
        }

        /// <summary>
        /// Stops current running CDN endpoint.
        /// </summary>
        void ICdnEndpoint.Stop()
        {
 
            this.Stop();
        }

        /// <return>True if Http traffic is allowed, otherwise false.</return>
        bool ICdnEndpoint.IsHttpAllowed
        {
            get
            {
                return this.IsHttpAllowed;
            }
        }

        /// <return>List of Geo filters.</return>
        System.Collections.Generic.IList<GeoFilter> ICdnEndpoint.GeoFilters
        {
            get
            {
                return this.GeoFilters;
            }
        }

        /// <summary>
        /// Starts current stopped CDN endpoint.
        /// </summary>
        void ICdnEndpoint.Start()
        {
 
            this.Start();
        }
        
        /// <return>Endpoint provisioning state.</return>
        string ICdnEndpoint.ProvisioningState
        {
            get
            {
                return this.ProvisioningState;
            }
        }

        /// <summary>
        /// Forcibly pre-loads current CDN endpoint content. Available for Verizon Profiles.
        /// </summary>
        /// <param name="contentPaths">The path to the content to be loaded. Should describe a file path.</param>
        void ICdnEndpoint.LoadContent(IList<string> contentPaths)
        {
 
            this.LoadContent(contentPaths);
        }

        /// <return>True if Https traffic is allowed, otherwise false.</return>
        bool ICdnEndpoint.IsHttpsAllowed
        {
            get
            {
                return this.IsHttpsAllowed;
            }
        }

        /// <return>Https port value.</return>
        int ICdnEndpoint.HttpsPort
        {
            get
            {
                return this.HttpsPort;
            }
        }

        /// <return>List of content types to be compressed.</return>
        System.Collections.Generic.IList<string> ICdnEndpoint.ContentTypesToCompress
        {
            get
            {
                return this.ContentTypesToCompress;
            }
        }

        /// <return>True if content compression is enabled, otherwise false.</return>
        bool ICdnEndpoint.IsCompressionEnabled
        {
            get
            {
                return this.IsCompressionEnabled;
            }
        }

        /// <return>List of custom domains associated with current endpoint.</return>
        IReadOnlyCollection<string> ICdnEndpoint.CustomDomains
        {
            get
            {
                return this.CustomDomains;
            }
        }

        /// <return>Origin host name.</return>
        string ICdnEndpoint.OriginHostName
        {
            get
            {
                return this.OriginHostName;
            }
        }

        /// <return>Origin path.</return>
        string ICdnEndpoint.OriginPath
        {
            get
            {
                return this.OriginPath;
            }
        }

        /// <return>Origin host header.</return>
        string ICdnEndpoint.OriginHostHeader
        {
            get
            {
                return this.OriginHostHeader;
            }
        }

        /// <return>Query string caching behavior.</return>
        QueryStringCachingBehavior ICdnEndpoint.QueryStringCachingBehavior
        {
            get
            {
                return this.QueryStringCachingBehavior;
            }
        }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint.
        /// </summary>
        /// <param name="hostName">The host name of the custom domain. Must be a domain name.</param>
        /// <return>The CustomDomainValidationResult object if successful.</return>
        CustomDomainValidationResult ICdnEndpoint.ValidateCustomDomain(string hostName)
        {
            return this.ValidateCustomDomain(hostName) as CustomDomainValidationResult;
        }

        /// <return>Optimization type value.</return>
        string ICdnEndpoint.OptimizationType
        {
            get
            {
                return this.OptimizationType;
            }
        }

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            return this.WithQueryStringCachingBehavior(cachingBehavior) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <param name="geoFilters">The Geo filters list to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithGeoFilters(IList<GeoFilter> geoFilters)
        {
            return this.WithGeoFilters(geoFilters) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to compress to add to the list.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">The list of content types to compress to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            return this.WithContentTypesToCompress(contentTypesToCompress) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If set to true compression will be enabled. If set to false compression will be disabled.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithCompressionEnabled(bool compressionEnabled)
        {
            return this.WithCompressionEnabled(compressionEnabled) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a single entry to the Geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCode">The ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            return this.WithGeoFilter(relativePath, action, countryCode) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithGeoFilter(string relativePath, GeoFilterActions action, IList<CountryISOCode> countryCodes)
        {
            return this.WithGeoFilter(relativePath, action, countryCodes) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        IUpdate CdnEndpoint.UpdateDefinition.IAttachableStandard<IUpdate>.Attach()
        {
            return this.Attach();
        }

        IWithStandardCreate CdnEndpoint.Definition.IAttachableStandard<IWithStandardCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originName">Name of the origin.</param>
        /// <param name="originHostName">Origin host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate>.WithOrigin(string originName, string originHostName)
        {
            return this.WithOrigin(originName, originHostName) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originHostName">Origin host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate>.WithOrigin(string originHostName)
        {
            return this.WithOrigin(originHostName) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Removes the content type  to compress value from the list.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to remove from the list.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithoutContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            return this.WithQueryStringCachingBehavior(cachingBehavior) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <param name="geoFilters">The Geo filters list to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithGeoFilters(IList<GeoFilter> geoFilters)
        {
            return this.WithGeoFilters(geoFilters) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to compress to add to the list.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Clears entire list of content types to compress .
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutContentTypesToCompress()
        {
            return this.WithoutContentTypesToCompress() as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">The list of content types to compress to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            return this.WithContentTypesToCompress(contentTypesToCompress) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Removes an entry from the geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path value.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutGeoFilter(string relativePath)
        {
            return this.WithoutGeoFilter(relativePath) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If set to true compression will be enabled. If set to false compression will be disabled.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithCompressionEnabled(bool compressionEnabled)
        {
            return this.WithCompressionEnabled(compressionEnabled) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Clears entire geo filters list.
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutGeoFilters()
        {
            return this.WithoutGeoFilters() as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Adds a single entry to the Geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCode">The ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            return this.WithGeoFilter(relativePath, action, countryCode) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithGeoFilter(string relativePath, GeoFilterActions action, IList<CountryISOCode> countryCodes)
        {
            return this.WithGeoFilter(relativePath, action, countryCodes) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutCustomDomain(string hostName)
        {
            return this.WithoutCustomDomain(hostName) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithoutCustomDomain(string hostName)
        {
            return this.WithoutCustomDomain(hostName) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originName">Name of the origin.</param>
        /// <param name="originHostName">Origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate>.WithOrigin(string originName, string originHostName)
        {
            return this.WithOrigin(originName, originHostName) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies the origin of the CDN endpoint.
        /// </summary>
        /// <param name="originHostName">Origin hostname.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate>.WithOrigin(string originHostName)
        {
            return this.WithOrigin(originHostName) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            return this.WithQueryStringCachingBehavior(cachingBehavior) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies http port for http traffic.
        /// </summary>
        /// <param name="httpPort">Http port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <param name="geoFilters">The Geo filters list to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithGeoFilters(IList<GeoFilter> geoFilters)
        {
            return this.WithGeoFilters(geoFilters) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies https port for http traffic.
        /// </summary>
        /// <param name="httpsPort">Https port number.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A singe content type to compress to add to the list.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies the content types to compress.
        /// </summary>
        /// <param name="contentTypesToCompress">The list of content types to compress to set.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            return this.WithContentTypesToCompress(contentTypesToCompress) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies host header.
        /// </summary>
        /// <param name="hostHeader">Host header.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies if https traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies origin path.
        /// </summary>
        /// <param name="originPath">Origin path.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies if http traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If set to true Http traffic will be allowed.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If set to true compression will be enabled. If set to false compression will be disabled.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithCompressionEnabled(bool compressionEnabled)
        {
            return this.WithCompressionEnabled(compressionEnabled) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Adds a single entry to the Geo filters list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCode">The ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            return this.WithGeoFilter(relativePath, action, countryCode) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <param name="relativePath">The relative path.</param>
        /// <param name="action">The action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the endpoint definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithGeoFilter(string relativePath, GeoFilterActions action, IList<CountryISOCode> countryCodes)
        {
            return this.WithGeoFilter(relativePath, action, countryCodes) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }
    }
}