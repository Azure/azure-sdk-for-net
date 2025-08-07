// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.Json;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
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
        : base(isAsync, mode)
        {
        }

        protected ResourcesTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

        protected static ArmApplicationDefinitionData CreateApplicationDefinitionData(string displayName) => new ArmApplicationDefinitionData(AzureLocation.WestUS2, ArmApplicationLockLevel.None)
        {
            DisplayName = displayName,
            Description = $"{displayName} description",
            PackageFileUri = new Uri("https://raw.githubusercontent.com/Azure/azure-managedapp-samples/master/Managed%20Application%20Sample%20Packages/201-managed-storage-account/managedstorage.zip")
        };

        protected static ArmApplicationData CreateApplicationData(ResourceIdentifier applicationDefinitionId, ResourceIdentifier managedResourceGroupId, string storageAccountPrefix) => new ArmApplicationData(AzureLocation.WestUS2, "ServiceCatalog")
        {
            ApplicationDefinitionId = applicationDefinitionId,
            ManagedResourceGroupId = managedResourceGroupId,
            Parameters = BinaryData.FromObjectAsJson(new JsonObject()
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
            })
        };

        protected static ArmDeploymentProperties CreateDeploymentProperties()
        {
            ArmDeploymentProperties tmpDeploymentProperties = new ArmDeploymentProperties(ArmDeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new ArmDeploymentTemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json");
            tmpDeploymentProperties.Parameters = BinaryData.FromObjectAsJson(new JsonObject()
            {
                {"storageAccountType", new JsonObject()
                    {
                        {"value", "Standard_GRS" }
                    }
                }
            });
            return tmpDeploymentProperties;
        }

        protected static ArmDeploymentProperties CreateDeploymentPropertiesAtSub()
        {
            ArmDeploymentProperties tmpDeploymentProperties = new ArmDeploymentProperties(ArmDeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new ArmDeploymentTemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/emptyrg.json");
            tmpDeploymentProperties.Parameters = BinaryData.FromObjectAsJson(new JsonObject()
            {
                {"rgName", new JsonObject()
                    {
                        {"value", "testDeployAtSub" }
                    }
                },
                {"rgLocation", new JsonObject()
                    {
                        {"value", $"{AzureLocation.CentralUS}" }
                    }
                },
            });
            return tmpDeploymentProperties;
        }

        protected static ArmDeploymentProperties CreateDeploymentPropertiesUsingString()
        {
            ArmDeploymentProperties tmpDeploymentProperties = new ArmDeploymentProperties(ArmDeploymentMode.Incremental);
            tmpDeploymentProperties.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Scenario",
            "DeploymentTemplates",
            $"storage-template.json")));
            tmpDeploymentProperties.Parameters = BinaryData.FromString(File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Scenario",
            "DeploymentTemplates",
            $"storage-parameters.json")));
            return tmpDeploymentProperties;
        }

        protected static ArmDeploymentProperties CreateDeploymentPropertiesUsingJsonElement()
        {
            ArmDeploymentProperties tmpDeploymentProperties = new ArmDeploymentProperties(ArmDeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new ArmDeploymentTemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json");
            var parametersObject = new { storageAccountType = new { value = "Standard_GRS" } };
            //convert this object to JsonElement
            var parametersString = JsonSerializer.Serialize(parametersObject);
            using var jsonDocument = JsonDocument.Parse(parametersString);
            var parameters = jsonDocument.RootElement;
            tmpDeploymentProperties.Parameters = BinaryData.FromString(parameters.GetRawText());
            return tmpDeploymentProperties;
        }

        protected static ArmDeploymentContent CreateDeploymentData(ArmDeploymentProperties deploymentProperties) => new ArmDeploymentContent(deploymentProperties);

        protected static ArmDeploymentContent CreateDeploymentData(ArmDeploymentProperties deploymentProperties, AzureLocation location) => new ArmDeploymentContent(deploymentProperties)
        {
            Location = location
        };

        protected static DeploymentStackData CreateRGDeploymentStackDataWithTemplate()
        {
            var data = new DeploymentStackData();

            data.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Scenario",
                    "DeploymentTemplates",
                    $"rg-stack-template.json")));

            data.DenySettings = new DenySettings(DenySettingsMode.None);

            data.ActionOnUnmanage = new ActionOnUnmanage()
            {
                Resources = DeploymentStacksDeleteDetachEnum.Detach,
                ResourceGroups = DeploymentStacksDeleteDetachEnum.Detach,
                ManagementGroups = DeploymentStacksDeleteDetachEnum.Detach
            };

            data.BypassStackOutOfSyncError = false;

            data.Parameters.Add("templateSpecName", new DeploymentParameter { Value = BinaryData.FromString("\"stacksTestTemplate4321\"") });

            return data;
        }

        protected static DeploymentStackData CreateSubDeploymentStackDataWithTemplate(AzureLocation location) {
            var data = new DeploymentStackData();

            data.Location = location;

            data.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Scenario",
                    "DeploymentTemplates",
                    $"sub-stack-template.json")));

            data.DenySettings = new DenySettings(DenySettingsMode.None);

            data.ActionOnUnmanage = new ActionOnUnmanage()
            {
                Resources = DeploymentStacksDeleteDetachEnum.Detach,
                ResourceGroups = DeploymentStacksDeleteDetachEnum.Detach,
                ManagementGroups = DeploymentStacksDeleteDetachEnum.Detach
            };

            data.BypassStackOutOfSyncError = false;

            data.Parameters.Add("rgName", new DeploymentParameter { Value = BinaryData.FromString("\"stacksTestRG4321\"") } );

            return data;
        }

        protected static DeploymentStackData CreateMGDeploymentStackDataWithTemplate(AzureLocation location)
        {
            var data = new DeploymentStackData();

            data.Location = location;

            data.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Scenario",
                    "DeploymentTemplates",
                    $"mg-stack-template.json")));

            data.DenySettings = new DenySettings(DenySettingsMode.None);

            data.ActionOnUnmanage = new ActionOnUnmanage()
            {
                Resources = DeploymentStacksDeleteDetachEnum.Detach,
                ResourceGroups = DeploymentStacksDeleteDetachEnum.Detach,
                ManagementGroups = DeploymentStacksDeleteDetachEnum.Detach
            };

            data.BypassStackOutOfSyncError = false;

            data.Parameters.Add("message", new DeploymentParameter { Value = BinaryData.FromString("\"hello world\"") });

            return data;
        }

        private static GenericResourceData ConstructGenericUserAssignedIdentities()
        {
            var userAssignedIdentities = new GenericResourceData(AzureLocation.WestUS2);
            return userAssignedIdentities;
        }

        protected async Task<ArmDeploymentScriptData> GetDeploymentScriptDataAsync()
        {
            //The user assigned identities was created firstly in Portal due to the unexpected behavior of using generic resource to create the user assigned identities.
            string rgName4Identities = "rg-for-DeployScript";
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            SubscriptionResource sub = await Client.GetDefaultSubscriptionAsync();
            var lro = await sub.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName4Identities, rgData);
            ResourceGroupResource rg4Identities = lro.Value;
            GenericResourceData userAssignedIdentitiesData = ConstructGenericUserAssignedIdentities();
            ResourceIdentifier userAssignedIdentitiesId = rg4Identities.Id.AppendProviderResource("Microsoft.ManagedIdentity", "userAssignedIdentities", "test-user-assigned-msi");
            var lro2 = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, userAssignedIdentitiesId, userAssignedIdentitiesData);
            GenericResource userAssignedIdentities = lro2.Value;
            var managedIdentity = new ArmDeploymentScriptManagedIdentity()
            {
                IdentityType = "UserAssigned",
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
            return new AzurePowerShellScript(AzureLocation.WestUS2, RetentionInterval, AzurePowerShellVersion)
            {
                Identity = managedIdentity,
                ScriptContent = ScriptContent,
                Arguments = ScriptArguments
            };
        }

        protected static TemplateSpecData CreateTemplateSpecData(string displayName) => new TemplateSpecData(AzureLocation.WestUS2)
        {
            Description = "Description of my Template Spec",
            DisplayName = $"{displayName} (Test)"
        };

        protected static TemplateSpecVersionData CreateTemplateSpecVersionData() => new TemplateSpecVersionData(AzureLocation.WestUS2)
        {
            Description = "My first version",
            MainTemplate = BinaryData.FromString(File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Scenario",
            "DeploymentTemplates",
            $"simple-storage-account.json")))
        };
    }
}
