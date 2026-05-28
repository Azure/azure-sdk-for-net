// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;

namespace Azure.ResourceManager.AppService.Tests.Helpers
{
    public static class ResourceDataHelper
    {
        private const string dummySSHKey = "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC+wWK73dCr+jgQOAxNsHAnNNNMEMWOHYEccp6wJm2gotpr9katuF/ZAdou5AaW1C61slRkHRkpRRX9FA9CYBiitZgvCCz+3nWNN7l/Up54Zps/pHWGZLHNJZRYyAB6j5yVLMVHIHriY49d/GZTZVNB8GoJv9Gakwc/fuEZYYl4YDFiGMBP///TzlI4jhiJzjKnEvqPFki5p2ZRJqcbCiF4pJrxUQR/RXqVFQdbRLZgYfJ8xGB878RENq3yQ39d8dVOkq4edbkzwcUmwwwkYVPIoDGsYLaRHnG+To7FvMeyO7xDVQkMKzopTQV8AuKpyvpqu0a9pWOMaiCyDytO7GGN you@me.com";

        // Temporary solution since the one in Azure.ResourceManager.AppService is internal
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region AppServicePlan
        public static void AssertPlan(AppServicePlanData plan1, AppServicePlanData plan2)
        {
            AssertTrackedResource(plan1, plan2);
            Assert.AreEqual(plan1.ExtendedLocation, plan2.ExtendedLocation);
        }

        public static AppServicePlanData GetBasicAppServicePlanData(AzureLocation location)
        {
            var data = new AppServicePlanData(location)
            {
                Sku = new AppServiceSkuDescription
                {
                    Name = "S1",
                    Tier = "STANDARD",
                    Capacity =  1
                },
                IsPerSiteScaling = false,
                IsXenon = false
            };
            return data;
        }
        #endregion

        #region Site

        public static void AssertSite(WebSiteData site1, WebSiteData site2)
        {
            AssertTrackedResource(site1, site2);
            Assert.AreEqual(site1.EnabledHostNames, site2.EnabledHostNames);
        }

        public static WebSiteData GetBasicSiteData(AzureLocation location)//, string description = null)
        {
            var data = new WebSiteData(location)
            {
                /*Reserved = false,
                IsXenon = false,
                HyperV = false,
                SiteConfig = new SiteConfig
                {
                    NetFrameworkVersion = "v4.6",
                    AppSettings =
                    {
                        new NameValuePair
                        {
                            Name = "WEBSITE_NODE_DEFAULT_VERSION",
                            Value = "10.14"
                        }
                    },
                    LocalMySqlEnabled = false,
                    Http20Enabled = true
                },
                ScmSiteAlsoStopped = false,
                HttpsOnly = false*/
            };
            return data;
        }
        #endregion

        #region SiteSlot
        public static void AssertSiteSlot(WebSiteData site1, WebSiteData site2)
        {
            AssertTrackedResource(site1, site2);
            Assert.AreEqual(site1.EnabledHostNames, site2.EnabledHostNames);
        }

        public static WebSiteData GetBasicSiteSlotData(AzureLocation location, string description = null)
        {
            var data = new WebSiteData(location)
            {
                IsReserved = false,
                IsXenon = false,
                IsHyperV = false,
                SiteConfig = new SiteConfigProperties
                {
                    NetFrameworkVersion = "v4.6",
                    IsLocalMySqlEnabled = false,
                    IsHttp20Enabled = true
                },
                IsScmSiteAlsoStopped = false,
            };
            return data;
        }
        #endregion

