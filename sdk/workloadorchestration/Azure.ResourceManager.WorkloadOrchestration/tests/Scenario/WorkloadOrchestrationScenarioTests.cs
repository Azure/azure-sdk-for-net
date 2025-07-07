// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.WorkloadOrchestration.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.WorkloadOrchestration.Tests
{
  public class WorkloadOrchestrationScenarioTests : WorkloadOrchestrationTestBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="WorkloadOrchestrationScenarioTests"/> class.
    /// </summary>
    /// <param name="isAsync">A flag indicating whether the test should run asynchronously.</param>
    /// <param name="mode">The recording mode for the test. If null, uses the default mode.</param>
    public WorkloadOrchestrationScenarioTests(bool isAsync) : base(isAsync)
    {
    }

    public static IEnumerable<object[]> TestData => new[] { new object[] { false }, new object[] { true } };

    [Test]
    [RecordedTest]
    public async Task Schema_LifecycleAsync()
    {
      string schemaName = Recording.GenerateAssetName("schema88");
      string schemaVersionName = Recording.GenerateAssetName("1.0.0");

      // Get client and resource group from test base
      ArmClient client = GetArmClient();
      ResourceGroupResource resourceGroupResource = GetResourceGroup();

      // Get schema collection and create new schema
      SchemaCollection collection = resourceGroupResource.GetSchemas();
      SchemaData data = new SchemaData(new AzureLocation("eastus2euap"))
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
          )
      };

      // Create the schema version
      ArmOperation<SchemaVersionResource> createVersionOperation = await versionCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaVersionName, versionData);
      SchemaVersionResource createdVersion = createVersionOperation.Value;
      Assert.NotNull(createdVersion, "Created schema version should not be null");
      Assert.That(createdVersion.Data.Name, Is.EqualTo(schemaVersionName));
    }
  }
}