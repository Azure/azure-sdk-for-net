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

namespace Azure.ResourceManager.Resources.Deployments.Tests
{
    public class DeploymentsTestBase : ManagementRecordedTestBase<DeploymentsTestEnvironment>
    {
        protected ArmClient Client { get; private set; }

        protected DeploymentsTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DeploymentsTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void CreateCommonClient()
        {
            Client = GetArmClient();
        }

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
    }
}
