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
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Threading;
using System.Drawing.Design;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    [TestFixture]
    public class SviCRUDTests : WorkloadsManagementTestBase
    {
        /// <summary>
        /// The Get Ops Extension Status Interval.
        /// </summary>
        private const int GetOpsIntervalinMillis = 30000;

        public SviCRUDTests() : base(true, RecordedTestMode.Record)
        {}

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

            SapVirtualInstanceData SviCreatePayload = this.GetSingleServerPayloadToPut(rg.Data.Name, false);

            // Create SVI
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances().CreateOrUpdateAsync(
                    waitUntil: WaitUntil.Completed,
                    sapVirtualInstanceName: "F97",
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
                    sapVirtualInstanceName: "F97",
                    data: SviInstallPayload);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            var sviObject1 = await rg.GetSapVirtualInstanceAsync("F97");

            // Delete RG
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestSVIStartStopOperations()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            var lro = await subscription.GetResourceGroups().GetAsync("E2E-SVI-DevBox-27Jun-avzone-SLES-SAP-12-sp4-gen2");
            ResourceGroupResource rg = lro.Value;

            // Stop operation
            var sviObject1 = await lro.Value.GetSapVirtualInstanceAsync("C11");
            await sviObject1.Value.StopAsync(WaitUntil.Completed);

            var sviObjectstatus = await lro.Value.GetSapVirtualInstanceAsync("C11");
            Assert.Equals(sviObjectstatus.Value.Data.Status, SapVirtualInstanceStatus.Offline);

            // Start operation
            await sviObject1.Value.StartAsync(WaitUntil.Completed);
            sviObjectstatus = await lro.Value.GetSapVirtualInstanceAsync("C11");
            Assert.Equals(sviObjectstatus.Value.Data.Status, SapVirtualInstanceStatus.Running);
        }

        /// <summary>
        /// Gets an object of SAP Workload Resource for Single Server that should be used for PUT call.
        /// </summary>
        /// <param name="infraRgName"> Contains the infra RG
        /// used as app resource group. </param>
        /// <returns>SVI Workload Resource.</returns>
        private SapVirtualInstanceData GetSingleServerPayloadToPut(string infraRgName, bool isInstall)
        {
            var testSapWorkloadJson = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), @"tests\SingleServerInstall.json"));
            var deploymentConfigurationJson = JsonDocument.Parse(testSapWorkloadJson).RootElement;
            DeploymentConfiguration deploymentConfiguration = DeploymentConfiguration.DeserializeDeploymentConfiguration(
                deploymentConfigurationJson.GetProperty("properties").GetProperty("configuration"));

            deploymentConfiguration.InfrastructureConfiguration.AppResourceGroup = infraRgName;

            if (isInstall)
            {
                // Creating the installation payload after fetching the SshPrivateKey
                ServiceInitiatedSoftwareConfiguration softwareConfiguration =
                    ServiceInitiatedSoftwareConfiguration.DeserializeServiceInitiatedSoftwareConfiguration(
                        deploymentConfigurationJson.GetProperty("properties").GetProperty("configuration").GetProperty("softwareConfiguration"));
                softwareConfiguration.SshPrivateKey = this.GetKeyVaultSecret("E2ETestPrivatesshkey");
                deploymentConfiguration.SoftwareConfiguration = softwareConfiguration;
            }
            else
            {
                deploymentConfiguration.SoftwareConfiguration = null;
            }

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
