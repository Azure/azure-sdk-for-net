// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Azure.Generator.Management.Providers;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    public class ResourceVisitorTests
    {
        [Test]
        public void ResourceModelRenameClearsStaleResourceClientCustomCodeView()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var resourceModel = models.Single();
            _ = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var modelProvider = new ResourceDataModelProvider(resourceModel);
            Assert.That(modelProvider.Name, Is.EqualTo("ResponseTypeData"));
            Assert.That(modelProvider.CustomCodeView, Is.Null);

            var visitor = new TestableResourceVisitor();
            var result = visitor.InvokePreVisitModel(resourceModel, modelProvider);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("ResponseTypeData"));
            Assert.That(result.BaseType?.FrameworkType, Is.Not.EqualTo(typeof(ArmResource)));
        }

        [Test]
        public void ResourceDataModelUsesTrackedResourceDataBase()
        {
            var trackedResourceModel = InputFactory.Model(
                "TrackedResource",
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            typeof(InputModelType).GetProperty(nameof(InputModelType.CrossLanguageDefinitionId))!
                .GetSetMethod(true)!
                .Invoke(trackedResourceModel, ["Azure.ResourceManager.CommonTypes.TrackedResource"]);

            var resourceModel = InputFactory.Model(
                "NewRelicMonitorResource",
                properties: [InputFactory.Property("properties", InputPrimitiveType.String)],
                baseModel: trackedResourceModel,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            _ = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [trackedResourceModel, resourceModel]);

            var modelProvider = new ResourceDataModelProvider(resourceModel);

            Assert.That(modelProvider.Name, Is.EqualTo("NewRelicMonitorResourceData"));
            Assert.That(modelProvider.BaseType?.AreNamesEqual(new CSharpType(typeof(TrackedResourceData))), Is.True);
        }

        private class TestableResourceVisitor : ResourceVisitor
        {
            public ModelProvider? InvokePreVisitModel(InputModelType inputType, ModelProvider? type)
            {
                return base.PreVisitModel(inputType, type);
            }
        }
    }
}
