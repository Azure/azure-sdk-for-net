// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Workloads.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Workloads.Tests.Tests
{
    public class SapVirtualInstanceCRUDTests : WorkloadsManagementTestBase
    {
        public SapVirtualInstanceCRUDTests(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..privateKey");
            JsonPathSanitizers.Add("$..fencingClientPassword");
        }

        private string _rgName;

        [TestCase]
        [RecordedTest]
        [LiveOnly(Reason = "Test regularly times out in playback.")]
        public async Task TestVisOperations()
        {
            _rgName ??= Recording.GenerateAssetName("netSdkTest-");
            const string filePath = "./payload/acss/CreateSapVirtualInstancePayload_ThreeTier.json";
            const string installFilePath = "./payload/acss/InstallSapVirtualInstancePayload.json";

            string resourceName = "ZW9";//Recording.GenerateAssetName("A").Substring(0, 3);
            SapVirtualInstanceResource resource = await createVis(filePath, installFilePath, resourceName);
            try
            {
                ArmOperation<OperationStatusResult> result = await resource.StopAsync(WaitUntil.Completed);
                Console.WriteLine("Stopped resource with Payload " + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Stopping resource" + ex);
            }

            try
            {
                ArmOperation<OperationStatusResult> result =
                    await resource.StartAsync(WaitUntil.Completed);
                Console.WriteLine("Starting resource with Payload " +
                    await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Stopping resource" + ex);
            }

            try
            {
                SapApplicationServerInstanceResource applicationServer =
                    await resource.GetSapApplicationServerInstanceAsync("app0");
                ArmOperation<OperationStatusResult> result =
                    await applicationServer.StopInstanceAsync(WaitUntil.Completed);
                Console.WriteLine("Stopped application server resource with Payload "
                    + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Stopping application resource" + ex);
            }

            try
            {
                SapCentralServerInstanceResource centralServer =
                    await resource.GetSapCentralServerInstanceAsync("cs0");
                ArmOperation<OperationStatusResult> result =
                    await centralServer.StopInstanceAsync(WaitUntil.Completed);
                Console.WriteLine("Stopped central server resource with Payload "
                    + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Stopping central server instance resource" + ex);
            }

            try
            {
                SapDatabaseInstanceResource databseServer =
                    await resource.GetSapDatabaseInstanceAsync("db0");
                ArmOperation<OperationStatusResult> result =
                    await databseServer.StopInstanceAsync(WaitUntil.Completed);
                Console.WriteLine("Stopped database server resource with Payload "
                    + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Stopping database server application resource" + ex);
            }

            try
            {
                SapApplicationServerInstanceResource applicationServer =
                    await resource.GetSapApplicationServerInstanceAsync("app0");
                ArmOperation<OperationStatusResult> result =
                    await applicationServer.StartInstanceAsync(WaitUntil.Completed);
                Console.WriteLine("Started application server resource with Payload "
                    + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Starting  application resource" + ex);
            }

            try
            {
                SapCentralServerInstanceResource centralServer =
                    await resource.GetSapCentralServerInstanceAsync("cs0");
                ArmOperation<OperationStatusResult> result =
                    await centralServer.StartInstanceAsync(WaitUntil.Completed);
                Console.WriteLine("Started central server resource with Payload "
                    + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Starting central server instance resource" + ex);
            }

            try
            {
                SapDatabaseInstanceResource databseServer =
                    await resource.GetSapDatabaseInstanceAsync("db0");
                ArmOperation<OperationStatusResult> result =
                    await databseServer.StartInstanceAsync(WaitUntil.Completed);
                Console.WriteLine("Started database server resource with Payload "
                    + await getObjectAsString(result.Value.Status));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Starting database server application resource" + ex);
            }

            await resource.DeleteAsync(WaitUntil.Completed);
        }

        private async Task<SapVirtualInstanceResource> createVis(string filePath, String installfilePath, string resourceName)
        {
            Console.WriteLine("Starting VIS Resource tests for " + resourceName);
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupResource rg = await CreateResourceGroup(
                subscription,
                _rgName,
                AzureLocation.EastUS2);

            SapVirtualInstanceResource result = null;
            // Create SAP VIS
            JsonDocument jsonElement = GetJsonElement(filePath);
            var sviData = SapVirtualInstanceData.DeserializeSapVirtualInstanceData(jsonElement.RootElement);
            sviData.ManagedResourceGroupConfiguration = new ManagedRGConfiguration
            {
                Name = Recording.GenerateAssetName(resourceName + "mrg-")
            };

            string appRgName = Recording.GenerateAssetName(resourceName + "appRg-");
            DeploymentWithOSConfiguration deploymentWithOSConfiguration =
                (sviData.Configuration as DeploymentWithOSConfiguration);
            deploymentWithOSConfiguration.InfrastructureConfiguration.AppResourceGroup = appRgName;

            _ = await CreateResourceGroup(
                subscription,
                appRgName,
                AzureLocation.EastUS2);

            Console.WriteLine("Creating resource with Payload " + await getObjectAsString(sviData));
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances()
                    .CreateOrUpdateAsync(
                        WaitUntil.Completed,
                        resourceName,
                        sviData);

                Assert.AreEqual(resourceName, resource.Value.Data.Name);
                Console.WriteLine("Created resource with Payload " + await getObjectAsString(resource.Value.Data));

                // Get SAP VIS
                Response<SapVirtualInstanceResource> vis = await rg.GetSapVirtualInstanceAsync(resourceName);
                Assert.AreEqual(resourceName, vis.Value.Data.Name);
                Console.WriteLine("Fetched resource with Payload " + await getObjectAsString(vis.Value.Data));

                //Patch SAP VIS
                var visPatch = new SapVirtualInstancePatch();
                visPatch.Tags.Add("Key1", "TestPatchValue");
                Console.WriteLine("Patching resource with Payload " + await getObjectAsString(visPatch));
                vis = await vis.Value.UpdateAsync(visPatch);
                Assert.AreEqual(resourceName, vis.Value.Data.Name);
                Console.WriteLine("Patched resource with Payload " + await getObjectAsString(vis.Value.Data));
                result = vis.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating resource with Payload " + ex);
            }

            //Install SAP VIS.
            JsonDocument installJsonElement = GetJsonElement(installfilePath);
            var softwareConfiguration =
                SapInstallWithoutOSConfigSoftwareConfiguration.
                DeserializeSapInstallWithoutOSConfigSoftwareConfiguration(
                    installJsonElement.RootElement);
            deploymentWithOSConfiguration.SoftwareConfiguration = softwareConfiguration;

            Console.WriteLine("Installing resource with Payload " + await getObjectAsString(sviData));
            try
            {
                ArmOperation<SapVirtualInstanceResource> resource = await rg.GetSapVirtualInstances()
                    .CreateOrUpdateAsync(
                        WaitUntil.Completed,
                        resourceName,
                        sviData);

                Assert.AreEqual(resourceName, resource.Value.Data.Name);
                Console.WriteLine("Install resource with Payload " + await getObjectAsString(resource.Value.Data));

                // Get SAP VIS
                Response<SapVirtualInstanceResource> vis = await rg.GetSapVirtualInstanceAsync(resourceName);
                Assert.AreEqual(resourceName, vis.Value.Data.Name);
                Console.WriteLine("Fetched resource with Payload " + await getObjectAsString(vis.Value.Data));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Creating resource with Payload " + ex);
            }

            //List SAP VIS
            Console.WriteLine("Listing all VIS resources in RG " + rg.Id);

            AsyncPageable<SapVirtualInstanceResource> visResourceList = rg.GetSapVirtualInstances().GetAllAsync();
            IAsyncEnumerator<SapVirtualInstanceResource> asyncVisEnumerator = visResourceList.GetAsyncEnumerator();
            while (await asyncVisEnumerator.MoveNextAsync())
            {
                Console.WriteLine("Fetched Resource: " + await getObjectAsString(asyncVisEnumerator.Current.Data));
            }
            Console.WriteLine("Listed all resources");

            if (result != null)
            {
                //List SAP AppInstances
                Console.WriteLine("Listing all App resources in VIS " + result.Id);

                AsyncPageable<SapApplicationServerInstanceResource> appResourceList =
                    result.GetSapApplicationServerInstances().GetAllAsync();
                IAsyncEnumerator<SapApplicationServerInstanceResource> asyncAppEnumerator =
                    appResourceList.GetAsyncEnumerator();
                while (await asyncAppEnumerator.MoveNextAsync())
                {
                    Console.WriteLine("Fetched Resource: " +
                        await getObjectAsString(asyncAppEnumerator.Current.Data));
                }
                Console.WriteLine("Listed all resources");
                //List SAP DbInstances
                Console.WriteLine("Listing all DB resources in VIS " + result.Id);

                AsyncPageable<SapDatabaseInstanceResource> dbResourceList =
                    result.GetSapDatabaseInstances().GetAllAsync();
                IAsyncEnumerator<SapDatabaseInstanceResource> asyncDbEnumerator =
                    dbResourceList.GetAsyncEnumerator();
                while (await asyncDbEnumerator.MoveNextAsync())
                {
                    Console.WriteLine("Fetched Resource: " +
                        await getObjectAsString(asyncDbEnumerator.Current.Data));
                }
                Console.WriteLine("Listed all resources");
                //List SAP Central Instances
                Console.WriteLine("Listing all Central resources in VIS " + result.Id);

                AsyncPageable<SapCentralServerInstanceResource> centralResourceList =
                    result.GetSapCentralServerInstances().GetAllAsync();
                IAsyncEnumerator<SapCentralServerInstanceResource> asyncCentralEnumerator =
                    centralResourceList.GetAsyncEnumerator();
                while (await asyncCentralEnumerator.MoveNextAsync())
                {
                    Console.WriteLine("Fetched Resource: " +
                        await getObjectAsString(asyncCentralEnumerator.Current.Data));
                }
                Console.WriteLine("Listed all resources");
            }

            return result;
        }
    }
}
