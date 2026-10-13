// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.BillingBenefits.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class SavingsPlanValidateResponseTests
    {
        [Test]
        public void FactoryKeepsWrapperAndItemModelsDistinct()
        {
            var item = ArmBillingBenefitsModelFactory.SavingsPlanValidationDetail(false, "InvalidScope", "Scope is invalid");
            var response = ArmBillingBenefitsModelFactory.SavingsPlanValidateResult(new[] { item }, "https://example.com/next");

            Assert.That(response.Benefits, Has.Count.EqualTo(1));
            Assert.That(response.Benefits[0], Is.SameAs(item));
            Assert.That(response.NextLink, Is.EqualTo("https://example.com/next"));
        }

        [TestCase("J")]
        [TestCase("W")]
        public void DeserializationPreservesWrapperAndItemProperties(string format)
        {
            var json = BinaryData.FromString("{\"benefits\":[{\"valid\":false,\"reasonCode\":\"InvalidScope\",\"reason\":\"Scope is invalid\"}],\"nextLink\":\"https://example.com/next\"}");
            var response = ModelReaderWriter.Read<SavingsPlanValidateResult>(json, new ModelReaderWriterOptions(format));

            Assert.That(response.Benefits, Has.Count.EqualTo(1));
            Assert.That(response.Benefits[0].IsValid, Is.False);
            Assert.That(response.Benefits[0].ReasonCode, Is.EqualTo("InvalidScope"));
            Assert.That(response.Benefits[0].Reason, Is.EqualTo("Scope is invalid"));
            Assert.That(response.NextLink, Is.EqualTo("https://example.com/next"));
        }
    }
}
