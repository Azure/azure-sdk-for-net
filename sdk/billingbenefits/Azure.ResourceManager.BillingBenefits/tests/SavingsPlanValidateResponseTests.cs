// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BillingBenefits.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class SavingsPlanValidateResponseTests
    {
        private const string ResponseJson = "{\"benefits\":[{\"valid\":false,\"reasonCode\":\"InvalidScope\",\"reason\":\"Scope is invalid\"}],\"nextLink\":\"https://example.com/next\"}";

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
            var response = ModelReaderWriter.Read<SavingsPlanValidateResult>(BinaryData.FromString(ResponseJson), new ModelReaderWriterOptions(format));

            AssertResponse(response);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ValidateUpdatePreservesWrapperAndItemProperties(bool async)
        {
            var rawResponse = new MockResponse(200).SetContent(ResponseJson);
            var transport = new MockTransport(rawResponse);
            var client = new ArmClient(new MockCredential(), defaultSubscriptionId: null, options: new ArmClientOptions { Transport = transport });
            var id = BillingBenefitsSavingsPlanResource.CreateResourceIdentifier("order", "plan");
            var resource = client.GetBillingBenefitsSavingsPlanResource(id);
            var content = new SavingsPlanUpdateValidateContent();

            var response = async
                ? await resource.ValidateUpdateAsync(content)
                : resource.ValidateUpdate(content);

            AssertResponse(response.Value);
            Assert.That(response.GetRawResponse(), Is.SameAs(rawResponse));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.Requests[0].Method, Is.EqualTo(RequestMethod.Post));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(id + "/validate"));
        }

        private static void AssertResponse(SavingsPlanValidateResult response)
        {
            Assert.That(response.Benefits, Has.Count.EqualTo(1));
            Assert.That(response.Benefits[0].IsValid, Is.False);
            Assert.That(response.Benefits[0].ReasonCode, Is.EqualTo("InvalidScope"));
            Assert.That(response.Benefits[0].Reason, Is.EqualTo("Scope is invalid"));
            Assert.That(response.NextLink, Is.EqualTo("https://example.com/next"));
        }
    }
}
