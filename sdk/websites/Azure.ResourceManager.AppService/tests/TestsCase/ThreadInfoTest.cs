// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.AppService.Models;
using Azure.ResourceManager.AppService.Tests.Helpers;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.AppService.Tests.TestsCase
{
    internal class ThreadInfoTest : AppServiceTestBase
    {
        public ThreadInfoTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }
        [TestCase]
        [RecordedTest]
        //The app service resource needed should be created by using template file under TeseCase/AppServicetemplates by Azure CLI or other way.
        public async Task GetSiteInstanceProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            ResourceGroupCollection rgCollection = DefaultSubscription.GetResourceGroups();
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
                    var threadsCollection = siteInsResource.GetSiteInstanceProcessThreads();
                    foreach (WebAppProcessThreadInfo threadInfo in threadsCollection)
                    {
                        var id = threadInfo.Properties.Id;
                        var href = threadInfo.Properties.Href;
                        var state = threadInfo.Properties.State;
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
        [TestCase]
        [RecordedTest]
        //The app service resource needed should be created by using template file under TeseCase/AppServicetemplates by Azure CLI or other way.
        public void GetSiteProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            // Authenticate and create the client
            var credentials = new DefaultAzureCredential();
            var armClient = new ArmClient(credentials);
            var subid = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource sub = armClient.GetSubscriptionResource(subid).Get();
            var identifier = WebSiteResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            var webSiteResource = armClient.GetWebSiteResource(identifier);

            var processList = webSiteResource.GetSiteProcesses();
            int threadsInfoRecord = 0;
            try
            {
                foreach (SiteProcessResource item in processList)
                {
                    var processThreadInfo_Collection = item.GetSiteProcessThreads(); //1
                    foreach (WebAppProcessThreadInfo item33 in processThreadInfo_Collection)
                    {
                        var id = item33.Properties.Id;
                        var href = item33.Properties.Href;
                        var state = item33.Properties.State;
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
        [TestCase]
        [RecordedTest]
        //The app service resource needed should be created by using template file under TeseCase/AppServicetemplates by Azure CLI or other way.
        public void GetSiteSlotProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            // Authenticate and create the client
            var credentials = new DefaultAzureCredential();
            var armClient = new ArmClient(credentials);
            var subid = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource sub = armClient.GetSubscriptionResource(subid).Get();
            var identifier = WebSiteResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            var webSiteResource = armClient.GetWebSiteResource(identifier);
            var processList = webSiteResource.GetSiteProcesses();
            int threadsInfoRecord = 0;
            var identifierSlot = WebSiteSlotResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, "slot1");
            var webSiteSlotResource = armClient.GetWebSiteSlotResource(identifierSlot);
            var processList_slot = webSiteSlotResource.GetSiteSlotProcesses();
            try
            {
                foreach (SiteSlotProcessResource item in processList_slot)
                {
                    var processThreadInfo_Collection = item.GetSiteSlotProcessThreads(); //2
                    foreach (WebAppProcessThreadInfo item33 in processThreadInfo_Collection)
                    {
                        var id = item33.Properties.Id;
                        var href = item33.Properties.Href;
                        var state = item33.Properties.State;
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

        [TestCase]
        [RecordedTest]
        //The app service resource needed should be created by using template file under TeseCase/AppServicetemplates by Azure CLI or other way.
        public void GetSiteSlotInstanceProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            // Authenticate and create the client
            var credentials = new DefaultAzureCredential();
            var armClient = new ArmClient(credentials);
            var subid = SubscriptionResource.CreateResourceIdentifier(subscriptionId);
            SubscriptionResource sub = armClient.GetSubscriptionResource(subid).Get();
            int threadsInfoRecord = 0;
            var identifierSlot = WebSiteSlotResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, "slot1");
            var webSiteSlotResource = armClient.GetWebSiteSlotResource(identifierSlot);
            SiteSlotInstanceCollection ops_slot = webSiteSlotResource.GetSiteSlotInstances();
            try
            {
                foreach (SiteSlotInstanceResource item44 in ops_slot)
                {
                    SiteSlotInstanceProcessCollection siteInstanceCollection = item44.GetSiteSlotInstanceProcesses();
                    string processId = "";
                    foreach (SiteSlotInstanceProcessResource item22 in siteInstanceCollection)
                    {
                        processId = item22.Data.Id.Name;
                    }
                    SiteSlotInstanceProcessResource siteSlotInsResource = siteInstanceCollection.Get(processId);
                    var threadsCollection = siteSlotInsResource.GetSiteSlotInstanceProcessThreads();//3
                    foreach (WebAppProcessThreadInfo item33 in threadsCollection)
                    {
                        var id = item33.Properties.Id;
                        var href = item33.Properties.Href;
                        var state = item33.Properties.State;
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
