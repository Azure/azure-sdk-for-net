// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;

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

        public static void AssertTrackedResource(TrackedResource r1, TrackedResource r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Type, r2.Type);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        #region AppServicePlan
        public static void AssertPlan(AppServicePlanData plan1, AppServicePlanData plan2)
        {
            AssertTrackedResource(plan1, plan2);
            Assert.AreEqual(plan1.ExtendedLocation, plan2.ExtendedLocation);
        }

        public static AppServicePlanData GetBasicAppServicePlanData(Location location)
        {
            var data = new AppServicePlanData(location)
            {
                //Location = "AZURE_LOCATION",
                Sku = new SkuDescription
                {
                Name = "S1",
                Tier = "STANDARD",
                Capacity =  1
                },
                PerSiteScaling = false,
                IsXenon = false
            };
            return data;
        }
        #endregion

        #region Site
        public static void AssertSite(SiteData site1, SiteData site2)
        {
            AssertTrackedResource(site1, site2);
            Assert.AreEqual(site1.EnabledHostNames, site2.EnabledHostNames);
        }

        public static SiteData GetBasicSiteData(Location location, string description = null)
        {
            var data = new SiteData(location)
            {
                Reserved = false,
                IsXenon = false,
                HyperV = false,
                SiteConfig =
                {
                    NetFrameworkVersion = "v4.6",
                    AppSettings =
                    {
                       // new list
                    }
                }
            }
                ;//HostNames = { "ServerCert" }
            return data;
        }
        #endregion

        #region SiteSlotConfigWeb
        public static SiteConfigResourceData GetBasicSiteConfigResourceData(Location location, string description = null)
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
            var data = new SiteConfigResourceData()
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
                IpSecurityRestrictions =
                {
                    new IpSecurityRestriction
                    {
                    IpAddress = "Any",
                    Action = "Allow",
                    Priority = 1,
                    Name =  "Allow all",
                    Description = "Allow all access"
                    }
                }
            };
            return data;
        }
        #endregion
    }
}
