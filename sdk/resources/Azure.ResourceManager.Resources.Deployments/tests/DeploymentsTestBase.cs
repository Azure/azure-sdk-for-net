// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources._Deployments;
using Azure.ResourceManager.Resources._Deployments.Models;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

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

        protected static DeploymentProperties CreateDeploymentProperties()
        {
            DeploymentProperties tmpDeploymentProperties = new DeploymentProperties(DeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new TemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json";
            tmpDeploymentProperties.Parameters["storageAccountType"] = new DeploymentParameterValue
            {
                Value = BinaryData.FromString("\"Standard_GRS\"")
            };
            return tmpDeploymentProperties;
        }

        protected static DeploymentProperties CreateDeploymentPropertiesAtSub()
        {
            DeploymentProperties tmpDeploymentProperties = new DeploymentProperties(DeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new TemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = "https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/emptyrg.json";
            tmpDeploymentProperties.Parameters["rgName"] = new DeploymentParameterValue
            {
                Value = BinaryData.FromString("\"testDeployAtSub\"")
            };
            tmpDeploymentProperties.Parameters["rgLocation"] = new DeploymentParameterValue
            {
                Value = BinaryData.FromString($"\"{AzureLocation.CentralUS}\"")
            };
            return tmpDeploymentProperties;
        }

        protected static DeploymentProperties CreateDeploymentPropertiesUsingString()
        {
            DeploymentProperties tmpDeploymentProperties = new DeploymentProperties(DeploymentMode.Incremental);
            tmpDeploymentProperties.Template = BinaryData.FromString(File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Scenario",
            "DeploymentTemplates",
            $"storage-template.json")));
            string parametersJson = File.ReadAllText(Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
            "Scenario",
            "DeploymentTemplates",
            $"storage-parameters.json"));
            using var doc = JsonDocument.Parse(parametersJson);
            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                var paramValue = new DeploymentParameterValue();
                if (prop.Value.TryGetProperty("value", out var val))
                {
                    paramValue.Value = BinaryData.FromString(val.GetRawText());
                }
                tmpDeploymentProperties.Parameters[prop.Name] = paramValue;
            }
            return tmpDeploymentProperties;
        }

        protected static DeploymentProperties CreateDeploymentPropertiesUsingJsonElement()
        {
            DeploymentProperties tmpDeploymentProperties = new DeploymentProperties(DeploymentMode.Incremental);
            tmpDeploymentProperties.TemplateLink = new TemplateLink();
            tmpDeploymentProperties.TemplateLink.Uri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json";
            tmpDeploymentProperties.Parameters["storageAccountType"] = new DeploymentParameterValue
            {
                Value = BinaryData.FromString("\"Standard_GRS\"")
            };
            return tmpDeploymentProperties;
        }

        protected static Deployment CreateDeploymentData(DeploymentProperties deploymentProperties) => new Deployment(deploymentProperties);

        protected static Deployment CreateDeploymentData(DeploymentProperties deploymentProperties, AzureLocation location) => new Deployment(deploymentProperties)
        {
            Location = location.ToString()
        };
    }
}
