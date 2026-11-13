// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Chaos.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Chaos.Tests
{
    public class ScenarioRunSummaryTests
    {
        [Test]
        public void ActionSummaryDeserializesResourceSummaries()
        {
            BinaryData data = BinaryData.FromString("{\"resources\":[{\"id\":\"resource-id\",\"affectedResources\":[{\"id\":\"target-id\",\"state\":\"Succeeded\"}]}],\"actionUrn\":\"action-urn\"}");

            ScenarioRunSummaryAction action = ModelReaderWriter.Read<ScenarioRunSummaryAction>(data);
            ScenarioRunResourceSummary resource = action.Resources[0];

            Assert.That(action.Resources, Has.Count.EqualTo(1));
            Assert.That(resource.Id, Is.EqualTo("resource-id"));
            Assert.That(resource.AffectedResources, Has.Count.EqualTo(1));
            Assert.That(resource.AffectedResources[0].Id, Is.EqualTo("target-id"));
            Assert.That(resource.AffectedResources[0].State.ToString(), Is.EqualTo("Succeeded"));
        }

        [Test]
        public void ModelFactoryPreservesResourceSummaryJson()
        {
            ScenarioRunEffectiveTarget target = ArmChaosModelFactory.ScenarioRunEffectiveTarget(id: "target-id");
            ScenarioRunResourceSummary resource = ArmChaosModelFactory.ScenarioRunResourceSummary(id: "resource-id", affectedResources: new[] { target });
            ScenarioRunSummaryAction action = ArmChaosModelFactory.ScenarioRunSummaryAction(resources: new[] { resource });

            using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(action));
            JsonElement summary = document.RootElement.GetProperty("resources")[0];

            Assert.That(summary.GetProperty("id").GetString(), Is.EqualTo("resource-id"));
            Assert.That(summary.GetProperty("affectedResources")[0].GetProperty("id").GetString(), Is.EqualTo("target-id"));
        }
    }
}
