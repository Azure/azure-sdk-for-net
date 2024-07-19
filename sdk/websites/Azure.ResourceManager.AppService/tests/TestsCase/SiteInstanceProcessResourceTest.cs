using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    internal class SiteInstanceProcessResourceTest : AppServiceTestBase
    {
        public SiteInstanceProcessResourceTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        [TestCase]
        [RecordedTest]
        public async Task SiteInstanceProcessResource_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
            ResourceGroupResource rg = await rgCollection.GetAsync(resourceGroupName);
            var identifier = WebSiteResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            var credentials = new DefaultAzureCredential();
            var armClient = new ArmClient(credentials);
            var webSiteResource = armClient.GetWebSiteResource(identifier);
            SiteInstanceCollection siteInsCollection = webSiteResource.GetSiteInstances();
            int threadsInfoRecord = 0;
            try
            {
                await foreach (SiteInstanceResource item in siteInsCollection.GetAllAsync())
                {
                    SiteInstanceProcessCollection siteInstanceCollection = item.GetSiteInstanceProcesses();

                    string processId = "";
                    await foreach (SiteInstanceProcessResource siteInsProcess in siteInstanceCollection.GetAllAsync())
                    {
                        processId = siteInsProcess.Data.Id.Name;
                    }
                    SiteInstanceProcessResource siteInsResource = await siteInstanceCollection.GetAsync(processId);
                    var threadsCollection = siteInsResource.GetInstanceProcessThreads();
                    foreach (ProcessThreadInfo treadIno in threadsCollection)
                    {
                        var processid = treadIno.Processid;
                        var process = treadIno.Process;
                        threadsInfoRecord++;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.NotZero(threadsInfoRecord);
        }
    }
}
