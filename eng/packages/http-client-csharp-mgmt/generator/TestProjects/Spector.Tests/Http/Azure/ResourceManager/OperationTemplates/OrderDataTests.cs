// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using NUnit.Framework;
using TestProjects.Spector.Tests.Infrastructure;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class OrderDataTests : SpectorModelTests<OrderData>
    {
        private static readonly ModelReaderWriterOptions _wireOptions = new ModelReaderWriterOptions("W");

        protected override string JsonPayload => """
            {
                "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Azure.ResourceManager.OperationTemplates/orders/order1",
                "name": "order1",
                "type": "Azure.ResourceManager.OperationTemplates/orders",
                "location": "eastus",
                "tags": {
                    "tagKey1": "tagValue1"
                },
                "properties": {
                    "productId": "product1",
                    "amount": 5,
                    "provisioningState": "Succeeded"
                }
            }
            """;

        protected override string WirePayload => JsonPayload;

        protected override OrderData GetModelInstance()
        {
            return new OrderData(AzureLocation.EastUS);
        }

        protected override void VerifyModel(OrderData model, string format)
        {
            Assert.AreEqual("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Azure.ResourceManager.OperationTemplates/orders/order1", model.Id.ToString());
            Assert.AreEqual("order1", model.Name);
            Assert.AreEqual("eastus", model.Location.Name);
            Assert.IsNotNull(model.Tags);
            Assert.AreEqual("tagValue1", model.Tags["tagKey1"]);
            Assert.IsNotNull(model.Properties);
            Assert.AreEqual("product1", model.Properties.ProductId);
            Assert.AreEqual(5, model.Properties.Amount);
            Assert.AreEqual("Succeeded", model.Properties.ProvisioningState);
        }

        protected override void CompareModels(OrderData model, OrderData model2, string format)
        {
            Assert.AreEqual(model.Id, model2.Id);
            Assert.AreEqual(model.Name, model2.Name);
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(model.Properties?.ProductId, model2.Properties?.ProductId);
            Assert.AreEqual(model.Properties?.Amount, model2.Properties?.Amount);
            Assert.AreEqual(model.Properties?.ProvisioningState, model2.Properties?.ProvisioningState);
        }

        protected override OrderData ToModel(Response response)
        {
            // Use ModelReaderWriter to deserialize since the FromResponse method is internal
            return ModelReaderWriter.Read<OrderData>(response.Content, _wireOptions)!;
        }

        protected override RequestContent ToRequestContent(OrderData model)
        {
            // Use ModelReaderWriter to serialize since the ToRequestContent method is internal
            var binaryData = ModelReaderWriter.Write(model, _wireOptions);
            return RequestContent.Create(binaryData);
        }
    }
}
