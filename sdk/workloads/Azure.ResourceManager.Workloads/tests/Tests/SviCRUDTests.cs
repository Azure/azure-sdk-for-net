// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Workloads.Models;
using System.Text.Json;
using NUnit.Framework;
using Microsoft.CSharp.RuntimeBinder;
using System.Threading;
using System.Drawing.Design;
using System.Reflection;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    public class SviCRUDTests : WorkloadsManagementTestBase
    {
        public SviCRUDTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
            JsonPathSanitizers.Add("$.properties.configuration.infrastructureConfiguration.virtualMachineConfiguration" +
                ".osProfile.osConfiguration.ssh.publicKeys.[*].keyData");
            JsonPathSanitizers.Add("$.properties.configuration.softwareConfiguration.sshPrivateKey");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        /// <summary>
        /// The Get Ops Extension Status Interval.
        /// </summary>
        private const int GetStatusIntervalinMillis = 2000;

        /// <summary>
        /// The SVI CRUD test that creates and installs
        /// an SVI.
        /// </summary>
        [TestCase]
        [RecordedTest]
        public async Task TestSVICrudOperations()
        {
            string sviName = "F97";
            // Create Test RG
            var resourceGroupName = Recording.GenerateAssetName("SdkRg-SVICrud");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                resourceGroupName,
                AzureLocation.EastUS);

            SapVirtualInstanceData sviCreatePayload = this.GetSingleServerPayloadToPut(rg.Data.Name, false);

            // Create SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: sviName,
                    data: sviCreatePayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            SapVirtualInstanceData sviInstallPayload = this.GetSingleServerPayloadToPut(rg.Data.Name, true);

            // Install SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: sviName,
                    data: sviInstallPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var sviObject1 = await rg.GetSapVirtualInstanceAsync(sviName);

            // Delete RG
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSVIStartStopOperations()
        {
            string sviName = "E61";
            string rgName = "svi-loop-test-register-30Jun-avzone-44";

            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var lro = await subscription.GetResourceGroups().GetAsync(rgName);
            ResourceGroupResource rg = lro.Value;

            // Stop operation
            var sviObject1 = await lro.Value.GetSapVirtualInstanceAsync(sviName);
            await sviObject1.Value.StopAsync(WaitUntil.Completed);
            var sviObjectstatus = await lro.Value.GetSapVirtualInstanceAsync(sviName);
            Assert.AreEqual(sviObjectstatus.Value.Data.Status, SapVirtualInstanceStatus.Offline);

            // Start operation
            await sviObject1.Value.StartAsync(WaitUntil.Completed);
            sviObjectstatus = await lro.Value.GetSapVirtualInstanceAsync(sviName);
            Assert.AreEqual(sviObjectstatus.Value.Data.Status, SapVirtualInstanceStatus.Running);
        }

        //[TestCase(null)] TODO: need to re-record
        //[TestCase(false)] TODO: need to re-record
        //[TestCase(true)] TODO: need to re-record
        public async Task TestSVIPatchCall(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string sviName = "B83";
            string rgName = "svi-loop-test-register-02Jul-singleserver-88";
            string subID = "49d64d54-e966-4c46-a868-1999802b762c";

            ResourceIdentifier sviResourceID = SapVirtualInstanceResource.CreateResourceIdentifier(subID, rgName, sviName);
            ResourceIdentifier appServerResourceID =
                SapApplicationServerInstanceResource.CreateResourceIdentifier(subID, rgName, sviName, "app0");
            ResourceIdentifier dbServerResourceID =
                SapDatabaseInstanceResource.CreateResourceIdentifier(subID, rgName, sviName, "db0");
            ResourceIdentifier csServerResourceID =
                SapCentralServerInstanceResource.CreateResourceIdentifier(subID, rgName, sviName, "cs0");

            SapVirtualInstanceResource sapVirtualInstance = await Client.GetSapVirtualInstanceResource(sviResourceID).GetAsync();
            SapDatabaseInstanceResource sapDatabaseInstanceResource =
                await Client.GetSapDatabaseInstanceResource(dbServerResourceID).GetAsync();
            SapApplicationServerInstanceResource sapApplicationServerInstanceResource =
                await Client.GetSapApplicationServerInstanceResource(appServerResourceID).GetAsync();
            SapCentralServerInstanceResource sapCentralServerInstanceResource =
                await Client.GetSapCentralServerInstanceResource(csServerResourceID).GetAsync();

            // Patch call for SVI and child resources
            await sapVirtualInstance.AddTagAsync("TestKey1", "TestValue1");
            await sapApplicationServerInstanceResource.AddTagAsync("TestKey1", "TestValue1");
            await sapCentralServerInstanceResource.AddTagAsync("TestKey1", "TestValue1");
            await sapDatabaseInstanceResource.AddTagAsync("TestKey1", "TestValue1");

            Thread.Sleep(GetStatusIntervalinMillis);

            sapVirtualInstance =
                await Client.GetSapVirtualInstanceResource(sviResourceID).GetAsync();
            sapDatabaseInstanceResource =
                await Client.GetSapDatabaseInstanceResource(dbServerResourceID).GetAsync();
            sapApplicationServerInstanceResource =
                await Client.GetSapApplicationServerInstanceResource(appServerResourceID).GetAsync();
            sapCentralServerInstanceResource =
                await Client.GetSapCentralServerInstanceResource(csServerResourceID).GetAsync();

            var firsttag = sapVirtualInstance.Data.Tags.Values.GetEnumerator();
            firsttag.MoveNext();
            Assert.AreEqual(firsttag.Current, "TestValue1");

            firsttag = sapDatabaseInstanceResource.Data.Tags.Values.GetEnumerator();
            firsttag.MoveNext();
            Assert.AreEqual(firsttag.Current, "TestValue1");
            await sapDatabaseInstanceResource.GetTagResource().DeleteAsync(WaitUntil.Completed);

            firsttag = sapCentralServerInstanceResource.Data.Tags.Values.GetEnumerator();
            firsttag.MoveNext();
            Assert.AreEqual(firsttag.Current, "TestValue1");
            await sapCentralServerInstanceResource.GetTagResource().DeleteAsync(WaitUntil.Completed);

            firsttag = sapApplicationServerInstanceResource.Data.Tags.Values.GetEnumerator();
            firsttag.MoveNext();
            Assert.AreEqual(firsttag.Current, "TestValue1");
            await sapApplicationServerInstanceResource.GetTagResource().DeleteAsync(WaitUntil.Completed);
        }

        /// <summary>
        /// Gets an object of SAP Workload Resource for Single Server that should be used for PUT call.
        /// </summary>
        /// <param name="infraRgName"> Contains the infra RG
        /// used as app resource group. </param>
        /// <returns>PHP Workload Resource.</returns>
        private SapVirtualInstanceData GetSingleServerPayloadToPut(string infraRgName, bool isInstall)
        {
            // Reading constants from files.
            string sshPublicKey = File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SshKeyPublic.txt"));
            string fileName = isInstall ? "SingleServerInstall.json" : "SingleServerCreate.json";

            var testSapWorkloadJson = File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName));

            var sapPayloadJson = JsonDocument.Parse(testSapWorkloadJson).RootElement;
            SapVirtualInstanceData sviPayload = SapVirtualInstanceData.DeserializeSapVirtualInstanceData(
                sapPayloadJson);

            ((DeploymentConfiguration)sviPayload.Configuration).InfrastructureConfiguration.AppResourceGroup = infraRgName;

            ((LinuxConfiguration)((SingleServerConfiguration)((DeploymentConfiguration)sviPayload.Configuration).InfrastructureConfiguration)
                .VirtualMachineConfiguration.OSProfile.OSConfiguration).Ssh.PublicKeys[0] = new SshPublicKey(sshPublicKey);

            if (isInstall)
            {
                string sshPrivateKey = File.ReadAllText(Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SshKeyPrivate.txt"));
                ((ServiceInitiatedSoftwareConfiguration)((DeploymentConfiguration)sviPayload.Configuration)
                    .SoftwareConfiguration).SshPrivateKey = sshPrivateKey;
            }
            return sviPayload;
        }
    }
}
