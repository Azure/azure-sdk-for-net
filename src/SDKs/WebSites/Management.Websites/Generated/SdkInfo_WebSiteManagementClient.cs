
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_WebSiteManagementClient
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("CertificateRegistration", "AppServiceCertificateOrders", "2015-08-01"),
                new Tuple<string, string, string>("CertificateRegistration", "CertificateRegistrationProvider", "2015-08-01"),
                new Tuple<string, string, string>("DomainRegistration", "DomainRegistrationProvider", "2015-04-01"),
                new Tuple<string, string, string>("DomainRegistration", "Domains", "2015-04-01"),
                new Tuple<string, string, string>("DomainRegistration", "TopLevelDomains", "2015-04-01"),
                new Tuple<string, string, string>("Web", "AppServiceEnvironments", "2016-09-01"),
                new Tuple<string, string, string>("Web", "AppServicePlans", "2016-09-01"),
                new Tuple<string, string, string>("Web", "Certificates", "2016-03-01"),
                new Tuple<string, string, string>("Web", "CheckNameAvailability", "2016-03-01"),
                new Tuple<string, string, string>("Web", "DeletedWebApps", "2016-03-01"),
                new Tuple<string, string, string>("Web", "Diagnostics", "2016-03-01"),
                new Tuple<string, string, string>("Web", "GetPublishingUser", "2016-03-01"),
                new Tuple<string, string, string>("Web", "GetSourceControl", "2016-03-01"),
                new Tuple<string, string, string>("Web", "GetSubscriptionDeploymentLocations", "2016-03-01"),
                new Tuple<string, string, string>("Web", "ListGeoRegions", "2016-03-01"),
                new Tuple<string, string, string>("Web", "ListPremierAddOnOffers", "2016-03-01"),
                new Tuple<string, string, string>("Web", "ListSiteIdentifiersAssignedToHostName", "2016-03-01"),
                new Tuple<string, string, string>("Web", "ListSkus", "2016-03-01"),
                new Tuple<string, string, string>("Web", "ListSourceControls", "2016-03-01"),
                new Tuple<string, string, string>("Web", "Provider", "2016-03-01"),
                new Tuple<string, string, string>("Web", "Recommendations", "2016-03-01"),
                new Tuple<string, string, string>("Web", "UpdatePublishingUser", "2016-03-01"),
                new Tuple<string, string, string>("Web", "UpdateSourceControl", "2016-03-01"),
                new Tuple<string, string, string>("Web", "Validate", "2016-03-01"),
                new Tuple<string, string, string>("Web", "VerifyHostingEnvironmentVnet", "2016-03-01"),
                new Tuple<string, string, string>("Web", "WebApps", "2016-08-01"),
                new Tuple<string, string, string>("WebSiteManagementClient", "Move", "2016-03-01"),
                new Tuple<string, string, string>("WebSiteManagementClient", "ValidateMove", "2016-03-01"),
            }.AsEnumerable();
        }
    }
}
