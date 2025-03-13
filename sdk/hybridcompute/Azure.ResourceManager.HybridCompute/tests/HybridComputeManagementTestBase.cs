// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using Azure.Identity;
using Azure.ResourceManager.HybridCompute.Models;
using Azure.ResourceManager.Models;
using System.Collections.Generic;
using System.Xml;

namespace Azure.ResourceManager.HybridCompute.Tests
{
    public class HybridComputeManagementTestBase : ManagementRecordedTestBase<HybridComputeManagementTestEnvironment>
    {
        public ArmClient ArmClient { get; private set; }
        public ResourceIdentifier resourceGroupResourceId { get; set; }
        public ResourceGroupResource resourceGroupResource { get; set; }
        public HybridComputeMachineCollection collection { get; set; }
        public SubscriptionResource Subscription { get; set; }
        public HybridComputePrivateLinkScopeCollection scopeCollection { get; set; }
        public string subscriptionId = "b24cc8ee-df4f-48ac-94cf-46edf36b0fae";
        public string resourceGroupName = "ytongtest";
        public string scopeName = "myScope3";
        public string machineName = "testmachine";
        public string extensionName = "myExtension";
        // need to run private-endpoint-connection list and obtain from the 'name' property
        public string privateEndpointConnectionName = "pe-test";
        public string runCommandName = "myRunCommand";
        public string esuLicenseName = "myESULicense";
        public string resourceGroupNameNSP = "ytongtest";
        public string privateLinkScopeNameNSP = "myScope3";
        public string perimeterName = "15e77ed0-bfa3-4cfd-b4fb-3e272e6d0f57.testAssociation";
        public string machineNamePaygo = "WIN-IAH3TLSP7A8";
        public string resourceGroupNameProfile = "PayGo_cmdlet";

        protected HybridComputeManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected HybridComputeManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            ArmClient = GetArmClient();
        }

        protected async Task InitializeClients()
        {
            Subscription = await ArmClient.GetDefaultSubscriptionAsync();
            resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            resourceGroupResource = ArmClient.GetResourceGroupResource(resourceGroupResourceId);

            // get the collection of this HybridComputeMachineResource
            collection = resourceGroupResource.GetHybridComputeMachines();
        }

        protected async Task<HybridComputeMachineCollection> getMachineCollection()
        {
            // invoke the operation and iterate over the result
            await foreach (HybridComputeMachineResource item in collection.GetAllAsync())
            {
                HybridComputeMachineData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            return collection;
        }

        protected async Task<HybridComputeMachineData> getMachine()
        {
            HybridComputeMachineResource result = await collection.GetAsync(machineName);
            return result.Data;
        }

        protected async Task<HybridComputeMachineData> updateMachine()
        {
            ResourceIdentifier hybridComputeMachineResourceId = HybridComputeMachineResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, machineName);
            HybridComputeMachineResource hybridComputeMachine = ArmClient.GetHybridComputeMachineResource(hybridComputeMachineResourceId);

            HybridComputeMachinePatch patch = new HybridComputeMachinePatch()
            {
                Identity = new ManagedServiceIdentity("SystemAssigned"),
                LocationData = new HybridComputeLocation("Redmond"),
                OSProfile = new HybridComputeOSProfile()
                {
                    WindowsConfiguration = new HybridComputeWindowsConfiguration()
                    {
                        AssessmentMode = AssessmentModeType.ImageDefault,
                        PatchMode = PatchModeType.Manual,
                    },
                },
                ParentClusterResourceId = new ResourceIdentifier("{AzureStackHCIResourceId}"),
                PrivateLinkScopeResourceId = new ResourceIdentifier("/subscriptions/" + subscriptionId + "/resourceGroups/" + resourceGroupName + "/providers/Microsoft.HybridCompute/privateLinkScopes/" + scopeName),
            };
            HybridComputeMachineResource result = await hybridComputeMachine.UpdateAsync(patch);

            return result.Data;
        }

