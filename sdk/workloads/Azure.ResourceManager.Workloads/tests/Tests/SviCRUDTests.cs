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
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading;
using System.Drawing.Design;
using System.Reflection;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    public class SviCRUDTests : WorkloadsManagementTestBase
    {
        public SviCRUDTests(bool isAsync) : base(isAsync)
        { }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        /// <summary>
        /// The Get Ops Extension Status Interval.
        /// </summary>
        private const int GetStatusIntervalinMillis = 10000;

        /// <summary>
        /// The SVI CRUD test that creates and installs
        /// an SVI.
        /// </summary>
        [TestCase]
        [RecordedTest]
        public async Task TestSVICrudOperations()
        {
            string SviName = "F97";
            // Create Test RG
            var resourceGroupName = Recording.GenerateAssetName("SdkRg-SVICrud");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                resourceGroupName,
                AzureLocation.EastUS);

            SapVirtualInstanceData SviCreatePayload = this.GetSingleServerPayloadToPut(rg.Data.Name, false);

            // Create SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: SviName,
                    data: SviCreatePayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            SapVirtualInstanceData SviInstallPayload = this.GetSingleServerPayloadToPut(rg.Data.Name, true);

            // Install SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: SviName,
                    data: SviInstallPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var sviObject1 = await rg.GetSapVirtualInstanceAsync(SviName);

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

        [TestCase]
        [RecordedTest]
        public async Task TestSVIPatchCall()
        {
            string sviName = "G80";
            string rgName = "E2E-SVI-DevBox-29Jun-distributed-SLES-SAP-12-sp4-gen2";

            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var lro = await subscription.GetResourceGroups().GetAsync(rgName);
            ResourceGroupResource rg = lro.Value;
            var sviObject = await lro.Value.GetSapVirtualInstanceAsync(sviName);

            // Patch call for SVI
            await sviObject.Value.AddTagAsync("TestKey1", "TestValue1");

            Thread.Sleep(GetStatusIntervalinMillis);
            var firsttag = sviObject.Value.Data.Tags.Values.GetEnumerator();
            firsttag.MoveNext();
            Assert.AreEqual(firsttag.Current, "TestValue1");
            await sviObject.Value.GetTagResource().DeleteAsync(WaitUntil.Completed);
        }

        /// <summary>
        /// Gets an object of SAP Workload Resource for Single Server that should be used for PUT call.
        /// </summary>
        /// <param name="infraRgName"> Contains the infra RG
        /// used as app resource group. </param>
        /// <returns>PHP Workload Resource.</returns>
        private SapVirtualInstanceData GetSingleServerPayloadToPut(string infraRgName, bool isInstall)
        {
            var testSapWorkloadJson = File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SingleServerInstall.json"));
            var sapPayloadJson = JsonDocument.Parse(testSapWorkloadJson).RootElement;

            SapVirtualInstanceData testSapWorkload = SapVirtualInstanceData.DeserializeSapVirtualInstanceData(
                sapPayloadJson);

            DeploymentConfiguration deploymentConfiguration = DeploymentConfiguration.DeserializeDeploymentConfiguration(
                sapPayloadJson.GetProperty("properties").GetProperty("configuration"));

            deploymentConfiguration.InfrastructureConfiguration.AppResourceGroup = infraRgName;

            if (isInstall)
            {
                // Creating the installation payload after fetching the SshPrivateKey
                ServiceInitiatedSoftwareConfiguration softwareConfiguration =
                    ServiceInitiatedSoftwareConfiguration.DeserializeServiceInitiatedSoftwareConfiguration(
                        sapPayloadJson.GetProperty("properties").GetProperty("configuration").GetProperty("softwareConfiguration"));

                string sshPrivateKey = File.ReadAllText(Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SshKeyPrivate.txt"));

                softwareConfiguration.SshPrivateKey = sshPrivateKey;
                deploymentConfiguration.SoftwareConfiguration = softwareConfiguration;
            }
            // Create payload does not have Software Configuration
            else
            {
                deploymentConfiguration.SoftwareConfiguration = null;
            }

            testSapWorkload.Configuration = deploymentConfiguration;

            return testSapWorkload;
        }

        /// <summary>
        /// Gets the certificate from local store.
        /// </summary>
        /// <param name="certSubjectName">Certificate subject name.</param>
        /// <returns>Certificate object.</returns>
        public static X509Certificate2 GetCertificateBySubjectName(string certSubjectName)
        {
            using (var machineCertStore = new X509Store(StoreName.My, StoreLocation.LocalMachine))
            {
                machineCertStore.Open(OpenFlags.ReadOnly);

                var certCollection = machineCertStore.Certificates.Find(
                    X509FindType.FindBySubjectName,
                    certSubjectName,
                    false);
                if (certCollection.Count == 0)
                {
                    throw new ArgumentException(
                        $"Certificate with subject name: {certSubjectName} is not present in local " +
                        $"machine store.");
                }
                else
                {
                    X509Certificate2 selectedCert = certCollection[0];
                    foreach (X509Certificate2 cert in certCollection)
                    {
                        if (cert.NotBefore > selectedCert.NotBefore)
                        {
                            selectedCert = cert;
                        }
                    }

                    return selectedCert;
                }
            }
        }
    }
}
