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
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for CdnEndpoint.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNkbi5pbXBsZW1lbnRhdGlvbi5DZG5FbmRwb2ludEltcGw=
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

        ///GENMHASH:5E567D525C2D1A4E96F5EDCE712176A4:E661050B2228F0D19D27F5E798A9AAED
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

        ///GENMHASH:21CB0BD3DBCE4F803F8717FE67D484A9:5C329AC5714B2CF2EDE8689B96916F37
        public CdnEndpointImpl WithOrigin(string hostname)
        {
            return this.WithOrigin("origin", hostname);
        }
		
        ///GENMHASH:18D91A64C4BA864D24E2DE4DD2523297:08F121BA4E95C8CA8A60DE2B6D8A259A
        public CdnEndpointImpl WithQueryStringCachingBehavior(QueryStringCachingBehavior cachingBehavior)
        {
            this.Inner.QueryStringCachingBehavior = cachingBehavior;
            return this;
        }

        ///GENMHASH:BA650B492EF1E2A3A4C8226C4A669B7F:3DDBCC9A4C358BBA941924D7644F0538
        public CdnEndpointImpl WithHttpsPort(int httpsPort)
        {
            if (this.Inner.Origins != null && this.Inner.Origins.Any())
            {
                this.Inner.Origins.ElementAt(0).HttpsPort = httpsPort;
            }
            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:947989B0DEAD5D70EE77D478831B3C67
        public async override Task<Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
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
                    SharedSettings.RandomResourceName("CustomDomain", 50),
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

        ///GENMHASH:A8B790B37504B3C5949D6280CCA5766C:10B53C5448039688C01BB784974A2356
        public void PurgeContent(IList<string> contentPaths)
        {
            this.Parent.PurgeEndpointContent(this.Name(), contentPaths);
        }

        ///GENMHASH:D5D59EB5CA82A8AB794662C7BE5DC553:B3CB07BBD45377B8277115EC46260752
        public CdnEndpointImpl WithPremiumOrigin(string originName, string hostname)
        {
            return this.WithOrigin(originName, hostname);
        }

        ///GENMHASH:F71E48F5B3D69E8C24335B207B0C3D6D:5CA83E956D3104EE4C9ADD7A88955055
        public CdnEndpointImpl WithPremiumOrigin(string hostname)
        {
            return this.WithOrigin(hostname);
        }

        ///GENMHASH:72FE6C296217E3578A9C74F7AAE606D0:8C62D9D7CE9960043DCAF3584DDE1668
        public void LoadContent(IList<string> contentPaths)
        {
            this.Parent.LoadEndpointContent(this.Name(), contentPaths);
        }

        ///GENMHASH:F08598A17ADD014E223DFD77272641FF:B18E8741B5B810C680CCE7043B0158A0
        public async override Task<Microsoft.Azure.Management.Cdn.Fluent.ICdnEndpoint> UpdateAsync(CancellationToken cancellationToken = default(CancellationToken))
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

        ///GENMHASH:DEAE39A7D24B41C1AF6ABFA406FD058B:997BF86B1AE48764E97C384BDB52387E
        public string ResourceState()
        {
			return this.Inner.ResourceState;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
			return this.Inner.Id;
        }

        ///GENMHASH:50951E75802920DF638B9F82BEC67147:0486B1BC9AE097182CCECA801B4C0A3C
        public CdnEndpointImpl WithContentTypeToCompress(string contentTypeToCompress)
        {
            if (this.Inner.ContentTypesToCompress == null)
            {
                this.Inner.ContentTypesToCompress = new List<string>();
            }
            this.Inner.ContentTypesToCompress.Add(contentTypeToCompress);
            return this;
        }

        ///GENMHASH:3BC1B56E1EA6D8692923934DD96FA69E:3E899646D6EF65C7F18D49308FB9672A
        public IList<Microsoft.Azure.Management.Cdn.Fluent.Models.GeoFilter> GeoFilters()
        {
                return this.Inner.GeoFilters;
        }

        ///GENMHASH:6F62B34CB3A912AA692DBF18C6F448CB:A04B2C5688B47A48AC0B72C698E4AFC4
        public CdnEndpointImpl WithHostHeader(string hostHeader)
        {
            this.Inner.OriginHostHeader = hostHeader;
            return this;
        }

        ///GENMHASH:52A2DCF36C3A58BEC0D85E7C013DD0A4:4E93ADCD1660A9273F08B84E6A5E307D
        public CdnEndpointImpl WithoutContentTypesToCompress()
        {
            if (this.Inner.ContentTypesToCompress != null)
            {
                this.Inner.ContentTypesToCompress.Clear();
            }
            return this;
        }

        ///GENMHASH:69AE408B69EFE5C70BE2FFF8DAFDE487:664DE54EB6DDDFB480C8D678BFF06988
        public int HttpPort()
        {
			if (this.Inner.Origins != null && this.Inner.Origins.Any() &&
				this.Inner.Origins.ElementAt(0).HttpPort.HasValue)
			{
				return this.Inner.Origins.ElementAt(0).HttpPort.Value;
			}
			return 0;
        }

        ///GENMHASH:F2439439456B08DA8AB97215E07770D4:3B1EB2372D771F546AF6E37C78648BB2
        public QueryStringCachingBehavior QueryStringCachingBehavior()
        {
			return this.Inner.QueryStringCachingBehavior.Value;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:220D4662AAC7DF3BEFAF2B253278E85C
        public string ProvisioningState()
        {
			return this.Inner.ProvisioningState;
        }

        ///GENMHASH:03E80F0F2C9B94D8F1D6C59D199A324F:40C8D11EF6D101133A63F404CB1BB8D9
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

        ///GENMHASH:EB854F18026EDB6E01762FA4580BE789:731989EAA3E6D31DB2AFFE17967B29FB
        public void Stop()
        {
            this.Parent.StopEndpoint(this.Name());
        }

        ///GENMHASH:4432D0ADF52DD4D5E7DE90F40C6E8896:76F37D088A77DEC25DE11A157AB47F1D
        public string OriginHostHeader()
        {
			return this.Inner.OriginHostHeader;
		}

        ///GENMHASH:3660F0252470EA7E11BE799A78D9EC84:B7A7715C766EAE6ADE136666DFFE09AC
        public bool IsHttpsAllowed()
        {
			return (this.Inner.IsHttpsAllowed.HasValue) ?
                    this.Inner.IsHttpsAllowed.Value : false;
        }

        ///GENMHASH:B616A3CDCC5668DC239E5CB02EC9777C:8915C60D99E7BDD3A3FD9CF713070E1C
        public string OptimizationType()
        {
			return this.Inner.OptimizationType;
        }

        ///GENMHASH:339AE17292CFA9A95578C99FBDA11380:C16B6B3A2E90C698F4A188EF7462D6DC
        public CdnEndpointImpl WithHttpsAllowed(bool httpsAllowed)
        {
            this.Inner.IsHttpsAllowed = httpsAllowed;
            return this;
        }

        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:1130E1FDC5A612FAE78D6B24DD71D43E
        public string HostName()
        {
			return this.Inner.HostName;
        }

        ///GENMHASH:0D2A82EC2942737570457A70F9912934:F9F8378CA5AE05C20515570CAE35960A
        public string OriginHostName()
        {
			if (this.Inner.Origins != null && this.Inner.Origins.Any())
			{
				return this.Inner.Origins.ElementAt(0).HostName;
			}
			return null;
        }

        ///GENMHASH:E60DC199BAC0D1A721C0F7662730ABA2:518C4F662A2D3826050A6374C08548F8
        public string OriginPath()
        {
			return this.Inner.OriginPath;
        }

        ///GENMHASH:FEA86C0334821B08888EC64FA387E385:3C9E4B867B3BFA631870D3CB338CF2DD
        public CdnEndpointImpl WithContentTypesToCompress(IList<string> contentTypesToCompress)
        {
            foreach (var contentType in contentTypesToCompress)
            {
                this.Inner.ContentTypesToCompress.Add(contentType);
            }
            return this;
        }

        ///GENMHASH:1616938B44B8E0E6D22C3659A2BCFCFE:55912BF697AF997979E54EED9E353D49
        public int HttpsPort()
        {
			if (this.Inner.Origins != null && this.Inner.Origins.Any() &&
				this.Inner.Origins.ElementAt(0).HttpsPort.HasValue)
			{
				return this.Inner.Origins.ElementAt(0).HttpsPort.Value;
			}
			return 0;
        }

        ///GENMHASH:00FEB5C68B4751719C13C6D6808A9E3D:6B89DE41199AB45D2C541D6B3DBC05CC
        public CdnEndpointImpl WithGeoFilter(string relativePath, GeoFilterActions action, Microsoft.Azure.Management.Resource.Fluent.Core.CountryISOCode countryCode)
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

        ///GENMHASH:E81B85429E14169BEB0AD4E22E1D7E02:EFAC4F0A8E7E479378E2D805054B10E9
        public CdnEndpointImpl WithGeoFilter(string relativePath, GeoFilterActions action, IList<Microsoft.Azure.Management.Resource.Fluent.Core.CountryISOCode> countryCodes)
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

        ///GENMHASH:C7E3B6CC7CD3267F666A96B615DDC068:0357550555FFEA6B58DFA325B94D8DA2
        public CdnEndpointImpl WithHttpPort(int httpPort)
        {
            if (this.Inner.Origins != null && this.Inner.Origins.Any())
            {
                this.Inner.Origins.ElementAt(0).HttpPort = httpPort;
            }
            return this;
        }

        ///GENMHASH:02F4B346FD2A70C665ACC639FDB892A8:55B871B6D1B5DB1661BCCFCFAE29D39C
        public IList<string> ContentTypesToCompress()
        {
			return this.Inner.ContentTypesToCompress;
        }

        ///GENMHASH:E6BF4911DAC5A8F7935D5D2C29B496A4:5599AE7A8F08BDC419B9D9D6350D80B3
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

        ///GENMHASH:C245F1873A239F9C8B080F237C995994:CADA2D8BC52DA7D402455B63B068EB16
        public IList<string> CustomDomains()
        {
			return this.customDomainList.Select(cd => cd.HostName).ToList();
        }

        ///GENMHASH:23C4E65AB754D70B878D3A66AEE8E654:B3F227E77BD8D90C6C9A5BFB4BED56AB
        public CdnEndpointImpl WithCompressionEnabled(bool compressionEnabled)
        {
            this.Inner.IsCompressionEnabled = compressionEnabled;
            return this;
        }

        ///GENMHASH:49ED727092D355BFE0529224205A61FE:FB641FDF3348A96399457703B16AA777
        public CdnEndpointImpl WithGeoFilters(IList<Microsoft.Azure.Management.Cdn.Fluent.Models.GeoFilter> geoFilters)
        {
            this.Inner.GeoFilters = geoFilters;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:34C3D97AC56EA49A0A7DE74A085B41B2
        public CdnProfileImpl Attach()
        {
            return this.Parent.WithEndpoint(this);
        }

        ///GENMHASH:57B9D4E7F982060F78F28F5609F2BC38:C49EB5D71E9039DEC17115C095E282F9
        public CdnEndpointImpl WithHttpAllowed(bool httpAllowed)
        {
            this.Inner.IsHttpAllowed = httpAllowed;
            return this;
        }

        ///GENMHASH:CD6809DFDD78677C6753D833E44E73E6:8AB02C538F745324130F952F19B611D7
        public bool IsHttpAllowed()
        {
			return (this.Inner.IsHttpAllowed.HasValue) ?
                    this.Inner.IsHttpAllowed.Value : false;
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:A5F7C81073BA64AE03AC5C595EE8B6E5
        public void Start()
        {
            this.Parent.StartEndpoint(this.Name());
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:F8A6A48920042C49572BFDA9629E1BC7
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

        ///GENMHASH:64AF8E4C0DC21702ECEBDAB60ABF9E38:B0E2487AEAA046DB40AFBF76759F57B7
        public CdnEndpointImpl WithoutGeoFilters()
        {
            if(this.Inner.GeoFilters != null)
            {
                this.Inner.GeoFilters.Clear();
            }
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:4ECAD0C81AFE0A2718CE4BFF1EC4C29F
        public async override Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.client.DeleteAsync(
                this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.Name(),
                cancellationToken);
        }

        ///GENMHASH:ED6AC52E4E80AB09EC1F1A4F7D67B43D:1304F5065C963D2A0B0FDB3559616C62
        public bool IsCompressionEnabled()
        {
			return (this.Inner.IsCompressionEnabled.HasValue) ? 
                    this.Inner.IsCompressionEnabled.Value : false;
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

        ///GENMHASH:D318AAF0AF67937A3B0D7457810D7189:9C29B8395D3F24B9173B3136ACF366A7
        public CdnEndpointImpl WithoutContentTypeToCompress(string contentTypeToCompress)
        {
            if(this.Inner.ContentTypesToCompress != null)
            {
                this.Inner.ContentTypesToCompress.Remove(contentTypeToCompress);
            }
            return this;
        }

        ///GENMHASH:693BE444A3B7607A943975559DB607E2:06BF95A95E70AE38A4CDD5D6B5F142E7
        public CdnEndpointImpl WithOriginPath(string originPath)
        {
            this.Inner.OriginPath = originPath;
            return this;
        }
		
        ///GENMHASH:79A840C9F24220C8EF02C0B73BAD3C0F:3586CFD7AEFDBFA89168B9EFC6A2C18C
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

        ///GENMHASH:870B1F6CF318C295B15B16948090E5A0:ABEA6A4F088942CBF4A75A3B05559004
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

        ///GENMHASH:AD2E24D9DFB738D4BF1A5F65CE996552:3723FC50D475B864D34F27CE06DE8A61
        public CustomDomainValidationResult ValidateCustomDomain(string hostName)
        {
            return this.Parent.ValidateEndpointCustomDomain(this.Name(), hostName);
        }

        IUpdate ISettable<IUpdate>.Parent()
        {
            return this.Parent;
        }				
    }
}
