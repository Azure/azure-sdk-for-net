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
