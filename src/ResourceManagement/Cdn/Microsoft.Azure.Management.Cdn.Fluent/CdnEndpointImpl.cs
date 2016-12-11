// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using CdnEndpoint.UpdatePremiumEndpoint;
    using CdnEndpoint.UpdateStandardEndpoint;
    using CdnProfile.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using Resource.Fluent;
    using Resource.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for CdnEndpoint.
    /// </summary>
    internal partial class CdnEndpointImpl  :
        ExternalChildResource<ICdnEndpoint, EndpointInner, ICdnProfile, CdnProfileImpl>,
        ICdnEndpoint,
        CdnEndpoint.Definition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Definition.IWithStandardCreate>,
        CdnEndpoint.Definition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Definition.IWithPremiumVerizonCreate>,
        CdnEndpoint.Definition.IWithStandardAttach<CdnProfile.Definition.IWithStandardCreate>,
        CdnEndpoint.Definition.IWithPremiumAttach<CdnProfile.Definition.IWithPremiumVerizonCreate>,
        CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint.IStandardEndpoint<CdnProfile.Update.IUpdate>,
        CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint.IPremiumEndpoint<CdnProfile.Update.IUpdate>,
        CdnEndpoint.UpdateDefinition.IWithStandardAttach<CdnProfile.Update.IUpdate>,
        CdnEndpoint.UpdateDefinition.IWithPremiumAttach<CdnProfile.Update.IUpdate>,
        IUpdateStandardEndpoint,
        IUpdatePremiumEndpoint
    {
        private IEndpointsOperations client;
        private IOriginsOperations originsClient;
        private ICustomDomainsOperations customDomainsClient;
        private List<CustomDomainInner> customDomainList;
        private List<CustomDomainInner> deletedCustomDomainList;

        string IExternalChildResource<ICdnEndpoint, ICdnProfile>.Id
        {
            get
            {
                return this.Inner.Id;
            }
        }

        public IList<GeoFilter> GeoFilters
        {
            get
            {
                return this.Inner.GeoFilters;
            }
        }

        public string ResourceState
        {
            get
            {
                return this.Inner.ResourceState;
            }
        }

        public int HttpPort
        {
            get
            {
                if (this.Inner.Origins != null && this.Inner.Origins.Any() &&
                    this.Inner.Origins.ElementAt(0).HttpPort.HasValue)
                {
                    return this.Inner.Origins.ElementAt(0).HttpPort.Value;
                }
                return 0;
            }
        }


        public QueryStringCachingBehavior QueryStringCachingBehavior
        {
            get
            {
                return this.Inner.QueryStringCachingBehavior.Value;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return this.Inner.ProvisioningState;
            }
        }

        public bool IsCompressionEnabled
        {
            get
            {
                return (this.Inner.IsCompressionEnabled.HasValue) ? 
                    this.Inner.IsCompressionEnabled.Value : false;
            }
        }

        public string OriginHostHeader
        {
            get
            {
                return this.Inner.OriginHostHeader;
            }
        }

        public bool IsHttpsAllowed
        {
            get
            {
                return (this.Inner.IsHttpsAllowed.HasValue) ?
                    this.Inner.IsHttpsAllowed.Value : false;
            }
        }

        public string OptimizationType
        {
            get
            {
                return this.Inner.OptimizationType;
            }
        }

        public string HostName
        {
            get
            {
                return this.Inner.HostName;
            }
        }

        public string OriginHostName
        {
            get
            {
                if (this.Inner.Origins != null && this.Inner.Origins.Any())
                {
                    return this.Inner.Origins.ElementAt(0).HostName;
                }
                return null;
            }
        }

        public string OriginPath
        {
            get
            {
                return this.Inner.OriginPath;
            }
        }

        public int HttpsPort
        {
            get
            {
                if (this.Inner.Origins != null && this.Inner.Origins.Any() &&
                    this.Inner.Origins.ElementAt(0).HttpsPort.HasValue)
                {
                    return this.Inner.Origins.ElementAt(0).HttpsPort.Value;
                }
                return 0;
            }
        }

        public IList<string> ContentTypesToCompress
        {
            get
            {
                return this.Inner.ContentTypesToCompress;
            }
        }

        public bool IsHttpAllowed
        {
            get
            {
                return (this.Inner.IsHttpAllowed.HasValue) ?
                    this.Inner.IsHttpAllowed.Value : false;
            }
        }

        public IReadOnlyCollection<string> CustomDomains
        {
            get
            {
                return new ReadOnlyCollection<string>(this.customDomainList.Select(cd => cd.HostName).ToList());
            }
        }
        
        public CdnEndpointImpl WithOrigin(string originName, string hostname)
        {
            this.Inner.Origins.Add(
                new DeepCreatedOrigin
                {
                   Name = originName,
                   HostName = hostname
                });
            return this;
        }

        public CdnEndpointImpl WithOrigin(string hostname)
        {
            return this.WithOrigin("origin", hostname);
        }

        public CdnEndpointImpl WithPremiumOrigin(string originName, string hostname)
        {
            return this.WithOrigin(originName, hostname);
        }

        public CdnEndpointImpl WithPremiumOrigin(string hostname)
        {
            return this.WithOrigin(hostname);
        }

        public CdnEndpointImpl WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            this.Inner.QueryStringCachingBehavior = cachingBehavior;
            return this;
        }
                        
        public CdnEndpointImpl WithContentTypeToCompress(string contentTypeToCompress)
        {
            if (this.Inner.ContentTypesToCompress == null)
            {
                this.Inner.ContentTypesToCompress = new List<string>();
            }
            this.Inner.ContentTypesToCompress.Add(contentTypeToCompress);
            return this;
        }
        
        public CdnEndpointImpl WithHostHeader(string hostHeader)
        {
            this.Inner.OriginHostHeader = hostHeader;
            return this;
        }

        public CdnEndpointImpl WithoutContentTypesToCompress()
        {
            if (this.Inner.ContentTypesToCompress != null)
            {
                this.Inner.ContentTypesToCompress.Clear();
            }
            return this;
        }

        public CdnEndpointImpl WithHttpsAllowed(bool httpsAllowed)
        {
            this.Inner.IsHttpsAllowed = httpsAllowed;
            return this;
        }

        public CdnEndpointImpl WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            foreach (var contentType in contentTypesToCompress)
            {
                this.Inner.ContentTypesToCompress.Add(contentType);
            }
            return this;
        }

        public CdnEndpointImpl WithoutContentTypeToCompress(string contentTypeToCompress)
        {
            if(this.Inner.ContentTypesToCompress != null)
            {
                this.Inner.ContentTypesToCompress.Remove(contentTypeToCompress);
            }
            return this;
        }

        public CdnEndpointImpl WithHttpPort(int httpPort)
        {
            if (this.Inner.Origins != null && this.Inner.Origins.Any())
            {
                this.Inner.Origins.ElementAt(0).HttpPort = httpPort;
            }
            return this;
        }

        public CdnEndpointImpl WithHttpsPort(int httpsPort)
        {
            if (this.Inner.Origins != null && this.Inner.Origins.Any())
            {
                this.Inner.Origins.ElementAt(0).HttpsPort = httpsPort;
            }
            return this;
        }

        public CdnEndpointImpl WithoutGeoFilter(string relativePath)
        {
            if (this.Inner.GeoFilters != null && this.Inner.GeoFilters.Any())
            {
                var cleanList = this.Inner.GeoFilters
                    .Where(s => !s.RelativePath.Equals(relativePath, System.StringComparison.OrdinalIgnoreCase))
                    .ToList();
                this.Inner.GeoFilters = cleanList;
            }
            return this;
        }

        public CdnEndpointImpl WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            var geoFilter = this.CreateGeoFiltersObject(relativePath, action);

            if (geoFilter.CountryCodes == null)
            {
                geoFilter.CountryCodes = new List<string>();
            }
            geoFilter.CountryCodes.Add(countryCode.ToString());
            this.Inner.GeoFilters.Add(geoFilter);
            return this;
        }

        public CdnEndpointImpl WithGeoFilter(string relativePath, GeoFilterActions action, IList<CountryISOCode> countryCodes)
        {
            var geoFilter = this.CreateGeoFiltersObject(relativePath, action);

            if(geoFilter.CountryCodes == null)
            {
                geoFilter.CountryCodes = new List<string>();
            }
            else
            {
                geoFilter.CountryCodes.Clear();
            }
            foreach (var countryCode in countryCodes)
            {
                geoFilter.CountryCodes.Add(countryCode.ToString());
            }
            this.Inner.GeoFilters.Add(geoFilter);
            return this;
        }

        public CdnEndpointImpl WithoutGeoFilters()
        {
            if(this.Inner.GeoFilters != null)
            {
                this.Inner.GeoFilters.Clear();
            }
            return this;
        }

        public CdnEndpointImpl WithGeoFilters(IList<GeoFilter> geoFilters)
        {
            this.Inner.GeoFilters = geoFilters;
            return this;
        }

        public CdnEndpointImpl WithoutCustomDomain(string hostName)
        {
            if(this.customDomainList != null && this.customDomainList.Any())
            {
                var cleanList = this.customDomainList
                            .Where(s => 
                            {
                                if (s.HostName.Equals(hostName, System.StringComparison.OrdinalIgnoreCase))
                                {
                                    deletedCustomDomainList.Add(s);
                                    return false;
                                }
                                return true;
                            })
                            .ToList();
                this.customDomainList = cleanList;
            }
            return this;
        }

        public CdnEndpointImpl WithCustomDomain(string hostName)
        {
            if (this.customDomainList == null)
            {
                this.customDomainList = new List<CustomDomainInner>();
            }
            this.customDomainList.Add(new CustomDomainInner
                                            {
                                                HostName = hostName
                                            });

            return this;
        }

        public CdnEndpointImpl WithCompressionEnabled(bool compressionEnabled)
        {
            this.Inner.IsCompressionEnabled = compressionEnabled;
            return this;
        }
        
        public CdnEndpointImpl WithHttpAllowed(bool httpAllowed)
        {
            this.Inner.IsHttpAllowed = httpAllowed;
            return this;
        }
        
        public CdnEndpointImpl WithOriginPath(string originPath)
        {
            this.Inner.OriginPath = originPath;
            return this;
        }
        
        public CustomDomainValidationResult ValidateCustomDomain(string hostName)
        {
            return this.Parent.ValidateEndpointCustomDomain(this.Name(), hostName);
        }

        IUpdate ISettable<IUpdate>.Parent()
        {
            return this.Parent;
        }

        internal CdnEndpointImpl(
            string name,
            CdnProfileImpl parent,
            EndpointInner inner,
            IEndpointsOperations client,
            IOriginsOperations originsClient,
            ICustomDomainsOperations customDomainsClient)
            : base(name, parent, inner)
        {
            this.client = client;
            this.originsClient = originsClient;
            this.customDomainsClient = customDomainsClient;
            this.customDomainList = new List<CustomDomainInner>();
            this.deletedCustomDomainList = new List<CustomDomainInner>();

        }
        
        public void PurgeContent(IList<string> contentPaths)
        {
            this.Parent.PurgeEndpointContent(this.Name(), contentPaths);
        }

        public void LoadContent(IList<string> contentPaths)
        {
            this.Parent.LoadEndpointContent(this.Name(), contentPaths);
        }

        public void Stop()
        {
            this.Parent.StopEndpoint(this.Name());
        }

        public void Start()
        {
            this.Parent.StartEndpoint(this.Name());
        }

        public CdnProfileImpl Attach()
        {
            return this.Parent.WithEndpoint(this);
        }

        public ICdnEndpoint Refresh()
        {
            EndpointInner inner = this.client.Get(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name());
            this.SetInner(inner);
            this.customDomainList.Clear();
            this.deletedCustomDomainList.Clear();
            this.customDomainList.AddRange(
                this.customDomainsClient.ListByEndpoint(
                    this.Parent.ResourceGroupName,
                    this.Parent.Name,
                    this.Name()));
            return this;
        }
        
        private GeoFilter CreateGeoFiltersObject(string relativePath, GeoFilterActions action)
        {
            if (this.Inner.GeoFilters == null)
            {
                this.Inner.GeoFilters = new List<GeoFilter>();
            }
            var geoFilter = this.Inner.GeoFilters
                .FirstOrDefault(s => s.RelativePath.Equals(
                    relativePath, 
                    System.StringComparison.OrdinalIgnoreCase));

            if (geoFilter == null)
            {
                geoFilter = new GeoFilter();
            }
            else
            {
                this.Inner.GeoFilters.Remove(geoFilter);
            }
            geoFilter.RelativePath = relativePath;
            geoFilter.Action = action;
            return geoFilter;
        }

        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.client.DeleteAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                cancellationToken);
        }

        public async override Task<ICdnEndpoint> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var endpointInner = await this.client.CreateAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                this.Inner,
                cancellationToken);
            this.SetInner(endpointInner);
            
            foreach (var itemToCreate in this.customDomainList)
            {
                await this.customDomainsClient.CreateAsync(
                    this.Parent.ResourceGroupName,
                    this.Parent.Name,
                    this.Name(),
                    ResourceNamer.RandomResourceName("CustomDomain", 50),
                    itemToCreate.HostName,
                    cancellationToken);
            }

            this.customDomainList.Clear();
            this.customDomainList.AddRange(
                await this.customDomainsClient.ListByEndpointAsync(
                    this.Parent.ResourceGroupName,
                    this.Parent.Name,
                    this.Name(),
                    cancellationToken));
            return this;
        }

        public async override Task<ICdnEndpoint> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            EndpointUpdateParametersInner updateInner = new EndpointUpdateParametersInner
                                                        {
                                                            IsHttpAllowed = this.Inner.IsHttpAllowed,
                                                            IsHttpsAllowed = this.Inner.IsHttpsAllowed,
                                                            OriginPath = this.Inner.OriginPath,
                                                            OriginHostHeader = this.Inner.OriginHostHeader,
                                                            IsCompressionEnabled = this.Inner.IsCompressionEnabled,
                                                            ContentTypesToCompress = this.Inner.ContentTypesToCompress,
                                                            GeoFilters = this.Inner.GeoFilters,
                                                            OptimizationType = this.Inner.OptimizationType,
                                                            QueryStringCachingBehavior = this.Inner.QueryStringCachingBehavior,
                                                            Tags = this.Inner.Tags
                                                        };
            
            DeepCreatedOrigin originInner = this.Inner.Origins.ElementAt(0);
            OriginUpdateParametersInner originParameters = new OriginUpdateParametersInner
                                                            {
                                                                HostName = originInner.HostName,
                                                                HttpPort = originInner.HttpPort,
                                                                HttpsPort = originInner.HttpsPort
                                                            };


            await Task.WhenAll(this.deletedCustomDomainList
                .Select(itemToDelete => this.customDomainsClient.DeleteAsync(
                    this.Parent.ResourceGroupName,
                    this.Parent.Name,
                    this.Name(),
                    itemToDelete.Name)));

            this.deletedCustomDomainList.Clear();

            await this.originsClient.UpdateAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                originInner.Name,
                originParameters);

            var endpointInner = await this.client.UpdateAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                updateInner);
            this.SetInner(endpointInner);

            return this;
        }
    }
}