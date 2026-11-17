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

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public void FailureSuppressionRetainsWireNameAndValue(bool? suppressed)
        {
            ScenarioRunSummaryAction action = ArmChaosModelFactory.ScenarioRunSummaryAction(state: ScenarioSummaryState.Succeeded, isFailureSuppressed: suppressed);
            BinaryData data = ModelReaderWriter.Write(action, new ModelReaderWriterOptions("J"));
            using JsonDocument document = JsonDocument.Parse(data);
            bool present = document.RootElement.TryGetProperty("failureSuppressed", out JsonElement value);
            ScenarioRunSummaryAction restored = ModelReaderWriter.Read<ScenarioRunSummaryAction>(data, new ModelReaderWriterOptions("J"));

            Assert.That(present, Is.EqualTo(suppressed.HasValue));
            if (suppressed.HasValue)
                Assert.That(value.GetBoolean(), Is.EqualTo(suppressed.Value));
            Assert.That(restored.IsFailureSuppressed, Is.EqualTo(suppressed));
        }

        [Test]
        public void ScenarioActionErrorsPreserveWireValues()
        {
            ScenarioActionErrorDetail detail = ArmChaosModelFactory.ScenarioActionErrorDetail(code: "detail", message: "detail message", target: "target");
            ScenarioActionError error = ArmChaosModelFactory.ScenarioActionError(code: "error", message: "message", details: new[] { detail });
            ScenarioRunSummaryAction action = ArmChaosModelFactory.ScenarioRunSummaryAction(state: ScenarioSummaryState.Succeeded, error: error);
            BinaryData data = ModelReaderWriter.Write(action, new ModelReaderWriterOptions("J"));
            using JsonDocument document = JsonDocument.Parse(data);
            ScenarioRunSummaryAction restored = ModelReaderWriter.Read<ScenarioRunSummaryAction>(data, new ModelReaderWriterOptions("J"));

            Assert.That(document.RootElement.GetProperty("error").GetProperty("details")[0].GetProperty("code").GetString(), Is.EqualTo("detail"));
            Assert.That(restored.Error.Code, Is.EqualTo("error"));
            Assert.That(restored.Error.Details[0].Target, Is.EqualTo("target"));
        }

        [Test]
        public void ScenarioEnumsPreserveWireValues()
        {
            ScenarioAction action = ArmChaosModelFactory.ScenarioAction(failureBehavior: ScenarioFailureBehavior.Continue);
            ScenarioParameterFormat format = ArmChaosModelFactory.ScenarioParameterFormat(formatType: ScenarioParameterFormatType.Json);
            using JsonDocument actionJson = JsonDocument.Parse(ModelReaderWriter.Write(action, new ModelReaderWriterOptions("J")));
            using JsonDocument formatJson = JsonDocument.Parse(ModelReaderWriter.Write(format, new ModelReaderWriterOptions("J")));

            Assert.That(actionJson.RootElement.GetProperty("failureBehavior").GetString(), Is.EqualTo("Continue"));
            Assert.That(formatJson.RootElement.GetProperty("formatType").GetString(), Is.EqualTo("Json"));
        }
    }
}
