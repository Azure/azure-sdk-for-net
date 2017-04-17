// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.Definition.Blank.StandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdatePremiumEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnEndpoint.UpdateStandardEndpoint;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Definition;
    using Microsoft.Azure.Management.Cdn.Fluent.CdnProfile.Update;
    using Microsoft.Azure.Management.Cdn.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    internal partial class CdnEndpointImpl 
    {
        /// <summary>
        /// Attaches the endpoint definition to the parent CDN profile update.
        /// </summary>
        /// <return>The stage of the parent CDN profile update to return to after attaching this definition.</return>
        CdnProfile.Update.IUpdate CdnEndpoint.UpdateDefinition.IAttachablePremium<CdnProfile.Update.IUpdate>.Attach()
        {
            return this.Attach() as CdnProfile.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the defined endpoint to the parent CDN profile.
        /// </summary>
        /// <return>The stage of the parent CDN profile definition to return to after attaching this definition.</return>
        CdnProfile.Definition.IWithPremiumVerizonCreate CdnEndpoint.Definition.IAttachablePremium<CdnProfile.Definition.IWithPremiumVerizonCreate>.Attach()
        {
            return this.Attach() as CdnProfile.Definition.IWithPremiumVerizonCreate;
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
        /// Forcibly purges the content of the CDN endpoint.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.PurgeContent(IList<string> contentPaths)
        {
 
            this.PurgeContentAsync(contentPaths).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets endpoint host name.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        /// <summary>
        /// Gets HTTP port value.
        /// </summary>
        int Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.HttpPort
        {
            get
            {
                return this.HttpPort();
            }
        }

        /// <summary>
        /// Checks the quota and usage of geo filters and custom domains under the current endpoint.
        /// </summary>
        /// <return>List of quotas and usages of geo filters and custom domains under the current endpoint.</return>
        System.Collections.Generic.IEnumerable<ResourceUsage> Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.ListResourceUsage()
        {
            return this.ListResourceUsage();
        }

        /// <summary>
        /// Stops the CDN endpoint, if it is running.
        /// </summary>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.Stop()
        {
 
            this.StopAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets true if HTTP traffic is allowed, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.IsHttpAllowed
        {
            get
            {
                return this.IsHttpAllowed();
            }
        }

        /// <summary>
        /// Gets list of Geo filters.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Models.GeoFilter> Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.GeoFilters
        {
            get
            {
                return this.GeoFilters() as System.Collections.Generic.IReadOnlyList<Models.GeoFilter>;
            }
        }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="hostName">The host name, which must be a domain name, of the custom domain.</param>
        /// <return>An observable of the result.</return>
        async Task<Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult> Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.ValidateCustomDomainAsync(string hostName, CancellationToken cancellationToken)
        {
            return await this.ValidateCustomDomainAsync(hostName, cancellationToken) as Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult;
        }

        /// <summary>
        /// Gets endpoint state.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.ResourceState
        {
            get
            {
                return this.ResourceState();
            }
        }

        /// <summary>
        /// Starts the CDN endpoint, if it is stopped.
        /// </summary>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.Start()
        {

            this.StartAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets endpoint provisioning state.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Starts the CDN endpoint asynchronously, if it is stopped.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.StartAsync(CancellationToken cancellationToken)
        {
 
            await this.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        void Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.LoadContent(IList<string> contentPaths)
        {
            this.LoadContentAsync(contentPaths).GetAwaiter().GetResult(); 
        }

        /// <summary>
        /// Gets true if HTTPS traffic is allowed, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.IsHttpsAllowed
        {
            get
            {
                return this.IsHttpsAllowed();
            }
        }

        /// <summary>
        /// Gets HTTPS port value.
        /// </summary>
        int Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.HttpsPort
        {
            get
            {
                return this.HttpsPort();
            }
        }

        /// <remarks>
        /// Gets (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <summary>
        /// Gets list of content types to be compressed.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.ContentTypesToCompress
        {
            get
            {
                return this.ContentTypesToCompress() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Stops the CDN endpoint asynchronously, if it is running.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.StopAsync(CancellationToken cancellationToken)
        {
 
            await this.StopAsync(cancellationToken);
        }

        /// <summary>
        /// Gets true if content compression is enabled, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.IsCompressionEnabled
        {
            get
            {
                return this.IsCompressionEnabled();
            }
        }

        /// <summary>
        /// Forcibly purges the content of the CDN endpoint asynchronously.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The paths to the content to be purged, which can be file paths or directory wild cards.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.PurgeContentAsync(IList<string> contentPaths, CancellationToken cancellationToken)
        {
 
            await this.PurgeContentAsync(contentPaths, cancellationToken);
        }

        /// <remarks>
        /// Gets (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <summary>
        /// Gets list of custom domains associated with this endpoint.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.CustomDomains
        {
            get
            {
                return this.CustomDomains() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets origin host name.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.OriginHostName
        {
            get
            {
                return this.OriginHostName();
            }
        }

        /// <summary>
        /// Gets origin path.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.OriginPath
        {
            get
            {
                return this.OriginPath();
            }
        }

        /// <summary>
        /// Forcibly preloads the content of the CDN endpoint asynchronously.
        /// Note: this is supported for Verizon profiles only.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="contentPaths">The file paths to the content to be loaded.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.LoadContentAsync(IList<string> contentPaths, CancellationToken cancellationToken)
        {
 
            await this.LoadContentAsync(contentPaths, cancellationToken);
        }

        /// <summary>
        /// Gets origin host header.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.OriginHostHeader
        {
            get
            {
                return this.OriginHostHeader();
            }
        }

        /// <summary>
        /// Gets query string caching behavior.
        /// </summary>
        Models.QueryStringCachingBehavior Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.QueryStringCachingBehavior
        {
            get
            {
                return this.QueryStringCachingBehavior();
            }
        }

        /// <summary>
        /// Validates a custom domain mapping to ensure it maps to the correct CNAME in DNS for current endpoint.
        /// </summary>
        /// <param name="hostName">The host name, which must be a domain name, of the custom domain.</param>
        /// <return>The result of the action, if successful.</return>
        Microsoft.Azure.Management.Cdn.Fluent.CustomDomainValidationResult Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.ValidateCustomDomain(string hostName)
        {
            return this.ValidateCustomDomainAsync(hostName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets optimization type.
        /// </summary>
        string Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint.OptimizationType
        {
            get
            {
                return this.OptimizationType();
            }
        }

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">A query string caching behavior.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            return this.WithQueryStringCachingBehavior(cachingBehavior) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

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
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithGeoFilters(IList<Models.GeoFilter> geoFilters)
        {
            return this.WithGeoFilters(geoFilters) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A single content type to compress to add to the list.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

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
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            return this.WithContentTypesToCompress(contentTypesToCompress) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If true then compression will be enabled, else disabled.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithCompressionEnabled(bool compressionEnabled)
        {
            return this.WithCompressionEnabled(compressionEnabled) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a single entry to the geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action.</param>
        /// <param name="countryCode">An ISO 2 letter country code.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            return this.WithGeoFilter(relativePath, action, countryCode) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

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
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>.WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode> countryCodes)
        {
            return this.WithGeoFilter(relativePath, action, countryCodes) as CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Attaches the endpoint definition to the parent CDN profile update.
        /// </summary>
        /// <return>The stage of the parent CDN profile update to return to after attaching this definition.</return>
        CdnProfile.Update.IUpdate CdnEndpoint.UpdateDefinition.IAttachableStandard<CdnProfile.Update.IUpdate>.Attach()
        {
            return this.Attach() as CdnProfile.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the defined endpoint to the parent CDN profile.
        /// </summary>
        /// <return>The stage of the parent CDN profile definition to return to after attaching this definition.</return>
        CdnProfile.Definition.IWithStandardCreate CdnEndpoint.Definition.IAttachableStandard<CdnProfile.Definition.IWithStandardCreate>.Attach()
        {
            return this.Attach() as CdnProfile.Definition.IWithStandardCreate;
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
        /// Removes the content type to compress from the list.
        /// </summary>
        /// <param name="contentTypeToCompress">A single content type to remove from the list.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithoutContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the query string caching behavior.
        /// </summary>
        /// <param name="cachingBehavior">The query string caching behavior value to set.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            return this.WithQueryStringCachingBehavior(cachingBehavior) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the geo filters list.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="geoFilters">A geo filters list.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithGeoFilters(IList<Models.GeoFilter> geoFilters)
        {
            return this.WithGeoFilters(geoFilters) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A single content type to compress to add to the list.</param>
        /// <return>The next stage of the definition.</return>
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
        /// Clears entire list of content types to compress.
        /// </summary>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutContentTypesToCompress()
        {
            return this.WithoutContentTypesToCompress() as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

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
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            return this.WithContentTypesToCompress(contentTypesToCompress) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Removes an entry from the geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutGeoFilter(string relativePath)
        {
            return this.WithoutGeoFilter(relativePath) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If true then compression will be enabled.</param>
        /// <return>The next stage of the definition.</return>
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
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action.</param>
        /// <param name="countryCode">An ISO 2 letter country code.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            return this.WithGeoFilter(relativePath, action, countryCode) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

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
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode> countryCodes)
        {
            return this.WithGeoFilter(relativePath, action, countryCodes) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint.WithoutCustomDomain(string hostName)
        {
            return this.WithoutCustomDomain(hostName) as CdnEndpoint.UpdateStandardEndpoint.IUpdateStandardEndpoint;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Removes CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the endpoint update.</return>
        CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint.WithoutCustomDomain(string hostName)
        {
            return this.WithoutCustomDomain(hostName) as CdnEndpoint.UpdatePremiumEndpoint.IUpdatePremiumEndpoint;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">Custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate> CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain for the endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If true then HTTPS traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate> CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>;
        }

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true, then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
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
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            return this.WithQueryStringCachingBehavior(cachingBehavior) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies the port for HTTP traffic.
        /// </summary>
        /// <param name="httpPort">A port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpPort(int httpPort)
        {
            return this.WithHttpPort(httpPort) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

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
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithGeoFilters(IList<Models.GeoFilter> geoFilters)
        {
            return this.WithGeoFilters(geoFilters) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies the port for HTTPS traffic.
        /// </summary>
        /// <param name="httpsPort">HTTPS port number.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpsPort(int httpsPort)
        {
            return this.WithHttpsPort(httpsPort) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies a single content type to compress.
        /// </summary>
        /// <param name="contentTypeToCompress">A content type to compress to add to the list.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithContentTypeToCompress(string contentTypeToCompress)
        {
            return this.WithContentTypeToCompress(contentTypeToCompress) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Adds a new CDN custom domain within an endpoint.
        /// </summary>
        /// <param name="hostName">A custom domain host name.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithCustomDomain(string hostName)
        {
            return this.WithCustomDomain(hostName) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

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
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            return this.WithContentTypesToCompress(contentTypesToCompress) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies the host header.
        /// </summary>
        /// <param name="hostHeader">A host header.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHostHeader(string hostHeader)
        {
            return this.WithHostHeader(hostHeader) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies if HTTPS traffic is allowed.
        /// </summary>
        /// <param name="httpsAllowed">If set to true Https traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpsAllowed(bool httpsAllowed)
        {
            return this.WithHttpsAllowed(httpsAllowed) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies the origin path.
        /// </summary>
        /// <param name="originPath">An origin path.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithOriginPath(string originPath)
        {
            return this.WithOriginPath(originPath) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Specifies if HTTP traffic is allowed.
        /// </summary>
        /// <param name="httpAllowed">If true then HTTP traffic will be allowed.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithHttpAllowed(bool httpAllowed)
        {
            return this.WithHttpAllowed(httpAllowed) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Sets the compression state.
        /// </summary>
        /// <param name="compressionEnabled">If true then compression will be enabled.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithCompressionEnabled(bool compressionEnabled)
        {
            return this.WithCompressionEnabled(compressionEnabled) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Adds a single entry to the geo filters list.
        /// </summary>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">A geo filter action.</param>
        /// <param name="countryCode">An ISO 2 letter country code.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            return this.WithGeoFilter(relativePath, action, countryCode) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }

        /// <summary>
        /// Sets the geo filters list for the specified countries list.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="relativePath">A relative path.</param>
        /// <param name="action">An action value.</param>
        /// <param name="countryCodes">A list of the ISO 2 letter country codes.</param>
        /// <return>The next stage of the definition.</return>
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate> CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>.WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.ResourceManager.Fluent.Core.CountryISOCode> countryCodes)
        {
            return this.WithGeoFilter(relativePath, action, countryCodes) as CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>;
        }
    }
}