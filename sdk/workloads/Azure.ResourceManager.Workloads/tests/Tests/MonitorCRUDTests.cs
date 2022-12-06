// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Workloads.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    public class MonitorCRUDTests : WorkloadsManagementTestBase
    {
        public MonitorCRUDTests(bool isAsync) : base(isAsync)
        {}

        //[SetUp]
        //public void ClearAndInitialize()
        //{
        //    CreateCommonClient();
        //}

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMonitorHanaProviderCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                "suha-0802-rg1",
                AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("suha-0806-ams");
            string mrgName = Recording.GenerateAssetName("sapmonrg-");
            string hanaProviderName = Recording.GenerateAssetName("saphana-");

            // Create SAP Monitor
            SapMonitorData sapMonitorData = new SapMonitorData(AzureLocation.EastUS2);
            sapMonitorData.AppLocation = AzureLocation.EastUS;
            sapMonitorData.MonitorSubnetId = new ResourceIdentifier(
                "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/nitin-agarwal-scale-test/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-0906-2");
            sapMonitorData.RoutingPreference = RoutingPreference.RouteAll;
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = mrgName
            };

            // Create SAP monitor
            ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                sapMonitorData);

            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Get SAP monitor
            Response<SapMonitorResource> getMonitor = await rg.GetSapMonitorAsync(resourceName);
            Assert.AreEqual(resourceName, getMonitor.Value.Data.Name);

            SapProviderInstanceData sapProviderInstanceData = new SapProviderInstanceData();
            HanaDBProviderInstanceProperties hanaDBProviderInstanceProperties = new HanaDBProviderInstanceProperties();
            hanaDBProviderInstanceProperties.DBUsername = "NITINAGARWAL";
            hanaDBProviderInstanceProperties.DBPassword = "Welcome@1234";
            hanaDBProviderInstanceProperties.DBName = "SYSTEMDB";
            hanaDBProviderInstanceProperties.SqlPort = "30213";
            hanaDBProviderInstanceProperties.Hostname = "172.20.164.202";

            sapProviderInstanceData.ProviderSettings = hanaDBProviderInstanceProperties;

            // Create SAP Hana provider
            ArmOperation<SapProviderInstanceResource> providerResource = await resource
                .Value
                .GetSapProviderInstances()
                .CreateOrUpdateAsync(
                WaitUntil.Completed,
                hanaProviderName,
                sapProviderInstanceData);

            Assert.AreEqual(hanaProviderName, providerResource.Value.Data.Name);

            // Delete SAP Hana provider
            await providerResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapProviderInstanceResource> getDelProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(hanaProviderName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Provider {hanaProviderName} does not exist.");
            }

            //Delete SAP monitor
            await resource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapMonitorResource> getDelMonitor = await rg.GetSapMonitorAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Monitor {resourceName} does not exist.");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMonitorNetweaverProviderCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                "suha-0802-rg1",
                AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("suha-0906-ams");
            string mrgName = Recording.GenerateAssetName("sapmonrg-");
            string nwProviderName = Recording.GenerateAssetName("sapnetw-");

            // Create SAP Monitor
            SapMonitorData sapMonitorData = new SapMonitorData(AzureLocation.EastUS2);
            sapMonitorData.AppLocation = AzureLocation.EastUS;
            sapMonitorData.MonitorSubnetId = new ResourceIdentifier(
                "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/nitin-agarwal-scale-test/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1306-2");
            sapMonitorData.RoutingPreference = RoutingPreference.RouteAll;
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = mrgName
            };

            // Create SAP monitor
            ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                sapMonitorData);

            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Get SAP monitor
            Response<SapMonitorResource> getMonitor = await rg.GetSapMonitorAsync(resourceName);
            Assert.AreEqual(resourceName, getMonitor.Value.Data.Name);

            SapProviderInstanceData sapProviderInstanceData = new SapProviderInstanceData();
            SapNetWeaverProviderInstanceProperties nwProviderInstanceProperties = new SapNetWeaverProviderInstanceProperties();
            nwProviderInstanceProperties.SapHostname = "saptstgtmci.redmond.corp.microsoft.com";
            nwProviderInstanceProperties.SapSid = "GMT";
            nwProviderInstanceProperties.SapHostFileEntries.Add("172.20.164.196 SAPTSTGTMA1 SAPTSTGTMA1.redmond.corp.microsoft.com");
            nwProviderInstanceProperties.SapHostFileEntries.Add("172.20.164.197 SAPTSTGTMCI SAPTSTGTMCI.redmond.corp.microsoft.com");
            nwProviderInstanceProperties.SapHostFileEntries.Add("172.20.164.203 SAPTSTGTMA2 SAPTSTGTMA2.redmond.corp.microsoft.com");

            nwProviderInstanceProperties.SapInstanceNr = "11";

            sapProviderInstanceData.ProviderSettings = nwProviderInstanceProperties;

            // Create SAP Netweaver provider
            ArmOperation<SapProviderInstanceResource> providerResource = await resource
                .Value
                .GetSapProviderInstances()
                .CreateOrUpdateAsync(
                WaitUntil.Completed,
                nwProviderName,
                sapProviderInstanceData);

            Assert.AreEqual(nwProviderName, providerResource.Value.Data.Name);

            // Delete SAP Netweaver provider
            await providerResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapProviderInstanceResource> getDelProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(nwProviderName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Provider {nwProviderName} does not exist.");
            }

            //Delete SAP monitor
            await resource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapMonitorResource> getDelMonitor = await rg.GetSapMonitorAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Monitor {resourceName} does not exist.");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMonitorOsProviderCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                "suha-0802-rg1",
                AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("suha-0906-ams");
            string mrgName = Recording.GenerateAssetName("sapmonrg-");
            string osProviderName = Recording.GenerateAssetName("sapnetw-");

            // Create SAP Monitor
            SapMonitorData sapMonitorData = new SapMonitorData(AzureLocation.EastUS2);
            sapMonitorData.AppLocation = AzureLocation.EastUS;
            sapMonitorData.MonitorSubnetId = new ResourceIdentifier(
                "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/nitin-agarwal-scale-test/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1306-3");
            sapMonitorData.RoutingPreference = RoutingPreference.RouteAll;
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = mrgName
            };

            // Create SAP monitor
            ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                sapMonitorData);

            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Get SAP monitor
            Response<SapMonitorResource> getMonitor = await rg.GetSapMonitorAsync(resourceName);
            Assert.AreEqual(resourceName, getMonitor.Value.Data.Name);

            SapProviderInstanceData sapProviderInstanceData = new SapProviderInstanceData();
            PrometheusOSProviderInstanceProperties osProviderInstanceProperties = new PrometheusOSProviderInstanceProperties();
            osProviderInstanceProperties.PrometheusUri = new Uri("http://10.0.44.4:9100/metrics");
            sapProviderInstanceData.ProviderSettings = osProviderInstanceProperties;

            // Create OS provider
            ArmOperation<SapProviderInstanceResource> providerResource = await resource
                .Value
                .GetSapProviderInstances()
                .CreateOrUpdateAsync(
                WaitUntil.Completed,
                osProviderName,
                sapProviderInstanceData);

            Assert.AreEqual(osProviderName, providerResource.Value.Data.Name);

            // Get OS Provider
            Response<SapProviderInstanceResource> getProvider = await resource.Value.GetSapProviderInstances().GetAsync(osProviderName);
            Assert.AreEqual(osProviderName, getProvider.Value.Data.Name);

            // Delete OS provider
            await providerResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapProviderInstanceResource> getDelProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(osProviderName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Provider {osProviderName} does not exist.");
            }

            //Delete SAP monitor
            await resource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapMonitorResource> getDelMonitor = await rg.GetSapMonitorAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Monitor {resourceName} does not exist.");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMonitorDb2ProviderCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                "suha-0802-rg1",
                AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("suha-0906-ams");
            string mrgName = Recording.GenerateAssetName("sapmonrg-");
            string db2ProviderName = Recording.GenerateAssetName("sapdb2-");

            // Create SAP Monitor
            SapMonitorData sapMonitorData = new SapMonitorData(AzureLocation.EastUS2);
            sapMonitorData.AppLocation = AzureLocation.EastUS;
            sapMonitorData.MonitorSubnetId = new ResourceIdentifier(
                "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/Basant-db2/providers/Microsoft.Network/virtualNetworks/db2-vnet/subnets/snet-db2-3");
            sapMonitorData.RoutingPreference = RoutingPreference.RouteAll;
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = mrgName
            };

            // Create SAP monitor
            ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                sapMonitorData);

            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Get SAP monitor
            Response<SapMonitorResource> getMonitor = await rg.GetSapMonitorAsync(resourceName);
             Assert.AreEqual(resourceName, getMonitor.Value.Data.Name);

            SapProviderInstanceData sapProviderInstanceData = new SapProviderInstanceData();
            DB2ProviderInstanceProperties db2ProviderInstanceProperties = new DB2ProviderInstanceProperties();
            db2ProviderInstanceProperties.DBUsername = "db2t05";
            db2ProviderInstanceProperties.DBName = "T05";
            db2ProviderInstanceProperties.SapSid = "OPA";
            db2ProviderInstanceProperties.DBPort = "5912";
            db2ProviderInstanceProperties.Hostname = "10.170.100.80";
            db2ProviderInstanceProperties.DBPassword = "Welcome1";
            sapProviderInstanceData.ProviderSettings = db2ProviderInstanceProperties;

            // Create DB2 provider
            ArmOperation<SapProviderInstanceResource> providerResource = await resource
                .Value
                .GetSapProviderInstances()
                .CreateOrUpdateAsync(
                WaitUntil.Completed,
                db2ProviderName,
                sapProviderInstanceData);

            Assert.AreEqual(db2ProviderName, providerResource.Value.Data.Name);

            // Get DB2 Provider
            Response<SapProviderInstanceResource> getProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(db2ProviderName);
            Assert.AreEqual(db2ProviderName, getProvider.Value.Data.Name);

            // Delete DB2 provider
            await providerResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapProviderInstanceResource> getDelProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(db2ProviderName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Provider {db2ProviderName} does not exist.");
            }

            //Delete SAP monitor
            await resource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapMonitorResource> getDelMonitor = await rg.GetSapMonitorAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Monitor {resourceName} does not exist.");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMonitorHAProviderCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                "suha-0802-rg1",
                AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("suha-0906-ams");
            string mrgName = Recording.GenerateAssetName("sapmonrg-");
            string haProviderName = Recording.GenerateAssetName("sapHa-");

            // Create SAP Monitor
            SapMonitorData sapMonitorData = new SapMonitorData(AzureLocation.EastUS2);
            sapMonitorData.AppLocation = AzureLocation.EastUS;
            sapMonitorData.MonitorSubnetId = new ResourceIdentifier(
                "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/nitin-agarwal-scale-test/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1306-5");
            sapMonitorData.RoutingPreference = RoutingPreference.RouteAll;
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = mrgName
            };

            // Create SAP monitor
            ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                sapMonitorData);

            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Get SAP monitor
            Response<SapMonitorResource> getMonitor = await rg.GetSapMonitorAsync(resourceName);
            Assert.AreEqual(resourceName, getMonitor.Value.Data.Name);

            SapProviderInstanceData sapProviderInstanceData = new SapProviderInstanceData();
            PrometheusHAClusterProviderInstanceProperties haProviderInstanceProperties = new PrometheusHAClusterProviderInstanceProperties();
            haProviderInstanceProperties.ClusterName = "hacluster";
            haProviderInstanceProperties.PrometheusUri = new Uri("http://10.0.92.6:9664/metrics");
            haProviderInstanceProperties.Hostname = "nfs2";
            haProviderInstanceProperties.Sid = "h10";

            sapProviderInstanceData.ProviderSettings = haProviderInstanceProperties;

            // Create HA provider
            ArmOperation<SapProviderInstanceResource> providerResource = await resource
                .Value
                .GetSapProviderInstances()
                .CreateOrUpdateAsync(
                WaitUntil.Completed,
                haProviderName,
                sapProviderInstanceData);

            Assert.AreEqual(haProviderName, providerResource.Value.Data.Name);

            // Get HA Provider
            Response<SapProviderInstanceResource> getProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(haProviderName);
            Assert.AreEqual(haProviderName, getProvider.Value.Data.Name);

            // Delete HA provider
            await providerResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapProviderInstanceResource> getDelProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(haProviderName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Provider {haProviderName} does not exist.");
            }

            //Delete SAP monitor
            await resource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapMonitorResource> getDelMonitor = await rg.GetSapMonitorAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Monitor {resourceName} does not exist.");
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMonitorMsSqlServerProviderCRUDOperations()
        {
            var resourceGroupName = Recording.GenerateAssetName("SdkRg");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                "suha-0802-rg1",
                AzureLocation.EastUS);
            string resourceName = Recording.GenerateAssetName("suha-0906-ams");
            string mrgName = Recording.GenerateAssetName("sapmonrg-");
            string sqlProviderName = Recording.GenerateAssetName("sapSql-");

            // Create SAP Monitor
            SapMonitorData sapMonitorData = new SapMonitorData(AzureLocation.EastUS2);
            sapMonitorData.AppLocation = AzureLocation.EastUS;
            sapMonitorData.MonitorSubnetId = new ResourceIdentifier(
                "/subscriptions/49d64d54-e966-4c46-a868-1999802b762c/resourceGroups/nitin-agarwal-scale-test/providers/Microsoft.Network/virtualNetworks/vnetpeeringtest/subnets/snet-1306-6");
            sapMonitorData.RoutingPreference = RoutingPreference.RouteAll;
            sapMonitorData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = mrgName
            };

            // Create SAP monitor
            ArmOperation<SapMonitorResource> resource = await rg.GetSapMonitors().CreateOrUpdateAsync(
                WaitUntil.Completed,
                resourceName,
                sapMonitorData);

            Assert.AreEqual(resourceName, resource.Value.Data.Name);

            // Get SAP monitor
            Response<SapMonitorResource> getMonitor = await rg.GetSapMonitorAsync(resourceName);
            Assert.AreEqual(resourceName, getMonitor.Value.Data.Name);

            SapProviderInstanceData sapProviderInstanceData = new SapProviderInstanceData();
            MsSqlServerProviderInstanceProperties sqlProviderInstanceProperties = new MsSqlServerProviderInstanceProperties();
            sqlProviderInstanceProperties.DBUsername = "mohit";
            sqlProviderInstanceProperties.DBPort = "1433";
            sqlProviderInstanceProperties.Hostname = "10.0.107.4";
            sqlProviderInstanceProperties.SapSid = "X00";
            sqlProviderInstanceProperties.DBPassword = "Password@123";

            sapProviderInstanceData.ProviderSettings = sqlProviderInstanceProperties;

            // Create SQL provider
            ArmOperation<SapProviderInstanceResource> providerResource = await resource
                .Value
                .GetSapProviderInstances()
                .CreateOrUpdateAsync(
                WaitUntil.Completed,
                sqlProviderName,
                sapProviderInstanceData);

            Assert.AreEqual(sqlProviderName, providerResource.Value.Data.Name);

            // Get SQL Provider
            Response<SapProviderInstanceResource> getProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(sqlProviderName);
            Assert.AreEqual(sqlProviderName, getProvider.Value.Data.Name);

            // Delete SQL provider
            await providerResource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapProviderInstanceResource> getDelProvider = await resource
                .Value
                .GetSapProviderInstances()
                .GetAsync(sqlProviderName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Provider {sqlProviderName} does not exist.");
            }

            //Delete SAP monitor
            await resource.Value.DeleteAsync(WaitUntil.Completed);

            try
            {
                Response<SapMonitorResource> getDelMonitor = await rg.GetSapMonitorAsync(resourceName);
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                Console.WriteLine($"Monitor {resourceName} does not exist.");
            }
        }
    }
}
