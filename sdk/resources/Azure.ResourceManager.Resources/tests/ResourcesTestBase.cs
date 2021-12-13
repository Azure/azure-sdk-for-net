// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace Azure.ResourceManager.Resources.Tests
{
    public class ResourcesTestBase : ManagementRecordedTestBase<ResourcesTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected ResourcesTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode, useLegacyTransport: true)
        {
        }

        protected ResourcesTestBase(bool isAsync)
            : base(isAsync, useLegacyTransport: true)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected static ApplicationDefinitionData CreateApplicationDefinitionData(string displayName) => new ApplicationDefinitionData(Location.WestUS2, ApplicationLockLevel.None)
        {
            DisplayName = displayName,
            Description = $"{displayName} description",
            PackageFileUri = "https://raw.githubusercontent.com/Azure/azure-managedapp-samples/master/Managed%20Application%20Sample%20Packages/201-managed-storage-account/managedstorage.zip"
        };

        protected static ApplicationData CreateApplicationData(string applicationDefinitionId, string managedResourceGroupId, string storageAccountPrefix) => new ApplicationData(Location.WestUS2, "ServiceCatalog")
        {
            ApplicationDefinitionId = applicationDefinitionId,
            ManagedResourceGroupId = managedResourceGroupId,
            Parameters = new JsonObject()
            {
                {"storageAccountNamePrefix", new JsonObject()
                    {
                        {"value", storageAccountPrefix }
                    }
                },
                {"storageAccountType", new JsonObject()
                    {
                        {"value", "Standard_LRS" }
                    }
                }
            }
        };

        protected static DeploymentProperties CreateDeploymentProperties()
        {
            DeploymentProperties tmpDeploymentProperties = new DeploymentProperties(DeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new TemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json";
            tmpDeploymentProperties.Parameters = new JsonObject()
            {
                {"storageAccountType", new JsonObject()
                    {
                        {"value", "Standard_GRS" }
                    }
                }
            };
            return tmpDeploymentProperties;
        }

        protected static DeploymentInput CreateDeploymentData(DeploymentProperties deploymentProperties) => new DeploymentInput(deploymentProperties);

        private static GenericResourceData ConstructGenericUserAssignedIdentities()
        {
            var userAssignedIdentities = new GenericResourceData(Location.WestUS2);
            return userAssignedIdentities;
        }

        protected async Task<DeploymentScriptData> GetDeploymentScriptDataAsync()
        {
            //The user assigned identities was created firstly in Portal due to the unexpected behavior of using generic resource to create the user assigned identities.
            string rgName4Identities = "rg-for-DeployScript";
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            Subscription sub = await Client.GetDefaultSubscriptionAsync();
            var lro = await sub.GetResourceGroups().CreateOrUpdateAsync(rgName4Identities, rgData);
            ResourceGroup rg4Identities = lro.Value;
            GenericResourceData userAssignedIdentitiesData = ConstructGenericUserAssignedIdentities();
            ResourceIdentifier userAssignedIdentitiesId = rg4Identities.Id.AppendProviderResource("Microsoft.ManagedIdentity", "userAssignedIdentities", "test-user-assigned-msi");
            var lro2 = await sub.GetGenericResources().CreateOrUpdateAsync(userAssignedIdentitiesId, userAssignedIdentitiesData);
            GenericResource userAssignedIdentities = lro2.Value;
            var managedIdentity = new ManagedServiceIdentity()
            {
                Type = "UserAssigned",
                UserAssignedIdentities =
                {
                    {
                        userAssignedIdentitiesId,
                        new UserAssignedIdentity()
                    }
                }
            };
            string AzurePowerShellVersion = "2.7.0";
            TimeSpan RetentionInterval = new TimeSpan(1, 2, 0, 0, 0);
            string ScriptContent = "param([string] $helloWorld) Write-Output $helloWorld; $DeploymentScriptOutputs['output'] = $helloWorld";
            string ScriptArguments = "'Hello World'";
            return new AzurePowerShellScript(Location.WestUS2, RetentionInterval, AzurePowerShellVersion)
            {
                Identity = managedIdentity,
                ScriptContent = ScriptContent,
                Arguments = ScriptArguments
            };
        }

        protected static TemplateSpecData CreateTemplateSpecData(string displayName) => new TemplateSpecData(Location.WestUS2)
        {
            Description = "Description of my Template Spec",
            DisplayName = $"{displayName} (Test)"
        };

        protected static TemplateSpecVersionData CreateTemplateSpecVersionData() => new TemplateSpecVersionData(Location.WestUS2)
        {
            Description = "My first version",
            MainTemplate = JsonDocument.Parse(File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Scenario",
            "DeploymentTemplates",
            $"simple-storage-account.json"))).RootElement.GetObject()
        };
    }
}
