// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Core.Tests.Identity
{
    public class AzureAuthorityHostsTests
    {
        [Test]
        public void WellKnownAuthorityHostsHaveExpectedValues()
        {
            Assert.AreEqual(new Uri("https://login.microsoftonline.com/"), AzureAuthorityHosts.AzurePublicCloud);
            Assert.AreEqual(new Uri("https://login.sovcloud-identity.fr/"), AzureAuthorityHosts.AzureBleuCloud);
            Assert.AreEqual(new Uri("https://login.chinacloudapi.cn/"), AzureAuthorityHosts.AzureChina);
            Assert.AreEqual(new Uri("https://login.microsoftonline.us/"), AzureAuthorityHosts.AzureGovernment);
        }

        [Test]
        public void GetDefaultScopeReturnsExpectedScopeForKnownAuthorityHosts()
        {
            Assert.AreEqual("https://management.azure.com//.default", AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzurePublicCloud));
            Assert.AreEqual("https://management.sovcloud-api.fr//.default", AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzureBleuCloud));
            Assert.AreEqual("https://management.chinacloudapi.cn/.default", AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzureChina));
            Assert.AreEqual("https://management.usgovcloudapi.net/.default", AzureAuthorityHosts.GetDefaultScope(AzureAuthorityHosts.AzureGovernment));
            Assert.IsNull(AzureAuthorityHosts.GetDefaultScope(new Uri("https://login.contoso.com/")));
        }
    }
}