        #region SiteSlotConfigWeb
        public static void AssertSiteSlotConfigWeb(SiteConfigData site1, SiteConfigData site2)
        {
            //AssertTrackedResource(site1, site2);
            Assert.AreEqual(site1.AppSettings, site2.AppSettings);
        }
        public static SiteConfigData GetBasicSiteConfigResourceData(AzureLocation location, string description = null)
        {
            /*IDictionary<string, IList<string>> header = new ChangeTrackingDictionary<string, IList<string>>();
            IList<string> ipAddress = new List<string>();
            ipAddress.Add("Any");
            IList<string> action = new List<string>();
            action.Add("Allow");
            IList<string> priority = new List<string>();
            priority.Add("1");
            IList<string> name = new List<string>();
            name.Add("Allow all");
            IList<string> descriptionlist = new List<string>();
            descriptionlist.Add("Allow all accesss");
            header.Add("ip_adddress", ipAddress);
            header.Add("action", action);
            header.Add("priority", priority);
            header.Add("name", name);
            header.Add("description",descriptionlist);*/
            var data = new SiteConfigData()
            {
                DefaultDocuments =
                {
                    "Default.htm",
                    "Default.html",
                    "Default.asp",
                    "index.htm",
                    "index.html",
                    "iisstart.htm",
                    "default.aspx",
                    "index.php",
                    "hostingstart.html"
                },
                IPSecurityRestrictions =
                {
                    new AppServiceIPSecurityRestriction
                    {
                        IPAddressOrCidr = "Any",
                        Action = "Allow",
                        Priority = 1,
                        Name =  "Allow all",
                        Description = "Allow all access"
                    }
                },
                ScmIPSecurityRestrictions =
                {
                    new AppServiceIPSecurityRestriction
                    {
                        IPAddressOrCidr = "Any",
                        Action = "Allow",
                        Priority = 1,
                        Name =  "Allow all",
                        Description = "Allow all access"
                    }
                },
                VirtualApplications =
                {
                    new VirtualApplication
                    {
                        VirtualPath =  "/",
                        PhysicalPath =  "site\\wwwroot",
                        IsPreloadEnabled =  true
                    }
                }
            };
            return data;
        }
        #endregion

        #region SiteSourceControlData(SiteSlotSourcecontrol)
        public static void AssertSiteSourceControlData(SiteSourceControlData sscd1, SiteSourceControlData sscd2)
        {
            Assert.AreEqual(sscd1.Name, sscd2.Name);
            Assert.AreEqual(sscd1.Id, sscd2.Id);
            Assert.AreEqual(sscd1.ResourceType, sscd2.ResourceType);
            Assert.AreEqual(sscd1.Branch, sscd2.Branch);
        }

        public static SiteSourceControlData GetBasicSiteSourceControlData()
        {
            var data = new SiteSourceControlData()
            {
                RepoUri = new Uri("https://github.com/00Kai0/azure-site-test"),
                Branch = "staging",
                IsManualIntegration = true,
                IsMercurial = false,
            };
            return data;
        }
        #endregion

        #region StaticSiteARMResourceData(StaticSiteRestOperation)
        public static void AssertStaticSiteARMResourceData(StaticSiteData ssrd1, StaticSiteData ssrd2)
        {
            AssertTrackedResource(ssrd1, ssrd2);
            Assert.AreEqual(ssrd1.Branch, ssrd2.Branch);
            Assert.AreEqual(ssrd1.RepositoryUri, ssrd2.RepositoryUri);
            Assert.AreEqual(ssrd1.Kind, ssrd2.Kind);
        }

        public static StaticSiteData GetBasicStaticSiteARMResourceData(AzureLocation location)
        {
            var data = new StaticSiteData(location)
            {
                Sku = new AppServiceSkuDescription()
                {
                    Name = "Free",
                    //Tier = "Basic"
                },
                RepositoryUri = new Uri("https://github.com/00Kai0/html-docs-hello-world"),
                Branch = "master",
                RepositoryToken = "xxx",
                BuildProperties = new StaticSiteBuildProperties()
                {
                    AppLocation = "app",
                    ApiLocation = "api",
                    AppArtifactLocation = "build"
                }
            };
            return data;
        }
        #endregion

        #region Certificate
        public static void AssertCertificate(AppCertificateData certificate1, AppCertificateData certificate2)
        {
            AssertTrackedResource(certificate1, certificate2);
            Assert.AreEqual(certificate1.CanonicalName, certificate2.CanonicalName);
        }

        public static AppCertificateData GetBasicCertificateData(AzureLocation location)
        {
            var data = new AppCertificateData(location)
            {
                Location = location,
                HostNames =
                {
                    "ServerCert"
                },
                Password = "SWsSsd__233$Sdsds#%Sd!"
            };
            return data;
        }
        #endregion
    }
}
