// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.WorkloadOrchestration.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.WorkloadOrchestration.Tests
{
    public class WorkloadOrchestrationScenarioTests // Remove trailing space after "WorkloadOrchestrationScenarioTests"
    {
        [Test]
        public async Task Schema_LifecycleAsync()
        {
            string subscriptionId = "973d15c6-6c57-447e-b9c6-6d79b5b784ab";
            string resourceGroupName = "ConfigManager-CloudTest-Playground-Canary";
            string schemaName = "schemanet";
            string schemaVersionName = "1.0.0";

            // Get credentials and create client
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new ArmClient(cred);

            // Get resource group
            ResourceIdentifier resourceGroupResourceId = ResourceGroupResource.CreateResourceIdentifier(subscriptionId, resourceGroupName);
            ResourceGroupResource resourceGroupResource = client.GetResourceGroupResource(resourceGroupResourceId);

            // Get schema collection and create new schema
            SchemaCollection collection = resourceGroupResource.GetSchemas();
            SchemaData data = new SchemaData(new AzureLocation("eastus"))
            {
                Properties = new SchemaProperties()
            };

            // Create the schema
            ArmOperation<SchemaResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, schemaName, data);
            SchemaResource createdSchema = createOperation.Value;
            Assert.NotNull(createdSchema, "Created schema should not be null");
            Assert.That(createdSchema.Data.Name, Is.EqualTo(schemaName));

            // Get the schema and verify
            SchemaResource retrievedSchema = await collection.GetAsync(schemaName);
            Assert.NotNull(retrievedSchema, "Retrieved schema should not be null");
            Assert.That(retrievedSchema.Data.Name, Is.EqualTo(schemaName));
            Assert.That(retrievedSchema.Data.Id, Is.EqualTo(createdSchema.Data.Id));

            // Now create a version for this schema
            SchemaVersionCollection versionCollection = retrievedSchema.GetSchemaVersions();

            // Create schema content in YAML format
            var schema = new
            {
                configs = new
                {
                    ErrorThreshold = new
                    {
                        type = "float",
                        required = true,
                        editableAt = new[] { "factory" },
                        editableBy = new[] { "OT" }
                    },
                    HealthCheckEndpoint = new
                    {
                        type = "string",
                        required = false,
                        editableAt = new[] { "line" },
                        editableBy = new[] { "OT" }
                    },
                    EnableLocalLog = new
                    {
                        type = "boolean",
                        required = true,
                        editableAt = new[] { "line" },
                        editableBy = new[] { "OT" }
                    },
                    AgentEndpoint = new
                    {
                        type = "string",
                        required = true,
                        editableAt = new[] { "line" },
                        editableBy = new[] { "OT" }
                    },
                    HealthCheckEnabled = new
                    {
                        type = "boolean",
                        required = false,
                        editableAt = new[] { "line" },
                        editableBy = new[] { "OT" }
                    },
                    ApplicationEndpoint = new
                    {
                        type = "string",
                        required = true,
                        editableAt = new[] { "line" },
                        editableBy = new[] { "OT" }
                    },
                    TemperatureRangeMax = new
                    {
                        type = "float",
                        required = true,
                        editableAt = new[] { "line" },
                        editableBy = new[] { "OT" }
                    }
                }
            };

            SchemaVersionData versionData = new SchemaVersionData
            {
                Properties = new SchemaVersionProperties(
@"rules:
  configs:
      ErrorThreshold:
        type: float
        required: true
        editableAt:
          - factory
        editableBy:
          - OT
      HealthCheckEndpoint:
        type: string
        required: false
        editableAt:
          - line
        editableBy:
          - OT
      EnableLocalLog:
        type: boolean
        required: true
        editableAt:
          - line
        editableBy:
          - OT
      AgentEndpoint:
        type: string
        required: true
        editableAt:
          - line
        editableBy:
          - OT
      HealthCheckEnabled:
        type: boolean
        required: false
        editableAt:
          - line
        editableBy:
          - OT
      ApplicationEndpoint:
        type: string
        required: true
        editableAt:
          - line
        editableBy:
          - OT
      TemperatureRangeMax:
        type: float
        required: true
        editableAt:
          - line
        editableBy:
          - OT
"
                )};

            // Create the schema version
            ArmOperation<SchemaVersionResource> createVersionOperation = await versionCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaVersionName, versionData);
            SchemaVersionResource createdVersion = createVersionOperation.Value;
            Assert.NotNull(createdVersion, "Created schema version should not be null");
            Assert.That(createdVersion.Data.Name, Is.EqualTo(schemaVersionName));

            // Get the schema version and verify
            SchemaVersionResource retrievedVersion = await versionCollection.GetAsync(schemaVersionName);
            Assert.NotNull(retrievedVersion, "Retrieved schema version should not be null");
            Assert.That(retrievedVersion.Data.Name, Is.EqualTo(schemaVersionName));
            Assert.That(retrievedVersion.Data.Id, Is.EqualTo(createdVersion.Data.Id));
        }
    }
}
