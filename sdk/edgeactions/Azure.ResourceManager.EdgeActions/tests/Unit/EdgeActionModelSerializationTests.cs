// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.EdgeActions.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.EdgeActions.Tests
{
    public class EdgeActionModelSerializationTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void EmptyEdgeActionPatchOmitsSkuTagsAndProperties()
        {
            using JsonDocument document = Serialize(new EdgeActionPatch());
            Assert.That(document.RootElement.EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void EdgeActionTagPatchOmitsSkuAndProperties()
        {
            var patch = new EdgeActionPatch();
            patch.Tags.Add("purpose", "updated");
            using JsonDocument document = Serialize(patch);
            Assert.That(document.RootElement.GetProperty("tags").GetProperty("purpose").GetString(), Is.EqualTo("updated"));
            Assert.That(document.RootElement.TryGetProperty("sku", out _), Is.False);
            Assert.That(document.RootElement.TryGetProperty("properties", out _), Is.False);
        }

        [Test]
        public void ClearingEdgeActionPatchTagsSendsEmptyObject()
        {
            var patch = new EdgeActionPatch();
            patch.Tags.Clear();
            using JsonDocument document = Serialize(patch);
            Assert.That(document.RootElement.GetProperty("tags").EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void EmptyVersionPatchOmitsTagsAndProperties()
        {
            using JsonDocument document = Serialize(new EdgeActionVersionPatch());
            Assert.That(document.RootElement.EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void VersionTagPatchOmitsImmutableProperties()
        {
            var patch = new EdgeActionVersionPatch();
            patch.Tags.Add("purpose", "updated");
            using JsonDocument document = Serialize(patch);
            Assert.That(document.RootElement.GetProperty("tags").GetProperty("purpose").GetString(), Is.EqualTo("updated"));
            Assert.That(document.RootElement.TryGetProperty("properties", out _), Is.False);
        }

        [Test]
        public void EmptyVersionUpdatePropertiesDoNotSendDefaults()
        {
            var patch = new EdgeActionVersionPatch { Properties = new EdgeActionVersionUpdateProperties() };
            using JsonDocument document = Serialize(patch);
            Assert.That(document.RootElement.GetProperty("properties").EnumerateObject().MoveNext(), Is.False);
        }

        [TestCase("True")]
        [TestCase("False")]
        public void VersionCreationSerializesDefaultVersionAsString(string isDefaultVersion)
        {
            var data = new EdgeActionVersionData(new AzureLocation("global"))
            {
                Properties = new EdgeActionVersionProperties(EdgeActionVersionDeploymentType.File, new EdgeActionIsDefaultVersion(isDefaultVersion))
            };
            using JsonDocument document = Serialize(data);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("deploymentType").GetString(), Is.EqualTo("file"));
            Assert.That(properties.GetProperty("isDefaultVersion").ValueKind, Is.EqualTo(JsonValueKind.String));
            Assert.That(properties.GetProperty("isDefaultVersion").GetString(), Is.EqualTo(isDefaultVersion));
        }

        [Test]
        public void VersionResponsePropertiesAreNotWrittenToRequests()
        {
            var json = BinaryData.FromString("""
                {
                  "deploymentType": "file",
                  "isDefaultVersion": "True",
                  "validationStatus": "Succeeded",
                  "provisioningState": "Succeeded",
                  "lastPackageUpdateTime": "2026-10-01T12:30:00Z"
                }
                """);
            var properties = ModelReaderWriter.Read<EdgeActionVersionProperties>(json, WireOptions, AzureResourceManagerEdgeActionsContext.Default);
            Assert.That(properties.DeploymentType, Is.EqualTo(EdgeActionVersionDeploymentType.File));
            Assert.That(properties.IsDefaultVersion, Is.EqualTo(EdgeActionIsDefaultVersion.True));
            Assert.That(properties.ProvisioningState, Is.EqualTo(EdgeActionProvisioningState.Succeeded));
            Assert.That(properties.LastPackageUpdatedOn, Is.EqualTo(new DateTimeOffset(2026, 10, 1, 12, 30, 0, TimeSpan.Zero)));
            using JsonDocument document = Serialize(properties);
            Assert.That(document.RootElement.TryGetProperty("validationStatus", out _), Is.False);
            Assert.That(document.RootElement.TryGetProperty("provisioningState", out _), Is.False);
            Assert.That(document.RootElement.TryGetProperty("lastPackageUpdateTime", out _), Is.False);
        }

        [Test]
        public void EmptyExecutionFilterPatchOmitsTagsAndProperties()
        {
            using JsonDocument document = Serialize(new EdgeActionExecutionFilterPatch());
            Assert.That(document.RootElement.EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void ExecutionFilterSerializesVersionIdentifierAndHeaders()
        {
            ResourceIdentifier versionId = EdgeActionVersionResource.CreateResourceIdentifier(
                "00000000-0000-0000-0000-000000000000", "test-rg", "test-action", "v1");
            var data = new EdgeActionExecutionFilterData(new AzureLocation("global"))
            {
                Properties = new EdgeActionExecutionFilterProperties(versionId, "x-sdk-test", "initial")
            };
            using JsonDocument document = Serialize(data);
            JsonElement properties = document.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("versionId").GetString(), Is.EqualTo(versionId.ToString()));
            Assert.That(properties.GetProperty("executionFilterIdentifierHeaderName").GetString(), Is.EqualTo("x-sdk-test"));
            Assert.That(properties.GetProperty("executionFilterIdentifierHeaderValue").GetString(), Is.EqualTo("initial"));
        }

        private static JsonDocument Serialize<T>(T model) where T : IPersistableModel<T>
        {
            return JsonDocument.Parse(ModelReaderWriter.Write(model, WireOptions, AzureResourceManagerEdgeActionsContext.Default));
        }
    }
}
