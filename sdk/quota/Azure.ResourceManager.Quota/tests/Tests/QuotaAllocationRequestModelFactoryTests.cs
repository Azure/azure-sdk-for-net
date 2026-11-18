// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    public class QuotaAllocationRequestModelFactoryTests
    {
        [TestCase(null, null, null, null, "{}", "{}")]
        [TestCase(5L, null, null, null, "{\"properties\":{\"limit\":5}}", "{\"properties\":{\"limit\":5}}")]
        [TestCase(0L, null, null, null, "{\"properties\":{\"limit\":0}}", "{\"properties\":{\"limit\":0}}")]
        [TestCase(null, null, null, "eastus", "{\"properties\":{\"region\":\"eastus\"}}", "{\"properties\":{\"region\":\"eastus\"}}")]
        [TestCase(null, "cores", null, null, "{\"properties\":{}}", "{\"properties\":{\"name\":{\"value\":\"cores\"}}}")]
        [TestCase(null, null, "Cores", null, "{\"properties\":{}}", "{\"properties\":{\"name\":{\"localizedValue\":\"Cores\"}}}")]
        [TestCase(null, "", null, null, "{\"properties\":{}}", "{\"properties\":{\"name\":{\"value\":\"\"}}}")]
        [TestCase(null, "cores", "Cores", null, "{\"properties\":{}}", "{\"properties\":{\"name\":{\"value\":\"cores\",\"localizedValue\":\"Cores\"}}}")]
        [TestCase(5L, "cores", "Cores", "eastus", "{\"properties\":{\"limit\":5,\"region\":\"eastus\"}}", "{\"properties\":{\"limit\":5,\"name\":{\"value\":\"cores\",\"localizedValue\":\"Cores\"},\"region\":\"eastus\"}}")]
        public void PreservesFactoryValuesAndSerialization(long? limit, string value, string localizedValue, string region, string wireJson, string json)
        {
            var model = ArmQuotaModelFactory.QuotaAllocationRequestBase(limit, value, localizedValue, region);

            Assert.AreEqual(limit, model.Limit);
            Assert.AreEqual(value, model.Value);
            Assert.AreEqual(localizedValue, model.LocalizedValue);
            Assert.AreEqual(region, model.Region);
            Assert.AreEqual(wireJson, ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")).ToString());
            Assert.AreEqual(json, ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json).ToString());
        }

        [Test]
        public void DefaultFactoryModelSupportsWritableProperties()
        {
            var model = ArmQuotaModelFactory.QuotaAllocationRequestBase();
            model.Limit = 5;
            model.Region = "eastus";

            Assert.AreEqual(5, model.Limit);
            Assert.AreEqual("eastus", model.Region);
            Assert.AreEqual("{\"properties\":{\"limit\":5,\"region\":\"eastus\"}}", ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")).ToString());
        }
    }
}
