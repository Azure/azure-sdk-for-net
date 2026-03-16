// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceRegistry.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceRegistry.Tests.Scenario
{
    public class DeviceRegistryCredentialsAndPoliciesFlowTest : DeviceRegistryManagementTestBase
    {
        static DeviceRegistryCredentialsAndPoliciesFlowTest()
        {
            var testModeEnvVar = Environment.GetEnvironmentVariable("AZURE_TEST_MODE") ?? "(not set → defaults to Playback)";
            Console.WriteLine($"\n  AZURE_TEST_MODE = {testModeEnvVar}");
            // This allows running tests with specified test modes without needing to set env vars locally (e.g. in Visual Studio Test Explorer):
            // Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "PLAYBACK");
        }

        // Iteration number appended to the suffix for resource name uniqueness.
        // Change this locally when you need fresh resources (e.g., after a failed run).
        // Must match the -Iteration parameter used with the setup/teardown scripts.
        private const string Iteration = "1";  // e.g., "2", "3", etc. Empty string = no iteration.

        private readonly string _subscriptionId;
        private readonly string _resourceGroupName;
        private readonly AzureLocation _region;
        private readonly string _namespaceName;
        private readonly string _policyName;

        // PREREQUISITES
        // =============
        // Create RG, UAMI, ADR Namespace, IoT Hub, and DPS with ADR Integration BEFORE running in Record/Live mode.
        // Use the helper scripts in tests/Scripts/:
        //   Setup:    .\tests\Scripts\Setup-CmsTestPrerequisites.ps1 -Suffix both -Iteration <N> -NoPrompt
        //   Teardown: .\tests\Scripts\Teardown-CmsTestPrerequisites.ps1 -Suffix both -Iteration <N> -Force
        //
        // The scripts create these resources for each suffix (sync/async):
        //   Resource Group:    adr-sdk-test-cms-{suffix}{iteration}
        //   Managed Identity:  cms-test-uami-{suffix}{iteration}
        //   ADR Namespace:     cms-test-namespace-{suffix}{iteration}
        //   IoT Hub (GEN2):    adr-sdk-cms-test-hub-{suffix}{iteration}
        //   DPS:               adr-sdk-cms-test-dps-{suffix}{iteration}
        //
        // The test itself creates and deletes Credential and Policy resources during execution.

        public DeviceRegistryCredentialsAndPoliciesFlowTest(bool isAsync) : base(isAsync)
        {
            _subscriptionId = "53cd450b-b108-4e6e-b048-f63c1dcc8c8f";
            _region = new AzureLocation("eastus2euap");

            // Suffix distinguishes async vs sync test runs; iteration allows fresh resource sets.
            string suffix = (isAsync ? "async" : "sync") + Iteration;

            _resourceGroupName = $"adr-sdk-test-cms-{suffix}";
            _namespaceName = $"cms-test-namespace-{suffix}";
            _policyName = $"cms-test-policy-{suffix}";
        }

        [RecordedTest]
        public async Task TestCredentialAndPolicyFlow()
        {
            // Log test mode — AZURE_TEST_MODE env var controls this.
            // Default is Playback (replays recorded sessions). Set to Record to re-record.
            //   PowerShell:  $env:AZURE_TEST_MODE = "Record"
            //   CMD:         set AZURE_TEST_MODE=Record
            // NOTE: Visual Studio requires restart after setting env vars.
            var testModeEnvVar = Environment.GetEnvironmentVariable("AZURE_TEST_MODE") ?? "(not set → defaults to Playback)";
            Console.WriteLine($"\n  AZURE_TEST_MODE = {testModeEnvVar}");
            Console.WriteLine($"  Effective Mode  = {Mode}\n");

            var sw = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine($"\n{'=' * 60}");
            Console.WriteLine($"TEST STARTED at {DateTime.Now:yyyy-MM-dd HH:mm:ss}  [Mode={Mode}]");
            Console.WriteLine($"{'=' * 60}\n");

            // Setup: Get resource group
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 1: Getting resource group...");
            var rgId = new ResourceIdentifier($"/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroupName}");
            var rg = Client.GetResourceGroupResource(rgId);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Resource group retrieved\n");

            // Get existing namespace (prerequisite - created via Azure CLI)
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 2: Getting namespace '{_namespaceName}'...");
            var namespacesCollection = rg.GetDeviceRegistryNamespaces();
            var namespaceResponse = await namespacesCollection.GetAsync(_namespaceName, CancellationToken.None);
            DeviceRegistryNamespaceResource namespaceResource = namespaceResponse.Value;

            Assert.IsNotNull(namespaceResource);
            Assert.AreEqual(namespaceResource.Data.Location, _region);
            Assert.AreEqual(namespaceResource.Data.Name, _namespaceName);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Namespace retrieved successfully\n");

            // Test Credential Flow
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 3: Checking if credential exists...");
            var credentialCollection = namespaceResource.GetCredentials();

            CredentialResource credentialResource;
            bool credentialExists = await credentialCollection.ExistsAsync(CancellationToken.None);

            if (!credentialExists)
            {
                // Create credential
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Creating new credential (this may take several minutes)...");
                var credentialData = new CredentialData(_region);
                var credentialOperation = await credentialCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    credentialData,
                    CancellationToken.None);
                credentialResource = credentialOperation.Value;
                Assert.IsNotNull(credentialResource);
                Assert.AreEqual(credentialResource.Data.Location, _region);
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Credential created successfully\n");

                // Allow backend propagation after credential creation
                await DelayForPropagationAsync(10, "Waiting for credential propagation...", sw);
            }
            else
            {
                // Get existing credential
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Credential already exists, retrieving...");
                var credentialResponse = await credentialCollection.GetAsync(CancellationToken.None);
                credentialResource = credentialResponse.Value;
                Assert.IsNotNull(credentialResource);
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Credential retrieved successfully\n");
            }

            // Verify credential was created or retrieved successfully
            Assert.IsNotNull(credentialResource.Data);
            Assert.AreEqual(credentialResource.Data.Location, _region);

            // Test Policy Flow
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 4: Checking if policy '{_policyName}' exists...");
            var policyCollection = credentialResource.GetPolicies();

            PolicyResource policyResource;
            bool policyExists = await policyCollection.ExistsAsync(_policyName, CancellationToken.None);

            if (!policyExists)
            {
                // Create certificate configuration
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Creating new policy with ECC certificate (90-day validity)...");
                var certificateAuthorityConfig = new CertificateAuthorityConfiguration(SupportedKeyType.ECC);
                var leafCertificateConfig = new LeafCertificateConfiguration(validityPeriodInDays: 90);
                var certificateConfig = new CertificateConfiguration(
                    certificateAuthorityConfig,
                    leafCertificateConfig.ValidityPeriodInDays);

                // Create policy data with certificate configuration
                var policyData = new PolicyData()
                {
                    Location = _region.Name,
                    Properties = new PolicyProperties()
                    {
                        Certificate = certificateConfig
                    }
                };

                // Create the policy
                var policyOperation = await policyCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    _policyName,
                    policyData,
                    CancellationToken.None);
                policyResource = policyOperation.Value;
                Assert.IsNotNull(policyResource);
                Assert.AreEqual(policyResource.Data.Location, _region.Name);
                Assert.AreEqual(policyResource.Data.Name, _policyName);
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Policy created successfully\n");

                // Allow backend propagation after policy creation
                await DelayForPropagationAsync(10, "Waiting for policy propagation...", sw);
            }
            else
            {
                // Get existing policy
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Policy already exists, retrieving...");
                var policyResponse = await policyCollection.GetAsync(_policyName, CancellationToken.None);
                policyResource = policyResponse.Value;
                Assert.IsNotNull(policyResource);
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Policy retrieved successfully\n");
            }

            // Verify policy was created or retrieved successfully
            Assert.IsNotNull(policyResource.Data);
            Assert.AreEqual(policyResource.Data.Location, _region.Name);
            Assert.IsNotNull(policyResource.Data.Properties);
            Assert.IsNotNull(policyResource.Data.Properties.Certificate);

            // Verify certificate configuration details
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Verifying certificate properties...");
            Assert.AreEqual(SupportedKeyType.ECC,
                policyResource.Data.Properties.Certificate.CertificateAuthorityConfiguration.KeyType);
            Assert.AreEqual(90,
                policyResource.Data.Properties.Certificate.LeafCertificateValidityPeriodInDays);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   ✓ Certificate: ECC key type, 90-day validity");

            // Verify provisioning state
            Assert.AreEqual(DeviceRegistryProvisioningState.Succeeded,
                policyResource.Data.Properties.ProvisioningState);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   ✓ Provisioning state: Succeeded");

            // Test Policy List operation
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Testing LIST operation...");
            var allPolicies = new System.Collections.Generic.List<PolicyResource>();
            await foreach (var policy in policyCollection.GetAllAsync())
            {
                allPolicies.Add(policy);
            }
            Assert.IsTrue(allPolicies.Any(p => p.Data.Name == _policyName));
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   ✓ LIST operation successful, found {allPolicies.Count} policy(ies)\n");

            // Synchronize Credentials with IoT Hub
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 5: Synchronizing credentials with IoT Hub (this may take several minutes)...");
            var syncOperation = await credentialResource.SynchronizeAsync(
                WaitUntil.Completed,
                CancellationToken.None);

            // Verify sync completed successfully
            Assert.IsNotNull(syncOperation);
            Assert.IsTrue(syncOperation.HasCompleted);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Synchronization completed successfully\n");

            // Allow extra time for IoT Hub synchronization propagation
            await DelayForPropagationAsync(10, "Waiting for IoT Hub synchronization propagation...", sw);

            // Step 6: GET fresh policy after sync before updating
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 6: Getting fresh policy after sync...");
            var policyGetAfterSyncResponse = await policyCollection.GetAsync(_policyName, CancellationToken.None);
            policyResource = policyGetAfterSyncResponse.Value;
            var currentValidity = policyResource.Data.Properties.Certificate.LeafCertificateValidityPeriodInDays;
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Fresh policy retrieved (current validity: {currentValidity} days)\n");

            // Step 7: Test Policy Update - minimal change (only validity period)
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 7: Testing UPDATE operation - changing validity from {currentValidity} to 60 days...");

            // Output policy state before update
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   BEFORE UPDATE (JSON):");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(policyResource.Data, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));

            var policyPatch = new PolicyPatch();
            policyPatch.Properties = new PolicyUpdateProperties()
            {
                Certificate = new CertificateConfiguration(
                    policyResource.Data.Properties.Certificate.CertificateAuthorityConfiguration,  // Reuse existing config
                    60
                )
            };

            var updateOperation = await policyResource.UpdateAsync(
                WaitUntil.Completed,
                policyPatch,
                CancellationToken.None);

            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Update operation initiated (not waiting for completion)");

            // Allow time for update to propagate
            await DelayForPropagationAsync(20, "Waiting for update to propagate...", sw);

            // GET fresh policy after update to verify changes
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   Getting fresh policy after update...");
            var policyGetAfterUpdateResponse = await policyCollection.GetAsync(_policyName, CancellationToken.None);
            policyResource = policyGetAfterUpdateResponse.Value;

            // Output policy state after update
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   AFTER UPDATE (JSON):");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(policyResource.Data, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));

            // Verify update was successful
            Assert.AreEqual(60,
                policyResource.Data.Properties.Certificate.LeafCertificateValidityPeriodInDays);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Policy updated successfully, validity now 60 days\n");

            // Clean up: Delete Policy
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 8: Deleting policy '{_policyName}'...");
            var policyDeleteOperation = await policyResource.DeleteAsync(
                WaitUntil.Completed,
                CancellationToken.None);

            // Verify policy deletion completed
            Assert.IsNotNull(policyDeleteOperation);
            Assert.IsTrue(policyDeleteOperation.HasCompleted);

            // Allow backend cleanup after policy deletion
            await DelayForPropagationAsync(10, "Waiting for policy deletion propagation...", sw);

            // Verify policy no longer exists
            bool policyExistsAfterDelete = await policyCollection.ExistsAsync(_policyName, CancellationToken.None);
            Assert.IsFalse(policyExistsAfterDelete);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Policy deleted successfully\n");

            // Clean up: Delete Credential
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] Step 9: Deleting credential...");
            var credentialDeleteOperation = await credentialResource.DeleteAsync(
                WaitUntil.Completed,
                CancellationToken.None);

            // Verify credential deletion completed
            Assert.IsNotNull(credentialDeleteOperation);
            Assert.IsTrue(credentialDeleteOperation.HasCompleted);

            // Allow backend cleanup after credential deletion
            await DelayForPropagationAsync(10, "Waiting for credential deletion propagation...", sw);

            // Verify credential no longer exists
            bool credentialExistsAfterDelete = await credentialCollection.ExistsAsync(CancellationToken.None);
            Assert.IsFalse(credentialExistsAfterDelete);
            Console.WriteLine($"[{sw.Elapsed:mm\\:ss}] ✓ Credential deleted successfully\n");

            Console.WriteLine($"{'=' * 60}");
            Console.WriteLine($"TEST COMPLETED at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Total Duration: {sw.Elapsed:mm\\:ss\\.fff}");
            Console.WriteLine($"{'=' * 60}\n");
        }

        /// <summary>
        /// Helper method to add delays for resource propagation in Live or Record modes.
        /// </summary>
        /// <param name="seconds">Number of seconds to delay</param>
        /// <param name="message">Message to display during the delay</param>
        /// <param name="sw">Stopwatch for elapsed time tracking</param>
        private async Task DelayForPropagationAsync(int seconds, string message, System.Diagnostics.Stopwatch sw)
        {
            if (Mode == RecordedTestMode.Live || Mode == RecordedTestMode.Record)
            {
                Console.WriteLine($"[{sw.Elapsed:mm\\:ss}]   {message}");
                await Task.Delay(TimeSpan.FromSeconds(seconds));
            }
        }
    }
}
