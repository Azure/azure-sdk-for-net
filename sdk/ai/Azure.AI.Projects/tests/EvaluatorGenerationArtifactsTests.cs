// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.AI.Projects.Evaluation;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class EvaluatorGenerationArtifactsTests
{
    [Test]
    public void ExistingEvaluationConstructorsPreserveConfiguredValues()
    {
        EvaluatorGenerationInputs inputs = new(
            [new PromptEvaluatorGenerationJobSource("Assess response quality.")], "quality-model", "quality-evaluator");
        EvaluationsDimension dimension = new("resolution", "Resolves the request.", 7);
        DailyRecurrenceSchedule schedule = new(new[] { 8, 12 });

        using JsonDocument inputsJson = JsonDocument.Parse(ModelReaderWriter.Write(inputs, new("W")));
        using JsonDocument dimensionJson = JsonDocument.Parse(ModelReaderWriter.Write(dimension, new("W")));
        using JsonDocument scheduleJson = JsonDocument.Parse(ModelReaderWriter.Write(schedule, new("W")));
        Assert.Multiple(() =>
        {
            Assert.That(inputs.Model, Is.EqualTo("quality-model"));
            Assert.That(inputsJson.RootElement.GetProperty("model").GetString(), Is.EqualTo("quality-model"));
            Assert.That(inputsJson.RootElement.GetProperty("evaluator_name").GetString(), Is.EqualTo("quality-evaluator"));
            Assert.That(dimension.Weight, Is.EqualTo(7));
            Assert.That(dimensionJson.RootElement.GetProperty("weight").GetInt32(), Is.EqualTo(7));
            Assert.That(schedule.Hours, Is.EqualTo(new[] { 8, 12 }));
            Assert.That(scheduleJson.RootElement.GetProperty("hours")[1].GetInt32(), Is.EqualTo(12));
        });
    }

    [Test]
    public void UnweightedDimensionOmitsConfiguredWeight()
    {
        EvaluationsDimension dimension = new("resolution", "Resolves the request.");
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(dimension, new("W")));
        Assert.Multiple(() =>
        {
            Assert.That(dimension.Weight, Is.Null);
            Assert.That(document.RootElement.TryGetProperty("weight", out _), Is.False);
        });
    }

    [Test]
    public void LegacyConstructorNullValidationIsPreserved()
    {
        Assert.Throws<ArgumentNullException>(() => new EvaluatorGenerationInputs(
            [new PromptEvaluatorGenerationJobSource("Assess quality.")], null, "quality-evaluator"));
        Assert.Throws<ArgumentNullException>(() => new DailyRecurrenceSchedule(null));
    }

    [Test]
    public void GeneratedErrorAndMetadataAliasesPreserveWireFields()
    {
        ProjectsError error = ModelReaderWriter.Read<ProjectsError>(BinaryData.FromString("""
            {"code":"invalid_input","message":"Invalid input.","target":"dataset","details":[{"code":"missing_row","message":"A row is missing."}]}
            """));
        ProjectsMetadata metadata = ModelReaderWriter.Read<ProjectsMetadata>(
            BinaryData.FromString("""{"test_id":"metadata-roundtrip"}"""));
        using JsonDocument errorJson = JsonDocument.Parse(ModelReaderWriter.Write(error));
        using JsonDocument metadataJson = JsonDocument.Parse(ModelReaderWriter.Write(metadata));
        Assert.Multiple(() =>
        {
            Assert.That(error.Code, Is.EqualTo("invalid_input"));
            Assert.That(error.Target, Is.EqualTo("dataset"));
            Assert.That(error.Details[0].Code, Is.EqualTo("missing_row"));
            Assert.That(errorJson.RootElement.GetProperty("details")[0].GetProperty("message").GetString(), Is.EqualTo("A row is missing."));
            Assert.That(metadata.AdditionalProperties["test_id"], Is.EqualTo("metadata-roundtrip"));
            Assert.That(metadataJson.RootElement.GetProperty("test_id").GetString(), Is.EqualTo("metadata-roundtrip"));
        });
    }

    [Test]
    public void ResolvedDatasetVersionAndUnknownFieldsRoundTrip()
    {
        BinaryData data = BinaryData.FromString("""
            {
              "dataset": { "name": "evaluation-artifacts", "version": "7", "future_dataset": true },
              "kinds": ["spec", "tools"],
              "future_artifacts": { "enabled": true }
            }
            """);
        EvaluatorGenerationArtifacts artifacts = ModelReaderWriter.Read<EvaluatorGenerationArtifacts>(
            data, ModelReaderWriterOptions.Json, AzureAIProjectsContext.Default);
        using JsonDocument document = JsonDocument.Parse(ModelReaderWriter.Write(
            artifacts, ModelReaderWriterOptions.Json, AzureAIProjectsContext.Default));
        Assert.Multiple(() =>
        {
            Assert.That(artifacts.Reference, Is.TypeOf<VersionedDatasetReference>());
            Assert.That(artifacts.Reference.Name, Is.EqualTo("evaluation-artifacts"));
            Assert.That(artifacts.Reference.Version, Is.EqualTo("7"));
            Assert.That(artifacts.DatasetRowKinds, Is.EqualTo(new[] { "spec", "tools" }));
            Assert.That(document.RootElement.GetProperty("dataset").GetProperty("version").GetString(), Is.EqualTo("7"));
            Assert.That(document.RootElement.GetProperty("dataset").GetProperty("future_dataset").GetBoolean(), Is.True);
            Assert.That(document.RootElement.GetProperty("future_artifacts").GetProperty("enabled").GetBoolean(), Is.True);
        });
    }

    [Test]
    public void FactoryPreservesResolvedDatasetReference()
    {
        VersionedDatasetReference reference = AzureAIProjectsModelFactory.VersionedDatasetReference("dataset", "3");
        EvaluatorGenerationArtifacts artifacts = AzureAIProjectsModelFactory.EvaluatorGenerationArtifacts(reference, new[] { "spec" });
        Assert.Multiple(() =>
        {
            Assert.That(artifacts.Reference, Is.SameAs(reference));
            Assert.That(artifacts.Reference.Name, Is.EqualTo("dataset"));
            Assert.That(artifacts.Reference.Version, Is.EqualTo("3"));
            Assert.That(artifacts.DatasetRowKinds, Is.EqualTo(new[] { "spec" }));
        });
    }
}
