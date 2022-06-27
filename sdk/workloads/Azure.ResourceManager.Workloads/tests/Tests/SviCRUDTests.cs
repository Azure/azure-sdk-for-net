// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Workloads.Models;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    [TestFixture]
    public class SviCRUDTests : WorkloadsManagementTestBase
    {
        /// <summary>
        /// The Get Ops Extension Status Interval.
        /// </summary>
        private const int GetOpsIntervalinMillis = 30000;

        public SviCRUDTests(bool isAsync) : base(isAsync)
        { }

        [OneTimeTearDown]
        public void Cleanup()
        {
            CleanupResourceGroups();
        }

        /// <summary>
        /// The SVI CRUD test that creates and installs
        /// an SVI.
        /// </summary>
        [TestCase]
        [RecordedTest]
        public async Task TestSVICrudOperations()
        {
            // Create Test RG
            var resourceGroupName = Recording.GenerateAssetName("SdkRg-SVICrud");
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                resourceGroupName,
                AzureLocation.EastUS);

            SapVirtualInstanceData SviData = this.GetSingleServerPayloadToPut(rg.Data.Name, false);

            SapVirtualInstanceData SviInstallData = this.GetSingleServerPayloadToPut(rg.Data.Name, true);

            // Create SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: "F95",
                    data: SviData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            SapVirtualInstanceCollection collection = rg.GetSapVirtualInstances();

            // Install SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: "F95",
                    data: SviInstallData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Delete RG
            collection = rg.GetSapVirtualInstances();
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSVIStartStopOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var lro = await subscription.GetResourceGroups().GetAsync("E2E-SVI-DevBox-16Jun-avzone-RHEL-SAP-HA-84sapha-gen2");
            ResourceGroupResource rg = lro.Value;
            var sviObject1 = await lro.Value.GetSapVirtualInstanceAsync("F62");

            int count = 0;
            var sviObjectstatus = lro.Value.GetSapVirtualInstance("A13").Value.Data.Status;
            do
            {
                Thread.Sleep(GetOpsIntervalinMillis);
                sviObjectstatus = lro.Value.GetSapVirtualInstance("A13").Value.Data.Status;
                count++;
            }
            while (sviObjectstatus != SapVirtualInstanceStatus.Offline &&
                count < 6);
            Assert.Equals(lro.Value.GetSapVirtualInstance("A13").Value.Data.Status, SapVirtualInstanceStatus.Offline);
            lro.Value.GetSapVirtualInstance("A13").Value.Stop(WaitUntil.Completed);
            count = 0;
            do
            {
                Thread.Sleep(GetOpsIntervalinMillis);
                sviObjectstatus = lro.Value.GetSapVirtualInstance("A13").Value.Data.Status;
                count++;
            }
            while (sviObjectstatus != SapVirtualInstanceStatus.Running &&
                    count < 6);
            Assert.Equals(lro.Value.GetSapVirtualInstance("A13").Value.Data.Status, SapVirtualInstanceStatus.Running);
        }

        /// <summary>
        /// Gets an object of SAP Workload Resource for Single Server that should be used for PUT call.
        /// </summary>
        /// <param name="infraRgName"> Contains the infra RG
        /// used as app resource group. </param>
        /// <returns>PHP Workload Resource.</returns>
        private SapVirtualInstanceData GetSingleServerPayloadToPut(string infraRgName, bool isInstall)
        {
            var testSapWorkloadJson = File.ReadAllText(
                @"C:\Users\skottukkal\azure-sdk-for-net\sdk\workloads\Azure.ResourceManager.Workloads\tests\SingleServerInstall.json");
            //var testSapWorkload =
            //    JsonConvert.DeserializeObject<SapVirtualInstanceData>(testSapWorkloadJson);

            JObject jObject = JsonConvert.DeserializeObject(testSapWorkloadJson) as JObject;

            var deploymentConfiguration =
                JsonConvert.DeserializeObject<DeploymentConfiguration>(
                    jObject.SelectToken("properties.configuration").ToString());

            var singleServerConfiguration = JsonConvert.DeserializeObject<SingleServerConfiguration>(
                jObject.SelectToken("properties.configuration.infrastructureConfiguration").ToString());
            singleServerConfiguration.AppResourceGroup = infraRgName;

            var ssh = JsonConvert.DeserializeObject<SshConfiguration>(jObject.SelectToken("properties.configuration.infrastructureConfiguration.virtualMachineConfiguration.osProfile.osConfiguration.ssh").ToString());
            var osConfiguration = JsonConvert.DeserializeObject<LinuxConfiguration>(
                jObject.SelectToken(
                    "properties.configuration.infrastructureConfiguration." +
                    "virtualMachineConfiguration.osProfile.osConfiguration").ToString());

            osConfiguration.Ssh = ssh;
            singleServerConfiguration.VirtualMachineConfiguration.OSProfile.OSConfiguration = osConfiguration;
            ServiceInitiatedSoftwareConfiguration softwareConfiguration = null;

            if (isInstall)
            {
                softwareConfiguration = JsonConvert.DeserializeObject<ServiceInitiatedSoftwareConfiguration>(
                jObject.SelectToken("properties.configuration.softwareConfiguration").ToString());
                softwareConfiguration.SshPrivateKey = this.GetKeyVaultSecret("E2ETestPrivatesshkey");
            }
            else
            {
                softwareConfiguration = null;
            }

            singleServerConfiguration.VirtualMachineConfiguration
                .OSProfile.OSConfiguration = osConfiguration;

            deploymentConfiguration.InfrastructureConfiguration = singleServerConfiguration;
            deploymentConfiguration.SoftwareConfiguration = softwareConfiguration;

            SapVirtualInstanceData testSapWorkload = new SapVirtualInstanceData(
                location: AzureLocation.EastUS2,
                environment: SapEnvironmentType.NonProd,
                sapProduct: SapProductType.S4Hana,
                configuration: deploymentConfiguration);

            return testSapWorkload;
        }

        /// <summary>
        /// Gets the secret from key vault.
        /// </summary>
        /// <param name="secretName">The secret name for install.</param>
        /// <returns>The secret value.</returns>
        private string GetKeyVaultSecret(string secretName)
        {
            var kvUri = "https://waas-service-ct-kv.vault.azure.net/";
            var certificate = GetCertificateBySubjectName(
                        "HRME2ANew");

            var client = new SecretClient(new Uri(kvUri), new ClientCertificateCredential(
                "72f988bf-86f1-41af-91ab-2d7cd011db47",
                "d4b3c6a3-2fd1-4f46-b0c1-37220ff8d54d",
                certificate));

            KeyVaultSecret secret = client.GetSecret(secretName);
            return secret.Value;
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1600:Elements should be documented",
    Justification = "keeping related things together")]
        public class OsImage
        {
            [JsonProperty("Offer")]
            public string Offer { get; set; }

            [JsonProperty("Publisher")]
            public string Publisher { get; set; }

            [JsonProperty("Sku")]
            public string Sku { get; set; }

            [JsonProperty("Version")]
            public string Version { get; set; }

            [JsonProperty("platform")]
            public string Platform { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }
        }
    }
}
