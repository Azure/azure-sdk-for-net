// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Monitor.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Monitor.Tests
{
    public class RestoredMonitorApiTests
    {
        private const string Scope = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Compute/virtualMachines/vm";
        private const string WorkspaceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.OperationalInsights/workspaces/workspace";

        [TestCase("J")]
        [TestCase("W")]
        public void DiagnosticSettingFactoryPreservesPayload(string format)
        {
            var id = DiagnosticSettingResource.CreateResourceIdentifier(Scope, "setting");
            var data = ArmMonitorModelFactory.DiagnosticSettingData(
                id: id,
                eventHubName: "events",
                workspaceId: new ResourceIdentifier(WorkspaceId),
                metrics: new[] { new MetricSettings(true) },
                logs: new[] { new LogSettings(true) });
            var options = new ModelReaderWriterOptions(format);
            var serialized = ModelReaderWriter.Write(data, options);
            using var json = JsonDocument.Parse(serialized.ToMemory());
            var properties = json.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("eventHubName").GetString(), Is.EqualTo("events"));
            Assert.That(properties.GetProperty("workspaceId").GetString(), Is.EqualTo(WorkspaceId));
            Assert.That(properties.GetProperty("metrics")[0].GetProperty("enabled").GetBoolean(), Is.True);
            Assert.That(properties.GetProperty("logs")[0].GetProperty("enabled").GetBoolean(), Is.True);

            var deserialized = ModelReaderWriter.Read<DiagnosticSettingData>(serialized, options);
            Assert.That(deserialized.EventHubName, Is.EqualTo("events"));
            Assert.That(deserialized.WorkspaceId, Is.EqualTo(new ResourceIdentifier(WorkspaceId)));
            Assert.That(deserialized.Metrics, Has.Count.EqualTo(1));
            Assert.That(deserialized.Logs, Has.Count.EqualTo(1));
            Assert.That(ArmMonitorModelFactory.DiagnosticSettingData().Metrics, Is.Empty);
            Assert.That(ArmMonitorModelFactory.DiagnosticSettingData().Logs, Is.Empty);
            Assert.That(Attribute.IsDefined(typeof(DiagnosticSettingData), typeof(ObsoleteAttribute)), Is.False);
            Assert.That(Attribute.IsDefined(typeof(DiagnosticSettingResource), typeof(ObsoleteAttribute)), Is.False);
            Assert.That(Attribute.IsDefined(typeof(DiagnosticSettingCollection), typeof(ObsoleteAttribute)), Is.False);
        }

        [TestCase(false, 0)]
        [TestCase(true, 0)]
        [TestCase(false, 1)]
        [TestCase(true, 1)]
        [TestCase(false, 2)]
        [TestCase(true, 2)]
        public async Task DiagnosticSettingEntryPointsCallTheService(bool async, int entryPoint)
        {
            var id = DiagnosticSettingResource.CreateResourceIdentifier(Scope, "setting");
            var responseJson = $"{{\"id\":\"{id}\",\"name\":\"setting\",\"type\":\"Microsoft.Insights/diagnosticSettings\",\"properties\":{{\"eventHubName\":\"events\",\"workspaceId\":\"{WorkspaceId}\"}}}}";
            var transport = new MockTransport(new MockResponse(200).SetContent(responseJson));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });

            Response<DiagnosticSettingResource> response;
            if (entryPoint == 0)
            {
                var resource = client.GetDiagnosticSettingResource(id);
                Assert.That(resource.HasData, Is.False);
                response = async ? await resource.GetAsync() : resource.Get();
            }
            else if (entryPoint == 1)
            {
                var collection = client.GetDiagnosticSettings(new ResourceIdentifier(Scope));
                response = async ? await collection.GetAsync("setting") : collection.Get("setting");
            }
            else
            {
                var scope = new ResourceIdentifier(Scope);
                response = async ? await client.GetDiagnosticSettingAsync(scope, "setting") : client.GetDiagnosticSetting(scope, "setting");
            }

            Assert.That(response.Value.HasData, Is.True);
            Assert.That(response.Value.Data.EventHubName, Is.EqualTo("events"));
            Assert.That(response.Value.Data.WorkspaceId, Is.EqualTo(new ResourceIdentifier(WorkspaceId)));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id.ToString()));
        }

        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task DiagnosticSettingCreateOrUpdateCallsTheService(bool async, bool update)
        {
            var id = DiagnosticSettingResource.CreateResourceIdentifier(Scope, "setting");
            var responseJson = $"{{\"id\":\"{id}\",\"name\":\"setting\",\"type\":\"Microsoft.Insights/diagnosticSettings\",\"properties\":{{\"eventHubName\":\"events\"}}}}";
            var transport = new MockTransport(new MockResponse(200).SetContent(responseJson));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var data = new DiagnosticSettingData { EventHubName = "events" };
            ArmOperation<DiagnosticSettingResource> operation;
            if (update)
            {
                var resource = client.GetDiagnosticSettingResource(id);
                operation = async ? await resource.UpdateAsync(WaitUntil.Completed, data) : resource.Update(WaitUntil.Completed, data);
            }
            else
            {
                var collection = client.GetDiagnosticSettings(new ResourceIdentifier(Scope));
                operation = async ? await collection.CreateOrUpdateAsync(WaitUntil.Completed, "setting", data) : collection.CreateOrUpdate(WaitUntil.Completed, "setting", data);
            }

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Data.EventHubName, Is.EqualTo("events"));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Put));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id.ToString()));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task DiagnosticSettingDeleteCallsTheService(bool async)
        {
            var id = DiagnosticSettingResource.CreateResourceIdentifier(Scope, "setting");
            var transport = new MockTransport(new MockResponse(204));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var resource = client.GetDiagnosticSettingResource(id);
            var operation = async ? await resource.DeleteAsync(WaitUntil.Completed) : resource.Delete(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Delete));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id.ToString()));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task DiagnosticSettingCollectionFollowsNextLink(bool async)
        {
            var firstId = DiagnosticSettingResource.CreateResourceIdentifier(Scope, "first");
            var secondId = DiagnosticSettingResource.CreateResourceIdentifier(Scope, "second");
            var nextLink = $"https://management.azure.com{Scope}/providers/Microsoft.Insights/diagnosticSettings?api-version=2021-05-01-preview&$skiptoken=next";
            var firstPage = $"{{\"value\":[{{\"id\":\"{firstId}\",\"name\":\"first\",\"type\":\"Microsoft.Insights/diagnosticSettings\",\"properties\":{{\"eventHubName\":\"events\"}}}}],\"nextLink\":\"{nextLink}\"}}";
            var secondPage = $"{{\"value\":[{{\"id\":\"{secondId}\",\"name\":\"second\",\"type\":\"Microsoft.Insights/diagnosticSettings\",\"properties\":{{\"eventHubName\":\"events\"}}}}]}}";
            var transport = new MockTransport(new MockResponse(200).SetContent(firstPage), new MockResponse(200).SetContent(secondPage));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var collection = client.GetDiagnosticSettings(new ResourceIdentifier(Scope));
            var ids = new List<ResourceIdentifier>();
            if (async)
            {
                await foreach (var resource in collection.GetAllAsync())
                {
                    ids.Add(resource.Id);
                }
            }
            else
            {
                foreach (var resource in collection.GetAll())
                {
                    ids.Add(resource.Id);
                }
            }

            Assert.That(ids, Is.EqualTo(new[] { firstId, secondId }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo($"{Scope}/providers/Microsoft.Insights/diagnosticSettings"));
            Assert.That(transport.Requests[1].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void ActivityLogAlertRetainsConstructorAndConditionSetter(string format)
        {
            var data = new ActivityLogAlertData(AzureLocation.EastUS);
            Assert.That(data, Is.InstanceOf<Azure.ResourceManager.Models.TrackedResourceData>());
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.ConditionAllOf, Is.Empty);
            var conditions = new List<ActivityLogAlertAnyOfOrLeafCondition>
            {
                new ActivityLogAlertAnyOfOrLeafCondition { Field = "category", EqualsValue = "Administrative" }
            };
            data.ConditionAllOf = conditions;
            var assignedConditions = data.ConditionAllOf;
            Assert.That(assignedConditions, Is.EqualTo(conditions));
            Assert.That(assignedConditions, Is.Not.SameAs(conditions));
            conditions.Clear();
            Assert.That(assignedConditions, Has.Count.EqualTo(1));
            Assert.Throws<ArgumentNullException>(() => data.ConditionAllOf = null);
            Assert.That(data.ConditionAllOf, Is.SameAs(assignedConditions));

            var options = new ModelReaderWriterOptions(format);
            var serialized = ModelReaderWriter.Write(data, options);
            using var json = JsonDocument.Parse(serialized.ToMemory());
            var allOf = json.RootElement.GetProperty("properties").GetProperty("condition").GetProperty("allOf");
            Assert.That(allOf.GetArrayLength(), Is.EqualTo(1));
            Assert.That(allOf[0].GetProperty("field").GetString(), Is.EqualTo("category"));
            var deserialized = ModelReaderWriter.Read<ActivityLogAlertData>(serialized, options);
            Assert.That(deserialized.ConditionAllOf, Has.Count.EqualTo(1));
            Assert.That(deserialized.ConditionAllOf[0].EqualsValue, Is.EqualTo("Administrative"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DiagnosticCategoryRetainsGaSetterAndWireProperties(string format)
        {
            var category = new DiagnosticSettingsCategoryData { CategoryType = MonitorCategoryType.Logs };
            category.CategoryGroups.Add("audit");
            Assert.That(ArmMonitorModelFactory.DiagnosticSettingsCategoryData().CategoryGroups, Is.Empty);
            var options = new ModelReaderWriterOptions(format);
            var serialized = ModelReaderWriter.Write(category, options);
            using var json = JsonDocument.Parse(serialized.ToMemory());
            var properties = json.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("categoryType").GetString(), Is.EqualTo("Logs"));
            Assert.That(properties.GetProperty("categoryGroups")[0].GetString(), Is.EqualTo("audit"));

            var deserialized = ModelReaderWriter.Read<DiagnosticSettingsCategoryData>(serialized, options);
            Assert.That(deserialized.CategoryType, Is.EqualTo(MonitorCategoryType.Logs));
            Assert.That(deserialized.CategoryGroups, Is.EqualTo(new[] { "audit" }));
            deserialized.CategoryType = MonitorCategoryType.Metrics;
            Assert.That(deserialized.CategoryType, Is.EqualTo(MonitorCategoryType.Metrics));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void VmInsightsDataContainerUsesGeneratedWorkspace(string format)
        {
            var json = BinaryData.FromString($"{{\"workspace\":{{\"id\":\"{WorkspaceId}\",\"location\":\"eastus\",\"properties\":{{\"customerId\":\"customer\"}}}}}}");
            var container = ModelReaderWriter.Read<DataContainer>(json, new ModelReaderWriterOptions(format));
            Assert.That(container.Workspace.Id.ToString(), Is.EqualTo(WorkspaceId));
            Assert.That(container.Workspace.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(container.Workspace.CustomerId, Is.EqualTo("customer"));

            var workspace = ArmMonitorModelFactory.DataContainerWorkspace(new ResourceIdentifier(WorkspaceId), AzureLocation.EastUS, "customer");
            Assert.That(ArmMonitorModelFactory.DataContainer(workspace).Workspace, Is.SameAs(workspace));
            Assert.That(workspace.CustomerId, Is.EqualTo("customer"));
            Assert.That(ArmMonitorModelFactory.DataContainerWorkspace().CustomerId, Is.Null);
            Assert.That(OnboardingStatus.Onboarded.ToString(), Is.EqualTo("onboarded"));
            Assert.That(DataStatus.Present.ToString(), Is.EqualTo("present"));
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task VmInsightsGeneratedResourceReadsData(bool async)
        {
            var id = VmInsightsOnboardingStatusResource.CreateResourceIdentifier(Scope);
            var responseJson = $"{{\"id\":\"{id}\",\"name\":\"default\",\"type\":\"Microsoft.Insights/vmInsightsOnboardingStatuses\",\"properties\":{{\"resourceId\":\"{Scope}\",\"onboardingStatus\":\"onboarded\",\"dataStatus\":\"present\",\"data\":[{{\"workspace\":{{\"id\":\"{WorkspaceId}\",\"location\":\"eastus\",\"properties\":{{\"customerId\":\"customer\"}}}}}}]}}}}";
            var transport = new MockTransport(new MockResponse(200).SetContent(responseJson));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var resource = client.GetVmInsightsOnboardingStatus(new ResourceIdentifier(Scope));
            var response = async ? await resource.GetAsync() : resource.Get();

            Assert.That(response.Value.Data.ResourceId, Is.EqualTo(new ResourceIdentifier(Scope)));
            Assert.That(response.Value.Data.OnboardingStatus, Is.EqualTo(OnboardingStatus.Onboarded));
            Assert.That(response.Value.Data.DataStatus, Is.EqualTo(DataStatus.Present));
            Assert.That(response.Value.Data.Data[0].Workspace.CustomerId, Is.EqualTo("customer"));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id.ToString()));
        }

#pragma warning disable CS0618 // The pre-fix GA compatibility surface is obsolete.
        [TestCase(false, false)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(true, true)]
        public async Task VmInsightsGaResourceReadsData(bool async, bool byId)
        {
            var id = new ResourceIdentifier($"{Scope}/providers/Microsoft.Insights/vmInsightsOnboardingStatuses/default");
            var responseJson = $"{{\"id\":\"{id}\",\"name\":\"default\",\"type\":\"Microsoft.Insights/vmInsightsOnboardingStatuses\",\"properties\":{{\"resourceId\":\"{Scope}\",\"onboardingStatus\":\"onboarded\",\"dataStatus\":\"present\",\"data\":[{{\"workspace\":{{\"id\":\"{WorkspaceId}\",\"location\":\"eastus\",\"properties\":{{\"customerId\":\"customer\"}}}}}}]}}}}";
            var transport = new MockTransport(new MockResponse(200).SetContent(responseJson));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var resource = byId ? client.GetVmInsightsOnboardingStatusResource(id) : client.GetVmInsightsOnboardingStatus(new ResourceIdentifier(Scope));
            var response = async ? await resource.GetAsync() : resource.Get();

            Assert.That(response.Value.Data.ResourceId, Is.EqualTo(new ResourceIdentifier(Scope)));
            Assert.That(response.Value.Data.OnboardingStatus, Is.EqualTo(OnboardingStatus.Onboarded));
            Assert.That(response.Value.Data.DataStatus, Is.EqualTo(DataStatus.Present));
            Assert.That(response.Value.Data.Data[0].Workspace.CustomerId, Is.EqualTo("customer"));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id.ToString()));
        }

        [Test]
        public void VmInsightsGaFactoryPreservesOptionalValues()
        {
            var data = ArmMonitorModelFactory.VmInsightsOnboardingStatusData(null, null, default, null, null, null, null, null);
            Assert.That(data.ResourceId, Is.Null);
            Assert.That(data.OnboardingStatus, Is.Null);
            Assert.That(data.DataStatus, Is.Null);
            Assert.That(data.Data, Is.Empty);
            Assert.That(ArmMonitorModelFactory.VmInsightsOnboardingStatusData().Data, Is.Empty);
            Assert.That(Attribute.IsDefined(typeof(VmInsightsOnboardingStatusResource), typeof(ObsoleteAttribute)), Is.False);
            Assert.That(Attribute.IsDefined(typeof(VmInsightsOnboardingStatusData), typeof(ObsoleteAttribute)), Is.False);
        }

        [TestCase("J")]
        [TestCase("W")]
        public void VmInsightsGaFactoryPreservesOptionalWireFields(string format)
        {
            var data = ArmMonitorModelFactory.VmInsightsOnboardingStatusData(resourceId: new ResourceIdentifier(Scope), onboardingStatus: OnboardingStatus.Onboarded);
            var options = new ModelReaderWriterOptions(format);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(data, options).ToMemory());
            var properties = json.RootElement.GetProperty("properties");
            Assert.That(properties.GetProperty("resourceId").GetString(), Is.EqualTo(Scope));
            Assert.That(properties.GetProperty("onboardingStatus").GetString(), Is.EqualTo("onboarded"));
            Assert.That(properties.TryGetProperty("dataStatus", out _), Is.False);
            var read = ModelReaderWriter.Read<VmInsightsOnboardingStatusData>(BinaryData.FromString(json.RootElement.GetRawText()), options);
            Assert.That(read.ResourceId, Is.EqualTo(new ResourceIdentifier(Scope)));
            Assert.That(read.OnboardingStatus, Is.EqualTo(OnboardingStatus.Onboarded));
            Assert.That(read.DataStatus, Is.Null);
        }
        [TestCase("J")]
        [TestCase("W")]
        public void VmInsightsGaDeserializationAcceptsNullOptionalFields(string format)
        {
            var json = BinaryData.FromString("{\"properties\":{\"resourceId\":null,\"onboardingStatus\":null,\"dataStatus\":null,\"data\":null}}");
            var data = ModelReaderWriter.Read<VmInsightsOnboardingStatusData>(json, new ModelReaderWriterOptions(format));
            Assert.That(data.ResourceId, Is.Null);
            Assert.That(data.OnboardingStatus, Is.Null);
            Assert.That(data.DataStatus, Is.Null);
            Assert.That(data.Data, Is.Empty);
        }
#pragma warning restore CS0618

        [TestCase(false)]
        [TestCase(true)]
        public async Task DiagnosticCategoryGaCollectionEnumeratesResults(bool async)
        {
            var id = DiagnosticSettingsCategoryResource.CreateResourceIdentifier(Scope, "Audit");
            var responseJson = $"{{\"value\":[{{\"id\":\"{id}\",\"name\":\"Audit\",\"type\":\"Microsoft.Insights/diagnosticSettingsCategories\",\"properties\":{{\"categoryType\":\"Logs\"}}}}]}}";
            var transport = new MockTransport(new MockResponse(200).SetContent(responseJson));
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var collection = client.GetDiagnosticSettingsCategories(new ResourceIdentifier(Scope));
            var count = 0;
            if (async)
            {
                await foreach (var category in collection.GetAllAsync())
                {
                    Assert.That(category.Data.CategoryType, Is.EqualTo(MonitorCategoryType.Logs));
                    count++;
                }
            }
            else
            {
                foreach (var category in collection.GetAll())
                {
                    Assert.That(category.Data.CategoryType, Is.EqualTo(MonitorCategoryType.Logs));
                    count++;
                }
            }

            Assert.That(count, Is.EqualTo(1));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo($"{Scope}/providers/Microsoft.Insights/diagnosticSettingsCategories"));
        }

        [TestCase(false, 0)]
        [TestCase(true, 0)]
        [TestCase(false, 1)]
        [TestCase(true, 1)]
        [TestCase(false, 2)]
        [TestCase(true, 2)]
        public async Task DiagnosticCategoryGaEntryPointsCallTheService(bool async, int entryPoint)
        {
            var id = DiagnosticSettingsCategoryResource.CreateResourceIdentifier(Scope, "Audit");
            var responseJson = $"{{\"id\":\"{id}\",\"name\":\"Audit\",\"type\":\"Microsoft.Insights/diagnosticSettingsCategories\",\"properties\":{{\"categoryType\":\"Logs\",\"categoryGroups\":[\"audit\"]}}}}";
            var rawResponse = new MockResponse(200).SetContent(responseJson);
            var transport = new MockTransport(rawResponse);
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });

            Response<DiagnosticSettingsCategoryResource> response;
            if (entryPoint == 0)
            {
                var resource = client.GetDiagnosticSettingsCategoryResource(id);
                response = async ? await resource.GetAsync() : resource.Get();
            }
            else if (entryPoint == 1)
            {
                var collection = client.GetDiagnosticSettingsCategories(new ResourceIdentifier(Scope));
                response = async ? await collection.GetAsync("Audit") : collection.Get("Audit");
            }
            else
            {
                var scope = new ResourceIdentifier(Scope);
                response = async ? await client.GetDiagnosticSettingsCategoryAsync(scope, "Audit") : client.GetDiagnosticSettingsCategory(scope, "Audit");
            }

            Assert.That(response.Value.Data.CategoryType, Is.EqualTo(MonitorCategoryType.Logs));
            Assert.That(response.Value.Data.CategoryGroups, Is.EqualTo(new[] { "audit" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Get));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id.ToString()));
        }
    }
}
