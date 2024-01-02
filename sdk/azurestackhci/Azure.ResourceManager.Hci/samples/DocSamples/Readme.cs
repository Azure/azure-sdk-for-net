// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Hci;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.ResourceManager.Hci.Models;
using System.Security.Policy;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Readme
    {
        #region Snippet:Readme_DefineVars
        public string subscriptionId = "00000000-0000-0000-0000-000000000000";  // Replace with your subscription ID
        public string resourceGroupName = "hcicluster-rg";                      // Replace with your resource group name
        #endregion Snippet:Readme_DefineVars
        #region Snippet:Readme_DefineClusterName
        public string clusterName = "HCICluster";                               // Replace with your cluster name
        #endregion Snippet:Readme_DefineClusterName

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task InstallAMA()
        {
            #region Snippet:Readme_AuthClient
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);
            #endregion Snippet:Readme_AuthClient

            #region Snippet:Readme_InstallAMA
            // Create the Payload and invoke the operation
            string extensionName = "AzureMonitorWindowsAgent";
            string publisherName = "Microsoft.Azure.Monitor";
            string arcExtensionName = "AzureMonitorWindowsAgent";
            string typeHandlerVersion = "1.10";
            string workspaceId = "xx";  // workspace id for the log analytics workspace to be used with AMA extension
            string workspaceKey = "xx"; // workspace key for the log analytics workspace to be used with AMA extension
            bool enableAutomaticUpgrade = false;

            ArcExtensionData data = new ArcExtensionData()
            {
                Publisher = publisherName,
                ArcExtensionType = arcExtensionName,
                TypeHandlerVersion = typeHandlerVersion,
                Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    ["workspaceId"] = workspaceId
                }),
                ProtectedSettings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    ["workspaceKey"] = workspaceKey
                }),
                EnableAutomaticUpgrade = enableAutomaticUpgrade,
            };

            ResourceIdentifier arcSettingResourceId = ArcSettingResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default");
            ArcSettingResource arcSetting = client.GetArcSettingResource(arcSettingResourceId);
            ArcExtensionCollection collection = arcSetting.GetArcExtensions();

            // Create the Extension
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
            ArcExtensionResource resource = lro.Value;
            #endregion Snippet:Readme_InstallAMA
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void EnableHybridBenefits()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_EnableHybridBenefits
            ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);
            SoftwareAssuranceChangeContent content = new SoftwareAssuranceChangeContent()
            {
                SoftwareAssuranceIntent = SoftwareAssuranceIntent.Enable,
            };
            HciClusterResource result = (hciCluster.ExtendSoftwareAssuranceBenefitAsync(WaitUntil.Completed, content).Result).Value;
            #endregion Snippet:Readme_EnableHybridBenefits
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task UpdateClusterProps()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_UpdateClusterProps
            // Get the HCI Cluster
            ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);
            HciClusterPatch patch = new HciClusterPatch()
            {
                Tags =
                {
                    { "key", "value" }
                },
                DesiredProperties = new HciClusterDesiredProperties()
                {
                    WindowsServerSubscription = WindowsServerSubscription.Enabled,  // It can Enabled or Disabled
                    DiagnosticLevel = HciClusterDiagnosticLevel.Basic,              // It can be Off, Basic or Enhanced
                },
            };
            HciClusterResource result = await hciCluster.UpdateAsync(patch);
            #endregion Snippet:Readme_UpdateClusterProps
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteAllClusters()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_DeleteAllClusters
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // Get the collection of this HciClusterResource
            HciClusterCollection collection = resourceGroupResource.GetHciClusters();

            // Calling the delete function for all Cluster Resources in the collection
            await foreach (HciClusterResource item in collection.GetAllAsync())
            {
                // delete the item

                await item.DeleteAsync(WaitUntil.Completed);
            }
            #endregion Snippet:Readme_DeleteAllClusters
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteCluster()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_DeleteCluster
            // Get the HCI Cluster
            ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);

            // Invoke delete operation
            await hciCluster.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Readme_DeleteCluster
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ViewCluster()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_ViewCluster
            // Get the HCI Cluster
            string clusterName = "HCICluster"; // Replace with your cluster name,
            ResourceIdentifier hciClusterResourceId = HciClusterResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName);
            HciClusterResource hciCluster = client.GetHciClusterResource(hciClusterResourceId);

            // Invoke get operation
            HciClusterResource result = await hciCluster.GetAsync();
            #endregion Snippet:Readme_ViewCluster
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteExtension()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_DeleteExtension
            string extensionName = "AzureMonitorWindowsAgent"; // Replace with your extension name Some common examples are: AzureMonitorWindowsAgent, AzureSiteRecovery, AdminCenter
            ResourceIdentifier arcExtensionResourceId = ArcExtensionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default", extensionName);
            ArcExtensionResource arcExtension = client.GetArcExtensionResource(arcExtensionResourceId);
            // Invoke the delete operation
            await arcExtension.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Readme_DeleteExtension
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ExtensionUpgrade()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_ExtensionUpgrade
            string extensionName = "AzureMonitorWindowsAgent"; // Replace with your extension name Some common examples are: AzureMonitorWindowsAgent, AzureSiteRecovery, AdminCenter
            string targetVersion = "1.0.18062.0"; //replace with extension version you want to install
            ResourceIdentifier arcExtensionResourceId = ArcExtensionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default", extensionName);
            ArcExtensionResource arcExtension = client.GetArcExtensionResource(arcExtensionResourceId);
            // Invoke Upgrade operation
            ExtensionUpgradeContent content = new ExtensionUpgradeContent()
            {
                TargetVersion = targetVersion,
            };
            await arcExtension.UpgradeAsync(WaitUntil.Completed, content);
            #endregion Snippet:Readme_ExtensionUpgrade
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task InstallASR()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_InstallASR
            string publisherName = "Microsoft.SiteRecovery.Dra";
            string arcExtensionType = "Windows";
            string extensionName = "AzureSiteRecovery";
            ArcExtensionData data = new ArcExtensionData()
            {
                Publisher = publisherName,
                ArcExtensionType = arcExtensionType,
                EnableAutomaticUpgrade = true,
                Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    { "SubscriptionId", "your SubscriptionId" },
                    { "Environment", "AzureCloud" },
                    { "ResourceGroup", "your ResourceGroup" },
                    { "ResourceName", "your site recovery vault name" },
                    { "Location", "your site recovery region" },
                    { "SiteId", "Id for your recovery site" },
                    { "SiteName", "your recovery site name" },
                    { "PolicyId", "your resource id for recovery site policy" },
                    { "PrivateEndpointStateForSiteRecovery", "None" },
                })
            };

            // Get Arc Extension Resource
            ResourceIdentifier arcSettingResourceId = ArcSettingResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default");
            ArcSettingResource arcSetting = client.GetArcSettingResource(arcSettingResourceId);
            ArcExtensionCollection collection = arcSetting.GetArcExtensions();

            // Create the Extension
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
            ArcExtensionResource resource = lro.Value;
            #endregion Snippet:Readme_InstallASR
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task InstallWAC()
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            #region Snippet:Readme_InstallWAC
            // Create the payload and invoke the operation
            string extensionName = "AdminCenter";
            string publisherName = "Microsoft.AdminCenter";
            string arcExtensionType = "AdminCenter";
            string typeHandlerVersion = "1.10";
            string portNumber = "6516"; //port to be associated with WAC
            bool enableAutoUpgrade = false; // change to true to enable automatic upgrade

            ArcExtensionData data = new ArcExtensionData()
            {
                Publisher = publisherName,
                ArcExtensionType = arcExtensionType,
                TypeHandlerVersion = typeHandlerVersion,
                Settings = BinaryData.FromObjectAsJson(new Dictionary<string, object>()
                {
                    ["port"] = portNumber
                }),
                EnableAutomaticUpgrade = enableAutoUpgrade,
            };
            ResourceIdentifier arcSettingResourceId = ArcSettingResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, clusterName, "default");
            ArcSettingResource arcSetting = client.GetArcSettingResource(arcSettingResourceId);
            ArcExtensionCollection collection = arcSetting.GetArcExtensions();

            // Create the Extension
            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
            ArcExtensionResource resource = lro.Value;
            #endregion Snippet:Readme_InstallWAC
        }
    }
}
