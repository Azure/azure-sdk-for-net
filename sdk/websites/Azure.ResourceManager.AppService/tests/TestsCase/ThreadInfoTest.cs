// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.AppService.Models;
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
            var webSiteResource = (await Client.GetWebSiteResource(identifier).GetAsync()).Value;
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
                    var threadsCollection = siteInsResource.GetSiteInstanceProcessThreadsAsync();
                    await foreach (WebAppProcessThreadInfo threadInfo in threadsCollection)
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
        public async Task GetSiteProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            var identifier = WebSiteResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            var webSiteResource = (await Client.GetWebSiteResource(identifier).GetAsync()).Value;

            var processList = webSiteResource.GetSiteProcesses().GetAllAsync();
            int threadsInfoRecord = 0;
            try
            {
                await foreach (SiteProcessResource item in processList)
                {
                    var processThreadInfo_Collection = item.GetSiteProcessThreadsAsync(); //1
                    await foreach (WebAppProcessThreadInfo threadInfo in processThreadInfo_Collection)
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
        public async Task GetSiteSlotProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            var identifier = WebSiteResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName);
            var webSiteResource = (await Client.GetWebSiteResource(identifier).GetAsync()).Value;
            int threadsInfoRecord = 0;
            var identifierSlot = WebSiteSlotResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, "slot1");
            var webSiteSlotResource = (await Client.GetWebSiteSlotResource(identifierSlot).GetAsync()).Value;
            var processList_slot = webSiteSlotResource.GetSiteSlotProcesses().GetAllAsync();
            try
            {
                await foreach (SiteSlotProcessResource item in processList_slot)
                {
                    var processThreadInfo_Collection = item.GetSiteSlotProcessThreadsAsync(); //2
                    await foreach (WebAppProcessThreadInfo threadInfo in processThreadInfo_Collection)
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
        public async Task GetSiteSlotInstanceProcessThreads_Test()
        {
            string resourceGroupName = "testRG";
            string serviceName = "testapplwm";
            string subscriptionId = DefaultSubscription.Data.SubscriptionId;
            int threadsInfoRecord = 0;
            var identifierSlot = WebSiteSlotResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, serviceName, "slot1");
            var webSiteSlotResource = (await Client.GetWebSiteSlotResource(identifierSlot).GetAsync()).Value;
            var ops_slot = webSiteSlotResource.GetSiteSlotInstances().GetAllAsync();
            try
            {
                await foreach (SiteSlotInstanceResource item in ops_slot)
                {
                    var siteInstanceCollection = item.GetSiteSlotInstanceProcesses().GetAllAsync();
                    string processId = "";
                    await foreach (SiteSlotInstanceProcessResource ssipr in siteInstanceCollection)
                    {
                        processId = ssipr.Data.Id.Name;
                    }
                    SiteSlotInstanceProcessResource siteSlotInsResource = await item.GetSiteSlotInstanceProcesses().GetAsync(processId);
                    var threadsCollection = siteSlotInsResource.GetSiteSlotInstanceProcessThreadsAsync();
                    await foreach (WebAppProcessThreadInfo threadInfo in threadsCollection)
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
    }
}
