// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests.Cdn
{
    public class CdnTests
    {
        private const string cdnStandardProfileName = "cdnStandardProfile22";
        private const string cdnPremiumProfileName = "cdnPremiumProfile22";
        private const string cdnEndpointName = "endpoint-f3757d2a3e10";
        private const string cdnPremiumEndpointName = "premiumVerizonEndpointFluentTest22";
        private const string rgName = "rgRCCDN";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDCdn()
        {

            try
            {
                var cdnManager = CreateCdnManager();

                var standardProfile = cdnManager.Profiles.Define(cdnStandardProfileName)
                        .WithRegion(Region.US_CENTRAL)
                        .WithNewResourceGroup(rgName)

                        .WithStandardAkamaiSku()
                        .WithNewEndpoint("supername.cloudapp.net")
                        .DefineNewEndpoint("akamiEndpointWithoutMuchProperties")
                            .WithOrigin("originSuperName", "storageforazdevextest.blob.core.windows.net")
                            .Attach()
                        .DefineNewEndpoint(cdnEndpointName, "mylinuxapp.azurewebsites.net")
                            .WithContentTypeToCompress("powershell/pain")
                            .WithGeoFilter("/path/videos", GeoFilterActions.Block, CountryISOCode.ARGENTINA)
                            .WithGeoFilter("/path/images", GeoFilterActions.Block, CountryISOCode.BELGIUM)
                            .WithContentTypeToCompress("text/plain")
                            .WithCompressionEnabled(true)
                            .WithQueryStringCachingBehavior(QueryStringCachingBehavior.BypassCaching)
                            .WithHttpsAllowed(true)
                            .WithHttpsPort(444)
                            .WithHttpAllowed(true)
                            .WithHttpPort(85)
                            .WithCustomDomain("sdk-1-f3757d2a3e10.azureedge-test.net")
                            .WithCustomDomain("sdk-2-f3757d2a3e10.azureedge-test.net")
                            .Attach()
                        .Create();

                var premiumProfile = cdnManager.Profiles.Define(cdnPremiumProfileName)
                        .WithRegion(Region.US_CENTRAL)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumVerizonSku()
                        .WithNewPremiumEndpoint("someweirdname.blob.core.windows.net")
                        .DefineNewPremiumEndpoint("supermuperep1")
                            .WithPremiumOrigin("originPremium", "xplattestvmss1sto0575014.blob.core.windows.net")
                            .Attach()
                        .DefineNewPremiumEndpoint(cdnPremiumEndpointName)
                            .WithPremiumOrigin("supername.cloudapp.net")
                            .WithHttpAllowed(true)
                            .WithHttpsAllowed(true)
                            .WithHttpsPort(12)
                            .WithHttpPort(123)
                            .Attach()
                        .Create();

                var profileRead = standardProfile.Refresh();
                
                /*
                foreach (var endpoint in profileRead.Endpoints.Values)
                {
                    System.out.println("CDN Endpoint: " + endpoint.name());
                    System.out.println("EP Hostname: " + endpoint.hostName());
                    System.out.println("EP Origin hostname: " + endpoint.originHostName());
                    System.out.println("EP optimization type: " + endpoint.optimizationType());
                    System.out.println("EP Origin host header: " + endpoint.originHostHeader());
                    System.out.println("EP Origin path: " + endpoint.originPath());
                    for (String customDomain : endpoint.customDomains())
                    {
                        System.out.println("EP custom domain: " + customDomain);
                    }
                }*/
                
                if (!standardProfile.IsPremiumVerizon)
                {
                    standardProfile.Update()
                            .WithTag("provider", "Akamai")
                            .WithNewEndpoint("www.somewebsite.com")
                            .DefineNewEndpoint("somenewnamefortheendpoint")
                                .WithOrigin("www.someotherwebsite.com")
                                .WithGeoFilter("/path/music", GeoFilterActions.Block, CountryISOCode.ESTONIA)
                                .Attach()
                            .UpdateEndpoint(cdnEndpointName)
                                .WithoutGeoFilters()
                                .WithHttpAllowed(true)
                                .WithHttpPort(1111)
                                .WithoutCustomDomain("sdk-2-f3757d2a3e10.azureedge-test.net")
                                .Parent()
                    .Apply();
                }

                premiumProfile.Update()
                        .WithTag("provider", "Verizon")
                        .WithNewPremiumEndpoint("xplattestvmss1sto0575014.blob.core.windows.net")
                        .DefineNewPremiumEndpoint("supermuperep3")
                            .WithPremiumOrigin("xplattestvmss1sto0575014.blob.core.windows.net")
                        .Attach()
                        .UpdatePremiumEndpoint(cdnPremiumEndpointName)
                            .WithHttpsAllowed(true)
                            .WithHttpsPort(1111)
                        .Parent()
                        .WithoutEndpoint("supermuperep1")
                .Apply();

                String ssoUri = premiumProfile.GenerateSsoUri();

                //System.out.println("Standard Akamai Endpoints: " + standardProfile.endpoints().size());
                var standardEp = standardProfile.Endpoints[cdnEndpointName];
                var validationResult = standardEp.ValidateCustomDomain("sdk-2-f3757d2a3e10.azureedge-test.net");
                standardProfile.StopEndpoint(standardEp.Name);
                standardEp.Start();

            }
            finally
            {
                try
                {
                    CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                }
                catch
                { }
            }
        }

        private ICdnManager CreateCdnManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            return CdnManager
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        private IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
