// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Cdn.Fluent
{
    using CdnEndpoint.Definition.Blank.StandardEndpoint;
    using System.Collections.Generic;
    using System.Threading;
    using CdnEndpoint.UpdatePremiumEndpoint;
    using CdnProfile.Definition;
    using CdnEndpoint.Definition;
    using CdnEndpoint.UpdateDefinition.Blank.StandardEndpoint;
    using System.Threading.Tasks;
    using CdnProfile.Update;
    using CdnEndpoint.Definition.Blank.PremiumEndpoint;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using CdnEndpoint.UpdateDefinition.Blank.PremiumEndpoint;
    using CdnEndpoint.UpdateStandardEndpoint;
    using CdnEndpoint.UpdateDefinition;
    using Models;
    using Resource.Fluent.Core.ResourceActions;
    using System.Linq;
    using Resource.Fluent.Core.ChildResourceActions;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Implementation for CdnEndpoint.
    /// </summary>
    public partial class CdnEndpointImpl  :
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
        private IList<CustomDomainInner> customDomainList;
        private IList<CustomDomainInner> deletedCustomDomainList;

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
        
        public CdnEndpointImpl WithoutGeoFilter(string relativePath)
        {
            //$ for (Iterator<GeoFilter> iter = this.Inner.GeoFilters().ListIterator(); iter.HasNext();) {
            //$ GeoFilter geoFilter = iter.Next();
            //$ if (geoFilter.RelativePath().Equals(relativePath)) {
            //$ iter.Remove();
            //$ }
            //$ }
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithHttpsAllowed(bool httpsAllowed)
        {
            //$ this.Inner.WithIsHttpsAllowed(httpsAllowed);
            //$ return this;

            return this;
        }
        
        public CdnEndpointImpl WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            //$ this.Inner.WithContentTypesToCompress(contentTypesToCompress);
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithGeoFilter(string relativePath, GeoFilterActions action, CountryISOCode countryCode)
        {
            //$ GeoFilter geoFilter = this.CreateGeoFiltersObject(relativePath, action);
            //$ 
            //$ if (geoFilter.CountryCodes() == null) {
            //$ geoFilter.WithCountryCodes(new ArrayList<String>());
            //$ }
            //$ geoFilter.CountryCodes().Add(countryCode.ToString());
            //$ 
            //$ this.Inner.GeoFilters().Add(geoFilter);
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.Resource.Fluent.Core.CountryISOCode> countryCodes)
        {
            //$ GeoFilter geoFilter = this.CreateGeoFiltersObject(relativePath, action);
            //$ 
            //$ if (geoFilter.CountryCodes() == null) {
            //$ geoFilter.WithCountryCodes(new ArrayList<String>());
            //$ } else {
            //$ geoFilter.CountryCodes().IsEmpty();
            //$ }
            //$ 
            //$ foreach(var countryCode in countryCodes)  {
            //$ geoFilter.CountryCodes().Add(countryCode.ToString());
            //$ }
            //$ 
            //$ this.Inner.GeoFilters().Add(geoFilter);
            //$ return this;

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

        public CdnEndpointImpl WithoutCustomDomain(string hostName)
        {
            //$ for (Iterator<CustomDomainInner> iter = this.customDomainList.ListIterator(); iter.HasNext();) {
            //$ CustomDomainInner customDomain = iter.Next();
            //$ if (hostName.Equals(customDomain.HostName())) {
            //$ iter.Remove();
            //$ deletedCustomDomainList.Add(customDomain);
            //$ }
            //$ }
            //$ return this;

            return this;
        }
        
        public CdnEndpointImpl WithCompressionEnabled(bool compressionEnabled)
        {
            //$ this.Inner.WithIsCompressionEnabled(compressionEnabled);
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithoutGeoFilters()
        {
            //$ if (this.Inner.GeoFilters() != null) {
            //$ this.Inner.GeoFilters().Clear();
            //$ }
            //$ return this;

            return this;
        }
        
        public CdnEndpointImpl WithGeoFilters(IList<GeoFilter> geoFilters)
        {
            //$ this.Inner.WithGeoFilters(geoFilters);
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithHttpAllowed(bool httpAllowed)
        {
            //$ this.Inner.WithIsHttpAllowed(httpAllowed);
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithoutContentTypeToCompress(string contentTypeToCompress)
        {
            //$ if (this.Inner.ContentTypesToCompress() != null) {
            //$ this.Inner.ContentTypesToCompress().Remove(contentTypeToCompress);
            //$ }
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithOriginPath(string originPath)
        {
            //$ this.Inner.WithOriginPath(originPath);
            //$ return this;

            return this;
        }

        public CdnEndpointImpl WithCustomDomain(string hostName)
        {
            //$ if (this.customDomainList != null) {
            //$ this.customDomainList.Add(new CustomDomainInner().WithHostName(hostName));
            //$ }
            //$ return this;

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

        public CdnProfileImpl Attach()
        {
            //$ return this.Parent().WithEndpoint(this);

            return null;
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
            //$ this.Parent().StopEndpoint(this.Name());

        }

        public void Start()
        {
            //$ this.Parent().StartEndpoint(this.Name());

        }

        public ICdnEndpoint Refresh()
        {
            //$ EndpointInner inner = this.client.Get(this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name());
            //$ this.SetInner(inner);
            //$ this.customDomainList.Clear();
            //$ this.deletedCustomDomainList.Clear();
            //$ this.customDomainList.AddAll(this.customDomainsClient.ListByEndpoint(
            //$ this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name()));
            //$ return this;

            return this;
        }
        
        internal  CdnEndpointImpl(
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
        
        private GeoFilter CreateGeoFiltersObject(string relativePath, GeoFilterActions action)
        {
            //$ if (this.Inner.GeoFilters() == null) {
            //$ this.Inner.WithGeoFilters(new ArrayList<GeoFilter>());
            //$ }
            //$ GeoFilter geoFilter = null;
            //$ foreach(var filter in this.Inner.GeoFilters())  {
            //$ if (filter.RelativePath().Equals(relativePath)) {
            //$ geoFilter = filter;
            //$ break;
            //$ }
            //$ }
            //$ if (geoFilter == null) {
            //$ geoFilter = new GeoFilter();
            //$ }
            //$ else {
            //$ this.Inner.GeoFilters().Remove(geoFilter);
            //$ }
            //$ geoFilter.WithRelativePath(relativePath)
            //$ .WithAction(action);
            //$ 
            //$ return geoFilter;
            //$ }

            return null;
        }
        
        public async override Task<ICdnEndpoint> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ CdnEndpointImpl self = this;
            //$ return this.client.CreateAsync(this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name(),
            //$ this.Inner)
            //$ .Map(new Func1<EndpointInner, CdnEndpoint>() {
            //$ @Override
            //$ public CdnEndpoint call(EndpointInner inner) {
            //$ self.SetInner(inner);
            //$ foreach(var itemToCreate in self.CustomDomainList)  {
            //$ self.CustomDomainsClient.Create(
            //$ self.Parent().ResourceGroupName(),
            //$ self.Parent().Name(),
            //$ self.Name(),
            //$ ResourceNamer.RandomResourceName("CustomDomain", 50),
            //$ itemToCreate.HostName());
            //$ }
            //$ self.CustomDomainList.Clear();
            //$ self.CustomDomainList.AddAll(self.CustomDomainsClient.ListByEndpoint(
            //$ self.Parent().ResourceGroupName(),
            //$ self.Parent().Name(),
            //$ self.Name()));
            //$ return self;
            //$ }
            //$ });

            return null;
        }

        public async override Task<ICdnEndpoint> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ CdnEndpointImpl self = this;
            //$ EndpointUpdateParametersInner updateInner = new EndpointUpdateParametersInner();
            //$ updateInner.WithIsHttpAllowed(this.Inner.IsHttpAllowed())
            //$ .WithIsHttpsAllowed(this.Inner.IsHttpsAllowed())
            //$ .WithOriginPath(this.Inner.OriginPath())
            //$ .WithOriginHostHeader(this.Inner.OriginHostHeader())
            //$ .WithIsCompressionEnabled(this.Inner.IsCompressionEnabled())
            //$ .WithContentTypesToCompress(this.Inner.ContentTypesToCompress())
            //$ .WithGeoFilters(this.Inner.GeoFilters())
            //$ .WithOptimizationType(this.Inner.OptimizationType())
            //$ .WithQueryStringCachingBehavior(this.Inner.QueryStringCachingBehavior())
            //$ .WithTags(this.Inner.GetTags());
            //$ 
            //$ DeepCreatedOrigin originInner = this.Inner.Origins().Get(0);
            //$ OriginUpdateParametersInner originParameters = new OriginUpdateParametersInner()
            //$ .WithHostName(originInner.HostName())
            //$ .WithHttpPort(originInner.HttpPort())
            //$ .WithHttpsPort(originInner.HttpsPort());
            //$ 
            //$ Observable<OriginInner> originObservable = this.originsClient.UpdateAsync(
            //$ this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name(),
            //$ originInner.Name(),
            //$ originParameters);
            //$ 
            //$ Observable<CdnEndpoint> endpointObservable = this.client.UpdateAsync(
            //$ this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name(),
            //$ updateInner)
            //$ .Map(new Func1<EndpointInner, CdnEndpoint>() {
            //$ @Override
            //$ public CdnEndpoint call(EndpointInner inner) {
            //$ self.SetInner(inner);
            //$ return self;
            //$ }
            //$ });
            //$ 
            //$ List<Observable<CustomDomainInner>> customDomainDeleteObservables = new ArrayList<>();
            //$ 
            //$ foreach(var itemToDelete in this.deletedCustomDomainList)  {
            //$ customDomainDeleteObservables.Add(this.customDomainsClient.DeleteAsync(
            //$ this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name(),
            //$ itemToDelete.Name()));
            //$ }
            //$ Observable<CustomDomainInner> deleteObservable = Observable.Zip(customDomainDeleteObservables, new FuncN<CustomDomainInner>() {
            //$ @Override
            //$ public CustomDomainInner call(Object... objects) {
            //$ return null;
            //$ }
            //$ });
            //$ 
            //$ return Observable.Zip(
            //$ originObservable,
            //$ endpointObservable,
            //$ deleteObservable,
            //$ new Func3<OriginInner, CdnEndpoint, CustomDomainInner, CdnEndpoint>() {
            //$ @Override
            //$ public CdnEndpoint call(OriginInner originInner, CdnEndpoint cdnEndpoint, CustomDomainInner customDomain) {
            //$ return cdnEndpoint;
            //$ }
            //$ }).DoOnNext(new Action1<CdnEndpoint>() {
            //$ @Override
            //$ public void call(CdnEndpoint cdnEndpoint) {
            //$ self.DeletedCustomDomainList.Clear();
            //$ }
            //$ });

            return null;
        }

        public async override Task DeleteAsync(CancellationToken cancellationToke)
        {
            //$ return this.client.DeleteAsync(this.Parent().ResourceGroupName(),
            //$ this.Parent().Name(),
            //$ this.Name()).Map(new Func1<Void, Void>() {
            //$ @Override
            //$ public Void call(Void result) {
            //$ return result;
            //$ }
            //$ });
            /*

            await this.client.DeleteAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name,
                cancellationToken);
             */
        }
    }
}