        protected async Task<MachineInstallPatchesResult> installPatch()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);

            MachineInstallPatchesContent content = new MachineInstallPatchesContent(XmlConvert.ToTimeSpan("PT4H"), VmGuestPatchRebootSetting.IfRequired)
            {
                WindowsParameters = new HybridComputeWindowsParameters()
                {
                    ClassificationsToInclude = {
                        VmGuestPatchClassificationWindow.Critical,VmGuestPatchClassificationWindow.Security
                        },
                    // The maximum published date for patches must be a DateTime value between last patch Tuesday and a week from today
                    MaxPatchPublishOn = DateTimeOffset.Parse("2024-11-20T02:36:43.0539904+00:00"),
                },
            };
            ArmOperation<MachineInstallPatchesResult> lro = await hybridComputeMachine.InstallPatchesAsync(WaitUntil.Completed, content);

            return lro.Value;
        }

        protected async Task<MachineAssessPatchesResult> assessPatch()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);

            // invoke the operation
            ArmOperation<MachineAssessPatchesResult> lro = await hybridComputeMachine.AssessPatchesAsync(WaitUntil.Completed);

            return lro.Value;
        }

       protected async Task<HybridComputeMachineExtensionData> createMachineExtension()
       {
            System.Text.UTF8Encoding encoding=new System.Text.UTF8Encoding();
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            HybridComputeMachineExtensionCollection extensionCollection = hybridComputeMachine.GetHybridComputeMachineExtensions();

            HybridComputeMachineExtensionData data = new HybridComputeMachineExtensionData(new AzureLocation("eastus"))
            {
                Properties = new MachineExtensionProperties()
                {
                    Publisher = "Microsoft.Azure.NetworkWatcher",
                    MachineExtensionPropertiesType = "NetworkWatcherAgentWindows",
                    TypeHandlerVersion = "1.4.2798.3",
                    Settings =
                    {
                        ["commandToExecute"] = new BinaryData("\"dir\""),
                    },
                },
            };
            ArmOperation<HybridComputeMachineExtensionResource> lro = await extensionCollection.CreateOrUpdateAsync(WaitUntil.Completed, extensionName, data);
            HybridComputeMachineExtensionResource result = lro.Value;

            return result.Data;
       }

       protected async Task<HybridComputeMachineExtensionData> updateMachineExtension()
       {
            ResourceIdentifier hybridComputeMachineExtensionResourceId = HybridComputeMachineExtensionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, machineName, extensionName);
            HybridComputeMachineExtensionResource hybridComputeMachineExtension = ArmClient.GetHybridComputeMachineExtensionResource(hybridComputeMachineExtensionResourceId);

            HybridComputeMachineExtensionPatch patch = new HybridComputeMachineExtensionPatch()
            {
                Publisher = "Microsoft.Azure.NetworkWatcher",
                MachineExtensionUpdatePropertiesType = "NetworkWatcherAgentWindows",
                TypeHandlerVersion = "1.4.2798.3",
                EnableAutomaticUpgrade = true,
                Settings =
                {
                    ["commandToExecute"] = new BinaryData("\"powershell.exe ls\""),
                },
            };
            ArmOperation<HybridComputeMachineExtensionResource> lro = await hybridComputeMachineExtension.UpdateAsync(WaitUntil.Completed, patch);
            HybridComputeMachineExtensionResource result = lro.Value;

            return result.Data;
       }

        protected async Task<HybridComputeMachineExtensionData> getMachineExtension()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            HybridComputeMachineExtensionCollection extensionCollection = hybridComputeMachine.GetHybridComputeMachineExtensions();

            HybridComputeMachineExtensionResource result = await extensionCollection.GetAsync(extensionName);

            return result.Data;
        }

        protected async Task<HybridComputeMachineExtensionCollection> getMachineExtensionCollection()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            HybridComputeMachineExtensionCollection extensionCollection = hybridComputeMachine.GetHybridComputeMachineExtensions();

            await foreach (HybridComputeMachineExtensionResource item in extensionCollection.GetAllAsync())
            {
                HybridComputeMachineExtensionData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            return extensionCollection;
        }

        protected async Task<HybridComputePrivateLinkScopeData> createPrivateLinkScope()
        {
            HybridComputePrivateLinkScopeCollection scopeCollection = resourceGroupResource.GetHybridComputePrivateLinkScopes();

            HybridComputePrivateLinkScopeData data = new HybridComputePrivateLinkScopeData(new AzureLocation("eastus"))
            {
                Properties = new HybridComputePrivateLinkScopeProperties()
                {
                    PublicNetworkAccess = "Disabled",
                },
            };

            ArmOperation<HybridComputePrivateLinkScopeResource> lro = await scopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, scopeName, data);
            HybridComputePrivateLinkScopeResource result = lro.Value;

            return result.Data;
        }

        protected async Task<HybridComputePrivateLinkScopeData> updatePrivateLinkScope()
        {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            // invoke the operation
            HybridComputePrivateLinkScopePatch patch = new HybridComputePrivateLinkScopePatch()
            {
                Tags =
                {
                    ["Tag1"] = "Value1",
                    ["Tag2"] = "Value2",
                },
            };
            HybridComputePrivateLinkScopeResource result = await hybridComputePrivateLinkScope.UpdateAsync(patch);
            return result.Data;
        }

        protected async Task<HybridComputePrivateLinkScopeData> getPrivateLinkScope()
        {
            scopeCollection = resourceGroupResource.GetHybridComputePrivateLinkScopes();
            HybridComputePrivateLinkScopeResource result = await scopeCollection.GetAsync(scopeName);

            return result.Data;
        }

        protected async Task<HybridComputePrivateLinkScopeCollection> getPrivateLinkScopeCollection()
        {
            scopeCollection = resourceGroupResource.GetHybridComputePrivateLinkScopes();

            await foreach (HybridComputePrivateLinkScopeResource item in scopeCollection.GetAllAsync())
            {
                HybridComputePrivateLinkScopeData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            return scopeCollection;
        }

        protected async Task<HybridComputePrivateLinkResourceData> getPrivateLinkResource()
        {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            HybridComputePrivateLinkResourceCollection collection = hybridComputePrivateLinkScope.GetHybridComputePrivateLinkResources();

            string groupName = "hybridcompute";
            HybridComputePrivateLinkResource result = await collection.GetAsync(groupName);

            return result.Data;
        }

        protected async Task<HybridComputePrivateLinkResourceCollection> getPrivateLinkResourceCollection()
        {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            HybridComputePrivateLinkResourceCollection privateLinkResourcecollection = hybridComputePrivateLinkScope.GetHybridComputePrivateLinkResources();

            await foreach (HybridComputePrivateLinkResource item in privateLinkResourcecollection.GetAllAsync())
            {
                HybridComputePrivateLinkResourceData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            return privateLinkResourcecollection;
        }

        protected async Task<HybridComputePrivateEndpointConnectionData> updatePrivateEndpointConnection()
        {
            ResourceIdentifier hybridComputePrivateEndpointConnectionResourceId = HybridComputePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName, privateEndpointConnectionName);
            HybridComputePrivateEndpointConnectionResource hybridComputePrivateEndpointConnection = ArmClient.GetHybridComputePrivateEndpointConnectionResource(hybridComputePrivateEndpointConnectionResourceId);

            HybridComputePrivateEndpointConnectionData data = new HybridComputePrivateEndpointConnectionData()
            {
                Properties = new HybridComputePrivateEndpointConnectionProperties()
                {
                    ConnectionState = new HybridComputePrivateLinkServiceConnectionStateProperty("Approved", "Approved by johndoe@contoso.com"),
                },
            };
            ArmOperation<HybridComputePrivateEndpointConnectionResource> lro = await hybridComputePrivateEndpointConnection.UpdateAsync(WaitUntil.Completed, data);
            HybridComputePrivateEndpointConnectionResource result = lro.Value;

            return result.Data;
        }

        protected async Task<HybridComputePrivateEndpointConnectionData> getPrivateEndpointConnection()
        {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            HybridComputePrivateEndpointConnectionCollection connectionCollection = hybridComputePrivateLinkScope.GetHybridComputePrivateEndpointConnections();
            HybridComputePrivateEndpointConnectionResource result = await connectionCollection.GetAsync(privateEndpointConnectionName);

            return result.Data;
        }

        protected async Task<HybridComputePrivateEndpointConnectionCollection> getPrivateEndpointConnectionCollection()
        {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            HybridComputePrivateEndpointConnectionCollection connectionCollection = hybridComputePrivateLinkScope.GetHybridComputePrivateEndpointConnections();

            await foreach (HybridComputePrivateEndpointConnectionResource item in connectionCollection.GetAllAsync())
            {
                HybridComputePrivateEndpointConnectionData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            return connectionCollection;
        }

        protected async Task<MachineRunCommandData> createRunCommand()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            MachineRunCommandCollection runCommandCollection = hybridComputeMachine.GetMachineRunCommands();

            MachineRunCommandData data = new MachineRunCommandData(new AzureLocation("eastus"))
            {
                Source = new MachineRunCommandScriptSource()
                {
                    Script = "Write-Host Hello World!",
                },
                Parameters =
                {
                    new RunCommandInputParameter("param1","value1"), new RunCommandInputParameter("param2","value2")
                },
                // AsyncExecution = false,
                // RunAsUser = "user1",
                // RunAsPassword = "<runAsPassword>",
                // TimeoutInSeconds = 3600,
                // OutputBlobUri = new Uri("https://mystorageaccount.blob.core.windows.net/myscriptoutputcontainer/MyScriptoutput.txt"),
                // ErrorBlobUri = new Uri("https://mystorageaccount.blob.core.windows.net/mycontainer/MyScriptError.txt"),
            };
            ArmOperation<MachineRunCommandResource> lro = await runCommandCollection.CreateOrUpdateAsync(WaitUntil.Completed, runCommandName, data);
            MachineRunCommandResource result = lro.Value;

            return result.Data;
        }

        protected async Task<MachineRunCommandData> updateRunCommand()
        {
            ResourceIdentifier machineRunCommandResourceId = MachineRunCommandResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, machineName, runCommandName);
            MachineRunCommandResource machineRunCommand = ArmClient.GetMachineRunCommandResource(machineRunCommandResourceId);

            MachineRunCommandData data = new MachineRunCommandData(new AzureLocation("eastus"))
            {
                Source = new MachineRunCommandScriptSource()
                {
                    Script = "Write-Host Hello World!",
                },
                Parameters =
                {
                    new RunCommandInputParameter("param1","value1"), new RunCommandInputParameter("param2","value2")
                },
                // AsyncExecution = false,
                // RunAsUser = "user1",
                // RunAsPassword = "<runAsPassword>",
                // TimeoutInSeconds = 3600,
                // OutputBlobUri = new Uri("https://mystorageaccount.blob.core.windows.net/myscriptoutputcontainer/MyScriptoutput.txt"),
                // ErrorBlobUri = new Uri("https://mystorageaccount.blob.core.windows.net/mycontainer/MyScriptError.txt"),
                Tags =
                {
                    ["Tag1"] = "Value1",
                    ["Tag2"] = "Value2",
                },
            };
            ArmOperation<MachineRunCommandResource> lro = await machineRunCommand.UpdateAsync(WaitUntil.Completed, data);
            MachineRunCommandResource result = lro.Value;

            return result.Data;
        }

        protected async Task<MachineRunCommandData> getRunCommand()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            MachineRunCommandCollection runCommandCollection = hybridComputeMachine.GetMachineRunCommands();

            MachineRunCommandResource result = await runCommandCollection.GetAsync(runCommandName);

            return result.Data;
        }

        protected async Task<MachineRunCommandCollection> getRunCommandCollection()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            MachineRunCommandCollection runCommandCollection = hybridComputeMachine.GetMachineRunCommands();

            await foreach (MachineRunCommandResource item in runCommandCollection.GetAllAsync())
            {
                MachineRunCommandData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            return runCommandCollection;
        }

        protected async Task<HybridComputeLicenseData> createEsuLicense()
       {
            HybridComputeLicenseCollection esuLicensecollection = resourceGroupResource.GetHybridComputeLicenses();

            HybridComputeLicenseData data = new HybridComputeLicenseData(new AzureLocation("eastus"))
            {
                LicenseType = "ESU",
                LicenseDetails = new HybridComputeLicenseDetails()
                {
                    State = "Activated",
                    Target = "Windows Server 2012",
                    Edition = "Datacenter",
                    LicenseCoreType = "pCore",
                    Processors = 16,
                },
            };
            ArmOperation<HybridComputeLicenseResource> lro = await esuLicensecollection.CreateOrUpdateAsync(WaitUntil.Completed, esuLicenseName, data);
            HybridComputeLicenseResource result = lro.Value;

            return result.Data;
       }

        protected async Task<HybridComputeLicenseData> getEsuLicense()
       {
            HybridComputeLicenseCollection esuLicensecollection = resourceGroupResource.GetHybridComputeLicenses();

            HybridComputeLicenseResource result = await esuLicensecollection.GetAsync(esuLicenseName);

            return result.Data;
       }

        protected async Task<HybridComputeLicenseCollection> getEsuLicenseCollection()
       {
            HybridComputeLicenseCollection esuLicensecollection = resourceGroupResource.GetHybridComputeLicenses();

            await foreach (HybridComputeLicenseResource item in esuLicensecollection.GetAllAsync())
            {
                HybridComputeLicenseData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }
            return esuLicensecollection;
       }

        protected async Task<HybridComputeLicenseData> updateEsuLicense()
       {
            ResourceIdentifier hybridComputeLicenseResourceId = HybridComputeLicenseResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, esuLicenseName);
            HybridComputeLicenseResource hybridComputeLicense = ArmClient.GetHybridComputeLicenseResource(hybridComputeLicenseResourceId);

            HybridComputeLicenseData data = new HybridComputeLicenseData(new AzureLocation("eastus"))
            {
                LicenseType = "ESU",
                LicenseDetails = new HybridComputeLicenseDetails()
                {
                    State = "Deactivated",
                    Target = "Windows Server 2012",
                    Edition = "Datacenter",
                    LicenseCoreType = "pCore",
                    Processors = 16,
                },
            };
            ArmOperation<HybridComputeLicenseResource> lro = await hybridComputeLicense.UpdateAsync(WaitUntil.Completed, data);
            HybridComputeLicenseResource result = lro.Value;

            return result.Data;
       }

        protected async Task<HybridComputeLicenseProfileData> createLicenseProfile()
       {
            ResourceIdentifier hybridComputeLicenseProfileResourceId = HybridComputeLicenseProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameProfile, machineNamePaygo);
            HybridComputeLicenseProfileResource hybridComputeLicenseProfile = ArmClient.GetHybridComputeLicenseProfileResource(hybridComputeLicenseProfileResourceId);

            // invoke the operation
            HybridComputeLicenseProfileData data = new HybridComputeLicenseProfileData(new AzureLocation("eastus"))
            {
                SubscriptionStatus = LicenseProfileSubscriptionStatus.Enabled,
                ProductType = LicenseProfileProductType.WindowsServer,
                ProductFeatures =
                {
                    new HybridComputeProductFeature()
                    {
                        Name = "Hotpatch",
                        SubscriptionStatus = LicenseProfileSubscriptionStatus.Enabled,
                    }
                },
            };
            ArmOperation<HybridComputeLicenseProfileResource> lro = await hybridComputeLicenseProfile.CreateOrUpdateAsync(WaitUntil.Completed, data);
            HybridComputeLicenseProfileResource result = lro.Value;

            return result.Data;
       }

        protected async Task<HybridComputeLicenseProfileData> getLicenseProfile()
       {
            ResourceIdentifier hybridComputeLicenseProfileResourceId = HybridComputeLicenseProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameProfile, machineNamePaygo);
            HybridComputeLicenseProfileResource hybridComputeLicenseProfile = ArmClient.GetHybridComputeLicenseProfileResource(hybridComputeLicenseProfileResourceId);

            HybridComputeLicenseProfileResource result = await hybridComputeLicenseProfile.GetAsync();

            return result.Data;
       }

        protected async Task<HybridComputeLicenseProfileData> updateLicenseProfile()
       {
            ResourceIdentifier hybridComputeLicenseProfileResourceId = HybridComputeLicenseProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameProfile, machineNamePaygo);
            HybridComputeLicenseProfileResource hybridComputeLicenseProfile = ArmClient.GetHybridComputeLicenseProfileResource(hybridComputeLicenseProfileResourceId);

            HybridComputeLicenseProfilePatch patch = new HybridComputeLicenseProfilePatch()
            {
                SubscriptionStatus = LicenseProfileSubscriptionStatusUpdate.Enable,
                ProductType = LicenseProfileProductType.WindowsServer,
                ProductFeatures =
                {
                    new HybridComputeProductFeatureUpdate()
                    {
                        Name = "Hotpatch",
                        SubscriptionStatus = LicenseProfileSubscriptionStatusUpdate.Enable,
                    }
                },
            };
            ArmOperation<HybridComputeLicenseProfileResource> lro = await hybridComputeLicenseProfile.UpdateAsync(WaitUntil.Completed, patch);
            HybridComputeLicenseProfileResource result = lro.Value;

            return result.Data;
       }

        protected async Task<NetworkSecurityPerimeterConfigurationCollection> getNspCollection()
       {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameNSP, privateLinkScopeNameNSP);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            NetworkSecurityPerimeterConfigurationCollection nspCollection = hybridComputePrivateLinkScope.GetNetworkSecurityPerimeterConfigurations();

            // invoke the operation and iterate over the result
            await foreach (NetworkSecurityPerimeterConfigurationResource item in nspCollection.GetAllAsync())
            {
                NetworkSecurityPerimeterConfigurationData resourceData = item.Data;
                Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            }

            return nspCollection;
       }

        protected async Task<NetworkSecurityPerimeterConfigurationData> getNsp()
       {
            ResourceIdentifier networkSecurityPerimeterConfigurationResourceId = NetworkSecurityPerimeterConfigurationResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameNSP, privateLinkScopeNameNSP, perimeterName);
            NetworkSecurityPerimeterConfigurationResource networkSecurityPerimeterConfiguration = ArmClient.GetNetworkSecurityPerimeterConfigurationResource(networkSecurityPerimeterConfigurationResourceId);

            NetworkSecurityPerimeterConfigurationResource result = await networkSecurityPerimeterConfiguration.GetAsync();

            return result.Data;
       }

        protected async Task invokeNsp()
       {
            ResourceIdentifier networkSecurityPerimeterConfigurationResourceId = NetworkSecurityPerimeterConfigurationResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameNSP, privateLinkScopeNameNSP, perimeterName);
            NetworkSecurityPerimeterConfigurationResource networkSecurityPerimeterConfiguration = ArmClient.GetNetworkSecurityPerimeterConfigurationResource(networkSecurityPerimeterConfigurationResourceId);

            // invoke the operation
            ArmOperation<NetworkSecurityPerimeterConfigurationReconcileResult> lro = await networkSecurityPerimeterConfiguration.ReconcileForPrivateLinkScopeAsync(WaitUntil.Completed);
            NetworkSecurityPerimeterConfigurationReconcileResult result = lro.Value;

            Console.WriteLine($"Invoke NSP Succeeded");
       }

        protected async Task deleteLicenseProfile()
        {
            ResourceIdentifier hybridComputeLicenseProfileResourceId = HybridComputeLicenseProfileResource.CreateResourceIdentifier(subscriptionId, resourceGroupNameProfile, machineNamePaygo);
            HybridComputeLicenseProfileResource hybridComputeLicenseProfile = ArmClient.GetHybridComputeLicenseProfileResource(hybridComputeLicenseProfileResourceId);

            await hybridComputeLicenseProfile.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Delete License Profile Succeeded");
        }

        protected async Task deleteEsuLicense()
        {
            ResourceIdentifier hybridComputeLicenseResourceId = HybridComputeLicenseResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, esuLicenseName);
            HybridComputeLicenseResource hybridComputeLicense = ArmClient.GetHybridComputeLicenseResource(hybridComputeLicenseResourceId);

            await hybridComputeLicense.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Delete ESU License Succeeded");
        }

        protected async Task deleteRunCommand()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            MachineRunCommandCollection runCommandCollection = hybridComputeMachine.GetMachineRunCommands();

            MachineRunCommandResource result = await runCommandCollection.GetAsync(runCommandName);

            await result.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Delete Machine Run Command Succeeded");
        }

        protected async Task deletePrivateLinkScope()
        {
            ResourceIdentifier hybridComputePrivateLinkScopeResourceId = HybridComputePrivateLinkScopeResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName);
            HybridComputePrivateLinkScopeResource hybridComputePrivateLinkScope = ArmClient.GetHybridComputePrivateLinkScopeResource(hybridComputePrivateLinkScopeResourceId);

            await hybridComputePrivateLinkScope.DeleteAsync(WaitUntil.Completed);
        }

        protected async Task deletePrivateEndpointConnection()
        {
            ResourceIdentifier hybridComputePrivateEndpointConnectionResourceId = HybridComputePrivateEndpointConnectionResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, scopeName, privateEndpointConnectionName);
            HybridComputePrivateEndpointConnectionResource hybridComputePrivateEndpointConnection = ArmClient.GetHybridComputePrivateEndpointConnectionResource(hybridComputePrivateEndpointConnectionResourceId);

            await hybridComputePrivateEndpointConnection.DeleteAsync(WaitUntil.Completed);
        }

        protected async Task deleteMachineExtension()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            HybridComputeMachineExtensionCollection extensionCollection = hybridComputeMachine.GetHybridComputeMachineExtensions();

            HybridComputeMachineExtensionResource result = await extensionCollection.GetAsync(extensionName);

            await result.DeleteAsync(WaitUntil.Completed);
            Console.WriteLine($"Delete Machine Extension Succeeded");
        }
        protected async Task deleteMachine()
        {
            HybridComputeMachineResource hybridComputeMachine = await collection.GetAsync(machineName);
            await hybridComputeMachine.DeleteAsync(WaitUntil.Completed);

            Console.WriteLine($"Delete Machine Succeeded");
        }
    }
}
