using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.WebSites;

namespace Common.Phone.Test
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void TestClientInitialization()
        {
            var tokenCredentials = new TokenCloudCredentials("123", "abc");
            var fakeClient = new WebSiteManagementClient(tokenCredentials);
            Assert.IsNotNull(fakeClient);
        }
    }
}
