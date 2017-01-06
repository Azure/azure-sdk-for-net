// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Cdn.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System.Linq;
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
        private const string endpointOriginHostname = "mylinuxapp.azurewebsites.net";

        [Fact]
        public void CanCRUDCdn()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var cdnManager = TestHelper.CreateCdnManager();

                    var standardProfile = cdnManager.Profiles.Define(cdnStandardProfileName)
                            .WithRegion(Region.US_CENTRAL)
                            .WithNewResourceGroup(rgName)
                            .WithStandardAkamaiSku()
                            .WithNewEndpoint("supername.cloudapp.net")
                            .DefineNewEndpoint("akamiEndpointWithoutMuchProperties")
                                .WithOrigin("originSuperName", "storageforazdevextest.blob.core.windows.net")
                                .Attach()
                            .DefineNewEndpoint(cdnEndpointName, endpointOriginHostname)
                                .WithContentTypeToCompress("powershell/pain")
                                .WithGeoFilter("/path/videos", GeoFilterActions.Block, CountryISOCode.Argentina)
                                .WithGeoFilter("/path/images", GeoFilterActions.Block, CountryISOCode.Belgium)
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

                    Assert.NotNull(standardProfile);
                    Assert.Equal(cdnStandardProfileName, standardProfile.Name);
                    Assert.False(standardProfile.IsPremiumVerizon);
                    Assert.Equal(3, standardProfile.Endpoints.Count);
                    Assert.True(standardProfile.Endpoints.ContainsKey(cdnEndpointName));
                    Assert.Equal(endpointOriginHostname, standardProfile.Endpoints[cdnEndpointName].OriginHostName);
                    Assert.Equal(2, standardProfile.Endpoints[cdnEndpointName].CustomDomains.Count);
                    Assert.Equal(2, standardProfile.Endpoints[cdnEndpointName].GeoFilters.Count);
                    Assert.True(standardProfile.Endpoints[cdnEndpointName].IsCompressionEnabled);
                    Assert.True(standardProfile.Endpoints[cdnEndpointName].IsHttpAllowed);
                    Assert.True(standardProfile.Endpoints[cdnEndpointName].IsHttpsAllowed);
                    Assert.Equal(444, standardProfile.Endpoints[cdnEndpointName].HttpsPort);
                    Assert.Equal(85, standardProfile.Endpoints[cdnEndpointName].HttpPort);


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
                    Assert.NotNull(premiumProfile);
                    Assert.Equal(Region.US_CENTRAL, premiumProfile.Region);
                    Assert.True(premiumProfile.IsPremiumVerizon);
                    Assert.Equal(3, premiumProfile.Endpoints.Count);
                    Assert.True(premiumProfile.Endpoints.ContainsKey(cdnPremiumEndpointName));
                    Assert.True(premiumProfile.Endpoints[cdnPremiumEndpointName].IsHttpAllowed);
                    Assert.True(premiumProfile.Endpoints[cdnPremiumEndpointName].IsHttpsAllowed);
                    Assert.Equal(12, premiumProfile.Endpoints[cdnPremiumEndpointName].HttpsPort);
                    Assert.Equal(123, premiumProfile.Endpoints[cdnPremiumEndpointName].HttpPort);

                    var profileRead = standardProfile.Refresh();

                    Assert.NotNull(profileRead);
                    Assert.Equal(standardProfile.Region, profileRead.Region);
                    Assert.Equal(standardProfile.Name, profileRead.Name);
                    Assert.Equal(standardProfile.Endpoints.Count, profileRead.Endpoints.Count);

                    profileRead = cdnManager.Profiles.GetById(standardProfile.Id);
                    Assert.Equal(3, profileRead.Endpoints.Count);
                    Assert.Equal(2, profileRead.Endpoints[cdnEndpointName].CustomDomains.Count);
                    Assert.Equal(standardProfile.Name, profileRead.Name);

                    if (!standardProfile.IsPremiumVerizon)
                    {
                        standardProfile.Update()
                                .WithTag("provider", "Akamai")
                                .WithNewEndpoint("www.somewebsite.com")
                                .DefineNewEndpoint("somenewnamefortheendpoint")
                                    .WithOrigin("www.someotherwebsite.com")
                                    .WithGeoFilter("/path/music", GeoFilterActions.Block, CountryISOCode.Estonia)
                                    .Attach()
                                .UpdateEndpoint(cdnEndpointName)
                                    .WithoutGeoFilters()
                                    .WithHttpAllowed(true)
                                    .WithHttpPort(1111)
                                    .WithoutCustomDomain("sdk-2-f3757d2a3e10.azureedge-test.net")
                                    .Parent()
                        .Apply();
                    }

                    Assert.Equal(standardProfile.Region, profileRead.Region);
                    Assert.Equal(standardProfile.Name, profileRead.Name);
                    Assert.NotEqual(standardProfile.Endpoints.Count, profileRead.Endpoints.Count);
                    Assert.Equal(5, standardProfile.Endpoints.Count);
                    Assert.Equal(1111, standardProfile.Endpoints[cdnEndpointName].HttpPort);
                    Assert.Equal(1, standardProfile.Endpoints[cdnEndpointName].CustomDomains.Count);
                    Assert.Equal("sdk-1-f3757d2a3e10.azureedge-test.net", standardProfile.Endpoints[cdnEndpointName].CustomDomains.ElementAt(0));
                    Assert.Equal(0, standardProfile.Endpoints[cdnEndpointName].GeoFilters.Count);

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

                    Assert.True(premiumProfile.IsPremiumVerizon);
                    Assert.Equal(4, premiumProfile.Endpoints.Count);
                    Assert.False(premiumProfile.Endpoints.ContainsKey("supermuperep1"));
                    Assert.True(premiumProfile.IsPremiumVerizon);

                    string ssoUri = premiumProfile.GenerateSsoUri();
                    Assert.NotNull(ssoUri);

                    var standardEp = standardProfile.Endpoints[cdnEndpointName];
                    var validationResult = standardEp.ValidateCustomDomain("sdk-2-f3757d2a3e10.azureedge-test.net");
                    Assert.NotNull(validationResult);
                    Assert.True(validationResult.CustomDomainValidated);

                    standardProfile.StopEndpoint(standardEp.Name);
                    standardEp.Start();

                }
                finally
                {
                    try
                    {
                        TestHelper.CreateResourceManager().ResourceGroups.DeleteByName(rgName);
                    }
                    catch
                    { }
                }
            }
        }
   }
}
