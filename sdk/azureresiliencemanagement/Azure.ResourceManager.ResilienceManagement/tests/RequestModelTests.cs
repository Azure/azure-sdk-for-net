// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.ResilienceManagement.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ResilienceManagement.Tests
{
    public class RequestModelTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void ReprotectContentAcceptsSelectedResources()
        {
            var resourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Compute/virtualMachines/test");
            var properties = new ReprotectContent();
            properties.ReprotectRequestSelectedResourceIds.Add(resourceId);
            var content = new DrillRunReprotectContent(properties);

            Assert.That(content.ReprotectProperties, Is.SameAs(properties));
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(content, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            JsonElement selectedResources = json.RootElement.GetProperty("reprotectProperties").GetProperty("reprotectRequestProperties").GetProperty("selectedResourceIds");
            Assert.That(selectedResources.GetArrayLength(), Is.EqualTo(1));
            Assert.That(selectedResources[0].GetString(), Is.EqualTo(resourceId.ToString()));

            var roundTrip = ModelReaderWriter.Read<DrillRunReprotectContent>(
                ModelReaderWriter.Write(content, WireOptions, AzureResourceManagerResilienceManagementContext.Default),
                WireOptions,
                AzureResourceManagerResilienceManagementContext.Default);
            Assert.That(roundTrip.ReprotectProperties.ReprotectRequestSelectedResourceIds, Is.EquivalentTo(new[] { resourceId }));
        }

        [Test]
        public void ReprotectContentCanTargetAllResources()
        {
            var content = new DrillRunReprotectContent(new ReprotectContent());

            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(content, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            Assert.That(json.RootElement.GetProperty("reprotectProperties").ValueKind, Is.EqualTo(JsonValueKind.Object));
        }

        [Test]
        public void ReprotectContentRequiresProperties()
        {
            Assert.Throws<ArgumentNullException>(() => new DrillRunReprotectContent(null));
        }

        [Test]
        public void GoalAssignmentBooleanKeepsWireName()
        {
            var properties = new GoalAssignmentProperties(true);

            Assert.That(properties.IsZonalResiliencyRequired, Is.True);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(properties, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            Assert.That(json.RootElement.GetProperty("requireZonalResiliency").GetBoolean(), Is.True);
            Assert.That(json.RootElement.TryGetProperty("IsZonalResiliencyRequired", out _), Is.False);
        }

        [Test]
        public void GoalRequirementKeepsZonalContext()
        {
            var data = BinaryData.FromString("{\"assignmentId\":\"/providers/Microsoft.Management/serviceGroups/test/providers/Microsoft.AzureResilienceManagement/goalAssignments/test\",\"zonalResiliency\":{\"required\":true}}");
            var goals = ModelReaderWriter.Read<ResilienceManagementGoalsInfo>(data, WireOptions, AzureResourceManagerResilienceManagementContext.Default);

            Assert.That(goals.ZonalResiliency.IsRequired, Is.True);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(goals, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            Assert.That(json.RootElement.GetProperty("zonalResiliency").GetProperty("required").GetBoolean(), Is.True);
        }

        [Test]
        public void AttentionReasonBooleanKeepsWireName()
        {
            var data = BinaryData.FromString("{\"monitoringSourceNotConfigured\":true}");
            var reason = ModelReaderWriter.Read<DrillAttentionReason>(data, WireOptions, AzureResourceManagerResilienceManagementContext.Default);

            Assert.That(reason.IsMonitoringSourceNotConfigured, Is.True);
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(reason, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            Assert.That(json.RootElement.GetProperty("monitoringSourceNotConfigured").GetBoolean(), Is.True);
        }

        [Test]
        public void ArmResourceTypesRoundTrip()
        {
            var expectedType = new ResourceType("Microsoft.Compute/virtualMachines");
            var drillData = BinaryData.FromString("{\"drillType\":\"Zonal\",\"resourceId\":\"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Compute/virtualMachines/test\",\"resourceType\":\"Microsoft.Compute/virtualMachines\"}");
            var drill = ModelReaderWriter.Read<DrillResourceProperties>(drillData, WireOptions, AzureResourceManagerResilienceManagementContext.Default);

            Assert.That(drill.ResourceType, Is.TypeOf<ResourceType>());
            Assert.That(drill.ResourceType, Is.EqualTo(expectedType));
            using JsonDocument drillJson = JsonDocument.Parse(ModelReaderWriter.Write(drill, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            Assert.That(drillJson.RootElement.GetProperty("resourceType").GetString(), Is.EqualTo(expectedType.ToString()));

            var feasibilityData = BinaryData.FromString("{\"feasibilityType\":\"SkuAvailability\",\"resourceType\":\"Microsoft.Compute/virtualMachines\",\"status\":\"Passed\"}");
            var feasibility = ModelReaderWriter.Read<ResourceFeasibilityReview>(feasibilityData, WireOptions, AzureResourceManagerResilienceManagementContext.Default);

            Assert.That(feasibility.ResourceType, Is.TypeOf<ResourceType>());
            Assert.That(feasibility.ResourceType, Is.EqualTo(expectedType));
            using JsonDocument feasibilityJson = JsonDocument.Parse(ModelReaderWriter.Write(feasibility, WireOptions, AzureResourceManagerResilienceManagementContext.Default));
            Assert.That(feasibilityJson.RootElement.GetProperty("resourceType").GetString(), Is.EqualTo(expectedType.ToString()));
        }
    }
}
