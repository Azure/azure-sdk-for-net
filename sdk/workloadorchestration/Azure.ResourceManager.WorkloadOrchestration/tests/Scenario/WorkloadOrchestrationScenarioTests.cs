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
      EdgeSchemaCollection collection = resourceGroupResource.GetEdgeSchemas();
      EdgeSchemaData data = new EdgeSchemaData(new AzureLocation("eastus2euap"))
      {
        Properties = new EdgeSchemaProperties()
      };

      // Create the schema
      ArmOperation<EdgeSchemaResource> createOperation = await collection.CreateOrUpdateAsync(WaitUntil.Completed, schemaName, data);
      EdgeSchemaResource createdSchema = createOperation.Value;
      Assert.NotNull(createdSchema, "Created schema should not be null");
      Assert.That(createdSchema.Data.Name, Is.EqualTo(schemaName));

      // Get the schema and verify
      EdgeSchemaResource retrievedSchema = await collection.GetAsync(schemaName);
      Assert.NotNull(retrievedSchema, "Retrieved schema should not be null");
      Assert.That(retrievedSchema.Data.Name, Is.EqualTo(schemaName));
      Assert.That(retrievedSchema.Data.Id, Is.EqualTo(createdSchema.Data.Id));

      // Now create a version for this schema
      EdgeSchemaVersionCollection versionCollection = retrievedSchema.GetEdgeSchemaVersions();

      EdgeSchemaVersionData versionData = new EdgeSchemaVersionData
      {
        Properties = new EdgeSchemaVersionProperties(
"rules:\r\n  configs:\r\n      ErrorThreshold:\r\n        type: float\r\n        required: true\r\n        editableAt:\r\n          - factory\r\n        editableBy:\r\n          - OT\r\n      HealthCheckEndpoint:\r\n        type: string\r\n        required: false\r\n        editableAt:\r\n          - line\r\n        editableBy:\r\n          - OT\r\n      EnableLocalLog:\r\n        type: boolean\r\n        required: true\r\n        editableAt:\r\n          - line\r\n        editableBy:\r\n          - OT\r\n      AgentEndpoint:\r\n        type: string\r\n        required: true\r\n        editableAt:\r\n          - line\r\n        editableBy:\r\n          - OT\r\n      HealthCheckEnabled:\r\n        type: boolean\r\n        required: false\r\n        editableAt:\r\n          - line\r\n        editableBy:\r\n          - OT\r\n      ApplicationEndpoint:\r\n        type: string\r\n        required: true\r\n        editableAt:\r\n          - line\r\n        editableBy:\r\n          - OT\r\n      TemperatureRangeMax:\r\n        type: float\r\n        required: true\r\n        editableAt:\r\n          - line\r\n        editableBy:\r\n          - OT\r\n"
          )
      };

      // Create the schema version
      ArmOperation<EdgeSchemaVersionResource> createVersionOperation = await versionCollection.CreateOrUpdateAsync(WaitUntil.Completed, schemaVersionName, versionData);
      EdgeSchemaVersionResource createdVersion = createVersionOperation.Value;
      Assert.NotNull(createdVersion, "Created schema version should not be null");
      Assert.That(createdVersion.Data.Name, Is.EqualTo(schemaVersionName));
    }
  }
}