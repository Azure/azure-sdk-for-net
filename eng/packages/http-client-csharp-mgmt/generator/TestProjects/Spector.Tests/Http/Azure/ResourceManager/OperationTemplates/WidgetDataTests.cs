// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure;
using Azure.Core;
using Azure.ResourceManager.OperationTemplates;
using NUnit.Framework;
using TestProjects.Spector.Tests.Infrastructure;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class WidgetDataTests : SpectorModelTests<WidgetData>
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");

        protected override string JsonPayload => """
            {
                "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Azure.ResourceManager.OperationTemplates/widgets/widget1",
                "name": "widget1",
                "type": "Azure.ResourceManager.OperationTemplates/widgets",
                "location": "eastus",
                "tags": {
                    "tagKey1": "tagValue1"
                },
                "properties": {
                    "name": "Widget One",
                    "description": "Test widget",
                    "provisioningState": "Succeeded"
                }
            }
            """;

        protected override string WirePayload => """
            {
                "location": "eastus",
                "tags": {
                    "tagKey1": "tagValue1"
                },
                "properties": {
                    "name": "Widget One",
                    "description": "Test widget"
                }
            }
            """;

        protected override WidgetData GetModelInstance()
        {
            return new WidgetData(AzureLocation.EastUS);
        }

        protected override void VerifyModel(WidgetData model, string format)
        {
            if (format == "J")
            {
                Assert.That(model.Id.ToString(), Is.EqualTo("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Azure.ResourceManager.OperationTemplates/widgets/widget1"));
                Assert.That(model.Name, Is.EqualTo("widget1"));
            }
            Assert.That(model.Location.Name, Is.EqualTo("eastus"));
            Assert.That(model.Tags, Is.Not.Null);
            Assert.That(model.Tags["tagKey1"], Is.EqualTo("tagValue1"));
            Assert.That(model.Properties, Is.Not.Null);
            Assert.That(model.Properties.Name, Is.EqualTo("Widget One"));
            Assert.That(model.Properties.Description, Is.EqualTo("Test widget"));
            if (format == "J")
            {
                Assert.That(model.Properties.ProvisioningState, Is.EqualTo("Succeeded"));
            }
        }

        protected override void CompareModels(WidgetData model, WidgetData model2, string format)
        {
            Assert.That(model2.Id, Is.EqualTo(model.Id));
            Assert.That(model2.Name, Is.EqualTo(model.Name));
            Assert.That(model2.Location, Is.EqualTo(model.Location));
            Assert.That(model2.Properties?.Name, Is.EqualTo(model.Properties?.Name));
            Assert.That(model2.Properties?.Description, Is.EqualTo(model.Properties?.Description));
            Assert.That(model2.Properties?.ProvisioningState, Is.EqualTo(model.Properties?.ProvisioningState));
        }

        protected override WidgetData ToModel(Response response)
        {
            return ModelReaderWriter.Read<WidgetData>(response.Content, _wireOptions)!;
        }

        protected override RequestContent ToRequestContent(WidgetData model)
        {
            var binaryData = ModelReaderWriter.Write(model, _wireOptions);
            return RequestContent.Create(binaryData);
        }
    }
}
